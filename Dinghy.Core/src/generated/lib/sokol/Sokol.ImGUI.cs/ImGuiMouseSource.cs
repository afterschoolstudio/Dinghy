namespace Dinghy.Internal.Sokol;

[NativeTypeName("unsigned int")]
public enum ImGuiMouseSource : uint
{
    ImGuiMouseSource_Mouse = 0,
    ImGuiMouseSource_TouchScreen = 1,
    ImGuiMouseSource_Pen = 2,
    ImGuiMouseSource_COUNT = 3,
}
