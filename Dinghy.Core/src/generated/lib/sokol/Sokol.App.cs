using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Dinghy.Internal.Sokol;

public enum sapp_event_type
{
    SAPP_EVENTTYPE_INVALID,
    SAPP_EVENTTYPE_KEY_DOWN,
    SAPP_EVENTTYPE_KEY_UP,
    SAPP_EVENTTYPE_CHAR,
    SAPP_EVENTTYPE_MOUSE_DOWN,
    SAPP_EVENTTYPE_MOUSE_UP,
    SAPP_EVENTTYPE_MOUSE_SCROLL,
    SAPP_EVENTTYPE_MOUSE_MOVE,
    SAPP_EVENTTYPE_MOUSE_ENTER,
    SAPP_EVENTTYPE_MOUSE_LEAVE,
    SAPP_EVENTTYPE_TOUCHES_BEGAN,
    SAPP_EVENTTYPE_TOUCHES_MOVED,
    SAPP_EVENTTYPE_TOUCHES_ENDED,
    SAPP_EVENTTYPE_TOUCHES_CANCELLED,
    SAPP_EVENTTYPE_RESIZED,
    SAPP_EVENTTYPE_ICONIFIED,
    SAPP_EVENTTYPE_RESTORED,
    SAPP_EVENTTYPE_FOCUSED,
    SAPP_EVENTTYPE_UNFOCUSED,
    SAPP_EVENTTYPE_SUSPENDED,
    SAPP_EVENTTYPE_RESUMED,
    SAPP_EVENTTYPE_QUIT_REQUESTED,
    SAPP_EVENTTYPE_CLIPBOARD_PASTED,
    SAPP_EVENTTYPE_FILES_DROPPED,
    _SAPP_EVENTTYPE_NUM,
    _SAPP_EVENTTYPE_FORCE_U32 = 0x7FFFFFFF,
}

    public enum sapp_keycode
    {
        SAPP_KEYCODE_INVALID = 0,
        SAPP_KEYCODE_SPACE = 32,
        SAPP_KEYCODE_APOSTROPHE = 39,
        SAPP_KEYCODE_COMMA = 44,
        SAPP_KEYCODE_MINUS = 45,
        SAPP_KEYCODE_PERIOD = 46,
        SAPP_KEYCODE_SLASH = 47,
        SAPP_KEYCODE_0 = 48,
        SAPP_KEYCODE_1 = 49,
        SAPP_KEYCODE_2 = 50,
        SAPP_KEYCODE_3 = 51,
        SAPP_KEYCODE_4 = 52,
        SAPP_KEYCODE_5 = 53,
        SAPP_KEYCODE_6 = 54,
        SAPP_KEYCODE_7 = 55,
        SAPP_KEYCODE_8 = 56,
        SAPP_KEYCODE_9 = 57,
        SAPP_KEYCODE_SEMICOLON = 59,
        SAPP_KEYCODE_EQUAL = 61,
        SAPP_KEYCODE_A = 65,
        SAPP_KEYCODE_B = 66,
        SAPP_KEYCODE_C = 67,
        SAPP_KEYCODE_D = 68,
        SAPP_KEYCODE_E = 69,
        SAPP_KEYCODE_F = 70,
        SAPP_KEYCODE_G = 71,
        SAPP_KEYCODE_H = 72,
        SAPP_KEYCODE_I = 73,
        SAPP_KEYCODE_J = 74,
        SAPP_KEYCODE_K = 75,
        SAPP_KEYCODE_L = 76,
        SAPP_KEYCODE_M = 77,
        SAPP_KEYCODE_N = 78,
        SAPP_KEYCODE_O = 79,
        SAPP_KEYCODE_P = 80,
        SAPP_KEYCODE_Q = 81,
        SAPP_KEYCODE_R = 82,
        SAPP_KEYCODE_S = 83,
        SAPP_KEYCODE_T = 84,
        SAPP_KEYCODE_U = 85,
        SAPP_KEYCODE_V = 86,
        SAPP_KEYCODE_W = 87,
        SAPP_KEYCODE_X = 88,
        SAPP_KEYCODE_Y = 89,
        SAPP_KEYCODE_Z = 90,
        SAPP_KEYCODE_LEFT_BRACKET = 91,
        SAPP_KEYCODE_BACKSLASH = 92,
        SAPP_KEYCODE_RIGHT_BRACKET = 93,
        SAPP_KEYCODE_GRAVE_ACCENT = 96,
        SAPP_KEYCODE_WORLD_1 = 161,
        SAPP_KEYCODE_WORLD_2 = 162,
        SAPP_KEYCODE_ESCAPE = 256,
        SAPP_KEYCODE_ENTER = 257,
        SAPP_KEYCODE_TAB = 258,
        SAPP_KEYCODE_BACKSPACE = 259,
        SAPP_KEYCODE_INSERT = 260,
        SAPP_KEYCODE_DELETE = 261,
        SAPP_KEYCODE_RIGHT = 262,
        SAPP_KEYCODE_LEFT = 263,
        SAPP_KEYCODE_DOWN = 264,
        SAPP_KEYCODE_UP = 265,
        SAPP_KEYCODE_PAGE_UP = 266,
        SAPP_KEYCODE_PAGE_DOWN = 267,
        SAPP_KEYCODE_HOME = 268,
        SAPP_KEYCODE_END = 269,
        SAPP_KEYCODE_CAPS_LOCK = 280,
        SAPP_KEYCODE_SCROLL_LOCK = 281,
        SAPP_KEYCODE_NUM_LOCK = 282,
        SAPP_KEYCODE_PRINT_SCREEN = 283,
        SAPP_KEYCODE_PAUSE = 284,
        SAPP_KEYCODE_F1 = 290,
        SAPP_KEYCODE_F2 = 291,
        SAPP_KEYCODE_F3 = 292,
        SAPP_KEYCODE_F4 = 293,
        SAPP_KEYCODE_F5 = 294,
        SAPP_KEYCODE_F6 = 295,
        SAPP_KEYCODE_F7 = 296,
        SAPP_KEYCODE_F8 = 297,
        SAPP_KEYCODE_F9 = 298,
        SAPP_KEYCODE_F10 = 299,
        SAPP_KEYCODE_F11 = 300,
        SAPP_KEYCODE_F12 = 301,
        SAPP_KEYCODE_F13 = 302,
        SAPP_KEYCODE_F14 = 303,
        SAPP_KEYCODE_F15 = 304,
        SAPP_KEYCODE_F16 = 305,
        SAPP_KEYCODE_F17 = 306,
        SAPP_KEYCODE_F18 = 307,
        SAPP_KEYCODE_F19 = 308,
        SAPP_KEYCODE_F20 = 309,
        SAPP_KEYCODE_F21 = 310,
        SAPP_KEYCODE_F22 = 311,
        SAPP_KEYCODE_F23 = 312,
        SAPP_KEYCODE_F24 = 313,
        SAPP_KEYCODE_F25 = 314,
        SAPP_KEYCODE_KP_0 = 320,
        SAPP_KEYCODE_KP_1 = 321,
        SAPP_KEYCODE_KP_2 = 322,
        SAPP_KEYCODE_KP_3 = 323,
        SAPP_KEYCODE_KP_4 = 324,
        SAPP_KEYCODE_KP_5 = 325,
        SAPP_KEYCODE_KP_6 = 326,
        SAPP_KEYCODE_KP_7 = 327,
        SAPP_KEYCODE_KP_8 = 328,
        SAPP_KEYCODE_KP_9 = 329,
        SAPP_KEYCODE_KP_DECIMAL = 330,
        SAPP_KEYCODE_KP_DIVIDE = 331,
        SAPP_KEYCODE_KP_MULTIPLY = 332,
        SAPP_KEYCODE_KP_SUBTRACT = 333,
        SAPP_KEYCODE_KP_ADD = 334,
        SAPP_KEYCODE_KP_ENTER = 335,
        SAPP_KEYCODE_KP_EQUAL = 336,
        SAPP_KEYCODE_LEFT_SHIFT = 340,
        SAPP_KEYCODE_LEFT_CONTROL = 341,
        SAPP_KEYCODE_LEFT_ALT = 342,
        SAPP_KEYCODE_LEFT_SUPER = 343,
        SAPP_KEYCODE_RIGHT_SHIFT = 344,
        SAPP_KEYCODE_RIGHT_CONTROL = 345,
        SAPP_KEYCODE_RIGHT_ALT = 346,
        SAPP_KEYCODE_RIGHT_SUPER = 347,
        SAPP_KEYCODE_MENU = 348,
    }

    public enum sapp_android_tooltype
    {
        SAPP_ANDROIDTOOLTYPE_UNKNOWN = 0,
        SAPP_ANDROIDTOOLTYPE_FINGER = 1,
        SAPP_ANDROIDTOOLTYPE_STYLUS = 2,
        SAPP_ANDROIDTOOLTYPE_MOUSE = 3,
    }

    public partial struct sapp_touchpoint
    {
        [NativeTypeName("uintptr_t")]
        public nuint identifier;

        public float pos_x;

        public float pos_y;

        public sapp_android_tooltype android_tooltype;

        [NativeTypeName("bool")]
        public byte changed;
    }

    public enum sapp_mousebutton
    {
        SAPP_MOUSEBUTTON_LEFT = 0x0,
        SAPP_MOUSEBUTTON_RIGHT = 0x1,
        SAPP_MOUSEBUTTON_MIDDLE = 0x2,
        SAPP_MOUSEBUTTON_INVALID = 0x100,
    }

    public partial struct sapp_event
    {
        [NativeTypeName("uint64_t")]
        public ulong frame_count;

        public sapp_event_type type;

        public sapp_keycode key_code;

        [NativeTypeName("uint32_t")]
        public uint char_code;

        [NativeTypeName("bool")]
        public byte key_repeat;

        [NativeTypeName("uint32_t")]
        public uint modifiers;

        public sapp_mousebutton mouse_button;

        public float mouse_x;

        public float mouse_y;

        public float mouse_dx;

        public float mouse_dy;

        public float scroll_x;

        public float scroll_y;

        public int num_touches;

        [NativeTypeName("sapp_touchpoint[8]")]
        public _touches_e__FixedBuffer touches;

        public int window_width;

        public int window_height;

        public int framebuffer_width;

        public int framebuffer_height;

        public partial struct _touches_e__FixedBuffer
        {
            public sapp_touchpoint e0;
            public sapp_touchpoint e1;
            public sapp_touchpoint e2;
            public sapp_touchpoint e3;
            public sapp_touchpoint e4;
            public sapp_touchpoint e5;
            public sapp_touchpoint e6;
            public sapp_touchpoint e7;

            [UnscopedRef]
            public ref sapp_touchpoint this[int index]
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get
                {
                    return ref AsSpan()[index];
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [UnscopedRef]
            public Span<sapp_touchpoint> AsSpan() => MemoryMarshal.CreateSpan(ref e0, 8);
        }
    }

    public unsafe partial struct sapp_range
    {
        [NativeTypeName("const void *")]
        public void* ptr;

        [NativeTypeName("size_t")]
        public nuint size;
    }

    public partial struct sapp_image_desc
    {
        public int width;

        public int height;

        public sapp_range pixels;
    }

    public partial struct sapp_icon_desc
    {
        [NativeTypeName("bool")]
        public byte sokol_default;

        [NativeTypeName("sapp_image_desc[8]")]
        public _images_e__FixedBuffer images;

        public partial struct _images_e__FixedBuffer
        {
            public sapp_image_desc e0;
            public sapp_image_desc e1;
            public sapp_image_desc e2;
            public sapp_image_desc e3;
            public sapp_image_desc e4;
            public sapp_image_desc e5;
            public sapp_image_desc e6;
            public sapp_image_desc e7;

            [UnscopedRef]
            public ref sapp_image_desc this[int index]
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get
                {
                    return ref AsSpan()[index];
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [UnscopedRef]
            public Span<sapp_image_desc> AsSpan() => MemoryMarshal.CreateSpan(ref e0, 8);
        }
    }

    public unsafe partial struct sapp_allocator
    {
        [NativeTypeName("void *(*)(size_t, void *)")]
        public delegate* unmanaged[Cdecl]<nuint, void*, void*> alloc;

        [NativeTypeName("void (*)(void *, void *)")]
        public delegate* unmanaged[Cdecl]<void*, void*, void> free;

        public void* user_data;
    }

    public enum sapp_log_item
    {
        SAPP_LOGITEM_OK,
        SAPP_LOGITEM_MALLOC_FAILED,
        SAPP_LOGITEM_MACOS_INVALID_NSOPENGL_PROFILE,
        SAPP_LOGITEM_WIN32_LOAD_OPENGL32_DLL_FAILED,
        SAPP_LOGITEM_WIN32_CREATE_HELPER_WINDOW_FAILED,
        SAPP_LOGITEM_WIN32_HELPER_WINDOW_GETDC_FAILED,
        SAPP_LOGITEM_WIN32_DUMMY_CONTEXT_SET_PIXELFORMAT_FAILED,
        SAPP_LOGITEM_WIN32_CREATE_DUMMY_CONTEXT_FAILED,
        SAPP_LOGITEM_WIN32_DUMMY_CONTEXT_MAKE_CURRENT_FAILED,
        SAPP_LOGITEM_WIN32_GET_PIXELFORMAT_ATTRIB_FAILED,
        SAPP_LOGITEM_WIN32_WGL_FIND_PIXELFORMAT_FAILED,
        SAPP_LOGITEM_WIN32_WGL_DESCRIBE_PIXELFORMAT_FAILED,
        SAPP_LOGITEM_WIN32_WGL_SET_PIXELFORMAT_FAILED,
        SAPP_LOGITEM_WIN32_WGL_ARB_CREATE_CONTEXT_REQUIRED,
        SAPP_LOGITEM_WIN32_WGL_ARB_CREATE_CONTEXT_PROFILE_REQUIRED,
        SAPP_LOGITEM_WIN32_WGL_OPENGL_3_2_NOT_SUPPORTED,
        SAPP_LOGITEM_WIN32_WGL_OPENGL_PROFILE_NOT_SUPPORTED,
        SAPP_LOGITEM_WIN32_WGL_INCOMPATIBLE_DEVICE_CONTEXT,
        SAPP_LOGITEM_WIN32_WGL_CREATE_CONTEXT_ATTRIBS_FAILED_OTHER,
        SAPP_LOGITEM_WIN32_D3D11_CREATE_DEVICE_AND_SWAPCHAIN_WITH_DEBUG_FAILED,
        SAPP_LOGITEM_WIN32_D3D11_GET_IDXGIFACTORY_FAILED,
        SAPP_LOGITEM_WIN32_D3D11_GET_IDXGIADAPTER_FAILED,
        SAPP_LOGITEM_WIN32_D3D11_QUERY_INTERFACE_IDXGIDEVICE1_FAILED,
        SAPP_LOGITEM_WIN32_REGISTER_RAW_INPUT_DEVICES_FAILED_MOUSE_LOCK,
        SAPP_LOGITEM_WIN32_REGISTER_RAW_INPUT_DEVICES_FAILED_MOUSE_UNLOCK,
        SAPP_LOGITEM_WIN32_GET_RAW_INPUT_DATA_FAILED,
        SAPP_LOGITEM_LINUX_GLX_LOAD_LIBGL_FAILED,
        SAPP_LOGITEM_LINUX_GLX_LOAD_ENTRY_POINTS_FAILED,
        SAPP_LOGITEM_LINUX_GLX_EXTENSION_NOT_FOUND,
        SAPP_LOGITEM_LINUX_GLX_QUERY_VERSION_FAILED,
        SAPP_LOGITEM_LINUX_GLX_VERSION_TOO_LOW,
        SAPP_LOGITEM_LINUX_GLX_NO_GLXFBCONFIGS,
        SAPP_LOGITEM_LINUX_GLX_NO_SUITABLE_GLXFBCONFIG,
        SAPP_LOGITEM_LINUX_GLX_GET_VISUAL_FROM_FBCONFIG_FAILED,
        SAPP_LOGITEM_LINUX_GLX_REQUIRED_EXTENSIONS_MISSING,
        SAPP_LOGITEM_LINUX_GLX_CREATE_CONTEXT_FAILED,
        SAPP_LOGITEM_LINUX_GLX_CREATE_WINDOW_FAILED,
        SAPP_LOGITEM_LINUX_X11_CREATE_WINDOW_FAILED,
        SAPP_LOGITEM_LINUX_EGL_BIND_OPENGL_API_FAILED,
        SAPP_LOGITEM_LINUX_EGL_BIND_OPENGL_ES_API_FAILED,
        SAPP_LOGITEM_LINUX_EGL_GET_DISPLAY_FAILED,
        SAPP_LOGITEM_LINUX_EGL_INITIALIZE_FAILED,
        SAPP_LOGITEM_LINUX_EGL_NO_CONFIGS,
        SAPP_LOGITEM_LINUX_EGL_NO_NATIVE_VISUAL,
        SAPP_LOGITEM_LINUX_EGL_GET_VISUAL_INFO_FAILED,
        SAPP_LOGITEM_LINUX_EGL_CREATE_WINDOW_SURFACE_FAILED,
        SAPP_LOGITEM_LINUX_EGL_CREATE_CONTEXT_FAILED,
        SAPP_LOGITEM_LINUX_EGL_MAKE_CURRENT_FAILED,
        SAPP_LOGITEM_LINUX_X11_OPEN_DISPLAY_FAILED,
        SAPP_LOGITEM_LINUX_X11_QUERY_SYSTEM_DPI_FAILED,
        SAPP_LOGITEM_LINUX_X11_DROPPED_FILE_URI_WRONG_SCHEME,
        SAPP_LOGITEM_ANDROID_UNSUPPORTED_INPUT_EVENT_INPUT_CB,
        SAPP_LOGITEM_ANDROID_UNSUPPORTED_INPUT_EVENT_MAIN_CB,
        SAPP_LOGITEM_ANDROID_READ_MSG_FAILED,
        SAPP_LOGITEM_ANDROID_WRITE_MSG_FAILED,
        SAPP_LOGITEM_ANDROID_MSG_CREATE,
        SAPP_LOGITEM_ANDROID_MSG_RESUME,
        SAPP_LOGITEM_ANDROID_MSG_PAUSE,
        SAPP_LOGITEM_ANDROID_MSG_FOCUS,
        SAPP_LOGITEM_ANDROID_MSG_NO_FOCUS,
        SAPP_LOGITEM_ANDROID_MSG_SET_NATIVE_WINDOW,
        SAPP_LOGITEM_ANDROID_MSG_SET_INPUT_QUEUE,
        SAPP_LOGITEM_ANDROID_MSG_DESTROY,
        SAPP_LOGITEM_ANDROID_UNKNOWN_MSG,
        SAPP_LOGITEM_ANDROID_LOOP_THREAD_STARTED,
        SAPP_LOGITEM_ANDROID_LOOP_THREAD_DONE,
        SAPP_LOGITEM_ANDROID_NATIVE_ACTIVITY_ONSTART,
        SAPP_LOGITEM_ANDROID_NATIVE_ACTIVITY_ONRESUME,
        SAPP_LOGITEM_ANDROID_NATIVE_ACTIVITY_ONSAVEINSTANCESTATE,
        SAPP_LOGITEM_ANDROID_NATIVE_ACTIVITY_ONWINDOWFOCUSCHANGED,
        SAPP_LOGITEM_ANDROID_NATIVE_ACTIVITY_ONPAUSE,
        SAPP_LOGITEM_ANDROID_NATIVE_ACTIVITY_ONSTOP,
        SAPP_LOGITEM_ANDROID_NATIVE_ACTIVITY_ONNATIVEWINDOWCREATED,
        SAPP_LOGITEM_ANDROID_NATIVE_ACTIVITY_ONNATIVEWINDOWDESTROYED,
        SAPP_LOGITEM_ANDROID_NATIVE_ACTIVITY_ONINPUTQUEUECREATED,
        SAPP_LOGITEM_ANDROID_NATIVE_ACTIVITY_ONINPUTQUEUEDESTROYED,
        SAPP_LOGITEM_ANDROID_NATIVE_ACTIVITY_ONCONFIGURATIONCHANGED,
        SAPP_LOGITEM_ANDROID_NATIVE_ACTIVITY_ONLOWMEMORY,
        SAPP_LOGITEM_ANDROID_NATIVE_ACTIVITY_ONDESTROY,
        SAPP_LOGITEM_ANDROID_NATIVE_ACTIVITY_DONE,
        SAPP_LOGITEM_ANDROID_NATIVE_ACTIVITY_ONCREATE,
        SAPP_LOGITEM_ANDROID_CREATE_THREAD_PIPE_FAILED,
        SAPP_LOGITEM_ANDROID_NATIVE_ACTIVITY_CREATE_SUCCESS,
        SAPP_LOGITEM_IMAGE_DATA_SIZE_MISMATCH,
        SAPP_LOGITEM_DROPPED_FILE_PATH_TOO_LONG,
        SAPP_LOGITEM_CLIPBOARD_STRING_TOO_BIG,
    }

    public unsafe partial struct sapp_logger
    {
        [NativeTypeName("void (*)(const char *, uint32_t, uint32_t, const char *, uint32_t, const char *, void *)")]
        public delegate* unmanaged[Cdecl]<sbyte*, uint, uint, sbyte*, uint, sbyte*, void*, void> func;

        public void* user_data;
    }

    public unsafe partial struct sapp_desc
    {
        [NativeTypeName("void (*)()")]
        public delegate* unmanaged[Cdecl]<void> init_cb;

        [NativeTypeName("void (*)()")]
        public delegate* unmanaged[Cdecl]<void> frame_cb;

        [NativeTypeName("void (*)()")]
        public delegate* unmanaged[Cdecl]<void> cleanup_cb;

        [NativeTypeName("void (*)(const sapp_event *)")]
        public delegate* unmanaged[Cdecl]<sapp_event*, void> event_cb;

        public void* user_data;

        [NativeTypeName("void (*)(void *)")]
        public delegate* unmanaged[Cdecl]<void*, void> init_userdata_cb;

        [NativeTypeName("void (*)(void *)")]
        public delegate* unmanaged[Cdecl]<void*, void> frame_userdata_cb;

        [NativeTypeName("void (*)(void *)")]
        public delegate* unmanaged[Cdecl]<void*, void> cleanup_userdata_cb;

        [NativeTypeName("void (*)(const sapp_event *, void *)")]
        public delegate* unmanaged[Cdecl]<sapp_event*, void*, void> event_userdata_cb;

        public int width;

        public int height;

        public int sample_count;

        public int swap_interval;

        [NativeTypeName("bool")]
        public byte high_dpi;

        [NativeTypeName("bool")]
        public byte fullscreen;

        [NativeTypeName("bool")]
        public byte alpha;

        [NativeTypeName("const char *")]
        public sbyte* window_title;

        [NativeTypeName("bool")]
        public byte enable_clipboard;

        public int clipboard_size;

        [NativeTypeName("bool")]
        public byte enable_dragndrop;

        public int max_dropped_files;

        public int max_dropped_file_path_length;

        public sapp_icon_desc icon;

        public sapp_allocator allocator;

        public sapp_logger logger;

        public int gl_major_version;

        public int gl_minor_version;

        [NativeTypeName("bool")]
        public byte win32_console_utf8;

        [NativeTypeName("bool")]
        public byte win32_console_create;

        [NativeTypeName("bool")]
        public byte win32_console_attach;

        [NativeTypeName("const char *")]
        public sbyte* html5_canvas_name;

        [NativeTypeName("bool")]
        public byte html5_canvas_resize;

        [NativeTypeName("bool")]
        public byte html5_preserve_drawing_buffer;

        [NativeTypeName("bool")]
        public byte html5_premultiplied_alpha;

        [NativeTypeName("bool")]
        public byte html5_ask_leave_site;

        [NativeTypeName("bool")]
        public byte ios_keyboard_resizes_canvas;
    }

    public enum sapp_html5_fetch_error
    {
        SAPP_HTML5_FETCH_ERROR_NO_ERROR,
        SAPP_HTML5_FETCH_ERROR_BUFFER_TOO_SMALL,
        SAPP_HTML5_FETCH_ERROR_OTHER,
    }

    public unsafe partial struct sapp_html5_fetch_response
    {
        [NativeTypeName("bool")]
        public byte succeeded;

        public sapp_html5_fetch_error error_code;

        public int file_index;

        public sapp_range data;

        public sapp_range buffer;

        public void* user_data;
    }

    public unsafe partial struct sapp_html5_fetch_request
    {
        public int dropped_file_index;

        [NativeTypeName("void (*)(const sapp_html5_fetch_response *)")]
        public delegate* unmanaged[Cdecl]<sapp_html5_fetch_response*, void> callback;

        public sapp_range buffer;

        public void* user_data;
    }

    public enum sapp_mouse_cursor
    {
        SAPP_MOUSECURSOR_DEFAULT = 0,
        SAPP_MOUSECURSOR_ARROW,
        SAPP_MOUSECURSOR_IBEAM,
        SAPP_MOUSECURSOR_CROSSHAIR,
        SAPP_MOUSECURSOR_POINTING_HAND,
        SAPP_MOUSECURSOR_RESIZE_EW,
        SAPP_MOUSECURSOR_RESIZE_NS,
        SAPP_MOUSECURSOR_RESIZE_NWSE,
        SAPP_MOUSECURSOR_RESIZE_NESW,
        SAPP_MOUSECURSOR_RESIZE_ALL,
        SAPP_MOUSECURSOR_NOT_ALLOWED,
        _SAPP_MOUSECURSOR_NUM,
    }

    public static unsafe partial class App
    {
        public const int SAPP_MAX_TOUCHPOINTS = 8;
        public const int SAPP_MAX_MOUSEBUTTONS = 3;
        public const int SAPP_MAX_KEYCODES = 512;
        public const int SAPP_MAX_ICONIMAGES = 8;

        public const int SAPP_MODIFIER_SHIFT = 0x1;
        public const int SAPP_MODIFIER_CTRL = 0x2;
        public const int SAPP_MODIFIER_ALT = 0x4;
        public const int SAPP_MODIFIER_SUPER = 0x8;
        public const int SAPP_MODIFIER_LMB = 0x100;
        public const int SAPP_MODIFIER_RMB = 0x200;
        public const int SAPP_MODIFIER_MMB = 0x400;

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern sapp_desc sokol_main(int argc, [NativeTypeName("char *[]")] sbyte** argv);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sapp_isvalid", ExactSpelling = true)]
        [return: NativeTypeName("bool")]
        public static extern byte isvalid();

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sapp_width", ExactSpelling = true)]
        public static extern int width();

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sapp_widthf", ExactSpelling = true)]
        public static extern float widthf();

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sapp_height", ExactSpelling = true)]
        public static extern int height();

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sapp_heightf", ExactSpelling = true)]
        public static extern float heightf();

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sapp_color_format", ExactSpelling = true)]
        public static extern int color_format();

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sapp_depth_format", ExactSpelling = true)]
        public static extern int depth_format();

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sapp_sample_count", ExactSpelling = true)]
        public static extern int sample_count();

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sapp_high_dpi", ExactSpelling = true)]
        [return: NativeTypeName("bool")]
        public static extern byte high_dpi();

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sapp_dpi_scale", ExactSpelling = true)]
        public static extern float dpi_scale();

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sapp_show_keyboard", ExactSpelling = true)]
        public static extern void show_keyboard([NativeTypeName("bool")] byte show);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sapp_keyboard_shown", ExactSpelling = true)]
        [return: NativeTypeName("bool")]
        public static extern byte keyboard_shown();

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sapp_is_fullscreen", ExactSpelling = true)]
        [return: NativeTypeName("bool")]
        public static extern byte is_fullscreen();

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sapp_toggle_fullscreen", ExactSpelling = true)]
        public static extern void toggle_fullscreen();

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sapp_show_mouse", ExactSpelling = true)]
        public static extern void show_mouse([NativeTypeName("bool")] byte show);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sapp_mouse_shown", ExactSpelling = true)]
        [return: NativeTypeName("bool")]
        public static extern byte mouse_shown();

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sapp_lock_mouse", ExactSpelling = true)]
        public static extern void lock_mouse([NativeTypeName("bool")] byte @lock);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sapp_mouse_locked", ExactSpelling = true)]
        [return: NativeTypeName("bool")]
        public static extern byte mouse_locked();

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sapp_set_mouse_cursor", ExactSpelling = true)]
        public static extern void set_mouse_cursor(sapp_mouse_cursor cursor);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sapp_get_mouse_cursor", ExactSpelling = true)]
        public static extern sapp_mouse_cursor get_mouse_cursor();

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sapp_userdata", ExactSpelling = true)]
        public static extern void* userdata();

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sapp_query_desc", ExactSpelling = true)]
        public static extern sapp_desc query_desc();

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sapp_request_quit", ExactSpelling = true)]
        public static extern void request_quit();

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sapp_cancel_quit", ExactSpelling = true)]
        public static extern void cancel_quit();

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sapp_quit", ExactSpelling = true)]
        public static extern void quit();

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sapp_consume_event", ExactSpelling = true)]
        public static extern void consume_event();

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sapp_frame_count", ExactSpelling = true)]
        [return: NativeTypeName("uint64_t")]
        public static extern ulong frame_count();

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sapp_frame_duration", ExactSpelling = true)]
        public static extern double frame_duration();

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sapp_set_clipboard_string", ExactSpelling = true)]
        public static extern void set_clipboard_string([NativeTypeName("const char *")] sbyte* str);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sapp_get_clipboard_string", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* get_clipboard_string();

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sapp_set_window_title", ExactSpelling = true)]
        public static extern void set_window_title([NativeTypeName("const char *")] sbyte* str);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sapp_set_icon", ExactSpelling = true)]
        public static extern void set_icon([NativeTypeName("const sapp_icon_desc *")] sapp_icon_desc* icon_desc);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sapp_get_num_dropped_files", ExactSpelling = true)]
        public static extern int get_num_dropped_files();

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sapp_get_dropped_file_path", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* get_dropped_file_path(int index);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sapp_run", ExactSpelling = true)]
        public static extern void run([NativeTypeName("const sapp_desc *")] sapp_desc* desc);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sapp_egl_get_display", ExactSpelling = true)]
        [return: NativeTypeName("const void *")]
        public static extern void* egl_get_display();

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sapp_egl_get_context", ExactSpelling = true)]
        [return: NativeTypeName("const void *")]
        public static extern void* egl_get_context();

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sapp_html5_ask_leave_site", ExactSpelling = true)]
        public static extern void html5_ask_leave_site([NativeTypeName("bool")] byte ask);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sapp_html5_get_dropped_file_size", ExactSpelling = true)]
        [return: NativeTypeName("uint32_t")]
        public static extern uint html5_get_dropped_file_size(int index);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sapp_html5_fetch_dropped_file", ExactSpelling = true)]
        public static extern void html5_fetch_dropped_file([NativeTypeName("const sapp_html5_fetch_request *")] sapp_html5_fetch_request* request);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sapp_metal_get_device", ExactSpelling = true)]
        [return: NativeTypeName("const void *")]
        public static extern void* metal_get_device();

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sapp_metal_get_renderpass_descriptor", ExactSpelling = true)]
        [return: NativeTypeName("const void *")]
        public static extern void* metal_get_renderpass_descriptor();

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sapp_metal_get_drawable", ExactSpelling = true)]
        [return: NativeTypeName("const void *")]
        public static extern void* metal_get_drawable();

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sapp_macos_get_window", ExactSpelling = true)]
        [return: NativeTypeName("const void *")]
        public static extern void* macos_get_window();

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sapp_ios_get_window", ExactSpelling = true)]
        [return: NativeTypeName("const void *")]
        public static extern void* ios_get_window();

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sapp_d3d11_get_device", ExactSpelling = true)]
        [return: NativeTypeName("const void *")]
        public static extern void* d3d11_get_device();

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sapp_d3d11_get_device_context", ExactSpelling = true)]
        [return: NativeTypeName("const void *")]
        public static extern void* d3d11_get_device_context();

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sapp_d3d11_get_swap_chain", ExactSpelling = true)]
        [return: NativeTypeName("const void *")]
        public static extern void* d3d11_get_swap_chain();

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sapp_d3d11_get_render_target_view", ExactSpelling = true)]
        [return: NativeTypeName("const void *")]
        public static extern void* d3d11_get_render_target_view();

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sapp_d3d11_get_depth_stencil_view", ExactSpelling = true)]
        [return: NativeTypeName("const void *")]
        public static extern void* d3d11_get_depth_stencil_view();

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sapp_win32_get_hwnd", ExactSpelling = true)]
        [return: NativeTypeName("const void *")]
        public static extern void* win32_get_hwnd();

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sapp_wgpu_get_device", ExactSpelling = true)]
        [return: NativeTypeName("const void *")]
        public static extern void* wgpu_get_device();

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sapp_wgpu_get_render_view", ExactSpelling = true)]
        [return: NativeTypeName("const void *")]
        public static extern void* wgpu_get_render_view();

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sapp_wgpu_get_resolve_view", ExactSpelling = true)]
        [return: NativeTypeName("const void *")]
        public static extern void* wgpu_get_resolve_view();

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sapp_wgpu_get_depth_stencil_view", ExactSpelling = true)]
        [return: NativeTypeName("const void *")]
        public static extern void* wgpu_get_depth_stencil_view();

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sapp_android_get_native_activity", ExactSpelling = true)]
        [return: NativeTypeName("const void *")]
        public static extern void* android_get_native_activity();
    }
