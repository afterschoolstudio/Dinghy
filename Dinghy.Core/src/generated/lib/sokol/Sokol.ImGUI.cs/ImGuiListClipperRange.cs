namespace Dinghy.Internal.Sokol;

public partial struct ImGuiListClipperRange
{
    public int Min;

    public int Max;

    [NativeTypeName("bool")]
    public byte PosToIndexConvert;

    [NativeTypeName("ImS8")]
    public sbyte PosToIndexOffsetMin;

    [NativeTypeName("ImS8")]
    public sbyte PosToIndexOffsetMax;
}
