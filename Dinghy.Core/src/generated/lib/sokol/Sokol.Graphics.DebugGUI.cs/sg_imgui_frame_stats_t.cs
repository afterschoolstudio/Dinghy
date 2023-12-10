namespace Dinghy.Internal.Sokol;

public partial struct sg_imgui_frame_stats_t
{
    [NativeTypeName("bool")]
    public byte open;

    [NativeTypeName("bool")]
    public byte disable_sokol_imgui_stats;

    [NativeTypeName("bool")]
    public byte in_sokol_imgui;

    public sg_frame_stats stats;
}
