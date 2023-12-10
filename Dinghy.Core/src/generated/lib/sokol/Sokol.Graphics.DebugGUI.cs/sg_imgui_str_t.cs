namespace Dinghy.Internal.Sokol;

public unsafe partial struct sg_imgui_str_t
{
    [NativeTypeName("char[96]")]
    public fixed sbyte buf[96];
}
