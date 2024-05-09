const std = @import("std");
const builtin = @import("builtin");
const Build = std.Build;
const Step = std.Build.Step;
const OptimizeMode = std.builtin.OptimizeMode;

pub const SokolBackend = enum {
    auto, // Windows: D3D11, macOS/iOS: Metal, otherwise: GL
    d3d11,
    metal,
    gl,
    gles3,
    wgpu,
};

// helper function to resolve .auto backend based on target platform
pub fn resolveSokolBackend(backend: SokolBackend, target: std.Target) SokolBackend {
    if (backend != .auto) {
        return backend;
    } else if (target.isDarwin()) {
        return .metal;
    } else if (target.os.tag == .windows) {
        return .d3d11;
    } else if (target.isWasm()) {
        return .gles3;
    } else if (target.isAndroid()) {
        return .gles3;
    } else {
        return .gl;
    }
}

pub fn build(b: *Build) !void {
    const opt_use_gl = b.option(bool, "gl", "Force OpenGL (default: false)") orelse false;
    const opt_use_wgpu = b.option(bool, "wgpu", "Force WebGPU (default: false, web only)") orelse false;
    const opt_use_x11 = b.option(bool, "x11", "Force X11 (default: true, Linux only)") orelse true;
    const opt_use_wayland = b.option(bool, "wayland", "Force Wayland (default: false, Linux only, not supported in main-line headers)") orelse false;
    const opt_use_egl = b.option(bool, "egl", "Force EGL (default: false, Linux only)") orelse false;
    const sokol_backend: SokolBackend = if (opt_use_gl) .gl else if (opt_use_wgpu) .wgpu else .auto;

    const target = b.standardTargetOptions(.{});
    const optimize = b.standardOptimizeOption(.{});
    const emsdk = b.dependency("emsdk", .{});

    const dll = b.addSharedLibrary(.{
        .name = "sokol",
        .target = target,
        .optimize = optimize,
        .link_libc = true,
    });
    dll.linkLibCpp();
    // dll.linkLibC();

    try buildLibSokol(b, dll, .{
        .target = target,
        .optimize = optimize,
        .backend = sokol_backend,
        .use_wayland = opt_use_wayland,
        .use_x11 = opt_use_x11,
        .use_egl = opt_use_egl,
        .emsdk = emsdk,
    });
    b.installArtifact(dll);
}

