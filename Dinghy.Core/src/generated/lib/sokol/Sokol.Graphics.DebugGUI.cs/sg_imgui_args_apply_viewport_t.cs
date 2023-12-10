namespace Dinghy.Internal.Sokol;

public partial struct sg_imgui_args_apply_viewport_t
{
    public int x;

    public int y;

    public int width;

    public int height;

    [NativeTypeName("bool")]
    public byte origin_top_left;
}
