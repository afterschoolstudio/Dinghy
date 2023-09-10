this is a collection of build scripts to cross compile the header files to target platforms by using zig's build system

run this in any of the folders to build the lib:
zig build

what would maybe make sense is a zig build script at the top level dir you can run to build everything
and it basically trips on build scripts in each folder?

the sokol one is pulled largely from
https://github.com/floooh/sokol-zig/blob/master/build.zig