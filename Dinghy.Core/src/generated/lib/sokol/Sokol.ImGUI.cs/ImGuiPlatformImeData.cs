namespace Dinghy.Internal.Sokol;

public partial struct ImGuiPlatformImeData
{
    [NativeTypeName("bool")]
    public byte WantVisible;

    public ImVec2 InputPos;

    public float InputLineHeight;
}
