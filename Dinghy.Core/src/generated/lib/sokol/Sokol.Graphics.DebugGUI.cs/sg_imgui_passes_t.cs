namespace Dinghy.Internal.Sokol;

public unsafe partial struct sg_imgui_passes_t
{
    [NativeTypeName("bool")]
    public byte open;

    public int num_slots;

    public sg_pass sel_pass;

    public sg_imgui_pass_t* slots;
}
