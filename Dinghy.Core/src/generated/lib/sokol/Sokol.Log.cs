using System.Runtime.InteropServices;

namespace Dinghy.Internal.Sokol;

public static unsafe partial class Log
{
    [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void slog_func([NativeTypeName("const char *")] sbyte* tag, [NativeTypeName("uint32_t")] uint log_level, [NativeTypeName("uint32_t")] uint log_item, [NativeTypeName("const char *")] sbyte* message, [NativeTypeName("uint32_t")] uint line_nr, [NativeTypeName("const char *")] sbyte* filename, void* user_data);
}
