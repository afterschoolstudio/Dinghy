log function needs to be tagged with proper UnmanagedCallersOnly attribute, so edit to be this:

```c#

[DllImport("sokol_gp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]

public static extern void slog_func([NativeTypeName("const char *")] sbyte* tag, [NativeTypeName("uint32_t")] uint log_level, [NativeTypeName("uint32_t")] uint log_item, [NativeTypeName("const char *")] sbyte* message, [NativeTypeName("uint32_t")] uint line_nr, [NativeTypeName("const char *")] sbyte* filename, void* user_data);

```

  

compile the glsl shader manuall right now with

```

../sokol-tools-bin/bin/win32/sokol-shdc.exe -i ./shaders/loadpng.glsl -l hlsl4 -f bare -o ./shaders/compiled/

```