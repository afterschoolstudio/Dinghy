using System.Runtime.CompilerServices;

namespace Dinghy.Internal.Sokol;

public unsafe partial struct ImDrawListSharedData
{
    public ImVec2 TexUvWhitePixel;

    public ImFont* Font;

    public float FontSize;

    public float CurveTessellationTol;

    public float CircleSegmentMaxError;

    public ImVec4 ClipRectFullscreen;

    [NativeTypeName("ImDrawListFlags")]
    public int InitialFlags;

    public ImVector_ImVec2 TempBuffer;

    [NativeTypeName("ImVec2[48]")]
    public _ArcFastVtx_e__FixedBuffer ArcFastVtx;

    public float ArcFastRadiusCutoff;

    [NativeTypeName("ImU8[64]")]
    public fixed byte CircleSegmentCounts[64];

    [NativeTypeName("const ImVec4 *")]
    public ImVec4* TexUvLines;

    [InlineArray(48)]
    public partial struct _ArcFastVtx_e__FixedBuffer
    {
        public ImVec2 e0;
    }
}
