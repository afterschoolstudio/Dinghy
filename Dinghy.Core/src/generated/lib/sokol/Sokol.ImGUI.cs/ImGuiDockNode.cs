using System.Runtime.CompilerServices;

namespace Dinghy.Internal.Sokol;

public unsafe partial struct ImGuiDockNode
{
    [NativeTypeName("ImGuiID")]
    public uint ID;

    [NativeTypeName("ImGuiDockNodeFlags")]
    public int SharedFlags;

    [NativeTypeName("ImGuiDockNodeFlags")]
    public int LocalFlags;

    [NativeTypeName("ImGuiDockNodeFlags")]
    public int LocalFlagsInWindows;

    [NativeTypeName("ImGuiDockNodeFlags")]
    public int MergedFlags;

    public ImGuiDockNodeState State;

    public ImGuiDockNode* ParentNode;

    [NativeTypeName("ImGuiDockNode *[2]")]
    public _ChildNodes_e__FixedBuffer ChildNodes;

    public ImVector_ImGuiWindowPtr Windows;

    public ImGuiTabBar* TabBar;

    public ImVec2 Pos;

    public ImVec2 Size;

    public ImVec2 SizeRef;

    public ImGuiAxis SplitAxis;

    public ImGuiWindowClass WindowClass;

    [NativeTypeName("ImU32")]
    public uint LastBgColor;

    public ImGuiWindow* HostWindow;

    public ImGuiWindow* VisibleWindow;

    public ImGuiDockNode* CentralNode;

    public ImGuiDockNode* OnlyNodeWithWindows;

    public int CountNodeWithWindows;

    public int LastFrameAlive;

    public int LastFrameActive;

    public int LastFrameFocused;

    [NativeTypeName("ImGuiID")]
    public uint LastFocusedNodeId;

    [NativeTypeName("ImGuiID")]
    public uint SelectedTabId;

    [NativeTypeName("ImGuiID")]
    public uint WantCloseTabId;

    [NativeTypeName("ImGuiID")]
    public uint RefViewportId;

    public int _bitfield;

    [NativeTypeName("ImGuiDataAuthority : 3")]
    public int AuthorityForPos
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            return (_bitfield << 29) >> 29;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            _bitfield = (_bitfield & ~0x7) | (value & 0x7);
        }
    }

    [NativeTypeName("ImGuiDataAuthority : 3")]
    public int AuthorityForSize
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            return (_bitfield << 26) >> 29;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            _bitfield = (_bitfield & ~(0x7 << 3)) | ((value & 0x7) << 3);
        }
    }

    [NativeTypeName("ImGuiDataAuthority : 3")]
    public int AuthorityForViewport
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            return (_bitfield << 23) >> 29;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            _bitfield = (_bitfield & ~(0x7 << 6)) | ((value & 0x7) << 6);
        }
    }

    [NativeTypeName("bool : 1")]
    public bool IsVisible
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            return (((_bitfield) >> 9) & 0x1) != 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            _bitfield = (_bitfield & ~(0x1 << 9)) | (int)(((value ? 1 : 0) & 0x1) << 9);
        }
    }

    [NativeTypeName("bool : 1")]
    public bool IsFocused
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            return (((_bitfield) >> 10) & 0x1) != 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            _bitfield = (_bitfield & ~(0x1 << 10)) | (int)(((value ? 1 : 0) & 0x1) << 10);
        }
    }

    [NativeTypeName("bool : 1")]
    public bool IsBgDrawnThisFrame
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            return (((_bitfield) >> 11) & 0x1) != 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            _bitfield = (_bitfield & ~(0x1 << 11)) | (int)(((value ? 1 : 0) & 0x1) << 11);
        }
    }

    [NativeTypeName("bool : 1")]
    public bool HasCloseButton
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            return (((_bitfield) >> 12) & 0x1) != 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            _bitfield = (_bitfield & ~(0x1 << 12)) | (int)(((value ? 1 : 0) & 0x1) << 12);
        }
    }

    [NativeTypeName("bool : 1")]
    public bool HasWindowMenuButton
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            return (((_bitfield) >> 13) & 0x1) != 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            _bitfield = (_bitfield & ~(0x1 << 13)) | (int)(((value ? 1 : 0) & 0x1) << 13);
        }
    }

    [NativeTypeName("bool : 1")]
    public bool HasCentralNodeChild
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            return (((_bitfield) >> 14) & 0x1) != 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            _bitfield = (_bitfield & ~(0x1 << 14)) | (int)(((value ? 1 : 0) & 0x1) << 14);
        }
    }

    [NativeTypeName("bool : 1")]
    public bool WantCloseAll
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            return (((_bitfield) >> 15) & 0x1) != 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            _bitfield = (_bitfield & ~(0x1 << 15)) | (int)(((value ? 1 : 0) & 0x1) << 15);
        }
    }

    [NativeTypeName("bool : 1")]
    public bool WantLockSizeOnce
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            return (((_bitfield) >> 16) & 0x1) != 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            _bitfield = (_bitfield & ~(0x1 << 16)) | (int)(((value ? 1 : 0) & 0x1) << 16);
        }
    }

    [NativeTypeName("bool : 1")]
    public bool WantMouseMove
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            return (((_bitfield) >> 17) & 0x1) != 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            _bitfield = (_bitfield & ~(0x1 << 17)) | (int)(((value ? 1 : 0) & 0x1) << 17);
        }
    }

    [NativeTypeName("bool : 1")]
    public bool WantHiddenTabBarUpdate
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            return (((_bitfield) >> 18) & 0x1) != 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            _bitfield = (_bitfield & ~(0x1 << 18)) | (int)(((value ? 1 : 0) & 0x1) << 18);
        }
    }

    [NativeTypeName("bool : 1")]
    public bool WantHiddenTabBarToggle
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            return (((_bitfield) >> 19) & 0x1) != 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            _bitfield = (_bitfield & ~(0x1 << 19)) | (int)(((value ? 1 : 0) & 0x1) << 19);
        }
    }

    public unsafe partial struct _ChildNodes_e__FixedBuffer
    {
        public ImGuiDockNode* e0;
        public ImGuiDockNode* e1;

        public ref ImGuiDockNode* this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                fixed (ImGuiDockNode** pThis = &e0)
                {
                    return ref pThis[index];
                }
            }
        }
    }
}
