namespace Dinghy.Internal.Sokol;

public unsafe partial struct ImFontConfig
{
    public void* FontData;

    public int FontDataSize;

    [NativeTypeName("bool")]
    public byte FontDataOwnedByAtlas;

    public int FontNo;

    public float SizePixels;

    public int OversampleH;

    public int OversampleV;

    [NativeTypeName("bool")]
    public byte PixelSnapH;

    public ImVec2 GlyphExtraSpacing;

    public ImVec2 GlyphOffset;

    [NativeTypeName("const ImWchar *")]
    public ushort* GlyphRanges;

    public float GlyphMinAdvanceX;

    public float GlyphMaxAdvanceX;

    [NativeTypeName("bool")]
    public byte MergeMode;

    [NativeTypeName("unsigned int")]
    public uint FontBuilderFlags;

    public float RasterizerMultiply;

    public float RasterizerDensity;

    [NativeTypeName("ImWchar")]
    public ushort EllipsisChar;

    [NativeTypeName("char[40]")]
    public fixed sbyte Name[40];

    public ImFont* DstFont;
}
