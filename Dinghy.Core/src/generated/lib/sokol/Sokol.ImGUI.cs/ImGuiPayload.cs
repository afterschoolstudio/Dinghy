namespace Dinghy.Internal.Sokol;

public unsafe partial struct ImGuiPayload
{
    public void* Data;

    public int DataSize;

    [NativeTypeName("ImGuiID")]
    public uint SourceId;

    [NativeTypeName("ImGuiID")]
    public uint SourceParentId;

    public int DataFrameCount;

    [NativeTypeName("char[33]")]
    public fixed sbyte DataType[33];

    [NativeTypeName("bool")]
    public byte Preview;

    [NativeTypeName("bool")]
    public byte Delivery;
}
