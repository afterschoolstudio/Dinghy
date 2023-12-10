namespace Dinghy.Internal.Sokol;

public unsafe partial struct ImGuiPopupData
{
    [NativeTypeName("ImGuiID")]
    public uint PopupId;

    public ImGuiWindow* Window;

    public ImGuiWindow* BackupNavWindow;

    public int ParentNavLayer;

    public int OpenFrameCount;

    [NativeTypeName("ImGuiID")]
    public uint OpenParentId;

    public ImVec2 OpenPopupPos;

    public ImVec2 OpenMousePos;
}
