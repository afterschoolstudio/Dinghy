using System.Runtime.CompilerServices;

namespace Dinghy.Internal.Sokol;

public unsafe partial struct ImGuiContext
{
    [NativeTypeName("bool")]
    public byte Initialized;

    [NativeTypeName("bool")]
    public byte FontAtlasOwnedByContext;

    public ImGuiIO IO;

    public ImGuiPlatformIO PlatformIO;

    public ImGuiStyle Style;

    [NativeTypeName("ImGuiConfigFlags")]
    public int ConfigFlagsCurrFrame;

    [NativeTypeName("ImGuiConfigFlags")]
    public int ConfigFlagsLastFrame;

    public ImFont* Font;

    public float FontSize;

    public float FontBaseSize;

    public ImDrawListSharedData DrawListSharedData;

    public double Time;

    public int FrameCount;

    public int FrameCountEnded;

    public int FrameCountPlatformEnded;

    public int FrameCountRendered;

    [NativeTypeName("bool")]
    public byte WithinFrameScope;

    [NativeTypeName("bool")]
    public byte WithinFrameScopeWithImplicitWindow;

    [NativeTypeName("bool")]
    public byte WithinEndChild;

    [NativeTypeName("bool")]
    public byte GcCompactAll;

    [NativeTypeName("bool")]
    public byte TestEngineHookItems;

    public void* TestEngine;

    public ImVector_ImGuiInputEvent InputEventsQueue;

    public ImVector_ImGuiInputEvent InputEventsTrail;

    public ImGuiMouseSource InputEventsNextMouseSource;

    [NativeTypeName("ImU32")]
    public uint InputEventsNextEventId;

    public ImVector_ImGuiWindowPtr Windows;

    public ImVector_ImGuiWindowPtr WindowsFocusOrder;

    public ImVector_ImGuiWindowPtr WindowsTempSortBuffer;

    public ImVector_ImGuiWindowStackData CurrentWindowStack;

    public ImGuiStorage WindowsById;

    public int WindowsActiveCount;

    public ImVec2 WindowsHoverPadding;

    public ImGuiWindow* CurrentWindow;

    public ImGuiWindow* HoveredWindow;

    public ImGuiWindow* HoveredWindowUnderMovingWindow;

    public ImGuiWindow* MovingWindow;

    public ImGuiWindow* WheelingWindow;

    public ImVec2 WheelingWindowRefMousePos;

    public int WheelingWindowStartFrame;

    public int WheelingWindowScrolledFrame;

    public float WheelingWindowReleaseTimer;

    public ImVec2 WheelingWindowWheelRemainder;

    public ImVec2 WheelingAxisAvg;

    [NativeTypeName("ImGuiID")]
    public uint DebugHookIdInfo;

    [NativeTypeName("ImGuiID")]
    public uint HoveredId;

    [NativeTypeName("ImGuiID")]
    public uint HoveredIdPreviousFrame;

    [NativeTypeName("bool")]
    public byte HoveredIdAllowOverlap;

    [NativeTypeName("bool")]
    public byte HoveredIdDisabled;

    public float HoveredIdTimer;

    public float HoveredIdNotActiveTimer;

    [NativeTypeName("ImGuiID")]
    public uint ActiveId;

    [NativeTypeName("ImGuiID")]
    public uint ActiveIdIsAlive;

    public float ActiveIdTimer;

    [NativeTypeName("bool")]
    public byte ActiveIdIsJustActivated;

    [NativeTypeName("bool")]
    public byte ActiveIdAllowOverlap;

    [NativeTypeName("bool")]
    public byte ActiveIdNoClearOnFocusLoss;

    [NativeTypeName("bool")]
    public byte ActiveIdHasBeenPressedBefore;

    [NativeTypeName("bool")]
    public byte ActiveIdHasBeenEditedBefore;

    [NativeTypeName("bool")]
    public byte ActiveIdHasBeenEditedThisFrame;

    public ImVec2 ActiveIdClickOffset;

    public ImGuiWindow* ActiveIdWindow;

    public ImGuiInputSource ActiveIdSource;

    public int ActiveIdMouseButton;

    [NativeTypeName("ImGuiID")]
    public uint ActiveIdPreviousFrame;

    [NativeTypeName("bool")]
    public byte ActiveIdPreviousFrameIsAlive;

    [NativeTypeName("bool")]
    public byte ActiveIdPreviousFrameHasBeenEditedBefore;

    public ImGuiWindow* ActiveIdPreviousFrameWindow;

    [NativeTypeName("ImGuiID")]
    public uint LastActiveId;

    public float LastActiveIdTimer;

