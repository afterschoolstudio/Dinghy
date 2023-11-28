using System.Runtime.InteropServices;

namespace Dinghy.Internal.Sokol;

public partial struct simgui_image_t
{
    [NativeTypeName("uint32_t")]
    public uint id;
}

    public partial struct simgui_image_desc_t
    {
        public sg_image image;

        public sg_sampler sampler;
    }

    [NativeTypeName("unsigned int")]
    public enum simgui_log_item_t : uint
    {
        SIMGUI_LOGITEM_OK,
        SIMGUI_LOGITEM_MALLOC_FAILED,
        SIMGUI_LOGITEM_IMAGE_POOL_EXHAUSTED,
    }

    public unsafe partial struct simgui_allocator_t
    {
        [NativeTypeName("void *(*)(size_t, void *)")]
        public delegate* unmanaged[Cdecl]<nuint, void*, void*> alloc_fn;

        [NativeTypeName("void (*)(void *, void *)")]
        public delegate* unmanaged[Cdecl]<void*, void*, void> free_fn;

        public void* user_data;
    }

    public unsafe partial struct simgui_logger_t
    {
        [NativeTypeName("void (*)(const char *, uint32_t, uint32_t, const char *, uint32_t, const char *, void *)")]
        public delegate* unmanaged[Cdecl]<sbyte*, uint, uint, sbyte*, uint, sbyte*, void*, void> func;

        public void* user_data;
    }

    public unsafe partial struct simgui_desc_t
    {
        public int max_vertices;

        public int image_pool_size;

        public sg_pixel_format color_format;

        public sg_pixel_format depth_format;

        public int sample_count;

        [NativeTypeName("const char *")]
        public sbyte* ini_filename;

        [NativeTypeName("bool")]
        public byte no_default_font;

        [NativeTypeName("bool")]
        public byte disable_paste_override;

        [NativeTypeName("bool")]
        public byte disable_set_mouse_cursor;

        [NativeTypeName("bool")]
        public byte disable_windows_resize_from_edges;

        [NativeTypeName("bool")]
        public byte write_alpha_channel;

        public simgui_allocator_t allocator;

        public simgui_logger_t logger;
    }

    public partial struct simgui_frame_desc_t
    {
        public int width;

        public int height;

        public double delta_time;

        public float dpi_scale;
    }

    public static unsafe partial class ImGUI
    {
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
