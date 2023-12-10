namespace Dinghy.Internal.Sokol;

[NativeTypeName("unsigned int")]
public enum ImGuiDebugLogFlags_ : uint
{
    ImGuiDebugLogFlags_None = 0,
    ImGuiDebugLogFlags_EventActiveId = 1 << 0,
    ImGuiDebugLogFlags_EventFocus = 1 << 1,
    ImGuiDebugLogFlags_EventPopup = 1 << 2,
    ImGuiDebugLogFlags_EventNav = 1 << 3,
    ImGuiDebugLogFlags_EventClipper = 1 << 4,
    ImGuiDebugLogFlags_EventSelection = 1 << 5,
    ImGuiDebugLogFlags_EventIO = 1 << 6,
    ImGuiDebugLogFlags_EventDocking = 1 << 7,
    ImGuiDebugLogFlags_EventViewport = 1 << 8,
    ImGuiDebugLogFlags_EventMask_ = ImGuiDebugLogFlags_EventActiveId | ImGuiDebugLogFlags_EventFocus | ImGuiDebugLogFlags_EventPopup | ImGuiDebugLogFlags_EventNav | ImGuiDebugLogFlags_EventClipper | ImGuiDebugLogFlags_EventSelection | ImGuiDebugLogFlags_EventIO | ImGuiDebugLogFlags_EventDocking | ImGuiDebugLogFlags_EventViewport,
    ImGuiDebugLogFlags_OutputToTTY = 1 << 10,
    ImGuiDebugLogFlags_OutputToTestEngine = 1 << 11,
}
