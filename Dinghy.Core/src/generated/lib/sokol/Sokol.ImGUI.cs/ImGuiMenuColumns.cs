namespace Dinghy.Internal.Sokol;

public unsafe partial struct ImGuiMenuColumns
{
    [NativeTypeName("ImU32")]
    public uint TotalWidth;

    [NativeTypeName("ImU32")]
    public uint NextTotalWidth;

    [NativeTypeName("ImU16")]
    public ushort Spacing;

    [NativeTypeName("ImU16")]
    public ushort OffsetIcon;

    [NativeTypeName("ImU16")]
    public ushort OffsetLabel;

    [NativeTypeName("ImU16")]
    public ushort OffsetShortcut;

    [NativeTypeName("ImU16")]
    public ushort OffsetMark;

    [NativeTypeName("ImU16[4]")]
    public fixed ushort Widths[4];
}
