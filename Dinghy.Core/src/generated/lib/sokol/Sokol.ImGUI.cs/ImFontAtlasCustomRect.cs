namespace Dinghy.Internal.Sokol;

public unsafe partial struct ImFontAtlasCustomRect
{
    [NativeTypeName("unsigned short")]
    public ushort Width;

    [NativeTypeName("unsigned short")]
    public ushort Height;

    [NativeTypeName("unsigned short")]
    public ushort X;

    [NativeTypeName("unsigned short")]
    public ushort Y;

    [NativeTypeName("unsigned int")]
    public uint GlyphID;

    public float GlyphAdvanceX;

    public ImVec2 GlyphOffset;

    public ImFont* Font;
}
