namespace Dinghy.Internal.Sokol;

public partial struct ImGuiIDStackTool
{
    public int LastActiveFrame;

    public int StackLevel;

    [NativeTypeName("ImGuiID")]
    public uint QueryId;

    public ImVector_ImGuiStackLevelInfo Results;

    [NativeTypeName("bool")]
    public byte CopyToClipboardOnCtrlC;

    public float CopyToClipboardLastTime;
}