// build the sokol C headers
pub const LibSokolOptions = struct {
    target: Build.ResolvedTarget,
    optimize: OptimizeMode,
    backend: SokolBackend = .auto,
    use_egl: bool = false,
    use_x11: bool = true,
    use_wayland: bool = false,
    emsdk: ?*Build.Dependency = null,
};
pub fn buildLibSokol(b: *Build, lib: *Step.Compile, options: LibSokolOptions) !void {
    if (options.target.result.isWasm()) {
        // make sure we're building for the wasm32-emscripten target, not wasm32-freestanding
        if (lib.rootModuleTarget().os.tag != .emscripten) {
            std.log.err("Please build with 'zig build -Dtarget=wasm32-emscripten", .{});
            return error.Wasm32EmscriptenExpected;
        }

        // one-time setup of Emscripten SDK
        if (try emSdkSetupStep(b, options.emsdk.?)) |emsdk_setup| {
            lib.step.dependOn(&emsdk_setup.step);
        }
        // add the Emscripten system include seach path
        const emsdk_sysroot = b.pathJoin(&.{ emSdkPath(b, options.emsdk.?), "upstream", "emscripten", "cache", "sysroot" });
        const include_path = b.pathJoin(&.{ emsdk_sysroot, "include" });
        lib.addSystemIncludePath(.{ .path = include_path });
    }

    // resolve .auto backend into specific backend by platform
    const backend = resolveSokolBackend(options.backend, lib.rootModuleTarget());
    const backend_cflags = switch (backend) {
        .d3d11 => "-DSOKOL_D3D11",
        .metal => "-DSOKOL_METAL",
        .gl => "-DSOKOL_GLCORE33",
        .gles3 => "-DSOKOL_GLES3",
        .wgpu => "-DSOKOL_WGPU",
        else => @panic("unknown sokol backend"),
    };

    // platform specific compile and link options
    var cflags: []const []const u8 = &.{ "-DIMPL", backend_cflags };
    var cppflags: []const []const u8 = &.{ "-DIMPL", backend_cflags };
    if (lib.rootModuleTarget().isDarwin()) {
        b.lib_dir = "../Dinghy.Core/runtimes/osx-arm64/native";
        cflags = &.{ "-ObjC", "-DIMPL", backend_cflags };
        cppflags = &.{ "-ObjC++", "-DIMPL", backend_cflags };
        lib.linkFramework("Foundation");
        lib.linkFramework("AudioToolbox");
        if (.metal == backend) {
            lib.linkFramework("MetalKit");
            lib.linkFramework("Metal");
        }
        if (lib.rootModuleTarget().os.tag == .ios) {
            lib.linkFramework("UIKit");
            lib.linkFramework("AVFoundation");
            if (.gl == backend) {
                lib.linkFramework("OpenGLES");
                lib.linkFramework("GLKit");
            }
        } else if (lib.rootModuleTarget().os.tag == .macos) {
            lib.linkFramework("Cocoa");
            lib.linkFramework("QuartzCore");
            if (.gl == backend) {
                lib.linkFramework("OpenGL");
            }
        }
    } else if (lib.rootModuleTarget().isAndroid()) {
        if (.gles3 != backend) {
            @panic("For android targets, you must have backend set to GLES3");
        }
        lib.linkSystemLibrary("GLESv3");
        lib.linkSystemLibrary("EGL");
        lib.linkSystemLibrary("android");
        lib.linkSystemLibrary("log");
    } else if (lib.rootModuleTarget().os.tag == .linux) {
        b.lib_dir = "../Dinghy.Core/runtimes/linux-x64/native";
        const egl_cflags = if (options.use_egl) "-DSOKOL_FORCE_EGL " else "";
        const x11_cflags = if (!options.use_x11) "-DSOKOL_DISABLE_X11 " else "";
        const wayland_cflags = if (!options.use_wayland) "-DSOKOL_DISABLE_WAYLAND" else "";
        const link_egl = options.use_egl or options.use_wayland;
        cflags = &.{ "-DIMPL", backend_cflags, egl_cflags, x11_cflags, wayland_cflags };
        cppflags = &.{ "-DIMPL", backend_cflags, egl_cflags, x11_cflags, wayland_cflags };
        lib.linkSystemLibrary("asound");
        lib.linkSystemLibrary("GL");
        if (options.use_x11) {
            lib.linkSystemLibrary("X11");
            lib.linkSystemLibrary("Xi");
            lib.linkSystemLibrary("Xcursor");
        }
        if (options.use_wayland) {
            lib.linkSystemLibrary("wayland-client");
            lib.linkSystemLibrary("wayland-cursor");
            lib.linkSystemLibrary("wayland-egl");
            lib.linkSystemLibrary("xkbcommon");
        }
        if (link_egl) {
            lib.linkSystemLibrary("EGL");
        }
    } else if (lib.rootModuleTarget().os.tag == .windows) {
        b.lib_dir = "../Dinghy.Core/runtimes/win-x64/native";
        lib.linkSystemLibrary("kernel32");
        lib.linkSystemLibrary("user32");
        lib.linkSystemLibrary("gdi32");
        lib.linkSystemLibrary("ole32");
        if (.d3d11 == backend) {
            lib.linkSystemLibrary("d3d11");
            lib.linkSystemLibrary("dxgi");
        }
    }

    const cpp_sources = [_][]const u8{
        "imgui.cpp",
        "../../cimgui/src/cimgui/cimgui.cpp",
        "../../cimgui/src/cimgui/imgui/imgui.cpp",
        "../../cimgui/src/cimgui/imgui/imgui_demo.cpp",
        "../../cimgui/src/cimgui/imgui/imgui_draw.cpp",
        "../../cimgui/src/cimgui/imgui/imgui_tables.cpp",
        "../../cimgui/src/cimgui/imgui/imgui_widgets.cpp",
    };

    const c_sources = [_][]const u8{"sokol.c"};

    // lib.addCSourceFiles(.{
    //     // .root = csrc_root,
    //     .files = c_sources,
    //     .flags = cflags,
    // });

    // lib.addCSourceFiles(.{
    //     // .root = csrc_root,
    //     .files = cpp_sources,
    //     .flags = cppflags,
    // });

    inline for (c_sources) |csrc| {
        lib.addCSourceFile(.{
            .file = .{ .path = csrc },
            .flags = cflags,
        });
    }
    inline for (cpp_sources) |csrc| {
        lib.addCSourceFile(.{
            .file = .{ .path = csrc },
            .flags = cppflags,
        });
    }
    // return lib;
}

// helper function to extract emsdk path from the emsdk package dependency
fn emSdkPath(b: *Build, emsdk: *Build.Dependency) []const u8 {
    return emsdk.path("").getPath(b);
}

// One-time setup of the Emscripten SDK (runs 'emsdk install + activate'). If the
// SDK had to be setup, a run step will be returned which should be added
// as dependency to the sokol library (since this needs the emsdk in place),
// if the emsdk was already setup, null will be returned.
// NOTE: ideally this would go into a separate emsdk-zig package
fn emSdkSetupStep(b: *Build, emsdk: *Build.Dependency) !?*Build.Step.Run {
    const emsdk_path = emSdkPath(b, emsdk);
    const dot_emsc_path = b.pathJoin(&.{ emsdk_path, ".emscripten" });
    const dot_emsc_exists = !std.meta.isError(std.fs.accessAbsolute(dot_emsc_path, .{}));
    if (!dot_emsc_exists) {
        var cmd = std.ArrayList([]const u8).init(b.allocator);
        defer cmd.deinit();
        if (builtin.os.tag == .windows)
            try cmd.append(b.pathJoin(&.{ emsdk_path, "emsdk.bat" }))
        else {
            try cmd.append("bash"); // or try chmod
            try cmd.append(b.pathJoin(&.{ emsdk_path, "emsdk" }));
        }
        const emsdk_install = b.addSystemCommand(cmd.items);
        emsdk_install.addArgs(&.{ "install", "latest" });
        const emsdk_activate = b.addSystemCommand(cmd.items);
        emsdk_activate.addArgs(&.{ "activate", "latest" });
        emsdk_activate.step.dependOn(&emsdk_install.step);
        return emsdk_activate;
    } else {
        return null;
    }
}
