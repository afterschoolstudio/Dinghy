namespace Dinghy.Internal.Sokol;

public unsafe partial struct ImDrawData
{
    [NativeTypeName("bool")]
    public byte Valid;

    public int CmdListsCount;

    public int TotalIdxCount;

    public int TotalVtxCount;

    public ImVector_ImDrawListPtr CmdLists;

    public ImVec2 DisplayPos;

    public ImVec2 DisplaySize;

    public ImVec2 FramebufferScale;

    public ImGuiViewport* OwnerViewport;
}
