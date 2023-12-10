namespace Dinghy.Internal.Sokol;

public unsafe partial struct sg_imgui_shaders_t
{
    [NativeTypeName("bool")]
    public byte open;

    public int num_slots;

    public sg_shader sel_shd;

    public sg_imgui_shader_t* slots;
}
