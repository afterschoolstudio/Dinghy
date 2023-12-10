namespace Dinghy.Internal.Sokol;

public partial struct ImGuiLastItemData
{
    [NativeTypeName("ImGuiID")]
    public uint ID;

    [NativeTypeName("ImGuiItemFlags")]
    public int InFlags;

    [NativeTypeName("ImGuiItemStatusFlags")]
    public int StatusFlags;

    public ImRect Rect;

    public ImRect NavRect;

    public ImRect DisplayRect;
}
