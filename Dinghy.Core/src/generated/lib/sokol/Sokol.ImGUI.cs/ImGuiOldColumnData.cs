namespace Dinghy.Internal.Sokol;

public partial struct ImGuiOldColumnData
{
    public float OffsetNorm;

    public float OffsetNormBeforeResize;

    [NativeTypeName("ImGuiOldColumnFlags")]
    public int Flags;

    public ImRect ClipRect;
}
