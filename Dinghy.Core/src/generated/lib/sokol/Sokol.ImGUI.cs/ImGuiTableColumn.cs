using System.Runtime.CompilerServices;

namespace Dinghy.Internal.Sokol;

public partial struct ImGuiTableColumn
{
    [NativeTypeName("ImGuiTableColumnFlags")]
    public int Flags;

    public float WidthGiven;

    public float MinX;

    public float MaxX;

    public float WidthRequest;

    public float WidthAuto;

    public float StretchWeight;

    public float InitStretchWeightOrWidth;

    public ImRect ClipRect;

    [NativeTypeName("ImGuiID")]
    public uint UserID;

    public float WorkMinX;

    public float WorkMaxX;

    public float ItemWidth;

    public float ContentMaxXFrozen;

    public float ContentMaxXUnfrozen;

    public float ContentMaxXHeadersUsed;

    public float ContentMaxXHeadersIdeal;

    [NativeTypeName("ImS16")]
    public short NameOffset;

    [NativeTypeName("ImGuiTableColumnIdx")]
    public short DisplayOrder;

    [NativeTypeName("ImGuiTableColumnIdx")]
    public short IndexWithinEnabledSet;

    [NativeTypeName("ImGuiTableColumnIdx")]
    public short PrevEnabledColumn;

    [NativeTypeName("ImGuiTableColumnIdx")]
    public short NextEnabledColumn;

    [NativeTypeName("ImGuiTableColumnIdx")]
    public short SortOrder;

    [NativeTypeName("ImGuiTableDrawChannelIdx")]
    public ushort DrawChannelCurrent;

    [NativeTypeName("ImGuiTableDrawChannelIdx")]
    public ushort DrawChannelFrozen;

    [NativeTypeName("ImGuiTableDrawChannelIdx")]
    public ushort DrawChannelUnfrozen;

    [NativeTypeName("bool")]
    public byte IsEnabled;

    [NativeTypeName("bool")]
    public byte IsUserEnabled;

    [NativeTypeName("bool")]
    public byte IsUserEnabledNextFrame;

    [NativeTypeName("bool")]
    public byte IsVisibleX;

    [NativeTypeName("bool")]
    public byte IsVisibleY;

    [NativeTypeName("bool")]
    public byte IsRequestOutput;

    [NativeTypeName("bool")]
    public byte IsSkipItems;

    [NativeTypeName("bool")]
    public byte IsPreserveWidthAuto;

    [NativeTypeName("ImS8")]
    public sbyte NavLayerCurrent;

    [NativeTypeName("ImU8")]
    public byte AutoFitQueue;

    [NativeTypeName("ImU8")]
    public byte CannotSkipItemsQueue;

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

    [NativeTypeName("ImU8 : 2")]
    public byte SortDirectionsAvailCount
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            return (byte)((_bitfield >> 2) & 0x3u);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            _bitfield = (byte)((_bitfield & ~(0x3u << 2)) | ((value & 0x3u) << 2));
        }
    }

    [NativeTypeName("ImU8 : 4")]
    public byte SortDirectionsAvailMask
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            return (byte)((_bitfield >> 4) & 0xFu);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            _bitfield = (byte)((_bitfield & ~(0xFu << 4)) | ((value & 0xFu) << 4));
        }
    }

    [NativeTypeName("ImU8")]
    public byte SortDirectionsAvailList;
}
