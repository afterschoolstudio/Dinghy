namespace Dinghy.Internal.Sokol;

public unsafe partial struct ImGuiInputTextCallbackData
{
    public ImGuiContext* Ctx;

    [NativeTypeName("ImGuiInputTextFlags")]
    public int EventFlag;

    [NativeTypeName("ImGuiInputTextFlags")]
    public int Flags;

    public void* UserData;

    [NativeTypeName("ImWchar")]
    public ushort EventChar;

    public ImGuiKey EventKey;

    [NativeTypeName("char *")]
    public sbyte* Buf;

    public int BufTextLen;

    public int BufSize;

    [NativeTypeName("bool")]
    public byte BufDirty;

    public int CursorPos;

    public int SelectionStart;

    public int SelectionEnd;
}
