namespace Dinghy.Internal.Sokol;

public partial struct ImGuiTabBar
{
    public ImVector_ImGuiTabItem Tabs;

    [NativeTypeName("ImGuiTabBarFlags")]
    public int Flags;

    [NativeTypeName("ImGuiID")]
    public uint ID;

    [NativeTypeName("ImGuiID")]
    public uint SelectedTabId;

    [NativeTypeName("ImGuiID")]
    public uint NextSelectedTabId;

    [NativeTypeName("ImGuiID")]
    public uint VisibleTabId;

    public int CurrFrameVisible;

    public int PrevFrameVisible;

    public ImRect BarRect;

    public float CurrTabsContentsHeight;

    public float PrevTabsContentsHeight;

    public float WidthAllTabs;

    public float WidthAllTabsIdeal;

    public float ScrollingAnim;

    public float ScrollingTarget;

    public float ScrollingTargetDistToVisibility;

    public float ScrollingSpeed;

    public float ScrollingRectMinX;

    public float ScrollingRectMaxX;

    public float SeparatorMinX;

    public float SeparatorMaxX;

    [NativeTypeName("ImGuiID")]
    public uint ReorderRequestTabId;

    [NativeTypeName("ImS16")]
    public short ReorderRequestOffset;

    [NativeTypeName("ImS8")]
    public sbyte BeginCount;

    [NativeTypeName("bool")]
    public byte WantLayout;

    [NativeTypeName("bool")]
    public byte VisibleTabWasSubmitted;

    [NativeTypeName("bool")]
    public byte TabsAddedNew;

    [NativeTypeName("ImS16")]
    public short TabsActiveCount;

    [NativeTypeName("ImS16")]
    public short LastTabItemIdx;

    public float ItemSpacingY;

    public ImVec2 FramePadding;

    public ImVec2 BackupCursorPos;

    public ImGuiTextBuffer TabsNames;
}
