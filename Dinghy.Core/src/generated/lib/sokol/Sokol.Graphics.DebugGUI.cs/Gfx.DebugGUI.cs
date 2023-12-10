using System.Runtime.InteropServices;

namespace Dinghy.Internal.Sokol;

public static unsafe partial class GfxDebugGUI
{
    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_imgui_init", ExactSpelling = true)]
    public static extern void init(sg_imgui_t* ctx, [NativeTypeName("const sg_imgui_desc_t *")] sg_imgui_desc_t* desc);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_imgui_discard", ExactSpelling = true)]
    public static extern void discard(sg_imgui_t* ctx);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_imgui_draw", ExactSpelling = true)]
    public static extern void draw(sg_imgui_t* ctx);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_imgui_draw_menu", ExactSpelling = true)]
    public static extern void draw_menu(sg_imgui_t* ctx, [NativeTypeName("const char *")] sbyte* title);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_imgui_draw_buffers_content", ExactSpelling = true)]
    public static extern void draw_buffers_content(sg_imgui_t* ctx);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_imgui_draw_images_content", ExactSpelling = true)]
    public static extern void draw_images_content(sg_imgui_t* ctx);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_imgui_draw_samplers_content", ExactSpelling = true)]
    public static extern void draw_samplers_content(sg_imgui_t* ctx);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_imgui_draw_shaders_content", ExactSpelling = true)]
    public static extern void draw_shaders_content(sg_imgui_t* ctx);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_imgui_draw_pipelines_content", ExactSpelling = true)]
    public static extern void draw_pipelines_content(sg_imgui_t* ctx);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_imgui_draw_passes_content", ExactSpelling = true)]
    public static extern void draw_passes_content(sg_imgui_t* ctx);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_imgui_draw_capture_content", ExactSpelling = true)]
    public static extern void draw_capture_content(sg_imgui_t* ctx);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_imgui_draw_capabilities_content", ExactSpelling = true)]
    public static extern void draw_capabilities_content(sg_imgui_t* ctx);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_imgui_draw_frame_stats_content", ExactSpelling = true)]
    public static extern void draw_frame_stats_content(sg_imgui_t* ctx);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_imgui_draw_buffers_window", ExactSpelling = true)]
    public static extern void draw_buffers_window(sg_imgui_t* ctx);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_imgui_draw_images_window", ExactSpelling = true)]
    public static extern void draw_images_window(sg_imgui_t* ctx);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_imgui_draw_samplers_window", ExactSpelling = true)]
    public static extern void draw_samplers_window(sg_imgui_t* ctx);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_imgui_draw_shaders_window", ExactSpelling = true)]
    public static extern void draw_shaders_window(sg_imgui_t* ctx);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_imgui_draw_pipelines_window", ExactSpelling = true)]
    public static extern void draw_pipelines_window(sg_imgui_t* ctx);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_imgui_draw_passes_window", ExactSpelling = true)]
    public static extern void draw_passes_window(sg_imgui_t* ctx);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_imgui_draw_capture_window", ExactSpelling = true)]
    public static extern void draw_capture_window(sg_imgui_t* ctx);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_imgui_draw_capabilities_window", ExactSpelling = true)]
    public static extern void draw_capabilities_window(sg_imgui_t* ctx);

    [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_imgui_draw_frame_stats_window", ExactSpelling = true)]
    public static extern void draw_frame_stats_window(sg_imgui_t* ctx);
}
