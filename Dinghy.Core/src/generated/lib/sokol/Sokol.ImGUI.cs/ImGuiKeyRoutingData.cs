namespace Dinghy.Internal.Sokol;

public partial struct ImGuiKeyRoutingData
{
    [NativeTypeName("ImGuiKeyRoutingIndex")]
    public short NextEntryIndex;

    [NativeTypeName("ImU16")]
    public ushort Mods;

    [NativeTypeName("ImU8")]
    public byte RoutingNextScore;

    [NativeTypeName("ImGuiID")]
    public uint RoutingCurr;

    [NativeTypeName("ImGuiID")]
    public uint RoutingNext;
}
