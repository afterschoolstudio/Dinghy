namespace Dinghy.Internal.Sokol;

public partial struct ImGuiDebugAllocEntry
{
    public int FrameCount;

    [NativeTypeName("ImS16")]
    public short AllocCount;

    [NativeTypeName("ImS16")]
    public short FreeCount;
}
