using System.Runtime.CompilerServices;

namespace Dinghy.Internal.Sokol;

public unsafe partial struct ImGuiStackLevelInfo
{
    [NativeTypeName("ImGuiID")]
    public uint ID;

    [NativeTypeName("ImS8")]
    public sbyte QueryFrameCount;

    [NativeTypeName("bool")]
    public byte QuerySuccess;

    public int _bitfield;

    [NativeTypeName("ImGuiDataType : 8")]
    public int DataType
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            return (_bitfield << 24) >> 24;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            _bitfield = (_bitfield & ~0xFF) | (value & 0xFF);
        }
    }

    [NativeTypeName("char[57]")]
    public fixed sbyte Desc[57];
}
