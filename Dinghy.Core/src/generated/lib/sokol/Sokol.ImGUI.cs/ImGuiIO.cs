using System.Runtime.CompilerServices;

namespace Dinghy.Internal.Sokol;

public unsafe partial struct ImGuiIO
{
    [NativeTypeName("ImGuiConfigFlags")]
    public int ConfigFlags;

    [NativeTypeName("ImGuiBackendFlags")]
    public int BackendFlags;

    public ImVec2 DisplaySize;

    public float DeltaTime;

    public float IniSavingRate;

    [NativeTypeName("const char *")]
    public sbyte* IniFilename;

    [NativeTypeName("const char *")]
    public sbyte* LogFilename;

    public void* UserData;

    public ImFontAtlas* Fonts;

    public float FontGlobalScale;

    [NativeTypeName("bool")]
    public byte FontAllowUserScaling;

    public ImFont* FontDefault;

    public ImVec2 DisplayFramebufferScale;

    [NativeTypeName("bool")]
    public byte ConfigDockingNoSplit;

    [NativeTypeName("bool")]
    public byte ConfigDockingWithShift;

    [NativeTypeName("bool")]
    public byte ConfigDockingAlwaysTabBar;

    [NativeTypeName("bool")]
    public byte ConfigDockingTransparentPayload;

    [NativeTypeName("bool")]
    public byte ConfigViewportsNoAutoMerge;

    [NativeTypeName("bool")]
    public byte ConfigViewportsNoTaskBarIcon;

    [NativeTypeName("bool")]
    public byte ConfigViewportsNoDecoration;

    [NativeTypeName("bool")]
    public byte ConfigViewportsNoDefaultParent;

    [NativeTypeName("bool")]
    public byte MouseDrawCursor;

    [NativeTypeName("bool")]
    public byte ConfigMacOSXBehaviors;

    [NativeTypeName("bool")]
    public byte ConfigInputTrickleEventQueue;

    [NativeTypeName("bool")]
    public byte ConfigInputTextCursorBlink;

    [NativeTypeName("bool")]
    public byte ConfigInputTextEnterKeepActive;

    [NativeTypeName("bool")]
    public byte ConfigDragClickToInputText;

    [NativeTypeName("bool")]
    public byte ConfigWindowsResizeFromEdges;

    [NativeTypeName("bool")]
    public byte ConfigWindowsMoveFromTitleBarOnly;

    public float ConfigMemoryCompactTimer;

    public float MouseDoubleClickTime;

    public float MouseDoubleClickMaxDist;

    public float MouseDragThreshold;

    public float KeyRepeatDelay;

    public float KeyRepeatRate;

    [NativeTypeName("bool")]
    public byte ConfigDebugBeginReturnValueOnce;

    [NativeTypeName("bool")]
    public byte ConfigDebugBeginReturnValueLoop;

    [NativeTypeName("bool")]
    public byte ConfigDebugIgnoreFocusLoss;

    [NativeTypeName("bool")]
    public byte ConfigDebugIniSettings;

    [NativeTypeName("const char *")]
    public sbyte* BackendPlatformName;

    [NativeTypeName("const char *")]
    public sbyte* BackendRendererName;

    public void* BackendPlatformUserData;

    public void* BackendRendererUserData;

    public void* BackendLanguageUserData;

    [NativeTypeName("const char *(*)(void *)")]
    public delegate* unmanaged[Cdecl]<void*, sbyte*> GetClipboardTextFn;

    [NativeTypeName("void (*)(void *, const char *)")]
    public delegate* unmanaged[Cdecl]<void*, sbyte*, void> SetClipboardTextFn;

    public void* ClipboardUserData;

    [NativeTypeName("void (*)(ImGuiViewport *, ImGuiPlatformImeData *)")]
    public delegate* unmanaged[Cdecl]<ImGuiViewport*, ImGuiPlatformImeData*, void> SetPlatformImeDataFn;

    [NativeTypeName("ImWchar")]
    public ushort PlatformLocaleDecimalPoint;

    [NativeTypeName("bool")]
    public byte WantCaptureMouse;

