namespace Dinghy.Internal.Sokol;

public unsafe partial struct ImGuiLocEntry
{
    public ImGuiLocKey Key;

    [NativeTypeName("const char *")]
    public sbyte* Text;
}
