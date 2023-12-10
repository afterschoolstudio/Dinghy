using System.Runtime.CompilerServices;

namespace Dinghy.Internal.Sokol;

public unsafe partial struct ImGuiWindow
{
    public ImGuiContext* Ctx;

    [NativeTypeName("char *")]
    public sbyte* Name;

    [NativeTypeName("ImGuiID")]
    public uint ID;

    [NativeTypeName("ImGuiWindowFlags")]
    public int Flags;

    [NativeTypeName("ImGuiWindowFlags")]
    public int FlagsPreviousFrame;

    [NativeTypeName("ImGuiChildFlags")]
    public int ChildFlags;

    public ImGuiWindowClass WindowClass;

    public ImGuiViewportP* Viewport;

    [NativeTypeName("ImGuiID")]
    public uint ViewportId;

    public ImVec2 ViewportPos;

    public int ViewportAllowPlatformMonitorExtend;

    public ImVec2 Pos;

    public ImVec2 Size;

    public ImVec2 SizeFull;

    public ImVec2 ContentSize;

    public ImVec2 ContentSizeIdeal;

    public ImVec2 ContentSizeExplicit;

    public ImVec2 WindowPadding;

    public float WindowRounding;

    public float WindowBorderSize;

    public float DecoOuterSizeX1;

    public float DecoOuterSizeY1;

    public float DecoOuterSizeX2;

    public float DecoOuterSizeY2;

    public float DecoInnerSizeX1;

    public float DecoInnerSizeY1;

    public int NameBufLen;

    [NativeTypeName("ImGuiID")]
    public uint MoveId;

    [NativeTypeName("ImGuiID")]
    public uint TabId;

    [NativeTypeName("ImGuiID")]
    public uint ChildId;

    public ImVec2 Scroll;

    public ImVec2 ScrollMax;

    public ImVec2 ScrollTarget;

    public ImVec2 ScrollTargetCenterRatio;

    public ImVec2 ScrollTargetEdgeSnapDist;

    public ImVec2 ScrollbarSizes;

    [NativeTypeName("bool")]
    public byte ScrollbarX;

    [NativeTypeName("bool")]
    public byte ScrollbarY;

    [NativeTypeName("bool")]
    public byte ViewportOwned;

    [NativeTypeName("bool")]
    public byte Active;

    [NativeTypeName("bool")]
    public byte WasActive;

    [NativeTypeName("bool")]
    public byte WriteAccessed;

    [NativeTypeName("bool")]
    public byte Collapsed;

    [NativeTypeName("bool")]
    public byte WantCollapseToggle;

    [NativeTypeName("bool")]
    public byte SkipItems;

    [NativeTypeName("bool")]
    public byte Appearing;

    [NativeTypeName("bool")]
    public byte Hidden;

    [NativeTypeName("bool")]
    public byte IsFallbackWindow;

    [NativeTypeName("bool")]
    public byte IsExplicitChild;

    [NativeTypeName("bool")]
    public byte HasCloseButton;

    [NativeTypeName("signed char")]
    public sbyte ResizeBorderHovered;

    [NativeTypeName("signed char")]
    public sbyte ResizeBorderHeld;

    public short BeginCount;

    public short BeginCountPreviousFrame;

    public short BeginOrderWithinParent;

    public short BeginOrderWithinContext;

    public short FocusOrder;

    [NativeTypeName("ImGuiID")]
    public uint PopupId;

    [NativeTypeName("ImS8")]
    public sbyte AutoFitFramesX;

    [NativeTypeName("ImS8")]
    public sbyte AutoFitFramesY;

    [NativeTypeName("bool")]
    public byte AutoFitOnlyGrows;

    [NativeTypeName("ImGuiDir")]
    public int AutoPosLastDirection;

    [NativeTypeName("ImS8")]
    public sbyte HiddenFramesCanSkipItems;

    [NativeTypeName("ImS8")]
    public sbyte HiddenFramesCannotSkipItems;

    [NativeTypeName("ImS8")]
    public sbyte HiddenFramesForRenderOnly;

    [NativeTypeName("ImS8")]
    public sbyte DisableInputsFrames;

    public int _bitfield1;

