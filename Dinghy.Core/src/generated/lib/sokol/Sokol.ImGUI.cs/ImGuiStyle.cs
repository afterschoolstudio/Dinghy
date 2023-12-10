using System.Runtime.CompilerServices;

namespace Dinghy.Internal.Sokol;

public partial struct ImGuiStyle
{
    public float Alpha;

    public float DisabledAlpha;

    public ImVec2 WindowPadding;

    public float WindowRounding;

    public float WindowBorderSize;

    public ImVec2 WindowMinSize;

    public ImVec2 WindowTitleAlign;

    [NativeTypeName("ImGuiDir")]
    public int WindowMenuButtonPosition;

    public float ChildRounding;

    public float ChildBorderSize;

    public float PopupRounding;

    public float PopupBorderSize;

    public ImVec2 FramePadding;

    public float FrameRounding;

    public float FrameBorderSize;

    public ImVec2 ItemSpacing;

    public ImVec2 ItemInnerSpacing;

    public ImVec2 CellPadding;

    public ImVec2 TouchExtraPadding;

    public float IndentSpacing;

    public float ColumnsMinSpacing;

    public float ScrollbarSize;

    public float ScrollbarRounding;

    public float GrabMinSize;

    public float GrabRounding;

    public float LogSliderDeadzone;

    public float TabRounding;

    public float TabBorderSize;

    public float TabMinWidthForCloseButton;

    public float TabBarBorderSize;

    public float TableAngledHeadersAngle;

    [NativeTypeName("ImGuiDir")]
    public int ColorButtonPosition;

    public ImVec2 ButtonTextAlign;

    public ImVec2 SelectableTextAlign;

    public float SeparatorTextBorderSize;

    public ImVec2 SeparatorTextAlign;

    public ImVec2 SeparatorTextPadding;

    public ImVec2 DisplayWindowPadding;

    public ImVec2 DisplaySafeAreaPadding;

    public float DockingSeparatorSize;

    public float MouseCursorScale;

    [NativeTypeName("bool")]
    public byte AntiAliasedLines;

    [NativeTypeName("bool")]
    public byte AntiAliasedLinesUseTex;

    [NativeTypeName("bool")]
    public byte AntiAliasedFill;

    public float CurveTessellationTol;

    public float CircleTessellationMaxError;

    [NativeTypeName("ImVec4[55]")]
    public _Colors_e__FixedBuffer Colors;

    public float HoverStationaryDelay;

    public float HoverDelayShort;

    public float HoverDelayNormal;

    [NativeTypeName("ImGuiHoveredFlags")]
    public int HoverFlagsForTooltipMouse;

    [NativeTypeName("ImGuiHoveredFlags")]
    public int HoverFlagsForTooltipNav;

    [InlineArray(55)]
    public partial struct _Colors_e__FixedBuffer
    {
        public ImVec4 e0;
    }
}
