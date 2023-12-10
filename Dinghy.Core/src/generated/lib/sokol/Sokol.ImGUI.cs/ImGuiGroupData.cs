namespace Dinghy.Internal.Sokol;

public partial struct ImGuiGroupData
{
    [NativeTypeName("ImGuiID")]
    public uint WindowID;

    public ImVec2 BackupCursorPos;

    public ImVec2 BackupCursorMaxPos;

    public ImVec2 BackupCursorPosPrevLine;

    public ImVec1 BackupIndent;

    public ImVec1 BackupGroupOffset;

    public ImVec2 BackupCurrLineSize;

    public float BackupCurrLineTextBaseOffset;

    [NativeTypeName("ImGuiID")]
    public uint BackupActiveIdIsAlive;

    [NativeTypeName("bool")]
    public byte BackupActiveIdPreviousFrameIsAlive;

    [NativeTypeName("bool")]
    public byte BackupHoveredIdIsAlive;

    [NativeTypeName("bool")]
    public byte BackupIsSameLine;

    [NativeTypeName("bool")]
    public byte EmitItem;
}
