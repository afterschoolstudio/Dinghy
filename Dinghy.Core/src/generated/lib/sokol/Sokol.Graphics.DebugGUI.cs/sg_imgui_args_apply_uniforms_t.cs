namespace Dinghy.Internal.Sokol;

public partial struct sg_imgui_args_apply_uniforms_t
{
    public sg_shader_stage stage;

    public int ub_index;

    [NativeTypeName("size_t")]
    public nuint data_size;

    public sg_pipeline pipeline;

    [NativeTypeName("size_t")]
    public nuint ubuf_pos;
}
