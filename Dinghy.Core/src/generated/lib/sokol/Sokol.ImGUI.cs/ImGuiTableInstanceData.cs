namespace Dinghy.Internal.Sokol;

public partial struct ImGuiTableInstanceData
{
    [NativeTypeName("ImGuiID")]
    public uint TableInstanceID;

    public float LastOuterHeight;

    public float LastTopHeadersRowHeight;

    public float LastFrozenHeight;

    public int HoveredRowLast;

    public int HoveredRowNext;
}
