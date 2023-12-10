namespace Dinghy.Internal.Sokol;

public unsafe partial struct ImGuiInputTextState
{
    public ImGuiContext* Ctx;

    [NativeTypeName("ImGuiID")]
    public uint ID;

    public int CurLenW;

    public int CurLenA;

    public ImVector_ImWchar TextW;

    public ImVector_char TextA;

    public ImVector_char InitialTextA;

    [NativeTypeName("bool")]
    public byte TextAIsValid;

    public int BufCapacityA;

    public float ScrollX;

    public STB_TexteditState Stb;

    public float CursorAnim;

    [NativeTypeName("bool")]
    public byte CursorFollow;

    [NativeTypeName("bool")]
    public byte SelectedAllMouseLock;

    [NativeTypeName("bool")]
    public byte Edited;

    [NativeTypeName("ImGuiInputTextFlags")]
    public int Flags;
}
