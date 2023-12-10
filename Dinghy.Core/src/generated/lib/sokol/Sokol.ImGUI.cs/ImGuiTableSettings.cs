namespace Dinghy.Internal.Sokol;

public partial struct ImGuiTableSettings
{
    [NativeTypeName("ImGuiID")]
    public uint ID;

    [NativeTypeName("ImGuiTableFlags")]
    public int SaveFlags;

    public float RefScale;

    [NativeTypeName("ImGuiTableColumnIdx")]
    public short ColumnsCount;

    [NativeTypeName("ImGuiTableColumnIdx")]
    public short ColumnsCountMax;

    [NativeTypeName("bool")]
    public byte WantApply;
}
