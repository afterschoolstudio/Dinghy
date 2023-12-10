namespace Dinghy.Internal.Sokol;

public partial struct ImGuiMetricsConfig
{
    [NativeTypeName("bool")]
    public byte ShowDebugLog;

    [NativeTypeName("bool")]
    public byte ShowIDStackTool;

    [NativeTypeName("bool")]
    public byte ShowWindowsRects;

    [NativeTypeName("bool")]
    public byte ShowWindowsBeginOrder;

    [NativeTypeName("bool")]
    public byte ShowTablesRects;

    [NativeTypeName("bool")]
    public byte ShowDrawCmdMesh;

    [NativeTypeName("bool")]
    public byte ShowDrawCmdBoundingBoxes;

    [NativeTypeName("bool")]
    public byte ShowAtlasTintedWithTextColor;

    [NativeTypeName("bool")]
    public byte ShowDockingNodes;

    public int ShowWindowsRectsType;

    public int ShowTablesRectsType;
}
