namespace Dinghy.Internal.Sokol;

public unsafe partial struct ImGuiSizeCallbackData
{
    public void* UserData;

    public ImVec2 Pos;

    public ImVec2 CurrentSize;

    public ImVec2 DesiredSize;
}
