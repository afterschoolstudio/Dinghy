namespace Dinghy.Internal.Sokol;

public unsafe partial struct ImVector_ImWchar
{
    public int Size;

    public int Capacity;

    [NativeTypeName("ImWchar *")]
    public ushort* Data;
}
