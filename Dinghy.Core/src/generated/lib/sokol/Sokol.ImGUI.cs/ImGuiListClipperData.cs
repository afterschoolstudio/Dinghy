namespace Dinghy.Internal.Sokol;

public unsafe partial struct ImGuiListClipperData
{
    public ImGuiListClipper* ListClipper;

    public float LossynessOffset;

    public int StepNo;

    public int ItemsFrozen;

    public ImVector_ImGuiListClipperRange Ranges;
}
