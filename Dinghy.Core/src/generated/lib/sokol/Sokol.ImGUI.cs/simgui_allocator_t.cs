namespace Dinghy.Internal.Sokol;

public unsafe partial struct simgui_allocator_t
{
    [NativeTypeName("void *(*)(size_t, void *)")]
    public delegate* unmanaged[Cdecl]<nuint, void*, void*> alloc_fn;

    [NativeTypeName("void (*)(void *, void *)")]
    public delegate* unmanaged[Cdecl]<void*, void*, void> free_fn;

    public void* user_data;
}
