namespace Dinghy.Internal.Sokol;

public unsafe partial struct sg_imgui_buffers_t
{
    [NativeTypeName("bool")]
    public byte open;

    public int num_slots;

    public sg_buffer sel_buf;

    public sg_imgui_buffer_t* slots;
}
