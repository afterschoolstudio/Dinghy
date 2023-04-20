todo: 
  
- add in console application that runs the ClangSharpPInvokeGenerator global against sokol wtih rsp  
- maybe this is added in as nuget instead of a global tool?  
- these bindings get spit out to an out directory and copied  
  
  
generate bindings by running the global ClangSharpPinvokeGenerator tool against these rsp files: 
  
sokol_settings.rsp  
sokol_gp_settings.rsp  
  
tool has a tendency to add another brace at the end + inject garbage in the middle of the file so needs cleaning  
  
to generate sokol_gp bindings, need to manually add this to the top of the sokol_gp.h file (otherwise it wont detect gfx):  
```  
#include "../sokol/sokol_gfx.h"  
```  
  
at the bottom of the sokol file, need to add in a manual binding for slog:  
see other note in other folder about UnmanagedCallersOnly  
```c#  
[DllImport("sokol_gp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]  
public static extern void slog_func([NativeTypeName("const char *")] sbyte* tag, [NativeTypeName("uint32_t")] uint log_level, [NativeTypeName("uint32_t")] uint log_item, [NativeTypeName("const char *")] sbyte* message, [NativeTypeName("uint32_t")] uint line_nr, [NativeTypeName("const char *")] sbyte* filename, void* user_data);  
```  
  
see this link about clangsharp stuff  
https://github.com/dotnet/ClangSharp/issues/432