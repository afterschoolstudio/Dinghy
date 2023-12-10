using System.Runtime.CompilerServices;

namespace Dinghy.Internal.Sokol;

public partial struct ImGuiDebugAllocInfo
{
    public int TotalAllocCount;

    public int TotalFreeCount;

    [NativeTypeName("ImS16")]
    public short LastEntriesIdx;

    [NativeTypeName("ImGuiDebugAllocEntry[6]")]
    public _LastEntriesBuf_e__FixedBuffer LastEntriesBuf;

    [InlineArray(6)]
    public partial struct _LastEntriesBuf_e__FixedBuffer
    {
        public ImGuiDebugAllocEntry e0;
    }
}
