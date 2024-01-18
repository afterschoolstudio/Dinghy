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

pub fn build(b: *std.Build) void {

    var config: Config = .{};
        
    const force_gl = b.option(bool, "gl", "Force GL backend") orelse false;
    config.backend = if (force_gl) .gl else .auto;
    config.enable_wayland = b.option(bool, "wayland", "Compile with wayland-support (default: false)") orelse false;
    config.enable_x11 = b.option(bool, "x11", "Compile with x11-support (default: true)") orelse true;
    config.force_egl = b.option(bool, "egl", "Use EGL instead of GLX if possible (default: false)") orelse false;

    const target = b.standardTargetOptions(.{});
    const optimize = b.standardOptimizeOption(.{});
    
    const cpp_sources = [_][]const u8 {
        "imgui.cpp",
        "../../cimgui/src/cimgui/cimgui.cpp",
        "../../cimgui/src/cimgui/imgui/imgui.cpp",
        "../../cimgui/src/cimgui/imgui/imgui_demo.cpp",
        "../../cimgui/src/cimgui/imgui/imgui_draw.cpp",
        "../../cimgui/src/cimgui/imgui/imgui_tables.cpp",
        "../../cimgui/src/cimgui/imgui/imgui_widgets.cpp",
    };
    
    const c_sources = [_][]const u8 {
        "sokol.c"
    };
    
     const dll = b.addSharedLibrary(.{
        .name = "sokol",
        .target = target,
        .optimize = optimize
    });
    dll.linkLibCpp();
    dll.linkLibC();
    
    var _backend = config.backend;
    if (_backend == .auto) {
        if (dll.target.isDarwin()) { _backend = .metal; }
        else if (dll.target.isWindows()) { _backend = .d3d11; }
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

    if (dll.target.isDarwin()) {
        b.lib_dir = "../../../../Dinghy.Core/libs/osx-x64/native";
        
        inline for (c_sources) |csrc| {
            dll.addCSourceFile(.{
                .file = .{ .path = csrc },
                .flags = &[_][]const u8{ "-ObjC", "-DIMPL", backend_option },
            });
        }
        inline for (cpp_sources) |csrc| {
            dll.addCSourceFile(.{
                .file = .{ .path = csrc },
                .flags = &[_][]const u8{ "-ObjC++", "-DIMPL", backend_option },
            });
        }
        dll.linkFramework("Cocoa");
        dll.linkFramework("QuartzCore");
        dll.linkFramework("AudioToolbox");
        if (.metal == _backend) {
            dll.linkFramework("MetalKit");
            dll.linkFramework("Metal");
        }
        else {
            dll.linkFramework("OpenGL");
        }
    } else {
        var egl_flag = if (config.force_egl) "-DSOKOL_FORCE_EGL " else "";
        var x11_flag = if (!config.enable_x11) "-DSOKOL_DISABLE_X11 " else "";
        var wayland_flag = if (!config.enable_wayland) "-DSOKOL_DISABLE_WAYLAND" else "";

        inline for (c_sources) |csrc| {
            dll.addCSourceFile(.{
                .file = .{ .path = csrc },
                .flags = &[_][]const u8{ "-DIMPL", backend_option, egl_flag, x11_flag, wayland_flag },
            });
        }
        inline for (cpp_sources) |csrc| {
            dll.addCSourceFile(.{
                .file = .{ .path = csrc },
                .flags = &[_][]const u8{ "-DIMPL", backend_option, egl_flag, x11_flag, wayland_flag },
            });
        }

        if (dll.target.isLinux()) {
            b.lib_dir = "../../../../Dinghy.Core/libs/linux-x64/native";
        
            var link_egl = config.force_egl or config.enable_wayland;
            var egl_ensured = (config.force_egl and config.enable_x11) or config.enable_wayland;

            dll.linkSystemLibrary("asound");

            if (.gles2 == _backend) {
                dll.linkSystemLibrary("glesv2");
                if (!egl_ensured) {
                    @panic("GLES2 in Linux only available with Config.force_egl and/or Wayland");
                }
            } else {
                dll.linkSystemLibrary("GL");
            }
            if (config.enable_x11) {
                dll.linkSystemLibrary("X11");
                dll.linkSystemLibrary("Xi");
                dll.linkSystemLibrary("Xcursor");
                
            }
            if (config.enable_wayland) {
                dll.linkSystemLibrary("wayland-client");
                dll.linkSystemLibrary("wayland-cursor");
                dll.linkSystemLibrary("wayland-egl");
                dll.linkSystemLibrary("xkbcommon");
                
            }
            if (link_egl) {
                dll.linkSystemLibrary("egl");
            }
        }
        else if (dll.target.isWindows()) {
            //if running zig build in same folder
            // b.lib_dir = "../../../../Dinghy.Core/libs/win-x64/native";
            //if running zig build from parent project folder
            b.lib_dir = "../Dinghy.Core/libs/win-x64/native";
        
            dll.linkSystemLibraryName("kernel32");
            dll.linkSystemLibraryName("user32");
            dll.linkSystemLibraryName("gdi32");
            dll.linkSystemLibraryName("ole32");
            if (.d3d11 == _backend) {
                dll.linkSystemLibraryName("d3d11");
                dll.linkSystemLibraryName("dxgi");
            }
        }
    }
    
    b.installArtifact(dll);
}