using static Dinghy.Internal.Sokol.ImGuiTabItemFlags_;

namespace Dinghy.Internal.Sokol;

[NativeTypeName("unsigned int")]
public enum ImGuiTabItemFlagsPrivate_ : uint
{
    ImGuiTabItemFlags_SectionMask_ = ImGuiTabItemFlags_Leading | ImGuiTabItemFlags_Trailing,
    ImGuiTabItemFlags_NoCloseButton = 1 << 20,
    ImGuiTabItemFlags_Button = 1 << 21,
    ImGuiTabItemFlags_Unsorted = 1 << 22,
}
