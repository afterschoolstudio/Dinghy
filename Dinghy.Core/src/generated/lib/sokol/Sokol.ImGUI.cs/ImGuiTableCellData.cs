namespace Dinghy.Internal.Sokol;

public partial struct ImGuiTableCellData
{
    [NativeTypeName("ImU32")]
    public uint BgColor;

    [NativeTypeName("ImGuiTableColumnIdx")]
    public short Column;
}
