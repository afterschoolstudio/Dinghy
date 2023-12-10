namespace Dinghy.Internal.Sokol;

public unsafe partial struct sg_imgui_samplers_t
{
    [NativeTypeName("bool")]
    public byte open;

    public int num_slots;

    public sg_sampler sel_smp;

    public sg_imgui_sampler_t* slots;
}
