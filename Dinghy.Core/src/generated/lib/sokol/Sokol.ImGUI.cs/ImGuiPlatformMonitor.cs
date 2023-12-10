namespace Dinghy.Internal.Sokol;

public unsafe partial struct ImGuiPlatformMonitor
{
    public ImVec2 MainPos;

    public ImVec2 MainSize;

    public ImVec2 WorkPos;

    public ImVec2 WorkSize;

    public float DpiScale;

    public void* PlatformHandle;
}
