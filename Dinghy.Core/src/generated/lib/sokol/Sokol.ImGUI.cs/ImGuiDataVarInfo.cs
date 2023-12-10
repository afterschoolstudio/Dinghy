namespace Dinghy.Internal.Sokol;

public partial struct ImGuiDataVarInfo
{
    [NativeTypeName("ImGuiDataType")]
    public int Type;

    [NativeTypeName("ImU32")]
    public uint Count;

    [NativeTypeName("ImU32")]
    public uint Offset;
}
