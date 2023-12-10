namespace Dinghy.Internal.Sokol;

public unsafe partial struct ImGuiNextWindowData
{
    [NativeTypeName("ImGuiNextWindowDataFlags")]
    public int Flags;

    [NativeTypeName("ImGuiCond")]
    public int PosCond;

    [NativeTypeName("ImGuiCond")]
    public int SizeCond;

    [NativeTypeName("ImGuiCond")]
    public int CollapsedCond;

    [NativeTypeName("ImGuiCond")]
    public int DockCond;

    public ImVec2 PosVal;

    public ImVec2 PosPivotVal;

    public ImVec2 SizeVal;

    public ImVec2 ContentSizeVal;

    public ImVec2 ScrollVal;

    [NativeTypeName("ImGuiChildFlags")]
    public int ChildFlags;

    [NativeTypeName("bool")]
    public byte PosUndock;

    [NativeTypeName("bool")]
    public byte CollapsedVal;

    public ImRect SizeConstraintRect;

    [NativeTypeName("ImGuiSizeCallback")]
    public delegate* unmanaged[Cdecl]<ImGuiSizeCallbackData*, void> SizeCallback;

    public void* SizeCallbackUserData;

    public float BgAlphaVal;

    [NativeTypeName("ImGuiID")]
    public uint ViewportId;

    [NativeTypeName("ImGuiID")]
    public uint DockId;

    public ImGuiWindowClass WindowClass;

    public ImVec2 MenuBarOffsetMinVal;
}