    [NativeTypeName("ImGuiKeyOwnerData[154]")]
    public _KeysOwnerData_e__FixedBuffer KeysOwnerData;

    public ImGuiKeyRoutingTable KeysRoutingTable;

    [NativeTypeName("ImU32")]
    public uint ActiveIdUsingNavDirMask;

    [NativeTypeName("bool")]
    public byte ActiveIdUsingAllKeyboardKeys;

    [NativeTypeName("ImGuiID")]
    public uint CurrentFocusScopeId;

    [NativeTypeName("ImGuiItemFlags")]
    public int CurrentItemFlags;

    [NativeTypeName("ImGuiID")]
    public uint DebugLocateId;

    public ImGuiNextItemData NextItemData;

    public ImGuiLastItemData LastItemData;

    public ImGuiNextWindowData NextWindowData;

    [NativeTypeName("bool")]
    public byte DebugShowGroupRects;

    public ImVector_ImGuiColorMod ColorStack;

    public ImVector_ImGuiStyleMod StyleVarStack;

    public ImVector_ImFontPtr FontStack;

    public ImVector_ImGuiID FocusScopeStack;

    public ImVector_ImGuiItemFlags ItemFlagsStack;

    public ImVector_ImGuiGroupData GroupStack;

    public ImVector_ImGuiPopupData OpenPopupStack;

    public ImVector_ImGuiPopupData BeginPopupStack;

    public ImVector_ImGuiNavTreeNodeData NavTreeNodeStack;

    public int BeginMenuCount;

    public ImVector_ImGuiViewportPPtr Viewports;

    public float CurrentDpiScale;

    public ImGuiViewportP* CurrentViewport;

    public ImGuiViewportP* MouseViewport;

    public ImGuiViewportP* MouseLastHoveredViewport;

    [NativeTypeName("ImGuiID")]
    public uint PlatformLastFocusedViewportId;

    public ImGuiPlatformMonitor FallbackMonitor;

    public int ViewportCreatedCount;

    public int PlatformWindowsCreatedCount;

    public int ViewportFocusedStampCount;

    public ImGuiWindow* NavWindow;

    [NativeTypeName("ImGuiID")]
    public uint NavId;

    [NativeTypeName("ImGuiID")]
    public uint NavFocusScopeId;

    [NativeTypeName("ImGuiID")]
    public uint NavActivateId;

    [NativeTypeName("ImGuiID")]
    public uint NavActivateDownId;

    [NativeTypeName("ImGuiID")]
    public uint NavActivatePressedId;

    [NativeTypeName("ImGuiActivateFlags")]
    public int NavActivateFlags;

    [NativeTypeName("ImGuiID")]
    public uint NavJustMovedToId;

    [NativeTypeName("ImGuiID")]
    public uint NavJustMovedToFocusScopeId;

    [NativeTypeName("ImGuiKeyChord")]
    public int NavJustMovedToKeyMods;

    [NativeTypeName("ImGuiID")]
    public uint NavNextActivateId;

    [NativeTypeName("ImGuiActivateFlags")]
    public int NavNextActivateFlags;

    public ImGuiInputSource NavInputSource;

    public ImGuiNavLayer NavLayer;

    [NativeTypeName("ImGuiSelectionUserData")]
    public long NavLastValidSelectionUserData;

    [NativeTypeName("bool")]
    public byte NavIdIsAlive;

    [NativeTypeName("bool")]
    public byte NavMousePosDirty;

    [NativeTypeName("bool")]
    public byte NavDisableHighlight;

    [NativeTypeName("bool")]
    public byte NavDisableMouseHover;

    [NativeTypeName("bool")]
    public byte NavAnyRequest;

    [NativeTypeName("bool")]
    public byte NavInitRequest;

    [NativeTypeName("bool")]
    public byte NavInitRequestFromMove;

    public ImGuiNavItemData NavInitResult;

    [NativeTypeName("bool")]
    public byte NavMoveSubmitted;

    [NativeTypeName("bool")]
    public byte NavMoveScoringItems;

    [NativeTypeName("bool")]
    public byte NavMoveForwardToNextFrame;

    [NativeTypeName("ImGuiNavMoveFlags")]
    public int NavMoveFlags;

    [NativeTypeName("ImGuiScrollFlags")]
    public int NavMoveScrollFlags;

    [NativeTypeName("ImGuiKeyChord")]
    public int NavMoveKeyMods;

    [NativeTypeName("ImGuiDir")]
    public int NavMoveDir;

    [NativeTypeName("ImGuiDir")]
    public int NavMoveDirForDebug;

    [NativeTypeName("ImGuiDir")]
    public int NavMoveClipDir;

    public ImRect NavScoringRect;

