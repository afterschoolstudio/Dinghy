namespace Dinghy.Internal.Sokol;

public unsafe partial struct sg_imgui_pass_t
{
    public sg_pass res_id;

    public sg_imgui_str_t label;

    [NativeTypeName("float[4]")]
    public fixed float color_image_scale[4];

    [NativeTypeName("float[4]")]
    public fixed float resolve_image_scale[4];

    public float ds_image_scale;

    public sg_pass_desc desc;
}
