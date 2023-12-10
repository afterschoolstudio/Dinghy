namespace Dinghy.Internal.Sokol;

public partial struct ImPool_ImGuiTable
{
    public ImVector_ImGuiTable Buf;

    public ImGuiStorage Map;

    [NativeTypeName("ImPoolIdx")]
    public int FreeIdx;

    [NativeTypeName("ImPoolIdx")]
    public int AliveCount;
}
