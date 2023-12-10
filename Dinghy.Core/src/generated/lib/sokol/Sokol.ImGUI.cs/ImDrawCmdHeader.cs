namespace Dinghy.Internal.Sokol;

public unsafe partial struct ImDrawCmdHeader
{
    public ImVec4 ClipRect;

    [NativeTypeName("ImTextureID")]
    public void* TextureId;

    [NativeTypeName("unsigned int")]
    public uint VtxOffset;
}
