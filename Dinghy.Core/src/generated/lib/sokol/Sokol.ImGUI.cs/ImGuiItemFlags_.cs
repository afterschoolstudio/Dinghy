namespace Dinghy.Internal.Sokol;

[NativeTypeName("unsigned int")]
public enum ImGuiItemFlags_ : uint
{
    ImGuiItemFlags_None = 0,
    ImGuiItemFlags_NoTabStop = 1 << 0,
    ImGuiItemFlags_ButtonRepeat = 1 << 1,
    ImGuiItemFlags_Disabled = 1 << 2,
    ImGuiItemFlags_NoNav = 1 << 3,
    ImGuiItemFlags_NoNavDefaultFocus = 1 << 4,
    ImGuiItemFlags_SelectableDontClosePopup = 1 << 5,
    ImGuiItemFlags_MixedValue = 1 << 6,
    ImGuiItemFlags_ReadOnly = 1 << 7,
    ImGuiItemFlags_NoWindowHoverableCheck = 1 << 8,
    ImGuiItemFlags_AllowOverlap = 1 << 9,
    ImGuiItemFlags_Inputable = 1 << 10,
    ImGuiItemFlags_HasSelectionUserData = 1 << 11,
}
