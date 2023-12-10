namespace Dinghy.Internal.Sokol;

public unsafe partial struct ImVector_ImGuiItemFlags
{
    public int Size;

    public int Capacity;

    [NativeTypeName("ImGuiItemFlags *")]
    public int* Data;
}
