namespace Dinghy.Internal.Sokol;

public unsafe partial struct ImVector_const_charPtr
{
    public int Size;

    public int Capacity;

    [NativeTypeName("const char **")]
    public sbyte** Data;
}
