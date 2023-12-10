namespace Dinghy.Internal.Sokol;

public unsafe partial struct sg_imgui_pipelines_t
{
    [NativeTypeName("bool")]
    public byte open;

    public int num_slots;

    public sg_pipeline sel_pip;

    public sg_imgui_pipeline_t* slots;
}
