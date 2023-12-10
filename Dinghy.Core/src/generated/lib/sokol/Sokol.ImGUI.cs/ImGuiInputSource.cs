namespace Dinghy.Internal.Sokol;

[NativeTypeName("unsigned int")]
public enum ImGuiInputSource : uint
{
    ImGuiInputSource_None = 0,
    ImGuiInputSource_Mouse,
    ImGuiInputSource_Keyboard,
    ImGuiInputSource_Gamepad,
    ImGuiInputSource_Clipboard,
    ImGuiInputSource_COUNT,
}
