namespace Dinghy.Internal.Sokol;

public unsafe partial struct ImVector_unsigned_char
{
    public int Size;

    public int Capacity;

    [NativeTypeName("unsigned char *")]
    public byte* Data;
}
