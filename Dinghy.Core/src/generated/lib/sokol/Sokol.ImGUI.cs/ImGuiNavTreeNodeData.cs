namespace Dinghy.Internal.Sokol;

public partial struct ImGuiNavTreeNodeData
{
    [NativeTypeName("ImGuiID")]
    public uint ID;

    [NativeTypeName("ImGuiItemFlags")]
    public int InFlags;

    public ImRect NavRect;
}
