namespace Dinghy.Internal.Sokol;

public unsafe partial struct ImGuiTextRange
{
    [NativeTypeName("const char *")]
    public sbyte* b;

    [NativeTypeName("const char *")]
    public sbyte* e;
}
