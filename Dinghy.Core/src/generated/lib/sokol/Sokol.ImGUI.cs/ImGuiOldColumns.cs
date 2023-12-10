namespace Dinghy.Internal.Sokol;

public partial struct ImGuiOldColumns
{
    [NativeTypeName("ImGuiID")]
    public uint ID;

    [NativeTypeName("ImGuiOldColumnFlags")]
    public int Flags;

    [NativeTypeName("bool")]
    public byte IsFirstFrame;

    [NativeTypeName("bool")]
    public byte IsBeingResized;

    public int Current;

    public int Count;

    public float OffMinX;

    public float OffMaxX;

    public float LineMinY;

    public float LineMaxY;

    public float HostCursorPosY;

    public float HostCursorMaxPosX;

    public ImRect HostInitialClipRect;

    public ImRect HostBackupClipRect;

    public ImRect HostBackupParentWorkRect;

    public ImVector_ImGuiOldColumnData Columns;

    public ImDrawListSplitter Splitter;
}
