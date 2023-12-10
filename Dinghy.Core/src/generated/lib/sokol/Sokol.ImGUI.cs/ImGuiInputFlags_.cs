namespace Dinghy.Internal.Sokol;

[NativeTypeName("unsigned int")]
public enum ImGuiInputFlags_ : uint
{
    ImGuiInputFlags_None = 0,
    ImGuiInputFlags_Repeat = 1 << 0,
    ImGuiInputFlags_RepeatRateDefault = 1 << 1,
    ImGuiInputFlags_RepeatRateNavMove = 1 << 2,
    ImGuiInputFlags_RepeatRateNavTweak = 1 << 3,
    ImGuiInputFlags_RepeatRateMask_ = ImGuiInputFlags_RepeatRateDefault | ImGuiInputFlags_RepeatRateNavMove | ImGuiInputFlags_RepeatRateNavTweak,
    ImGuiInputFlags_CondHovered = 1 << 4,
    ImGuiInputFlags_CondActive = 1 << 5,
    ImGuiInputFlags_CondDefault_ = ImGuiInputFlags_CondHovered | ImGuiInputFlags_CondActive,
    ImGuiInputFlags_CondMask_ = ImGuiInputFlags_CondHovered | ImGuiInputFlags_CondActive,
    ImGuiInputFlags_LockThisFrame = 1 << 6,
    ImGuiInputFlags_LockUntilRelease = 1 << 7,
    ImGuiInputFlags_RouteFocused = 1 << 8,
    ImGuiInputFlags_RouteGlobalLow = 1 << 9,
    ImGuiInputFlags_RouteGlobal = 1 << 10,
    ImGuiInputFlags_RouteGlobalHigh = 1 << 11,
    ImGuiInputFlags_RouteMask_ = ImGuiInputFlags_RouteFocused | ImGuiInputFlags_RouteGlobal | ImGuiInputFlags_RouteGlobalLow | ImGuiInputFlags_RouteGlobalHigh,
    ImGuiInputFlags_RouteAlways = 1 << 12,
    ImGuiInputFlags_RouteUnlessBgFocused = 1 << 13,
    ImGuiInputFlags_RouteExtraMask_ = ImGuiInputFlags_RouteAlways | ImGuiInputFlags_RouteUnlessBgFocused,
    ImGuiInputFlags_SupportedByIsKeyPressed = ImGuiInputFlags_Repeat | ImGuiInputFlags_RepeatRateMask_,
    ImGuiInputFlags_SupportedByShortcut = ImGuiInputFlags_Repeat | ImGuiInputFlags_RepeatRateMask_ | ImGuiInputFlags_RouteMask_ | ImGuiInputFlags_RouteExtraMask_,
    ImGuiInputFlags_SupportedBySetKeyOwner = ImGuiInputFlags_LockThisFrame | ImGuiInputFlags_LockUntilRelease,
    ImGuiInputFlags_SupportedBySetItemKeyOwner = ImGuiInputFlags_SupportedBySetKeyOwner | ImGuiInputFlags_CondMask_,
}
