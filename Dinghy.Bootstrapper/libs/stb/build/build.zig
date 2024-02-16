const std = @import("std");
const builtin = @import("builtin");
const Builder = std.build.Builder;
const LibExeObjStep = std.build.LibExeObjStep;
const CrossTarget = std.zig.CrossTarget;
const Mode = std.builtin.Mode;

// Although this function looks imperative, note that its job is to
// declaratively construct a build graph that will be executed by an external
// runner.
pub fn build(b: *std.Build) void {
    const target = b.standardTargetOptions(.{});
    const lib = b.addSharedLibrary(.{
        .name = "stb",
        .target = target,
        // Standard optimization options allow the person running `zig build` to select
        // between Debug, ReleaseSafe, ReleaseFast, and ReleaseSmall. Here we do not
        // set a preferred release mode, allowing the user to decide how to optimize.
        .optimize = b.standardOptimizeOption(.{})
    });
    lib.linkLibC();
    
    // const csources = [_][]const u8 {
    //     "stb.c"
    // };
    lib.addCSourceFile(.{
        .file = .{ .path = "stb.c" },
        .flags = &[_][]const u8{},
    });
    
    if (lib.target.isDarwin()) {
        // b.lib_dir = "../../../../Dinghy.Core/libs/osx-x64/native";
        b.lib_dir = "../Dinghy.Core/runtimes/osx-arm64/native";
    } else {
        if (lib.target.isLinux()) {
            // b.lib_dir = "../../../../Dinghy.Core/libs/linux-x64/native";
            b.lib_dir = "../Dinghy.Core/runtimes/linux-x64/native";
        }
        else if (lib.target.isWindows()) {
            // b.lib_dir = "../../../../Dinghy.Core/libs/win-x64/native";
            b.lib_dir = "../Dinghy.Core/runtimes/win-x64/native";
        }
    }
    b.installArtifact(lib);
}