    public ImRect NavScoringNoClipRect;

    public int NavScoringDebugCount;

    public int NavTabbingDir;

    public int NavTabbingCounter;

    public ImGuiNavItemData NavMoveResultLocal;

    public ImGuiNavItemData NavMoveResultLocalVisible;

    public ImGuiNavItemData NavMoveResultOther;

    public ImGuiNavItemData NavTabbingResultFirst;

    [NativeTypeName("ImGuiKeyChord")]
    public int ConfigNavWindowingKeyNext;

    [NativeTypeName("ImGuiKeyChord")]
    public int ConfigNavWindowingKeyPrev;

    public ImGuiWindow* NavWindowingTarget;

    public ImGuiWindow* NavWindowingTargetAnim;

    public ImGuiWindow* NavWindowingListWindow;

    public float NavWindowingTimer;

    public float NavWindowingHighlightAlpha;

    [NativeTypeName("bool")]
    public byte NavWindowingToggleLayer;

    public ImVec2 NavWindowingAccumDeltaPos;

    public ImVec2 NavWindowingAccumDeltaSize;

    public float DimBgRatio;

    [NativeTypeName("bool")]
    public byte DragDropActive;

    [NativeTypeName("bool")]
    public byte DragDropWithinSource;

    [NativeTypeName("bool")]
    public byte DragDropWithinTarget;

    [NativeTypeName("ImGuiDragDropFlags")]
    public int DragDropSourceFlags;

    public int DragDropSourceFrameCount;

    public int DragDropMouseButton;

    public ImGuiPayload DragDropPayload;

    public ImRect DragDropTargetRect;

    [NativeTypeName("ImGuiID")]
    public uint DragDropTargetId;

    [NativeTypeName("ImGuiDragDropFlags")]
    public int DragDropAcceptFlags;

    public float DragDropAcceptIdCurrRectSurface;

    [NativeTypeName("ImGuiID")]
    public uint DragDropAcceptIdCurr;

    [NativeTypeName("ImGuiID")]
    public uint DragDropAcceptIdPrev;

    public int DragDropAcceptFrameCount;

    [NativeTypeName("ImGuiID")]
    public uint DragDropHoldJustPressedId;

    public ImVector_unsigned_char DragDropPayloadBufHeap;

    [NativeTypeName("unsigned char[16]")]
    public fixed byte DragDropPayloadBufLocal[16];

    public int ClipperTempDataStacked;

    public ImVector_ImGuiListClipperData ClipperTempData;

    public ImGuiTable* CurrentTable;

    public int TablesTempDataStacked;

    public ImVector_ImGuiTableTempData TablesTempData;

    public ImPool_ImGuiTable Tables;

    public ImVector_float TablesLastTimeActive;

    public ImVector_ImDrawChannel DrawChannelsTempMergeBuffer;

    public ImGuiTabBar* CurrentTabBar;

    public ImPool_ImGuiTabBar TabBars;

    public ImVector_ImGuiPtrOrIndex CurrentTabBarStack;

    public ImVector_ImGuiShrinkWidthItem ShrinkWidthBuffer;

    [NativeTypeName("ImGuiID")]
    public uint HoverItemDelayId;

    [NativeTypeName("ImGuiID")]
    public uint HoverItemDelayIdPreviousFrame;

    public float HoverItemDelayTimer;

    public float HoverItemDelayClearTimer;

    [NativeTypeName("ImGuiID")]
    public uint HoverItemUnlockedStationaryId;

    [NativeTypeName("ImGuiID")]
    public uint HoverWindowUnlockedStationaryId;

    [NativeTypeName("ImGuiMouseCursor")]
    public int MouseCursor;

    public float MouseStationaryTimer;

    public ImVec2 MouseLastValidPos;

    public ImGuiInputTextState InputTextState;

    public ImGuiInputTextDeactivatedState InputTextDeactivatedState;

    public ImFont InputTextPasswordFont;

    [NativeTypeName("ImGuiID")]
    public uint TempInputId;

    [NativeTypeName("ImGuiColorEditFlags")]
    public int ColorEditOptions;

    [NativeTypeName("ImGuiID")]
    public uint ColorEditCurrentID;

    [NativeTypeName("ImGuiID")]
    public uint ColorEditSavedID;

    public float ColorEditSavedHue;

    public float ColorEditSavedSat;

    [NativeTypeName("ImU32")]
    public uint ColorEditSavedColor;

    public ImVec4 ColorPickerRef;

    public ImGuiComboPreviewData ComboPreviewData;

    public ImRect WindowResizeBorderExpectedRect;

    [NativeTypeName("bool")]
    public byte WindowResizeRelativeMode;

