namespace Dinghy.Internal.Sokol;

public unsafe partial struct ImGuiListClipper
{
    public ImGuiContext* Ctx;

    public int DisplayStart;

    public int DisplayEnd;

    public int ItemsCount;

    public float ItemsHeight;

    public float StartPosY;

    public void* TempData;
}
