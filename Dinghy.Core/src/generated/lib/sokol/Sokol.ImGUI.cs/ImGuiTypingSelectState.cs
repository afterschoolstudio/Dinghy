namespace Dinghy.Internal.Sokol;

public unsafe partial struct ImGuiTypingSelectState
{
    public ImGuiTypingSelectRequest Request;

    [NativeTypeName("char[64]")]
    public fixed sbyte SearchBuffer[64];

    [NativeTypeName("ImGuiID")]
    public uint FocusScope;

    public int LastRequestFrame;

    public float LastRequestTime;

    [NativeTypeName("bool")]
    public byte SingleCharModeLock;
}
