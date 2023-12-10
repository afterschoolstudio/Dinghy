namespace Dinghy.Internal.Sokol;

public unsafe partial struct ImVector_ImDrawIdx
{
    public int Size;

    public int Capacity;

    [NativeTypeName("ImDrawIdx *")]
    public ushort* Data;
}
