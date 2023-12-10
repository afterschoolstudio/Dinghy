namespace Dinghy.Internal.Sokol;

public unsafe partial struct ImGuiWindowTempData
{
    public ImVec2 CursorPos;

    public ImVec2 CursorPosPrevLine;

    public ImVec2 CursorStartPos;

    public ImVec2 CursorMaxPos;

    public ImVec2 IdealMaxPos;

    public ImVec2 CurrLineSize;

    public ImVec2 PrevLineSize;

    public float CurrLineTextBaseOffset;

    public float PrevLineTextBaseOffset;

    [NativeTypeName("bool")]
    public byte IsSameLine;

    [NativeTypeName("bool")]
    public byte IsSetPos;

    public ImVec1 Indent;

    public ImVec1 ColumnsOffset;

    public ImVec1 GroupOffset;

    public ImVec2 CursorStartPosLossyness;

    public ImGuiNavLayer NavLayerCurrent;

    public short NavLayersActiveMask;

    public short NavLayersActiveMaskNext;

    [NativeTypeName("bool")]
    public byte NavIsScrollPushableX;

    [NativeTypeName("bool")]
    public byte NavHideHighlightOneFrame;

    [NativeTypeName("bool")]
    public byte NavWindowHasScrollY;

    [NativeTypeName("bool")]
    public byte MenuBarAppending;

    public ImVec2 MenuBarOffset;

    public ImGuiMenuColumns MenuColumns;

    public int TreeDepth;

    [NativeTypeName("ImU32")]
    public uint TreeJumpToParentOnPopMask;

    public ImVector_ImGuiWindowPtr ChildWindows;

    public ImGuiStorage* StateStorage;

    public ImGuiOldColumns* CurrentColumns;

    public int CurrentTableIdx;

    [NativeTypeName("ImGuiLayoutType")]
    public int LayoutType;

    [NativeTypeName("ImGuiLayoutType")]
    public int ParentLayoutType;

    public float ItemWidth;

    public float TextWrapPos;

    public ImVector_float ItemWidthStack;

    public ImVector_float TextWrapPosStack;
}
