namespace Dinghy.Internal.Sokol;

public partial struct sg_imgui_args_append_buffer_t
{
    public sg_buffer buffer;

    [NativeTypeName("size_t")]
    public nuint data_size;

    public int result;
}