    [NativeTypeName("ImGuiCond : 8")]
    public int SetWindowPosAllowFlags
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            return (_bitfield1 << 24) >> 24;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            _bitfield1 = (_bitfield1 & ~0xFF) | (value & 0xFF);
        }
    }

    [NativeTypeName("ImGuiCond : 8")]
    public int SetWindowSizeAllowFlags
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            return (_bitfield1 << 16) >> 24;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            _bitfield1 = (_bitfield1 & ~(0xFF << 8)) | ((value & 0xFF) << 8);
        }
    }

    [NativeTypeName("ImGuiCond : 8")]
    public int SetWindowCollapsedAllowFlags
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            return (_bitfield1 << 8) >> 24;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            _bitfield1 = (_bitfield1 & ~(0xFF << 16)) | ((value & 0xFF) << 16);
        }
    }

    [NativeTypeName("ImGuiCond : 8")]
    public int SetWindowDockAllowFlags
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            return (_bitfield1 << 0) >> 24;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            _bitfield1 = (_bitfield1 & ~(0xFF << 24)) | ((value & 0xFF) << 24);
        }
    }

    public ImVec2 SetWindowPosVal;

    public ImVec2 SetWindowPosPivot;

    public ImVector_ImGuiID IDStack;

    public ImGuiWindowTempData DC;

    public ImRect OuterRectClipped;

    public ImRect InnerRect;

    public ImRect InnerClipRect;

    public ImRect WorkRect;

    public ImRect ParentWorkRect;

    public ImRect ClipRect;

    public ImRect ContentRegionRect;

    public ImVec2ih HitTestHoleSize;

    public ImVec2ih HitTestHoleOffset;

    public int LastFrameActive;

    public int LastFrameJustFocused;

    public float LastTimeActive;

    public float ItemWidthDefault;

    public ImGuiStorage StateStorage;

    public ImVector_ImGuiOldColumns ColumnsStorage;

    public float FontWindowScale;

    public float FontDpiScale;

    public int SettingsOffset;

    public ImDrawList* DrawList;

    public ImDrawList DrawListInst;

    public ImGuiWindow* ParentWindow;

    public ImGuiWindow* ParentWindowInBeginStack;

    public ImGuiWindow* RootWindow;

    public ImGuiWindow* RootWindowPopupTree;

    public ImGuiWindow* RootWindowDockTree;

    public ImGuiWindow* RootWindowForTitleBarHighlight;

    public ImGuiWindow* RootWindowForNav;

    public ImGuiWindow* NavLastChildNavWindow;

    [NativeTypeName("ImGuiID[2]")]
    public fixed uint NavLastIds[2];

    [NativeTypeName("ImRect[2]")]
    public _NavRectRel_e__FixedBuffer NavRectRel;

    [NativeTypeName("ImVec2[2]")]
    public _NavPreferredScoringPosRel_e__FixedBuffer NavPreferredScoringPosRel;

    [NativeTypeName("ImGuiID")]
    public uint NavRootFocusScopeId;

    public int MemoryDrawListIdxCapacity;

    public int MemoryDrawListVtxCapacity;

    [NativeTypeName("bool")]
    public byte MemoryCompacted;

    public bool _bitfield2;

    [NativeTypeName("bool : 1")]
    public bool DockIsActive
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            return ((_bitfield2 ? 1 : 0) & 0x1) != 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            _bitfield2 = (((_bitfield2 ? 1 : 0) & ~0x1) | ((value ? 1 : 0) & 0x1)) != 0;
        }
    }

    [NativeTypeName("bool : 1")]
    public bool DockNodeIsVisible
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            return (((_bitfield2 ? 1 : 0) >> 1) & 0x1) != 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            _bitfield2 = (((_bitfield2 ? 1 : 0) & ~(0x1 << 1)) | (((value ? 1 : 0) & 0x1) << 1)) != 0;
        }
    }

    [NativeTypeName("bool : 1")]
    public bool DockTabIsVisible
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            return (((_bitfield2 ? 1 : 0) >> 2) & 0x1) != 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            _bitfield2 = (((_bitfield2 ? 1 : 0) & ~(0x1 << 2)) | (((value ? 1 : 0) & 0x1) << 2)) != 0;
        }
    }

    [NativeTypeName("bool : 1")]
    public bool DockTabWantClose
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            return (((_bitfield2 ? 1 : 0) >> 3) & 0x1) != 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            _bitfield2 = (((_bitfield2 ? 1 : 0) & ~(0x1 << 3)) | (((value ? 1 : 0) & 0x1) << 3)) != 0;
        }
    }

    public short DockOrder;

    public ImGuiWindowDockStyle DockStyle;

    public ImGuiDockNode* DockNode;

    public ImGuiDockNode* DockNodeAsHost;

    [NativeTypeName("ImGuiID")]
    public uint DockId;

    [NativeTypeName("ImGuiItemStatusFlags")]
    public int DockTabItemStatusFlags;

    public ImRect DockTabItemRect;

    [InlineArray(2)]
    public partial struct _NavRectRel_e__FixedBuffer
    {
        public ImRect e0;
    }

    [InlineArray(2)]
    public partial struct _NavPreferredScoringPosRel_e__FixedBuffer
    {
        public ImVec2 e0;
    }
}
