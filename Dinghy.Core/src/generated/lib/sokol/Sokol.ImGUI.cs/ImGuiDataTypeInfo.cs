namespace Dinghy.Internal.Sokol;

public unsafe partial struct ImGuiDataTypeInfo
{
    [NativeTypeName("size_t")]
    public nuint Size;

    [NativeTypeName("const char *")]
    public sbyte* Name;

    [NativeTypeName("const char *")]
    public sbyte* PrintFmt;

    [NativeTypeName("const char *")]
    public sbyte* ScanFmt;
}
