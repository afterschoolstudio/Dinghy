using System.Runtime.CompilerServices;

namespace Dinghy.Internal.Sokol;

public partial struct ImGuiTableColumnSettings
{
    public float WidthOrWeight;

    [NativeTypeName("ImGuiID")]
    public uint UserID;

    [NativeTypeName("ImGuiTableColumnIdx")]
    public short Index;

    [NativeTypeName("ImGuiTableColumnIdx")]
    public short DisplayOrder;

    [NativeTypeName("ImGuiTableColumnIdx")]
    public short SortOrder;

    public byte _bitfield;

    [NativeTypeName("ImU8 : 2")]
    public byte SortDirection
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            return (byte)(_bitfield & 0x3u);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            _bitfield = (byte)((_bitfield & ~0x3u) | (value & 0x3u));
        }
    }

    [NativeTypeName("ImU8 : 1")]
    public byte IsEnabled
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            return (byte)((_bitfield >> 2) & 0x1u);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            _bitfield = (byte)((_bitfield & ~(0x1u << 2)) | ((value & 0x1u) << 2));
        }
    }

    [NativeTypeName("ImU8 : 1")]
    public byte IsStretch
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            return (byte)((_bitfield >> 3) & 0x1u);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            _bitfield = (byte)((_bitfield & ~(0x1u << 3)) | ((value & 0x1u) << 3));
        }
    }
}
