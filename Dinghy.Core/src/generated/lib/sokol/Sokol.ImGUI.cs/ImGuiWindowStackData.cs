namespace Dinghy.Internal.Sokol;

public unsafe partial struct ImGuiWindowStackData
{
    public ImGuiWindow* Window;

    public ImGuiLastItemData ParentLastItemDataBackup;

    public ImGuiStackSizes StackSizesOnBegin;
}
