namespace Dinghy.Internal.Sokol;

public partial struct ImGuiComboPreviewData
{
    public ImRect PreviewRect;

    public ImVec2 BackupCursorPos;

    public ImVec2 BackupCursorMaxPos;

    public ImVec2 BackupCursorPosPrevLine;

    public float BackupPrevLineTextBaseOffset;

    [NativeTypeName("ImGuiLayoutType")]
    public int BackupLayout;
}
