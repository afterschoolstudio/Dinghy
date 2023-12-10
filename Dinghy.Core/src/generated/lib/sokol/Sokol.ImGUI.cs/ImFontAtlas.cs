using System.Runtime.CompilerServices;

namespace Dinghy.Internal.Sokol;

public unsafe partial struct ImFontAtlas
{
    [NativeTypeName("ImFontAtlasFlags")]
    public int Flags;

    [NativeTypeName("ImTextureID")]
    public void* TexID;

    public int TexDesiredWidth;

    public int TexGlyphPadding;

    [NativeTypeName("bool")]
    public byte Locked;

    public void* UserData;

    [NativeTypeName("bool")]
    public byte TexReady;

    [NativeTypeName("bool")]
    public byte TexPixelsUseColors;

    [NativeTypeName("unsigned char *")]
    public byte* TexPixelsAlpha8;

    [NativeTypeName("unsigned int *")]
    public uint* TexPixelsRGBA32;

    public int TexWidth;

    public int TexHeight;

    public ImVec2 TexUvScale;

    public ImVec2 TexUvWhitePixel;

    public ImVector_ImFontPtr Fonts;

    public ImVector_ImFontAtlasCustomRect CustomRects;

    public ImVector_ImFontConfig ConfigData;

    [NativeTypeName("ImVec4[64]")]
    public _TexUvLines_e__FixedBuffer TexUvLines;

    [NativeTypeName("const ImFontBuilderIO *")]
    public ImFontBuilderIO* FontBuilderIO;

    [NativeTypeName("unsigned int")]
    public uint FontBuilderFlags;

    public int PackIdMouseCursors;

    public int PackIdLines;

    [InlineArray(64)]
    public partial struct _TexUvLines_e__FixedBuffer
    {
        public ImVec4 e0;
    }
}
