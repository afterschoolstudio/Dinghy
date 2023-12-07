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
    
    // static imgui compile
    const imgui_lib = b.addStaticLibrary(.{
         .name = "imgui",
         .target = target,
         .optimize = optimize
    });
    const imgui_sources = [_][]const u8 {
        "imgui.cpp",
        "../../cimgui/src/cimgui/cimgui.cpp",
        "../../cimgui/src/cimgui/imgui/imgui.cpp",
        "../../cimgui/src/cimgui/imgui/imgui_demo.cpp",
        "../../cimgui/src/cimgui/imgui/imgui_draw.cpp",
        "../../cimgui/src/cimgui/imgui/imgui_tables.cpp",
        "../../cimgui/src/cimgui/imgui/imgui_widgets.cpp",
    };
    imgui_lib.linkLibCpp();
    
    //static sokol compile
    const sokol_lib = b.addStaticLibrary(.{
        .name = "sokol",
        .target = target,
        .optimize = optimize
    });
    const sokol_sources = [_][]const u8 {
        "sokol.c"
    };
    sokol_lib.linkLibC();
    
    var _backend = config.backend;
    if (_backend == .auto) {
        if (sokol_lib.target.isDarwin()) { _backend = .metal; }
        else if (sokol_lib.target.isWindows()) { _backend = .d3d11; }
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

    if (sokol_lib.target.isDarwin()) {
        inline for (sokol_sources) |csrc| {
            sokol_lib.addCSourceFile(.{
                .file = .{ .path = csrc },
                .flags = &[_][]const u8{ "-ObjC", "-DIMPL", backend_option },
            });
        }
        inline for (imgui_sources) |csrc| {
            imgui_lib.addCSourceFile(.{
                .file = .{ .path = csrc },
                .flags = &[_][]const u8{ "-ObjC++", "-DIMPL", backend_option },
            });
        }
        sokol_lib.linkFramework("Cocoa");
        sokol_lib.linkFramework("QuartzCore");
        sokol_lib.linkFramework("AudioToolbox");
        
        imgui_lib.linkFramework("Cocoa");
        imgui_lib.linkFramework("QuartzCore");
        imgui_lib.linkFramework("AudioToolbox");
        
        if (.metal == _backend) {
            sokol_lib.linkFramework("MetalKit");
            sokol_lib.linkFramework("Metal");
            
            imgui_lib.linkFramework("MetalKit");
            imgui_lib.linkFramework("Metal");
        }
        else {
            sokol_lib.linkFramework("OpenGL");
            imgui_lib.linkFramework("OpenGL");
        }
    } else {
        var egl_flag = if (config.force_egl) "-DSOKOL_FORCE_EGL " else "";
        var x11_flag = if (!config.enable_x11) "-DSOKOL_DISABLE_X11 " else "";
        var wayland_flag = if (!config.enable_wayland) "-DSOKOL_DISABLE_WAYLAND" else "";

        inline for (sokol_sources) |csrc| {
            sokol_lib.addCSourceFile(.{
                .file = .{ .path = csrc },
                .flags = &[_][]const u8{ "-DIMPL", backend_option, egl_flag, x11_flag, wayland_flag },
            });
        }
        inline for (imgui_sources) |csrc| {
            imgui_lib.addCSourceFile(.{
                .file = .{ .path = csrc },
                .flags = &[_][]const u8{ "-DIMPL", backend_option, egl_flag, x11_flag, wayland_flag },
            });
        }

        if (sokol_lib.target.isLinux()) {
            var link_egl = config.force_egl or config.enable_wayland;
            var egl_ensured = (config.force_egl and config.enable_x11) or config.enable_wayland;

            sokol_lib.linkSystemLibrary("asound");
            imgui_lib.linkSystemLibrary("asound");

            if (.gles2 == _backend) {
                sokol_lib.linkSystemLibrary("glesv2");
                imgui_lib.linkSystemLibrary("glesv2");
                if (!egl_ensured) {
                    @panic("GLES2 in Linux only available with Config.force_egl and/or Wayland");
                }
            } else {
                sokol_lib.linkSystemLibrary("GL");
                imgui_lib.linkSystemLibrary("GL");
            }
            if (config.enable_x11) {
                sokol_lib.linkSystemLibrary("X11");
                sokol_lib.linkSystemLibrary("Xi");
                sokol_lib.linkSystemLibrary("Xcursor");
                
                imgui_lib.linkSystemLibrary("X11");
                imgui_lib.linkSystemLibrary("Xi");
                imgui_lib.linkSystemLibrary("Xcursor");
            }
            if (config.enable_wayland) {
                sokol_lib.linkSystemLibrary("wayland-client");
                sokol_lib.linkSystemLibrary("wayland-cursor");
                sokol_lib.linkSystemLibrary("wayland-egl");
                sokol_lib.linkSystemLibrary("xkbcommon");
                
                imgui_lib.linkSystemLibrary("wayland-client");
                imgui_lib.linkSystemLibrary("wayland-cursor");
                imgui_lib.linkSystemLibrary("wayland-egl");
                imgui_lib.linkSystemLibrary("xkbcommon");
            }
            if (link_egl) {
                sokol_lib.linkSystemLibrary("egl");
                imgui_lib.linkSystemLibrary("egl");
            }
        }
        else if (sokol_lib.target.isWindows()) {
            sokol_lib.linkSystemLibraryName("kernel32");
            sokol_lib.linkSystemLibraryName("user32");
            sokol_lib.linkSystemLibraryName("gdi32");
            sokol_lib.linkSystemLibraryName("ole32");
            if (.d3d11 == _backend) {
                sokol_lib.linkSystemLibraryName("d3d11");
                sokol_lib.linkSystemLibraryName("dxgi");
            }
            
            imgui_lib.linkSystemLibraryName("kernel32");
            imgui_lib.linkSystemLibraryName("user32");
            imgui_lib.linkSystemLibraryName("gdi32");
            imgui_lib.linkSystemLibraryName("ole32");
            if (.d3d11 == _backend) {
                imgui_lib.linkSystemLibraryName("d3d11");
                imgui_lib.linkSystemLibraryName("dxgi");
            }
        }
    }
    
    const dll = b.addSharedLibrary(.{
        .name = "sokol",
        .target = target,
        .optimize = optimize
    });
    dll.linkLibrary(imgui_lib);
    dll.linkLibrary(sokol_lib);
    
    b.lib_dir = "../../../../Dinghy.Core/libs";
    b.installArtifact(dll);
}