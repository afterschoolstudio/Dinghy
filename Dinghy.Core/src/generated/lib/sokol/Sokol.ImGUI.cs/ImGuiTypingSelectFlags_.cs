namespace Dinghy.Internal.Sokol;

[NativeTypeName("unsigned int")]
public enum ImGuiTypingSelectFlags_ : uint
{
    ImGuiTypingSelectFlags_None = 0,
    ImGuiTypingSelectFlags_AllowBackspace = 1 << 0,
    ImGuiTypingSelectFlags_AllowSingleCharMode = 1 << 1,
}
