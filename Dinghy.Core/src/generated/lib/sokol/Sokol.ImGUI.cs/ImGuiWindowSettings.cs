namespace Dinghy.Internal.Sokol;

public partial struct ImGuiWindowSettings
{
    [NativeTypeName("ImGuiID")]
    public uint ID;

    public ImVec2ih Pos;

    public ImVec2ih Size;

    public ImVec2ih ViewportPos;

    [NativeTypeName("ImGuiID")]
    public uint ViewportId;

    [NativeTypeName("ImGuiID")]
    public uint DockId;

    [NativeTypeName("ImGuiID")]
    public uint ClassId;

    public short DockOrder;

    [NativeTypeName("bool")]
    public byte Collapsed;

    [NativeTypeName("bool")]
    public byte IsChild;

    [NativeTypeName("bool")]
    public byte WantApply;

    [NativeTypeName("bool")]
    public byte WantDelete;
}
