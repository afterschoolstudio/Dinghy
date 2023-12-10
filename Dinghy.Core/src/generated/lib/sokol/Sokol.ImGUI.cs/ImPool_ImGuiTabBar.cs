namespace Dinghy.Internal.Sokol;

public partial struct ImPool_ImGuiTabBar
{
    public ImVector_ImGuiTabBar Buf;

    public ImGuiStorage Map;

    [NativeTypeName("ImPoolIdx")]
    public int FreeIdx;

    [NativeTypeName("ImPoolIdx")]
    public int AliveCount;
}
