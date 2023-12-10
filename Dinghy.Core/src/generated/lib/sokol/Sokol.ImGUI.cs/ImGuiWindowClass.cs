namespace Dinghy.Internal.Sokol;

public partial struct ImGuiWindowClass
{
    [NativeTypeName("ImGuiID")]
    public uint ClassId;

    [NativeTypeName("ImGuiID")]
    public uint ParentViewportId;

    [NativeTypeName("ImGuiViewportFlags")]
    public int ViewportFlagsOverrideSet;

    [NativeTypeName("ImGuiViewportFlags")]
    public int ViewportFlagsOverrideClear;

    [NativeTypeName("ImGuiTabItemFlags")]
    public int TabItemFlagsOverrideSet;

    [NativeTypeName("ImGuiDockNodeFlags")]
    public int DockNodeFlagsOverrideSet;

    [NativeTypeName("bool")]
    public byte DockingAlwaysTabBar;

    [NativeTypeName("bool")]
    public byte DockingAllowUnclassed;
}
