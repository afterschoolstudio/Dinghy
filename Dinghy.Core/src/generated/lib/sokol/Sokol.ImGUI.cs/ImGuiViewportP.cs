using System.Runtime.CompilerServices;

namespace Dinghy.Internal.Sokol;

public unsafe partial struct ImGuiViewportP
{
    public ImGuiViewport _ImGuiViewport;

    public ImGuiWindow* Window;

    public int Idx;

    public int LastFrameActive;

    public int LastFocusedStampCount;

    [NativeTypeName("ImGuiID")]
    public uint LastNameHash;

    public ImVec2 LastPos;

    public float Alpha;

    public float LastAlpha;

    [NativeTypeName("bool")]
    public byte LastFocusedHadNavWindow;

    public short PlatformMonitor;

    [NativeTypeName("int[2]")]
    public fixed int BgFgDrawListsLastFrame[2];

    [NativeTypeName("ImDrawList *[2]")]
    public _BgFgDrawLists_e__FixedBuffer BgFgDrawLists;

    public ImDrawData DrawDataP;

    public ImDrawDataBuilder DrawDataBuilder;

    public ImVec2 LastPlatformPos;

    public ImVec2 LastPlatformSize;

    public ImVec2 LastRendererSize;

    public ImVec2 WorkOffsetMin;

    public ImVec2 WorkOffsetMax;

    public ImVec2 BuildWorkOffsetMin;

    public ImVec2 BuildWorkOffsetMax;

    public unsafe partial struct _BgFgDrawLists_e__FixedBuffer
    {
        public ImDrawList* e0;
        public ImDrawList* e1;

        public ref ImDrawList* this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                fixed (ImDrawList** pThis = &e0)
                {
                    return ref pThis[index];
                }
            }
        }
    }
}
