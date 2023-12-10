namespace Dinghy.Internal.Sokol;

public partial struct ImGuiNextItemData
{
    [NativeTypeName("ImGuiNextItemDataFlags")]
    public int Flags;

    [NativeTypeName("ImGuiItemFlags")]
    public int ItemFlags;

    public float Width;

    [NativeTypeName("ImGuiSelectionUserData")]
    public long SelectionUserData;

    [NativeTypeName("ImGuiCond")]
    public int OpenCond;

    [NativeTypeName("bool")]
    public byte OpenVal;
}
