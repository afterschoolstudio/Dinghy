namespace Dinghy.Internal.Sokol;

public unsafe partial struct ImGuiTextFilter
{
    [NativeTypeName("char[256]")]
    public fixed sbyte InputBuf[256];

    public ImVector_ImGuiTextRange Filters;

    public int CountGrep;
}
