rider configs has accurate mappings for all the sokol libs 
generate bindings by running the corresponding rider config
build dlls by running rider builders
  
tool has a tendency to add another brace at the end + inject garbage in the middle of the file so needs cleaning  

right now zig builds on windows machine but maybe need this to build dinghy for other platforms?
https://github.com/vezel-dev/zig-toolsets
this flecs lib works like this automatically? idgi but here's the link https://github.com/BeanCheeseBurrito/Flecs.NET#compile-flecs

see this link about clangsharp stuff  
https://github.com/dotnet/ClangSharp/issues/432

as a note on clagsharp