    public float SliderGrabClickOffset;

    public float SliderCurrentAccum;

    [NativeTypeName("bool")]
    public byte SliderCurrentAccumDirty;

    [NativeTypeName("bool")]
    public byte DragCurrentAccumDirty;

    public float DragCurrentAccum;

    public float DragSpeedDefaultRatio;

    public float ScrollbarClickDeltaToGrabCenter;

    public float DisabledAlphaBackup;

    public short DisabledStackSize;

    public short LockMarkEdited;

    public short TooltipOverrideCount;

    public ImVector_char ClipboardHandlerData;

    public ImVector_ImGuiID MenusIdSubmittedThisFrame;

    public ImGuiTypingSelectState TypingSelectState;

    public ImGuiPlatformImeData PlatformImeData;

    public ImGuiPlatformImeData PlatformImeDataPrev;

    [NativeTypeName("ImGuiID")]
    public uint PlatformImeViewport;

    public ImGuiDockContext DockContext;

    [NativeTypeName("void (*)(ImGuiContext *, ImGuiDockNode *, ImGuiTabBar *)")]
    public delegate* unmanaged[Cdecl]<ImGuiContext*, ImGuiDockNode*, ImGuiTabBar*, void> DockNodeWindowMenuHandler;

    [NativeTypeName("bool")]
    public byte SettingsLoaded;

    public float SettingsDirtyTimer;

    public ImGuiTextBuffer SettingsIniData;

    public ImVector_ImGuiSettingsHandler SettingsHandlers;

    public ImChunkStream_ImGuiWindowSettings SettingsWindows;

    public ImChunkStream_ImGuiTableSettings SettingsTables;

    public ImVector_ImGuiContextHook Hooks;

    [NativeTypeName("ImGuiID")]
    public uint HookIdNext;

    [NativeTypeName("const char *[11]")]
    public _LocalizationTable_e__FixedBuffer LocalizationTable;

    [NativeTypeName("bool")]
    public byte LogEnabled;

    public ImGuiLogType LogType;

    [NativeTypeName("ImFileHandle")]
    public void* LogFile;

    public ImGuiTextBuffer LogBuffer;

    [NativeTypeName("const char *")]
    public sbyte* LogNextPrefix;

    [NativeTypeName("const char *")]
    public sbyte* LogNextSuffix;

    public float LogLinePosY;

    [NativeTypeName("bool")]
    public byte LogLineFirstItem;

    public int LogDepthRef;

    public int LogDepthToExpand;

    public int LogDepthToExpandDefault;

    [NativeTypeName("ImGuiDebugLogFlags")]
    public int DebugLogFlags;

    public ImGuiTextBuffer DebugLogBuf;

    public ImGuiTextIndex DebugLogIndex;

    [NativeTypeName("ImU8")]
    public byte DebugLogClipperAutoDisableFrames;

    [NativeTypeName("ImU8")]
    public byte DebugLocateFrames;

    [NativeTypeName("ImS8")]
    public sbyte DebugBeginReturnValueCullDepth;

    [NativeTypeName("bool")]
    public byte DebugItemPickerActive;

    [NativeTypeName("ImU8")]
    public byte DebugItemPickerMouseButton;

    [NativeTypeName("ImGuiID")]
    public uint DebugItemPickerBreakId;

    public ImGuiMetricsConfig DebugMetricsConfig;

    public ImGuiIDStackTool DebugIDStackTool;

    public ImGuiDebugAllocInfo DebugAllocInfo;

    public ImGuiDockNode* DebugHoveredDockNode;

    [NativeTypeName("float[60]")]
    public fixed float FramerateSecPerFrame[60];

    public int FramerateSecPerFrameIdx;

    public int FramerateSecPerFrameCount;

    public float FramerateSecPerFrameAccum;

    public int WantCaptureMouseNextFrame;

    public int WantCaptureKeyboardNextFrame;

    public int WantTextInputNextFrame;

    public ImVector_char TempBuffer;

    [InlineArray(154)]
    public partial struct _KeysOwnerData_e__FixedBuffer
    {
        public ImGuiKeyOwnerData e0;
    }

    public unsafe partial struct _LocalizationTable_e__FixedBuffer
    {
        public sbyte* e0;
        public sbyte* e1;
        public sbyte* e2;
        public sbyte* e3;
        public sbyte* e4;
        public sbyte* e5;
        public sbyte* e6;
        public sbyte* e7;
        public sbyte* e8;
        public sbyte* e9;
        public sbyte* e10;

        public ref sbyte* this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                fixed (sbyte** pThis = &e0)
                {
                    return ref pThis[index];
                }
            }
        }
    }
}
