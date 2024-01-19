using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Dinghy.Internal.Sokol;

public partial struct sg_imgui_str_t
{
    [NativeTypeName("char[96]")]
    public _buf_e__FixedBuffer buf;

    [InlineArray(96)]
    public partial struct _buf_e__FixedBuffer
    {
        public sbyte e0;
    }
}

    public partial struct sg_imgui_buffer_t
    {
        public sg_buffer res_id;

        public sg_imgui_str_t label;

        public sg_buffer_desc desc;
    }

    public partial struct sg_imgui_image_t
    {
        public sg_image res_id;

        public float ui_scale;

        public sg_imgui_str_t label;

        public sg_image_desc desc;

        public simgui_image_t simgui_img;
    }

    public partial struct sg_imgui_sampler_t
    {
        public sg_sampler res_id;

        public sg_imgui_str_t label;

        public sg_sampler_desc desc;
    }

    public partial struct sg_imgui_shader_t
    {
        public sg_shader res_id;

        public sg_imgui_str_t label;

        public sg_imgui_str_t vs_entry;

        public sg_imgui_str_t vs_d3d11_target;

        [NativeTypeName("sg_imgui_str_t[12]")]
        public _vs_image_sampler_name_e__FixedBuffer vs_image_sampler_name;

        [NativeTypeName("sg_imgui_str_t[4][16]")]
        public _vs_uniform_name_e__FixedBuffer vs_uniform_name;

        public sg_imgui_str_t fs_entry;

        public sg_imgui_str_t fs_d3d11_target;

        [NativeTypeName("sg_imgui_str_t[12]")]
        public _fs_image_sampler_name_e__FixedBuffer fs_image_sampler_name;

        [NativeTypeName("sg_imgui_str_t[4][16]")]
        public _fs_uniform_name_e__FixedBuffer fs_uniform_name;

        [NativeTypeName("sg_imgui_str_t[16]")]
        public _attr_name_e__FixedBuffer attr_name;

        [NativeTypeName("sg_imgui_str_t[16]")]
        public _attr_sem_name_e__FixedBuffer attr_sem_name;

        public sg_shader_desc desc;

        [InlineArray(12)]
        public partial struct _vs_image_sampler_name_e__FixedBuffer
        {
            public sg_imgui_str_t e0;
        }

        [InlineArray(4 * 16)]
        public partial struct _vs_uniform_name_e__FixedBuffer
        {
            public sg_imgui_str_t e0_0;
        }

        [InlineArray(12)]
        public partial struct _fs_image_sampler_name_e__FixedBuffer
        {
            public sg_imgui_str_t e0;
        }

        [InlineArray(4 * 16)]
        public partial struct _fs_uniform_name_e__FixedBuffer
        {
            public sg_imgui_str_t e0_0;
        }

        [InlineArray(16)]
        public partial struct _attr_name_e__FixedBuffer
        {
            public sg_imgui_str_t e0;
        }

        [InlineArray(16)]
        public partial struct _attr_sem_name_e__FixedBuffer
        {
            public sg_imgui_str_t e0;
        }
    }

    public partial struct sg_imgui_pipeline_t
    {
        public sg_pipeline res_id;

        public sg_imgui_str_t label;

        public sg_pipeline_desc desc;
    }

    public partial struct sg_imgui_pass_t
    {
        public sg_pass res_id;

        public sg_imgui_str_t label;

        [NativeTypeName("float[4]")]
        public _color_image_scale_e__FixedBuffer color_image_scale;

        [NativeTypeName("float[4]")]
        public _resolve_image_scale_e__FixedBuffer resolve_image_scale;

        public float ds_image_scale;

        public sg_pass_desc desc;

        [InlineArray(4)]
        public partial struct _color_image_scale_e__FixedBuffer
        {
            public float e0;
        }

        [InlineArray(4)]
        public partial struct _resolve_image_scale_e__FixedBuffer
        {
            public float e0;
        }
    }

    public unsafe partial struct sg_imgui_buffers_t
    {
        [NativeTypeName("bool")]
        public byte open;

        public int num_slots;

        public sg_buffer sel_buf;

        public sg_imgui_buffer_t* slots;
    }

    public unsafe partial struct sg_imgui_images_t
    {
        [NativeTypeName("bool")]
        public byte open;

        public int num_slots;

        public sg_image sel_img;

        public sg_imgui_image_t* slots;
    }

    public unsafe partial struct sg_imgui_samplers_t
    {
        [NativeTypeName("bool")]
        public byte open;

        public int num_slots;

        public sg_sampler sel_smp;

        public sg_imgui_sampler_t* slots;
    }

    public unsafe partial struct sg_imgui_shaders_t
    {
        [NativeTypeName("bool")]
        public byte open;

        public int num_slots;

        public sg_shader sel_shd;

        public sg_imgui_shader_t* slots;
    }

    public unsafe partial struct sg_imgui_pipelines_t
    {
        [NativeTypeName("bool")]
        public byte open;

        public int num_slots;

        public sg_pipeline sel_pip;

        public sg_imgui_pipeline_t* slots;
    }

    public unsafe partial struct sg_imgui_passes_t
    {
        [NativeTypeName("bool")]
        public byte open;

        public int num_slots;

        public sg_pass sel_pass;

        public sg_imgui_pass_t* slots;
    }

    [NativeTypeName("unsigned int")]
    public enum sg_imgui_cmd_t : uint
    {
        SG_IMGUI_CMD_INVALID,
        SG_IMGUI_CMD_RESET_STATE_CACHE,
        SG_IMGUI_CMD_MAKE_BUFFER,
        SG_IMGUI_CMD_MAKE_IMAGE,
        SG_IMGUI_CMD_MAKE_SAMPLER,
        SG_IMGUI_CMD_MAKE_SHADER,
        SG_IMGUI_CMD_MAKE_PIPELINE,
        SG_IMGUI_CMD_MAKE_PASS,
        SG_IMGUI_CMD_DESTROY_BUFFER,
        SG_IMGUI_CMD_DESTROY_IMAGE,
        SG_IMGUI_CMD_DESTROY_SAMPLER,
        SG_IMGUI_CMD_DESTROY_SHADER,
        SG_IMGUI_CMD_DESTROY_PIPELINE,
        SG_IMGUI_CMD_DESTROY_PASS,
        SG_IMGUI_CMD_UPDATE_BUFFER,
        SG_IMGUI_CMD_UPDATE_IMAGE,
        SG_IMGUI_CMD_APPEND_BUFFER,
        SG_IMGUI_CMD_BEGIN_DEFAULT_PASS,
        SG_IMGUI_CMD_BEGIN_PASS,
        SG_IMGUI_CMD_APPLY_VIEWPORT,
        SG_IMGUI_CMD_APPLY_SCISSOR_RECT,
        SG_IMGUI_CMD_APPLY_PIPELINE,
        SG_IMGUI_CMD_APPLY_BINDINGS,
        SG_IMGUI_CMD_APPLY_UNIFORMS,
        SG_IMGUI_CMD_DRAW,
        SG_IMGUI_CMD_END_PASS,
        SG_IMGUI_CMD_COMMIT,
        SG_IMGUI_CMD_ALLOC_BUFFER,
        SG_IMGUI_CMD_ALLOC_IMAGE,
        SG_IMGUI_CMD_ALLOC_SAMPLER,
        SG_IMGUI_CMD_ALLOC_SHADER,
        SG_IMGUI_CMD_ALLOC_PIPELINE,
        SG_IMGUI_CMD_ALLOC_PASS,
        SG_IMGUI_CMD_DEALLOC_BUFFER,
        SG_IMGUI_CMD_DEALLOC_IMAGE,
        SG_IMGUI_CMD_DEALLOC_SAMPLER,
        SG_IMGUI_CMD_DEALLOC_SHADER,
        SG_IMGUI_CMD_DEALLOC_PIPELINE,
        SG_IMGUI_CMD_DEALLOC_PASS,
        SG_IMGUI_CMD_INIT_BUFFER,
        SG_IMGUI_CMD_INIT_IMAGE,
        SG_IMGUI_CMD_INIT_SAMPLER,
        SG_IMGUI_CMD_INIT_SHADER,
        SG_IMGUI_CMD_INIT_PIPELINE,
        SG_IMGUI_CMD_INIT_PASS,
        SG_IMGUI_CMD_UNINIT_BUFFER,
        SG_IMGUI_CMD_UNINIT_IMAGE,
        SG_IMGUI_CMD_UNINIT_SAMPLER,
        SG_IMGUI_CMD_UNINIT_SHADER,
        SG_IMGUI_CMD_UNINIT_PIPELINE,
        SG_IMGUI_CMD_UNINIT_PASS,
        SG_IMGUI_CMD_FAIL_BUFFER,
        SG_IMGUI_CMD_FAIL_IMAGE,
        SG_IMGUI_CMD_FAIL_SAMPLER,
        SG_IMGUI_CMD_FAIL_SHADER,
        SG_IMGUI_CMD_FAIL_PIPELINE,
        SG_IMGUI_CMD_FAIL_PASS,
        SG_IMGUI_CMD_PUSH_DEBUG_GROUP,
        SG_IMGUI_CMD_POP_DEBUG_GROUP,
    }

    public partial struct sg_imgui_args_make_buffer_t
    {
        public sg_buffer result;
    }

    public partial struct sg_imgui_args_make_image_t
    {
        public sg_image result;
    }

    public partial struct sg_imgui_args_make_sampler_t
    {
        public sg_sampler result;
    }

    public partial struct sg_imgui_args_make_shader_t
    {
        public sg_shader result;
    }

    public partial struct sg_imgui_args_make_pipeline_t
    {
        public sg_pipeline result;
    }

    public partial struct sg_imgui_args_make_pass_t
    {
        public sg_pass result;
    }

    public partial struct sg_imgui_args_destroy_buffer_t
    {
        public sg_buffer buffer;
    }

    public partial struct sg_imgui_args_destroy_image_t
    {
        public sg_image image;
    }

    public partial struct sg_imgui_args_destroy_sampler_t
    {
        public sg_sampler sampler;
    }

    public partial struct sg_imgui_args_destroy_shader_t
    {
        public sg_shader shader;
    }

    public partial struct sg_imgui_args_destroy_pipeline_t
    {
        public sg_pipeline pipeline;
    }

    public partial struct sg_imgui_args_destroy_pass_t
    {
        public sg_pass pass;
    }

    public partial struct sg_imgui_args_update_buffer_t
    {
        public sg_buffer buffer;

        [NativeTypeName("size_t")]
        public nuint data_size;
    }

    public partial struct sg_imgui_args_update_image_t
    {
        public sg_image image;
    }

    public partial struct sg_imgui_args_append_buffer_t
    {
        public sg_buffer buffer;

        [NativeTypeName("size_t")]
        public nuint data_size;

        public int result;
    }

    public partial struct sg_imgui_args_begin_default_pass_t
    {
        public sg_pass_action action;

        public int width;

        public int height;
    }

    public partial struct sg_imgui_args_begin_pass_t
    {
        public sg_pass pass;

        public sg_pass_action action;
    }

    public partial struct sg_imgui_args_apply_viewport_t
    {
        public int x;

        public int y;

        public int width;

        public int height;

        [NativeTypeName("bool")]
        public byte origin_top_left;
    }

    public partial struct sg_imgui_args_apply_scissor_rect_t
    {
        public int x;

        public int y;

        public int width;

        public int height;

        [NativeTypeName("bool")]
        public byte origin_top_left;
    }

    public partial struct sg_imgui_args_apply_pipeline_t
    {
        public sg_pipeline pipeline;
    }

    public partial struct sg_imgui_args_apply_bindings_t
    {
        public sg_bindings bindings;
    }

    public partial struct sg_imgui_args_apply_uniforms_t
    {
        public sg_shader_stage stage;

        public int ub_index;

        [NativeTypeName("size_t")]
        public nuint data_size;

        public sg_pipeline pipeline;

        [NativeTypeName("size_t")]
        public nuint ubuf_pos;
    }

    public partial struct sg_imgui_args_draw_t
    {
        public int base_element;

        public int num_elements;

        public int num_instances;
    }

    public partial struct sg_imgui_args_alloc_buffer_t
    {
        public sg_buffer result;
    }

    public partial struct sg_imgui_args_alloc_image_t
    {
        public sg_image result;
    }

    public partial struct sg_imgui_args_alloc_sampler_t
    {
        public sg_sampler result;
    }

    public partial struct sg_imgui_args_alloc_shader_t
    {
        public sg_shader result;
    }

    public partial struct sg_imgui_args_alloc_pipeline_t
    {
        public sg_pipeline result;
    }

    public partial struct sg_imgui_args_alloc_pass_t
    {
        public sg_pass result;
    }

    public partial struct sg_imgui_args_dealloc_buffer_t
    {
        public sg_buffer buffer;
    }

    public partial struct sg_imgui_args_dealloc_image_t
    {
        public sg_image image;
    }

    public partial struct sg_imgui_args_dealloc_sampler_t
    {
        public sg_sampler sampler;
    }

    public partial struct sg_imgui_args_dealloc_shader_t
    {
        public sg_shader shader;
    }

    public partial struct sg_imgui_args_dealloc_pipeline_t
    {
        public sg_pipeline pipeline;
    }

    public partial struct sg_imgui_args_dealloc_pass_t
    {
        public sg_pass pass;
    }

    public partial struct sg_imgui_args_init_buffer_t
    {
        public sg_buffer buffer;
    }

    public partial struct sg_imgui_args_init_image_t
    {
        public sg_image image;
    }

    public partial struct sg_imgui_args_init_sampler_t
    {
        public sg_sampler sampler;
    }

    public partial struct sg_imgui_args_init_shader_t
    {
        public sg_shader shader;
    }

    public partial struct sg_imgui_args_init_pipeline_t
    {
        public sg_pipeline pipeline;
    }

    public partial struct sg_imgui_args_init_pass_t
    {
        public sg_pass pass;
    }

    public partial struct sg_imgui_args_uninit_buffer_t
    {
        public sg_buffer buffer;
    }

    public partial struct sg_imgui_args_uninit_image_t
    {
        public sg_image image;
    }

    public partial struct sg_imgui_args_uninit_sampler_t
    {
        public sg_sampler sampler;
    }

    public partial struct sg_imgui_args_uninit_shader_t
    {
        public sg_shader shader;
    }

    public partial struct sg_imgui_args_uninit_pipeline_t
    {
        public sg_pipeline pipeline;
    }

    public partial struct sg_imgui_args_uninit_pass_t
    {
        public sg_pass pass;
    }

    public partial struct sg_imgui_args_fail_buffer_t
    {
        public sg_buffer buffer;
    }

    public partial struct sg_imgui_args_fail_image_t
    {
        public sg_image image;
    }

    public partial struct sg_imgui_args_fail_sampler_t
    {
        public sg_sampler sampler;
    }

    public partial struct sg_imgui_args_fail_shader_t
    {
        public sg_shader shader;
    }

    public partial struct sg_imgui_args_fail_pipeline_t
    {
        public sg_pipeline pipeline;
    }

    public partial struct sg_imgui_args_fail_pass_t
    {
        public sg_pass pass;
    }

    public partial struct sg_imgui_args_push_debug_group_t
    {
        public sg_imgui_str_t name;
    }

    [StructLayout(LayoutKind.Explicit)]
    public partial struct sg_imgui_args_t
    {
        [FieldOffset(0)]
        public sg_imgui_args_make_buffer_t make_buffer;

        [FieldOffset(0)]
        public sg_imgui_args_make_image_t make_image;

        [FieldOffset(0)]
        public sg_imgui_args_make_sampler_t make_sampler;

        [FieldOffset(0)]
        public sg_imgui_args_make_shader_t make_shader;

        [FieldOffset(0)]
        public sg_imgui_args_make_pipeline_t make_pipeline;

        [FieldOffset(0)]
        public sg_imgui_args_make_pass_t make_pass;

        [FieldOffset(0)]
        public sg_imgui_args_destroy_buffer_t destroy_buffer;

        [FieldOffset(0)]
        public sg_imgui_args_destroy_image_t destroy_image;

        [FieldOffset(0)]
        public sg_imgui_args_destroy_sampler_t destroy_sampler;

        [FieldOffset(0)]
        public sg_imgui_args_destroy_shader_t destroy_shader;

        [FieldOffset(0)]
        public sg_imgui_args_destroy_pipeline_t destroy_pipeline;

        [FieldOffset(0)]
        public sg_imgui_args_destroy_pass_t destroy_pass;

        [FieldOffset(0)]
        public sg_imgui_args_update_buffer_t update_buffer;

        [FieldOffset(0)]
        public sg_imgui_args_update_image_t update_image;

        [FieldOffset(0)]
        public sg_imgui_args_append_buffer_t append_buffer;

        [FieldOffset(0)]
        public sg_imgui_args_begin_default_pass_t begin_default_pass;

        [FieldOffset(0)]
        public sg_imgui_args_begin_pass_t begin_pass;

        [FieldOffset(0)]
        public sg_imgui_args_apply_viewport_t apply_viewport;

        [FieldOffset(0)]
        public sg_imgui_args_apply_scissor_rect_t apply_scissor_rect;

        [FieldOffset(0)]
        public sg_imgui_args_apply_pipeline_t apply_pipeline;

        [FieldOffset(0)]
        public sg_imgui_args_apply_bindings_t apply_bindings;

        [FieldOffset(0)]
        public sg_imgui_args_apply_uniforms_t apply_uniforms;

        [FieldOffset(0)]
        public sg_imgui_args_draw_t draw;

        [FieldOffset(0)]
        public sg_imgui_args_alloc_buffer_t alloc_buffer;

        [FieldOffset(0)]
        public sg_imgui_args_alloc_image_t alloc_image;

        [FieldOffset(0)]
        public sg_imgui_args_alloc_sampler_t alloc_sampler;

        [FieldOffset(0)]
        public sg_imgui_args_alloc_shader_t alloc_shader;

        [FieldOffset(0)]
        public sg_imgui_args_alloc_pipeline_t alloc_pipeline;

        [FieldOffset(0)]
        public sg_imgui_args_alloc_pass_t alloc_pass;

        [FieldOffset(0)]
        public sg_imgui_args_dealloc_buffer_t dealloc_buffer;

        [FieldOffset(0)]
        public sg_imgui_args_dealloc_image_t dealloc_image;

        [FieldOffset(0)]
        public sg_imgui_args_dealloc_sampler_t dealloc_sampler;

        [FieldOffset(0)]
        public sg_imgui_args_dealloc_shader_t dealloc_shader;

        [FieldOffset(0)]
        public sg_imgui_args_dealloc_pipeline_t dealloc_pipeline;

        [FieldOffset(0)]
        public sg_imgui_args_dealloc_pass_t dealloc_pass;

        [FieldOffset(0)]
        public sg_imgui_args_init_buffer_t init_buffer;

        [FieldOffset(0)]
        public sg_imgui_args_init_image_t init_image;

        [FieldOffset(0)]
        public sg_imgui_args_init_sampler_t init_sampler;

        [FieldOffset(0)]
        public sg_imgui_args_init_shader_t init_shader;

        [FieldOffset(0)]
        public sg_imgui_args_init_pipeline_t init_pipeline;

        [FieldOffset(0)]
        public sg_imgui_args_init_pass_t init_pass;

        [FieldOffset(0)]
        public sg_imgui_args_uninit_buffer_t uninit_buffer;

        [FieldOffset(0)]
        public sg_imgui_args_uninit_image_t uninit_image;

        [FieldOffset(0)]
        public sg_imgui_args_uninit_sampler_t uninit_sampler;

        [FieldOffset(0)]
        public sg_imgui_args_uninit_shader_t uninit_shader;

        [FieldOffset(0)]
        public sg_imgui_args_uninit_pipeline_t uninit_pipeline;

        [FieldOffset(0)]
        public sg_imgui_args_uninit_pass_t uninit_pass;

        [FieldOffset(0)]
        public sg_imgui_args_fail_buffer_t fail_buffer;

        [FieldOffset(0)]
        public sg_imgui_args_fail_image_t fail_image;

        [FieldOffset(0)]
        public sg_imgui_args_fail_sampler_t fail_sampler;

        [FieldOffset(0)]
        public sg_imgui_args_fail_shader_t fail_shader;

        [FieldOffset(0)]
        public sg_imgui_args_fail_pipeline_t fail_pipeline;

        [FieldOffset(0)]
        public sg_imgui_args_fail_pass_t fail_pass;

        [FieldOffset(0)]
        public sg_imgui_args_push_debug_group_t push_debug_group;
    }

    public partial struct sg_imgui_capture_item_t
    {
        public sg_imgui_cmd_t cmd;

        [NativeTypeName("uint32_t")]
        public uint color;

        public sg_imgui_args_t args;
    }

    public unsafe partial struct sg_imgui_capture_bucket_t
    {
        [NativeTypeName("size_t")]
        public nuint ubuf_size;

        [NativeTypeName("size_t")]
        public nuint ubuf_pos;

        [NativeTypeName("uint8_t *")]
        public byte* ubuf;

        public int num_items;

        [NativeTypeName("sg_imgui_capture_item_t[4096]")]
        public _items_e__FixedBuffer items;

        [InlineArray(4096)]
        public partial struct _items_e__FixedBuffer
        {
            public sg_imgui_capture_item_t e0;
        }
    }

    public partial struct sg_imgui_capture_t
    {
        [NativeTypeName("bool")]
        public byte open;

        public int bucket_index;

        public int sel_item;

        [NativeTypeName("sg_imgui_capture_bucket_t[2]")]
        public _bucket_e__FixedBuffer bucket;

        [InlineArray(2)]
        public partial struct _bucket_e__FixedBuffer
        {
            public sg_imgui_capture_bucket_t e0;
        }
    }

    public partial struct sg_imgui_caps_t
    {
        [NativeTypeName("bool")]
        public byte open;
    }

    public partial struct sg_imgui_frame_stats_t
    {
        [NativeTypeName("bool")]
        public byte open;

        [NativeTypeName("bool")]
        public byte disable_sokol_imgui_stats;

        [NativeTypeName("bool")]
        public byte in_sokol_imgui;

        public sg_frame_stats stats;
    }

    public unsafe partial struct sg_imgui_allocator_t
    {
        [NativeTypeName("void *(*)(size_t, void *)")]
        public delegate* unmanaged[Cdecl]<nuint, void*, void*> alloc_fn;

        [NativeTypeName("void (*)(void *, void *)")]
        public delegate* unmanaged[Cdecl]<void*, void*, void> free_fn;

        public void* user_data;
    }

    public partial struct sg_imgui_desc_t
    {
        public sg_imgui_allocator_t allocator;
    }

    public partial struct sg_imgui_t
    {
        [NativeTypeName("uint32_t")]
        public uint init_tag;

        public sg_imgui_desc_t desc;

        public sg_imgui_buffers_t buffers;

        public sg_imgui_images_t images;

        public sg_imgui_samplers_t samplers;

        public sg_imgui_shaders_t shaders;

        public sg_imgui_pipelines_t pipelines;

        public sg_imgui_passes_t passes;

        public sg_imgui_capture_t capture;

        public sg_imgui_caps_t caps;

        public sg_imgui_frame_stats_t frame_stats;

        public sg_pipeline cur_pipeline;

        public sg_trace_hooks hooks;
    }

    public static unsafe partial class GfxDebugGUI
    {
        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_imgui_init", ExactSpelling = true)]
        public static extern void init(sg_imgui_t* ctx, [NativeTypeName("const sg_imgui_desc_t *")] sg_imgui_desc_t* desc);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_imgui_discard", ExactSpelling = true)]
        public static extern void discard(sg_imgui_t* ctx);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_imgui_draw", ExactSpelling = true)]
        public static extern void draw(sg_imgui_t* ctx);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_imgui_draw_menu", ExactSpelling = true)]
        public static extern void draw_menu(sg_imgui_t* ctx, [NativeTypeName("const char *")] sbyte* title);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_imgui_draw_buffers_content", ExactSpelling = true)]
        public static extern void draw_buffers_content(sg_imgui_t* ctx);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_imgui_draw_images_content", ExactSpelling = true)]
        public static extern void draw_images_content(sg_imgui_t* ctx);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_imgui_draw_samplers_content", ExactSpelling = true)]
        public static extern void draw_samplers_content(sg_imgui_t* ctx);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_imgui_draw_shaders_content", ExactSpelling = true)]
        public static extern void draw_shaders_content(sg_imgui_t* ctx);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_imgui_draw_pipelines_content", ExactSpelling = true)]
        public static extern void draw_pipelines_content(sg_imgui_t* ctx);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_imgui_draw_passes_content", ExactSpelling = true)]
        public static extern void draw_passes_content(sg_imgui_t* ctx);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_imgui_draw_capture_content", ExactSpelling = true)]
        public static extern void draw_capture_content(sg_imgui_t* ctx);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_imgui_draw_capabilities_content", ExactSpelling = true)]
        public static extern void draw_capabilities_content(sg_imgui_t* ctx);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_imgui_draw_frame_stats_content", ExactSpelling = true)]
        public static extern void draw_frame_stats_content(sg_imgui_t* ctx);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_imgui_draw_buffers_window", ExactSpelling = true)]
        public static extern void draw_buffers_window(sg_imgui_t* ctx);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_imgui_draw_images_window", ExactSpelling = true)]
        public static extern void draw_images_window(sg_imgui_t* ctx);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_imgui_draw_samplers_window", ExactSpelling = true)]
        public static extern void draw_samplers_window(sg_imgui_t* ctx);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_imgui_draw_shaders_window", ExactSpelling = true)]
        public static extern void draw_shaders_window(sg_imgui_t* ctx);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_imgui_draw_pipelines_window", ExactSpelling = true)]
        public static extern void draw_pipelines_window(sg_imgui_t* ctx);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_imgui_draw_passes_window", ExactSpelling = true)]
        public static extern void draw_passes_window(sg_imgui_t* ctx);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_imgui_draw_capture_window", ExactSpelling = true)]
        public static extern void draw_capture_window(sg_imgui_t* ctx);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_imgui_draw_capabilities_window", ExactSpelling = true)]
        public static extern void draw_capabilities_window(sg_imgui_t* ctx);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_imgui_draw_frame_stats_window", ExactSpelling = true)]
        public static extern void draw_frame_stats_window(sg_imgui_t* ctx);
    }
