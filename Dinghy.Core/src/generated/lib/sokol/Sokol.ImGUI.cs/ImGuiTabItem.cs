namespace Dinghy.Internal.Sokol;

public unsafe partial struct ImGuiTabItem
{
    [NativeTypeName("ImGuiID")]
    public uint ID;

    [NativeTypeName("ImGuiTabItemFlags")]
    public int Flags;

    public ImGuiWindow* Window;

    public int LastFrameVisible;

    public int LastFrameSelected;

    public float Offset;

    public float Width;

    public float ContentWidth;

    public float RequestedWidth;

    [NativeTypeName("ImS32")]
    public int NameOffset;

    [NativeTypeName("ImS16")]
    public short BeginOrder;

    [NativeTypeName("ImS16")]
    public short IndexDuringLayout;

    [NativeTypeName("bool")]
    public byte WantClose;
}
