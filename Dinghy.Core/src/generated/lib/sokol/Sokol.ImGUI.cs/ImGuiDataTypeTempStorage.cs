namespace Dinghy.Internal.Sokol;

public unsafe partial struct ImGuiDataTypeTempStorage
{
    [NativeTypeName("ImU8[8]")]
    public fixed byte Data[8];
}
