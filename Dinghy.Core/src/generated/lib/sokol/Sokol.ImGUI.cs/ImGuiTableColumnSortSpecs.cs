using System.Runtime.CompilerServices;

namespace Dinghy.Internal.Sokol;

public partial struct ImGuiTableColumnSortSpecs
{
    [NativeTypeName("ImGuiID")]
    public uint ColumnUserID;

    [NativeTypeName("ImS16")]
    public short ColumnIndex;

    [NativeTypeName("ImS16")]
    public short SortOrder;

    public int _bitfield;

    [NativeTypeName("ImGuiSortDirection : 8")]
    public int SortDirection
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
}
