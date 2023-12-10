namespace Dinghy.Internal.Sokol;

public partial struct sg_imgui_capture_item_t
{
    public sg_imgui_cmd_t cmd;

    [NativeTypeName("uint32_t")]
    public uint color;

    public sg_imgui_args_t args;
}
