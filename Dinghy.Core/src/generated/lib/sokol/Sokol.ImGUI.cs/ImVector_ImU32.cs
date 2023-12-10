namespace Dinghy.Internal.Sokol;

public unsafe partial struct ImVector_ImU32
{
    public int Size;

    public int Capacity;

    [NativeTypeName("ImU32 *")]
    public uint* Data;
}
