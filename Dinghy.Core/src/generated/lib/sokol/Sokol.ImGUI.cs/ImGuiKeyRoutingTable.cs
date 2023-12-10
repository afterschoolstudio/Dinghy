namespace Dinghy.Internal.Sokol;

public unsafe partial struct ImGuiKeyRoutingTable
{
    [NativeTypeName("ImGuiKeyRoutingIndex[154]")]
    public fixed short Index[154];

    public ImVector_ImGuiKeyRoutingData Entries;

    public ImVector_ImGuiKeyRoutingData EntriesNext;
}
