namespace Dinghy.Internal.Sokol;

public unsafe partial struct ImFontBuilderIO
{
    [NativeTypeName("bool (*)(ImFontAtlas *)")]
    public delegate* unmanaged[Cdecl]<ImFontAtlas*, byte> FontBuilder_Build;
}
