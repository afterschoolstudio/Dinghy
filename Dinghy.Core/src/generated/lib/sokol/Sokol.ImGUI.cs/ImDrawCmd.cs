namespace Dinghy.Internal.Sokol;

public unsafe partial struct ImDrawCmd
{
    public ImVec4 ClipRect;

    [NativeTypeName("ImTextureID")]
    public void* TextureId;

    [NativeTypeName("unsigned int")]
    public uint VtxOffset;

    [NativeTypeName("unsigned int")]
    public uint IdxOffset;

    [NativeTypeName("unsigned int")]
    public uint ElemCount;

    [NativeTypeName("ImDrawCallback")]
    public delegate* unmanaged[Cdecl]<ImDrawList*, ImDrawCmd*, void> UserCallback;

    public void* UserCallbackData;
}
