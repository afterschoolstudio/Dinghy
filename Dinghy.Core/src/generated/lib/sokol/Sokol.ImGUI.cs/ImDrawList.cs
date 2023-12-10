namespace Dinghy.Internal.Sokol;

public unsafe partial struct ImDrawList
{
    public ImVector_ImDrawCmd CmdBuffer;

    public ImVector_ImDrawIdx IdxBuffer;

    public ImVector_ImDrawVert VtxBuffer;

    [NativeTypeName("ImDrawListFlags")]
    public int Flags;

    [NativeTypeName("unsigned int")]
    public uint _VtxCurrentIdx;

    public ImDrawListSharedData* _Data;

    [NativeTypeName("const char *")]
    public sbyte* _OwnerName;

    public ImDrawVert* _VtxWritePtr;

    [NativeTypeName("ImDrawIdx *")]
    public ushort* _IdxWritePtr;

    public ImVector_ImVec4 _ClipRectStack;

    public ImVector_ImTextureID _TextureIdStack;

    public ImVector_ImVec2 _Path;

    public ImDrawCmdHeader _CmdHeader;

    public ImDrawListSplitter _Splitter;

    public float _FringeScale;
}
