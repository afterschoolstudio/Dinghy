using System.Runtime.InteropServices;

namespace Dinghy.Internal.Sokol;

public static unsafe partial class ImGUI
{
    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImVec2* ImVec2_ImVec2_Nil();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImVec2_destroy(ImVec2* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImVec2* ImVec2_ImVec2_Float(float _x, float _y);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImVec4* ImVec4_ImVec4_Nil();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImVec4_destroy(ImVec4* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImVec4* ImVec4_ImVec4_Float(float _x, float _y, float _z, float _w);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiContext* igCreateContext(ImFontAtlas* shared_font_atlas);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igDestroyContext(ImGuiContext* ctx);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiContext* igGetCurrentContext();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igSetCurrentContext(ImGuiContext* ctx);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiIO* igGetIO();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiStyle* igGetStyle();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igNewFrame();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igEndFrame();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igRender();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImDrawData* igGetDrawData();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igShowDemoWindow(bool* p_open);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igShowMetricsWindow(bool* p_open);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igShowDebugLogWindow(bool* p_open);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igShowIDStackToolWindow(bool* p_open);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igShowAboutWindow(bool* p_open);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igShowStyleEditor(ImGuiStyle* @ref);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igShowStyleSelector([NativeTypeName("const char *")] sbyte* label);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igShowFontSelector([NativeTypeName("const char *")] sbyte* label);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igShowUserGuide();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* igGetVersion();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igStyleColorsDark(ImGuiStyle* dst);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igStyleColorsLight(ImGuiStyle* dst);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igStyleColorsClassic(ImGuiStyle* dst);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igBegin([NativeTypeName("const char *")] sbyte* name, bool* p_open, [NativeTypeName("ImGuiWindowFlags")] int flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igEnd();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igBeginChild_Str([NativeTypeName("const char *")] sbyte* str_id, [NativeTypeName("const ImVec2")] ImVec2 size, [NativeTypeName("ImGuiChildFlags")] int child_flags, [NativeTypeName("ImGuiWindowFlags")] int window_flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igBeginChild_ID([NativeTypeName("ImGuiID")] uint id, [NativeTypeName("const ImVec2")] ImVec2 size, [NativeTypeName("ImGuiChildFlags")] int child_flags, [NativeTypeName("ImGuiWindowFlags")] int window_flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igEndChild();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igIsWindowAppearing();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igIsWindowCollapsed();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igIsWindowFocused([NativeTypeName("ImGuiFocusedFlags")] int flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igIsWindowHovered([NativeTypeName("ImGuiHoveredFlags")] int flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImDrawList* igGetWindowDrawList();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float igGetWindowDpiScale();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igGetWindowPos(ImVec2* pOut);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igGetWindowSize(ImVec2* pOut);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float igGetWindowWidth();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float igGetWindowHeight();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiViewport* igGetWindowViewport();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igSetNextWindowPos([NativeTypeName("const ImVec2")] ImVec2 pos, [NativeTypeName("ImGuiCond")] int cond, [NativeTypeName("const ImVec2")] ImVec2 pivot);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igSetNextWindowSize([NativeTypeName("const ImVec2")] ImVec2 size, [NativeTypeName("ImGuiCond")] int cond);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igSetNextWindowSizeConstraints([NativeTypeName("const ImVec2")] ImVec2 size_min, [NativeTypeName("const ImVec2")] ImVec2 size_max, [NativeTypeName("ImGuiSizeCallback")] delegate* unmanaged[Cdecl]<ImGuiSizeCallbackData*, void> custom_callback, void* custom_callback_data);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igSetNextWindowContentSize([NativeTypeName("const ImVec2")] ImVec2 size);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igSetNextWindowCollapsed([NativeTypeName("bool")] byte collapsed, [NativeTypeName("ImGuiCond")] int cond);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igSetNextWindowFocus();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igSetNextWindowScroll([NativeTypeName("const ImVec2")] ImVec2 scroll);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igSetNextWindowBgAlpha(float alpha);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igSetNextWindowViewport([NativeTypeName("ImGuiID")] uint viewport_id);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igSetWindowPos_Vec2([NativeTypeName("const ImVec2")] ImVec2 pos, [NativeTypeName("ImGuiCond")] int cond);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igSetWindowSize_Vec2([NativeTypeName("const ImVec2")] ImVec2 size, [NativeTypeName("ImGuiCond")] int cond);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igSetWindowCollapsed_Bool([NativeTypeName("bool")] byte collapsed, [NativeTypeName("ImGuiCond")] int cond);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igSetWindowFocus_Nil();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igSetWindowFontScale(float scale);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igSetWindowPos_Str([NativeTypeName("const char *")] sbyte* name, [NativeTypeName("const ImVec2")] ImVec2 pos, [NativeTypeName("ImGuiCond")] int cond);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igSetWindowSize_Str([NativeTypeName("const char *")] sbyte* name, [NativeTypeName("const ImVec2")] ImVec2 size, [NativeTypeName("ImGuiCond")] int cond);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igSetWindowCollapsed_Str([NativeTypeName("const char *")] sbyte* name, [NativeTypeName("bool")] byte collapsed, [NativeTypeName("ImGuiCond")] int cond);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igSetWindowFocus_Str([NativeTypeName("const char *")] sbyte* name);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igGetContentRegionAvail(ImVec2* pOut);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igGetContentRegionMax(ImVec2* pOut);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igGetWindowContentRegionMin(ImVec2* pOut);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igGetWindowContentRegionMax(ImVec2* pOut);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float igGetScrollX();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float igGetScrollY();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igSetScrollX_Float(float scroll_x);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igSetScrollY_Float(float scroll_y);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float igGetScrollMaxX();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float igGetScrollMaxY();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igSetScrollHereX(float center_x_ratio);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igSetScrollHereY(float center_y_ratio);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igSetScrollFromPosX_Float(float local_x, float center_x_ratio);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igSetScrollFromPosY_Float(float local_y, float center_y_ratio);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igPushFont(ImFont* font);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igPopFont();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igPushStyleColor_U32([NativeTypeName("ImGuiCol")] int idx, [NativeTypeName("ImU32")] uint col);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igPushStyleColor_Vec4([NativeTypeName("ImGuiCol")] int idx, [NativeTypeName("const ImVec4")] ImVec4 col);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igPopStyleColor(int count);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igPushStyleVar_Float([NativeTypeName("ImGuiStyleVar")] int idx, float val);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igPushStyleVar_Vec2([NativeTypeName("ImGuiStyleVar")] int idx, [NativeTypeName("const ImVec2")] ImVec2 val);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igPopStyleVar(int count);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igPushTabStop([NativeTypeName("bool")] byte tab_stop);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igPopTabStop();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igPushButtonRepeat([NativeTypeName("bool")] byte repeat);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igPopButtonRepeat();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igPushItemWidth(float item_width);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igPopItemWidth();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igSetNextItemWidth(float item_width);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float igCalcItemWidth();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igPushTextWrapPos(float wrap_local_pos_x);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igPopTextWrapPos();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImFont* igGetFont();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float igGetFontSize();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igGetFontTexUvWhitePixel(ImVec2* pOut);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("ImU32")]
    public static extern uint igGetColorU32_Col([NativeTypeName("ImGuiCol")] int idx, float alpha_mul);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("ImU32")]
    public static extern uint igGetColorU32_Vec4([NativeTypeName("const ImVec4")] ImVec4 col);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("ImU32")]
    public static extern uint igGetColorU32_U32([NativeTypeName("ImU32")] uint col);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const ImVec4 *")]
    public static extern ImVec4* igGetStyleColorVec4([NativeTypeName("ImGuiCol")] int idx);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igGetCursorScreenPos(ImVec2* pOut);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igSetCursorScreenPos([NativeTypeName("const ImVec2")] ImVec2 pos);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igGetCursorPos(ImVec2* pOut);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float igGetCursorPosX();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float igGetCursorPosY();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igSetCursorPos([NativeTypeName("const ImVec2")] ImVec2 local_pos);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igSetCursorPosX(float local_x);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igSetCursorPosY(float local_y);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igGetCursorStartPos(ImVec2* pOut);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igSeparator();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igSameLine(float offset_from_start_x, float spacing);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igNewLine();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igSpacing();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igDummy([NativeTypeName("const ImVec2")] ImVec2 size);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igIndent(float indent_w);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igUnindent(float indent_w);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igBeginGroup();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igEndGroup();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igAlignTextToFramePadding();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float igGetTextLineHeight();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float igGetTextLineHeightWithSpacing();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float igGetFrameHeight();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float igGetFrameHeightWithSpacing();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igPushID_Str([NativeTypeName("const char *")] sbyte* str_id);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igPushID_StrStr([NativeTypeName("const char *")] sbyte* str_id_begin, [NativeTypeName("const char *")] sbyte* str_id_end);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igPushID_Ptr([NativeTypeName("const void *")] void* ptr_id);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igPushID_Int(int int_id);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igPopID();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("ImGuiID")]
    public static extern uint igGetID_Str([NativeTypeName("const char *")] sbyte* str_id);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("ImGuiID")]
    public static extern uint igGetID_StrStr([NativeTypeName("const char *")] sbyte* str_id_begin, [NativeTypeName("const char *")] sbyte* str_id_end);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("ImGuiID")]
    public static extern uint igGetID_Ptr([NativeTypeName("const void *")] void* ptr_id);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igTextUnformatted([NativeTypeName("const char *")] sbyte* text, [NativeTypeName("const char *")] sbyte* text_end);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igText([NativeTypeName("const char *")] sbyte* fmt, params string[] args);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igTextV([NativeTypeName("const char *")] sbyte* fmt, [NativeTypeName("va_list")] sbyte* args);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igTextColored([NativeTypeName("const ImVec4")] ImVec4 col, [NativeTypeName("const char *")] sbyte* fmt, __arglist);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igTextColoredV([NativeTypeName("const ImVec4")] ImVec4 col, [NativeTypeName("const char *")] sbyte* fmt, [NativeTypeName("va_list")] sbyte* args);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igTextDisabled([NativeTypeName("const char *")] sbyte* fmt, __arglist);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igTextDisabledV([NativeTypeName("const char *")] sbyte* fmt, [NativeTypeName("va_list")] sbyte* args);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igTextWrapped([NativeTypeName("const char *")] sbyte* fmt, __arglist);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igTextWrappedV([NativeTypeName("const char *")] sbyte* fmt, [NativeTypeName("va_list")] sbyte* args);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igLabelText([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("const char *")] sbyte* fmt, __arglist);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igLabelTextV([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("const char *")] sbyte* fmt, [NativeTypeName("va_list")] sbyte* args);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igBulletText([NativeTypeName("const char *")] sbyte* fmt, __arglist);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igBulletTextV([NativeTypeName("const char *")] sbyte* fmt, [NativeTypeName("va_list")] sbyte* args);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igSeparatorText([NativeTypeName("const char *")] sbyte* label);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igButton([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("const ImVec2")] ImVec2 size);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igSmallButton([NativeTypeName("const char *")] sbyte* label);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igInvisibleButton([NativeTypeName("const char *")] sbyte* str_id, [NativeTypeName("const ImVec2")] ImVec2 size, [NativeTypeName("ImGuiButtonFlags")] int flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igArrowButton([NativeTypeName("const char *")] sbyte* str_id, [NativeTypeName("ImGuiDir")] int dir);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igCheckbox([NativeTypeName("const char *")] sbyte* label, bool* v);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igCheckboxFlags_IntPtr([NativeTypeName("const char *")] sbyte* label, int* flags, int flags_value);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igCheckboxFlags_UintPtr([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("unsigned int *")] uint* flags, [NativeTypeName("unsigned int")] uint flags_value);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igRadioButton_Bool([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("bool")] byte active);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igRadioButton_IntPtr([NativeTypeName("const char *")] sbyte* label, int* v, int v_button);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igProgressBar(float fraction, [NativeTypeName("const ImVec2")] ImVec2 size_arg, [NativeTypeName("const char *")] sbyte* overlay);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igBullet();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igImage([NativeTypeName("ImTextureID")] void* user_texture_id, [NativeTypeName("const ImVec2")] ImVec2 size, [NativeTypeName("const ImVec2")] ImVec2 uv0, [NativeTypeName("const ImVec2")] ImVec2 uv1, [NativeTypeName("const ImVec4")] ImVec4 tint_col, [NativeTypeName("const ImVec4")] ImVec4 border_col);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igImageButton([NativeTypeName("const char *")] sbyte* str_id, [NativeTypeName("ImTextureID")] void* user_texture_id, [NativeTypeName("const ImVec2")] ImVec2 image_size, [NativeTypeName("const ImVec2")] ImVec2 uv0, [NativeTypeName("const ImVec2")] ImVec2 uv1, [NativeTypeName("const ImVec4")] ImVec4 bg_col, [NativeTypeName("const ImVec4")] ImVec4 tint_col);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igBeginCombo([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("const char *")] sbyte* preview_value, [NativeTypeName("ImGuiComboFlags")] int flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igEndCombo();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igCombo_Str_arr([NativeTypeName("const char *")] sbyte* label, int* current_item, [NativeTypeName("const char *const[]")] sbyte** items, int items_count, int popup_max_height_in_items);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igCombo_Str([NativeTypeName("const char *")] sbyte* label, int* current_item, [NativeTypeName("const char *")] sbyte* items_separated_by_zeros, int popup_max_height_in_items);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igCombo_FnStrPtr([NativeTypeName("const char *")] sbyte* label, int* current_item, [NativeTypeName("const char *(*)(void *, int)")] delegate* unmanaged[Cdecl]<void*, int, sbyte*> getter, void* user_data, int items_count, int popup_max_height_in_items);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igDragFloat([NativeTypeName("const char *")] sbyte* label, float* v, float v_speed, float v_min, float v_max, [NativeTypeName("const char *")] sbyte* format, [NativeTypeName("ImGuiSliderFlags")] int flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igDragFloat2([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("float[2]")] float* v, float v_speed, float v_min, float v_max, [NativeTypeName("const char *")] sbyte* format, [NativeTypeName("ImGuiSliderFlags")] int flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igDragFloat3([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("float[3]")] float* v, float v_speed, float v_min, float v_max, [NativeTypeName("const char *")] sbyte* format, [NativeTypeName("ImGuiSliderFlags")] int flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igDragFloat4([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("float[4]")] float* v, float v_speed, float v_min, float v_max, [NativeTypeName("const char *")] sbyte* format, [NativeTypeName("ImGuiSliderFlags")] int flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igDragFloatRange2([NativeTypeName("const char *")] sbyte* label, float* v_current_min, float* v_current_max, float v_speed, float v_min, float v_max, [NativeTypeName("const char *")] sbyte* format, [NativeTypeName("const char *")] sbyte* format_max, [NativeTypeName("ImGuiSliderFlags")] int flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igDragInt([NativeTypeName("const char *")] sbyte* label, int* v, float v_speed, int v_min, int v_max, [NativeTypeName("const char *")] sbyte* format, [NativeTypeName("ImGuiSliderFlags")] int flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igDragInt2([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("int[2]")] int* v, float v_speed, int v_min, int v_max, [NativeTypeName("const char *")] sbyte* format, [NativeTypeName("ImGuiSliderFlags")] int flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igDragInt3([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("int[3]")] int* v, float v_speed, int v_min, int v_max, [NativeTypeName("const char *")] sbyte* format, [NativeTypeName("ImGuiSliderFlags")] int flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igDragInt4([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("int[4]")] int* v, float v_speed, int v_min, int v_max, [NativeTypeName("const char *")] sbyte* format, [NativeTypeName("ImGuiSliderFlags")] int flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igDragIntRange2([NativeTypeName("const char *")] sbyte* label, int* v_current_min, int* v_current_max, float v_speed, int v_min, int v_max, [NativeTypeName("const char *")] sbyte* format, [NativeTypeName("const char *")] sbyte* format_max, [NativeTypeName("ImGuiSliderFlags")] int flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igDragScalar([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("ImGuiDataType")] int data_type, void* p_data, float v_speed, [NativeTypeName("const void *")] void* p_min, [NativeTypeName("const void *")] void* p_max, [NativeTypeName("const char *")] sbyte* format, [NativeTypeName("ImGuiSliderFlags")] int flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igDragScalarN([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("ImGuiDataType")] int data_type, void* p_data, int components, float v_speed, [NativeTypeName("const void *")] void* p_min, [NativeTypeName("const void *")] void* p_max, [NativeTypeName("const char *")] sbyte* format, [NativeTypeName("ImGuiSliderFlags")] int flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igSliderFloat([NativeTypeName("const char *")] sbyte* label, float* v, float v_min, float v_max, [NativeTypeName("const char *")] sbyte* format, [NativeTypeName("ImGuiSliderFlags")] int flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igSliderFloat2([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("float[2]")] float* v, float v_min, float v_max, [NativeTypeName("const char *")] sbyte* format, [NativeTypeName("ImGuiSliderFlags")] int flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igSliderFloat3([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("float[3]")] float* v, float v_min, float v_max, [NativeTypeName("const char *")] sbyte* format, [NativeTypeName("ImGuiSliderFlags")] int flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igSliderFloat4([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("float[4]")] float* v, float v_min, float v_max, [NativeTypeName("const char *")] sbyte* format, [NativeTypeName("ImGuiSliderFlags")] int flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igSliderAngle([NativeTypeName("const char *")] sbyte* label, float* v_rad, float v_degrees_min, float v_degrees_max, [NativeTypeName("const char *")] sbyte* format, [NativeTypeName("ImGuiSliderFlags")] int flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igSliderInt([NativeTypeName("const char *")] sbyte* label, int* v, int v_min, int v_max, [NativeTypeName("const char *")] sbyte* format, [NativeTypeName("ImGuiSliderFlags")] int flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igSliderInt2([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("int[2]")] int* v, int v_min, int v_max, [NativeTypeName("const char *")] sbyte* format, [NativeTypeName("ImGuiSliderFlags")] int flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igSliderInt3([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("int[3]")] int* v, int v_min, int v_max, [NativeTypeName("const char *")] sbyte* format, [NativeTypeName("ImGuiSliderFlags")] int flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igSliderInt4([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("int[4]")] int* v, int v_min, int v_max, [NativeTypeName("const char *")] sbyte* format, [NativeTypeName("ImGuiSliderFlags")] int flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igSliderScalar([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("ImGuiDataType")] int data_type, void* p_data, [NativeTypeName("const void *")] void* p_min, [NativeTypeName("const void *")] void* p_max, [NativeTypeName("const char *")] sbyte* format, [NativeTypeName("ImGuiSliderFlags")] int flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igSliderScalarN([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("ImGuiDataType")] int data_type, void* p_data, int components, [NativeTypeName("const void *")] void* p_min, [NativeTypeName("const void *")] void* p_max, [NativeTypeName("const char *")] sbyte* format, [NativeTypeName("ImGuiSliderFlags")] int flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igVSliderFloat([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("const ImVec2")] ImVec2 size, float* v, float v_min, float v_max, [NativeTypeName("const char *")] sbyte* format, [NativeTypeName("ImGuiSliderFlags")] int flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igVSliderInt([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("const ImVec2")] ImVec2 size, int* v, int v_min, int v_max, [NativeTypeName("const char *")] sbyte* format, [NativeTypeName("ImGuiSliderFlags")] int flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igVSliderScalar([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("const ImVec2")] ImVec2 size, [NativeTypeName("ImGuiDataType")] int data_type, void* p_data, [NativeTypeName("const void *")] void* p_min, [NativeTypeName("const void *")] void* p_max, [NativeTypeName("const char *")] sbyte* format, [NativeTypeName("ImGuiSliderFlags")] int flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igInputText([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("char *")] sbyte* buf, [NativeTypeName("size_t")] nuint buf_size, [NativeTypeName("ImGuiInputTextFlags")] int flags, [NativeTypeName("ImGuiInputTextCallback")] delegate* unmanaged[Cdecl]<ImGuiInputTextCallbackData*, int> callback, void* user_data);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igInputTextMultiline([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("char *")] sbyte* buf, [NativeTypeName("size_t")] nuint buf_size, [NativeTypeName("const ImVec2")] ImVec2 size, [NativeTypeName("ImGuiInputTextFlags")] int flags, [NativeTypeName("ImGuiInputTextCallback")] delegate* unmanaged[Cdecl]<ImGuiInputTextCallbackData*, int> callback, void* user_data);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igInputTextWithHint([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("const char *")] sbyte* hint, [NativeTypeName("char *")] sbyte* buf, [NativeTypeName("size_t")] nuint buf_size, [NativeTypeName("ImGuiInputTextFlags")] int flags, [NativeTypeName("ImGuiInputTextCallback")] delegate* unmanaged[Cdecl]<ImGuiInputTextCallbackData*, int> callback, void* user_data);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igInputFloat([NativeTypeName("const char *")] sbyte* label, float* v, float step, float step_fast, [NativeTypeName("const char *")] sbyte* format, [NativeTypeName("ImGuiInputTextFlags")] int flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igInputFloat2([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("float[2]")] float* v, [NativeTypeName("const char *")] sbyte* format, [NativeTypeName("ImGuiInputTextFlags")] int flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igInputFloat3([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("float[3]")] float* v, [NativeTypeName("const char *")] sbyte* format, [NativeTypeName("ImGuiInputTextFlags")] int flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igInputFloat4([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("float[4]")] float* v, [NativeTypeName("const char *")] sbyte* format, [NativeTypeName("ImGuiInputTextFlags")] int flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igInputInt([NativeTypeName("const char *")] sbyte* label, int* v, int step, int step_fast, [NativeTypeName("ImGuiInputTextFlags")] int flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igInputInt2([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("int[2]")] int* v, [NativeTypeName("ImGuiInputTextFlags")] int flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igInputInt3([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("int[3]")] int* v, [NativeTypeName("ImGuiInputTextFlags")] int flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igInputInt4([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("int[4]")] int* v, [NativeTypeName("ImGuiInputTextFlags")] int flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igInputDouble([NativeTypeName("const char *")] sbyte* label, double* v, double step, double step_fast, [NativeTypeName("const char *")] sbyte* format, [NativeTypeName("ImGuiInputTextFlags")] int flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igInputScalar([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("ImGuiDataType")] int data_type, void* p_data, [NativeTypeName("const void *")] void* p_step, [NativeTypeName("const void *")] void* p_step_fast, [NativeTypeName("const char *")] sbyte* format, [NativeTypeName("ImGuiInputTextFlags")] int flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igInputScalarN([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("ImGuiDataType")] int data_type, void* p_data, int components, [NativeTypeName("const void *")] void* p_step, [NativeTypeName("const void *")] void* p_step_fast, [NativeTypeName("const char *")] sbyte* format, [NativeTypeName("ImGuiInputTextFlags")] int flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igColorEdit3([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("float[3]")] float* col, [NativeTypeName("ImGuiColorEditFlags")] int flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igColorEdit4([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("float[4]")] float* col, [NativeTypeName("ImGuiColorEditFlags")] int flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igColorPicker3([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("float[3]")] float* col, [NativeTypeName("ImGuiColorEditFlags")] int flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igColorPicker4([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("float[4]")] float* col, [NativeTypeName("ImGuiColorEditFlags")] int flags, [NativeTypeName("const float *")] float* ref_col);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igColorButton([NativeTypeName("const char *")] sbyte* desc_id, [NativeTypeName("const ImVec4")] ImVec4 col, [NativeTypeName("ImGuiColorEditFlags")] int flags, [NativeTypeName("const ImVec2")] ImVec2 size);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igSetColorEditOptions([NativeTypeName("ImGuiColorEditFlags")] int flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igTreeNode_Str([NativeTypeName("const char *")] sbyte* label);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igTreeNode_StrStr([NativeTypeName("const char *")] sbyte* str_id, [NativeTypeName("const char *")] sbyte* fmt, __arglist);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igTreeNode_Ptr([NativeTypeName("const void *")] void* ptr_id, [NativeTypeName("const char *")] sbyte* fmt, __arglist);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igTreeNodeV_Str([NativeTypeName("const char *")] sbyte* str_id, [NativeTypeName("const char *")] sbyte* fmt, [NativeTypeName("va_list")] sbyte* args);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igTreeNodeV_Ptr([NativeTypeName("const void *")] void* ptr_id, [NativeTypeName("const char *")] sbyte* fmt, [NativeTypeName("va_list")] sbyte* args);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igTreeNodeEx_Str([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("ImGuiTreeNodeFlags")] int flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igTreeNodeEx_StrStr([NativeTypeName("const char *")] sbyte* str_id, [NativeTypeName("ImGuiTreeNodeFlags")] int flags, [NativeTypeName("const char *")] sbyte* fmt, __arglist);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igTreeNodeEx_Ptr([NativeTypeName("const void *")] void* ptr_id, [NativeTypeName("ImGuiTreeNodeFlags")] int flags, [NativeTypeName("const char *")] sbyte* fmt, __arglist);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igTreeNodeExV_Str([NativeTypeName("const char *")] sbyte* str_id, [NativeTypeName("ImGuiTreeNodeFlags")] int flags, [NativeTypeName("const char *")] sbyte* fmt, [NativeTypeName("va_list")] sbyte* args);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igTreeNodeExV_Ptr([NativeTypeName("const void *")] void* ptr_id, [NativeTypeName("ImGuiTreeNodeFlags")] int flags, [NativeTypeName("const char *")] sbyte* fmt, [NativeTypeName("va_list")] sbyte* args);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igTreePush_Str([NativeTypeName("const char *")] sbyte* str_id);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igTreePush_Ptr([NativeTypeName("const void *")] void* ptr_id);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igTreePop();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float igGetTreeNodeToLabelSpacing();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igCollapsingHeader_TreeNodeFlags([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("ImGuiTreeNodeFlags")] int flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igCollapsingHeader_BoolPtr([NativeTypeName("const char *")] sbyte* label, bool* p_visible, [NativeTypeName("ImGuiTreeNodeFlags")] int flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igSetNextItemOpen([NativeTypeName("bool")] byte is_open, [NativeTypeName("ImGuiCond")] int cond);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igSelectable_Bool([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("bool")] byte selected, [NativeTypeName("ImGuiSelectableFlags")] int flags, [NativeTypeName("const ImVec2")] ImVec2 size);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igSelectable_BoolPtr([NativeTypeName("const char *")] sbyte* label, bool* p_selected, [NativeTypeName("ImGuiSelectableFlags")] int flags, [NativeTypeName("const ImVec2")] ImVec2 size);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igBeginListBox([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("const ImVec2")] ImVec2 size);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igEndListBox();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igListBox_Str_arr([NativeTypeName("const char *")] sbyte* label, int* current_item, [NativeTypeName("const char *const[]")] sbyte** items, int items_count, int height_in_items);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igListBox_FnStrPtr([NativeTypeName("const char *")] sbyte* label, int* current_item, [NativeTypeName("const char *(*)(void *, int)")] delegate* unmanaged[Cdecl]<void*, int, sbyte*> getter, void* user_data, int items_count, int height_in_items);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igPlotLines_FloatPtr([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("const float *")] float* values, int values_count, int values_offset, [NativeTypeName("const char *")] sbyte* overlay_text, float scale_min, float scale_max, ImVec2 graph_size, int stride);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igPlotLines_FnFloatPtr([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("float (*)(void *, int)")] delegate* unmanaged[Cdecl]<void*, int, float> values_getter, void* data, int values_count, int values_offset, [NativeTypeName("const char *")] sbyte* overlay_text, float scale_min, float scale_max, ImVec2 graph_size);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igPlotHistogram_FloatPtr([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("const float *")] float* values, int values_count, int values_offset, [NativeTypeName("const char *")] sbyte* overlay_text, float scale_min, float scale_max, ImVec2 graph_size, int stride);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igPlotHistogram_FnFloatPtr([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("float (*)(void *, int)")] delegate* unmanaged[Cdecl]<void*, int, float> values_getter, void* data, int values_count, int values_offset, [NativeTypeName("const char *")] sbyte* overlay_text, float scale_min, float scale_max, ImVec2 graph_size);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igValue_Bool([NativeTypeName("const char *")] sbyte* prefix, [NativeTypeName("bool")] byte b);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igValue_Int([NativeTypeName("const char *")] sbyte* prefix, int v);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igValue_Uint([NativeTypeName("const char *")] sbyte* prefix, [NativeTypeName("unsigned int")] uint v);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igValue_Float([NativeTypeName("const char *")] sbyte* prefix, float v, [NativeTypeName("const char *")] sbyte* float_format);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igBeginMenuBar();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igEndMenuBar();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igBeginMainMenuBar();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igEndMainMenuBar();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igBeginMenu([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("bool")] byte enabled);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igEndMenu();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igMenuItem_Bool([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("const char *")] sbyte* shortcut, [NativeTypeName("bool")] byte selected, [NativeTypeName("bool")] byte enabled);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igMenuItem_BoolPtr([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("const char *")] sbyte* shortcut, bool* p_selected, [NativeTypeName("bool")] byte enabled);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igBeginTooltip();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igEndTooltip();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igSetTooltip([NativeTypeName("const char *")] sbyte* fmt, __arglist);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igSetTooltipV([NativeTypeName("const char *")] sbyte* fmt, [NativeTypeName("va_list")] sbyte* args);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igBeginItemTooltip();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igSetItemTooltip([NativeTypeName("const char *")] sbyte* fmt, __arglist);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igSetItemTooltipV([NativeTypeName("const char *")] sbyte* fmt, [NativeTypeName("va_list")] sbyte* args);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igBeginPopup([NativeTypeName("const char *")] sbyte* str_id, [NativeTypeName("ImGuiWindowFlags")] int flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igBeginPopupModal([NativeTypeName("const char *")] sbyte* name, bool* p_open, [NativeTypeName("ImGuiWindowFlags")] int flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igEndPopup();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igOpenPopup_Str([NativeTypeName("const char *")] sbyte* str_id, [NativeTypeName("ImGuiPopupFlags")] int popup_flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igOpenPopup_ID([NativeTypeName("ImGuiID")] uint id, [NativeTypeName("ImGuiPopupFlags")] int popup_flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igOpenPopupOnItemClick([NativeTypeName("const char *")] sbyte* str_id, [NativeTypeName("ImGuiPopupFlags")] int popup_flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igCloseCurrentPopup();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igBeginPopupContextItem([NativeTypeName("const char *")] sbyte* str_id, [NativeTypeName("ImGuiPopupFlags")] int popup_flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igBeginPopupContextWindow([NativeTypeName("const char *")] sbyte* str_id, [NativeTypeName("ImGuiPopupFlags")] int popup_flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igBeginPopupContextVoid([NativeTypeName("const char *")] sbyte* str_id, [NativeTypeName("ImGuiPopupFlags")] int popup_flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igIsPopupOpen_Str([NativeTypeName("const char *")] sbyte* str_id, [NativeTypeName("ImGuiPopupFlags")] int flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igBeginTable([NativeTypeName("const char *")] sbyte* str_id, int column, [NativeTypeName("ImGuiTableFlags")] int flags, [NativeTypeName("const ImVec2")] ImVec2 outer_size, float inner_width);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igEndTable();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igTableNextRow([NativeTypeName("ImGuiTableRowFlags")] int row_flags, float min_row_height);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igTableNextColumn();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igTableSetColumnIndex(int column_n);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igTableSetupColumn([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("ImGuiTableColumnFlags")] int flags, float init_width_or_weight, [NativeTypeName("ImGuiID")] uint user_id);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igTableSetupScrollFreeze(int cols, int rows);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igTableHeader([NativeTypeName("const char *")] sbyte* label);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igTableHeadersRow();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igTableAngledHeadersRow();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiTableSortSpecs* igTableGetSortSpecs();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int igTableGetColumnCount();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int igTableGetColumnIndex();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int igTableGetRowIndex();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* igTableGetColumnName_Int(int column_n);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("ImGuiTableColumnFlags")]
    public static extern int igTableGetColumnFlags(int column_n);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igTableSetColumnEnabled(int column_n, [NativeTypeName("bool")] byte v);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igTableSetBgColor([NativeTypeName("ImGuiTableBgTarget")] int target, [NativeTypeName("ImU32")] uint color, int column_n);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igColumns(int count, [NativeTypeName("const char *")] sbyte* id, [NativeTypeName("bool")] byte border);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igNextColumn();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int igGetColumnIndex();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float igGetColumnWidth(int column_index);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igSetColumnWidth(int column_index, float width);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float igGetColumnOffset(int column_index);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igSetColumnOffset(int column_index, float offset_x);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int igGetColumnsCount();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igBeginTabBar([NativeTypeName("const char *")] sbyte* str_id, [NativeTypeName("ImGuiTabBarFlags")] int flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igEndTabBar();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igBeginTabItem([NativeTypeName("const char *")] sbyte* label, bool* p_open, [NativeTypeName("ImGuiTabItemFlags")] int flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igEndTabItem();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igTabItemButton([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("ImGuiTabItemFlags")] int flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igSetTabItemClosed([NativeTypeName("const char *")] sbyte* tab_or_docked_window_label);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("ImGuiID")]
    public static extern uint igDockSpace([NativeTypeName("ImGuiID")] uint id, [NativeTypeName("const ImVec2")] ImVec2 size, [NativeTypeName("ImGuiDockNodeFlags")] int flags, [NativeTypeName("const ImGuiWindowClass *")] ImGuiWindowClass* window_class);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("ImGuiID")]
    public static extern uint igDockSpaceOverViewport([NativeTypeName("const ImGuiViewport *")] ImGuiViewport* viewport, [NativeTypeName("ImGuiDockNodeFlags")] int flags, [NativeTypeName("const ImGuiWindowClass *")] ImGuiWindowClass* window_class);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igSetNextWindowDockID([NativeTypeName("ImGuiID")] uint dock_id, [NativeTypeName("ImGuiCond")] int cond);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igSetNextWindowClass([NativeTypeName("const ImGuiWindowClass *")] ImGuiWindowClass* window_class);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("ImGuiID")]
    public static extern uint igGetWindowDockID();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igIsWindowDocked();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igLogToTTY(int auto_open_depth);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igLogToFile(int auto_open_depth, [NativeTypeName("const char *")] sbyte* filename);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igLogToClipboard(int auto_open_depth);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igLogFinish();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igLogButtons();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igLogTextV([NativeTypeName("const char *")] sbyte* fmt, [NativeTypeName("va_list")] sbyte* args);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igBeginDragDropSource([NativeTypeName("ImGuiDragDropFlags")] int flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igSetDragDropPayload([NativeTypeName("const char *")] sbyte* type, [NativeTypeName("const void *")] void* data, [NativeTypeName("size_t")] nuint sz, [NativeTypeName("ImGuiCond")] int cond);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igEndDragDropSource();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igBeginDragDropTarget();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const ImGuiPayload *")]
    public static extern ImGuiPayload* igAcceptDragDropPayload([NativeTypeName("const char *")] sbyte* type, [NativeTypeName("ImGuiDragDropFlags")] int flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igEndDragDropTarget();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const ImGuiPayload *")]
    public static extern ImGuiPayload* igGetDragDropPayload();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igBeginDisabled([NativeTypeName("bool")] byte disabled);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igEndDisabled();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igPushClipRect([NativeTypeName("const ImVec2")] ImVec2 clip_rect_min, [NativeTypeName("const ImVec2")] ImVec2 clip_rect_max, [NativeTypeName("bool")] byte intersect_with_current_clip_rect);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igPopClipRect();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igSetItemDefaultFocus();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igSetKeyboardFocusHere(int offset);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igSetNextItemAllowOverlap();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igIsItemHovered([NativeTypeName("ImGuiHoveredFlags")] int flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igIsItemActive();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igIsItemFocused();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igIsItemClicked([NativeTypeName("ImGuiMouseButton")] int mouse_button);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igIsItemVisible();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igIsItemEdited();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igIsItemActivated();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igIsItemDeactivated();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igIsItemDeactivatedAfterEdit();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igIsItemToggledOpen();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igIsAnyItemHovered();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igIsAnyItemActive();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igIsAnyItemFocused();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("ImGuiID")]
    public static extern uint igGetItemID();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igGetItemRectMin(ImVec2* pOut);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igGetItemRectMax(ImVec2* pOut);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igGetItemRectSize(ImVec2* pOut);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiViewport* igGetMainViewport();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImDrawList* igGetBackgroundDrawList_Nil();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImDrawList* igGetForegroundDrawList_Nil();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImDrawList* igGetBackgroundDrawList_ViewportPtr(ImGuiViewport* viewport);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImDrawList* igGetForegroundDrawList_ViewportPtr(ImGuiViewport* viewport);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igIsRectVisible_Nil([NativeTypeName("const ImVec2")] ImVec2 size);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igIsRectVisible_Vec2([NativeTypeName("const ImVec2")] ImVec2 rect_min, [NativeTypeName("const ImVec2")] ImVec2 rect_max);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern double igGetTime();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int igGetFrameCount();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImDrawListSharedData* igGetDrawListSharedData();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* igGetStyleColorName([NativeTypeName("ImGuiCol")] int idx);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igSetStateStorage(ImGuiStorage* storage);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiStorage* igGetStateStorage();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igCalcTextSize(ImVec2* pOut, [NativeTypeName("const char *")] sbyte* text, [NativeTypeName("const char *")] sbyte* text_end, [NativeTypeName("bool")] byte hide_text_after_double_hash, float wrap_width);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igColorConvertU32ToFloat4(ImVec4* pOut, [NativeTypeName("ImU32")] uint @in);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("ImU32")]
    public static extern uint igColorConvertFloat4ToU32([NativeTypeName("const ImVec4")] ImVec4 @in);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igColorConvertRGBtoHSV(float r, float g, float b, float* out_h, float* out_s, float* out_v);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igColorConvertHSVtoRGB(float h, float s, float v, float* out_r, float* out_g, float* out_b);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igIsKeyDown_Nil(ImGuiKey key);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igIsKeyPressed_Bool(ImGuiKey key, [NativeTypeName("bool")] byte repeat);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igIsKeyReleased_Nil(ImGuiKey key);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igIsKeyChordPressed_Nil([NativeTypeName("ImGuiKeyChord")] int key_chord);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int igGetKeyPressedAmount(ImGuiKey key, float repeat_delay, float rate);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* igGetKeyName(ImGuiKey key);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igSetNextFrameWantCaptureKeyboard([NativeTypeName("bool")] byte want_capture_keyboard);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igIsMouseDown_Nil([NativeTypeName("ImGuiMouseButton")] int button);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igIsMouseClicked_Bool([NativeTypeName("ImGuiMouseButton")] int button, [NativeTypeName("bool")] byte repeat);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igIsMouseReleased_Nil([NativeTypeName("ImGuiMouseButton")] int button);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igIsMouseDoubleClicked_Nil([NativeTypeName("ImGuiMouseButton")] int button);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int igGetMouseClickedCount([NativeTypeName("ImGuiMouseButton")] int button);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igIsMouseHoveringRect([NativeTypeName("const ImVec2")] ImVec2 r_min, [NativeTypeName("const ImVec2")] ImVec2 r_max, [NativeTypeName("bool")] byte clip);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igIsMousePosValid([NativeTypeName("const ImVec2 *")] ImVec2* mouse_pos);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igIsAnyMouseDown();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igGetMousePos(ImVec2* pOut);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igGetMousePosOnOpeningCurrentPopup(ImVec2* pOut);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igIsMouseDragging([NativeTypeName("ImGuiMouseButton")] int button, float lock_threshold);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igGetMouseDragDelta(ImVec2* pOut, [NativeTypeName("ImGuiMouseButton")] int button, float lock_threshold);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igResetMouseDragDelta([NativeTypeName("ImGuiMouseButton")] int button);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("ImGuiMouseCursor")]
    public static extern int igGetMouseCursor();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igSetMouseCursor([NativeTypeName("ImGuiMouseCursor")] int cursor_type);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igSetNextFrameWantCaptureMouse([NativeTypeName("bool")] byte want_capture_mouse);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* igGetClipboardText();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igSetClipboardText([NativeTypeName("const char *")] sbyte* text);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igLoadIniSettingsFromDisk([NativeTypeName("const char *")] sbyte* ini_filename);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igLoadIniSettingsFromMemory([NativeTypeName("const char *")] sbyte* ini_data, [NativeTypeName("size_t")] nuint ini_size);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igSaveIniSettingsToDisk([NativeTypeName("const char *")] sbyte* ini_filename);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* igSaveIniSettingsToMemory([NativeTypeName("size_t *")] nuint* out_ini_size);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igDebugTextEncoding([NativeTypeName("const char *")] sbyte* text);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igDebugCheckVersionAndDataLayout([NativeTypeName("const char *")] sbyte* version_str, [NativeTypeName("size_t")] nuint sz_io, [NativeTypeName("size_t")] nuint sz_style, [NativeTypeName("size_t")] nuint sz_vec2, [NativeTypeName("size_t")] nuint sz_vec4, [NativeTypeName("size_t")] nuint sz_drawvert, [NativeTypeName("size_t")] nuint sz_drawidx);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igSetAllocatorFunctions([NativeTypeName("ImGuiMemAllocFunc")] delegate* unmanaged[Cdecl]<nuint, void*, void*> alloc_func, [NativeTypeName("ImGuiMemFreeFunc")] delegate* unmanaged[Cdecl]<void*, void*, void> free_func, void* user_data);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igGetAllocatorFunctions([NativeTypeName("ImGuiMemAllocFunc *")] delegate* unmanaged[Cdecl]<nuint, void*, void*>* p_alloc_func, [NativeTypeName("ImGuiMemFreeFunc *")] delegate* unmanaged[Cdecl]<void*, void*, void>* p_free_func, void** p_user_data);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void* igMemAlloc([NativeTypeName("size_t")] nuint size);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igMemFree(void* ptr);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiPlatformIO* igGetPlatformIO();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igUpdatePlatformWindows();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igRenderPlatformWindowsDefault(void* platform_render_arg, void* renderer_render_arg);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igDestroyPlatformWindows();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiViewport* igFindViewportByID([NativeTypeName("ImGuiID")] uint id);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiViewport* igFindViewportByPlatformHandle(void* platform_handle);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiStyle* ImGuiStyle_ImGuiStyle();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiStyle_destroy(ImGuiStyle* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiStyle_ScaleAllSizes(ImGuiStyle* self, float scale_factor);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiIO_AddKeyEvent(ImGuiIO* self, ImGuiKey key, [NativeTypeName("bool")] byte down);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiIO_AddKeyAnalogEvent(ImGuiIO* self, ImGuiKey key, [NativeTypeName("bool")] byte down, float v);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiIO_AddMousePosEvent(ImGuiIO* self, float x, float y);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiIO_AddMouseButtonEvent(ImGuiIO* self, int button, [NativeTypeName("bool")] byte down);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiIO_AddMouseWheelEvent(ImGuiIO* self, float wheel_x, float wheel_y);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiIO_AddMouseSourceEvent(ImGuiIO* self, ImGuiMouseSource source);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiIO_AddMouseViewportEvent(ImGuiIO* self, [NativeTypeName("ImGuiID")] uint id);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiIO_AddFocusEvent(ImGuiIO* self, [NativeTypeName("bool")] byte focused);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiIO_AddInputCharacter(ImGuiIO* self, [NativeTypeName("unsigned int")] uint c);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiIO_AddInputCharacterUTF16(ImGuiIO* self, [NativeTypeName("ImWchar16")] ushort c);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiIO_AddInputCharactersUTF8(ImGuiIO* self, [NativeTypeName("const char *")] sbyte* str);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiIO_SetKeyEventNativeData(ImGuiIO* self, ImGuiKey key, int native_keycode, int native_scancode, int native_legacy_index);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiIO_SetAppAcceptingEvents(ImGuiIO* self, [NativeTypeName("bool")] byte accepting_events);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiIO_ClearEventsQueue(ImGuiIO* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiIO_ClearInputKeys(ImGuiIO* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiIO* ImGuiIO_ImGuiIO();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiIO_destroy(ImGuiIO* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiInputTextCallbackData* ImGuiInputTextCallbackData_ImGuiInputTextCallbackData();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiInputTextCallbackData_destroy(ImGuiInputTextCallbackData* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiInputTextCallbackData_DeleteChars(ImGuiInputTextCallbackData* self, int pos, int bytes_count);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiInputTextCallbackData_InsertChars(ImGuiInputTextCallbackData* self, int pos, [NativeTypeName("const char *")] sbyte* text, [NativeTypeName("const char *")] sbyte* text_end);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiInputTextCallbackData_SelectAll(ImGuiInputTextCallbackData* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiInputTextCallbackData_ClearSelection(ImGuiInputTextCallbackData* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte ImGuiInputTextCallbackData_HasSelection(ImGuiInputTextCallbackData* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiWindowClass* ImGuiWindowClass_ImGuiWindowClass();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiWindowClass_destroy(ImGuiWindowClass* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiPayload* ImGuiPayload_ImGuiPayload();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiPayload_destroy(ImGuiPayload* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiPayload_Clear(ImGuiPayload* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte ImGuiPayload_IsDataType(ImGuiPayload* self, [NativeTypeName("const char *")] sbyte* type);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte ImGuiPayload_IsPreview(ImGuiPayload* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte ImGuiPayload_IsDelivery(ImGuiPayload* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiTableColumnSortSpecs* ImGuiTableColumnSortSpecs_ImGuiTableColumnSortSpecs();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiTableColumnSortSpecs_destroy(ImGuiTableColumnSortSpecs* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiTableSortSpecs* ImGuiTableSortSpecs_ImGuiTableSortSpecs();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiTableSortSpecs_destroy(ImGuiTableSortSpecs* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiOnceUponAFrame* ImGuiOnceUponAFrame_ImGuiOnceUponAFrame();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiOnceUponAFrame_destroy(ImGuiOnceUponAFrame* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiTextFilter* ImGuiTextFilter_ImGuiTextFilter([NativeTypeName("const char *")] sbyte* default_filter);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiTextFilter_destroy(ImGuiTextFilter* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte ImGuiTextFilter_Draw(ImGuiTextFilter* self, [NativeTypeName("const char *")] sbyte* label, float width);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte ImGuiTextFilter_PassFilter(ImGuiTextFilter* self, [NativeTypeName("const char *")] sbyte* text, [NativeTypeName("const char *")] sbyte* text_end);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiTextFilter_Build(ImGuiTextFilter* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiTextFilter_Clear(ImGuiTextFilter* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte ImGuiTextFilter_IsActive(ImGuiTextFilter* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiTextRange* ImGuiTextRange_ImGuiTextRange_Nil();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiTextRange_destroy(ImGuiTextRange* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiTextRange* ImGuiTextRange_ImGuiTextRange_Str([NativeTypeName("const char *")] sbyte* _b, [NativeTypeName("const char *")] sbyte* _e);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte ImGuiTextRange_empty(ImGuiTextRange* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiTextRange_split(ImGuiTextRange* self, [NativeTypeName("char")] sbyte separator, ImVector_ImGuiTextRange* @out);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiTextBuffer* ImGuiTextBuffer_ImGuiTextBuffer();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiTextBuffer_destroy(ImGuiTextBuffer* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* ImGuiTextBuffer_begin(ImGuiTextBuffer* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* ImGuiTextBuffer_end(ImGuiTextBuffer* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int ImGuiTextBuffer_size(ImGuiTextBuffer* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte ImGuiTextBuffer_empty(ImGuiTextBuffer* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiTextBuffer_clear(ImGuiTextBuffer* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiTextBuffer_reserve(ImGuiTextBuffer* self, int capacity);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* ImGuiTextBuffer_c_str(ImGuiTextBuffer* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiTextBuffer_append(ImGuiTextBuffer* self, [NativeTypeName("const char *")] sbyte* str, [NativeTypeName("const char *")] sbyte* str_end);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiTextBuffer_appendfv(ImGuiTextBuffer* self, [NativeTypeName("const char *")] sbyte* fmt, [NativeTypeName("va_list")] sbyte* args);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiStoragePair* ImGuiStoragePair_ImGuiStoragePair_Int([NativeTypeName("ImGuiID")] uint _key, int _val);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiStoragePair_destroy(ImGuiStoragePair* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiStoragePair* ImGuiStoragePair_ImGuiStoragePair_Float([NativeTypeName("ImGuiID")] uint _key, float _val);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiStoragePair* ImGuiStoragePair_ImGuiStoragePair_Ptr([NativeTypeName("ImGuiID")] uint _key, void* _val);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiStorage_Clear(ImGuiStorage* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int ImGuiStorage_GetInt(ImGuiStorage* self, [NativeTypeName("ImGuiID")] uint key, int default_val);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiStorage_SetInt(ImGuiStorage* self, [NativeTypeName("ImGuiID")] uint key, int val);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte ImGuiStorage_GetBool(ImGuiStorage* self, [NativeTypeName("ImGuiID")] uint key, [NativeTypeName("bool")] byte default_val);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiStorage_SetBool(ImGuiStorage* self, [NativeTypeName("ImGuiID")] uint key, [NativeTypeName("bool")] byte val);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float ImGuiStorage_GetFloat(ImGuiStorage* self, [NativeTypeName("ImGuiID")] uint key, float default_val);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiStorage_SetFloat(ImGuiStorage* self, [NativeTypeName("ImGuiID")] uint key, float val);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void* ImGuiStorage_GetVoidPtr(ImGuiStorage* self, [NativeTypeName("ImGuiID")] uint key);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiStorage_SetVoidPtr(ImGuiStorage* self, [NativeTypeName("ImGuiID")] uint key, void* val);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int* ImGuiStorage_GetIntRef(ImGuiStorage* self, [NativeTypeName("ImGuiID")] uint key, int default_val);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern bool* ImGuiStorage_GetBoolRef(ImGuiStorage* self, [NativeTypeName("ImGuiID")] uint key, [NativeTypeName("bool")] byte default_val);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float* ImGuiStorage_GetFloatRef(ImGuiStorage* self, [NativeTypeName("ImGuiID")] uint key, float default_val);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void** ImGuiStorage_GetVoidPtrRef(ImGuiStorage* self, [NativeTypeName("ImGuiID")] uint key, void* default_val);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiStorage_BuildSortByKey(ImGuiStorage* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiStorage_SetAllInt(ImGuiStorage* self, int val);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiListClipper* ImGuiListClipper_ImGuiListClipper();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiListClipper_destroy(ImGuiListClipper* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiListClipper_Begin(ImGuiListClipper* self, int items_count, float items_height);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiListClipper_End(ImGuiListClipper* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte ImGuiListClipper_Step(ImGuiListClipper* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiListClipper_IncludeItemByIndex(ImGuiListClipper* self, int item_index);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiListClipper_IncludeItemsByIndex(ImGuiListClipper* self, int item_begin, int item_end);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImColor* ImColor_ImColor_Nil();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImColor_destroy(ImColor* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImColor* ImColor_ImColor_Float(float r, float g, float b, float a);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImColor* ImColor_ImColor_Vec4([NativeTypeName("const ImVec4")] ImVec4 col);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImColor* ImColor_ImColor_Int(int r, int g, int b, int a);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImColor* ImColor_ImColor_U32([NativeTypeName("ImU32")] uint rgba);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImColor_SetHSV(ImColor* self, float h, float s, float v, float a);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImColor_HSV(ImColor* pOut, float h, float s, float v, float a);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImDrawCmd* ImDrawCmd_ImDrawCmd();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImDrawCmd_destroy(ImDrawCmd* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("ImTextureID")]
    public static extern void* ImDrawCmd_GetTexID(ImDrawCmd* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImDrawListSplitter* ImDrawListSplitter_ImDrawListSplitter();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImDrawListSplitter_destroy(ImDrawListSplitter* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImDrawListSplitter_Clear(ImDrawListSplitter* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImDrawListSplitter_ClearFreeMemory(ImDrawListSplitter* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImDrawListSplitter_Split(ImDrawListSplitter* self, ImDrawList* draw_list, int count);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImDrawListSplitter_Merge(ImDrawListSplitter* self, ImDrawList* draw_list);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImDrawListSplitter_SetCurrentChannel(ImDrawListSplitter* self, ImDrawList* draw_list, int channel_idx);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImDrawList* ImDrawList_ImDrawList(ImDrawListSharedData* shared_data);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImDrawList_destroy(ImDrawList* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImDrawList_PushClipRect(ImDrawList* self, [NativeTypeName("const ImVec2")] ImVec2 clip_rect_min, [NativeTypeName("const ImVec2")] ImVec2 clip_rect_max, [NativeTypeName("bool")] byte intersect_with_current_clip_rect);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImDrawList_PushClipRectFullScreen(ImDrawList* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImDrawList_PopClipRect(ImDrawList* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImDrawList_PushTextureID(ImDrawList* self, [NativeTypeName("ImTextureID")] void* texture_id);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImDrawList_PopTextureID(ImDrawList* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImDrawList_GetClipRectMin(ImVec2* pOut, ImDrawList* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImDrawList_GetClipRectMax(ImVec2* pOut, ImDrawList* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImDrawList_AddLine(ImDrawList* self, [NativeTypeName("const ImVec2")] ImVec2 p1, [NativeTypeName("const ImVec2")] ImVec2 p2, [NativeTypeName("ImU32")] uint col, float thickness);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImDrawList_AddRect(ImDrawList* self, [NativeTypeName("const ImVec2")] ImVec2 p_min, [NativeTypeName("const ImVec2")] ImVec2 p_max, [NativeTypeName("ImU32")] uint col, float rounding, [NativeTypeName("ImDrawFlags")] int flags, float thickness);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImDrawList_AddRectFilled(ImDrawList* self, [NativeTypeName("const ImVec2")] ImVec2 p_min, [NativeTypeName("const ImVec2")] ImVec2 p_max, [NativeTypeName("ImU32")] uint col, float rounding, [NativeTypeName("ImDrawFlags")] int flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImDrawList_AddRectFilledMultiColor(ImDrawList* self, [NativeTypeName("const ImVec2")] ImVec2 p_min, [NativeTypeName("const ImVec2")] ImVec2 p_max, [NativeTypeName("ImU32")] uint col_upr_left, [NativeTypeName("ImU32")] uint col_upr_right, [NativeTypeName("ImU32")] uint col_bot_right, [NativeTypeName("ImU32")] uint col_bot_left);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImDrawList_AddQuad(ImDrawList* self, [NativeTypeName("const ImVec2")] ImVec2 p1, [NativeTypeName("const ImVec2")] ImVec2 p2, [NativeTypeName("const ImVec2")] ImVec2 p3, [NativeTypeName("const ImVec2")] ImVec2 p4, [NativeTypeName("ImU32")] uint col, float thickness);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImDrawList_AddQuadFilled(ImDrawList* self, [NativeTypeName("const ImVec2")] ImVec2 p1, [NativeTypeName("const ImVec2")] ImVec2 p2, [NativeTypeName("const ImVec2")] ImVec2 p3, [NativeTypeName("const ImVec2")] ImVec2 p4, [NativeTypeName("ImU32")] uint col);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImDrawList_AddTriangle(ImDrawList* self, [NativeTypeName("const ImVec2")] ImVec2 p1, [NativeTypeName("const ImVec2")] ImVec2 p2, [NativeTypeName("const ImVec2")] ImVec2 p3, [NativeTypeName("ImU32")] uint col, float thickness);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImDrawList_AddTriangleFilled(ImDrawList* self, [NativeTypeName("const ImVec2")] ImVec2 p1, [NativeTypeName("const ImVec2")] ImVec2 p2, [NativeTypeName("const ImVec2")] ImVec2 p3, [NativeTypeName("ImU32")] uint col);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImDrawList_AddCircle(ImDrawList* self, [NativeTypeName("const ImVec2")] ImVec2 center, float radius, [NativeTypeName("ImU32")] uint col, int num_segments, float thickness);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImDrawList_AddCircleFilled(ImDrawList* self, [NativeTypeName("const ImVec2")] ImVec2 center, float radius, [NativeTypeName("ImU32")] uint col, int num_segments);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImDrawList_AddNgon(ImDrawList* self, [NativeTypeName("const ImVec2")] ImVec2 center, float radius, [NativeTypeName("ImU32")] uint col, int num_segments, float thickness);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImDrawList_AddNgonFilled(ImDrawList* self, [NativeTypeName("const ImVec2")] ImVec2 center, float radius, [NativeTypeName("ImU32")] uint col, int num_segments);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImDrawList_AddEllipse(ImDrawList* self, [NativeTypeName("const ImVec2")] ImVec2 center, float radius_x, float radius_y, [NativeTypeName("ImU32")] uint col, float rot, int num_segments, float thickness);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImDrawList_AddEllipseFilled(ImDrawList* self, [NativeTypeName("const ImVec2")] ImVec2 center, float radius_x, float radius_y, [NativeTypeName("ImU32")] uint col, float rot, int num_segments);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImDrawList_AddText_Vec2(ImDrawList* self, [NativeTypeName("const ImVec2")] ImVec2 pos, [NativeTypeName("ImU32")] uint col, [NativeTypeName("const char *")] sbyte* text_begin, [NativeTypeName("const char *")] sbyte* text_end);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImDrawList_AddText_FontPtr(ImDrawList* self, [NativeTypeName("const ImFont *")] ImFont* font, float font_size, [NativeTypeName("const ImVec2")] ImVec2 pos, [NativeTypeName("ImU32")] uint col, [NativeTypeName("const char *")] sbyte* text_begin, [NativeTypeName("const char *")] sbyte* text_end, float wrap_width, [NativeTypeName("const ImVec4 *")] ImVec4* cpu_fine_clip_rect);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImDrawList_AddPolyline(ImDrawList* self, [NativeTypeName("const ImVec2 *")] ImVec2* points, int num_points, [NativeTypeName("ImU32")] uint col, [NativeTypeName("ImDrawFlags")] int flags, float thickness);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImDrawList_AddConvexPolyFilled(ImDrawList* self, [NativeTypeName("const ImVec2 *")] ImVec2* points, int num_points, [NativeTypeName("ImU32")] uint col);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImDrawList_AddBezierCubic(ImDrawList* self, [NativeTypeName("const ImVec2")] ImVec2 p1, [NativeTypeName("const ImVec2")] ImVec2 p2, [NativeTypeName("const ImVec2")] ImVec2 p3, [NativeTypeName("const ImVec2")] ImVec2 p4, [NativeTypeName("ImU32")] uint col, float thickness, int num_segments);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImDrawList_AddBezierQuadratic(ImDrawList* self, [NativeTypeName("const ImVec2")] ImVec2 p1, [NativeTypeName("const ImVec2")] ImVec2 p2, [NativeTypeName("const ImVec2")] ImVec2 p3, [NativeTypeName("ImU32")] uint col, float thickness, int num_segments);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImDrawList_AddImage(ImDrawList* self, [NativeTypeName("ImTextureID")] void* user_texture_id, [NativeTypeName("const ImVec2")] ImVec2 p_min, [NativeTypeName("const ImVec2")] ImVec2 p_max, [NativeTypeName("const ImVec2")] ImVec2 uv_min, [NativeTypeName("const ImVec2")] ImVec2 uv_max, [NativeTypeName("ImU32")] uint col);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImDrawList_AddImageQuad(ImDrawList* self, [NativeTypeName("ImTextureID")] void* user_texture_id, [NativeTypeName("const ImVec2")] ImVec2 p1, [NativeTypeName("const ImVec2")] ImVec2 p2, [NativeTypeName("const ImVec2")] ImVec2 p3, [NativeTypeName("const ImVec2")] ImVec2 p4, [NativeTypeName("const ImVec2")] ImVec2 uv1, [NativeTypeName("const ImVec2")] ImVec2 uv2, [NativeTypeName("const ImVec2")] ImVec2 uv3, [NativeTypeName("const ImVec2")] ImVec2 uv4, [NativeTypeName("ImU32")] uint col);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImDrawList_AddImageRounded(ImDrawList* self, [NativeTypeName("ImTextureID")] void* user_texture_id, [NativeTypeName("const ImVec2")] ImVec2 p_min, [NativeTypeName("const ImVec2")] ImVec2 p_max, [NativeTypeName("const ImVec2")] ImVec2 uv_min, [NativeTypeName("const ImVec2")] ImVec2 uv_max, [NativeTypeName("ImU32")] uint col, float rounding, [NativeTypeName("ImDrawFlags")] int flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImDrawList_PathClear(ImDrawList* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImDrawList_PathLineTo(ImDrawList* self, [NativeTypeName("const ImVec2")] ImVec2 pos);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImDrawList_PathLineToMergeDuplicate(ImDrawList* self, [NativeTypeName("const ImVec2")] ImVec2 pos);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImDrawList_PathFillConvex(ImDrawList* self, [NativeTypeName("ImU32")] uint col);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImDrawList_PathStroke(ImDrawList* self, [NativeTypeName("ImU32")] uint col, [NativeTypeName("ImDrawFlags")] int flags, float thickness);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImDrawList_PathArcTo(ImDrawList* self, [NativeTypeName("const ImVec2")] ImVec2 center, float radius, float a_min, float a_max, int num_segments);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImDrawList_PathArcToFast(ImDrawList* self, [NativeTypeName("const ImVec2")] ImVec2 center, float radius, int a_min_of_12, int a_max_of_12);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImDrawList_PathEllipticalArcTo(ImDrawList* self, [NativeTypeName("const ImVec2")] ImVec2 center, float radius_x, float radius_y, float rot, float a_min, float a_max, int num_segments);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImDrawList_PathBezierCubicCurveTo(ImDrawList* self, [NativeTypeName("const ImVec2")] ImVec2 p2, [NativeTypeName("const ImVec2")] ImVec2 p3, [NativeTypeName("const ImVec2")] ImVec2 p4, int num_segments);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImDrawList_PathBezierQuadraticCurveTo(ImDrawList* self, [NativeTypeName("const ImVec2")] ImVec2 p2, [NativeTypeName("const ImVec2")] ImVec2 p3, int num_segments);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImDrawList_PathRect(ImDrawList* self, [NativeTypeName("const ImVec2")] ImVec2 rect_min, [NativeTypeName("const ImVec2")] ImVec2 rect_max, float rounding, [NativeTypeName("ImDrawFlags")] int flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImDrawList_AddCallback(ImDrawList* self, [NativeTypeName("ImDrawCallback")] delegate* unmanaged[Cdecl]<ImDrawList*, ImDrawCmd*, void> callback, void* callback_data);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImDrawList_AddDrawCmd(ImDrawList* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImDrawList* ImDrawList_CloneOutput(ImDrawList* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImDrawList_ChannelsSplit(ImDrawList* self, int count);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImDrawList_ChannelsMerge(ImDrawList* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImDrawList_ChannelsSetCurrent(ImDrawList* self, int n);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImDrawList_PrimReserve(ImDrawList* self, int idx_count, int vtx_count);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImDrawList_PrimUnreserve(ImDrawList* self, int idx_count, int vtx_count);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImDrawList_PrimRect(ImDrawList* self, [NativeTypeName("const ImVec2")] ImVec2 a, [NativeTypeName("const ImVec2")] ImVec2 b, [NativeTypeName("ImU32")] uint col);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImDrawList_PrimRectUV(ImDrawList* self, [NativeTypeName("const ImVec2")] ImVec2 a, [NativeTypeName("const ImVec2")] ImVec2 b, [NativeTypeName("const ImVec2")] ImVec2 uv_a, [NativeTypeName("const ImVec2")] ImVec2 uv_b, [NativeTypeName("ImU32")] uint col);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImDrawList_PrimQuadUV(ImDrawList* self, [NativeTypeName("const ImVec2")] ImVec2 a, [NativeTypeName("const ImVec2")] ImVec2 b, [NativeTypeName("const ImVec2")] ImVec2 c, [NativeTypeName("const ImVec2")] ImVec2 d, [NativeTypeName("const ImVec2")] ImVec2 uv_a, [NativeTypeName("const ImVec2")] ImVec2 uv_b, [NativeTypeName("const ImVec2")] ImVec2 uv_c, [NativeTypeName("const ImVec2")] ImVec2 uv_d, [NativeTypeName("ImU32")] uint col);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImDrawList_PrimWriteVtx(ImDrawList* self, [NativeTypeName("const ImVec2")] ImVec2 pos, [NativeTypeName("const ImVec2")] ImVec2 uv, [NativeTypeName("ImU32")] uint col);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImDrawList_PrimWriteIdx(ImDrawList* self, [NativeTypeName("ImDrawIdx")] ushort idx);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImDrawList_PrimVtx(ImDrawList* self, [NativeTypeName("const ImVec2")] ImVec2 pos, [NativeTypeName("const ImVec2")] ImVec2 uv, [NativeTypeName("ImU32")] uint col);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImDrawList__ResetForNewFrame(ImDrawList* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImDrawList__ClearFreeMemory(ImDrawList* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImDrawList__PopUnusedDrawCmd(ImDrawList* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImDrawList__TryMergeDrawCmds(ImDrawList* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImDrawList__OnChangedClipRect(ImDrawList* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImDrawList__OnChangedTextureID(ImDrawList* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImDrawList__OnChangedVtxOffset(ImDrawList* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int ImDrawList__CalcCircleAutoSegmentCount(ImDrawList* self, float radius);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImDrawList__PathArcToFastEx(ImDrawList* self, [NativeTypeName("const ImVec2")] ImVec2 center, float radius, int a_min_sample, int a_max_sample, int a_step);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImDrawList__PathArcToN(ImDrawList* self, [NativeTypeName("const ImVec2")] ImVec2 center, float radius, float a_min, float a_max, int num_segments);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImDrawData* ImDrawData_ImDrawData();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImDrawData_destroy(ImDrawData* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImDrawData_Clear(ImDrawData* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImDrawData_AddDrawList(ImDrawData* self, ImDrawList* draw_list);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImDrawData_DeIndexAllBuffers(ImDrawData* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImDrawData_ScaleClipRects(ImDrawData* self, [NativeTypeName("const ImVec2")] ImVec2 fb_scale);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImFontConfig* ImFontConfig_ImFontConfig();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImFontConfig_destroy(ImFontConfig* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImFontGlyphRangesBuilder* ImFontGlyphRangesBuilder_ImFontGlyphRangesBuilder();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImFontGlyphRangesBuilder_destroy(ImFontGlyphRangesBuilder* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImFontGlyphRangesBuilder_Clear(ImFontGlyphRangesBuilder* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte ImFontGlyphRangesBuilder_GetBit(ImFontGlyphRangesBuilder* self, [NativeTypeName("size_t")] nuint n);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImFontGlyphRangesBuilder_SetBit(ImFontGlyphRangesBuilder* self, [NativeTypeName("size_t")] nuint n);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImFontGlyphRangesBuilder_AddChar(ImFontGlyphRangesBuilder* self, [NativeTypeName("ImWchar")] ushort c);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImFontGlyphRangesBuilder_AddText(ImFontGlyphRangesBuilder* self, [NativeTypeName("const char *")] sbyte* text, [NativeTypeName("const char *")] sbyte* text_end);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImFontGlyphRangesBuilder_AddRanges(ImFontGlyphRangesBuilder* self, [NativeTypeName("const ImWchar *")] ushort* ranges);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImFontGlyphRangesBuilder_BuildRanges(ImFontGlyphRangesBuilder* self, ImVector_ImWchar* out_ranges);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImFontAtlasCustomRect* ImFontAtlasCustomRect_ImFontAtlasCustomRect();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImFontAtlasCustomRect_destroy(ImFontAtlasCustomRect* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte ImFontAtlasCustomRect_IsPacked(ImFontAtlasCustomRect* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImFontAtlas* ImFontAtlas_ImFontAtlas();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImFontAtlas_destroy(ImFontAtlas* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImFont* ImFontAtlas_AddFont(ImFontAtlas* self, [NativeTypeName("const ImFontConfig *")] ImFontConfig* font_cfg);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImFont* ImFontAtlas_AddFontDefault(ImFontAtlas* self, [NativeTypeName("const ImFontConfig *")] ImFontConfig* font_cfg);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImFont* ImFontAtlas_AddFontFromFileTTF(ImFontAtlas* self, [NativeTypeName("const char *")] sbyte* filename, float size_pixels, [NativeTypeName("const ImFontConfig *")] ImFontConfig* font_cfg, [NativeTypeName("const ImWchar *")] ushort* glyph_ranges);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImFont* ImFontAtlas_AddFontFromMemoryTTF(ImFontAtlas* self, void* font_data, int font_data_size, float size_pixels, [NativeTypeName("const ImFontConfig *")] ImFontConfig* font_cfg, [NativeTypeName("const ImWchar *")] ushort* glyph_ranges);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImFont* ImFontAtlas_AddFontFromMemoryCompressedTTF(ImFontAtlas* self, [NativeTypeName("const void *")] void* compressed_font_data, int compressed_font_data_size, float size_pixels, [NativeTypeName("const ImFontConfig *")] ImFontConfig* font_cfg, [NativeTypeName("const ImWchar *")] ushort* glyph_ranges);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImFont* ImFontAtlas_AddFontFromMemoryCompressedBase85TTF(ImFontAtlas* self, [NativeTypeName("const char *")] sbyte* compressed_font_data_base85, float size_pixels, [NativeTypeName("const ImFontConfig *")] ImFontConfig* font_cfg, [NativeTypeName("const ImWchar *")] ushort* glyph_ranges);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImFontAtlas_ClearInputData(ImFontAtlas* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImFontAtlas_ClearTexData(ImFontAtlas* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImFontAtlas_ClearFonts(ImFontAtlas* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImFontAtlas_Clear(ImFontAtlas* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte ImFontAtlas_Build(ImFontAtlas* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImFontAtlas_GetTexDataAsAlpha8(ImFontAtlas* self, [NativeTypeName("unsigned char **")] byte** out_pixels, int* out_width, int* out_height, int* out_bytes_per_pixel);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImFontAtlas_GetTexDataAsRGBA32(ImFontAtlas* self, [NativeTypeName("unsigned char **")] byte** out_pixels, int* out_width, int* out_height, int* out_bytes_per_pixel);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte ImFontAtlas_IsBuilt(ImFontAtlas* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImFontAtlas_SetTexID(ImFontAtlas* self, [NativeTypeName("ImTextureID")] void* id);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const ImWchar *")]
    public static extern ushort* ImFontAtlas_GetGlyphRangesDefault(ImFontAtlas* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const ImWchar *")]
    public static extern ushort* ImFontAtlas_GetGlyphRangesGreek(ImFontAtlas* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const ImWchar *")]
    public static extern ushort* ImFontAtlas_GetGlyphRangesKorean(ImFontAtlas* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const ImWchar *")]
    public static extern ushort* ImFontAtlas_GetGlyphRangesJapanese(ImFontAtlas* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const ImWchar *")]
    public static extern ushort* ImFontAtlas_GetGlyphRangesChineseFull(ImFontAtlas* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const ImWchar *")]
    public static extern ushort* ImFontAtlas_GetGlyphRangesChineseSimplifiedCommon(ImFontAtlas* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const ImWchar *")]
    public static extern ushort* ImFontAtlas_GetGlyphRangesCyrillic(ImFontAtlas* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const ImWchar *")]
    public static extern ushort* ImFontAtlas_GetGlyphRangesThai(ImFontAtlas* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const ImWchar *")]
    public static extern ushort* ImFontAtlas_GetGlyphRangesVietnamese(ImFontAtlas* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int ImFontAtlas_AddCustomRectRegular(ImFontAtlas* self, int width, int height);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int ImFontAtlas_AddCustomRectFontGlyph(ImFontAtlas* self, ImFont* font, [NativeTypeName("ImWchar")] ushort id, int width, int height, float advance_x, [NativeTypeName("const ImVec2")] ImVec2 offset);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImFontAtlasCustomRect* ImFontAtlas_GetCustomRectByIndex(ImFontAtlas* self, int index);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImFontAtlas_CalcCustomRectUV(ImFontAtlas* self, [NativeTypeName("const ImFontAtlasCustomRect *")] ImFontAtlasCustomRect* rect, ImVec2* out_uv_min, ImVec2* out_uv_max);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte ImFontAtlas_GetMouseCursorTexData(ImFontAtlas* self, [NativeTypeName("ImGuiMouseCursor")] int cursor, ImVec2* out_offset, ImVec2* out_size, [NativeTypeName("ImVec2[2]")] ImVec2* out_uv_border, [NativeTypeName("ImVec2[2]")] ImVec2* out_uv_fill);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImFont* ImFont_ImFont();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImFont_destroy(ImFont* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const ImFontGlyph *")]
    public static extern ImFontGlyph* ImFont_FindGlyph(ImFont* self, [NativeTypeName("ImWchar")] ushort c);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const ImFontGlyph *")]
    public static extern ImFontGlyph* ImFont_FindGlyphNoFallback(ImFont* self, [NativeTypeName("ImWchar")] ushort c);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float ImFont_GetCharAdvance(ImFont* self, [NativeTypeName("ImWchar")] ushort c);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte ImFont_IsLoaded(ImFont* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* ImFont_GetDebugName(ImFont* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImFont_CalcTextSizeA(ImVec2* pOut, ImFont* self, float size, float max_width, float wrap_width, [NativeTypeName("const char *")] sbyte* text_begin, [NativeTypeName("const char *")] sbyte* text_end, [NativeTypeName("const char **")] sbyte** remaining);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* ImFont_CalcWordWrapPositionA(ImFont* self, float scale, [NativeTypeName("const char *")] sbyte* text, [NativeTypeName("const char *")] sbyte* text_end, float wrap_width);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImFont_RenderChar(ImFont* self, ImDrawList* draw_list, float size, [NativeTypeName("const ImVec2")] ImVec2 pos, [NativeTypeName("ImU32")] uint col, [NativeTypeName("ImWchar")] ushort c);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImFont_RenderText(ImFont* self, ImDrawList* draw_list, float size, [NativeTypeName("const ImVec2")] ImVec2 pos, [NativeTypeName("ImU32")] uint col, [NativeTypeName("const ImVec4")] ImVec4 clip_rect, [NativeTypeName("const char *")] sbyte* text_begin, [NativeTypeName("const char *")] sbyte* text_end, float wrap_width, [NativeTypeName("bool")] byte cpu_fine_clip);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImFont_BuildLookupTable(ImFont* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImFont_ClearOutputData(ImFont* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImFont_GrowIndex(ImFont* self, int new_size);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImFont_AddGlyph(ImFont* self, [NativeTypeName("const ImFontConfig *")] ImFontConfig* src_cfg, [NativeTypeName("ImWchar")] ushort c, float x0, float y0, float x1, float y1, float u0, float v0, float u1, float v1, float advance_x);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImFont_AddRemapChar(ImFont* self, [NativeTypeName("ImWchar")] ushort dst, [NativeTypeName("ImWchar")] ushort src, [NativeTypeName("bool")] byte overwrite_dst);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImFont_SetGlyphVisible(ImFont* self, [NativeTypeName("ImWchar")] ushort c, [NativeTypeName("bool")] byte visible);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte ImFont_IsGlyphRangeUnused(ImFont* self, [NativeTypeName("unsigned int")] uint c_begin, [NativeTypeName("unsigned int")] uint c_last);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiViewport* ImGuiViewport_ImGuiViewport();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiViewport_destroy(ImGuiViewport* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiViewport_GetCenter(ImVec2* pOut, ImGuiViewport* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiViewport_GetWorkCenter(ImVec2* pOut, ImGuiViewport* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiPlatformIO* ImGuiPlatformIO_ImGuiPlatformIO();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiPlatformIO_destroy(ImGuiPlatformIO* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiPlatformMonitor* ImGuiPlatformMonitor_ImGuiPlatformMonitor();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiPlatformMonitor_destroy(ImGuiPlatformMonitor* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiPlatformImeData* ImGuiPlatformImeData_ImGuiPlatformImeData();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiPlatformImeData_destroy(ImGuiPlatformImeData* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiKey igGetKeyIndex(ImGuiKey key);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("ImGuiID")]
    public static extern uint igImHashData([NativeTypeName("const void *")] void* data, [NativeTypeName("size_t")] nuint data_size, [NativeTypeName("ImGuiID")] uint seed);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("ImGuiID")]
    public static extern uint igImHashStr([NativeTypeName("const char *")] sbyte* data, [NativeTypeName("size_t")] nuint data_size, [NativeTypeName("ImGuiID")] uint seed);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igImQsort(void* @base, [NativeTypeName("size_t")] nuint count, [NativeTypeName("size_t")] nuint size_of_element, [NativeTypeName("int (*)(const void *, const void *)")] delegate* unmanaged[Cdecl]<void*, void*, int> compare_func);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("ImU32")]
    public static extern uint igImAlphaBlendColors([NativeTypeName("ImU32")] uint col_a, [NativeTypeName("ImU32")] uint col_b);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igImIsPowerOfTwo_Int(int v);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igImIsPowerOfTwo_U64([NativeTypeName("ImU64")] ulong v);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int igImUpperPowerOfTwo(int v);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int igImStricmp([NativeTypeName("const char *")] sbyte* str1, [NativeTypeName("const char *")] sbyte* str2);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int igImStrnicmp([NativeTypeName("const char *")] sbyte* str1, [NativeTypeName("const char *")] sbyte* str2, [NativeTypeName("size_t")] nuint count);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igImStrncpy([NativeTypeName("char *")] sbyte* dst, [NativeTypeName("const char *")] sbyte* src, [NativeTypeName("size_t")] nuint count);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("char *")]
    public static extern sbyte* igImStrdup([NativeTypeName("const char *")] sbyte* str);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("char *")]
    public static extern sbyte* igImStrdupcpy([NativeTypeName("char *")] sbyte* dst, [NativeTypeName("size_t *")] nuint* p_dst_size, [NativeTypeName("const char *")] sbyte* str);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* igImStrchrRange([NativeTypeName("const char *")] sbyte* str_begin, [NativeTypeName("const char *")] sbyte* str_end, [NativeTypeName("char")] sbyte c);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* igImStreolRange([NativeTypeName("const char *")] sbyte* str, [NativeTypeName("const char *")] sbyte* str_end);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* igImStristr([NativeTypeName("const char *")] sbyte* haystack, [NativeTypeName("const char *")] sbyte* haystack_end, [NativeTypeName("const char *")] sbyte* needle, [NativeTypeName("const char *")] sbyte* needle_end);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igImStrTrimBlanks([NativeTypeName("char *")] sbyte* str);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* igImStrSkipBlank([NativeTypeName("const char *")] sbyte* str);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int igImStrlenW([NativeTypeName("const ImWchar *")] ushort* str);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const ImWchar *")]
    public static extern ushort* igImStrbolW([NativeTypeName("const ImWchar *")] ushort* buf_mid_line, [NativeTypeName("const ImWchar *")] ushort* buf_begin);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("char")]
    public static extern sbyte igImToUpper([NativeTypeName("char")] sbyte c);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igImCharIsBlankA([NativeTypeName("char")] sbyte c);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igImCharIsBlankW([NativeTypeName("unsigned int")] uint c);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int igImFormatString([NativeTypeName("char *")] sbyte* buf, [NativeTypeName("size_t")] nuint buf_size, [NativeTypeName("const char *")] sbyte* fmt, __arglist);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int igImFormatStringV([NativeTypeName("char *")] sbyte* buf, [NativeTypeName("size_t")] nuint buf_size, [NativeTypeName("const char *")] sbyte* fmt, [NativeTypeName("va_list")] sbyte* args);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igImFormatStringToTempBuffer([NativeTypeName("const char **")] sbyte** out_buf, [NativeTypeName("const char **")] sbyte** out_buf_end, [NativeTypeName("const char *")] sbyte* fmt, __arglist);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igImFormatStringToTempBufferV([NativeTypeName("const char **")] sbyte** out_buf, [NativeTypeName("const char **")] sbyte** out_buf_end, [NativeTypeName("const char *")] sbyte* fmt, [NativeTypeName("va_list")] sbyte* args);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* igImParseFormatFindStart([NativeTypeName("const char *")] sbyte* format);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* igImParseFormatFindEnd([NativeTypeName("const char *")] sbyte* format);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* igImParseFormatTrimDecorations([NativeTypeName("const char *")] sbyte* format, [NativeTypeName("char *")] sbyte* buf, [NativeTypeName("size_t")] nuint buf_size);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igImParseFormatSanitizeForPrinting([NativeTypeName("const char *")] sbyte* fmt_in, [NativeTypeName("char *")] sbyte* fmt_out, [NativeTypeName("size_t")] nuint fmt_out_size);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* igImParseFormatSanitizeForScanning([NativeTypeName("const char *")] sbyte* fmt_in, [NativeTypeName("char *")] sbyte* fmt_out, [NativeTypeName("size_t")] nuint fmt_out_size);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int igImParseFormatPrecision([NativeTypeName("const char *")] sbyte* format, int default_value);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* igImTextCharToUtf8([NativeTypeName("char[5]")] sbyte* out_buf, [NativeTypeName("unsigned int")] uint c);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int igImTextStrToUtf8([NativeTypeName("char *")] sbyte* out_buf, int out_buf_size, [NativeTypeName("const ImWchar *")] ushort* in_text, [NativeTypeName("const ImWchar *")] ushort* in_text_end);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int igImTextCharFromUtf8([NativeTypeName("unsigned int *")] uint* out_char, [NativeTypeName("const char *")] sbyte* in_text, [NativeTypeName("const char *")] sbyte* in_text_end);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int igImTextStrFromUtf8([NativeTypeName("ImWchar *")] ushort* out_buf, int out_buf_size, [NativeTypeName("const char *")] sbyte* in_text, [NativeTypeName("const char *")] sbyte* in_text_end, [NativeTypeName("const char **")] sbyte** in_remaining);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int igImTextCountCharsFromUtf8([NativeTypeName("const char *")] sbyte* in_text, [NativeTypeName("const char *")] sbyte* in_text_end);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int igImTextCountUtf8BytesFromChar([NativeTypeName("const char *")] sbyte* in_text, [NativeTypeName("const char *")] sbyte* in_text_end);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int igImTextCountUtf8BytesFromStr([NativeTypeName("const ImWchar *")] ushort* in_text, [NativeTypeName("const ImWchar *")] ushort* in_text_end);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* igImTextFindPreviousUtf8Codepoint([NativeTypeName("const char *")] sbyte* in_text_start, [NativeTypeName("const char *")] sbyte* in_text_curr);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("ImFileHandle")]
    public static extern void* igImFileOpen([NativeTypeName("const char *")] sbyte* filename, [NativeTypeName("const char *")] sbyte* mode);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igImFileClose([NativeTypeName("ImFileHandle")] void* file);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("ImU64")]
    public static extern ulong igImFileGetSize([NativeTypeName("ImFileHandle")] void* file);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("ImU64")]
    public static extern ulong igImFileRead(void* data, [NativeTypeName("ImU64")] ulong size, [NativeTypeName("ImU64")] ulong count, [NativeTypeName("ImFileHandle")] void* file);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("ImU64")]
    public static extern ulong igImFileWrite([NativeTypeName("const void *")] void* data, [NativeTypeName("ImU64")] ulong size, [NativeTypeName("ImU64")] ulong count, [NativeTypeName("ImFileHandle")] void* file);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void* igImFileLoadToMemory([NativeTypeName("const char *")] sbyte* filename, [NativeTypeName("const char *")] sbyte* mode, [NativeTypeName("size_t *")] nuint* out_file_size, int padding_bytes);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float igImPow_Float(float x, float y);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern double igImPow_double(double x, double y);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float igImLog_Float(float x);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern double igImLog_double(double x);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int igImAbs_Int(int x);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float igImAbs_Float(float x);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern double igImAbs_double(double x);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float igImSign_Float(float x);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern double igImSign_double(double x);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float igImRsqrt_Float(float x);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern double igImRsqrt_double(double x);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igImMin(ImVec2* pOut, [NativeTypeName("const ImVec2")] ImVec2 lhs, [NativeTypeName("const ImVec2")] ImVec2 rhs);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igImMax(ImVec2* pOut, [NativeTypeName("const ImVec2")] ImVec2 lhs, [NativeTypeName("const ImVec2")] ImVec2 rhs);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igImClamp(ImVec2* pOut, [NativeTypeName("const ImVec2")] ImVec2 v, [NativeTypeName("const ImVec2")] ImVec2 mn, ImVec2 mx);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igImLerp_Vec2Float(ImVec2* pOut, [NativeTypeName("const ImVec2")] ImVec2 a, [NativeTypeName("const ImVec2")] ImVec2 b, float t);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igImLerp_Vec2Vec2(ImVec2* pOut, [NativeTypeName("const ImVec2")] ImVec2 a, [NativeTypeName("const ImVec2")] ImVec2 b, [NativeTypeName("const ImVec2")] ImVec2 t);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igImLerp_Vec4(ImVec4* pOut, [NativeTypeName("const ImVec4")] ImVec4 a, [NativeTypeName("const ImVec4")] ImVec4 b, float t);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float igImSaturate(float f);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float igImLengthSqr_Vec2([NativeTypeName("const ImVec2")] ImVec2 lhs);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float igImLengthSqr_Vec4([NativeTypeName("const ImVec4")] ImVec4 lhs);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float igImInvLength([NativeTypeName("const ImVec2")] ImVec2 lhs, float fail_value);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float igImTrunc_Float(float f);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igImTrunc_Vec2(ImVec2* pOut, [NativeTypeName("const ImVec2")] ImVec2 v);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float igImFloor_Float(float f);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igImFloor_Vec2(ImVec2* pOut, [NativeTypeName("const ImVec2")] ImVec2 v);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int igImModPositive(int a, int b);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float igImDot([NativeTypeName("const ImVec2")] ImVec2 a, [NativeTypeName("const ImVec2")] ImVec2 b);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igImRotate(ImVec2* pOut, [NativeTypeName("const ImVec2")] ImVec2 v, float cos_a, float sin_a);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float igImLinearSweep(float current, float target, float speed);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igImMul(ImVec2* pOut, [NativeTypeName("const ImVec2")] ImVec2 lhs, [NativeTypeName("const ImVec2")] ImVec2 rhs);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igImIsFloatAboveGuaranteedIntegerPrecision(float f);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float igImExponentialMovingAverage(float avg, float sample, int n);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igImBezierCubicCalc(ImVec2* pOut, [NativeTypeName("const ImVec2")] ImVec2 p1, [NativeTypeName("const ImVec2")] ImVec2 p2, [NativeTypeName("const ImVec2")] ImVec2 p3, [NativeTypeName("const ImVec2")] ImVec2 p4, float t);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igImBezierCubicClosestPoint(ImVec2* pOut, [NativeTypeName("const ImVec2")] ImVec2 p1, [NativeTypeName("const ImVec2")] ImVec2 p2, [NativeTypeName("const ImVec2")] ImVec2 p3, [NativeTypeName("const ImVec2")] ImVec2 p4, [NativeTypeName("const ImVec2")] ImVec2 p, int num_segments);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igImBezierCubicClosestPointCasteljau(ImVec2* pOut, [NativeTypeName("const ImVec2")] ImVec2 p1, [NativeTypeName("const ImVec2")] ImVec2 p2, [NativeTypeName("const ImVec2")] ImVec2 p3, [NativeTypeName("const ImVec2")] ImVec2 p4, [NativeTypeName("const ImVec2")] ImVec2 p, float tess_tol);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igImBezierQuadraticCalc(ImVec2* pOut, [NativeTypeName("const ImVec2")] ImVec2 p1, [NativeTypeName("const ImVec2")] ImVec2 p2, [NativeTypeName("const ImVec2")] ImVec2 p3, float t);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igImLineClosestPoint(ImVec2* pOut, [NativeTypeName("const ImVec2")] ImVec2 a, [NativeTypeName("const ImVec2")] ImVec2 b, [NativeTypeName("const ImVec2")] ImVec2 p);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igImTriangleContainsPoint([NativeTypeName("const ImVec2")] ImVec2 a, [NativeTypeName("const ImVec2")] ImVec2 b, [NativeTypeName("const ImVec2")] ImVec2 c, [NativeTypeName("const ImVec2")] ImVec2 p);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igImTriangleClosestPoint(ImVec2* pOut, [NativeTypeName("const ImVec2")] ImVec2 a, [NativeTypeName("const ImVec2")] ImVec2 b, [NativeTypeName("const ImVec2")] ImVec2 c, [NativeTypeName("const ImVec2")] ImVec2 p);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igImTriangleBarycentricCoords([NativeTypeName("const ImVec2")] ImVec2 a, [NativeTypeName("const ImVec2")] ImVec2 b, [NativeTypeName("const ImVec2")] ImVec2 c, [NativeTypeName("const ImVec2")] ImVec2 p, float* out_u, float* out_v, float* out_w);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float igImTriangleArea([NativeTypeName("const ImVec2")] ImVec2 a, [NativeTypeName("const ImVec2")] ImVec2 b, [NativeTypeName("const ImVec2")] ImVec2 c);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImVec1* ImVec1_ImVec1_Nil();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImVec1_destroy(ImVec1* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImVec1* ImVec1_ImVec1_Float(float _x);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImVec2ih* ImVec2ih_ImVec2ih_Nil();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImVec2ih_destroy(ImVec2ih* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImVec2ih* ImVec2ih_ImVec2ih_short(short _x, short _y);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImVec2ih* ImVec2ih_ImVec2ih_Vec2([NativeTypeName("const ImVec2")] ImVec2 rhs);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImRect* ImRect_ImRect_Nil();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImRect_destroy(ImRect* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImRect* ImRect_ImRect_Vec2([NativeTypeName("const ImVec2")] ImVec2 min, [NativeTypeName("const ImVec2")] ImVec2 max);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImRect* ImRect_ImRect_Vec4([NativeTypeName("const ImVec4")] ImVec4 v);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImRect* ImRect_ImRect_Float(float x1, float y1, float x2, float y2);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImRect_GetCenter(ImVec2* pOut, ImRect* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImRect_GetSize(ImVec2* pOut, ImRect* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float ImRect_GetWidth(ImRect* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float ImRect_GetHeight(ImRect* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float ImRect_GetArea(ImRect* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImRect_GetTL(ImVec2* pOut, ImRect* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImRect_GetTR(ImVec2* pOut, ImRect* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImRect_GetBL(ImVec2* pOut, ImRect* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImRect_GetBR(ImVec2* pOut, ImRect* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte ImRect_Contains_Vec2(ImRect* self, [NativeTypeName("const ImVec2")] ImVec2 p);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte ImRect_Contains_Rect(ImRect* self, [NativeTypeName("const ImRect")] ImRect r);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte ImRect_ContainsWithPad(ImRect* self, [NativeTypeName("const ImVec2")] ImVec2 p, [NativeTypeName("const ImVec2")] ImVec2 pad);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte ImRect_Overlaps(ImRect* self, [NativeTypeName("const ImRect")] ImRect r);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImRect_Add_Vec2(ImRect* self, [NativeTypeName("const ImVec2")] ImVec2 p);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImRect_Add_Rect(ImRect* self, [NativeTypeName("const ImRect")] ImRect r);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImRect_Expand_Float(ImRect* self, [NativeTypeName("const float")] float amount);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImRect_Expand_Vec2(ImRect* self, [NativeTypeName("const ImVec2")] ImVec2 amount);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImRect_Translate(ImRect* self, [NativeTypeName("const ImVec2")] ImVec2 d);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImRect_TranslateX(ImRect* self, float dx);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImRect_TranslateY(ImRect* self, float dy);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImRect_ClipWith(ImRect* self, [NativeTypeName("const ImRect")] ImRect r);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImRect_ClipWithFull(ImRect* self, [NativeTypeName("const ImRect")] ImRect r);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImRect_Floor(ImRect* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte ImRect_IsInverted(ImRect* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImRect_ToVec4(ImVec4* pOut, ImRect* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("size_t")]
    public static extern nuint igImBitArrayGetStorageSizeInBytes(int bitcount);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igImBitArrayClearAllBits([NativeTypeName("ImU32 *")] uint* arr, int bitcount);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igImBitArrayTestBit([NativeTypeName("const ImU32 *")] uint* arr, int n);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igImBitArrayClearBit([NativeTypeName("ImU32 *")] uint* arr, int n);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igImBitArraySetBit([NativeTypeName("ImU32 *")] uint* arr, int n);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igImBitArraySetBitRange([NativeTypeName("ImU32 *")] uint* arr, int n, int n2);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImBitVector_Create(ImBitVector* self, int sz);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImBitVector_Clear(ImBitVector* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte ImBitVector_TestBit(ImBitVector* self, int n);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImBitVector_SetBit(ImBitVector* self, int n);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImBitVector_ClearBit(ImBitVector* self, int n);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiTextIndex_clear(ImGuiTextIndex* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int ImGuiTextIndex_size(ImGuiTextIndex* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* ImGuiTextIndex_get_line_begin(ImGuiTextIndex* self, [NativeTypeName("const char *")] sbyte* @base, int n);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* ImGuiTextIndex_get_line_end(ImGuiTextIndex* self, [NativeTypeName("const char *")] sbyte* @base, int n);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiTextIndex_append(ImGuiTextIndex* self, [NativeTypeName("const char *")] sbyte* @base, int old_size, int new_size);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImDrawListSharedData* ImDrawListSharedData_ImDrawListSharedData();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImDrawListSharedData_destroy(ImDrawListSharedData* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImDrawListSharedData_SetCircleTessellationMaxError(ImDrawListSharedData* self, float max_error);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImDrawDataBuilder* ImDrawDataBuilder_ImDrawDataBuilder();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImDrawDataBuilder_destroy(ImDrawDataBuilder* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void* ImGuiDataVarInfo_GetVarPtr(ImGuiDataVarInfo* self, void* parent);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiStyleMod* ImGuiStyleMod_ImGuiStyleMod_Int([NativeTypeName("ImGuiStyleVar")] int idx, int v);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiStyleMod_destroy(ImGuiStyleMod* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiStyleMod* ImGuiStyleMod_ImGuiStyleMod_Float([NativeTypeName("ImGuiStyleVar")] int idx, float v);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiStyleMod* ImGuiStyleMod_ImGuiStyleMod_Vec2([NativeTypeName("ImGuiStyleVar")] int idx, ImVec2 v);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiComboPreviewData* ImGuiComboPreviewData_ImGuiComboPreviewData();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiComboPreviewData_destroy(ImGuiComboPreviewData* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiMenuColumns* ImGuiMenuColumns_ImGuiMenuColumns();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiMenuColumns_destroy(ImGuiMenuColumns* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiMenuColumns_Update(ImGuiMenuColumns* self, float spacing, [NativeTypeName("bool")] byte window_reappearing);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float ImGuiMenuColumns_DeclColumns(ImGuiMenuColumns* self, float w_icon, float w_label, float w_shortcut, float w_mark);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiMenuColumns_CalcNextTotalWidth(ImGuiMenuColumns* self, [NativeTypeName("bool")] byte update_offsets);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiInputTextDeactivatedState* ImGuiInputTextDeactivatedState_ImGuiInputTextDeactivatedState();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiInputTextDeactivatedState_destroy(ImGuiInputTextDeactivatedState* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiInputTextDeactivatedState_ClearFreeMemory(ImGuiInputTextDeactivatedState* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiInputTextState* ImGuiInputTextState_ImGuiInputTextState();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiInputTextState_destroy(ImGuiInputTextState* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiInputTextState_ClearText(ImGuiInputTextState* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiInputTextState_ClearFreeMemory(ImGuiInputTextState* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int ImGuiInputTextState_GetUndoAvailCount(ImGuiInputTextState* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int ImGuiInputTextState_GetRedoAvailCount(ImGuiInputTextState* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiInputTextState_OnKeyPressed(ImGuiInputTextState* self, int key);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiInputTextState_CursorAnimReset(ImGuiInputTextState* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiInputTextState_CursorClamp(ImGuiInputTextState* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte ImGuiInputTextState_HasSelection(ImGuiInputTextState* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiInputTextState_ClearSelection(ImGuiInputTextState* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int ImGuiInputTextState_GetCursorPos(ImGuiInputTextState* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int ImGuiInputTextState_GetSelectionStart(ImGuiInputTextState* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int ImGuiInputTextState_GetSelectionEnd(ImGuiInputTextState* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiInputTextState_SelectAll(ImGuiInputTextState* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiPopupData* ImGuiPopupData_ImGuiPopupData();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiPopupData_destroy(ImGuiPopupData* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiNextWindowData* ImGuiNextWindowData_ImGuiNextWindowData();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiNextWindowData_destroy(ImGuiNextWindowData* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiNextWindowData_ClearFlags(ImGuiNextWindowData* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiNextItemData* ImGuiNextItemData_ImGuiNextItemData();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiNextItemData_destroy(ImGuiNextItemData* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiNextItemData_ClearFlags(ImGuiNextItemData* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiLastItemData* ImGuiLastItemData_ImGuiLastItemData();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiLastItemData_destroy(ImGuiLastItemData* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiStackSizes* ImGuiStackSizes_ImGuiStackSizes();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiStackSizes_destroy(ImGuiStackSizes* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiStackSizes_SetToContextState(ImGuiStackSizes* self, ImGuiContext* ctx);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiStackSizes_CompareWithContextState(ImGuiStackSizes* self, ImGuiContext* ctx);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiPtrOrIndex* ImGuiPtrOrIndex_ImGuiPtrOrIndex_Ptr(void* ptr);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiPtrOrIndex_destroy(ImGuiPtrOrIndex* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiPtrOrIndex* ImGuiPtrOrIndex_ImGuiPtrOrIndex_Int(int index);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiInputEvent* ImGuiInputEvent_ImGuiInputEvent();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiInputEvent_destroy(ImGuiInputEvent* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiKeyRoutingData* ImGuiKeyRoutingData_ImGuiKeyRoutingData();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiKeyRoutingData_destroy(ImGuiKeyRoutingData* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiKeyRoutingTable* ImGuiKeyRoutingTable_ImGuiKeyRoutingTable();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiKeyRoutingTable_destroy(ImGuiKeyRoutingTable* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiKeyRoutingTable_Clear(ImGuiKeyRoutingTable* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiKeyOwnerData* ImGuiKeyOwnerData_ImGuiKeyOwnerData();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiKeyOwnerData_destroy(ImGuiKeyOwnerData* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiListClipperRange ImGuiListClipperRange_FromIndices(int min, int max);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiListClipperRange ImGuiListClipperRange_FromPositions(float y1, float y2, int off_min, int off_max);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiListClipperData* ImGuiListClipperData_ImGuiListClipperData();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiListClipperData_destroy(ImGuiListClipperData* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiListClipperData_Reset(ImGuiListClipperData* self, ImGuiListClipper* clipper);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiNavItemData* ImGuiNavItemData_ImGuiNavItemData();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiNavItemData_destroy(ImGuiNavItemData* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiNavItemData_Clear(ImGuiNavItemData* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiTypingSelectState* ImGuiTypingSelectState_ImGuiTypingSelectState();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiTypingSelectState_destroy(ImGuiTypingSelectState* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiTypingSelectState_Clear(ImGuiTypingSelectState* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiOldColumnData* ImGuiOldColumnData_ImGuiOldColumnData();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiOldColumnData_destroy(ImGuiOldColumnData* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiOldColumns* ImGuiOldColumns_ImGuiOldColumns();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiOldColumns_destroy(ImGuiOldColumns* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiDockNode* ImGuiDockNode_ImGuiDockNode([NativeTypeName("ImGuiID")] uint id);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiDockNode_destroy(ImGuiDockNode* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte ImGuiDockNode_IsRootNode(ImGuiDockNode* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte ImGuiDockNode_IsDockSpace(ImGuiDockNode* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte ImGuiDockNode_IsFloatingNode(ImGuiDockNode* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte ImGuiDockNode_IsCentralNode(ImGuiDockNode* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte ImGuiDockNode_IsHiddenTabBar(ImGuiDockNode* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte ImGuiDockNode_IsNoTabBar(ImGuiDockNode* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte ImGuiDockNode_IsSplitNode(ImGuiDockNode* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte ImGuiDockNode_IsLeafNode(ImGuiDockNode* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte ImGuiDockNode_IsEmpty(ImGuiDockNode* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiDockNode_Rect(ImRect* pOut, ImGuiDockNode* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiDockNode_SetLocalFlags(ImGuiDockNode* self, [NativeTypeName("ImGuiDockNodeFlags")] int flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiDockNode_UpdateMergedFlags(ImGuiDockNode* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiDockContext* ImGuiDockContext_ImGuiDockContext();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiDockContext_destroy(ImGuiDockContext* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiViewportP* ImGuiViewportP_ImGuiViewportP();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiViewportP_destroy(ImGuiViewportP* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiViewportP_ClearRequestFlags(ImGuiViewportP* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiViewportP_CalcWorkRectPos(ImVec2* pOut, ImGuiViewportP* self, [NativeTypeName("const ImVec2")] ImVec2 off_min);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiViewportP_CalcWorkRectSize(ImVec2* pOut, ImGuiViewportP* self, [NativeTypeName("const ImVec2")] ImVec2 off_min, [NativeTypeName("const ImVec2")] ImVec2 off_max);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiViewportP_UpdateWorkRect(ImGuiViewportP* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiViewportP_GetMainRect(ImRect* pOut, ImGuiViewportP* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiViewportP_GetWorkRect(ImRect* pOut, ImGuiViewportP* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiViewportP_GetBuildWorkRect(ImRect* pOut, ImGuiViewportP* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiWindowSettings* ImGuiWindowSettings_ImGuiWindowSettings();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiWindowSettings_destroy(ImGuiWindowSettings* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("char *")]
    public static extern sbyte* ImGuiWindowSettings_GetName(ImGuiWindowSettings* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiSettingsHandler* ImGuiSettingsHandler_ImGuiSettingsHandler();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiSettingsHandler_destroy(ImGuiSettingsHandler* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiDebugAllocInfo* ImGuiDebugAllocInfo_ImGuiDebugAllocInfo();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiDebugAllocInfo_destroy(ImGuiDebugAllocInfo* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiStackLevelInfo* ImGuiStackLevelInfo_ImGuiStackLevelInfo();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiStackLevelInfo_destroy(ImGuiStackLevelInfo* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiIDStackTool* ImGuiIDStackTool_ImGuiIDStackTool();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiIDStackTool_destroy(ImGuiIDStackTool* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiContextHook* ImGuiContextHook_ImGuiContextHook();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiContextHook_destroy(ImGuiContextHook* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiContext* ImGuiContext_ImGuiContext(ImFontAtlas* shared_font_atlas);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiContext_destroy(ImGuiContext* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiWindow* ImGuiWindow_ImGuiWindow(ImGuiContext* context, [NativeTypeName("const char *")] sbyte* name);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiWindow_destroy(ImGuiWindow* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("ImGuiID")]
    public static extern uint ImGuiWindow_GetID_Str(ImGuiWindow* self, [NativeTypeName("const char *")] sbyte* str, [NativeTypeName("const char *")] sbyte* str_end);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("ImGuiID")]
    public static extern uint ImGuiWindow_GetID_Ptr(ImGuiWindow* self, [NativeTypeName("const void *")] void* ptr);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("ImGuiID")]
    public static extern uint ImGuiWindow_GetID_Int(ImGuiWindow* self, int n);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("ImGuiID")]
    public static extern uint ImGuiWindow_GetIDFromRectangle(ImGuiWindow* self, [NativeTypeName("const ImRect")] ImRect r_abs);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiWindow_Rect(ImRect* pOut, ImGuiWindow* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float ImGuiWindow_CalcFontSize(ImGuiWindow* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float ImGuiWindow_TitleBarHeight(ImGuiWindow* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiWindow_TitleBarRect(ImRect* pOut, ImGuiWindow* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float ImGuiWindow_MenuBarHeight(ImGuiWindow* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiWindow_MenuBarRect(ImRect* pOut, ImGuiWindow* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiTabItem* ImGuiTabItem_ImGuiTabItem();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiTabItem_destroy(ImGuiTabItem* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiTabBar* ImGuiTabBar_ImGuiTabBar();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiTabBar_destroy(ImGuiTabBar* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiTableColumn* ImGuiTableColumn_ImGuiTableColumn();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiTableColumn_destroy(ImGuiTableColumn* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiTableInstanceData* ImGuiTableInstanceData_ImGuiTableInstanceData();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiTableInstanceData_destroy(ImGuiTableInstanceData* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiTable* ImGuiTable_ImGuiTable();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiTable_destroy(ImGuiTable* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiTableTempData* ImGuiTableTempData_ImGuiTableTempData();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiTableTempData_destroy(ImGuiTableTempData* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiTableColumnSettings* ImGuiTableColumnSettings_ImGuiTableColumnSettings();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiTableColumnSettings_destroy(ImGuiTableColumnSettings* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiTableSettings* ImGuiTableSettings_ImGuiTableSettings();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiTableSettings_destroy(ImGuiTableSettings* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiTableColumnSettings* ImGuiTableSettings_GetColumnSettings(ImGuiTableSettings* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiWindow* igGetCurrentWindowRead();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiWindow* igGetCurrentWindow();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiWindow* igFindWindowByID([NativeTypeName("ImGuiID")] uint id);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiWindow* igFindWindowByName([NativeTypeName("const char *")] sbyte* name);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igUpdateWindowParentAndRootLinks(ImGuiWindow* window, [NativeTypeName("ImGuiWindowFlags")] int flags, ImGuiWindow* parent_window);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igCalcWindowNextAutoFitSize(ImVec2* pOut, ImGuiWindow* window);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igIsWindowChildOf(ImGuiWindow* window, ImGuiWindow* potential_parent, [NativeTypeName("bool")] byte popup_hierarchy, [NativeTypeName("bool")] byte dock_hierarchy);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igIsWindowWithinBeginStackOf(ImGuiWindow* window, ImGuiWindow* potential_parent);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igIsWindowAbove(ImGuiWindow* potential_above, ImGuiWindow* potential_below);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igIsWindowNavFocusable(ImGuiWindow* window);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igSetWindowPos_WindowPtr(ImGuiWindow* window, [NativeTypeName("const ImVec2")] ImVec2 pos, [NativeTypeName("ImGuiCond")] int cond);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igSetWindowSize_WindowPtr(ImGuiWindow* window, [NativeTypeName("const ImVec2")] ImVec2 size, [NativeTypeName("ImGuiCond")] int cond);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igSetWindowCollapsed_WindowPtr(ImGuiWindow* window, [NativeTypeName("bool")] byte collapsed, [NativeTypeName("ImGuiCond")] int cond);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igSetWindowHitTestHole(ImGuiWindow* window, [NativeTypeName("const ImVec2")] ImVec2 pos, [NativeTypeName("const ImVec2")] ImVec2 size);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igSetWindowHiddendAndSkipItemsForCurrentFrame(ImGuiWindow* window);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igWindowRectAbsToRel(ImRect* pOut, ImGuiWindow* window, [NativeTypeName("const ImRect")] ImRect r);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igWindowRectRelToAbs(ImRect* pOut, ImGuiWindow* window, [NativeTypeName("const ImRect")] ImRect r);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igWindowPosRelToAbs(ImVec2* pOut, ImGuiWindow* window, [NativeTypeName("const ImVec2")] ImVec2 p);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igFocusWindow(ImGuiWindow* window, [NativeTypeName("ImGuiFocusRequestFlags")] int flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igFocusTopMostWindowUnderOne(ImGuiWindow* under_this_window, ImGuiWindow* ignore_window, ImGuiViewport* filter_viewport, [NativeTypeName("ImGuiFocusRequestFlags")] int flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igBringWindowToFocusFront(ImGuiWindow* window);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igBringWindowToDisplayFront(ImGuiWindow* window);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igBringWindowToDisplayBack(ImGuiWindow* window);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igBringWindowToDisplayBehind(ImGuiWindow* window, ImGuiWindow* above_window);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int igFindWindowDisplayIndex(ImGuiWindow* window);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiWindow* igFindBottomMostVisibleWindowWithinBeginStack(ImGuiWindow* window);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igSetCurrentFont(ImFont* font);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImFont* igGetDefaultFont();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImDrawList* igGetForegroundDrawList_WindowPtr(ImGuiWindow* window);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igAddDrawListToDrawDataEx(ImDrawData* draw_data, ImVector_ImDrawListPtr* out_list, ImDrawList* draw_list);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igInitialize();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igShutdown();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igUpdateInputEvents([NativeTypeName("bool")] byte trickle_fast_inputs);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igUpdateHoveredWindowAndCaptureFlags();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igStartMouseMovingWindow(ImGuiWindow* window);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igStartMouseMovingWindowOrNode(ImGuiWindow* window, ImGuiDockNode* node, [NativeTypeName("bool")] byte undock);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igUpdateMouseMovingWindowNewFrame();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igUpdateMouseMovingWindowEndFrame();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("ImGuiID")]
    public static extern uint igAddContextHook(ImGuiContext* context, [NativeTypeName("const ImGuiContextHook *")] ImGuiContextHook* hook);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igRemoveContextHook(ImGuiContext* context, [NativeTypeName("ImGuiID")] uint hook_to_remove);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igCallContextHooks(ImGuiContext* context, ImGuiContextHookType type);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igTranslateWindowsInViewport(ImGuiViewportP* viewport, [NativeTypeName("const ImVec2")] ImVec2 old_pos, [NativeTypeName("const ImVec2")] ImVec2 new_pos);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igScaleWindowsInViewport(ImGuiViewportP* viewport, float scale);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igDestroyPlatformWindow(ImGuiViewportP* viewport);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igSetWindowViewport(ImGuiWindow* window, ImGuiViewportP* viewport);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igSetCurrentViewport(ImGuiWindow* window, ImGuiViewportP* viewport);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const ImGuiPlatformMonitor *")]
    public static extern ImGuiPlatformMonitor* igGetViewportPlatformMonitor(ImGuiViewport* viewport);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiViewportP* igFindHoveredViewportFromPlatformWindowStack([NativeTypeName("const ImVec2")] ImVec2 mouse_platform_pos);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igMarkIniSettingsDirty_Nil();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igMarkIniSettingsDirty_WindowPtr(ImGuiWindow* window);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igClearIniSettings();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igAddSettingsHandler([NativeTypeName("const ImGuiSettingsHandler *")] ImGuiSettingsHandler* handler);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igRemoveSettingsHandler([NativeTypeName("const char *")] sbyte* type_name);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiSettingsHandler* igFindSettingsHandler([NativeTypeName("const char *")] sbyte* type_name);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiWindowSettings* igCreateNewWindowSettings([NativeTypeName("const char *")] sbyte* name);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiWindowSettings* igFindWindowSettingsByID([NativeTypeName("ImGuiID")] uint id);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiWindowSettings* igFindWindowSettingsByWindow(ImGuiWindow* window);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igClearWindowSettings([NativeTypeName("const char *")] sbyte* name);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igLocalizeRegisterEntries([NativeTypeName("const ImGuiLocEntry *")] ImGuiLocEntry* entries, int count);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* igLocalizeGetMsg(ImGuiLocKey key);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igSetScrollX_WindowPtr(ImGuiWindow* window, float scroll_x);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igSetScrollY_WindowPtr(ImGuiWindow* window, float scroll_y);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igSetScrollFromPosX_WindowPtr(ImGuiWindow* window, float local_x, float center_x_ratio);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igSetScrollFromPosY_WindowPtr(ImGuiWindow* window, float local_y, float center_y_ratio);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igScrollToItem([NativeTypeName("ImGuiScrollFlags")] int flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igScrollToRect(ImGuiWindow* window, [NativeTypeName("const ImRect")] ImRect rect, [NativeTypeName("ImGuiScrollFlags")] int flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igScrollToRectEx(ImVec2* pOut, ImGuiWindow* window, [NativeTypeName("const ImRect")] ImRect rect, [NativeTypeName("ImGuiScrollFlags")] int flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igScrollToBringRectIntoView(ImGuiWindow* window, [NativeTypeName("const ImRect")] ImRect rect);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("ImGuiItemStatusFlags")]
    public static extern int igGetItemStatusFlags();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("ImGuiItemFlags")]
    public static extern int igGetItemFlags();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("ImGuiID")]
    public static extern uint igGetActiveID();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("ImGuiID")]
    public static extern uint igGetFocusID();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igSetActiveID([NativeTypeName("ImGuiID")] uint id, ImGuiWindow* window);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igSetFocusID([NativeTypeName("ImGuiID")] uint id, ImGuiWindow* window);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igClearActiveID();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("ImGuiID")]
    public static extern uint igGetHoveredID();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igSetHoveredID([NativeTypeName("ImGuiID")] uint id);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igKeepAliveID([NativeTypeName("ImGuiID")] uint id);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igMarkItemEdited([NativeTypeName("ImGuiID")] uint id);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igPushOverrideID([NativeTypeName("ImGuiID")] uint id);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("ImGuiID")]
    public static extern uint igGetIDWithSeed_Str([NativeTypeName("const char *")] sbyte* str_id_begin, [NativeTypeName("const char *")] sbyte* str_id_end, [NativeTypeName("ImGuiID")] uint seed);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("ImGuiID")]
    public static extern uint igGetIDWithSeed_Int(int n, [NativeTypeName("ImGuiID")] uint seed);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igItemSize_Vec2([NativeTypeName("const ImVec2")] ImVec2 size, float text_baseline_y);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igItemSize_Rect([NativeTypeName("const ImRect")] ImRect bb, float text_baseline_y);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igItemAdd([NativeTypeName("const ImRect")] ImRect bb, [NativeTypeName("ImGuiID")] uint id, [NativeTypeName("const ImRect *")] ImRect* nav_bb, [NativeTypeName("ImGuiItemFlags")] int extra_flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igItemHoverable([NativeTypeName("const ImRect")] ImRect bb, [NativeTypeName("ImGuiID")] uint id, [NativeTypeName("ImGuiItemFlags")] int item_flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igIsWindowContentHoverable(ImGuiWindow* window, [NativeTypeName("ImGuiHoveredFlags")] int flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igIsClippedEx([NativeTypeName("const ImRect")] ImRect bb, [NativeTypeName("ImGuiID")] uint id);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igSetLastItemData([NativeTypeName("ImGuiID")] uint item_id, [NativeTypeName("ImGuiItemFlags")] int in_flags, [NativeTypeName("ImGuiItemStatusFlags")] int status_flags, [NativeTypeName("const ImRect")] ImRect item_rect);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igCalcItemSize(ImVec2* pOut, ImVec2 size, float default_w, float default_h);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float igCalcWrapWidthForPos([NativeTypeName("const ImVec2")] ImVec2 pos, float wrap_pos_x);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igPushMultiItemsWidths(int components, float width_full);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igIsItemToggledSelection();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igGetContentRegionMaxAbs(ImVec2* pOut);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igShrinkWidths(ImGuiShrinkWidthItem* items, int count, float width_excess);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igPushItemFlag([NativeTypeName("ImGuiItemFlags")] int option, [NativeTypeName("bool")] byte enabled);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igPopItemFlag();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const ImGuiDataVarInfo *")]
    public static extern ImGuiDataVarInfo* igGetStyleVarInfo([NativeTypeName("ImGuiStyleVar")] int idx);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igLogBegin(ImGuiLogType type, int auto_open_depth);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igLogToBuffer(int auto_open_depth);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igLogRenderedText([NativeTypeName("const ImVec2 *")] ImVec2* ref_pos, [NativeTypeName("const char *")] sbyte* text, [NativeTypeName("const char *")] sbyte* text_end);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igLogSetNextTextDecoration([NativeTypeName("const char *")] sbyte* prefix, [NativeTypeName("const char *")] sbyte* suffix);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igBeginChildEx([NativeTypeName("const char *")] sbyte* name, [NativeTypeName("ImGuiID")] uint id, [NativeTypeName("const ImVec2")] ImVec2 size_arg, [NativeTypeName("ImGuiChildFlags")] int child_flags, [NativeTypeName("ImGuiWindowFlags")] int window_flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igOpenPopupEx([NativeTypeName("ImGuiID")] uint id, [NativeTypeName("ImGuiPopupFlags")] int popup_flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igClosePopupToLevel(int remaining, [NativeTypeName("bool")] byte restore_focus_to_window_under_popup);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igClosePopupsOverWindow(ImGuiWindow* ref_window, [NativeTypeName("bool")] byte restore_focus_to_window_under_popup);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igClosePopupsExceptModals();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igIsPopupOpen_ID([NativeTypeName("ImGuiID")] uint id, [NativeTypeName("ImGuiPopupFlags")] int popup_flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igBeginPopupEx([NativeTypeName("ImGuiID")] uint id, [NativeTypeName("ImGuiWindowFlags")] int extra_flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igBeginTooltipEx([NativeTypeName("ImGuiTooltipFlags")] int tooltip_flags, [NativeTypeName("ImGuiWindowFlags")] int extra_window_flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igBeginTooltipHidden();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igGetPopupAllowedExtentRect(ImRect* pOut, ImGuiWindow* window);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiWindow* igGetTopMostPopupModal();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiWindow* igGetTopMostAndVisiblePopupModal();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiWindow* igFindBlockingModal(ImGuiWindow* window);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igFindBestWindowPosForPopup(ImVec2* pOut, ImGuiWindow* window);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igFindBestWindowPosForPopupEx(ImVec2* pOut, [NativeTypeName("const ImVec2")] ImVec2 ref_pos, [NativeTypeName("const ImVec2")] ImVec2 size, [NativeTypeName("ImGuiDir *")] int* last_dir, [NativeTypeName("const ImRect")] ImRect r_outer, [NativeTypeName("const ImRect")] ImRect r_avoid, ImGuiPopupPositionPolicy policy);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igBeginViewportSideBar([NativeTypeName("const char *")] sbyte* name, ImGuiViewport* viewport, [NativeTypeName("ImGuiDir")] int dir, float size, [NativeTypeName("ImGuiWindowFlags")] int window_flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igBeginMenuEx([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("const char *")] sbyte* icon, [NativeTypeName("bool")] byte enabled);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igMenuItemEx([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("const char *")] sbyte* icon, [NativeTypeName("const char *")] sbyte* shortcut, [NativeTypeName("bool")] byte selected, [NativeTypeName("bool")] byte enabled);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igBeginComboPopup([NativeTypeName("ImGuiID")] uint popup_id, [NativeTypeName("const ImRect")] ImRect bb, [NativeTypeName("ImGuiComboFlags")] int flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igBeginComboPreview();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igEndComboPreview();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igNavInitWindow(ImGuiWindow* window, [NativeTypeName("bool")] byte force_reinit);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igNavInitRequestApplyResult();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igNavMoveRequestButNoResultYet();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igNavMoveRequestSubmit([NativeTypeName("ImGuiDir")] int move_dir, [NativeTypeName("ImGuiDir")] int clip_dir, [NativeTypeName("ImGuiNavMoveFlags")] int move_flags, [NativeTypeName("ImGuiScrollFlags")] int scroll_flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igNavMoveRequestForward([NativeTypeName("ImGuiDir")] int move_dir, [NativeTypeName("ImGuiDir")] int clip_dir, [NativeTypeName("ImGuiNavMoveFlags")] int move_flags, [NativeTypeName("ImGuiScrollFlags")] int scroll_flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igNavMoveRequestResolveWithLastItem(ImGuiNavItemData* result);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igNavMoveRequestResolveWithPastTreeNode(ImGuiNavItemData* result, ImGuiNavTreeNodeData* tree_node_data);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igNavMoveRequestCancel();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igNavMoveRequestApplyResult();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igNavMoveRequestTryWrapping(ImGuiWindow* window, [NativeTypeName("ImGuiNavMoveFlags")] int move_flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igNavClearPreferredPosForAxis(ImGuiAxis axis);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igNavRestoreHighlightAfterMove();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igNavUpdateCurrentWindowIsScrollPushableX();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igSetNavWindow(ImGuiWindow* window);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igSetNavID([NativeTypeName("ImGuiID")] uint id, ImGuiNavLayer nav_layer, [NativeTypeName("ImGuiID")] uint focus_scope_id, [NativeTypeName("const ImRect")] ImRect rect_rel);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igFocusItem();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igActivateItemByID([NativeTypeName("ImGuiID")] uint id);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igIsNamedKey(ImGuiKey key);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igIsNamedKeyOrModKey(ImGuiKey key);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igIsLegacyKey(ImGuiKey key);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igIsKeyboardKey(ImGuiKey key);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igIsGamepadKey(ImGuiKey key);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igIsMouseKey(ImGuiKey key);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igIsAliasKey(ImGuiKey key);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("ImGuiKeyChord")]
    public static extern int igConvertShortcutMod([NativeTypeName("ImGuiKeyChord")] int key_chord);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiKey igConvertSingleModFlagToKey(ImGuiContext* ctx, ImGuiKey key);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiKeyData* igGetKeyData_ContextPtr(ImGuiContext* ctx, ImGuiKey key);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiKeyData* igGetKeyData_Key(ImGuiKey key);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igGetKeyChordName([NativeTypeName("ImGuiKeyChord")] int key_chord, [NativeTypeName("char *")] sbyte* out_buf, int out_buf_size);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiKey igMouseButtonToKey([NativeTypeName("ImGuiMouseButton")] int button);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igIsMouseDragPastThreshold([NativeTypeName("ImGuiMouseButton")] int button, float lock_threshold);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igGetKeyMagnitude2d(ImVec2* pOut, ImGuiKey key_left, ImGuiKey key_right, ImGuiKey key_up, ImGuiKey key_down);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float igGetNavTweakPressedAmount(ImGuiAxis axis);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int igCalcTypematicRepeatAmount(float t0, float t1, float repeat_delay, float repeat_rate);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igGetTypematicRepeatRate([NativeTypeName("ImGuiInputFlags")] int flags, float* repeat_delay, float* repeat_rate);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igTeleportMousePos([NativeTypeName("const ImVec2")] ImVec2 pos);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igSetActiveIdUsingAllKeyboardKeys();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igIsActiveIdUsingNavDir([NativeTypeName("ImGuiDir")] int dir);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("ImGuiID")]
    public static extern uint igGetKeyOwner(ImGuiKey key);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igSetKeyOwner(ImGuiKey key, [NativeTypeName("ImGuiID")] uint owner_id, [NativeTypeName("ImGuiInputFlags")] int flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igSetKeyOwnersForKeyChord([NativeTypeName("ImGuiKeyChord")] int key, [NativeTypeName("ImGuiID")] uint owner_id, [NativeTypeName("ImGuiInputFlags")] int flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igSetItemKeyOwner(ImGuiKey key, [NativeTypeName("ImGuiInputFlags")] int flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igTestKeyOwner(ImGuiKey key, [NativeTypeName("ImGuiID")] uint owner_id);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiKeyOwnerData* igGetKeyOwnerData(ImGuiContext* ctx, ImGuiKey key);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igIsKeyDown_ID(ImGuiKey key, [NativeTypeName("ImGuiID")] uint owner_id);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igIsKeyPressed_ID(ImGuiKey key, [NativeTypeName("ImGuiID")] uint owner_id, [NativeTypeName("ImGuiInputFlags")] int flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igIsKeyReleased_ID(ImGuiKey key, [NativeTypeName("ImGuiID")] uint owner_id);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igIsMouseDown_ID([NativeTypeName("ImGuiMouseButton")] int button, [NativeTypeName("ImGuiID")] uint owner_id);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igIsMouseClicked_ID([NativeTypeName("ImGuiMouseButton")] int button, [NativeTypeName("ImGuiID")] uint owner_id, [NativeTypeName("ImGuiInputFlags")] int flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igIsMouseReleased_ID([NativeTypeName("ImGuiMouseButton")] int button, [NativeTypeName("ImGuiID")] uint owner_id);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igIsMouseDoubleClicked_ID([NativeTypeName("ImGuiMouseButton")] int button, [NativeTypeName("ImGuiID")] uint owner_id);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igIsKeyChordPressed_ID([NativeTypeName("ImGuiKeyChord")] int key_chord, [NativeTypeName("ImGuiID")] uint owner_id, [NativeTypeName("ImGuiInputFlags")] int flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igShortcut([NativeTypeName("ImGuiKeyChord")] int key_chord, [NativeTypeName("ImGuiID")] uint owner_id, [NativeTypeName("ImGuiInputFlags")] int flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igSetShortcutRouting([NativeTypeName("ImGuiKeyChord")] int key_chord, [NativeTypeName("ImGuiID")] uint owner_id, [NativeTypeName("ImGuiInputFlags")] int flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igTestShortcutRouting([NativeTypeName("ImGuiKeyChord")] int key_chord, [NativeTypeName("ImGuiID")] uint owner_id);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiKeyRoutingData* igGetShortcutRoutingData([NativeTypeName("ImGuiKeyChord")] int key_chord);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igDockContextInitialize(ImGuiContext* ctx);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igDockContextShutdown(ImGuiContext* ctx);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igDockContextClearNodes(ImGuiContext* ctx, [NativeTypeName("ImGuiID")] uint root_id, [NativeTypeName("bool")] byte clear_settings_refs);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igDockContextRebuildNodes(ImGuiContext* ctx);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igDockContextNewFrameUpdateUndocking(ImGuiContext* ctx);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igDockContextNewFrameUpdateDocking(ImGuiContext* ctx);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igDockContextEndFrame(ImGuiContext* ctx);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("ImGuiID")]
    public static extern uint igDockContextGenNodeID(ImGuiContext* ctx);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igDockContextQueueDock(ImGuiContext* ctx, ImGuiWindow* target, ImGuiDockNode* target_node, ImGuiWindow* payload, [NativeTypeName("ImGuiDir")] int split_dir, float split_ratio, [NativeTypeName("bool")] byte split_outer);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igDockContextQueueUndockWindow(ImGuiContext* ctx, ImGuiWindow* window);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igDockContextQueueUndockNode(ImGuiContext* ctx, ImGuiDockNode* node);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igDockContextProcessUndockWindow(ImGuiContext* ctx, ImGuiWindow* window, [NativeTypeName("bool")] byte clear_persistent_docking_ref);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igDockContextProcessUndockNode(ImGuiContext* ctx, ImGuiDockNode* node);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igDockContextCalcDropPosForDocking(ImGuiWindow* target, ImGuiDockNode* target_node, ImGuiWindow* payload_window, ImGuiDockNode* payload_node, [NativeTypeName("ImGuiDir")] int split_dir, [NativeTypeName("bool")] byte split_outer, ImVec2* out_pos);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiDockNode* igDockContextFindNodeByID(ImGuiContext* ctx, [NativeTypeName("ImGuiID")] uint id);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igDockNodeWindowMenuHandler_Default(ImGuiContext* ctx, ImGuiDockNode* node, ImGuiTabBar* tab_bar);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igDockNodeBeginAmendTabBar(ImGuiDockNode* node);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igDockNodeEndAmendTabBar();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiDockNode* igDockNodeGetRootNode(ImGuiDockNode* node);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igDockNodeIsInHierarchyOf(ImGuiDockNode* node, ImGuiDockNode* parent);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int igDockNodeGetDepth([NativeTypeName("const ImGuiDockNode *")] ImGuiDockNode* node);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("ImGuiID")]
    public static extern uint igDockNodeGetWindowMenuButtonId([NativeTypeName("const ImGuiDockNode *")] ImGuiDockNode* node);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiDockNode* igGetWindowDockNode();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igGetWindowAlwaysWantOwnTabBar(ImGuiWindow* window);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igBeginDocked(ImGuiWindow* window, bool* p_open);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igBeginDockableDragDropSource(ImGuiWindow* window);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igBeginDockableDragDropTarget(ImGuiWindow* window);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igSetWindowDock(ImGuiWindow* window, [NativeTypeName("ImGuiID")] uint dock_id, [NativeTypeName("ImGuiCond")] int cond);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igDockBuilderDockWindow([NativeTypeName("const char *")] sbyte* window_name, [NativeTypeName("ImGuiID")] uint node_id);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiDockNode* igDockBuilderGetNode([NativeTypeName("ImGuiID")] uint node_id);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiDockNode* igDockBuilderGetCentralNode([NativeTypeName("ImGuiID")] uint node_id);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("ImGuiID")]
    public static extern uint igDockBuilderAddNode([NativeTypeName("ImGuiID")] uint node_id, [NativeTypeName("ImGuiDockNodeFlags")] int flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igDockBuilderRemoveNode([NativeTypeName("ImGuiID")] uint node_id);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igDockBuilderRemoveNodeDockedWindows([NativeTypeName("ImGuiID")] uint node_id, [NativeTypeName("bool")] byte clear_settings_refs);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igDockBuilderRemoveNodeChildNodes([NativeTypeName("ImGuiID")] uint node_id);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igDockBuilderSetNodePos([NativeTypeName("ImGuiID")] uint node_id, ImVec2 pos);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igDockBuilderSetNodeSize([NativeTypeName("ImGuiID")] uint node_id, ImVec2 size);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("ImGuiID")]
    public static extern uint igDockBuilderSplitNode([NativeTypeName("ImGuiID")] uint node_id, [NativeTypeName("ImGuiDir")] int split_dir, float size_ratio_for_node_at_dir, [NativeTypeName("ImGuiID *")] uint* out_id_at_dir, [NativeTypeName("ImGuiID *")] uint* out_id_at_opposite_dir);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igDockBuilderCopyDockSpace([NativeTypeName("ImGuiID")] uint src_dockspace_id, [NativeTypeName("ImGuiID")] uint dst_dockspace_id, ImVector_const_charPtr* in_window_remap_pairs);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igDockBuilderCopyNode([NativeTypeName("ImGuiID")] uint src_node_id, [NativeTypeName("ImGuiID")] uint dst_node_id, ImVector_ImGuiID* out_node_remap_pairs);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igDockBuilderCopyWindowSettings([NativeTypeName("const char *")] sbyte* src_name, [NativeTypeName("const char *")] sbyte* dst_name);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igDockBuilderFinish([NativeTypeName("ImGuiID")] uint node_id);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igPushFocusScope([NativeTypeName("ImGuiID")] uint id);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igPopFocusScope();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("ImGuiID")]
    public static extern uint igGetCurrentFocusScope();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igIsDragDropActive();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igBeginDragDropTargetCustom([NativeTypeName("const ImRect")] ImRect bb, [NativeTypeName("ImGuiID")] uint id);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igClearDragDrop();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igIsDragDropPayloadBeingAccepted();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igRenderDragDropTargetRect([NativeTypeName("const ImRect")] ImRect bb);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiTypingSelectRequest* igGetTypingSelectRequest([NativeTypeName("ImGuiTypingSelectFlags")] int flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int igTypingSelectFindMatch(ImGuiTypingSelectRequest* req, int items_count, [NativeTypeName("const char *(*)(void *, int)")] delegate* unmanaged[Cdecl]<void*, int, sbyte*> get_item_name_func, void* user_data, int nav_item_idx);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int igTypingSelectFindNextSingleCharMatch(ImGuiTypingSelectRequest* req, int items_count, [NativeTypeName("const char *(*)(void *, int)")] delegate* unmanaged[Cdecl]<void*, int, sbyte*> get_item_name_func, void* user_data, int nav_item_idx);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int igTypingSelectFindBestLeadingMatch(ImGuiTypingSelectRequest* req, int items_count, [NativeTypeName("const char *(*)(void *, int)")] delegate* unmanaged[Cdecl]<void*, int, sbyte*> get_item_name_func, void* user_data);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igSetWindowClipRectBeforeSetChannel(ImGuiWindow* window, [NativeTypeName("const ImRect")] ImRect clip_rect);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igBeginColumns([NativeTypeName("const char *")] sbyte* str_id, int count, [NativeTypeName("ImGuiOldColumnFlags")] int flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igEndColumns();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igPushColumnClipRect(int column_index);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igPushColumnsBackground();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igPopColumnsBackground();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("ImGuiID")]
    public static extern uint igGetColumnsID([NativeTypeName("const char *")] sbyte* str_id, int count);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiOldColumns* igFindOrCreateColumns(ImGuiWindow* window, [NativeTypeName("ImGuiID")] uint id);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float igGetColumnOffsetFromNorm([NativeTypeName("const ImGuiOldColumns *")] ImGuiOldColumns* columns, float offset_norm);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float igGetColumnNormFromOffset([NativeTypeName("const ImGuiOldColumns *")] ImGuiOldColumns* columns, float offset);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igTableOpenContextMenu(int column_n);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igTableSetColumnWidth(int column_n, float width);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igTableSetColumnSortDirection(int column_n, [NativeTypeName("ImGuiSortDirection")] int sort_direction, [NativeTypeName("bool")] byte append_to_sort_specs);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int igTableGetHoveredColumn();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int igTableGetHoveredRow();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float igTableGetHeaderRowHeight();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float igTableGetHeaderAngledMaxLabelWidth();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igTablePushBackgroundChannel();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igTablePopBackgroundChannel();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igTableAngledHeadersRowEx(float angle, float label_width);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiTable* igGetCurrentTable();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiTable* igTableFindByID([NativeTypeName("ImGuiID")] uint id);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igBeginTableEx([NativeTypeName("const char *")] sbyte* name, [NativeTypeName("ImGuiID")] uint id, int columns_count, [NativeTypeName("ImGuiTableFlags")] int flags, [NativeTypeName("const ImVec2")] ImVec2 outer_size, float inner_width);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igTableBeginInitMemory(ImGuiTable* table, int columns_count);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igTableBeginApplyRequests(ImGuiTable* table);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igTableSetupDrawChannels(ImGuiTable* table);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igTableUpdateLayout(ImGuiTable* table);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igTableUpdateBorders(ImGuiTable* table);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igTableUpdateColumnsWeightFromWidth(ImGuiTable* table);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igTableDrawBorders(ImGuiTable* table);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igTableDrawDefaultContextMenu(ImGuiTable* table, [NativeTypeName("ImGuiTableFlags")] int flags_for_section_to_display);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igTableBeginContextMenuPopup(ImGuiTable* table);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igTableMergeDrawChannels(ImGuiTable* table);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiTableInstanceData* igTableGetInstanceData(ImGuiTable* table, int instance_no);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("ImGuiID")]
    public static extern uint igTableGetInstanceID(ImGuiTable* table, int instance_no);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igTableSortSpecsSanitize(ImGuiTable* table);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igTableSortSpecsBuild(ImGuiTable* table);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("ImGuiSortDirection")]
    public static extern int igTableGetColumnNextSortDirection(ImGuiTableColumn* column);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igTableFixColumnSortDirection(ImGuiTable* table, ImGuiTableColumn* column);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float igTableGetColumnWidthAuto(ImGuiTable* table, ImGuiTableColumn* column);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igTableBeginRow(ImGuiTable* table);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igTableEndRow(ImGuiTable* table);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igTableBeginCell(ImGuiTable* table, int column_n);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igTableEndCell(ImGuiTable* table);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igTableGetCellBgRect(ImRect* pOut, [NativeTypeName("const ImGuiTable *")] ImGuiTable* table, int column_n);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* igTableGetColumnName_TablePtr([NativeTypeName("const ImGuiTable *")] ImGuiTable* table, int column_n);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("ImGuiID")]
    public static extern uint igTableGetColumnResizeID(ImGuiTable* table, int column_n, int instance_no);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float igTableGetMaxColumnWidth([NativeTypeName("const ImGuiTable *")] ImGuiTable* table, int column_n);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igTableSetColumnWidthAutoSingle(ImGuiTable* table, int column_n);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igTableSetColumnWidthAutoAll(ImGuiTable* table);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igTableRemove(ImGuiTable* table);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igTableGcCompactTransientBuffers_TablePtr(ImGuiTable* table);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igTableGcCompactTransientBuffers_TableTempDataPtr(ImGuiTableTempData* table);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igTableGcCompactSettings();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igTableLoadSettings(ImGuiTable* table);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igTableSaveSettings(ImGuiTable* table);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igTableResetSettings(ImGuiTable* table);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiTableSettings* igTableGetBoundSettings(ImGuiTable* table);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igTableSettingsAddSettingsHandler();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiTableSettings* igTableSettingsCreate([NativeTypeName("ImGuiID")] uint id, int columns_count);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiTableSettings* igTableSettingsFindByID([NativeTypeName("ImGuiID")] uint id);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiTabBar* igGetCurrentTabBar();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igBeginTabBarEx(ImGuiTabBar* tab_bar, [NativeTypeName("const ImRect")] ImRect bb, [NativeTypeName("ImGuiTabBarFlags")] int flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiTabItem* igTabBarFindTabByID(ImGuiTabBar* tab_bar, [NativeTypeName("ImGuiID")] uint tab_id);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiTabItem* igTabBarFindTabByOrder(ImGuiTabBar* tab_bar, int order);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiTabItem* igTabBarFindMostRecentlySelectedTabForActiveWindow(ImGuiTabBar* tab_bar);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiTabItem* igTabBarGetCurrentTab(ImGuiTabBar* tab_bar);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int igTabBarGetTabOrder(ImGuiTabBar* tab_bar, ImGuiTabItem* tab);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* igTabBarGetTabName(ImGuiTabBar* tab_bar, ImGuiTabItem* tab);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igTabBarAddTab(ImGuiTabBar* tab_bar, [NativeTypeName("ImGuiTabItemFlags")] int tab_flags, ImGuiWindow* window);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igTabBarRemoveTab(ImGuiTabBar* tab_bar, [NativeTypeName("ImGuiID")] uint tab_id);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igTabBarCloseTab(ImGuiTabBar* tab_bar, ImGuiTabItem* tab);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igTabBarQueueFocus(ImGuiTabBar* tab_bar, ImGuiTabItem* tab);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igTabBarQueueReorder(ImGuiTabBar* tab_bar, ImGuiTabItem* tab, int offset);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igTabBarQueueReorderFromMousePos(ImGuiTabBar* tab_bar, ImGuiTabItem* tab, ImVec2 mouse_pos);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igTabBarProcessReorder(ImGuiTabBar* tab_bar);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igTabItemEx(ImGuiTabBar* tab_bar, [NativeTypeName("const char *")] sbyte* label, bool* p_open, [NativeTypeName("ImGuiTabItemFlags")] int flags, ImGuiWindow* docked_window);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igTabItemCalcSize_Str(ImVec2* pOut, [NativeTypeName("const char *")] sbyte* label, [NativeTypeName("bool")] byte has_close_button_or_unsaved_marker);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igTabItemCalcSize_WindowPtr(ImVec2* pOut, ImGuiWindow* window);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igTabItemBackground(ImDrawList* draw_list, [NativeTypeName("const ImRect")] ImRect bb, [NativeTypeName("ImGuiTabItemFlags")] int flags, [NativeTypeName("ImU32")] uint col);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igTabItemLabelAndCloseButton(ImDrawList* draw_list, [NativeTypeName("const ImRect")] ImRect bb, [NativeTypeName("ImGuiTabItemFlags")] int flags, ImVec2 frame_padding, [NativeTypeName("const char *")] sbyte* label, [NativeTypeName("ImGuiID")] uint tab_id, [NativeTypeName("ImGuiID")] uint close_button_id, [NativeTypeName("bool")] byte is_contents_visible, bool* out_just_closed, bool* out_text_clipped);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igRenderText(ImVec2 pos, [NativeTypeName("const char *")] sbyte* text, [NativeTypeName("const char *")] sbyte* text_end, [NativeTypeName("bool")] byte hide_text_after_hash);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igRenderTextWrapped(ImVec2 pos, [NativeTypeName("const char *")] sbyte* text, [NativeTypeName("const char *")] sbyte* text_end, float wrap_width);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igRenderTextClipped([NativeTypeName("const ImVec2")] ImVec2 pos_min, [NativeTypeName("const ImVec2")] ImVec2 pos_max, [NativeTypeName("const char *")] sbyte* text, [NativeTypeName("const char *")] sbyte* text_end, [NativeTypeName("const ImVec2 *")] ImVec2* text_size_if_known, [NativeTypeName("const ImVec2")] ImVec2 align, [NativeTypeName("const ImRect *")] ImRect* clip_rect);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igRenderTextClippedEx(ImDrawList* draw_list, [NativeTypeName("const ImVec2")] ImVec2 pos_min, [NativeTypeName("const ImVec2")] ImVec2 pos_max, [NativeTypeName("const char *")] sbyte* text, [NativeTypeName("const char *")] sbyte* text_end, [NativeTypeName("const ImVec2 *")] ImVec2* text_size_if_known, [NativeTypeName("const ImVec2")] ImVec2 align, [NativeTypeName("const ImRect *")] ImRect* clip_rect);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igRenderTextEllipsis(ImDrawList* draw_list, [NativeTypeName("const ImVec2")] ImVec2 pos_min, [NativeTypeName("const ImVec2")] ImVec2 pos_max, float clip_max_x, float ellipsis_max_x, [NativeTypeName("const char *")] sbyte* text, [NativeTypeName("const char *")] sbyte* text_end, [NativeTypeName("const ImVec2 *")] ImVec2* text_size_if_known);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igRenderFrame(ImVec2 p_min, ImVec2 p_max, [NativeTypeName("ImU32")] uint fill_col, [NativeTypeName("bool")] byte border, float rounding);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igRenderFrameBorder(ImVec2 p_min, ImVec2 p_max, float rounding);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igRenderColorRectWithAlphaCheckerboard(ImDrawList* draw_list, ImVec2 p_min, ImVec2 p_max, [NativeTypeName("ImU32")] uint fill_col, float grid_step, ImVec2 grid_off, float rounding, [NativeTypeName("ImDrawFlags")] int flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igRenderNavHighlight([NativeTypeName("const ImRect")] ImRect bb, [NativeTypeName("ImGuiID")] uint id, [NativeTypeName("ImGuiNavHighlightFlags")] int flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* igFindRenderedTextEnd([NativeTypeName("const char *")] sbyte* text, [NativeTypeName("const char *")] sbyte* text_end);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igRenderMouseCursor(ImVec2 pos, float scale, [NativeTypeName("ImGuiMouseCursor")] int mouse_cursor, [NativeTypeName("ImU32")] uint col_fill, [NativeTypeName("ImU32")] uint col_border, [NativeTypeName("ImU32")] uint col_shadow);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igRenderArrow(ImDrawList* draw_list, ImVec2 pos, [NativeTypeName("ImU32")] uint col, [NativeTypeName("ImGuiDir")] int dir, float scale);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igRenderBullet(ImDrawList* draw_list, ImVec2 pos, [NativeTypeName("ImU32")] uint col);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igRenderCheckMark(ImDrawList* draw_list, ImVec2 pos, [NativeTypeName("ImU32")] uint col, float sz);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igRenderArrowPointingAt(ImDrawList* draw_list, ImVec2 pos, ImVec2 half_sz, [NativeTypeName("ImGuiDir")] int direction, [NativeTypeName("ImU32")] uint col);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igRenderArrowDockMenu(ImDrawList* draw_list, ImVec2 p_min, float sz, [NativeTypeName("ImU32")] uint col);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igRenderRectFilledRangeH(ImDrawList* draw_list, [NativeTypeName("const ImRect")] ImRect rect, [NativeTypeName("ImU32")] uint col, float x_start_norm, float x_end_norm, float rounding);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igRenderRectFilledWithHole(ImDrawList* draw_list, [NativeTypeName("const ImRect")] ImRect outer, [NativeTypeName("const ImRect")] ImRect inner, [NativeTypeName("ImU32")] uint col, float rounding);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("ImDrawFlags")]
    public static extern int igCalcRoundingFlagsForRectInRect([NativeTypeName("const ImRect")] ImRect r_in, [NativeTypeName("const ImRect")] ImRect r_outer, float threshold);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igTextEx([NativeTypeName("const char *")] sbyte* text, [NativeTypeName("const char *")] sbyte* text_end, [NativeTypeName("ImGuiTextFlags")] int flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igButtonEx([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("const ImVec2")] ImVec2 size_arg, [NativeTypeName("ImGuiButtonFlags")] int flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igArrowButtonEx([NativeTypeName("const char *")] sbyte* str_id, [NativeTypeName("ImGuiDir")] int dir, ImVec2 size_arg, [NativeTypeName("ImGuiButtonFlags")] int flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igImageButtonEx([NativeTypeName("ImGuiID")] uint id, [NativeTypeName("ImTextureID")] void* texture_id, [NativeTypeName("const ImVec2")] ImVec2 image_size, [NativeTypeName("const ImVec2")] ImVec2 uv0, [NativeTypeName("const ImVec2")] ImVec2 uv1, [NativeTypeName("const ImVec4")] ImVec4 bg_col, [NativeTypeName("const ImVec4")] ImVec4 tint_col, [NativeTypeName("ImGuiButtonFlags")] int flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igSeparatorEx([NativeTypeName("ImGuiSeparatorFlags")] int flags, float thickness);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igSeparatorTextEx([NativeTypeName("ImGuiID")] uint id, [NativeTypeName("const char *")] sbyte* label, [NativeTypeName("const char *")] sbyte* label_end, float extra_width);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igCheckboxFlags_S64Ptr([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("ImS64 *")] long* flags, [NativeTypeName("ImS64")] long flags_value);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igCheckboxFlags_U64Ptr([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("ImU64 *")] ulong* flags, [NativeTypeName("ImU64")] ulong flags_value);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igCloseButton([NativeTypeName("ImGuiID")] uint id, [NativeTypeName("const ImVec2")] ImVec2 pos);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igCollapseButton([NativeTypeName("ImGuiID")] uint id, [NativeTypeName("const ImVec2")] ImVec2 pos, ImGuiDockNode* dock_node);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igScrollbar(ImGuiAxis axis);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igScrollbarEx([NativeTypeName("const ImRect")] ImRect bb, [NativeTypeName("ImGuiID")] uint id, ImGuiAxis axis, [NativeTypeName("ImS64 *")] long* p_scroll_v, [NativeTypeName("ImS64")] long avail_v, [NativeTypeName("ImS64")] long contents_v, [NativeTypeName("ImDrawFlags")] int flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igGetWindowScrollbarRect(ImRect* pOut, ImGuiWindow* window, ImGuiAxis axis);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("ImGuiID")]
    public static extern uint igGetWindowScrollbarID(ImGuiWindow* window, ImGuiAxis axis);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("ImGuiID")]
    public static extern uint igGetWindowResizeCornerID(ImGuiWindow* window, int n);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("ImGuiID")]
    public static extern uint igGetWindowResizeBorderID(ImGuiWindow* window, [NativeTypeName("ImGuiDir")] int dir);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igButtonBehavior([NativeTypeName("const ImRect")] ImRect bb, [NativeTypeName("ImGuiID")] uint id, bool* out_hovered, bool* out_held, [NativeTypeName("ImGuiButtonFlags")] int flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igDragBehavior([NativeTypeName("ImGuiID")] uint id, [NativeTypeName("ImGuiDataType")] int data_type, void* p_v, float v_speed, [NativeTypeName("const void *")] void* p_min, [NativeTypeName("const void *")] void* p_max, [NativeTypeName("const char *")] sbyte* format, [NativeTypeName("ImGuiSliderFlags")] int flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igSliderBehavior([NativeTypeName("const ImRect")] ImRect bb, [NativeTypeName("ImGuiID")] uint id, [NativeTypeName("ImGuiDataType")] int data_type, void* p_v, [NativeTypeName("const void *")] void* p_min, [NativeTypeName("const void *")] void* p_max, [NativeTypeName("const char *")] sbyte* format, [NativeTypeName("ImGuiSliderFlags")] int flags, ImRect* out_grab_bb);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igSplitterBehavior([NativeTypeName("const ImRect")] ImRect bb, [NativeTypeName("ImGuiID")] uint id, ImGuiAxis axis, float* size1, float* size2, float min_size1, float min_size2, float hover_extend, float hover_visibility_delay, [NativeTypeName("ImU32")] uint bg_col);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igTreeNodeBehavior([NativeTypeName("ImGuiID")] uint id, [NativeTypeName("ImGuiTreeNodeFlags")] int flags, [NativeTypeName("const char *")] sbyte* label, [NativeTypeName("const char *")] sbyte* label_end);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igTreePushOverrideID([NativeTypeName("ImGuiID")] uint id);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igTreeNodeSetOpen([NativeTypeName("ImGuiID")] uint id, [NativeTypeName("bool")] byte open);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igTreeNodeUpdateNextOpen([NativeTypeName("ImGuiID")] uint id, [NativeTypeName("ImGuiTreeNodeFlags")] int flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igSetNextItemSelectionUserData([NativeTypeName("ImGuiSelectionUserData")] long selection_user_data);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const ImGuiDataTypeInfo *")]
    public static extern ImGuiDataTypeInfo* igDataTypeGetInfo([NativeTypeName("ImGuiDataType")] int data_type);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int igDataTypeFormatString([NativeTypeName("char *")] sbyte* buf, int buf_size, [NativeTypeName("ImGuiDataType")] int data_type, [NativeTypeName("const void *")] void* p_data, [NativeTypeName("const char *")] sbyte* format);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igDataTypeApplyOp([NativeTypeName("ImGuiDataType")] int data_type, int op, void* output, [NativeTypeName("const void *")] void* arg_1, [NativeTypeName("const void *")] void* arg_2);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igDataTypeApplyFromText([NativeTypeName("const char *")] sbyte* buf, [NativeTypeName("ImGuiDataType")] int data_type, void* p_data, [NativeTypeName("const char *")] sbyte* format);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int igDataTypeCompare([NativeTypeName("ImGuiDataType")] int data_type, [NativeTypeName("const void *")] void* arg_1, [NativeTypeName("const void *")] void* arg_2);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igDataTypeClamp([NativeTypeName("ImGuiDataType")] int data_type, void* p_data, [NativeTypeName("const void *")] void* p_min, [NativeTypeName("const void *")] void* p_max);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igInputTextEx([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("const char *")] sbyte* hint, [NativeTypeName("char *")] sbyte* buf, int buf_size, [NativeTypeName("const ImVec2")] ImVec2 size_arg, [NativeTypeName("ImGuiInputTextFlags")] int flags, [NativeTypeName("ImGuiInputTextCallback")] delegate* unmanaged[Cdecl]<ImGuiInputTextCallbackData*, int> callback, void* user_data);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igInputTextDeactivateHook([NativeTypeName("ImGuiID")] uint id);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igTempInputText([NativeTypeName("const ImRect")] ImRect bb, [NativeTypeName("ImGuiID")] uint id, [NativeTypeName("const char *")] sbyte* label, [NativeTypeName("char *")] sbyte* buf, int buf_size, [NativeTypeName("ImGuiInputTextFlags")] int flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igTempInputScalar([NativeTypeName("const ImRect")] ImRect bb, [NativeTypeName("ImGuiID")] uint id, [NativeTypeName("const char *")] sbyte* label, [NativeTypeName("ImGuiDataType")] int data_type, void* p_data, [NativeTypeName("const char *")] sbyte* format, [NativeTypeName("const void *")] void* p_clamp_min, [NativeTypeName("const void *")] void* p_clamp_max);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte igTempInputIsActive([NativeTypeName("ImGuiID")] uint id);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImGuiInputTextState* igGetInputTextState([NativeTypeName("ImGuiID")] uint id);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igColorTooltip([NativeTypeName("const char *")] sbyte* text, [NativeTypeName("const float *")] float* col, [NativeTypeName("ImGuiColorEditFlags")] int flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igColorEditOptionsPopup([NativeTypeName("const float *")] float* col, [NativeTypeName("ImGuiColorEditFlags")] int flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igColorPickerOptionsPopup([NativeTypeName("const float *")] float* ref_col, [NativeTypeName("ImGuiColorEditFlags")] int flags);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int igPlotEx(ImGuiPlotType plot_type, [NativeTypeName("const char *")] sbyte* label, [NativeTypeName("float (*)(void *, int)")] delegate* unmanaged[Cdecl]<void*, int, float> values_getter, void* data, int values_count, int values_offset, [NativeTypeName("const char *")] sbyte* overlay_text, float scale_min, float scale_max, [NativeTypeName("const ImVec2")] ImVec2 size_arg);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igShadeVertsLinearColorGradientKeepAlpha(ImDrawList* draw_list, int vert_start_idx, int vert_end_idx, ImVec2 gradient_p0, ImVec2 gradient_p1, [NativeTypeName("ImU32")] uint col0, [NativeTypeName("ImU32")] uint col1);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igShadeVertsLinearUV(ImDrawList* draw_list, int vert_start_idx, int vert_end_idx, [NativeTypeName("const ImVec2")] ImVec2 a, [NativeTypeName("const ImVec2")] ImVec2 b, [NativeTypeName("const ImVec2")] ImVec2 uv_a, [NativeTypeName("const ImVec2")] ImVec2 uv_b, [NativeTypeName("bool")] byte clamp);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igShadeVertsTransformPos(ImDrawList* draw_list, int vert_start_idx, int vert_end_idx, [NativeTypeName("const ImVec2")] ImVec2 pivot_in, float cos_a, float sin_a, [NativeTypeName("const ImVec2")] ImVec2 pivot_out);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igGcCompactTransientMiscBuffers();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igGcCompactTransientWindowBuffers(ImGuiWindow* window);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igGcAwakeTransientWindowBuffers(ImGuiWindow* window);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igDebugLog([NativeTypeName("const char *")] sbyte* fmt, __arglist);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igDebugLogV([NativeTypeName("const char *")] sbyte* fmt, [NativeTypeName("va_list")] sbyte* args);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igDebugAllocHook(ImGuiDebugAllocInfo* info, int frame_count, void* ptr, [NativeTypeName("size_t")] nuint size);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igErrorCheckEndFrameRecover([NativeTypeName("ImGuiErrorLogCallback")] delegate* unmanaged[Cdecl]<void*, sbyte*, void> log_callback, void* user_data);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igErrorCheckEndWindowRecover([NativeTypeName("ImGuiErrorLogCallback")] delegate* unmanaged[Cdecl]<void*, sbyte*, void> log_callback, void* user_data);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igErrorCheckUsingSetCursorPosToExtendParentBoundaries();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igDebugDrawCursorPos([NativeTypeName("ImU32")] uint col);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igDebugDrawLineExtents([NativeTypeName("ImU32")] uint col);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igDebugDrawItemRect([NativeTypeName("ImU32")] uint col);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igDebugLocateItem([NativeTypeName("ImGuiID")] uint target_id);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igDebugLocateItemOnHover([NativeTypeName("ImGuiID")] uint target_id);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igDebugLocateItemResolveWithLastItem();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igDebugStartItemPicker();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igShowFontAtlas(ImFontAtlas* atlas);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igDebugHookIdInfo([NativeTypeName("ImGuiID")] uint id, [NativeTypeName("ImGuiDataType")] int data_type, [NativeTypeName("const void *")] void* data_id, [NativeTypeName("const void *")] void* data_id_end);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igDebugNodeColumns(ImGuiOldColumns* columns);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igDebugNodeDockNode(ImGuiDockNode* node, [NativeTypeName("const char *")] sbyte* label);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igDebugNodeDrawList(ImGuiWindow* window, ImGuiViewportP* viewport, [NativeTypeName("const ImDrawList *")] ImDrawList* draw_list, [NativeTypeName("const char *")] sbyte* label);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igDebugNodeDrawCmdShowMeshAndBoundingBox(ImDrawList* out_draw_list, [NativeTypeName("const ImDrawList *")] ImDrawList* draw_list, [NativeTypeName("const ImDrawCmd *")] ImDrawCmd* draw_cmd, [NativeTypeName("bool")] byte show_mesh, [NativeTypeName("bool")] byte show_aabb);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igDebugNodeFont(ImFont* font);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igDebugNodeFontGlyph(ImFont* font, [NativeTypeName("const ImFontGlyph *")] ImFontGlyph* glyph);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igDebugNodeStorage(ImGuiStorage* storage, [NativeTypeName("const char *")] sbyte* label);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igDebugNodeTabBar(ImGuiTabBar* tab_bar, [NativeTypeName("const char *")] sbyte* label);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igDebugNodeTable(ImGuiTable* table);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igDebugNodeTableSettings(ImGuiTableSettings* settings);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igDebugNodeInputTextState(ImGuiInputTextState* state);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igDebugNodeTypingSelectState(ImGuiTypingSelectState* state);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igDebugNodeWindow(ImGuiWindow* window, [NativeTypeName("const char *")] sbyte* label);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igDebugNodeWindowSettings(ImGuiWindowSettings* settings);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igDebugNodeWindowsList(ImVector_ImGuiWindowPtr* windows, [NativeTypeName("const char *")] sbyte* label);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igDebugNodeWindowsListByBeginStackParent(ImGuiWindow** windows, int windows_size, ImGuiWindow* parent_in_begin_stack);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igDebugNodeViewport(ImGuiViewportP* viewport);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igDebugRenderKeyboardPreview(ImDrawList* draw_list);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igDebugRenderViewportThumbnail(ImDrawList* draw_list, ImGuiViewportP* viewport, [NativeTypeName("const ImRect")] ImRect bb);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const ImFontBuilderIO *")]
    public static extern ImFontBuilderIO* igImFontAtlasGetBuilderForStbTruetype();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igImFontAtlasUpdateConfigDataPointers(ImFontAtlas* atlas);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igImFontAtlasBuildInit(ImFontAtlas* atlas);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igImFontAtlasBuildSetupFont(ImFontAtlas* atlas, ImFont* font, ImFontConfig* font_config, float ascent, float descent);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igImFontAtlasBuildPackCustomRects(ImFontAtlas* atlas, void* stbrp_context_opaque);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igImFontAtlasBuildFinish(ImFontAtlas* atlas);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igImFontAtlasBuildRender8bppRectFromString(ImFontAtlas* atlas, int x, int y, int w, int h, [NativeTypeName("const char *")] sbyte* in_str, [NativeTypeName("char")] sbyte in_marker_char, [NativeTypeName("unsigned char")] byte in_marker_pixel_value);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igImFontAtlasBuildRender32bppRectFromString(ImFontAtlas* atlas, int x, int y, int w, int h, [NativeTypeName("const char *")] sbyte* in_str, [NativeTypeName("char")] sbyte in_marker_char, [NativeTypeName("unsigned int")] uint in_marker_pixel_value);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igImFontAtlasBuildMultiplyCalcLookupTable([NativeTypeName("unsigned char[256]")] byte* out_table, float in_multiply_factor);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igImFontAtlasBuildMultiplyRectAlpha8([NativeTypeName("const unsigned char[256]")] byte* table, [NativeTypeName("unsigned char *")] byte* pixels, int x, int y, int w, int h, int stride);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void igLogText([NativeTypeName("const char *")] sbyte* fmt, __arglist);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImGuiTextBuffer_appendf([NativeTypeName("struct ImGuiTextBuffer *")] ImGuiTextBuffer* buffer, [NativeTypeName("const char *")] sbyte* fmt, __arglist);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float igGET_FLT_MAX();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float igGET_FLT_MIN();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ImVector_ImWchar* ImVector_ImWchar_create();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImVector_ImWchar_destroy(ImVector_ImWchar* self);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImVector_ImWchar_Init(ImVector_ImWchar* p);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImVector_ImWchar_UnInit(ImVector_ImWchar* p);

    public const uint SIMGUI_INVALID_ID = 0;

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "simgui_setup", ExactSpelling = true)]
    public static extern void setup([NativeTypeName("const simgui_desc_t *")] simgui_desc_t* desc);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "simgui_new_frame", ExactSpelling = true)]
    public static extern void new_frame([NativeTypeName("const simgui_frame_desc_t *")] simgui_frame_desc_t* desc);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "simgui_render", ExactSpelling = true)]
    public static extern void render();

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "simgui_make_image", ExactSpelling = true)]
    public static extern simgui_image_t make_image([NativeTypeName("const simgui_image_desc_t *")] simgui_image_desc_t* desc);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "simgui_destroy_image", ExactSpelling = true)]
    public static extern void destroy_image(simgui_image_t img);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "simgui_query_image_desc", ExactSpelling = true)]
    public static extern simgui_image_desc_t query_image_desc(simgui_image_t img);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "simgui_imtextureid", ExactSpelling = true)]
    public static extern void* imtextureid(simgui_image_t img);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "simgui_image_from_imtextureid", ExactSpelling = true)]
    public static extern simgui_image_t image_from_imtextureid(void* imtextureid);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "simgui_add_focus_event", ExactSpelling = true)]
    public static extern void add_focus_event([NativeTypeName("bool")] byte focus);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "simgui_add_mouse_pos_event", ExactSpelling = true)]
    public static extern void add_mouse_pos_event(float x, float y);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "simgui_add_touch_pos_event", ExactSpelling = true)]
    public static extern void add_touch_pos_event(float x, float y);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "simgui_add_mouse_button_event", ExactSpelling = true)]
    public static extern void add_mouse_button_event(int mouse_button, [NativeTypeName("bool")] byte down);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "simgui_add_mouse_wheel_event", ExactSpelling = true)]
    public static extern void add_mouse_wheel_event(float wheel_x, float wheel_y);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "simgui_add_key_event", ExactSpelling = true)]
    public static extern void add_key_event([NativeTypeName("int (*)(int)")] delegate* unmanaged[Cdecl]<int, int> map_keycode, int keycode, [NativeTypeName("bool")] byte down);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "simgui_add_input_character", ExactSpelling = true)]
    public static extern void add_input_character([NativeTypeName("uint32_t")] uint c);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "simgui_add_input_characters_utf8", ExactSpelling = true)]
    public static extern void add_input_characters_utf8([NativeTypeName("const char *")] sbyte* c);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "simgui_add_touch_button_event", ExactSpelling = true)]
    public static extern void add_touch_button_event(int mouse_button, [NativeTypeName("bool")] byte down);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "simgui_handle_event", ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte handle_event([NativeTypeName("const sapp_event *")] sapp_event* ev);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "simgui_map_keycode", ExactSpelling = true)]
    public static extern int map_keycode(sapp_keycode keycode);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "simgui_shutdown", ExactSpelling = true)]
    public static extern void shutdown();
}
