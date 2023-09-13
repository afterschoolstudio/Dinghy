rider configs has accurate mappings for all the sokol libs

todo: 
* fix mappings for stb  
* add in zig build commands to rider configs
* bootstrapper could also use zig to build deps?
	* zig
	* fips
	* fibs (maybe use this for everything?)

need to build DLLs first
then generate bindings against those DLLs
then export those generated DLLs + bindings into Dinghy.Core
  
generate bindings by running the corresponding rider config
  
tool has a tendency to add another brace at the end + inject garbage in the middle of the file so needs cleaning  

at the bottom of the sokol file, need to add in a manual binding for slog:  
see other note in other folder about UnmanagedCallersOnly  
```c#  
[DllImport("sokol_gp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]  
public static extern void slog_func([NativeTypeName("const char *")] sbyte* tag, [NativeTypeName("uint32_t")] uint log_level, [NativeTypeName("uint32_t")] uint log_item, [NativeTypeName("const char *")] sbyte* message, [NativeTypeName("uint32_t")] uint line_nr, [NativeTypeName("const char *")] sbyte* filename, void* user_data);  
```  
  
see this link about clangsharp stuff  
https://github.com/dotnet/ClangSharp/issues/432

as a note on clagsharp