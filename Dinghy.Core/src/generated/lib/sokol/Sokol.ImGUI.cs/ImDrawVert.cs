namespace Dinghy.Internal.Sokol;

public partial struct ImDrawVert
{
    public ImVec2 pos;

    public ImVec2 uv;

    [NativeTypeName("ImU32")]
    public uint col;
}
