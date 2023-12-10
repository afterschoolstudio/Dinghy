namespace Dinghy.Internal.Sokol;

public unsafe partial struct simgui_logger_t
{
    [NativeTypeName("void (*)(const char *, uint32_t, uint32_t, const char *, uint32_t, const char *, void *)")]
    public delegate* unmanaged[Cdecl]<sbyte*, uint, uint, sbyte*, uint, sbyte*, void*, void> func;

    public void* user_data;
}
