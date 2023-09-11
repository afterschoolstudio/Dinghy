const std = @import("std");
const builtin = @import("builtin");
const Builder = std.build.Builder;
const LibExeObjStep = std.build.LibExeObjStep;
const CrossTarget = std.zig.CrossTarget;
const Mode = std.builtin.Mode;

pub const Backend = enum {
    auto,   // Windows: D3D11, macOS/iOS: Metal, otherwise: GL
    d3d11,
    metal,
    gl,
    gles2,
    gles3,
    wgpu,
};

pub const Config = struct {
    backend: Backend = .auto,
    force_egl: bool = false,

    enable_x11: bool = true,
    enable_wayland: bool = false
};

// Although this function looks imperative, note that its job is to
// declaratively construct a build graph that will be executed by an external
// runner.
pub fn build(b: *std.Build) void {

        var config: Config = .{};

    const force_gl = b.option(bool, "gl", "Force GL backend") orelse false;
    config.backend = if (force_gl) .gl else .auto;

    // NOTE: Wayland support is *not* currently supported in the standard sokol-zig bindings,
    // you need to generate your own bindings using this PR: https://github.com/floooh/sokol/pull/425
    config.enable_wayland = b.option(bool, "wayland", "Compile with wayland-support (default: false)") orelse false;
    config.enable_x11 = b.option(bool, "x11", "Compile with x11-support (default: true)") orelse true;
    config.force_egl = b.option(bool, "egl", "Use EGL instead of GLX if possible (default: false)") orelse false;

    const target = b.standardTargetOptions(.{});

    const lib = b.addSharedLibrary(.{
        .name = "sokol",
        .target = target,
        // Standard optimization options allow the person running `zig build` to select
        // between Debug, ReleaseSafe, ReleaseFast, and ReleaseSmall. Here we do not
        // set a preferred release mode, allowing the user to decide how to optimize.
        .optimize = b.standardOptimizeOption(.{})
    });
    lib.linkLibC();


    const sokol_path = "";
    const csources = [_][]const u8 {
        "sokol.c"
        // "sokol_app.c",
        // "sokol_gfx.c",
        // "sokol_time.c",
        // "sokol_audio.c",
        // "sokol_gl.c",
        // "sokol_debugtext.c",
        // "sokol_shape.c",
    };
    var _backend = config.backend;
    if (_backend == .auto) {
        if (lib.target.isDarwin()) { _backend = .metal; }
        else if (lib.target.isWindows()) { _backend = .d3d11; }
        else { _backend = .gl; }
    }
    const backend_option = switch (_backend) {
        .d3d11 => "-DSOKOL_D3D11",
        .metal => "-DSOKOL_METAL",
        .gl => "-DSOKOL_GLCORE33",
        .gles2 => "-DSOKOL_GLES2",
        .gles3 => "-DSOKOL_GLES3",
        .wgpu => "-DSOKOL_WGPU",
        else => unreachable,
    };

    if (lib.target.isDarwin()) {
        inline for (csources) |csrc| {
            lib.addCSourceFile(sokol_path ++ csrc, &[_][]const u8{"-ObjC", "-DIMPL", backend_option});
        }
        lib.linkFramework("Cocoa");
        lib.linkFramework("QuartzCore");
        lib.linkFramework("AudioToolbox");
        if (.metal == _backend) {
            lib.linkFramework("MetalKit");
            lib.linkFramework("Metal");
        }
        else {
            lib.linkFramework("OpenGL");
        }
    } else {
        var egl_flag = if (config.force_egl) "-DSOKOL_FORCE_EGL " else "";
        var x11_flag = if (!config.enable_x11) "-DSOKOL_DISABLE_X11 " else "";
        var wayland_flag = if (!config.enable_wayland) "-DSOKOL_DISABLE_WAYLAND" else "";

        inline for (csources) |csrc| {
            lib.addCSourceFile(sokol_path ++ csrc, &[_][]const u8{"-DIMPL", backend_option, egl_flag, x11_flag, wayland_flag});
        }

        if (lib.target.isLinux()) {
            var link_egl = config.force_egl or config.enable_wayland;
            var egl_ensured = (config.force_egl and config.enable_x11) or config.enable_wayland;

            lib.linkSystemLibrary("asound");

            if (.gles2 == _backend) {
                lib.linkSystemLibrary("glesv2");
                if (!egl_ensured) {
                    @panic("GLES2 in Linux only available with Config.force_egl and/or Wayland");
                }
            } else {
                lib.linkSystemLibrary("GL");
            }
            if (config.enable_x11) {
                lib.linkSystemLibrary("X11");
                lib.linkSystemLibrary("Xi");
                lib.linkSystemLibrary("Xcursor");
            }
            if (config.enable_wayland) {
                lib.linkSystemLibrary("wayland-client");
                lib.linkSystemLibrary("wayland-cursor");
                lib.linkSystemLibrary("wayland-egl");
                lib.linkSystemLibrary("xkbcommon");
            }
            if (link_egl) {
                lib.linkSystemLibrary("egl");
            }
        }
        else if (lib.target.isWindows()) {
            lib.linkSystemLibraryName("kernel32");
            lib.linkSystemLibraryName("user32");
            lib.linkSystemLibraryName("gdi32");
            lib.linkSystemLibraryName("ole32");
            if (.d3d11 == _backend) {
                lib.linkSystemLibraryName("d3d11");
                lib.linkSystemLibraryName("dxgi");
            }
        }
    }

    // lib.setBuildMode(mode);
    // shared_lib.setTarget(target);
    // shared_lib.addCSourceFile("sokol.c",&.{ "-Wall", "-Werror" });
    // shared_lib.addCSourceFile("sokol.c",&.{ "-Wall", "-Werror"});

    //windows
    // shared_lib.linkSystemLibrary("win32");
    // shared_lib.linkSystemLibrary("kernel32");
    // shared_lib.linkSystemLibrary("user32");
    // shared_lib.linkSystemLibrary("shell32");
    // shared_lib.linkSystemLibrary("dxgi");
    // shared_lib.linkSystemLibrary("d3d11");

    b.installArtifact(lib);
}