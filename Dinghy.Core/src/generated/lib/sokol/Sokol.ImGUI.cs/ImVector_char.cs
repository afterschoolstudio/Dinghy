namespace Dinghy.Internal.Sokol;

public unsafe partial struct ImVector_char
{
    public int Size;

    public int Capacity;

    [NativeTypeName("char *")]
    public sbyte* Data;
}