    [NativeTypeName("bool")]
    public byte WantCaptureKeyboard;

    [NativeTypeName("bool")]
    public byte WantTextInput;

    [NativeTypeName("bool")]
    public byte WantSetMousePos;

    [NativeTypeName("bool")]
    public byte WantSaveIniSettings;

    [NativeTypeName("bool")]
    public byte NavActive;

    [NativeTypeName("bool")]
    public byte NavVisible;

    public float Framerate;

    public int MetricsRenderVertices;

    public int MetricsRenderIndices;

    public int MetricsRenderWindows;

    public int MetricsActiveWindows;

    public ImVec2 MouseDelta;

    public void* _UnusedPadding;

    public ImGuiContext* Ctx;

    public ImVec2 MousePos;

    [NativeTypeName("bool[5]")]
    public fixed byte MouseDown[5];

    public float MouseWheel;

    public float MouseWheelH;

    public ImGuiMouseSource MouseSource;

    [NativeTypeName("ImGuiID")]
    public uint MouseHoveredViewport;

    [NativeTypeName("bool")]
    public byte KeyCtrl;

    [NativeTypeName("bool")]
    public byte KeyShift;

    [NativeTypeName("bool")]
    public byte KeyAlt;

    [NativeTypeName("bool")]
    public byte KeySuper;

    [NativeTypeName("ImGuiKeyChord")]
    public int KeyMods;

    [NativeTypeName("ImGuiKeyData[154]")]
    public _KeysData_e__FixedBuffer KeysData;

    [NativeTypeName("bool")]
    public byte WantCaptureMouseUnlessPopupClose;

    public ImVec2 MousePosPrev;

    [NativeTypeName("ImVec2[5]")]
    public _MouseClickedPos_e__FixedBuffer MouseClickedPos;

    [NativeTypeName("double[5]")]
    public fixed double MouseClickedTime[5];

    [NativeTypeName("bool[5]")]
    public fixed byte MouseClicked[5];

    [NativeTypeName("bool[5]")]
    public fixed byte MouseDoubleClicked[5];

    [NativeTypeName("ImU16[5]")]
    public fixed ushort MouseClickedCount[5];

    [NativeTypeName("ImU16[5]")]
    public fixed ushort MouseClickedLastCount[5];

    [NativeTypeName("bool[5]")]
    public fixed byte MouseReleased[5];

    [NativeTypeName("bool[5]")]
    public fixed byte MouseDownOwned[5];

    [NativeTypeName("bool[5]")]
    public fixed byte MouseDownOwnedUnlessPopupClose[5];

    [NativeTypeName("bool")]
    public byte MouseWheelRequestAxisSwap;

    [NativeTypeName("float[5]")]
    public fixed float MouseDownDuration[5];

    [NativeTypeName("float[5]")]
    public fixed float MouseDownDurationPrev[5];

    [NativeTypeName("ImVec2[5]")]
    public _MouseDragMaxDistanceAbs_e__FixedBuffer MouseDragMaxDistanceAbs;

    [NativeTypeName("float[5]")]
    public fixed float MouseDragMaxDistanceSqr[5];

    public float PenPressure;

    [NativeTypeName("bool")]
    public byte AppFocusLost;

    [NativeTypeName("bool")]
    public byte AppAcceptingEvents;

    [NativeTypeName("ImS8")]
    public sbyte BackendUsingLegacyKeyArrays;

    [NativeTypeName("bool")]
    public byte BackendUsingLegacyNavInputArray;

    [NativeTypeName("ImWchar16")]
    public ushort InputQueueSurrogate;

    public ImVector_ImWchar InputQueueCharacters;

    [InlineArray(154)]
    public partial struct _KeysData_e__FixedBuffer
    {
        public ImGuiKeyData e0;
    }

    [InlineArray(5)]
    public partial struct _MouseClickedPos_e__FixedBuffer
    {
        public ImVec2 e0;
    }

    [InlineArray(5)]
    public partial struct _MouseDragMaxDistanceAbs_e__FixedBuffer
    {
        public ImVec2 e0;
    }
}
