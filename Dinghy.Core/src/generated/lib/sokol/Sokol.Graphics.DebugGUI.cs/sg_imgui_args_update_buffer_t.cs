namespace Dinghy.Internal.Sokol;

public partial struct sg_imgui_args_update_buffer_t
{
    public sg_buffer buffer;

    [NativeTypeName("size_t")]
    public nuint data_size;
}
