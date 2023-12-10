namespace Dinghy.Internal.Sokol;

public unsafe partial struct ImGuiTypingSelectRequest
{
    [NativeTypeName("ImGuiTypingSelectFlags")]
    public int Flags;

    public int SearchBufferLen;

    [NativeTypeName("const char *")]
    public sbyte* SearchBuffer;

    [NativeTypeName("bool")]
    public byte SelectRequest;

    [NativeTypeName("bool")]
    public byte SingleCharMode;

    [NativeTypeName("ImS8")]
    public sbyte SingleCharSize;
}
