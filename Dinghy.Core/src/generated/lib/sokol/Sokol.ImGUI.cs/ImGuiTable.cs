using System.Runtime.CompilerServices;

namespace Dinghy.Internal.Sokol;

public unsafe partial struct ImGuiTable
{
    [NativeTypeName("ImGuiID")]
    public uint ID;

    [NativeTypeName("ImGuiTableFlags")]
    public int Flags;

    public void* RawData;

    public ImGuiTableTempData* TempData;

    public ImSpan_ImGuiTableColumn Columns;

    public ImSpan_ImGuiTableColumnIdx DisplayOrderToIndex;

    public ImSpan_ImGuiTableCellData RowCellData;

    [NativeTypeName("ImBitArrayPtr")]
    public uint* EnabledMaskByDisplayOrder;

    [NativeTypeName("ImBitArrayPtr")]
    public uint* EnabledMaskByIndex;

    [NativeTypeName("ImBitArrayPtr")]
    public uint* VisibleMaskByIndex;

    [NativeTypeName("ImGuiTableFlags")]
    public int SettingsLoadedFlags;

    public int SettingsOffset;

    public int LastFrameActive;

    public int ColumnsCount;

    public int CurrentRow;

    public int CurrentColumn;

    [NativeTypeName("ImS16")]
    public short InstanceCurrent;

    [NativeTypeName("ImS16")]
    public short InstanceInteracted;

    public float RowPosY1;

    public float RowPosY2;

    public float RowMinHeight;

    public float RowCellPaddingY;

    public float RowTextBaseline;

    public float RowIndentOffsetX;

    public int _bitfield;

