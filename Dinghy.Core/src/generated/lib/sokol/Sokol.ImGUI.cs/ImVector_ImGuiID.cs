namespace Dinghy.Internal.Sokol;

public unsafe partial struct ImVector_ImGuiID
{
    public int Size;

    public int Capacity;

    [NativeTypeName("ImGuiID *")]
    public uint* Data;
}
