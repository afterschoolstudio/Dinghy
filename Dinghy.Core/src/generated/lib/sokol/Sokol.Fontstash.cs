using System.Runtime.InteropServices;

namespace Dinghy.Internal.Sokol;

public unsafe partial struct sfons_allocator_t
{
    [NativeTypeName("void *(*)(size_t, void *)")]
    public delegate* unmanaged[Cdecl]<nuint, void*, void*> alloc_fn;

    [NativeTypeName("void (*)(void *, void *)")]
    public delegate* unmanaged[Cdecl]<void*, void*, void> free_fn;

    public void* user_data;
}

public partial struct sfons_desc_t
{
    public int width;

    public int height;

    public sfons_allocator_t allocator;
}

public static unsafe partial class Fontstash
{
    [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sfons_create", ExactSpelling = true)]
    [return: NativeTypeName("FONScontext*")]
    public static extern void* create([NativeTypeName("const sfons_desc_t *")] sfons_desc_t* desc);

    [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sfons_destroy", ExactSpelling = true)]
    public static extern void destroy([NativeTypeName("FONScontext*")] void* ctx);

    [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sfons_flush", ExactSpelling = true)]
    public static extern void flush([NativeTypeName("FONScontext*")] void* ctx);

    [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sfons_rgba", ExactSpelling = true)]
    [return: NativeTypeName("uint32_t")]
    public static extern uint rgba([NativeTypeName("uint8_t")] byte r, [NativeTypeName("uint8_t")] byte g, [NativeTypeName("uint8_t")] byte b, [NativeTypeName("uint8_t")] byte a);
}
