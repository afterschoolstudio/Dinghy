namespace Dinghy.Internal.Sokol;

public partial struct sg_imgui_t
{
    [NativeTypeName("uint32_t")]
    public uint init_tag;

    public sg_imgui_desc_t desc;

    public sg_imgui_buffers_t buffers;

    public sg_imgui_images_t images;

    public sg_imgui_samplers_t samplers;

    public sg_imgui_shaders_t shaders;

    public sg_imgui_pipelines_t pipelines;

    public sg_imgui_passes_t passes;

    public sg_imgui_capture_t capture;

    public sg_imgui_caps_t caps;

    public sg_imgui_frame_stats_t frame_stats;

    public sg_pipeline cur_pipeline;

    public sg_trace_hooks hooks;
}
