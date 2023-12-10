namespace Dinghy.Internal.Sokol;

public unsafe partial struct ImFont
{
    public ImVector_float IndexAdvanceX;

    public float FallbackAdvanceX;

    public float FontSize;

    public ImVector_ImWchar IndexLookup;

    public ImVector_ImFontGlyph Glyphs;

    [NativeTypeName("const ImFontGlyph *")]
    public ImFontGlyph* FallbackGlyph;

    public ImFontAtlas* ContainerAtlas;

    [NativeTypeName("const ImFontConfig *")]
    public ImFontConfig* ConfigData;

    public short ConfigDataCount;

    [NativeTypeName("ImWchar")]
    public ushort FallbackChar;

    [NativeTypeName("ImWchar")]
    public ushort EllipsisChar;

    public short EllipsisCharCount;

    public float EllipsisWidth;

    public float EllipsisCharStep;

    [NativeTypeName("bool")]
    public byte DirtyLookupTables;

    public float Scale;

    public float Ascent;

    public float Descent;

    public int MetricsTotalSurface;

    [NativeTypeName("ImU8[2]")]
    public fixed byte Used4kPagesMap[2];
}