    [NativeTypeName("ImGuiTableRowFlags : 16")]
    public int RowFlags
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            return (_bitfield << 16) >> 16;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            _bitfield = (_bitfield & ~0xFFFF) | (value & 0xFFFF);
        }
    }

    [NativeTypeName("ImGuiTableRowFlags : 16")]
    public int LastRowFlags
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            return (_bitfield << 0) >> 16;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            _bitfield = (_bitfield & ~(0xFFFF << 16)) | ((value & 0xFFFF) << 16);
        }
    }

    public int RowBgColorCounter;

    [NativeTypeName("ImU32[2]")]
    public fixed uint RowBgColor[2];

    [NativeTypeName("ImU32")]
    public uint BorderColorStrong;

    [NativeTypeName("ImU32")]
    public uint BorderColorLight;

    public float BorderX1;

    public float BorderX2;

    public float HostIndentX;

    public float MinColumnWidth;

    public float OuterPaddingX;

    public float CellPaddingX;

    public float CellSpacingX1;

    public float CellSpacingX2;

    public float InnerWidth;

    public float ColumnsGivenWidth;

    public float ColumnsAutoFitWidth;

    public float ColumnsStretchSumWeights;

    public float ResizedColumnNextWidth;

    public float ResizeLockMinContentsX2;

    public float RefScale;

    public float AngledHeadersHeight;

    public float AngledHeadersSlope;

    public ImRect OuterRect;

    public ImRect InnerRect;

    public ImRect WorkRect;

    public ImRect InnerClipRect;

    public ImRect BgClipRect;

    public ImRect Bg0ClipRectForDrawCmd;

    public ImRect Bg2ClipRectForDrawCmd;

    public ImRect HostClipRect;

    public ImRect HostBackupInnerClipRect;

    public ImGuiWindow* OuterWindow;

    public ImGuiWindow* InnerWindow;

    public ImGuiTextBuffer ColumnsNames;

    public ImDrawListSplitter* DrawSplitter;

    public ImGuiTableInstanceData InstanceDataFirst;

    public ImVector_ImGuiTableInstanceData InstanceDataExtra;

    public ImGuiTableColumnSortSpecs SortSpecsSingle;

    public ImVector_ImGuiTableColumnSortSpecs SortSpecsMulti;

    public ImGuiTableSortSpecs SortSpecs;

    [NativeTypeName("ImGuiTableColumnIdx")]
    public short SortSpecsCount;

    [NativeTypeName("ImGuiTableColumnIdx")]
    public short ColumnsEnabledCount;

    [NativeTypeName("ImGuiTableColumnIdx")]
    public short ColumnsEnabledFixedCount;

    [NativeTypeName("ImGuiTableColumnIdx")]
    public short DeclColumnsCount;

    [NativeTypeName("ImGuiTableColumnIdx")]
    public short AngledHeadersCount;

    [NativeTypeName("ImGuiTableColumnIdx")]
    public short HoveredColumnBody;

    [NativeTypeName("ImGuiTableColumnIdx")]
    public short HoveredColumnBorder;

    [NativeTypeName("ImGuiTableColumnIdx")]
    public short HighlightColumnHeader;

    [NativeTypeName("ImGuiTableColumnIdx")]
    public short AutoFitSingleColumn;

    [NativeTypeName("ImGuiTableColumnIdx")]
    public short ResizedColumn;

    [NativeTypeName("ImGuiTableColumnIdx")]
    public short LastResizedColumn;

    [NativeTypeName("ImGuiTableColumnIdx")]
    public short HeldHeaderColumn;

    [NativeTypeName("ImGuiTableColumnIdx")]
    public short ReorderColumn;

    [NativeTypeName("ImGuiTableColumnIdx")]
    public short ReorderColumnDir;

    [NativeTypeName("ImGuiTableColumnIdx")]
    public short LeftMostEnabledColumn;

    [NativeTypeName("ImGuiTableColumnIdx")]
    public short RightMostEnabledColumn;

    [NativeTypeName("ImGuiTableColumnIdx")]
    public short LeftMostStretchedColumn;

    [NativeTypeName("ImGuiTableColumnIdx")]
    public short RightMostStretchedColumn;

    [NativeTypeName("ImGuiTableColumnIdx")]
    public short ContextPopupColumn;

    [NativeTypeName("ImGuiTableColumnIdx")]
    public short FreezeRowsRequest;

    [NativeTypeName("ImGuiTableColumnIdx")]
    public short FreezeRowsCount;

    [NativeTypeName("ImGuiTableColumnIdx")]
    public short FreezeColumnsRequest;

    [NativeTypeName("ImGuiTableColumnIdx")]
    public short FreezeColumnsCount;

    [NativeTypeName("ImGuiTableColumnIdx")]
    public short RowCellDataCurrent;

    [NativeTypeName("ImGuiTableDrawChannelIdx")]
    public ushort DummyDrawChannel;

    [NativeTypeName("ImGuiTableDrawChannelIdx")]
    public ushort Bg2DrawChannelCurrent;

    [NativeTypeName("ImGuiTableDrawChannelIdx")]
    public ushort Bg2DrawChannelUnfrozen;

    [NativeTypeName("bool")]
    public byte IsLayoutLocked;

    [NativeTypeName("bool")]
    public byte IsInsideRow;

    [NativeTypeName("bool")]
    public byte IsInitializing;

    [NativeTypeName("bool")]
    public byte IsSortSpecsDirty;

    [NativeTypeName("bool")]
    public byte IsUsingHeaders;

    [NativeTypeName("bool")]
    public byte IsContextPopupOpen;

    [NativeTypeName("bool")]
    public byte DisableDefaultContextMenu;

    [NativeTypeName("bool")]
    public byte IsSettingsRequestLoad;

    [NativeTypeName("bool")]
    public byte IsSettingsDirty;

    [NativeTypeName("bool")]
    public byte IsDefaultDisplayOrder;

    [NativeTypeName("bool")]
    public byte IsResetAllRequest;

    [NativeTypeName("bool")]
    public byte IsResetDisplayOrderRequest;

    [NativeTypeName("bool")]
    public byte IsUnfrozenRows;

    [NativeTypeName("bool")]
    public byte IsDefaultSizingPolicy;

    [NativeTypeName("bool")]
    public byte IsActiveIdAliveBeforeTable;

    [NativeTypeName("bool")]
    public byte IsActiveIdInTable;

    [NativeTypeName("bool")]
    public byte HasScrollbarYCurr;

    [NativeTypeName("bool")]
    public byte HasScrollbarYPrev;

    [NativeTypeName("bool")]
    public byte MemoryCompacted;

    [NativeTypeName("bool")]
    public byte HostSkipItems;
}
