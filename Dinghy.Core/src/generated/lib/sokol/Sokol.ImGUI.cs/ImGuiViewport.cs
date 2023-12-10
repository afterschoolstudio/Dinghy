namespace Dinghy.Internal.Sokol;

public unsafe partial struct ImGuiViewport
{
    [NativeTypeName("ImGuiID")]
    public uint ID;

    [NativeTypeName("ImGuiViewportFlags")]
    public int Flags;

    public ImVec2 Pos;

    public ImVec2 Size;

    public ImVec2 WorkPos;

    public ImVec2 WorkSize;

    public float DpiScale;

    [NativeTypeName("ImGuiID")]
    public uint ParentViewportId;

    public ImDrawData* DrawData;

    public void* RendererUserData;

    public void* PlatformUserData;

    public void* PlatformHandle;

    public void* PlatformHandleRaw;

    [NativeTypeName("bool")]
    public byte PlatformWindowCreated;

    [NativeTypeName("bool")]
    public byte PlatformRequestMove;

    [NativeTypeName("bool")]
    public byte PlatformRequestResize;

    [NativeTypeName("bool")]
    public byte PlatformRequestClose;
}
