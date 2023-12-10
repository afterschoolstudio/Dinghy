namespace Dinghy.Internal.Sokol;

public unsafe partial struct ImVector_ImTextureID
{
    public int Size;

    public int Capacity;

    [NativeTypeName("ImTextureID *")]
    public void** Data;
}
