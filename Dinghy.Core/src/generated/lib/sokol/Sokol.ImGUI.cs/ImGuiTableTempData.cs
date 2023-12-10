namespace Dinghy.Internal.Sokol;

public partial struct ImGuiTableTempData
{
    public int TableIndex;

    public float LastTimeActive;

    public float AngledheadersExtraWidth;

    public ImVec2 UserOuterSize;

    public ImDrawListSplitter DrawSplitter;

    public ImRect HostBackupWorkRect;

    public ImRect HostBackupParentWorkRect;

    public ImVec2 HostBackupPrevLineSize;

    public ImVec2 HostBackupCurrLineSize;

    public ImVec2 HostBackupCursorMaxPos;

    public ImVec1 HostBackupColumnsOffset;

    public float HostBackupItemWidth;

    public int HostBackupItemWidthStackSize;
}
