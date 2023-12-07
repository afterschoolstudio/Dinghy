using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Dinghy.Internal.Sokol;

public unsafe partial struct sg_imgui_str_t
{
    [NativeTypeName("char[96]")]
    public fixed sbyte buf[96];
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

        public partial struct _vs_image_sampler_name_e__FixedBuffer
        {
            public sg_imgui_str_t e0;
            public sg_imgui_str_t e1;
            public sg_imgui_str_t e2;
            public sg_imgui_str_t e3;
            public sg_imgui_str_t e4;
            public sg_imgui_str_t e5;
            public sg_imgui_str_t e6;
            public sg_imgui_str_t e7;
            public sg_imgui_str_t e8;
            public sg_imgui_str_t e9;
            public sg_imgui_str_t e10;
            public sg_imgui_str_t e11;

            [UnscopedRef]
            public ref sg_imgui_str_t this[int index]
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get
                {
                    return ref AsSpan()[index];
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [UnscopedRef]
            public Span<sg_imgui_str_t> AsSpan() => MemoryMarshal.CreateSpan(ref e0, 12);
        }

        public partial struct _vs_uniform_name_e__FixedBuffer
        {
            public sg_imgui_str_t e0_0;
            public sg_imgui_str_t e1_0;
            public sg_imgui_str_t e2_0;
            public sg_imgui_str_t e3_0;

            public sg_imgui_str_t e0_1;
            public sg_imgui_str_t e1_1;
            public sg_imgui_str_t e2_1;
            public sg_imgui_str_t e3_1;

            public sg_imgui_str_t e0_2;
            public sg_imgui_str_t e1_2;
            public sg_imgui_str_t e2_2;
            public sg_imgui_str_t e3_2;

            public sg_imgui_str_t e0_3;
            public sg_imgui_str_t e1_3;
            public sg_imgui_str_t e2_3;
            public sg_imgui_str_t e3_3;

            public sg_imgui_str_t e0_4;
            public sg_imgui_str_t e1_4;
            public sg_imgui_str_t e2_4;
            public sg_imgui_str_t e3_4;

            public sg_imgui_str_t e0_5;
            public sg_imgui_str_t e1_5;
            public sg_imgui_str_t e2_5;
            public sg_imgui_str_t e3_5;

            public sg_imgui_str_t e0_6;
            public sg_imgui_str_t e1_6;
            public sg_imgui_str_t e2_6;
            public sg_imgui_str_t e3_6;

            public sg_imgui_str_t e0_7;
            public sg_imgui_str_t e1_7;
            public sg_imgui_str_t e2_7;
            public sg_imgui_str_t e3_7;

            public sg_imgui_str_t e0_8;
            public sg_imgui_str_t e1_8;
            public sg_imgui_str_t e2_8;
            public sg_imgui_str_t e3_8;

            public sg_imgui_str_t e0_9;
            public sg_imgui_str_t e1_9;
            public sg_imgui_str_t e2_9;
            public sg_imgui_str_t e3_9;

            public sg_imgui_str_t e0_10;
            public sg_imgui_str_t e1_10;
            public sg_imgui_str_t e2_10;
            public sg_imgui_str_t e3_10;

            public sg_imgui_str_t e0_11;
            public sg_imgui_str_t e1_11;
            public sg_imgui_str_t e2_11;
            public sg_imgui_str_t e3_11;

            public sg_imgui_str_t e0_12;
            public sg_imgui_str_t e1_12;
            public sg_imgui_str_t e2_12;
            public sg_imgui_str_t e3_12;

            public sg_imgui_str_t e0_13;
            public sg_imgui_str_t e1_13;
            public sg_imgui_str_t e2_13;
            public sg_imgui_str_t e3_13;

            public sg_imgui_str_t e0_14;
            public sg_imgui_str_t e1_14;
            public sg_imgui_str_t e2_14;
            public sg_imgui_str_t e3_14;

            public sg_imgui_str_t e0_15;
            public sg_imgui_str_t e1_15;
            public sg_imgui_str_t e2_15;
            public sg_imgui_str_t e3_15;

            [UnscopedRef]
            public ref sg_imgui_str_t this[int index]
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get
                {
                    return ref AsSpan()[index];
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [UnscopedRef]
            public Span<sg_imgui_str_t> AsSpan() => MemoryMarshal.CreateSpan(ref e0_0, 64);
        }

        public partial struct _fs_image_sampler_name_e__FixedBuffer
        {
            public sg_imgui_str_t e0;
            public sg_imgui_str_t e1;
            public sg_imgui_str_t e2;
            public sg_imgui_str_t e3;
            public sg_imgui_str_t e4;
            public sg_imgui_str_t e5;
            public sg_imgui_str_t e6;
            public sg_imgui_str_t e7;
            public sg_imgui_str_t e8;
            public sg_imgui_str_t e9;
            public sg_imgui_str_t e10;
            public sg_imgui_str_t e11;

            [UnscopedRef]
            public ref sg_imgui_str_t this[int index]
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get
                {
                    return ref AsSpan()[index];
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [UnscopedRef]
            public Span<sg_imgui_str_t> AsSpan() => MemoryMarshal.CreateSpan(ref e0, 12);
        }

        public partial struct _fs_uniform_name_e__FixedBuffer
        {
            public sg_imgui_str_t e0_0;
            public sg_imgui_str_t e1_0;
            public sg_imgui_str_t e2_0;
            public sg_imgui_str_t e3_0;

            public sg_imgui_str_t e0_1;
            public sg_imgui_str_t e1_1;
            public sg_imgui_str_t e2_1;
            public sg_imgui_str_t e3_1;

            public sg_imgui_str_t e0_2;
            public sg_imgui_str_t e1_2;
            public sg_imgui_str_t e2_2;
            public sg_imgui_str_t e3_2;

            public sg_imgui_str_t e0_3;
            public sg_imgui_str_t e1_3;
            public sg_imgui_str_t e2_3;
            public sg_imgui_str_t e3_3;

            public sg_imgui_str_t e0_4;
            public sg_imgui_str_t e1_4;
            public sg_imgui_str_t e2_4;
            public sg_imgui_str_t e3_4;

            public sg_imgui_str_t e0_5;
            public sg_imgui_str_t e1_5;
            public sg_imgui_str_t e2_5;
            public sg_imgui_str_t e3_5;

            public sg_imgui_str_t e0_6;
            public sg_imgui_str_t e1_6;
            public sg_imgui_str_t e2_6;
            public sg_imgui_str_t e3_6;

            public sg_imgui_str_t e0_7;
            public sg_imgui_str_t e1_7;
            public sg_imgui_str_t e2_7;
            public sg_imgui_str_t e3_7;

            public sg_imgui_str_t e0_8;
            public sg_imgui_str_t e1_8;
            public sg_imgui_str_t e2_8;
            public sg_imgui_str_t e3_8;

            public sg_imgui_str_t e0_9;
            public sg_imgui_str_t e1_9;
            public sg_imgui_str_t e2_9;
            public sg_imgui_str_t e3_9;

            public sg_imgui_str_t e0_10;
            public sg_imgui_str_t e1_10;
            public sg_imgui_str_t e2_10;
            public sg_imgui_str_t e3_10;

            public sg_imgui_str_t e0_11;
            public sg_imgui_str_t e1_11;
            public sg_imgui_str_t e2_11;
            public sg_imgui_str_t e3_11;

            public sg_imgui_str_t e0_12;
            public sg_imgui_str_t e1_12;
            public sg_imgui_str_t e2_12;
            public sg_imgui_str_t e3_12;

            public sg_imgui_str_t e0_13;
            public sg_imgui_str_t e1_13;
            public sg_imgui_str_t e2_13;
            public sg_imgui_str_t e3_13;

            public sg_imgui_str_t e0_14;
            public sg_imgui_str_t e1_14;
            public sg_imgui_str_t e2_14;
            public sg_imgui_str_t e3_14;

            public sg_imgui_str_t e0_15;
            public sg_imgui_str_t e1_15;
            public sg_imgui_str_t e2_15;
            public sg_imgui_str_t e3_15;

            [UnscopedRef]
            public ref sg_imgui_str_t this[int index]
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get
                {
                    return ref AsSpan()[index];
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [UnscopedRef]
            public Span<sg_imgui_str_t> AsSpan() => MemoryMarshal.CreateSpan(ref e0_0, 64);
        }

        public partial struct _attr_name_e__FixedBuffer
        {
            public sg_imgui_str_t e0;
            public sg_imgui_str_t e1;
            public sg_imgui_str_t e2;
            public sg_imgui_str_t e3;
            public sg_imgui_str_t e4;
            public sg_imgui_str_t e5;
            public sg_imgui_str_t e6;
            public sg_imgui_str_t e7;
            public sg_imgui_str_t e8;
            public sg_imgui_str_t e9;
            public sg_imgui_str_t e10;
            public sg_imgui_str_t e11;
            public sg_imgui_str_t e12;
            public sg_imgui_str_t e13;
            public sg_imgui_str_t e14;
            public sg_imgui_str_t e15;

            [UnscopedRef]
            public ref sg_imgui_str_t this[int index]
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get
                {
                    return ref AsSpan()[index];
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [UnscopedRef]
            public Span<sg_imgui_str_t> AsSpan() => MemoryMarshal.CreateSpan(ref e0, 16);
        }

        public partial struct _attr_sem_name_e__FixedBuffer
        {
            public sg_imgui_str_t e0;
            public sg_imgui_str_t e1;
            public sg_imgui_str_t e2;
            public sg_imgui_str_t e3;
            public sg_imgui_str_t e4;
            public sg_imgui_str_t e5;
            public sg_imgui_str_t e6;
            public sg_imgui_str_t e7;
            public sg_imgui_str_t e8;
            public sg_imgui_str_t e9;
            public sg_imgui_str_t e10;
            public sg_imgui_str_t e11;
            public sg_imgui_str_t e12;
            public sg_imgui_str_t e13;
            public sg_imgui_str_t e14;
            public sg_imgui_str_t e15;

            [UnscopedRef]
            public ref sg_imgui_str_t this[int index]
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get
                {
                    return ref AsSpan()[index];
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [UnscopedRef]
            public Span<sg_imgui_str_t> AsSpan() => MemoryMarshal.CreateSpan(ref e0, 16);
        }
    }

    public partial struct sg_imgui_pipeline_t
    {
        public sg_pipeline res_id;

        public sg_imgui_str_t label;

        public sg_pipeline_desc desc;
    }

    public unsafe partial struct sg_imgui_pass_t
    {
        public sg_pass res_id;

        public sg_imgui_str_t label;

        [NativeTypeName("float[4]")]
        public fixed float color_image_scale[4];

        [NativeTypeName("float[4]")]
        public fixed float resolve_image_scale[4];

        public float ds_image_scale;

        public sg_pass_desc desc;
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

        public partial struct _items_e__FixedBuffer
        {
            public sg_imgui_capture_item_t e0;
            public sg_imgui_capture_item_t e1;
            public sg_imgui_capture_item_t e2;
            public sg_imgui_capture_item_t e3;
            public sg_imgui_capture_item_t e4;
            public sg_imgui_capture_item_t e5;
            public sg_imgui_capture_item_t e6;
            public sg_imgui_capture_item_t e7;
            public sg_imgui_capture_item_t e8;
            public sg_imgui_capture_item_t e9;
            public sg_imgui_capture_item_t e10;
            public sg_imgui_capture_item_t e11;
            public sg_imgui_capture_item_t e12;
            public sg_imgui_capture_item_t e13;
            public sg_imgui_capture_item_t e14;
            public sg_imgui_capture_item_t e15;
            public sg_imgui_capture_item_t e16;
            public sg_imgui_capture_item_t e17;
            public sg_imgui_capture_item_t e18;
            public sg_imgui_capture_item_t e19;
            public sg_imgui_capture_item_t e20;
            public sg_imgui_capture_item_t e21;
            public sg_imgui_capture_item_t e22;
            public sg_imgui_capture_item_t e23;
            public sg_imgui_capture_item_t e24;
            public sg_imgui_capture_item_t e25;
            public sg_imgui_capture_item_t e26;
            public sg_imgui_capture_item_t e27;
            public sg_imgui_capture_item_t e28;
            public sg_imgui_capture_item_t e29;
            public sg_imgui_capture_item_t e30;
            public sg_imgui_capture_item_t e31;
            public sg_imgui_capture_item_t e32;
            public sg_imgui_capture_item_t e33;
            public sg_imgui_capture_item_t e34;
            public sg_imgui_capture_item_t e35;
            public sg_imgui_capture_item_t e36;
            public sg_imgui_capture_item_t e37;
            public sg_imgui_capture_item_t e38;
            public sg_imgui_capture_item_t e39;
            public sg_imgui_capture_item_t e40;
            public sg_imgui_capture_item_t e41;
            public sg_imgui_capture_item_t e42;
            public sg_imgui_capture_item_t e43;
            public sg_imgui_capture_item_t e44;
            public sg_imgui_capture_item_t e45;
            public sg_imgui_capture_item_t e46;
            public sg_imgui_capture_item_t e47;
            public sg_imgui_capture_item_t e48;
            public sg_imgui_capture_item_t e49;
            public sg_imgui_capture_item_t e50;
            public sg_imgui_capture_item_t e51;
            public sg_imgui_capture_item_t e52;
            public sg_imgui_capture_item_t e53;
            public sg_imgui_capture_item_t e54;
            public sg_imgui_capture_item_t e55;
            public sg_imgui_capture_item_t e56;
            public sg_imgui_capture_item_t e57;
            public sg_imgui_capture_item_t e58;
            public sg_imgui_capture_item_t e59;
            public sg_imgui_capture_item_t e60;
            public sg_imgui_capture_item_t e61;
            public sg_imgui_capture_item_t e62;
            public sg_imgui_capture_item_t e63;
            public sg_imgui_capture_item_t e64;
            public sg_imgui_capture_item_t e65;
            public sg_imgui_capture_item_t e66;
            public sg_imgui_capture_item_t e67;
            public sg_imgui_capture_item_t e68;
            public sg_imgui_capture_item_t e69;
            public sg_imgui_capture_item_t e70;
            public sg_imgui_capture_item_t e71;
            public sg_imgui_capture_item_t e72;
            public sg_imgui_capture_item_t e73;
            public sg_imgui_capture_item_t e74;
            public sg_imgui_capture_item_t e75;
            public sg_imgui_capture_item_t e76;
            public sg_imgui_capture_item_t e77;
            public sg_imgui_capture_item_t e78;
            public sg_imgui_capture_item_t e79;
            public sg_imgui_capture_item_t e80;
            public sg_imgui_capture_item_t e81;
            public sg_imgui_capture_item_t e82;
            public sg_imgui_capture_item_t e83;
            public sg_imgui_capture_item_t e84;
            public sg_imgui_capture_item_t e85;
            public sg_imgui_capture_item_t e86;
            public sg_imgui_capture_item_t e87;
            public sg_imgui_capture_item_t e88;
            public sg_imgui_capture_item_t e89;
            public sg_imgui_capture_item_t e90;
            public sg_imgui_capture_item_t e91;
            public sg_imgui_capture_item_t e92;
            public sg_imgui_capture_item_t e93;
            public sg_imgui_capture_item_t e94;
            public sg_imgui_capture_item_t e95;
            public sg_imgui_capture_item_t e96;
            public sg_imgui_capture_item_t e97;
            public sg_imgui_capture_item_t e98;
            public sg_imgui_capture_item_t e99;
            public sg_imgui_capture_item_t e100;
            public sg_imgui_capture_item_t e101;
            public sg_imgui_capture_item_t e102;
            public sg_imgui_capture_item_t e103;
            public sg_imgui_capture_item_t e104;
            public sg_imgui_capture_item_t e105;
            public sg_imgui_capture_item_t e106;
            public sg_imgui_capture_item_t e107;
            public sg_imgui_capture_item_t e108;
            public sg_imgui_capture_item_t e109;
            public sg_imgui_capture_item_t e110;
            public sg_imgui_capture_item_t e111;
            public sg_imgui_capture_item_t e112;
            public sg_imgui_capture_item_t e113;
            public sg_imgui_capture_item_t e114;
            public sg_imgui_capture_item_t e115;
            public sg_imgui_capture_item_t e116;
            public sg_imgui_capture_item_t e117;
            public sg_imgui_capture_item_t e118;
            public sg_imgui_capture_item_t e119;
            public sg_imgui_capture_item_t e120;
            public sg_imgui_capture_item_t e121;
            public sg_imgui_capture_item_t e122;
            public sg_imgui_capture_item_t e123;
            public sg_imgui_capture_item_t e124;
            public sg_imgui_capture_item_t e125;
            public sg_imgui_capture_item_t e126;
            public sg_imgui_capture_item_t e127;
            public sg_imgui_capture_item_t e128;
            public sg_imgui_capture_item_t e129;
            public sg_imgui_capture_item_t e130;
            public sg_imgui_capture_item_t e131;
            public sg_imgui_capture_item_t e132;
            public sg_imgui_capture_item_t e133;
            public sg_imgui_capture_item_t e134;
            public sg_imgui_capture_item_t e135;
            public sg_imgui_capture_item_t e136;
            public sg_imgui_capture_item_t e137;
            public sg_imgui_capture_item_t e138;
            public sg_imgui_capture_item_t e139;
            public sg_imgui_capture_item_t e140;
            public sg_imgui_capture_item_t e141;
            public sg_imgui_capture_item_t e142;
            public sg_imgui_capture_item_t e143;
            public sg_imgui_capture_item_t e144;
            public sg_imgui_capture_item_t e145;
            public sg_imgui_capture_item_t e146;
            public sg_imgui_capture_item_t e147;
            public sg_imgui_capture_item_t e148;
            public sg_imgui_capture_item_t e149;
            public sg_imgui_capture_item_t e150;
            public sg_imgui_capture_item_t e151;
            public sg_imgui_capture_item_t e152;
            public sg_imgui_capture_item_t e153;
            public sg_imgui_capture_item_t e154;
            public sg_imgui_capture_item_t e155;
            public sg_imgui_capture_item_t e156;
            public sg_imgui_capture_item_t e157;
            public sg_imgui_capture_item_t e158;
            public sg_imgui_capture_item_t e159;
            public sg_imgui_capture_item_t e160;
            public sg_imgui_capture_item_t e161;
            public sg_imgui_capture_item_t e162;
            public sg_imgui_capture_item_t e163;
            public sg_imgui_capture_item_t e164;
            public sg_imgui_capture_item_t e165;
            public sg_imgui_capture_item_t e166;
            public sg_imgui_capture_item_t e167;
            public sg_imgui_capture_item_t e168;
            public sg_imgui_capture_item_t e169;
            public sg_imgui_capture_item_t e170;
            public sg_imgui_capture_item_t e171;
            public sg_imgui_capture_item_t e172;
            public sg_imgui_capture_item_t e173;
            public sg_imgui_capture_item_t e174;
            public sg_imgui_capture_item_t e175;
            public sg_imgui_capture_item_t e176;
            public sg_imgui_capture_item_t e177;
            public sg_imgui_capture_item_t e178;
            public sg_imgui_capture_item_t e179;
            public sg_imgui_capture_item_t e180;
            public sg_imgui_capture_item_t e181;
            public sg_imgui_capture_item_t e182;
            public sg_imgui_capture_item_t e183;
            public sg_imgui_capture_item_t e184;
            public sg_imgui_capture_item_t e185;
            public sg_imgui_capture_item_t e186;
            public sg_imgui_capture_item_t e187;
            public sg_imgui_capture_item_t e188;
            public sg_imgui_capture_item_t e189;
            public sg_imgui_capture_item_t e190;
            public sg_imgui_capture_item_t e191;
            public sg_imgui_capture_item_t e192;
            public sg_imgui_capture_item_t e193;
            public sg_imgui_capture_item_t e194;
            public sg_imgui_capture_item_t e195;
            public sg_imgui_capture_item_t e196;
            public sg_imgui_capture_item_t e197;
            public sg_imgui_capture_item_t e198;
            public sg_imgui_capture_item_t e199;
            public sg_imgui_capture_item_t e200;
            public sg_imgui_capture_item_t e201;
            public sg_imgui_capture_item_t e202;
            public sg_imgui_capture_item_t e203;
            public sg_imgui_capture_item_t e204;
            public sg_imgui_capture_item_t e205;
            public sg_imgui_capture_item_t e206;
            public sg_imgui_capture_item_t e207;
            public sg_imgui_capture_item_t e208;
            public sg_imgui_capture_item_t e209;
            public sg_imgui_capture_item_t e210;
            public sg_imgui_capture_item_t e211;
            public sg_imgui_capture_item_t e212;
            public sg_imgui_capture_item_t e213;
            public sg_imgui_capture_item_t e214;
            public sg_imgui_capture_item_t e215;
            public sg_imgui_capture_item_t e216;
            public sg_imgui_capture_item_t e217;
            public sg_imgui_capture_item_t e218;
            public sg_imgui_capture_item_t e219;
            public sg_imgui_capture_item_t e220;
            public sg_imgui_capture_item_t e221;
            public sg_imgui_capture_item_t e222;
            public sg_imgui_capture_item_t e223;
            public sg_imgui_capture_item_t e224;
            public sg_imgui_capture_item_t e225;
            public sg_imgui_capture_item_t e226;
            public sg_imgui_capture_item_t e227;
            public sg_imgui_capture_item_t e228;
            public sg_imgui_capture_item_t e229;
            public sg_imgui_capture_item_t e230;
            public sg_imgui_capture_item_t e231;
            public sg_imgui_capture_item_t e232;
            public sg_imgui_capture_item_t e233;
            public sg_imgui_capture_item_t e234;
            public sg_imgui_capture_item_t e235;
            public sg_imgui_capture_item_t e236;
            public sg_imgui_capture_item_t e237;
            public sg_imgui_capture_item_t e238;
            public sg_imgui_capture_item_t e239;
            public sg_imgui_capture_item_t e240;
            public sg_imgui_capture_item_t e241;
            public sg_imgui_capture_item_t e242;
            public sg_imgui_capture_item_t e243;
            public sg_imgui_capture_item_t e244;
            public sg_imgui_capture_item_t e245;
            public sg_imgui_capture_item_t e246;
            public sg_imgui_capture_item_t e247;
            public sg_imgui_capture_item_t e248;
            public sg_imgui_capture_item_t e249;
            public sg_imgui_capture_item_t e250;
            public sg_imgui_capture_item_t e251;
            public sg_imgui_capture_item_t e252;
            public sg_imgui_capture_item_t e253;
            public sg_imgui_capture_item_t e254;
            public sg_imgui_capture_item_t e255;
            public sg_imgui_capture_item_t e256;
            public sg_imgui_capture_item_t e257;
            public sg_imgui_capture_item_t e258;
            public sg_imgui_capture_item_t e259;
            public sg_imgui_capture_item_t e260;
            public sg_imgui_capture_item_t e261;
            public sg_imgui_capture_item_t e262;
            public sg_imgui_capture_item_t e263;
            public sg_imgui_capture_item_t e264;
            public sg_imgui_capture_item_t e265;
            public sg_imgui_capture_item_t e266;
            public sg_imgui_capture_item_t e267;
            public sg_imgui_capture_item_t e268;
            public sg_imgui_capture_item_t e269;
            public sg_imgui_capture_item_t e270;
            public sg_imgui_capture_item_t e271;
            public sg_imgui_capture_item_t e272;
            public sg_imgui_capture_item_t e273;
            public sg_imgui_capture_item_t e274;
            public sg_imgui_capture_item_t e275;
            public sg_imgui_capture_item_t e276;
            public sg_imgui_capture_item_t e277;
            public sg_imgui_capture_item_t e278;
            public sg_imgui_capture_item_t e279;
            public sg_imgui_capture_item_t e280;
            public sg_imgui_capture_item_t e281;
            public sg_imgui_capture_item_t e282;
            public sg_imgui_capture_item_t e283;
            public sg_imgui_capture_item_t e284;
            public sg_imgui_capture_item_t e285;
            public sg_imgui_capture_item_t e286;
            public sg_imgui_capture_item_t e287;
            public sg_imgui_capture_item_t e288;
            public sg_imgui_capture_item_t e289;
            public sg_imgui_capture_item_t e290;
            public sg_imgui_capture_item_t e291;
            public sg_imgui_capture_item_t e292;
            public sg_imgui_capture_item_t e293;
            public sg_imgui_capture_item_t e294;
            public sg_imgui_capture_item_t e295;
            public sg_imgui_capture_item_t e296;
            public sg_imgui_capture_item_t e297;
            public sg_imgui_capture_item_t e298;
            public sg_imgui_capture_item_t e299;
            public sg_imgui_capture_item_t e300;
            public sg_imgui_capture_item_t e301;
            public sg_imgui_capture_item_t e302;
            public sg_imgui_capture_item_t e303;
            public sg_imgui_capture_item_t e304;
            public sg_imgui_capture_item_t e305;
            public sg_imgui_capture_item_t e306;
            public sg_imgui_capture_item_t e307;
            public sg_imgui_capture_item_t e308;
            public sg_imgui_capture_item_t e309;
            public sg_imgui_capture_item_t e310;
            public sg_imgui_capture_item_t e311;
            public sg_imgui_capture_item_t e312;
            public sg_imgui_capture_item_t e313;
            public sg_imgui_capture_item_t e314;
            public sg_imgui_capture_item_t e315;
            public sg_imgui_capture_item_t e316;
            public sg_imgui_capture_item_t e317;
            public sg_imgui_capture_item_t e318;
            public sg_imgui_capture_item_t e319;
            public sg_imgui_capture_item_t e320;
            public sg_imgui_capture_item_t e321;
            public sg_imgui_capture_item_t e322;
            public sg_imgui_capture_item_t e323;
            public sg_imgui_capture_item_t e324;
            public sg_imgui_capture_item_t e325;
            public sg_imgui_capture_item_t e326;
            public sg_imgui_capture_item_t e327;
            public sg_imgui_capture_item_t e328;
            public sg_imgui_capture_item_t e329;
            public sg_imgui_capture_item_t e330;
            public sg_imgui_capture_item_t e331;
            public sg_imgui_capture_item_t e332;
            public sg_imgui_capture_item_t e333;
            public sg_imgui_capture_item_t e334;
            public sg_imgui_capture_item_t e335;
            public sg_imgui_capture_item_t e336;
            public sg_imgui_capture_item_t e337;
            public sg_imgui_capture_item_t e338;
            public sg_imgui_capture_item_t e339;
            public sg_imgui_capture_item_t e340;
            public sg_imgui_capture_item_t e341;
            public sg_imgui_capture_item_t e342;
            public sg_imgui_capture_item_t e343;
            public sg_imgui_capture_item_t e344;
            public sg_imgui_capture_item_t e345;
            public sg_imgui_capture_item_t e346;
            public sg_imgui_capture_item_t e347;
            public sg_imgui_capture_item_t e348;
            public sg_imgui_capture_item_t e349;
            public sg_imgui_capture_item_t e350;
            public sg_imgui_capture_item_t e351;
            public sg_imgui_capture_item_t e352;
            public sg_imgui_capture_item_t e353;
            public sg_imgui_capture_item_t e354;
            public sg_imgui_capture_item_t e355;
            public sg_imgui_capture_item_t e356;
            public sg_imgui_capture_item_t e357;
            public sg_imgui_capture_item_t e358;
            public sg_imgui_capture_item_t e359;
            public sg_imgui_capture_item_t e360;
            public sg_imgui_capture_item_t e361;
            public sg_imgui_capture_item_t e362;
            public sg_imgui_capture_item_t e363;
            public sg_imgui_capture_item_t e364;
            public sg_imgui_capture_item_t e365;
            public sg_imgui_capture_item_t e366;
            public sg_imgui_capture_item_t e367;
            public sg_imgui_capture_item_t e368;
            public sg_imgui_capture_item_t e369;
            public sg_imgui_capture_item_t e370;
            public sg_imgui_capture_item_t e371;
            public sg_imgui_capture_item_t e372;
            public sg_imgui_capture_item_t e373;
            public sg_imgui_capture_item_t e374;
            public sg_imgui_capture_item_t e375;
            public sg_imgui_capture_item_t e376;
            public sg_imgui_capture_item_t e377;
            public sg_imgui_capture_item_t e378;
            public sg_imgui_capture_item_t e379;
            public sg_imgui_capture_item_t e380;
            public sg_imgui_capture_item_t e381;
            public sg_imgui_capture_item_t e382;
            public sg_imgui_capture_item_t e383;
            public sg_imgui_capture_item_t e384;
            public sg_imgui_capture_item_t e385;
            public sg_imgui_capture_item_t e386;
            public sg_imgui_capture_item_t e387;
            public sg_imgui_capture_item_t e388;
            public sg_imgui_capture_item_t e389;
            public sg_imgui_capture_item_t e390;
            public sg_imgui_capture_item_t e391;
            public sg_imgui_capture_item_t e392;
            public sg_imgui_capture_item_t e393;
            public sg_imgui_capture_item_t e394;
            public sg_imgui_capture_item_t e395;
            public sg_imgui_capture_item_t e396;
            public sg_imgui_capture_item_t e397;
            public sg_imgui_capture_item_t e398;
            public sg_imgui_capture_item_t e399;
            public sg_imgui_capture_item_t e400;
            public sg_imgui_capture_item_t e401;
            public sg_imgui_capture_item_t e402;
            public sg_imgui_capture_item_t e403;
            public sg_imgui_capture_item_t e404;
            public sg_imgui_capture_item_t e405;
            public sg_imgui_capture_item_t e406;
            public sg_imgui_capture_item_t e407;
            public sg_imgui_capture_item_t e408;
            public sg_imgui_capture_item_t e409;
            public sg_imgui_capture_item_t e410;
            public sg_imgui_capture_item_t e411;
            public sg_imgui_capture_item_t e412;
            public sg_imgui_capture_item_t e413;
            public sg_imgui_capture_item_t e414;
            public sg_imgui_capture_item_t e415;
            public sg_imgui_capture_item_t e416;
            public sg_imgui_capture_item_t e417;
            public sg_imgui_capture_item_t e418;
            public sg_imgui_capture_item_t e419;
            public sg_imgui_capture_item_t e420;
            public sg_imgui_capture_item_t e421;
            public sg_imgui_capture_item_t e422;
            public sg_imgui_capture_item_t e423;
            public sg_imgui_capture_item_t e424;
            public sg_imgui_capture_item_t e425;
            public sg_imgui_capture_item_t e426;
            public sg_imgui_capture_item_t e427;
            public sg_imgui_capture_item_t e428;
            public sg_imgui_capture_item_t e429;
            public sg_imgui_capture_item_t e430;
            public sg_imgui_capture_item_t e431;
            public sg_imgui_capture_item_t e432;
            public sg_imgui_capture_item_t e433;
            public sg_imgui_capture_item_t e434;
            public sg_imgui_capture_item_t e435;
            public sg_imgui_capture_item_t e436;
            public sg_imgui_capture_item_t e437;
            public sg_imgui_capture_item_t e438;
            public sg_imgui_capture_item_t e439;
            public sg_imgui_capture_item_t e440;
            public sg_imgui_capture_item_t e441;
            public sg_imgui_capture_item_t e442;
            public sg_imgui_capture_item_t e443;
            public sg_imgui_capture_item_t e444;
            public sg_imgui_capture_item_t e445;
            public sg_imgui_capture_item_t e446;
            public sg_imgui_capture_item_t e447;
            public sg_imgui_capture_item_t e448;
            public sg_imgui_capture_item_t e449;
            public sg_imgui_capture_item_t e450;
            public sg_imgui_capture_item_t e451;
            public sg_imgui_capture_item_t e452;
            public sg_imgui_capture_item_t e453;
            public sg_imgui_capture_item_t e454;
            public sg_imgui_capture_item_t e455;
            public sg_imgui_capture_item_t e456;
            public sg_imgui_capture_item_t e457;
            public sg_imgui_capture_item_t e458;
            public sg_imgui_capture_item_t e459;
            public sg_imgui_capture_item_t e460;
            public sg_imgui_capture_item_t e461;
            public sg_imgui_capture_item_t e462;
            public sg_imgui_capture_item_t e463;
            public sg_imgui_capture_item_t e464;
            public sg_imgui_capture_item_t e465;
            public sg_imgui_capture_item_t e466;
            public sg_imgui_capture_item_t e467;
            public sg_imgui_capture_item_t e468;
            public sg_imgui_capture_item_t e469;
            public sg_imgui_capture_item_t e470;
            public sg_imgui_capture_item_t e471;
            public sg_imgui_capture_item_t e472;
            public sg_imgui_capture_item_t e473;
            public sg_imgui_capture_item_t e474;
            public sg_imgui_capture_item_t e475;
            public sg_imgui_capture_item_t e476;
            public sg_imgui_capture_item_t e477;
            public sg_imgui_capture_item_t e478;
            public sg_imgui_capture_item_t e479;
            public sg_imgui_capture_item_t e480;
            public sg_imgui_capture_item_t e481;
            public sg_imgui_capture_item_t e482;
            public sg_imgui_capture_item_t e483;
            public sg_imgui_capture_item_t e484;
            public sg_imgui_capture_item_t e485;
            public sg_imgui_capture_item_t e486;
            public sg_imgui_capture_item_t e487;
            public sg_imgui_capture_item_t e488;
            public sg_imgui_capture_item_t e489;
            public sg_imgui_capture_item_t e490;
            public sg_imgui_capture_item_t e491;
            public sg_imgui_capture_item_t e492;
            public sg_imgui_capture_item_t e493;
            public sg_imgui_capture_item_t e494;
            public sg_imgui_capture_item_t e495;
            public sg_imgui_capture_item_t e496;
            public sg_imgui_capture_item_t e497;
            public sg_imgui_capture_item_t e498;
            public sg_imgui_capture_item_t e499;
            public sg_imgui_capture_item_t e500;
            public sg_imgui_capture_item_t e501;
            public sg_imgui_capture_item_t e502;
            public sg_imgui_capture_item_t e503;
            public sg_imgui_capture_item_t e504;
            public sg_imgui_capture_item_t e505;
            public sg_imgui_capture_item_t e506;
            public sg_imgui_capture_item_t e507;
            public sg_imgui_capture_item_t e508;
            public sg_imgui_capture_item_t e509;
            public sg_imgui_capture_item_t e510;
            public sg_imgui_capture_item_t e511;
            public sg_imgui_capture_item_t e512;
            public sg_imgui_capture_item_t e513;
            public sg_imgui_capture_item_t e514;
            public sg_imgui_capture_item_t e515;
            public sg_imgui_capture_item_t e516;
            public sg_imgui_capture_item_t e517;
            public sg_imgui_capture_item_t e518;
            public sg_imgui_capture_item_t e519;
            public sg_imgui_capture_item_t e520;
            public sg_imgui_capture_item_t e521;
            public sg_imgui_capture_item_t e522;
            public sg_imgui_capture_item_t e523;
            public sg_imgui_capture_item_t e524;
            public sg_imgui_capture_item_t e525;
            public sg_imgui_capture_item_t e526;
            public sg_imgui_capture_item_t e527;
            public sg_imgui_capture_item_t e528;
            public sg_imgui_capture_item_t e529;
            public sg_imgui_capture_item_t e530;
            public sg_imgui_capture_item_t e531;
            public sg_imgui_capture_item_t e532;
            public sg_imgui_capture_item_t e533;
            public sg_imgui_capture_item_t e534;
            public sg_imgui_capture_item_t e535;
            public sg_imgui_capture_item_t e536;
            public sg_imgui_capture_item_t e537;
            public sg_imgui_capture_item_t e538;
            public sg_imgui_capture_item_t e539;
            public sg_imgui_capture_item_t e540;
            public sg_imgui_capture_item_t e541;
            public sg_imgui_capture_item_t e542;
            public sg_imgui_capture_item_t e543;
            public sg_imgui_capture_item_t e544;
            public sg_imgui_capture_item_t e545;
            public sg_imgui_capture_item_t e546;
            public sg_imgui_capture_item_t e547;
            public sg_imgui_capture_item_t e548;
            public sg_imgui_capture_item_t e549;
            public sg_imgui_capture_item_t e550;
            public sg_imgui_capture_item_t e551;
            public sg_imgui_capture_item_t e552;
            public sg_imgui_capture_item_t e553;
            public sg_imgui_capture_item_t e554;
            public sg_imgui_capture_item_t e555;
            public sg_imgui_capture_item_t e556;
            public sg_imgui_capture_item_t e557;
            public sg_imgui_capture_item_t e558;
            public sg_imgui_capture_item_t e559;
            public sg_imgui_capture_item_t e560;
            public sg_imgui_capture_item_t e561;
            public sg_imgui_capture_item_t e562;
            public sg_imgui_capture_item_t e563;
            public sg_imgui_capture_item_t e564;
            public sg_imgui_capture_item_t e565;
            public sg_imgui_capture_item_t e566;
            public sg_imgui_capture_item_t e567;
            public sg_imgui_capture_item_t e568;
            public sg_imgui_capture_item_t e569;
            public sg_imgui_capture_item_t e570;
            public sg_imgui_capture_item_t e571;
            public sg_imgui_capture_item_t e572;
            public sg_imgui_capture_item_t e573;
            public sg_imgui_capture_item_t e574;
            public sg_imgui_capture_item_t e575;
            public sg_imgui_capture_item_t e576;
            public sg_imgui_capture_item_t e577;
            public sg_imgui_capture_item_t e578;
            public sg_imgui_capture_item_t e579;
            public sg_imgui_capture_item_t e580;
            public sg_imgui_capture_item_t e581;
            public sg_imgui_capture_item_t e582;
            public sg_imgui_capture_item_t e583;
            public sg_imgui_capture_item_t e584;
            public sg_imgui_capture_item_t e585;
            public sg_imgui_capture_item_t e586;
            public sg_imgui_capture_item_t e587;
            public sg_imgui_capture_item_t e588;
            public sg_imgui_capture_item_t e589;
            public sg_imgui_capture_item_t e590;
            public sg_imgui_capture_item_t e591;
            public sg_imgui_capture_item_t e592;
            public sg_imgui_capture_item_t e593;
            public sg_imgui_capture_item_t e594;
            public sg_imgui_capture_item_t e595;
            public sg_imgui_capture_item_t e596;
            public sg_imgui_capture_item_t e597;
            public sg_imgui_capture_item_t e598;
            public sg_imgui_capture_item_t e599;
            public sg_imgui_capture_item_t e600;
            public sg_imgui_capture_item_t e601;
            public sg_imgui_capture_item_t e602;
            public sg_imgui_capture_item_t e603;
            public sg_imgui_capture_item_t e604;
            public sg_imgui_capture_item_t e605;
            public sg_imgui_capture_item_t e606;
            public sg_imgui_capture_item_t e607;
            public sg_imgui_capture_item_t e608;
            public sg_imgui_capture_item_t e609;
            public sg_imgui_capture_item_t e610;
            public sg_imgui_capture_item_t e611;
            public sg_imgui_capture_item_t e612;
            public sg_imgui_capture_item_t e613;
            public sg_imgui_capture_item_t e614;
            public sg_imgui_capture_item_t e615;
            public sg_imgui_capture_item_t e616;
            public sg_imgui_capture_item_t e617;
            public sg_imgui_capture_item_t e618;
            public sg_imgui_capture_item_t e619;
            public sg_imgui_capture_item_t e620;
            public sg_imgui_capture_item_t e621;
            public sg_imgui_capture_item_t e622;
            public sg_imgui_capture_item_t e623;
            public sg_imgui_capture_item_t e624;
            public sg_imgui_capture_item_t e625;
            public sg_imgui_capture_item_t e626;
            public sg_imgui_capture_item_t e627;
            public sg_imgui_capture_item_t e628;
            public sg_imgui_capture_item_t e629;
            public sg_imgui_capture_item_t e630;
            public sg_imgui_capture_item_t e631;
            public sg_imgui_capture_item_t e632;
            public sg_imgui_capture_item_t e633;
            public sg_imgui_capture_item_t e634;
            public sg_imgui_capture_item_t e635;
            public sg_imgui_capture_item_t e636;
            public sg_imgui_capture_item_t e637;
            public sg_imgui_capture_item_t e638;
            public sg_imgui_capture_item_t e639;
            public sg_imgui_capture_item_t e640;
            public sg_imgui_capture_item_t e641;
            public sg_imgui_capture_item_t e642;
            public sg_imgui_capture_item_t e643;
            public sg_imgui_capture_item_t e644;
            public sg_imgui_capture_item_t e645;
            public sg_imgui_capture_item_t e646;
            public sg_imgui_capture_item_t e647;
            public sg_imgui_capture_item_t e648;
            public sg_imgui_capture_item_t e649;
            public sg_imgui_capture_item_t e650;
            public sg_imgui_capture_item_t e651;
            public sg_imgui_capture_item_t e652;
            public sg_imgui_capture_item_t e653;
            public sg_imgui_capture_item_t e654;
            public sg_imgui_capture_item_t e655;
            public sg_imgui_capture_item_t e656;
            public sg_imgui_capture_item_t e657;
            public sg_imgui_capture_item_t e658;
            public sg_imgui_capture_item_t e659;
            public sg_imgui_capture_item_t e660;
            public sg_imgui_capture_item_t e661;
            public sg_imgui_capture_item_t e662;
            public sg_imgui_capture_item_t e663;
            public sg_imgui_capture_item_t e664;
            public sg_imgui_capture_item_t e665;
            public sg_imgui_capture_item_t e666;
            public sg_imgui_capture_item_t e667;
            public sg_imgui_capture_item_t e668;
            public sg_imgui_capture_item_t e669;
            public sg_imgui_capture_item_t e670;
            public sg_imgui_capture_item_t e671;
            public sg_imgui_capture_item_t e672;
            public sg_imgui_capture_item_t e673;
            public sg_imgui_capture_item_t e674;
            public sg_imgui_capture_item_t e675;
            public sg_imgui_capture_item_t e676;
            public sg_imgui_capture_item_t e677;
            public sg_imgui_capture_item_t e678;
            public sg_imgui_capture_item_t e679;
            public sg_imgui_capture_item_t e680;
            public sg_imgui_capture_item_t e681;
            public sg_imgui_capture_item_t e682;
            public sg_imgui_capture_item_t e683;
            public sg_imgui_capture_item_t e684;
            public sg_imgui_capture_item_t e685;
            public sg_imgui_capture_item_t e686;
            public sg_imgui_capture_item_t e687;
            public sg_imgui_capture_item_t e688;
            public sg_imgui_capture_item_t e689;
            public sg_imgui_capture_item_t e690;
            public sg_imgui_capture_item_t e691;
            public sg_imgui_capture_item_t e692;
            public sg_imgui_capture_item_t e693;
            public sg_imgui_capture_item_t e694;
            public sg_imgui_capture_item_t e695;
            public sg_imgui_capture_item_t e696;
            public sg_imgui_capture_item_t e697;
            public sg_imgui_capture_item_t e698;
            public sg_imgui_capture_item_t e699;
            public sg_imgui_capture_item_t e700;
            public sg_imgui_capture_item_t e701;
            public sg_imgui_capture_item_t e702;
            public sg_imgui_capture_item_t e703;
            public sg_imgui_capture_item_t e704;
            public sg_imgui_capture_item_t e705;
            public sg_imgui_capture_item_t e706;
            public sg_imgui_capture_item_t e707;
            public sg_imgui_capture_item_t e708;
            public sg_imgui_capture_item_t e709;
            public sg_imgui_capture_item_t e710;
            public sg_imgui_capture_item_t e711;
            public sg_imgui_capture_item_t e712;
            public sg_imgui_capture_item_t e713;
            public sg_imgui_capture_item_t e714;
            public sg_imgui_capture_item_t e715;
            public sg_imgui_capture_item_t e716;
            public sg_imgui_capture_item_t e717;
            public sg_imgui_capture_item_t e718;
            public sg_imgui_capture_item_t e719;
            public sg_imgui_capture_item_t e720;
            public sg_imgui_capture_item_t e721;
            public sg_imgui_capture_item_t e722;
            public sg_imgui_capture_item_t e723;
            public sg_imgui_capture_item_t e724;
            public sg_imgui_capture_item_t e725;
            public sg_imgui_capture_item_t e726;
            public sg_imgui_capture_item_t e727;
            public sg_imgui_capture_item_t e728;
            public sg_imgui_capture_item_t e729;
            public sg_imgui_capture_item_t e730;
            public sg_imgui_capture_item_t e731;
            public sg_imgui_capture_item_t e732;
            public sg_imgui_capture_item_t e733;
            public sg_imgui_capture_item_t e734;
            public sg_imgui_capture_item_t e735;
            public sg_imgui_capture_item_t e736;
            public sg_imgui_capture_item_t e737;
            public sg_imgui_capture_item_t e738;
            public sg_imgui_capture_item_t e739;
            public sg_imgui_capture_item_t e740;
            public sg_imgui_capture_item_t e741;
            public sg_imgui_capture_item_t e742;
            public sg_imgui_capture_item_t e743;
            public sg_imgui_capture_item_t e744;
            public sg_imgui_capture_item_t e745;
            public sg_imgui_capture_item_t e746;
            public sg_imgui_capture_item_t e747;
            public sg_imgui_capture_item_t e748;
            public sg_imgui_capture_item_t e749;
            public sg_imgui_capture_item_t e750;
            public sg_imgui_capture_item_t e751;
            public sg_imgui_capture_item_t e752;
            public sg_imgui_capture_item_t e753;
            public sg_imgui_capture_item_t e754;
            public sg_imgui_capture_item_t e755;
            public sg_imgui_capture_item_t e756;
            public sg_imgui_capture_item_t e757;
            public sg_imgui_capture_item_t e758;
            public sg_imgui_capture_item_t e759;
            public sg_imgui_capture_item_t e760;
            public sg_imgui_capture_item_t e761;
            public sg_imgui_capture_item_t e762;
            public sg_imgui_capture_item_t e763;
            public sg_imgui_capture_item_t e764;
            public sg_imgui_capture_item_t e765;
            public sg_imgui_capture_item_t e766;
            public sg_imgui_capture_item_t e767;
            public sg_imgui_capture_item_t e768;
            public sg_imgui_capture_item_t e769;
            public sg_imgui_capture_item_t e770;
            public sg_imgui_capture_item_t e771;
            public sg_imgui_capture_item_t e772;
            public sg_imgui_capture_item_t e773;
            public sg_imgui_capture_item_t e774;
            public sg_imgui_capture_item_t e775;
            public sg_imgui_capture_item_t e776;
            public sg_imgui_capture_item_t e777;
            public sg_imgui_capture_item_t e778;
            public sg_imgui_capture_item_t e779;
            public sg_imgui_capture_item_t e780;
            public sg_imgui_capture_item_t e781;
            public sg_imgui_capture_item_t e782;
            public sg_imgui_capture_item_t e783;
            public sg_imgui_capture_item_t e784;
            public sg_imgui_capture_item_t e785;
            public sg_imgui_capture_item_t e786;
            public sg_imgui_capture_item_t e787;
            public sg_imgui_capture_item_t e788;
            public sg_imgui_capture_item_t e789;
            public sg_imgui_capture_item_t e790;
            public sg_imgui_capture_item_t e791;
            public sg_imgui_capture_item_t e792;
            public sg_imgui_capture_item_t e793;
            public sg_imgui_capture_item_t e794;
            public sg_imgui_capture_item_t e795;
            public sg_imgui_capture_item_t e796;
            public sg_imgui_capture_item_t e797;
            public sg_imgui_capture_item_t e798;
            public sg_imgui_capture_item_t e799;
            public sg_imgui_capture_item_t e800;
            public sg_imgui_capture_item_t e801;
            public sg_imgui_capture_item_t e802;
            public sg_imgui_capture_item_t e803;
            public sg_imgui_capture_item_t e804;
            public sg_imgui_capture_item_t e805;
            public sg_imgui_capture_item_t e806;
            public sg_imgui_capture_item_t e807;
            public sg_imgui_capture_item_t e808;
            public sg_imgui_capture_item_t e809;
            public sg_imgui_capture_item_t e810;
            public sg_imgui_capture_item_t e811;
            public sg_imgui_capture_item_t e812;
            public sg_imgui_capture_item_t e813;
            public sg_imgui_capture_item_t e814;
            public sg_imgui_capture_item_t e815;
            public sg_imgui_capture_item_t e816;
            public sg_imgui_capture_item_t e817;
            public sg_imgui_capture_item_t e818;
            public sg_imgui_capture_item_t e819;
            public sg_imgui_capture_item_t e820;
            public sg_imgui_capture_item_t e821;
            public sg_imgui_capture_item_t e822;
            public sg_imgui_capture_item_t e823;
            public sg_imgui_capture_item_t e824;
            public sg_imgui_capture_item_t e825;
            public sg_imgui_capture_item_t e826;
            public sg_imgui_capture_item_t e827;
            public sg_imgui_capture_item_t e828;
            public sg_imgui_capture_item_t e829;
            public sg_imgui_capture_item_t e830;
            public sg_imgui_capture_item_t e831;
            public sg_imgui_capture_item_t e832;
            public sg_imgui_capture_item_t e833;
            public sg_imgui_capture_item_t e834;
            public sg_imgui_capture_item_t e835;
            public sg_imgui_capture_item_t e836;
            public sg_imgui_capture_item_t e837;
            public sg_imgui_capture_item_t e838;
            public sg_imgui_capture_item_t e839;
            public sg_imgui_capture_item_t e840;
            public sg_imgui_capture_item_t e841;
            public sg_imgui_capture_item_t e842;
            public sg_imgui_capture_item_t e843;
            public sg_imgui_capture_item_t e844;
            public sg_imgui_capture_item_t e845;
            public sg_imgui_capture_item_t e846;
            public sg_imgui_capture_item_t e847;
            public sg_imgui_capture_item_t e848;
            public sg_imgui_capture_item_t e849;
            public sg_imgui_capture_item_t e850;
            public sg_imgui_capture_item_t e851;
            public sg_imgui_capture_item_t e852;
            public sg_imgui_capture_item_t e853;
            public sg_imgui_capture_item_t e854;
            public sg_imgui_capture_item_t e855;
            public sg_imgui_capture_item_t e856;
            public sg_imgui_capture_item_t e857;
            public sg_imgui_capture_item_t e858;
            public sg_imgui_capture_item_t e859;
            public sg_imgui_capture_item_t e860;
            public sg_imgui_capture_item_t e861;
            public sg_imgui_capture_item_t e862;
            public sg_imgui_capture_item_t e863;
            public sg_imgui_capture_item_t e864;
            public sg_imgui_capture_item_t e865;
            public sg_imgui_capture_item_t e866;
            public sg_imgui_capture_item_t e867;
            public sg_imgui_capture_item_t e868;
            public sg_imgui_capture_item_t e869;
            public sg_imgui_capture_item_t e870;
            public sg_imgui_capture_item_t e871;
            public sg_imgui_capture_item_t e872;
            public sg_imgui_capture_item_t e873;
            public sg_imgui_capture_item_t e874;
            public sg_imgui_capture_item_t e875;
            public sg_imgui_capture_item_t e876;
            public sg_imgui_capture_item_t e877;
            public sg_imgui_capture_item_t e878;
            public sg_imgui_capture_item_t e879;
            public sg_imgui_capture_item_t e880;
            public sg_imgui_capture_item_t e881;
            public sg_imgui_capture_item_t e882;
            public sg_imgui_capture_item_t e883;
            public sg_imgui_capture_item_t e884;
            public sg_imgui_capture_item_t e885;
            public sg_imgui_capture_item_t e886;
            public sg_imgui_capture_item_t e887;
            public sg_imgui_capture_item_t e888;
            public sg_imgui_capture_item_t e889;
            public sg_imgui_capture_item_t e890;
            public sg_imgui_capture_item_t e891;
            public sg_imgui_capture_item_t e892;
            public sg_imgui_capture_item_t e893;
            public sg_imgui_capture_item_t e894;
            public sg_imgui_capture_item_t e895;
            public sg_imgui_capture_item_t e896;
            public sg_imgui_capture_item_t e897;
            public sg_imgui_capture_item_t e898;
            public sg_imgui_capture_item_t e899;
            public sg_imgui_capture_item_t e900;
            public sg_imgui_capture_item_t e901;
            public sg_imgui_capture_item_t e902;
            public sg_imgui_capture_item_t e903;
            public sg_imgui_capture_item_t e904;
            public sg_imgui_capture_item_t e905;
            public sg_imgui_capture_item_t e906;
            public sg_imgui_capture_item_t e907;
            public sg_imgui_capture_item_t e908;
            public sg_imgui_capture_item_t e909;
            public sg_imgui_capture_item_t e910;
            public sg_imgui_capture_item_t e911;
            public sg_imgui_capture_item_t e912;
            public sg_imgui_capture_item_t e913;
            public sg_imgui_capture_item_t e914;
            public sg_imgui_capture_item_t e915;
            public sg_imgui_capture_item_t e916;
            public sg_imgui_capture_item_t e917;
            public sg_imgui_capture_item_t e918;
            public sg_imgui_capture_item_t e919;
            public sg_imgui_capture_item_t e920;
            public sg_imgui_capture_item_t e921;
            public sg_imgui_capture_item_t e922;
            public sg_imgui_capture_item_t e923;
            public sg_imgui_capture_item_t e924;
            public sg_imgui_capture_item_t e925;
            public sg_imgui_capture_item_t e926;
            public sg_imgui_capture_item_t e927;
            public sg_imgui_capture_item_t e928;
            public sg_imgui_capture_item_t e929;
            public sg_imgui_capture_item_t e930;
            public sg_imgui_capture_item_t e931;
            public sg_imgui_capture_item_t e932;
            public sg_imgui_capture_item_t e933;
            public sg_imgui_capture_item_t e934;
            public sg_imgui_capture_item_t e935;
            public sg_imgui_capture_item_t e936;
            public sg_imgui_capture_item_t e937;
            public sg_imgui_capture_item_t e938;
            public sg_imgui_capture_item_t e939;
            public sg_imgui_capture_item_t e940;
            public sg_imgui_capture_item_t e941;
            public sg_imgui_capture_item_t e942;
            public sg_imgui_capture_item_t e943;
            public sg_imgui_capture_item_t e944;
            public sg_imgui_capture_item_t e945;
            public sg_imgui_capture_item_t e946;
            public sg_imgui_capture_item_t e947;
            public sg_imgui_capture_item_t e948;
            public sg_imgui_capture_item_t e949;
            public sg_imgui_capture_item_t e950;
            public sg_imgui_capture_item_t e951;
            public sg_imgui_capture_item_t e952;
            public sg_imgui_capture_item_t e953;
            public sg_imgui_capture_item_t e954;
            public sg_imgui_capture_item_t e955;
            public sg_imgui_capture_item_t e956;
            public sg_imgui_capture_item_t e957;
            public sg_imgui_capture_item_t e958;
            public sg_imgui_capture_item_t e959;
            public sg_imgui_capture_item_t e960;
            public sg_imgui_capture_item_t e961;
            public sg_imgui_capture_item_t e962;
            public sg_imgui_capture_item_t e963;
            public sg_imgui_capture_item_t e964;
            public sg_imgui_capture_item_t e965;
            public sg_imgui_capture_item_t e966;
            public sg_imgui_capture_item_t e967;
            public sg_imgui_capture_item_t e968;
            public sg_imgui_capture_item_t e969;
            public sg_imgui_capture_item_t e970;
            public sg_imgui_capture_item_t e971;
            public sg_imgui_capture_item_t e972;
            public sg_imgui_capture_item_t e973;
            public sg_imgui_capture_item_t e974;
            public sg_imgui_capture_item_t e975;
            public sg_imgui_capture_item_t e976;
            public sg_imgui_capture_item_t e977;
            public sg_imgui_capture_item_t e978;
            public sg_imgui_capture_item_t e979;
            public sg_imgui_capture_item_t e980;
            public sg_imgui_capture_item_t e981;
            public sg_imgui_capture_item_t e982;
            public sg_imgui_capture_item_t e983;
            public sg_imgui_capture_item_t e984;
            public sg_imgui_capture_item_t e985;
            public sg_imgui_capture_item_t e986;
            public sg_imgui_capture_item_t e987;
            public sg_imgui_capture_item_t e988;
            public sg_imgui_capture_item_t e989;
            public sg_imgui_capture_item_t e990;
            public sg_imgui_capture_item_t e991;
            public sg_imgui_capture_item_t e992;
            public sg_imgui_capture_item_t e993;
            public sg_imgui_capture_item_t e994;
            public sg_imgui_capture_item_t e995;
            public sg_imgui_capture_item_t e996;
            public sg_imgui_capture_item_t e997;
            public sg_imgui_capture_item_t e998;
            public sg_imgui_capture_item_t e999;
            public sg_imgui_capture_item_t e1000;
            public sg_imgui_capture_item_t e1001;
            public sg_imgui_capture_item_t e1002;
            public sg_imgui_capture_item_t e1003;
            public sg_imgui_capture_item_t e1004;
            public sg_imgui_capture_item_t e1005;
            public sg_imgui_capture_item_t e1006;
            public sg_imgui_capture_item_t e1007;
            public sg_imgui_capture_item_t e1008;
            public sg_imgui_capture_item_t e1009;
            public sg_imgui_capture_item_t e1010;
            public sg_imgui_capture_item_t e1011;
            public sg_imgui_capture_item_t e1012;
            public sg_imgui_capture_item_t e1013;
            public sg_imgui_capture_item_t e1014;
            public sg_imgui_capture_item_t e1015;
            public sg_imgui_capture_item_t e1016;
            public sg_imgui_capture_item_t e1017;
            public sg_imgui_capture_item_t e1018;
            public sg_imgui_capture_item_t e1019;
            public sg_imgui_capture_item_t e1020;
            public sg_imgui_capture_item_t e1021;
            public sg_imgui_capture_item_t e1022;
            public sg_imgui_capture_item_t e1023;
            public sg_imgui_capture_item_t e1024;
            public sg_imgui_capture_item_t e1025;
            public sg_imgui_capture_item_t e1026;
            public sg_imgui_capture_item_t e1027;
            public sg_imgui_capture_item_t e1028;
            public sg_imgui_capture_item_t e1029;
            public sg_imgui_capture_item_t e1030;
            public sg_imgui_capture_item_t e1031;
            public sg_imgui_capture_item_t e1032;
            public sg_imgui_capture_item_t e1033;
            public sg_imgui_capture_item_t e1034;
            public sg_imgui_capture_item_t e1035;
            public sg_imgui_capture_item_t e1036;
            public sg_imgui_capture_item_t e1037;
            public sg_imgui_capture_item_t e1038;
            public sg_imgui_capture_item_t e1039;
            public sg_imgui_capture_item_t e1040;
            public sg_imgui_capture_item_t e1041;
            public sg_imgui_capture_item_t e1042;
            public sg_imgui_capture_item_t e1043;
            public sg_imgui_capture_item_t e1044;
            public sg_imgui_capture_item_t e1045;
            public sg_imgui_capture_item_t e1046;
            public sg_imgui_capture_item_t e1047;
            public sg_imgui_capture_item_t e1048;
            public sg_imgui_capture_item_t e1049;
            public sg_imgui_capture_item_t e1050;
            public sg_imgui_capture_item_t e1051;
            public sg_imgui_capture_item_t e1052;
            public sg_imgui_capture_item_t e1053;
            public sg_imgui_capture_item_t e1054;
            public sg_imgui_capture_item_t e1055;
            public sg_imgui_capture_item_t e1056;
            public sg_imgui_capture_item_t e1057;
            public sg_imgui_capture_item_t e1058;
            public sg_imgui_capture_item_t e1059;
            public sg_imgui_capture_item_t e1060;
            public sg_imgui_capture_item_t e1061;
            public sg_imgui_capture_item_t e1062;
            public sg_imgui_capture_item_t e1063;
            public sg_imgui_capture_item_t e1064;
            public sg_imgui_capture_item_t e1065;
            public sg_imgui_capture_item_t e1066;
            public sg_imgui_capture_item_t e1067;
            public sg_imgui_capture_item_t e1068;
            public sg_imgui_capture_item_t e1069;
            public sg_imgui_capture_item_t e1070;
            public sg_imgui_capture_item_t e1071;
            public sg_imgui_capture_item_t e1072;
            public sg_imgui_capture_item_t e1073;
            public sg_imgui_capture_item_t e1074;
            public sg_imgui_capture_item_t e1075;
            public sg_imgui_capture_item_t e1076;
            public sg_imgui_capture_item_t e1077;
            public sg_imgui_capture_item_t e1078;
            public sg_imgui_capture_item_t e1079;
            public sg_imgui_capture_item_t e1080;
            public sg_imgui_capture_item_t e1081;
            public sg_imgui_capture_item_t e1082;
            public sg_imgui_capture_item_t e1083;
            public sg_imgui_capture_item_t e1084;
            public sg_imgui_capture_item_t e1085;
            public sg_imgui_capture_item_t e1086;
            public sg_imgui_capture_item_t e1087;
            public sg_imgui_capture_item_t e1088;
            public sg_imgui_capture_item_t e1089;
            public sg_imgui_capture_item_t e1090;
            public sg_imgui_capture_item_t e1091;
            public sg_imgui_capture_item_t e1092;
            public sg_imgui_capture_item_t e1093;
            public sg_imgui_capture_item_t e1094;
            public sg_imgui_capture_item_t e1095;
            public sg_imgui_capture_item_t e1096;
            public sg_imgui_capture_item_t e1097;
            public sg_imgui_capture_item_t e1098;
            public sg_imgui_capture_item_t e1099;
            public sg_imgui_capture_item_t e1100;
            public sg_imgui_capture_item_t e1101;
            public sg_imgui_capture_item_t e1102;
            public sg_imgui_capture_item_t e1103;
            public sg_imgui_capture_item_t e1104;
            public sg_imgui_capture_item_t e1105;
            public sg_imgui_capture_item_t e1106;
            public sg_imgui_capture_item_t e1107;
            public sg_imgui_capture_item_t e1108;
            public sg_imgui_capture_item_t e1109;
            public sg_imgui_capture_item_t e1110;
            public sg_imgui_capture_item_t e1111;
            public sg_imgui_capture_item_t e1112;
            public sg_imgui_capture_item_t e1113;
            public sg_imgui_capture_item_t e1114;
            public sg_imgui_capture_item_t e1115;
            public sg_imgui_capture_item_t e1116;
            public sg_imgui_capture_item_t e1117;
            public sg_imgui_capture_item_t e1118;
            public sg_imgui_capture_item_t e1119;
            public sg_imgui_capture_item_t e1120;
            public sg_imgui_capture_item_t e1121;
            public sg_imgui_capture_item_t e1122;
            public sg_imgui_capture_item_t e1123;
            public sg_imgui_capture_item_t e1124;
            public sg_imgui_capture_item_t e1125;
            public sg_imgui_capture_item_t e1126;
            public sg_imgui_capture_item_t e1127;
            public sg_imgui_capture_item_t e1128;
            public sg_imgui_capture_item_t e1129;
            public sg_imgui_capture_item_t e1130;
            public sg_imgui_capture_item_t e1131;
            public sg_imgui_capture_item_t e1132;
            public sg_imgui_capture_item_t e1133;
            public sg_imgui_capture_item_t e1134;
            public sg_imgui_capture_item_t e1135;
            public sg_imgui_capture_item_t e1136;
            public sg_imgui_capture_item_t e1137;
            public sg_imgui_capture_item_t e1138;
            public sg_imgui_capture_item_t e1139;
            public sg_imgui_capture_item_t e1140;
            public sg_imgui_capture_item_t e1141;
            public sg_imgui_capture_item_t e1142;
            public sg_imgui_capture_item_t e1143;
            public sg_imgui_capture_item_t e1144;
            public sg_imgui_capture_item_t e1145;
            public sg_imgui_capture_item_t e1146;
            public sg_imgui_capture_item_t e1147;
            public sg_imgui_capture_item_t e1148;
            public sg_imgui_capture_item_t e1149;
            public sg_imgui_capture_item_t e1150;
            public sg_imgui_capture_item_t e1151;
            public sg_imgui_capture_item_t e1152;
            public sg_imgui_capture_item_t e1153;
            public sg_imgui_capture_item_t e1154;
            public sg_imgui_capture_item_t e1155;
            public sg_imgui_capture_item_t e1156;
            public sg_imgui_capture_item_t e1157;
            public sg_imgui_capture_item_t e1158;
            public sg_imgui_capture_item_t e1159;
            public sg_imgui_capture_item_t e1160;
            public sg_imgui_capture_item_t e1161;
            public sg_imgui_capture_item_t e1162;
            public sg_imgui_capture_item_t e1163;
            public sg_imgui_capture_item_t e1164;
            public sg_imgui_capture_item_t e1165;
            public sg_imgui_capture_item_t e1166;
            public sg_imgui_capture_item_t e1167;
            public sg_imgui_capture_item_t e1168;
            public sg_imgui_capture_item_t e1169;
            public sg_imgui_capture_item_t e1170;
            public sg_imgui_capture_item_t e1171;
            public sg_imgui_capture_item_t e1172;
            public sg_imgui_capture_item_t e1173;
            public sg_imgui_capture_item_t e1174;
            public sg_imgui_capture_item_t e1175;
            public sg_imgui_capture_item_t e1176;
            public sg_imgui_capture_item_t e1177;
            public sg_imgui_capture_item_t e1178;
            public sg_imgui_capture_item_t e1179;
            public sg_imgui_capture_item_t e1180;
            public sg_imgui_capture_item_t e1181;
            public sg_imgui_capture_item_t e1182;
            public sg_imgui_capture_item_t e1183;
            public sg_imgui_capture_item_t e1184;
            public sg_imgui_capture_item_t e1185;
            public sg_imgui_capture_item_t e1186;
            public sg_imgui_capture_item_t e1187;
            public sg_imgui_capture_item_t e1188;
            public sg_imgui_capture_item_t e1189;
            public sg_imgui_capture_item_t e1190;
            public sg_imgui_capture_item_t e1191;
            public sg_imgui_capture_item_t e1192;
            public sg_imgui_capture_item_t e1193;
            public sg_imgui_capture_item_t e1194;
            public sg_imgui_capture_item_t e1195;
            public sg_imgui_capture_item_t e1196;
            public sg_imgui_capture_item_t e1197;
            public sg_imgui_capture_item_t e1198;
            public sg_imgui_capture_item_t e1199;
            public sg_imgui_capture_item_t e1200;
            public sg_imgui_capture_item_t e1201;
            public sg_imgui_capture_item_t e1202;
            public sg_imgui_capture_item_t e1203;
            public sg_imgui_capture_item_t e1204;
            public sg_imgui_capture_item_t e1205;
            public sg_imgui_capture_item_t e1206;
            public sg_imgui_capture_item_t e1207;
            public sg_imgui_capture_item_t e1208;
            public sg_imgui_capture_item_t e1209;
            public sg_imgui_capture_item_t e1210;
            public sg_imgui_capture_item_t e1211;
            public sg_imgui_capture_item_t e1212;
            public sg_imgui_capture_item_t e1213;
            public sg_imgui_capture_item_t e1214;
            public sg_imgui_capture_item_t e1215;
            public sg_imgui_capture_item_t e1216;
            public sg_imgui_capture_item_t e1217;
            public sg_imgui_capture_item_t e1218;
            public sg_imgui_capture_item_t e1219;
            public sg_imgui_capture_item_t e1220;
            public sg_imgui_capture_item_t e1221;
            public sg_imgui_capture_item_t e1222;
            public sg_imgui_capture_item_t e1223;
            public sg_imgui_capture_item_t e1224;
            public sg_imgui_capture_item_t e1225;
            public sg_imgui_capture_item_t e1226;
            public sg_imgui_capture_item_t e1227;
            public sg_imgui_capture_item_t e1228;
            public sg_imgui_capture_item_t e1229;
            public sg_imgui_capture_item_t e1230;
            public sg_imgui_capture_item_t e1231;
            public sg_imgui_capture_item_t e1232;
            public sg_imgui_capture_item_t e1233;
            public sg_imgui_capture_item_t e1234;
            public sg_imgui_capture_item_t e1235;
            public sg_imgui_capture_item_t e1236;
            public sg_imgui_capture_item_t e1237;
            public sg_imgui_capture_item_t e1238;
            public sg_imgui_capture_item_t e1239;
            public sg_imgui_capture_item_t e1240;
            public sg_imgui_capture_item_t e1241;
            public sg_imgui_capture_item_t e1242;
            public sg_imgui_capture_item_t e1243;
            public sg_imgui_capture_item_t e1244;
            public sg_imgui_capture_item_t e1245;
            public sg_imgui_capture_item_t e1246;
            public sg_imgui_capture_item_t e1247;
            public sg_imgui_capture_item_t e1248;
            public sg_imgui_capture_item_t e1249;
            public sg_imgui_capture_item_t e1250;
            public sg_imgui_capture_item_t e1251;
            public sg_imgui_capture_item_t e1252;
            public sg_imgui_capture_item_t e1253;
            public sg_imgui_capture_item_t e1254;
            public sg_imgui_capture_item_t e1255;
            public sg_imgui_capture_item_t e1256;
            public sg_imgui_capture_item_t e1257;
            public sg_imgui_capture_item_t e1258;
            public sg_imgui_capture_item_t e1259;
            public sg_imgui_capture_item_t e1260;
            public sg_imgui_capture_item_t e1261;
            public sg_imgui_capture_item_t e1262;
            public sg_imgui_capture_item_t e1263;
            public sg_imgui_capture_item_t e1264;
            public sg_imgui_capture_item_t e1265;
            public sg_imgui_capture_item_t e1266;
            public sg_imgui_capture_item_t e1267;
            public sg_imgui_capture_item_t e1268;
            public sg_imgui_capture_item_t e1269;
            public sg_imgui_capture_item_t e1270;
            public sg_imgui_capture_item_t e1271;
            public sg_imgui_capture_item_t e1272;
            public sg_imgui_capture_item_t e1273;
            public sg_imgui_capture_item_t e1274;
            public sg_imgui_capture_item_t e1275;
            public sg_imgui_capture_item_t e1276;
            public sg_imgui_capture_item_t e1277;
            public sg_imgui_capture_item_t e1278;
            public sg_imgui_capture_item_t e1279;
            public sg_imgui_capture_item_t e1280;
            public sg_imgui_capture_item_t e1281;
            public sg_imgui_capture_item_t e1282;
            public sg_imgui_capture_item_t e1283;
            public sg_imgui_capture_item_t e1284;
            public sg_imgui_capture_item_t e1285;
            public sg_imgui_capture_item_t e1286;
            public sg_imgui_capture_item_t e1287;
            public sg_imgui_capture_item_t e1288;
            public sg_imgui_capture_item_t e1289;
            public sg_imgui_capture_item_t e1290;
            public sg_imgui_capture_item_t e1291;
            public sg_imgui_capture_item_t e1292;
            public sg_imgui_capture_item_t e1293;
            public sg_imgui_capture_item_t e1294;
            public sg_imgui_capture_item_t e1295;
            public sg_imgui_capture_item_t e1296;
            public sg_imgui_capture_item_t e1297;
            public sg_imgui_capture_item_t e1298;
            public sg_imgui_capture_item_t e1299;
            public sg_imgui_capture_item_t e1300;
            public sg_imgui_capture_item_t e1301;
            public sg_imgui_capture_item_t e1302;
            public sg_imgui_capture_item_t e1303;
            public sg_imgui_capture_item_t e1304;
            public sg_imgui_capture_item_t e1305;
            public sg_imgui_capture_item_t e1306;
            public sg_imgui_capture_item_t e1307;
            public sg_imgui_capture_item_t e1308;
            public sg_imgui_capture_item_t e1309;
            public sg_imgui_capture_item_t e1310;
            public sg_imgui_capture_item_t e1311;
            public sg_imgui_capture_item_t e1312;
            public sg_imgui_capture_item_t e1313;
            public sg_imgui_capture_item_t e1314;
            public sg_imgui_capture_item_t e1315;
            public sg_imgui_capture_item_t e1316;
            public sg_imgui_capture_item_t e1317;
            public sg_imgui_capture_item_t e1318;
            public sg_imgui_capture_item_t e1319;
            public sg_imgui_capture_item_t e1320;
            public sg_imgui_capture_item_t e1321;
            public sg_imgui_capture_item_t e1322;
            public sg_imgui_capture_item_t e1323;
            public sg_imgui_capture_item_t e1324;
            public sg_imgui_capture_item_t e1325;
            public sg_imgui_capture_item_t e1326;
            public sg_imgui_capture_item_t e1327;
            public sg_imgui_capture_item_t e1328;
            public sg_imgui_capture_item_t e1329;
            public sg_imgui_capture_item_t e1330;
            public sg_imgui_capture_item_t e1331;
            public sg_imgui_capture_item_t e1332;
            public sg_imgui_capture_item_t e1333;
            public sg_imgui_capture_item_t e1334;
            public sg_imgui_capture_item_t e1335;
            public sg_imgui_capture_item_t e1336;
            public sg_imgui_capture_item_t e1337;
            public sg_imgui_capture_item_t e1338;
            public sg_imgui_capture_item_t e1339;
            public sg_imgui_capture_item_t e1340;
            public sg_imgui_capture_item_t e1341;
            public sg_imgui_capture_item_t e1342;
            public sg_imgui_capture_item_t e1343;
            public sg_imgui_capture_item_t e1344;
            public sg_imgui_capture_item_t e1345;
            public sg_imgui_capture_item_t e1346;
            public sg_imgui_capture_item_t e1347;
            public sg_imgui_capture_item_t e1348;
            public sg_imgui_capture_item_t e1349;
            public sg_imgui_capture_item_t e1350;
            public sg_imgui_capture_item_t e1351;
            public sg_imgui_capture_item_t e1352;
            public sg_imgui_capture_item_t e1353;
            public sg_imgui_capture_item_t e1354;
            public sg_imgui_capture_item_t e1355;
            public sg_imgui_capture_item_t e1356;
            public sg_imgui_capture_item_t e1357;
            public sg_imgui_capture_item_t e1358;
            public sg_imgui_capture_item_t e1359;
            public sg_imgui_capture_item_t e1360;
            public sg_imgui_capture_item_t e1361;
            public sg_imgui_capture_item_t e1362;
            public sg_imgui_capture_item_t e1363;
            public sg_imgui_capture_item_t e1364;
            public sg_imgui_capture_item_t e1365;
            public sg_imgui_capture_item_t e1366;
            public sg_imgui_capture_item_t e1367;
            public sg_imgui_capture_item_t e1368;
            public sg_imgui_capture_item_t e1369;
            public sg_imgui_capture_item_t e1370;
            public sg_imgui_capture_item_t e1371;
            public sg_imgui_capture_item_t e1372;
            public sg_imgui_capture_item_t e1373;
            public sg_imgui_capture_item_t e1374;
            public sg_imgui_capture_item_t e1375;
            public sg_imgui_capture_item_t e1376;
            public sg_imgui_capture_item_t e1377;
            public sg_imgui_capture_item_t e1378;
            public sg_imgui_capture_item_t e1379;
            public sg_imgui_capture_item_t e1380;
            public sg_imgui_capture_item_t e1381;
            public sg_imgui_capture_item_t e1382;
            public sg_imgui_capture_item_t e1383;
            public sg_imgui_capture_item_t e1384;
            public sg_imgui_capture_item_t e1385;
            public sg_imgui_capture_item_t e1386;
            public sg_imgui_capture_item_t e1387;
            public sg_imgui_capture_item_t e1388;
            public sg_imgui_capture_item_t e1389;
            public sg_imgui_capture_item_t e1390;
            public sg_imgui_capture_item_t e1391;
            public sg_imgui_capture_item_t e1392;
            public sg_imgui_capture_item_t e1393;
            public sg_imgui_capture_item_t e1394;
            public sg_imgui_capture_item_t e1395;
            public sg_imgui_capture_item_t e1396;
            public sg_imgui_capture_item_t e1397;
            public sg_imgui_capture_item_t e1398;
            public sg_imgui_capture_item_t e1399;
            public sg_imgui_capture_item_t e1400;
            public sg_imgui_capture_item_t e1401;
            public sg_imgui_capture_item_t e1402;
            public sg_imgui_capture_item_t e1403;
            public sg_imgui_capture_item_t e1404;
            public sg_imgui_capture_item_t e1405;
            public sg_imgui_capture_item_t e1406;
            public sg_imgui_capture_item_t e1407;
            public sg_imgui_capture_item_t e1408;
            public sg_imgui_capture_item_t e1409;
            public sg_imgui_capture_item_t e1410;
            public sg_imgui_capture_item_t e1411;
            public sg_imgui_capture_item_t e1412;
            public sg_imgui_capture_item_t e1413;
            public sg_imgui_capture_item_t e1414;
            public sg_imgui_capture_item_t e1415;
            public sg_imgui_capture_item_t e1416;
            public sg_imgui_capture_item_t e1417;
            public sg_imgui_capture_item_t e1418;
            public sg_imgui_capture_item_t e1419;
            public sg_imgui_capture_item_t e1420;
            public sg_imgui_capture_item_t e1421;
            public sg_imgui_capture_item_t e1422;
            public sg_imgui_capture_item_t e1423;
            public sg_imgui_capture_item_t e1424;
            public sg_imgui_capture_item_t e1425;
            public sg_imgui_capture_item_t e1426;
            public sg_imgui_capture_item_t e1427;
            public sg_imgui_capture_item_t e1428;
            public sg_imgui_capture_item_t e1429;
            public sg_imgui_capture_item_t e1430;
            public sg_imgui_capture_item_t e1431;
            public sg_imgui_capture_item_t e1432;
            public sg_imgui_capture_item_t e1433;
            public sg_imgui_capture_item_t e1434;
            public sg_imgui_capture_item_t e1435;
            public sg_imgui_capture_item_t e1436;
            public sg_imgui_capture_item_t e1437;
            public sg_imgui_capture_item_t e1438;
            public sg_imgui_capture_item_t e1439;
            public sg_imgui_capture_item_t e1440;
            public sg_imgui_capture_item_t e1441;
            public sg_imgui_capture_item_t e1442;
            public sg_imgui_capture_item_t e1443;
            public sg_imgui_capture_item_t e1444;
            public sg_imgui_capture_item_t e1445;
            public sg_imgui_capture_item_t e1446;
            public sg_imgui_capture_item_t e1447;
            public sg_imgui_capture_item_t e1448;
            public sg_imgui_capture_item_t e1449;
            public sg_imgui_capture_item_t e1450;
            public sg_imgui_capture_item_t e1451;
            public sg_imgui_capture_item_t e1452;
            public sg_imgui_capture_item_t e1453;
            public sg_imgui_capture_item_t e1454;
            public sg_imgui_capture_item_t e1455;
            public sg_imgui_capture_item_t e1456;
            public sg_imgui_capture_item_t e1457;
            public sg_imgui_capture_item_t e1458;
            public sg_imgui_capture_item_t e1459;
            public sg_imgui_capture_item_t e1460;
            public sg_imgui_capture_item_t e1461;
            public sg_imgui_capture_item_t e1462;
            public sg_imgui_capture_item_t e1463;
            public sg_imgui_capture_item_t e1464;
            public sg_imgui_capture_item_t e1465;
            public sg_imgui_capture_item_t e1466;
            public sg_imgui_capture_item_t e1467;
            public sg_imgui_capture_item_t e1468;
            public sg_imgui_capture_item_t e1469;
            public sg_imgui_capture_item_t e1470;
            public sg_imgui_capture_item_t e1471;
            public sg_imgui_capture_item_t e1472;
            public sg_imgui_capture_item_t e1473;
            public sg_imgui_capture_item_t e1474;
            public sg_imgui_capture_item_t e1475;
            public sg_imgui_capture_item_t e1476;
            public sg_imgui_capture_item_t e1477;
            public sg_imgui_capture_item_t e1478;
            public sg_imgui_capture_item_t e1479;
            public sg_imgui_capture_item_t e1480;
            public sg_imgui_capture_item_t e1481;
            public sg_imgui_capture_item_t e1482;
            public sg_imgui_capture_item_t e1483;
            public sg_imgui_capture_item_t e1484;
            public sg_imgui_capture_item_t e1485;
            public sg_imgui_capture_item_t e1486;
            public sg_imgui_capture_item_t e1487;
            public sg_imgui_capture_item_t e1488;
            public sg_imgui_capture_item_t e1489;
            public sg_imgui_capture_item_t e1490;
            public sg_imgui_capture_item_t e1491;
            public sg_imgui_capture_item_t e1492;
            public sg_imgui_capture_item_t e1493;
            public sg_imgui_capture_item_t e1494;
            public sg_imgui_capture_item_t e1495;
            public sg_imgui_capture_item_t e1496;
            public sg_imgui_capture_item_t e1497;
            public sg_imgui_capture_item_t e1498;
            public sg_imgui_capture_item_t e1499;
            public sg_imgui_capture_item_t e1500;
            public sg_imgui_capture_item_t e1501;
            public sg_imgui_capture_item_t e1502;
            public sg_imgui_capture_item_t e1503;
            public sg_imgui_capture_item_t e1504;
            public sg_imgui_capture_item_t e1505;
            public sg_imgui_capture_item_t e1506;
            public sg_imgui_capture_item_t e1507;
            public sg_imgui_capture_item_t e1508;
            public sg_imgui_capture_item_t e1509;
            public sg_imgui_capture_item_t e1510;
            public sg_imgui_capture_item_t e1511;
            public sg_imgui_capture_item_t e1512;
            public sg_imgui_capture_item_t e1513;
            public sg_imgui_capture_item_t e1514;
            public sg_imgui_capture_item_t e1515;
            public sg_imgui_capture_item_t e1516;
            public sg_imgui_capture_item_t e1517;
            public sg_imgui_capture_item_t e1518;
            public sg_imgui_capture_item_t e1519;
            public sg_imgui_capture_item_t e1520;
            public sg_imgui_capture_item_t e1521;
            public sg_imgui_capture_item_t e1522;
            public sg_imgui_capture_item_t e1523;
            public sg_imgui_capture_item_t e1524;
            public sg_imgui_capture_item_t e1525;
            public sg_imgui_capture_item_t e1526;
            public sg_imgui_capture_item_t e1527;
            public sg_imgui_capture_item_t e1528;
            public sg_imgui_capture_item_t e1529;
            public sg_imgui_capture_item_t e1530;
            public sg_imgui_capture_item_t e1531;
            public sg_imgui_capture_item_t e1532;
            public sg_imgui_capture_item_t e1533;
            public sg_imgui_capture_item_t e1534;
            public sg_imgui_capture_item_t e1535;
            public sg_imgui_capture_item_t e1536;
            public sg_imgui_capture_item_t e1537;
            public sg_imgui_capture_item_t e1538;
            public sg_imgui_capture_item_t e1539;
            public sg_imgui_capture_item_t e1540;
            public sg_imgui_capture_item_t e1541;
            public sg_imgui_capture_item_t e1542;
            public sg_imgui_capture_item_t e1543;
            public sg_imgui_capture_item_t e1544;
            public sg_imgui_capture_item_t e1545;
            public sg_imgui_capture_item_t e1546;
            public sg_imgui_capture_item_t e1547;
            public sg_imgui_capture_item_t e1548;
            public sg_imgui_capture_item_t e1549;
            public sg_imgui_capture_item_t e1550;
            public sg_imgui_capture_item_t e1551;
            public sg_imgui_capture_item_t e1552;
            public sg_imgui_capture_item_t e1553;
            public sg_imgui_capture_item_t e1554;
            public sg_imgui_capture_item_t e1555;
            public sg_imgui_capture_item_t e1556;
            public sg_imgui_capture_item_t e1557;
            public sg_imgui_capture_item_t e1558;
            public sg_imgui_capture_item_t e1559;
            public sg_imgui_capture_item_t e1560;
            public sg_imgui_capture_item_t e1561;
            public sg_imgui_capture_item_t e1562;
            public sg_imgui_capture_item_t e1563;
            public sg_imgui_capture_item_t e1564;
            public sg_imgui_capture_item_t e1565;
            public sg_imgui_capture_item_t e1566;
            public sg_imgui_capture_item_t e1567;
            public sg_imgui_capture_item_t e1568;
            public sg_imgui_capture_item_t e1569;
            public sg_imgui_capture_item_t e1570;
            public sg_imgui_capture_item_t e1571;
            public sg_imgui_capture_item_t e1572;
            public sg_imgui_capture_item_t e1573;
            public sg_imgui_capture_item_t e1574;
            public sg_imgui_capture_item_t e1575;
            public sg_imgui_capture_item_t e1576;
            public sg_imgui_capture_item_t e1577;
            public sg_imgui_capture_item_t e1578;
            public sg_imgui_capture_item_t e1579;
            public sg_imgui_capture_item_t e1580;
            public sg_imgui_capture_item_t e1581;
            public sg_imgui_capture_item_t e1582;
            public sg_imgui_capture_item_t e1583;
            public sg_imgui_capture_item_t e1584;
            public sg_imgui_capture_item_t e1585;
            public sg_imgui_capture_item_t e1586;
            public sg_imgui_capture_item_t e1587;
            public sg_imgui_capture_item_t e1588;
            public sg_imgui_capture_item_t e1589;
            public sg_imgui_capture_item_t e1590;
            public sg_imgui_capture_item_t e1591;
            public sg_imgui_capture_item_t e1592;
            public sg_imgui_capture_item_t e1593;
            public sg_imgui_capture_item_t e1594;
            public sg_imgui_capture_item_t e1595;
            public sg_imgui_capture_item_t e1596;
            public sg_imgui_capture_item_t e1597;
            public sg_imgui_capture_item_t e1598;
            public sg_imgui_capture_item_t e1599;
            public sg_imgui_capture_item_t e1600;
            public sg_imgui_capture_item_t e1601;
            public sg_imgui_capture_item_t e1602;
            public sg_imgui_capture_item_t e1603;
            public sg_imgui_capture_item_t e1604;
            public sg_imgui_capture_item_t e1605;
            public sg_imgui_capture_item_t e1606;
            public sg_imgui_capture_item_t e1607;
            public sg_imgui_capture_item_t e1608;
            public sg_imgui_capture_item_t e1609;
            public sg_imgui_capture_item_t e1610;
            public sg_imgui_capture_item_t e1611;
            public sg_imgui_capture_item_t e1612;
            public sg_imgui_capture_item_t e1613;
            public sg_imgui_capture_item_t e1614;
            public sg_imgui_capture_item_t e1615;
            public sg_imgui_capture_item_t e1616;
            public sg_imgui_capture_item_t e1617;
            public sg_imgui_capture_item_t e1618;
            public sg_imgui_capture_item_t e1619;
            public sg_imgui_capture_item_t e1620;
            public sg_imgui_capture_item_t e1621;
            public sg_imgui_capture_item_t e1622;
            public sg_imgui_capture_item_t e1623;
            public sg_imgui_capture_item_t e1624;
            public sg_imgui_capture_item_t e1625;
            public sg_imgui_capture_item_t e1626;
            public sg_imgui_capture_item_t e1627;
            public sg_imgui_capture_item_t e1628;
            public sg_imgui_capture_item_t e1629;
            public sg_imgui_capture_item_t e1630;
            public sg_imgui_capture_item_t e1631;
            public sg_imgui_capture_item_t e1632;
            public sg_imgui_capture_item_t e1633;
            public sg_imgui_capture_item_t e1634;
            public sg_imgui_capture_item_t e1635;
            public sg_imgui_capture_item_t e1636;
            public sg_imgui_capture_item_t e1637;
            public sg_imgui_capture_item_t e1638;
            public sg_imgui_capture_item_t e1639;
            public sg_imgui_capture_item_t e1640;
            public sg_imgui_capture_item_t e1641;
            public sg_imgui_capture_item_t e1642;
            public sg_imgui_capture_item_t e1643;
            public sg_imgui_capture_item_t e1644;
            public sg_imgui_capture_item_t e1645;
            public sg_imgui_capture_item_t e1646;
            public sg_imgui_capture_item_t e1647;
            public sg_imgui_capture_item_t e1648;
            public sg_imgui_capture_item_t e1649;
            public sg_imgui_capture_item_t e1650;
            public sg_imgui_capture_item_t e1651;
            public sg_imgui_capture_item_t e1652;
            public sg_imgui_capture_item_t e1653;
            public sg_imgui_capture_item_t e1654;
            public sg_imgui_capture_item_t e1655;
            public sg_imgui_capture_item_t e1656;
            public sg_imgui_capture_item_t e1657;
            public sg_imgui_capture_item_t e1658;
            public sg_imgui_capture_item_t e1659;
            public sg_imgui_capture_item_t e1660;
            public sg_imgui_capture_item_t e1661;
            public sg_imgui_capture_item_t e1662;
            public sg_imgui_capture_item_t e1663;
            public sg_imgui_capture_item_t e1664;
            public sg_imgui_capture_item_t e1665;
            public sg_imgui_capture_item_t e1666;
            public sg_imgui_capture_item_t e1667;
            public sg_imgui_capture_item_t e1668;
            public sg_imgui_capture_item_t e1669;
            public sg_imgui_capture_item_t e1670;
            public sg_imgui_capture_item_t e1671;
            public sg_imgui_capture_item_t e1672;
            public sg_imgui_capture_item_t e1673;
            public sg_imgui_capture_item_t e1674;
            public sg_imgui_capture_item_t e1675;
            public sg_imgui_capture_item_t e1676;
            public sg_imgui_capture_item_t e1677;
            public sg_imgui_capture_item_t e1678;
            public sg_imgui_capture_item_t e1679;
            public sg_imgui_capture_item_t e1680;
            public sg_imgui_capture_item_t e1681;
            public sg_imgui_capture_item_t e1682;
            public sg_imgui_capture_item_t e1683;
            public sg_imgui_capture_item_t e1684;
            public sg_imgui_capture_item_t e1685;
            public sg_imgui_capture_item_t e1686;
            public sg_imgui_capture_item_t e1687;
            public sg_imgui_capture_item_t e1688;
            public sg_imgui_capture_item_t e1689;
            public sg_imgui_capture_item_t e1690;
            public sg_imgui_capture_item_t e1691;
            public sg_imgui_capture_item_t e1692;
            public sg_imgui_capture_item_t e1693;
            public sg_imgui_capture_item_t e1694;
            public sg_imgui_capture_item_t e1695;
            public sg_imgui_capture_item_t e1696;
            public sg_imgui_capture_item_t e1697;
            public sg_imgui_capture_item_t e1698;
            public sg_imgui_capture_item_t e1699;
            public sg_imgui_capture_item_t e1700;
            public sg_imgui_capture_item_t e1701;
            public sg_imgui_capture_item_t e1702;
            public sg_imgui_capture_item_t e1703;
            public sg_imgui_capture_item_t e1704;
            public sg_imgui_capture_item_t e1705;
            public sg_imgui_capture_item_t e1706;
            public sg_imgui_capture_item_t e1707;
            public sg_imgui_capture_item_t e1708;
            public sg_imgui_capture_item_t e1709;
            public sg_imgui_capture_item_t e1710;
            public sg_imgui_capture_item_t e1711;
            public sg_imgui_capture_item_t e1712;
            public sg_imgui_capture_item_t e1713;
            public sg_imgui_capture_item_t e1714;
            public sg_imgui_capture_item_t e1715;
            public sg_imgui_capture_item_t e1716;
            public sg_imgui_capture_item_t e1717;
            public sg_imgui_capture_item_t e1718;
            public sg_imgui_capture_item_t e1719;
            public sg_imgui_capture_item_t e1720;
            public sg_imgui_capture_item_t e1721;
            public sg_imgui_capture_item_t e1722;
            public sg_imgui_capture_item_t e1723;
            public sg_imgui_capture_item_t e1724;
            public sg_imgui_capture_item_t e1725;
            public sg_imgui_capture_item_t e1726;
            public sg_imgui_capture_item_t e1727;
            public sg_imgui_capture_item_t e1728;
            public sg_imgui_capture_item_t e1729;
            public sg_imgui_capture_item_t e1730;
            public sg_imgui_capture_item_t e1731;
            public sg_imgui_capture_item_t e1732;
            public sg_imgui_capture_item_t e1733;
            public sg_imgui_capture_item_t e1734;
            public sg_imgui_capture_item_t e1735;
            public sg_imgui_capture_item_t e1736;
            public sg_imgui_capture_item_t e1737;
            public sg_imgui_capture_item_t e1738;
            public sg_imgui_capture_item_t e1739;
            public sg_imgui_capture_item_t e1740;
            public sg_imgui_capture_item_t e1741;
            public sg_imgui_capture_item_t e1742;
            public sg_imgui_capture_item_t e1743;
            public sg_imgui_capture_item_t e1744;
            public sg_imgui_capture_item_t e1745;
            public sg_imgui_capture_item_t e1746;
            public sg_imgui_capture_item_t e1747;
            public sg_imgui_capture_item_t e1748;
            public sg_imgui_capture_item_t e1749;
            public sg_imgui_capture_item_t e1750;
            public sg_imgui_capture_item_t e1751;
            public sg_imgui_capture_item_t e1752;
            public sg_imgui_capture_item_t e1753;
            public sg_imgui_capture_item_t e1754;
            public sg_imgui_capture_item_t e1755;
            public sg_imgui_capture_item_t e1756;
            public sg_imgui_capture_item_t e1757;
            public sg_imgui_capture_item_t e1758;
            public sg_imgui_capture_item_t e1759;
            public sg_imgui_capture_item_t e1760;
            public sg_imgui_capture_item_t e1761;
            public sg_imgui_capture_item_t e1762;
            public sg_imgui_capture_item_t e1763;
            public sg_imgui_capture_item_t e1764;
            public sg_imgui_capture_item_t e1765;
            public sg_imgui_capture_item_t e1766;
            public sg_imgui_capture_item_t e1767;
            public sg_imgui_capture_item_t e1768;
            public sg_imgui_capture_item_t e1769;
            public sg_imgui_capture_item_t e1770;
            public sg_imgui_capture_item_t e1771;
            public sg_imgui_capture_item_t e1772;
            public sg_imgui_capture_item_t e1773;
            public sg_imgui_capture_item_t e1774;
            public sg_imgui_capture_item_t e1775;
            public sg_imgui_capture_item_t e1776;
            public sg_imgui_capture_item_t e1777;
            public sg_imgui_capture_item_t e1778;
            public sg_imgui_capture_item_t e1779;
            public sg_imgui_capture_item_t e1780;
            public sg_imgui_capture_item_t e1781;
            public sg_imgui_capture_item_t e1782;
            public sg_imgui_capture_item_t e1783;
            public sg_imgui_capture_item_t e1784;
            public sg_imgui_capture_item_t e1785;
            public sg_imgui_capture_item_t e1786;
            public sg_imgui_capture_item_t e1787;
            public sg_imgui_capture_item_t e1788;
            public sg_imgui_capture_item_t e1789;
            public sg_imgui_capture_item_t e1790;
            public sg_imgui_capture_item_t e1791;
            public sg_imgui_capture_item_t e1792;
            public sg_imgui_capture_item_t e1793;
            public sg_imgui_capture_item_t e1794;
            public sg_imgui_capture_item_t e1795;
            public sg_imgui_capture_item_t e1796;
            public sg_imgui_capture_item_t e1797;
            public sg_imgui_capture_item_t e1798;
            public sg_imgui_capture_item_t e1799;
            public sg_imgui_capture_item_t e1800;
            public sg_imgui_capture_item_t e1801;
            public sg_imgui_capture_item_t e1802;
            public sg_imgui_capture_item_t e1803;
            public sg_imgui_capture_item_t e1804;
            public sg_imgui_capture_item_t e1805;
            public sg_imgui_capture_item_t e1806;
            public sg_imgui_capture_item_t e1807;
            public sg_imgui_capture_item_t e1808;
            public sg_imgui_capture_item_t e1809;
            public sg_imgui_capture_item_t e1810;
            public sg_imgui_capture_item_t e1811;
            public sg_imgui_capture_item_t e1812;
            public sg_imgui_capture_item_t e1813;
            public sg_imgui_capture_item_t e1814;
            public sg_imgui_capture_item_t e1815;
            public sg_imgui_capture_item_t e1816;
            public sg_imgui_capture_item_t e1817;
            public sg_imgui_capture_item_t e1818;
            public sg_imgui_capture_item_t e1819;
            public sg_imgui_capture_item_t e1820;
            public sg_imgui_capture_item_t e1821;
            public sg_imgui_capture_item_t e1822;
            public sg_imgui_capture_item_t e1823;
            public sg_imgui_capture_item_t e1824;
            public sg_imgui_capture_item_t e1825;
            public sg_imgui_capture_item_t e1826;
            public sg_imgui_capture_item_t e1827;
            public sg_imgui_capture_item_t e1828;
            public sg_imgui_capture_item_t e1829;
            public sg_imgui_capture_item_t e1830;
            public sg_imgui_capture_item_t e1831;
            public sg_imgui_capture_item_t e1832;
            public sg_imgui_capture_item_t e1833;
            public sg_imgui_capture_item_t e1834;
            public sg_imgui_capture_item_t e1835;
            public sg_imgui_capture_item_t e1836;
            public sg_imgui_capture_item_t e1837;
            public sg_imgui_capture_item_t e1838;
            public sg_imgui_capture_item_t e1839;
            public sg_imgui_capture_item_t e1840;
            public sg_imgui_capture_item_t e1841;
            public sg_imgui_capture_item_t e1842;
            public sg_imgui_capture_item_t e1843;
            public sg_imgui_capture_item_t e1844;
            public sg_imgui_capture_item_t e1845;
            public sg_imgui_capture_item_t e1846;
            public sg_imgui_capture_item_t e1847;
            public sg_imgui_capture_item_t e1848;
            public sg_imgui_capture_item_t e1849;
            public sg_imgui_capture_item_t e1850;
            public sg_imgui_capture_item_t e1851;
            public sg_imgui_capture_item_t e1852;
            public sg_imgui_capture_item_t e1853;
            public sg_imgui_capture_item_t e1854;
            public sg_imgui_capture_item_t e1855;
            public sg_imgui_capture_item_t e1856;
            public sg_imgui_capture_item_t e1857;
            public sg_imgui_capture_item_t e1858;
            public sg_imgui_capture_item_t e1859;
            public sg_imgui_capture_item_t e1860;
            public sg_imgui_capture_item_t e1861;
            public sg_imgui_capture_item_t e1862;
            public sg_imgui_capture_item_t e1863;
            public sg_imgui_capture_item_t e1864;
            public sg_imgui_capture_item_t e1865;
            public sg_imgui_capture_item_t e1866;
            public sg_imgui_capture_item_t e1867;
            public sg_imgui_capture_item_t e1868;
            public sg_imgui_capture_item_t e1869;
            public sg_imgui_capture_item_t e1870;
            public sg_imgui_capture_item_t e1871;
            public sg_imgui_capture_item_t e1872;
            public sg_imgui_capture_item_t e1873;
            public sg_imgui_capture_item_t e1874;
            public sg_imgui_capture_item_t e1875;
            public sg_imgui_capture_item_t e1876;
            public sg_imgui_capture_item_t e1877;
            public sg_imgui_capture_item_t e1878;
            public sg_imgui_capture_item_t e1879;
            public sg_imgui_capture_item_t e1880;
            public sg_imgui_capture_item_t e1881;
            public sg_imgui_capture_item_t e1882;
            public sg_imgui_capture_item_t e1883;
            public sg_imgui_capture_item_t e1884;
            public sg_imgui_capture_item_t e1885;
            public sg_imgui_capture_item_t e1886;
            public sg_imgui_capture_item_t e1887;
            public sg_imgui_capture_item_t e1888;
            public sg_imgui_capture_item_t e1889;
            public sg_imgui_capture_item_t e1890;
            public sg_imgui_capture_item_t e1891;
            public sg_imgui_capture_item_t e1892;
            public sg_imgui_capture_item_t e1893;
            public sg_imgui_capture_item_t e1894;
            public sg_imgui_capture_item_t e1895;
            public sg_imgui_capture_item_t e1896;
            public sg_imgui_capture_item_t e1897;
            public sg_imgui_capture_item_t e1898;
            public sg_imgui_capture_item_t e1899;
            public sg_imgui_capture_item_t e1900;
            public sg_imgui_capture_item_t e1901;
            public sg_imgui_capture_item_t e1902;
            public sg_imgui_capture_item_t e1903;
            public sg_imgui_capture_item_t e1904;
            public sg_imgui_capture_item_t e1905;
            public sg_imgui_capture_item_t e1906;
            public sg_imgui_capture_item_t e1907;
            public sg_imgui_capture_item_t e1908;
            public sg_imgui_capture_item_t e1909;
            public sg_imgui_capture_item_t e1910;
            public sg_imgui_capture_item_t e1911;
            public sg_imgui_capture_item_t e1912;
            public sg_imgui_capture_item_t e1913;
            public sg_imgui_capture_item_t e1914;
            public sg_imgui_capture_item_t e1915;
            public sg_imgui_capture_item_t e1916;
            public sg_imgui_capture_item_t e1917;
            public sg_imgui_capture_item_t e1918;
            public sg_imgui_capture_item_t e1919;
            public sg_imgui_capture_item_t e1920;
            public sg_imgui_capture_item_t e1921;
            public sg_imgui_capture_item_t e1922;
            public sg_imgui_capture_item_t e1923;
            public sg_imgui_capture_item_t e1924;
            public sg_imgui_capture_item_t e1925;
            public sg_imgui_capture_item_t e1926;
            public sg_imgui_capture_item_t e1927;
            public sg_imgui_capture_item_t e1928;
            public sg_imgui_capture_item_t e1929;
            public sg_imgui_capture_item_t e1930;
            public sg_imgui_capture_item_t e1931;
            public sg_imgui_capture_item_t e1932;
            public sg_imgui_capture_item_t e1933;
            public sg_imgui_capture_item_t e1934;
            public sg_imgui_capture_item_t e1935;
            public sg_imgui_capture_item_t e1936;
            public sg_imgui_capture_item_t e1937;
            public sg_imgui_capture_item_t e1938;
            public sg_imgui_capture_item_t e1939;
            public sg_imgui_capture_item_t e1940;
            public sg_imgui_capture_item_t e1941;
            public sg_imgui_capture_item_t e1942;
            public sg_imgui_capture_item_t e1943;
            public sg_imgui_capture_item_t e1944;
            public sg_imgui_capture_item_t e1945;
            public sg_imgui_capture_item_t e1946;
            public sg_imgui_capture_item_t e1947;
            public sg_imgui_capture_item_t e1948;
            public sg_imgui_capture_item_t e1949;
            public sg_imgui_capture_item_t e1950;
            public sg_imgui_capture_item_t e1951;
            public sg_imgui_capture_item_t e1952;
            public sg_imgui_capture_item_t e1953;
            public sg_imgui_capture_item_t e1954;
            public sg_imgui_capture_item_t e1955;
            public sg_imgui_capture_item_t e1956;
            public sg_imgui_capture_item_t e1957;
            public sg_imgui_capture_item_t e1958;
            public sg_imgui_capture_item_t e1959;
            public sg_imgui_capture_item_t e1960;
            public sg_imgui_capture_item_t e1961;
            public sg_imgui_capture_item_t e1962;
            public sg_imgui_capture_item_t e1963;
            public sg_imgui_capture_item_t e1964;
            public sg_imgui_capture_item_t e1965;
            public sg_imgui_capture_item_t e1966;
            public sg_imgui_capture_item_t e1967;
            public sg_imgui_capture_item_t e1968;
            public sg_imgui_capture_item_t e1969;
            public sg_imgui_capture_item_t e1970;
            public sg_imgui_capture_item_t e1971;
            public sg_imgui_capture_item_t e1972;
            public sg_imgui_capture_item_t e1973;
            public sg_imgui_capture_item_t e1974;
            public sg_imgui_capture_item_t e1975;
            public sg_imgui_capture_item_t e1976;
            public sg_imgui_capture_item_t e1977;
            public sg_imgui_capture_item_t e1978;
            public sg_imgui_capture_item_t e1979;
            public sg_imgui_capture_item_t e1980;
            public sg_imgui_capture_item_t e1981;
            public sg_imgui_capture_item_t e1982;
            public sg_imgui_capture_item_t e1983;
            public sg_imgui_capture_item_t e1984;
            public sg_imgui_capture_item_t e1985;
            public sg_imgui_capture_item_t e1986;
            public sg_imgui_capture_item_t e1987;
            public sg_imgui_capture_item_t e1988;
            public sg_imgui_capture_item_t e1989;
            public sg_imgui_capture_item_t e1990;
            public sg_imgui_capture_item_t e1991;
            public sg_imgui_capture_item_t e1992;
            public sg_imgui_capture_item_t e1993;
            public sg_imgui_capture_item_t e1994;
            public sg_imgui_capture_item_t e1995;
            public sg_imgui_capture_item_t e1996;
            public sg_imgui_capture_item_t e1997;
            public sg_imgui_capture_item_t e1998;
            public sg_imgui_capture_item_t e1999;
            public sg_imgui_capture_item_t e2000;
            public sg_imgui_capture_item_t e2001;
            public sg_imgui_capture_item_t e2002;
            public sg_imgui_capture_item_t e2003;
            public sg_imgui_capture_item_t e2004;
            public sg_imgui_capture_item_t e2005;
            public sg_imgui_capture_item_t e2006;
            public sg_imgui_capture_item_t e2007;
            public sg_imgui_capture_item_t e2008;
            public sg_imgui_capture_item_t e2009;
            public sg_imgui_capture_item_t e2010;
            public sg_imgui_capture_item_t e2011;
            public sg_imgui_capture_item_t e2012;
            public sg_imgui_capture_item_t e2013;
            public sg_imgui_capture_item_t e2014;
            public sg_imgui_capture_item_t e2015;
            public sg_imgui_capture_item_t e2016;
            public sg_imgui_capture_item_t e2017;
            public sg_imgui_capture_item_t e2018;
            public sg_imgui_capture_item_t e2019;
            public sg_imgui_capture_item_t e2020;
            public sg_imgui_capture_item_t e2021;
            public sg_imgui_capture_item_t e2022;
            public sg_imgui_capture_item_t e2023;
            public sg_imgui_capture_item_t e2024;
            public sg_imgui_capture_item_t e2025;
            public sg_imgui_capture_item_t e2026;
            public sg_imgui_capture_item_t e2027;
            public sg_imgui_capture_item_t e2028;
            public sg_imgui_capture_item_t e2029;
            public sg_imgui_capture_item_t e2030;
            public sg_imgui_capture_item_t e2031;
            public sg_imgui_capture_item_t e2032;
            public sg_imgui_capture_item_t e2033;
            public sg_imgui_capture_item_t e2034;
            public sg_imgui_capture_item_t e2035;
            public sg_imgui_capture_item_t e2036;
            public sg_imgui_capture_item_t e2037;
            public sg_imgui_capture_item_t e2038;
            public sg_imgui_capture_item_t e2039;
            public sg_imgui_capture_item_t e2040;
            public sg_imgui_capture_item_t e2041;
            public sg_imgui_capture_item_t e2042;
            public sg_imgui_capture_item_t e2043;
            public sg_imgui_capture_item_t e2044;
            public sg_imgui_capture_item_t e2045;
            public sg_imgui_capture_item_t e2046;
            public sg_imgui_capture_item_t e2047;
            public sg_imgui_capture_item_t e2048;
            public sg_imgui_capture_item_t e2049;
            public sg_imgui_capture_item_t e2050;
            public sg_imgui_capture_item_t e2051;
            public sg_imgui_capture_item_t e2052;
            public sg_imgui_capture_item_t e2053;
            public sg_imgui_capture_item_t e2054;
            public sg_imgui_capture_item_t e2055;
            public sg_imgui_capture_item_t e2056;
            public sg_imgui_capture_item_t e2057;
            public sg_imgui_capture_item_t e2058;
            public sg_imgui_capture_item_t e2059;
            public sg_imgui_capture_item_t e2060;
            public sg_imgui_capture_item_t e2061;
            public sg_imgui_capture_item_t e2062;
            public sg_imgui_capture_item_t e2063;
            public sg_imgui_capture_item_t e2064;
            public sg_imgui_capture_item_t e2065;
            public sg_imgui_capture_item_t e2066;
            public sg_imgui_capture_item_t e2067;
            public sg_imgui_capture_item_t e2068;
            public sg_imgui_capture_item_t e2069;
            public sg_imgui_capture_item_t e2070;
            public sg_imgui_capture_item_t e2071;
            public sg_imgui_capture_item_t e2072;
            public sg_imgui_capture_item_t e2073;
            public sg_imgui_capture_item_t e2074;
            public sg_imgui_capture_item_t e2075;
            public sg_imgui_capture_item_t e2076;
            public sg_imgui_capture_item_t e2077;
            public sg_imgui_capture_item_t e2078;
            public sg_imgui_capture_item_t e2079;
            public sg_imgui_capture_item_t e2080;
            public sg_imgui_capture_item_t e2081;
            public sg_imgui_capture_item_t e2082;
            public sg_imgui_capture_item_t e2083;
            public sg_imgui_capture_item_t e2084;
            public sg_imgui_capture_item_t e2085;
            public sg_imgui_capture_item_t e2086;
            public sg_imgui_capture_item_t e2087;
            public sg_imgui_capture_item_t e2088;
            public sg_imgui_capture_item_t e2089;
            public sg_imgui_capture_item_t e2090;
            public sg_imgui_capture_item_t e2091;
            public sg_imgui_capture_item_t e2092;
            public sg_imgui_capture_item_t e2093;
            public sg_imgui_capture_item_t e2094;
            public sg_imgui_capture_item_t e2095;
            public sg_imgui_capture_item_t e2096;
            public sg_imgui_capture_item_t e2097;
            public sg_imgui_capture_item_t e2098;
            public sg_imgui_capture_item_t e2099;
            public sg_imgui_capture_item_t e2100;
            public sg_imgui_capture_item_t e2101;
            public sg_imgui_capture_item_t e2102;
            public sg_imgui_capture_item_t e2103;
            public sg_imgui_capture_item_t e2104;
            public sg_imgui_capture_item_t e2105;
            public sg_imgui_capture_item_t e2106;
            public sg_imgui_capture_item_t e2107;
            public sg_imgui_capture_item_t e2108;
            public sg_imgui_capture_item_t e2109;
            public sg_imgui_capture_item_t e2110;
            public sg_imgui_capture_item_t e2111;
            public sg_imgui_capture_item_t e2112;
            public sg_imgui_capture_item_t e2113;
            public sg_imgui_capture_item_t e2114;
            public sg_imgui_capture_item_t e2115;
            public sg_imgui_capture_item_t e2116;
            public sg_imgui_capture_item_t e2117;
            public sg_imgui_capture_item_t e2118;
            public sg_imgui_capture_item_t e2119;
            public sg_imgui_capture_item_t e2120;
            public sg_imgui_capture_item_t e2121;
            public sg_imgui_capture_item_t e2122;
            public sg_imgui_capture_item_t e2123;
            public sg_imgui_capture_item_t e2124;
            public sg_imgui_capture_item_t e2125;
            public sg_imgui_capture_item_t e2126;
            public sg_imgui_capture_item_t e2127;
            public sg_imgui_capture_item_t e2128;
            public sg_imgui_capture_item_t e2129;
            public sg_imgui_capture_item_t e2130;
            public sg_imgui_capture_item_t e2131;
            public sg_imgui_capture_item_t e2132;
            public sg_imgui_capture_item_t e2133;
            public sg_imgui_capture_item_t e2134;
            public sg_imgui_capture_item_t e2135;
            public sg_imgui_capture_item_t e2136;
            public sg_imgui_capture_item_t e2137;
            public sg_imgui_capture_item_t e2138;
            public sg_imgui_capture_item_t e2139;
            public sg_imgui_capture_item_t e2140;
            public sg_imgui_capture_item_t e2141;
            public sg_imgui_capture_item_t e2142;
            public sg_imgui_capture_item_t e2143;
            public sg_imgui_capture_item_t e2144;
            public sg_imgui_capture_item_t e2145;
            public sg_imgui_capture_item_t e2146;
            public sg_imgui_capture_item_t e2147;
            public sg_imgui_capture_item_t e2148;
            public sg_imgui_capture_item_t e2149;
            public sg_imgui_capture_item_t e2150;
            public sg_imgui_capture_item_t e2151;
            public sg_imgui_capture_item_t e2152;
            public sg_imgui_capture_item_t e2153;
            public sg_imgui_capture_item_t e2154;
            public sg_imgui_capture_item_t e2155;
            public sg_imgui_capture_item_t e2156;
            public sg_imgui_capture_item_t e2157;
            public sg_imgui_capture_item_t e2158;
            public sg_imgui_capture_item_t e2159;
            public sg_imgui_capture_item_t e2160;
            public sg_imgui_capture_item_t e2161;
            public sg_imgui_capture_item_t e2162;
            public sg_imgui_capture_item_t e2163;
            public sg_imgui_capture_item_t e2164;
            public sg_imgui_capture_item_t e2165;
            public sg_imgui_capture_item_t e2166;
            public sg_imgui_capture_item_t e2167;
            public sg_imgui_capture_item_t e2168;
            public sg_imgui_capture_item_t e2169;
            public sg_imgui_capture_item_t e2170;
            public sg_imgui_capture_item_t e2171;
            public sg_imgui_capture_item_t e2172;
            public sg_imgui_capture_item_t e2173;
            public sg_imgui_capture_item_t e2174;
            public sg_imgui_capture_item_t e2175;
            public sg_imgui_capture_item_t e2176;
            public sg_imgui_capture_item_t e2177;
            public sg_imgui_capture_item_t e2178;
            public sg_imgui_capture_item_t e2179;
            public sg_imgui_capture_item_t e2180;
            public sg_imgui_capture_item_t e2181;
            public sg_imgui_capture_item_t e2182;
            public sg_imgui_capture_item_t e2183;
            public sg_imgui_capture_item_t e2184;
            public sg_imgui_capture_item_t e2185;
            public sg_imgui_capture_item_t e2186;
            public sg_imgui_capture_item_t e2187;
            public sg_imgui_capture_item_t e2188;
            public sg_imgui_capture_item_t e2189;
            public sg_imgui_capture_item_t e2190;
            public sg_imgui_capture_item_t e2191;
            public sg_imgui_capture_item_t e2192;
            public sg_imgui_capture_item_t e2193;
            public sg_imgui_capture_item_t e2194;
            public sg_imgui_capture_item_t e2195;
            public sg_imgui_capture_item_t e2196;
            public sg_imgui_capture_item_t e2197;
            public sg_imgui_capture_item_t e2198;
            public sg_imgui_capture_item_t e2199;
            public sg_imgui_capture_item_t e2200;
            public sg_imgui_capture_item_t e2201;
            public sg_imgui_capture_item_t e2202;
            public sg_imgui_capture_item_t e2203;
            public sg_imgui_capture_item_t e2204;
            public sg_imgui_capture_item_t e2205;
            public sg_imgui_capture_item_t e2206;
            public sg_imgui_capture_item_t e2207;
            public sg_imgui_capture_item_t e2208;
            public sg_imgui_capture_item_t e2209;
            public sg_imgui_capture_item_t e2210;
            public sg_imgui_capture_item_t e2211;
            public sg_imgui_capture_item_t e2212;
            public sg_imgui_capture_item_t e2213;
            public sg_imgui_capture_item_t e2214;
            public sg_imgui_capture_item_t e2215;
            public sg_imgui_capture_item_t e2216;
            public sg_imgui_capture_item_t e2217;
            public sg_imgui_capture_item_t e2218;
            public sg_imgui_capture_item_t e2219;
            public sg_imgui_capture_item_t e2220;
            public sg_imgui_capture_item_t e2221;
            public sg_imgui_capture_item_t e2222;
            public sg_imgui_capture_item_t e2223;
            public sg_imgui_capture_item_t e2224;
            public sg_imgui_capture_item_t e2225;
            public sg_imgui_capture_item_t e2226;
            public sg_imgui_capture_item_t e2227;
            public sg_imgui_capture_item_t e2228;
            public sg_imgui_capture_item_t e2229;
            public sg_imgui_capture_item_t e2230;
            public sg_imgui_capture_item_t e2231;
            public sg_imgui_capture_item_t e2232;
            public sg_imgui_capture_item_t e2233;
            public sg_imgui_capture_item_t e2234;
            public sg_imgui_capture_item_t e2235;
            public sg_imgui_capture_item_t e2236;
            public sg_imgui_capture_item_t e2237;
            public sg_imgui_capture_item_t e2238;
            public sg_imgui_capture_item_t e2239;
            public sg_imgui_capture_item_t e2240;
            public sg_imgui_capture_item_t e2241;
            public sg_imgui_capture_item_t e2242;
            public sg_imgui_capture_item_t e2243;
            public sg_imgui_capture_item_t e2244;
            public sg_imgui_capture_item_t e2245;
            public sg_imgui_capture_item_t e2246;
            public sg_imgui_capture_item_t e2247;
            public sg_imgui_capture_item_t e2248;
            public sg_imgui_capture_item_t e2249;
            public sg_imgui_capture_item_t e2250;
            public sg_imgui_capture_item_t e2251;
            public sg_imgui_capture_item_t e2252;
            public sg_imgui_capture_item_t e2253;
            public sg_imgui_capture_item_t e2254;
            public sg_imgui_capture_item_t e2255;
            public sg_imgui_capture_item_t e2256;
            public sg_imgui_capture_item_t e2257;
            public sg_imgui_capture_item_t e2258;
            public sg_imgui_capture_item_t e2259;
            public sg_imgui_capture_item_t e2260;
            public sg_imgui_capture_item_t e2261;
            public sg_imgui_capture_item_t e2262;
            public sg_imgui_capture_item_t e2263;
            public sg_imgui_capture_item_t e2264;
            public sg_imgui_capture_item_t e2265;
            public sg_imgui_capture_item_t e2266;
            public sg_imgui_capture_item_t e2267;
            public sg_imgui_capture_item_t e2268;
            public sg_imgui_capture_item_t e2269;
            public sg_imgui_capture_item_t e2270;
            public sg_imgui_capture_item_t e2271;
            public sg_imgui_capture_item_t e2272;
            public sg_imgui_capture_item_t e2273;
            public sg_imgui_capture_item_t e2274;
            public sg_imgui_capture_item_t e2275;
            public sg_imgui_capture_item_t e2276;
            public sg_imgui_capture_item_t e2277;
            public sg_imgui_capture_item_t e2278;
            public sg_imgui_capture_item_t e2279;
            public sg_imgui_capture_item_t e2280;
            public sg_imgui_capture_item_t e2281;
            public sg_imgui_capture_item_t e2282;
            public sg_imgui_capture_item_t e2283;
            public sg_imgui_capture_item_t e2284;
            public sg_imgui_capture_item_t e2285;
            public sg_imgui_capture_item_t e2286;
            public sg_imgui_capture_item_t e2287;
            public sg_imgui_capture_item_t e2288;
            public sg_imgui_capture_item_t e2289;
            public sg_imgui_capture_item_t e2290;
            public sg_imgui_capture_item_t e2291;
            public sg_imgui_capture_item_t e2292;
            public sg_imgui_capture_item_t e2293;
            public sg_imgui_capture_item_t e2294;
            public sg_imgui_capture_item_t e2295;
            public sg_imgui_capture_item_t e2296;
            public sg_imgui_capture_item_t e2297;
            public sg_imgui_capture_item_t e2298;
            public sg_imgui_capture_item_t e2299;
            public sg_imgui_capture_item_t e2300;
            public sg_imgui_capture_item_t e2301;
            public sg_imgui_capture_item_t e2302;
            public sg_imgui_capture_item_t e2303;
            public sg_imgui_capture_item_t e2304;
            public sg_imgui_capture_item_t e2305;
            public sg_imgui_capture_item_t e2306;
            public sg_imgui_capture_item_t e2307;
            public sg_imgui_capture_item_t e2308;
            public sg_imgui_capture_item_t e2309;
            public sg_imgui_capture_item_t e2310;
            public sg_imgui_capture_item_t e2311;
            public sg_imgui_capture_item_t e2312;
            public sg_imgui_capture_item_t e2313;
            public sg_imgui_capture_item_t e2314;
            public sg_imgui_capture_item_t e2315;
            public sg_imgui_capture_item_t e2316;
            public sg_imgui_capture_item_t e2317;
            public sg_imgui_capture_item_t e2318;
            public sg_imgui_capture_item_t e2319;
            public sg_imgui_capture_item_t e2320;
            public sg_imgui_capture_item_t e2321;
            public sg_imgui_capture_item_t e2322;
            public sg_imgui_capture_item_t e2323;
            public sg_imgui_capture_item_t e2324;
            public sg_imgui_capture_item_t e2325;
            public sg_imgui_capture_item_t e2326;
            public sg_imgui_capture_item_t e2327;
            public sg_imgui_capture_item_t e2328;
            public sg_imgui_capture_item_t e2329;
            public sg_imgui_capture_item_t e2330;
            public sg_imgui_capture_item_t e2331;
            public sg_imgui_capture_item_t e2332;
            public sg_imgui_capture_item_t e2333;
            public sg_imgui_capture_item_t e2334;
            public sg_imgui_capture_item_t e2335;
            public sg_imgui_capture_item_t e2336;
            public sg_imgui_capture_item_t e2337;
            public sg_imgui_capture_item_t e2338;
            public sg_imgui_capture_item_t e2339;
            public sg_imgui_capture_item_t e2340;
            public sg_imgui_capture_item_t e2341;
            public sg_imgui_capture_item_t e2342;
            public sg_imgui_capture_item_t e2343;
            public sg_imgui_capture_item_t e2344;
            public sg_imgui_capture_item_t e2345;
            public sg_imgui_capture_item_t e2346;
            public sg_imgui_capture_item_t e2347;
            public sg_imgui_capture_item_t e2348;
            public sg_imgui_capture_item_t e2349;
            public sg_imgui_capture_item_t e2350;
            public sg_imgui_capture_item_t e2351;
            public sg_imgui_capture_item_t e2352;
            public sg_imgui_capture_item_t e2353;
            public sg_imgui_capture_item_t e2354;
            public sg_imgui_capture_item_t e2355;
            public sg_imgui_capture_item_t e2356;
            public sg_imgui_capture_item_t e2357;
            public sg_imgui_capture_item_t e2358;
            public sg_imgui_capture_item_t e2359;
            public sg_imgui_capture_item_t e2360;
            public sg_imgui_capture_item_t e2361;
            public sg_imgui_capture_item_t e2362;
            public sg_imgui_capture_item_t e2363;
            public sg_imgui_capture_item_t e2364;
            public sg_imgui_capture_item_t e2365;
            public sg_imgui_capture_item_t e2366;
            public sg_imgui_capture_item_t e2367;
            public sg_imgui_capture_item_t e2368;
            public sg_imgui_capture_item_t e2369;
            public sg_imgui_capture_item_t e2370;
            public sg_imgui_capture_item_t e2371;
            public sg_imgui_capture_item_t e2372;
            public sg_imgui_capture_item_t e2373;
            public sg_imgui_capture_item_t e2374;
            public sg_imgui_capture_item_t e2375;
            public sg_imgui_capture_item_t e2376;
            public sg_imgui_capture_item_t e2377;
            public sg_imgui_capture_item_t e2378;
            public sg_imgui_capture_item_t e2379;
            public sg_imgui_capture_item_t e2380;
            public sg_imgui_capture_item_t e2381;
            public sg_imgui_capture_item_t e2382;
            public sg_imgui_capture_item_t e2383;
            public sg_imgui_capture_item_t e2384;
            public sg_imgui_capture_item_t e2385;
            public sg_imgui_capture_item_t e2386;
            public sg_imgui_capture_item_t e2387;
            public sg_imgui_capture_item_t e2388;
            public sg_imgui_capture_item_t e2389;
            public sg_imgui_capture_item_t e2390;
            public sg_imgui_capture_item_t e2391;
            public sg_imgui_capture_item_t e2392;
            public sg_imgui_capture_item_t e2393;
            public sg_imgui_capture_item_t e2394;
            public sg_imgui_capture_item_t e2395;
            public sg_imgui_capture_item_t e2396;
            public sg_imgui_capture_item_t e2397;
            public sg_imgui_capture_item_t e2398;
            public sg_imgui_capture_item_t e2399;
            public sg_imgui_capture_item_t e2400;
            public sg_imgui_capture_item_t e2401;
            public sg_imgui_capture_item_t e2402;
            public sg_imgui_capture_item_t e2403;
            public sg_imgui_capture_item_t e2404;
            public sg_imgui_capture_item_t e2405;
            public sg_imgui_capture_item_t e2406;
            public sg_imgui_capture_item_t e2407;
            public sg_imgui_capture_item_t e2408;
            public sg_imgui_capture_item_t e2409;
            public sg_imgui_capture_item_t e2410;
            public sg_imgui_capture_item_t e2411;
            public sg_imgui_capture_item_t e2412;
            public sg_imgui_capture_item_t e2413;
            public sg_imgui_capture_item_t e2414;
            public sg_imgui_capture_item_t e2415;
            public sg_imgui_capture_item_t e2416;
            public sg_imgui_capture_item_t e2417;
            public sg_imgui_capture_item_t e2418;
            public sg_imgui_capture_item_t e2419;
            public sg_imgui_capture_item_t e2420;
            public sg_imgui_capture_item_t e2421;
            public sg_imgui_capture_item_t e2422;
            public sg_imgui_capture_item_t e2423;
            public sg_imgui_capture_item_t e2424;
            public sg_imgui_capture_item_t e2425;
            public sg_imgui_capture_item_t e2426;
            public sg_imgui_capture_item_t e2427;
            public sg_imgui_capture_item_t e2428;
            public sg_imgui_capture_item_t e2429;
            public sg_imgui_capture_item_t e2430;
            public sg_imgui_capture_item_t e2431;
            public sg_imgui_capture_item_t e2432;
            public sg_imgui_capture_item_t e2433;
            public sg_imgui_capture_item_t e2434;
            public sg_imgui_capture_item_t e2435;
            public sg_imgui_capture_item_t e2436;
            public sg_imgui_capture_item_t e2437;
            public sg_imgui_capture_item_t e2438;
            public sg_imgui_capture_item_t e2439;
            public sg_imgui_capture_item_t e2440;
            public sg_imgui_capture_item_t e2441;
            public sg_imgui_capture_item_t e2442;
            public sg_imgui_capture_item_t e2443;
            public sg_imgui_capture_item_t e2444;
            public sg_imgui_capture_item_t e2445;
            public sg_imgui_capture_item_t e2446;
            public sg_imgui_capture_item_t e2447;
            public sg_imgui_capture_item_t e2448;
            public sg_imgui_capture_item_t e2449;
            public sg_imgui_capture_item_t e2450;
            public sg_imgui_capture_item_t e2451;
            public sg_imgui_capture_item_t e2452;
            public sg_imgui_capture_item_t e2453;
            public sg_imgui_capture_item_t e2454;
            public sg_imgui_capture_item_t e2455;
            public sg_imgui_capture_item_t e2456;
            public sg_imgui_capture_item_t e2457;
            public sg_imgui_capture_item_t e2458;
            public sg_imgui_capture_item_t e2459;
            public sg_imgui_capture_item_t e2460;
            public sg_imgui_capture_item_t e2461;
            public sg_imgui_capture_item_t e2462;
            public sg_imgui_capture_item_t e2463;
            public sg_imgui_capture_item_t e2464;
            public sg_imgui_capture_item_t e2465;
            public sg_imgui_capture_item_t e2466;
            public sg_imgui_capture_item_t e2467;
            public sg_imgui_capture_item_t e2468;
            public sg_imgui_capture_item_t e2469;
            public sg_imgui_capture_item_t e2470;
            public sg_imgui_capture_item_t e2471;
            public sg_imgui_capture_item_t e2472;
            public sg_imgui_capture_item_t e2473;
            public sg_imgui_capture_item_t e2474;
            public sg_imgui_capture_item_t e2475;
            public sg_imgui_capture_item_t e2476;
            public sg_imgui_capture_item_t e2477;
            public sg_imgui_capture_item_t e2478;
            public sg_imgui_capture_item_t e2479;
            public sg_imgui_capture_item_t e2480;
            public sg_imgui_capture_item_t e2481;
            public sg_imgui_capture_item_t e2482;
            public sg_imgui_capture_item_t e2483;
            public sg_imgui_capture_item_t e2484;
            public sg_imgui_capture_item_t e2485;
            public sg_imgui_capture_item_t e2486;
            public sg_imgui_capture_item_t e2487;
            public sg_imgui_capture_item_t e2488;
            public sg_imgui_capture_item_t e2489;
            public sg_imgui_capture_item_t e2490;
            public sg_imgui_capture_item_t e2491;
            public sg_imgui_capture_item_t e2492;
            public sg_imgui_capture_item_t e2493;
            public sg_imgui_capture_item_t e2494;
            public sg_imgui_capture_item_t e2495;
            public sg_imgui_capture_item_t e2496;
            public sg_imgui_capture_item_t e2497;
            public sg_imgui_capture_item_t e2498;
            public sg_imgui_capture_item_t e2499;
            public sg_imgui_capture_item_t e2500;
            public sg_imgui_capture_item_t e2501;
            public sg_imgui_capture_item_t e2502;
            public sg_imgui_capture_item_t e2503;
            public sg_imgui_capture_item_t e2504;
            public sg_imgui_capture_item_t e2505;
            public sg_imgui_capture_item_t e2506;
            public sg_imgui_capture_item_t e2507;
            public sg_imgui_capture_item_t e2508;
            public sg_imgui_capture_item_t e2509;
            public sg_imgui_capture_item_t e2510;
            public sg_imgui_capture_item_t e2511;
            public sg_imgui_capture_item_t e2512;
            public sg_imgui_capture_item_t e2513;
            public sg_imgui_capture_item_t e2514;
            public sg_imgui_capture_item_t e2515;
            public sg_imgui_capture_item_t e2516;
            public sg_imgui_capture_item_t e2517;
            public sg_imgui_capture_item_t e2518;
            public sg_imgui_capture_item_t e2519;
            public sg_imgui_capture_item_t e2520;
            public sg_imgui_capture_item_t e2521;
            public sg_imgui_capture_item_t e2522;
            public sg_imgui_capture_item_t e2523;
            public sg_imgui_capture_item_t e2524;
            public sg_imgui_capture_item_t e2525;
            public sg_imgui_capture_item_t e2526;
            public sg_imgui_capture_item_t e2527;
            public sg_imgui_capture_item_t e2528;
            public sg_imgui_capture_item_t e2529;
            public sg_imgui_capture_item_t e2530;
            public sg_imgui_capture_item_t e2531;
            public sg_imgui_capture_item_t e2532;
            public sg_imgui_capture_item_t e2533;
            public sg_imgui_capture_item_t e2534;
            public sg_imgui_capture_item_t e2535;
            public sg_imgui_capture_item_t e2536;
            public sg_imgui_capture_item_t e2537;
            public sg_imgui_capture_item_t e2538;
            public sg_imgui_capture_item_t e2539;
            public sg_imgui_capture_item_t e2540;
            public sg_imgui_capture_item_t e2541;
            public sg_imgui_capture_item_t e2542;
            public sg_imgui_capture_item_t e2543;
            public sg_imgui_capture_item_t e2544;
            public sg_imgui_capture_item_t e2545;
            public sg_imgui_capture_item_t e2546;
            public sg_imgui_capture_item_t e2547;
            public sg_imgui_capture_item_t e2548;
            public sg_imgui_capture_item_t e2549;
            public sg_imgui_capture_item_t e2550;
            public sg_imgui_capture_item_t e2551;
            public sg_imgui_capture_item_t e2552;
            public sg_imgui_capture_item_t e2553;
            public sg_imgui_capture_item_t e2554;
            public sg_imgui_capture_item_t e2555;
            public sg_imgui_capture_item_t e2556;
            public sg_imgui_capture_item_t e2557;
            public sg_imgui_capture_item_t e2558;
            public sg_imgui_capture_item_t e2559;
            public sg_imgui_capture_item_t e2560;
            public sg_imgui_capture_item_t e2561;
            public sg_imgui_capture_item_t e2562;
            public sg_imgui_capture_item_t e2563;
            public sg_imgui_capture_item_t e2564;
            public sg_imgui_capture_item_t e2565;
            public sg_imgui_capture_item_t e2566;
            public sg_imgui_capture_item_t e2567;
            public sg_imgui_capture_item_t e2568;
            public sg_imgui_capture_item_t e2569;
            public sg_imgui_capture_item_t e2570;
            public sg_imgui_capture_item_t e2571;
            public sg_imgui_capture_item_t e2572;
            public sg_imgui_capture_item_t e2573;
            public sg_imgui_capture_item_t e2574;
            public sg_imgui_capture_item_t e2575;
            public sg_imgui_capture_item_t e2576;
            public sg_imgui_capture_item_t e2577;
            public sg_imgui_capture_item_t e2578;
            public sg_imgui_capture_item_t e2579;
            public sg_imgui_capture_item_t e2580;
            public sg_imgui_capture_item_t e2581;
            public sg_imgui_capture_item_t e2582;
            public sg_imgui_capture_item_t e2583;
            public sg_imgui_capture_item_t e2584;
            public sg_imgui_capture_item_t e2585;
            public sg_imgui_capture_item_t e2586;
            public sg_imgui_capture_item_t e2587;
            public sg_imgui_capture_item_t e2588;
            public sg_imgui_capture_item_t e2589;
            public sg_imgui_capture_item_t e2590;
            public sg_imgui_capture_item_t e2591;
            public sg_imgui_capture_item_t e2592;
            public sg_imgui_capture_item_t e2593;
            public sg_imgui_capture_item_t e2594;
            public sg_imgui_capture_item_t e2595;
            public sg_imgui_capture_item_t e2596;
            public sg_imgui_capture_item_t e2597;
            public sg_imgui_capture_item_t e2598;
            public sg_imgui_capture_item_t e2599;
            public sg_imgui_capture_item_t e2600;
            public sg_imgui_capture_item_t e2601;
            public sg_imgui_capture_item_t e2602;
            public sg_imgui_capture_item_t e2603;
            public sg_imgui_capture_item_t e2604;
            public sg_imgui_capture_item_t e2605;
            public sg_imgui_capture_item_t e2606;
            public sg_imgui_capture_item_t e2607;
            public sg_imgui_capture_item_t e2608;
            public sg_imgui_capture_item_t e2609;
            public sg_imgui_capture_item_t e2610;
            public sg_imgui_capture_item_t e2611;
            public sg_imgui_capture_item_t e2612;
            public sg_imgui_capture_item_t e2613;
            public sg_imgui_capture_item_t e2614;
            public sg_imgui_capture_item_t e2615;
            public sg_imgui_capture_item_t e2616;
            public sg_imgui_capture_item_t e2617;
            public sg_imgui_capture_item_t e2618;
            public sg_imgui_capture_item_t e2619;
            public sg_imgui_capture_item_t e2620;
            public sg_imgui_capture_item_t e2621;
            public sg_imgui_capture_item_t e2622;
            public sg_imgui_capture_item_t e2623;
            public sg_imgui_capture_item_t e2624;
            public sg_imgui_capture_item_t e2625;
            public sg_imgui_capture_item_t e2626;
            public sg_imgui_capture_item_t e2627;
            public sg_imgui_capture_item_t e2628;
            public sg_imgui_capture_item_t e2629;
            public sg_imgui_capture_item_t e2630;
            public sg_imgui_capture_item_t e2631;
            public sg_imgui_capture_item_t e2632;
            public sg_imgui_capture_item_t e2633;
            public sg_imgui_capture_item_t e2634;
            public sg_imgui_capture_item_t e2635;
            public sg_imgui_capture_item_t e2636;
            public sg_imgui_capture_item_t e2637;
            public sg_imgui_capture_item_t e2638;
            public sg_imgui_capture_item_t e2639;
            public sg_imgui_capture_item_t e2640;
            public sg_imgui_capture_item_t e2641;
            public sg_imgui_capture_item_t e2642;
            public sg_imgui_capture_item_t e2643;
            public sg_imgui_capture_item_t e2644;
            public sg_imgui_capture_item_t e2645;
            public sg_imgui_capture_item_t e2646;
            public sg_imgui_capture_item_t e2647;
            public sg_imgui_capture_item_t e2648;
            public sg_imgui_capture_item_t e2649;
            public sg_imgui_capture_item_t e2650;
            public sg_imgui_capture_item_t e2651;
            public sg_imgui_capture_item_t e2652;
            public sg_imgui_capture_item_t e2653;
            public sg_imgui_capture_item_t e2654;
            public sg_imgui_capture_item_t e2655;
            public sg_imgui_capture_item_t e2656;
            public sg_imgui_capture_item_t e2657;
            public sg_imgui_capture_item_t e2658;
            public sg_imgui_capture_item_t e2659;
            public sg_imgui_capture_item_t e2660;
            public sg_imgui_capture_item_t e2661;
            public sg_imgui_capture_item_t e2662;
            public sg_imgui_capture_item_t e2663;
            public sg_imgui_capture_item_t e2664;
            public sg_imgui_capture_item_t e2665;
            public sg_imgui_capture_item_t e2666;
            public sg_imgui_capture_item_t e2667;
            public sg_imgui_capture_item_t e2668;
            public sg_imgui_capture_item_t e2669;
            public sg_imgui_capture_item_t e2670;
            public sg_imgui_capture_item_t e2671;
            public sg_imgui_capture_item_t e2672;
            public sg_imgui_capture_item_t e2673;
            public sg_imgui_capture_item_t e2674;
            public sg_imgui_capture_item_t e2675;
            public sg_imgui_capture_item_t e2676;
            public sg_imgui_capture_item_t e2677;
            public sg_imgui_capture_item_t e2678;
            public sg_imgui_capture_item_t e2679;
            public sg_imgui_capture_item_t e2680;
            public sg_imgui_capture_item_t e2681;
            public sg_imgui_capture_item_t e2682;
            public sg_imgui_capture_item_t e2683;
            public sg_imgui_capture_item_t e2684;
            public sg_imgui_capture_item_t e2685;
            public sg_imgui_capture_item_t e2686;
            public sg_imgui_capture_item_t e2687;
            public sg_imgui_capture_item_t e2688;
            public sg_imgui_capture_item_t e2689;
            public sg_imgui_capture_item_t e2690;
            public sg_imgui_capture_item_t e2691;
            public sg_imgui_capture_item_t e2692;
            public sg_imgui_capture_item_t e2693;
            public sg_imgui_capture_item_t e2694;
            public sg_imgui_capture_item_t e2695;
            public sg_imgui_capture_item_t e2696;
            public sg_imgui_capture_item_t e2697;
            public sg_imgui_capture_item_t e2698;
            public sg_imgui_capture_item_t e2699;
            public sg_imgui_capture_item_t e2700;
            public sg_imgui_capture_item_t e2701;
            public sg_imgui_capture_item_t e2702;
            public sg_imgui_capture_item_t e2703;
            public sg_imgui_capture_item_t e2704;
            public sg_imgui_capture_item_t e2705;
            public sg_imgui_capture_item_t e2706;
            public sg_imgui_capture_item_t e2707;
            public sg_imgui_capture_item_t e2708;
            public sg_imgui_capture_item_t e2709;
            public sg_imgui_capture_item_t e2710;
            public sg_imgui_capture_item_t e2711;
            public sg_imgui_capture_item_t e2712;
            public sg_imgui_capture_item_t e2713;
            public sg_imgui_capture_item_t e2714;
            public sg_imgui_capture_item_t e2715;
            public sg_imgui_capture_item_t e2716;
            public sg_imgui_capture_item_t e2717;
            public sg_imgui_capture_item_t e2718;
            public sg_imgui_capture_item_t e2719;
            public sg_imgui_capture_item_t e2720;
            public sg_imgui_capture_item_t e2721;
            public sg_imgui_capture_item_t e2722;
            public sg_imgui_capture_item_t e2723;
            public sg_imgui_capture_item_t e2724;
            public sg_imgui_capture_item_t e2725;
            public sg_imgui_capture_item_t e2726;
            public sg_imgui_capture_item_t e2727;
            public sg_imgui_capture_item_t e2728;
            public sg_imgui_capture_item_t e2729;
            public sg_imgui_capture_item_t e2730;
            public sg_imgui_capture_item_t e2731;
            public sg_imgui_capture_item_t e2732;
            public sg_imgui_capture_item_t e2733;
            public sg_imgui_capture_item_t e2734;
            public sg_imgui_capture_item_t e2735;
            public sg_imgui_capture_item_t e2736;
            public sg_imgui_capture_item_t e2737;
            public sg_imgui_capture_item_t e2738;
            public sg_imgui_capture_item_t e2739;
            public sg_imgui_capture_item_t e2740;
            public sg_imgui_capture_item_t e2741;
            public sg_imgui_capture_item_t e2742;
            public sg_imgui_capture_item_t e2743;
            public sg_imgui_capture_item_t e2744;
            public sg_imgui_capture_item_t e2745;
            public sg_imgui_capture_item_t e2746;
            public sg_imgui_capture_item_t e2747;
            public sg_imgui_capture_item_t e2748;
            public sg_imgui_capture_item_t e2749;
            public sg_imgui_capture_item_t e2750;
            public sg_imgui_capture_item_t e2751;
            public sg_imgui_capture_item_t e2752;
            public sg_imgui_capture_item_t e2753;
            public sg_imgui_capture_item_t e2754;
            public sg_imgui_capture_item_t e2755;
            public sg_imgui_capture_item_t e2756;
            public sg_imgui_capture_item_t e2757;
            public sg_imgui_capture_item_t e2758;
            public sg_imgui_capture_item_t e2759;
            public sg_imgui_capture_item_t e2760;
            public sg_imgui_capture_item_t e2761;
            public sg_imgui_capture_item_t e2762;
            public sg_imgui_capture_item_t e2763;
            public sg_imgui_capture_item_t e2764;
            public sg_imgui_capture_item_t e2765;
            public sg_imgui_capture_item_t e2766;
            public sg_imgui_capture_item_t e2767;
            public sg_imgui_capture_item_t e2768;
            public sg_imgui_capture_item_t e2769;
            public sg_imgui_capture_item_t e2770;
            public sg_imgui_capture_item_t e2771;
            public sg_imgui_capture_item_t e2772;
            public sg_imgui_capture_item_t e2773;
            public sg_imgui_capture_item_t e2774;
            public sg_imgui_capture_item_t e2775;
            public sg_imgui_capture_item_t e2776;
            public sg_imgui_capture_item_t e2777;
            public sg_imgui_capture_item_t e2778;
            public sg_imgui_capture_item_t e2779;
            public sg_imgui_capture_item_t e2780;
            public sg_imgui_capture_item_t e2781;
            public sg_imgui_capture_item_t e2782;
            public sg_imgui_capture_item_t e2783;
            public sg_imgui_capture_item_t e2784;
            public sg_imgui_capture_item_t e2785;
            public sg_imgui_capture_item_t e2786;
            public sg_imgui_capture_item_t e2787;
            public sg_imgui_capture_item_t e2788;
            public sg_imgui_capture_item_t e2789;
            public sg_imgui_capture_item_t e2790;
            public sg_imgui_capture_item_t e2791;
            public sg_imgui_capture_item_t e2792;
            public sg_imgui_capture_item_t e2793;
            public sg_imgui_capture_item_t e2794;
            public sg_imgui_capture_item_t e2795;
            public sg_imgui_capture_item_t e2796;
            public sg_imgui_capture_item_t e2797;
            public sg_imgui_capture_item_t e2798;
            public sg_imgui_capture_item_t e2799;
            public sg_imgui_capture_item_t e2800;
            public sg_imgui_capture_item_t e2801;
            public sg_imgui_capture_item_t e2802;
            public sg_imgui_capture_item_t e2803;
            public sg_imgui_capture_item_t e2804;
            public sg_imgui_capture_item_t e2805;
            public sg_imgui_capture_item_t e2806;
            public sg_imgui_capture_item_t e2807;
            public sg_imgui_capture_item_t e2808;
            public sg_imgui_capture_item_t e2809;
            public sg_imgui_capture_item_t e2810;
            public sg_imgui_capture_item_t e2811;
            public sg_imgui_capture_item_t e2812;
            public sg_imgui_capture_item_t e2813;
            public sg_imgui_capture_item_t e2814;
            public sg_imgui_capture_item_t e2815;
            public sg_imgui_capture_item_t e2816;
            public sg_imgui_capture_item_t e2817;
            public sg_imgui_capture_item_t e2818;
            public sg_imgui_capture_item_t e2819;
            public sg_imgui_capture_item_t e2820;
            public sg_imgui_capture_item_t e2821;
            public sg_imgui_capture_item_t e2822;
            public sg_imgui_capture_item_t e2823;
            public sg_imgui_capture_item_t e2824;
            public sg_imgui_capture_item_t e2825;
            public sg_imgui_capture_item_t e2826;
            public sg_imgui_capture_item_t e2827;
            public sg_imgui_capture_item_t e2828;
            public sg_imgui_capture_item_t e2829;
            public sg_imgui_capture_item_t e2830;
            public sg_imgui_capture_item_t e2831;
            public sg_imgui_capture_item_t e2832;
            public sg_imgui_capture_item_t e2833;
            public sg_imgui_capture_item_t e2834;
            public sg_imgui_capture_item_t e2835;
            public sg_imgui_capture_item_t e2836;
            public sg_imgui_capture_item_t e2837;
            public sg_imgui_capture_item_t e2838;
            public sg_imgui_capture_item_t e2839;
            public sg_imgui_capture_item_t e2840;
            public sg_imgui_capture_item_t e2841;
            public sg_imgui_capture_item_t e2842;
            public sg_imgui_capture_item_t e2843;
            public sg_imgui_capture_item_t e2844;
            public sg_imgui_capture_item_t e2845;
            public sg_imgui_capture_item_t e2846;
            public sg_imgui_capture_item_t e2847;
            public sg_imgui_capture_item_t e2848;
            public sg_imgui_capture_item_t e2849;
            public sg_imgui_capture_item_t e2850;
            public sg_imgui_capture_item_t e2851;
            public sg_imgui_capture_item_t e2852;
            public sg_imgui_capture_item_t e2853;
            public sg_imgui_capture_item_t e2854;
            public sg_imgui_capture_item_t e2855;
            public sg_imgui_capture_item_t e2856;
            public sg_imgui_capture_item_t e2857;
            public sg_imgui_capture_item_t e2858;
            public sg_imgui_capture_item_t e2859;
            public sg_imgui_capture_item_t e2860;
            public sg_imgui_capture_item_t e2861;
            public sg_imgui_capture_item_t e2862;
            public sg_imgui_capture_item_t e2863;
            public sg_imgui_capture_item_t e2864;
            public sg_imgui_capture_item_t e2865;
            public sg_imgui_capture_item_t e2866;
            public sg_imgui_capture_item_t e2867;
            public sg_imgui_capture_item_t e2868;
            public sg_imgui_capture_item_t e2869;
            public sg_imgui_capture_item_t e2870;
            public sg_imgui_capture_item_t e2871;
            public sg_imgui_capture_item_t e2872;
            public sg_imgui_capture_item_t e2873;
            public sg_imgui_capture_item_t e2874;
            public sg_imgui_capture_item_t e2875;
            public sg_imgui_capture_item_t e2876;
            public sg_imgui_capture_item_t e2877;
            public sg_imgui_capture_item_t e2878;
            public sg_imgui_capture_item_t e2879;
            public sg_imgui_capture_item_t e2880;
            public sg_imgui_capture_item_t e2881;
            public sg_imgui_capture_item_t e2882;
            public sg_imgui_capture_item_t e2883;
            public sg_imgui_capture_item_t e2884;
            public sg_imgui_capture_item_t e2885;
            public sg_imgui_capture_item_t e2886;
            public sg_imgui_capture_item_t e2887;
            public sg_imgui_capture_item_t e2888;
            public sg_imgui_capture_item_t e2889;
            public sg_imgui_capture_item_t e2890;
            public sg_imgui_capture_item_t e2891;
            public sg_imgui_capture_item_t e2892;
            public sg_imgui_capture_item_t e2893;
            public sg_imgui_capture_item_t e2894;
            public sg_imgui_capture_item_t e2895;
            public sg_imgui_capture_item_t e2896;
            public sg_imgui_capture_item_t e2897;
            public sg_imgui_capture_item_t e2898;
            public sg_imgui_capture_item_t e2899;
            public sg_imgui_capture_item_t e2900;
            public sg_imgui_capture_item_t e2901;
            public sg_imgui_capture_item_t e2902;
            public sg_imgui_capture_item_t e2903;
            public sg_imgui_capture_item_t e2904;
            public sg_imgui_capture_item_t e2905;
            public sg_imgui_capture_item_t e2906;
            public sg_imgui_capture_item_t e2907;
            public sg_imgui_capture_item_t e2908;
            public sg_imgui_capture_item_t e2909;
            public sg_imgui_capture_item_t e2910;
            public sg_imgui_capture_item_t e2911;
            public sg_imgui_capture_item_t e2912;
            public sg_imgui_capture_item_t e2913;
            public sg_imgui_capture_item_t e2914;
            public sg_imgui_capture_item_t e2915;
            public sg_imgui_capture_item_t e2916;
            public sg_imgui_capture_item_t e2917;
            public sg_imgui_capture_item_t e2918;
            public sg_imgui_capture_item_t e2919;
            public sg_imgui_capture_item_t e2920;
            public sg_imgui_capture_item_t e2921;
            public sg_imgui_capture_item_t e2922;
            public sg_imgui_capture_item_t e2923;
            public sg_imgui_capture_item_t e2924;
            public sg_imgui_capture_item_t e2925;
            public sg_imgui_capture_item_t e2926;
            public sg_imgui_capture_item_t e2927;
            public sg_imgui_capture_item_t e2928;
            public sg_imgui_capture_item_t e2929;
            public sg_imgui_capture_item_t e2930;
            public sg_imgui_capture_item_t e2931;
            public sg_imgui_capture_item_t e2932;
            public sg_imgui_capture_item_t e2933;
            public sg_imgui_capture_item_t e2934;
            public sg_imgui_capture_item_t e2935;
            public sg_imgui_capture_item_t e2936;
            public sg_imgui_capture_item_t e2937;
            public sg_imgui_capture_item_t e2938;
            public sg_imgui_capture_item_t e2939;
            public sg_imgui_capture_item_t e2940;
            public sg_imgui_capture_item_t e2941;
            public sg_imgui_capture_item_t e2942;
            public sg_imgui_capture_item_t e2943;
            public sg_imgui_capture_item_t e2944;
            public sg_imgui_capture_item_t e2945;
            public sg_imgui_capture_item_t e2946;
            public sg_imgui_capture_item_t e2947;
            public sg_imgui_capture_item_t e2948;
            public sg_imgui_capture_item_t e2949;
            public sg_imgui_capture_item_t e2950;
            public sg_imgui_capture_item_t e2951;
            public sg_imgui_capture_item_t e2952;
            public sg_imgui_capture_item_t e2953;
            public sg_imgui_capture_item_t e2954;
            public sg_imgui_capture_item_t e2955;
            public sg_imgui_capture_item_t e2956;
            public sg_imgui_capture_item_t e2957;
            public sg_imgui_capture_item_t e2958;
            public sg_imgui_capture_item_t e2959;
            public sg_imgui_capture_item_t e2960;
            public sg_imgui_capture_item_t e2961;
            public sg_imgui_capture_item_t e2962;
            public sg_imgui_capture_item_t e2963;
            public sg_imgui_capture_item_t e2964;
            public sg_imgui_capture_item_t e2965;
            public sg_imgui_capture_item_t e2966;
            public sg_imgui_capture_item_t e2967;
            public sg_imgui_capture_item_t e2968;
            public sg_imgui_capture_item_t e2969;
            public sg_imgui_capture_item_t e2970;
            public sg_imgui_capture_item_t e2971;
            public sg_imgui_capture_item_t e2972;
            public sg_imgui_capture_item_t e2973;
            public sg_imgui_capture_item_t e2974;
            public sg_imgui_capture_item_t e2975;
            public sg_imgui_capture_item_t e2976;
            public sg_imgui_capture_item_t e2977;
            public sg_imgui_capture_item_t e2978;
            public sg_imgui_capture_item_t e2979;
            public sg_imgui_capture_item_t e2980;
            public sg_imgui_capture_item_t e2981;
            public sg_imgui_capture_item_t e2982;
            public sg_imgui_capture_item_t e2983;
            public sg_imgui_capture_item_t e2984;
            public sg_imgui_capture_item_t e2985;
            public sg_imgui_capture_item_t e2986;
            public sg_imgui_capture_item_t e2987;
            public sg_imgui_capture_item_t e2988;
            public sg_imgui_capture_item_t e2989;
            public sg_imgui_capture_item_t e2990;
            public sg_imgui_capture_item_t e2991;
            public sg_imgui_capture_item_t e2992;
            public sg_imgui_capture_item_t e2993;
            public sg_imgui_capture_item_t e2994;
            public sg_imgui_capture_item_t e2995;
            public sg_imgui_capture_item_t e2996;
            public sg_imgui_capture_item_t e2997;
            public sg_imgui_capture_item_t e2998;
            public sg_imgui_capture_item_t e2999;
            public sg_imgui_capture_item_t e3000;
            public sg_imgui_capture_item_t e3001;
            public sg_imgui_capture_item_t e3002;
            public sg_imgui_capture_item_t e3003;
            public sg_imgui_capture_item_t e3004;
            public sg_imgui_capture_item_t e3005;
            public sg_imgui_capture_item_t e3006;
            public sg_imgui_capture_item_t e3007;
            public sg_imgui_capture_item_t e3008;
            public sg_imgui_capture_item_t e3009;
            public sg_imgui_capture_item_t e3010;
            public sg_imgui_capture_item_t e3011;
            public sg_imgui_capture_item_t e3012;
            public sg_imgui_capture_item_t e3013;
            public sg_imgui_capture_item_t e3014;
            public sg_imgui_capture_item_t e3015;
            public sg_imgui_capture_item_t e3016;
            public sg_imgui_capture_item_t e3017;
            public sg_imgui_capture_item_t e3018;
            public sg_imgui_capture_item_t e3019;
            public sg_imgui_capture_item_t e3020;
            public sg_imgui_capture_item_t e3021;
            public sg_imgui_capture_item_t e3022;
            public sg_imgui_capture_item_t e3023;
            public sg_imgui_capture_item_t e3024;
            public sg_imgui_capture_item_t e3025;
            public sg_imgui_capture_item_t e3026;
            public sg_imgui_capture_item_t e3027;
            public sg_imgui_capture_item_t e3028;
            public sg_imgui_capture_item_t e3029;
            public sg_imgui_capture_item_t e3030;
            public sg_imgui_capture_item_t e3031;
            public sg_imgui_capture_item_t e3032;
            public sg_imgui_capture_item_t e3033;
            public sg_imgui_capture_item_t e3034;
            public sg_imgui_capture_item_t e3035;
            public sg_imgui_capture_item_t e3036;
            public sg_imgui_capture_item_t e3037;
            public sg_imgui_capture_item_t e3038;
            public sg_imgui_capture_item_t e3039;
            public sg_imgui_capture_item_t e3040;
            public sg_imgui_capture_item_t e3041;
            public sg_imgui_capture_item_t e3042;
            public sg_imgui_capture_item_t e3043;
            public sg_imgui_capture_item_t e3044;
            public sg_imgui_capture_item_t e3045;
            public sg_imgui_capture_item_t e3046;
            public sg_imgui_capture_item_t e3047;
            public sg_imgui_capture_item_t e3048;
            public sg_imgui_capture_item_t e3049;
            public sg_imgui_capture_item_t e3050;
            public sg_imgui_capture_item_t e3051;
            public sg_imgui_capture_item_t e3052;
            public sg_imgui_capture_item_t e3053;
            public sg_imgui_capture_item_t e3054;
            public sg_imgui_capture_item_t e3055;
            public sg_imgui_capture_item_t e3056;
            public sg_imgui_capture_item_t e3057;
            public sg_imgui_capture_item_t e3058;
            public sg_imgui_capture_item_t e3059;
            public sg_imgui_capture_item_t e3060;
            public sg_imgui_capture_item_t e3061;
            public sg_imgui_capture_item_t e3062;
            public sg_imgui_capture_item_t e3063;
            public sg_imgui_capture_item_t e3064;
            public sg_imgui_capture_item_t e3065;
            public sg_imgui_capture_item_t e3066;
            public sg_imgui_capture_item_t e3067;
            public sg_imgui_capture_item_t e3068;
            public sg_imgui_capture_item_t e3069;
            public sg_imgui_capture_item_t e3070;
            public sg_imgui_capture_item_t e3071;
            public sg_imgui_capture_item_t e3072;
            public sg_imgui_capture_item_t e3073;
            public sg_imgui_capture_item_t e3074;
            public sg_imgui_capture_item_t e3075;
            public sg_imgui_capture_item_t e3076;
            public sg_imgui_capture_item_t e3077;
            public sg_imgui_capture_item_t e3078;
            public sg_imgui_capture_item_t e3079;
            public sg_imgui_capture_item_t e3080;
            public sg_imgui_capture_item_t e3081;
            public sg_imgui_capture_item_t e3082;
            public sg_imgui_capture_item_t e3083;
            public sg_imgui_capture_item_t e3084;
            public sg_imgui_capture_item_t e3085;
            public sg_imgui_capture_item_t e3086;
            public sg_imgui_capture_item_t e3087;
            public sg_imgui_capture_item_t e3088;
            public sg_imgui_capture_item_t e3089;
            public sg_imgui_capture_item_t e3090;
            public sg_imgui_capture_item_t e3091;
            public sg_imgui_capture_item_t e3092;
            public sg_imgui_capture_item_t e3093;
            public sg_imgui_capture_item_t e3094;
            public sg_imgui_capture_item_t e3095;
            public sg_imgui_capture_item_t e3096;
            public sg_imgui_capture_item_t e3097;
            public sg_imgui_capture_item_t e3098;
            public sg_imgui_capture_item_t e3099;
            public sg_imgui_capture_item_t e3100;
            public sg_imgui_capture_item_t e3101;
            public sg_imgui_capture_item_t e3102;
            public sg_imgui_capture_item_t e3103;
            public sg_imgui_capture_item_t e3104;
            public sg_imgui_capture_item_t e3105;
            public sg_imgui_capture_item_t e3106;
            public sg_imgui_capture_item_t e3107;
            public sg_imgui_capture_item_t e3108;
            public sg_imgui_capture_item_t e3109;
            public sg_imgui_capture_item_t e3110;
            public sg_imgui_capture_item_t e3111;
            public sg_imgui_capture_item_t e3112;
            public sg_imgui_capture_item_t e3113;
            public sg_imgui_capture_item_t e3114;
            public sg_imgui_capture_item_t e3115;
            public sg_imgui_capture_item_t e3116;
            public sg_imgui_capture_item_t e3117;
            public sg_imgui_capture_item_t e3118;
            public sg_imgui_capture_item_t e3119;
            public sg_imgui_capture_item_t e3120;
            public sg_imgui_capture_item_t e3121;
            public sg_imgui_capture_item_t e3122;
            public sg_imgui_capture_item_t e3123;
            public sg_imgui_capture_item_t e3124;
            public sg_imgui_capture_item_t e3125;
            public sg_imgui_capture_item_t e3126;
            public sg_imgui_capture_item_t e3127;
            public sg_imgui_capture_item_t e3128;
            public sg_imgui_capture_item_t e3129;
            public sg_imgui_capture_item_t e3130;
            public sg_imgui_capture_item_t e3131;
            public sg_imgui_capture_item_t e3132;
            public sg_imgui_capture_item_t e3133;
            public sg_imgui_capture_item_t e3134;
            public sg_imgui_capture_item_t e3135;
            public sg_imgui_capture_item_t e3136;
            public sg_imgui_capture_item_t e3137;
            public sg_imgui_capture_item_t e3138;
            public sg_imgui_capture_item_t e3139;
            public sg_imgui_capture_item_t e3140;
            public sg_imgui_capture_item_t e3141;
            public sg_imgui_capture_item_t e3142;
            public sg_imgui_capture_item_t e3143;
            public sg_imgui_capture_item_t e3144;
            public sg_imgui_capture_item_t e3145;
            public sg_imgui_capture_item_t e3146;
            public sg_imgui_capture_item_t e3147;
            public sg_imgui_capture_item_t e3148;
            public sg_imgui_capture_item_t e3149;
            public sg_imgui_capture_item_t e3150;
            public sg_imgui_capture_item_t e3151;
            public sg_imgui_capture_item_t e3152;
            public sg_imgui_capture_item_t e3153;
            public sg_imgui_capture_item_t e3154;
            public sg_imgui_capture_item_t e3155;
            public sg_imgui_capture_item_t e3156;
            public sg_imgui_capture_item_t e3157;
            public sg_imgui_capture_item_t e3158;
            public sg_imgui_capture_item_t e3159;
            public sg_imgui_capture_item_t e3160;
            public sg_imgui_capture_item_t e3161;
            public sg_imgui_capture_item_t e3162;
            public sg_imgui_capture_item_t e3163;
            public sg_imgui_capture_item_t e3164;
            public sg_imgui_capture_item_t e3165;
            public sg_imgui_capture_item_t e3166;
            public sg_imgui_capture_item_t e3167;
            public sg_imgui_capture_item_t e3168;
            public sg_imgui_capture_item_t e3169;
            public sg_imgui_capture_item_t e3170;
            public sg_imgui_capture_item_t e3171;
            public sg_imgui_capture_item_t e3172;
            public sg_imgui_capture_item_t e3173;
            public sg_imgui_capture_item_t e3174;
            public sg_imgui_capture_item_t e3175;
            public sg_imgui_capture_item_t e3176;
            public sg_imgui_capture_item_t e3177;
            public sg_imgui_capture_item_t e3178;
            public sg_imgui_capture_item_t e3179;
            public sg_imgui_capture_item_t e3180;
            public sg_imgui_capture_item_t e3181;
            public sg_imgui_capture_item_t e3182;
            public sg_imgui_capture_item_t e3183;
            public sg_imgui_capture_item_t e3184;
            public sg_imgui_capture_item_t e3185;
            public sg_imgui_capture_item_t e3186;
            public sg_imgui_capture_item_t e3187;
            public sg_imgui_capture_item_t e3188;
            public sg_imgui_capture_item_t e3189;
            public sg_imgui_capture_item_t e3190;
            public sg_imgui_capture_item_t e3191;
            public sg_imgui_capture_item_t e3192;
            public sg_imgui_capture_item_t e3193;
            public sg_imgui_capture_item_t e3194;
            public sg_imgui_capture_item_t e3195;
            public sg_imgui_capture_item_t e3196;
            public sg_imgui_capture_item_t e3197;
            public sg_imgui_capture_item_t e3198;
            public sg_imgui_capture_item_t e3199;
            public sg_imgui_capture_item_t e3200;
            public sg_imgui_capture_item_t e3201;
            public sg_imgui_capture_item_t e3202;
            public sg_imgui_capture_item_t e3203;
            public sg_imgui_capture_item_t e3204;
            public sg_imgui_capture_item_t e3205;
            public sg_imgui_capture_item_t e3206;
            public sg_imgui_capture_item_t e3207;
            public sg_imgui_capture_item_t e3208;
            public sg_imgui_capture_item_t e3209;
            public sg_imgui_capture_item_t e3210;
            public sg_imgui_capture_item_t e3211;
            public sg_imgui_capture_item_t e3212;
            public sg_imgui_capture_item_t e3213;
            public sg_imgui_capture_item_t e3214;
            public sg_imgui_capture_item_t e3215;
            public sg_imgui_capture_item_t e3216;
            public sg_imgui_capture_item_t e3217;
            public sg_imgui_capture_item_t e3218;
            public sg_imgui_capture_item_t e3219;
            public sg_imgui_capture_item_t e3220;
            public sg_imgui_capture_item_t e3221;
            public sg_imgui_capture_item_t e3222;
            public sg_imgui_capture_item_t e3223;
            public sg_imgui_capture_item_t e3224;
            public sg_imgui_capture_item_t e3225;
            public sg_imgui_capture_item_t e3226;
            public sg_imgui_capture_item_t e3227;
            public sg_imgui_capture_item_t e3228;
            public sg_imgui_capture_item_t e3229;
            public sg_imgui_capture_item_t e3230;
            public sg_imgui_capture_item_t e3231;
            public sg_imgui_capture_item_t e3232;
            public sg_imgui_capture_item_t e3233;
            public sg_imgui_capture_item_t e3234;
            public sg_imgui_capture_item_t e3235;
            public sg_imgui_capture_item_t e3236;
            public sg_imgui_capture_item_t e3237;
            public sg_imgui_capture_item_t e3238;
            public sg_imgui_capture_item_t e3239;
            public sg_imgui_capture_item_t e3240;
            public sg_imgui_capture_item_t e3241;
            public sg_imgui_capture_item_t e3242;
            public sg_imgui_capture_item_t e3243;
            public sg_imgui_capture_item_t e3244;
            public sg_imgui_capture_item_t e3245;
            public sg_imgui_capture_item_t e3246;
            public sg_imgui_capture_item_t e3247;
            public sg_imgui_capture_item_t e3248;
            public sg_imgui_capture_item_t e3249;
            public sg_imgui_capture_item_t e3250;
            public sg_imgui_capture_item_t e3251;
            public sg_imgui_capture_item_t e3252;
            public sg_imgui_capture_item_t e3253;
            public sg_imgui_capture_item_t e3254;
            public sg_imgui_capture_item_t e3255;
            public sg_imgui_capture_item_t e3256;
            public sg_imgui_capture_item_t e3257;
            public sg_imgui_capture_item_t e3258;
            public sg_imgui_capture_item_t e3259;
            public sg_imgui_capture_item_t e3260;
            public sg_imgui_capture_item_t e3261;
            public sg_imgui_capture_item_t e3262;
            public sg_imgui_capture_item_t e3263;
            public sg_imgui_capture_item_t e3264;
            public sg_imgui_capture_item_t e3265;
            public sg_imgui_capture_item_t e3266;
            public sg_imgui_capture_item_t e3267;
            public sg_imgui_capture_item_t e3268;
            public sg_imgui_capture_item_t e3269;
            public sg_imgui_capture_item_t e3270;
            public sg_imgui_capture_item_t e3271;
            public sg_imgui_capture_item_t e3272;
            public sg_imgui_capture_item_t e3273;
            public sg_imgui_capture_item_t e3274;
            public sg_imgui_capture_item_t e3275;
            public sg_imgui_capture_item_t e3276;
            public sg_imgui_capture_item_t e3277;
            public sg_imgui_capture_item_t e3278;
            public sg_imgui_capture_item_t e3279;
            public sg_imgui_capture_item_t e3280;
            public sg_imgui_capture_item_t e3281;
            public sg_imgui_capture_item_t e3282;
            public sg_imgui_capture_item_t e3283;
            public sg_imgui_capture_item_t e3284;
            public sg_imgui_capture_item_t e3285;
            public sg_imgui_capture_item_t e3286;
            public sg_imgui_capture_item_t e3287;
            public sg_imgui_capture_item_t e3288;
            public sg_imgui_capture_item_t e3289;
            public sg_imgui_capture_item_t e3290;
            public sg_imgui_capture_item_t e3291;
            public sg_imgui_capture_item_t e3292;
            public sg_imgui_capture_item_t e3293;
            public sg_imgui_capture_item_t e3294;
            public sg_imgui_capture_item_t e3295;
            public sg_imgui_capture_item_t e3296;
            public sg_imgui_capture_item_t e3297;
            public sg_imgui_capture_item_t e3298;
            public sg_imgui_capture_item_t e3299;
            public sg_imgui_capture_item_t e3300;
            public sg_imgui_capture_item_t e3301;
            public sg_imgui_capture_item_t e3302;
            public sg_imgui_capture_item_t e3303;
            public sg_imgui_capture_item_t e3304;
            public sg_imgui_capture_item_t e3305;
            public sg_imgui_capture_item_t e3306;
            public sg_imgui_capture_item_t e3307;
            public sg_imgui_capture_item_t e3308;
            public sg_imgui_capture_item_t e3309;
            public sg_imgui_capture_item_t e3310;
            public sg_imgui_capture_item_t e3311;
            public sg_imgui_capture_item_t e3312;
            public sg_imgui_capture_item_t e3313;
            public sg_imgui_capture_item_t e3314;
            public sg_imgui_capture_item_t e3315;
            public sg_imgui_capture_item_t e3316;
            public sg_imgui_capture_item_t e3317;
            public sg_imgui_capture_item_t e3318;
            public sg_imgui_capture_item_t e3319;
            public sg_imgui_capture_item_t e3320;
            public sg_imgui_capture_item_t e3321;
            public sg_imgui_capture_item_t e3322;
            public sg_imgui_capture_item_t e3323;
            public sg_imgui_capture_item_t e3324;
            public sg_imgui_capture_item_t e3325;
            public sg_imgui_capture_item_t e3326;
            public sg_imgui_capture_item_t e3327;
            public sg_imgui_capture_item_t e3328;
            public sg_imgui_capture_item_t e3329;
            public sg_imgui_capture_item_t e3330;
            public sg_imgui_capture_item_t e3331;
            public sg_imgui_capture_item_t e3332;
            public sg_imgui_capture_item_t e3333;
            public sg_imgui_capture_item_t e3334;
            public sg_imgui_capture_item_t e3335;
            public sg_imgui_capture_item_t e3336;
            public sg_imgui_capture_item_t e3337;
            public sg_imgui_capture_item_t e3338;
            public sg_imgui_capture_item_t e3339;
            public sg_imgui_capture_item_t e3340;
            public sg_imgui_capture_item_t e3341;
            public sg_imgui_capture_item_t e3342;
            public sg_imgui_capture_item_t e3343;
            public sg_imgui_capture_item_t e3344;
            public sg_imgui_capture_item_t e3345;
            public sg_imgui_capture_item_t e3346;
            public sg_imgui_capture_item_t e3347;
            public sg_imgui_capture_item_t e3348;
            public sg_imgui_capture_item_t e3349;
            public sg_imgui_capture_item_t e3350;
            public sg_imgui_capture_item_t e3351;
            public sg_imgui_capture_item_t e3352;
            public sg_imgui_capture_item_t e3353;
            public sg_imgui_capture_item_t e3354;
            public sg_imgui_capture_item_t e3355;
            public sg_imgui_capture_item_t e3356;
            public sg_imgui_capture_item_t e3357;
            public sg_imgui_capture_item_t e3358;
            public sg_imgui_capture_item_t e3359;
            public sg_imgui_capture_item_t e3360;
            public sg_imgui_capture_item_t e3361;
            public sg_imgui_capture_item_t e3362;
            public sg_imgui_capture_item_t e3363;
            public sg_imgui_capture_item_t e3364;
            public sg_imgui_capture_item_t e3365;
            public sg_imgui_capture_item_t e3366;
            public sg_imgui_capture_item_t e3367;
            public sg_imgui_capture_item_t e3368;
            public sg_imgui_capture_item_t e3369;
            public sg_imgui_capture_item_t e3370;
            public sg_imgui_capture_item_t e3371;
            public sg_imgui_capture_item_t e3372;
            public sg_imgui_capture_item_t e3373;
            public sg_imgui_capture_item_t e3374;
            public sg_imgui_capture_item_t e3375;
            public sg_imgui_capture_item_t e3376;
            public sg_imgui_capture_item_t e3377;
            public sg_imgui_capture_item_t e3378;
            public sg_imgui_capture_item_t e3379;
            public sg_imgui_capture_item_t e3380;
            public sg_imgui_capture_item_t e3381;
            public sg_imgui_capture_item_t e3382;
            public sg_imgui_capture_item_t e3383;
            public sg_imgui_capture_item_t e3384;
            public sg_imgui_capture_item_t e3385;
            public sg_imgui_capture_item_t e3386;
            public sg_imgui_capture_item_t e3387;
            public sg_imgui_capture_item_t e3388;
            public sg_imgui_capture_item_t e3389;
            public sg_imgui_capture_item_t e3390;
            public sg_imgui_capture_item_t e3391;
            public sg_imgui_capture_item_t e3392;
            public sg_imgui_capture_item_t e3393;
            public sg_imgui_capture_item_t e3394;
            public sg_imgui_capture_item_t e3395;
            public sg_imgui_capture_item_t e3396;
            public sg_imgui_capture_item_t e3397;
            public sg_imgui_capture_item_t e3398;
            public sg_imgui_capture_item_t e3399;
            public sg_imgui_capture_item_t e3400;
            public sg_imgui_capture_item_t e3401;
            public sg_imgui_capture_item_t e3402;
            public sg_imgui_capture_item_t e3403;
            public sg_imgui_capture_item_t e3404;
            public sg_imgui_capture_item_t e3405;
            public sg_imgui_capture_item_t e3406;
            public sg_imgui_capture_item_t e3407;
            public sg_imgui_capture_item_t e3408;
            public sg_imgui_capture_item_t e3409;
            public sg_imgui_capture_item_t e3410;
            public sg_imgui_capture_item_t e3411;
            public sg_imgui_capture_item_t e3412;
            public sg_imgui_capture_item_t e3413;
            public sg_imgui_capture_item_t e3414;
            public sg_imgui_capture_item_t e3415;
            public sg_imgui_capture_item_t e3416;
            public sg_imgui_capture_item_t e3417;
            public sg_imgui_capture_item_t e3418;
            public sg_imgui_capture_item_t e3419;
            public sg_imgui_capture_item_t e3420;
            public sg_imgui_capture_item_t e3421;
            public sg_imgui_capture_item_t e3422;
            public sg_imgui_capture_item_t e3423;
            public sg_imgui_capture_item_t e3424;
            public sg_imgui_capture_item_t e3425;
            public sg_imgui_capture_item_t e3426;
            public sg_imgui_capture_item_t e3427;
            public sg_imgui_capture_item_t e3428;
            public sg_imgui_capture_item_t e3429;
            public sg_imgui_capture_item_t e3430;
            public sg_imgui_capture_item_t e3431;
            public sg_imgui_capture_item_t e3432;
            public sg_imgui_capture_item_t e3433;
            public sg_imgui_capture_item_t e3434;
            public sg_imgui_capture_item_t e3435;
            public sg_imgui_capture_item_t e3436;
            public sg_imgui_capture_item_t e3437;
            public sg_imgui_capture_item_t e3438;
            public sg_imgui_capture_item_t e3439;
            public sg_imgui_capture_item_t e3440;
            public sg_imgui_capture_item_t e3441;
            public sg_imgui_capture_item_t e3442;
            public sg_imgui_capture_item_t e3443;
            public sg_imgui_capture_item_t e3444;
            public sg_imgui_capture_item_t e3445;
            public sg_imgui_capture_item_t e3446;
            public sg_imgui_capture_item_t e3447;
            public sg_imgui_capture_item_t e3448;
            public sg_imgui_capture_item_t e3449;
            public sg_imgui_capture_item_t e3450;
            public sg_imgui_capture_item_t e3451;
            public sg_imgui_capture_item_t e3452;
            public sg_imgui_capture_item_t e3453;
            public sg_imgui_capture_item_t e3454;
            public sg_imgui_capture_item_t e3455;
            public sg_imgui_capture_item_t e3456;
            public sg_imgui_capture_item_t e3457;
            public sg_imgui_capture_item_t e3458;
            public sg_imgui_capture_item_t e3459;
            public sg_imgui_capture_item_t e3460;
            public sg_imgui_capture_item_t e3461;
            public sg_imgui_capture_item_t e3462;
            public sg_imgui_capture_item_t e3463;
            public sg_imgui_capture_item_t e3464;
            public sg_imgui_capture_item_t e3465;
            public sg_imgui_capture_item_t e3466;
            public sg_imgui_capture_item_t e3467;
            public sg_imgui_capture_item_t e3468;
            public sg_imgui_capture_item_t e3469;
            public sg_imgui_capture_item_t e3470;
            public sg_imgui_capture_item_t e3471;
            public sg_imgui_capture_item_t e3472;
            public sg_imgui_capture_item_t e3473;
            public sg_imgui_capture_item_t e3474;
            public sg_imgui_capture_item_t e3475;
            public sg_imgui_capture_item_t e3476;
            public sg_imgui_capture_item_t e3477;
            public sg_imgui_capture_item_t e3478;
            public sg_imgui_capture_item_t e3479;
            public sg_imgui_capture_item_t e3480;
            public sg_imgui_capture_item_t e3481;
            public sg_imgui_capture_item_t e3482;
            public sg_imgui_capture_item_t e3483;
            public sg_imgui_capture_item_t e3484;
            public sg_imgui_capture_item_t e3485;
            public sg_imgui_capture_item_t e3486;
            public sg_imgui_capture_item_t e3487;
            public sg_imgui_capture_item_t e3488;
            public sg_imgui_capture_item_t e3489;
            public sg_imgui_capture_item_t e3490;
            public sg_imgui_capture_item_t e3491;
            public sg_imgui_capture_item_t e3492;
            public sg_imgui_capture_item_t e3493;
            public sg_imgui_capture_item_t e3494;
            public sg_imgui_capture_item_t e3495;
            public sg_imgui_capture_item_t e3496;
            public sg_imgui_capture_item_t e3497;
            public sg_imgui_capture_item_t e3498;
            public sg_imgui_capture_item_t e3499;
            public sg_imgui_capture_item_t e3500;
            public sg_imgui_capture_item_t e3501;
            public sg_imgui_capture_item_t e3502;
            public sg_imgui_capture_item_t e3503;
            public sg_imgui_capture_item_t e3504;
            public sg_imgui_capture_item_t e3505;
            public sg_imgui_capture_item_t e3506;
            public sg_imgui_capture_item_t e3507;
            public sg_imgui_capture_item_t e3508;
            public sg_imgui_capture_item_t e3509;
            public sg_imgui_capture_item_t e3510;
            public sg_imgui_capture_item_t e3511;
            public sg_imgui_capture_item_t e3512;
            public sg_imgui_capture_item_t e3513;
            public sg_imgui_capture_item_t e3514;
            public sg_imgui_capture_item_t e3515;
            public sg_imgui_capture_item_t e3516;
            public sg_imgui_capture_item_t e3517;
            public sg_imgui_capture_item_t e3518;
            public sg_imgui_capture_item_t e3519;
            public sg_imgui_capture_item_t e3520;
            public sg_imgui_capture_item_t e3521;
            public sg_imgui_capture_item_t e3522;
            public sg_imgui_capture_item_t e3523;
            public sg_imgui_capture_item_t e3524;
            public sg_imgui_capture_item_t e3525;
            public sg_imgui_capture_item_t e3526;
            public sg_imgui_capture_item_t e3527;
            public sg_imgui_capture_item_t e3528;
            public sg_imgui_capture_item_t e3529;
            public sg_imgui_capture_item_t e3530;
            public sg_imgui_capture_item_t e3531;
            public sg_imgui_capture_item_t e3532;
            public sg_imgui_capture_item_t e3533;
            public sg_imgui_capture_item_t e3534;
            public sg_imgui_capture_item_t e3535;
            public sg_imgui_capture_item_t e3536;
            public sg_imgui_capture_item_t e3537;
            public sg_imgui_capture_item_t e3538;
            public sg_imgui_capture_item_t e3539;
            public sg_imgui_capture_item_t e3540;
            public sg_imgui_capture_item_t e3541;
            public sg_imgui_capture_item_t e3542;
            public sg_imgui_capture_item_t e3543;
            public sg_imgui_capture_item_t e3544;
            public sg_imgui_capture_item_t e3545;
            public sg_imgui_capture_item_t e3546;
            public sg_imgui_capture_item_t e3547;
            public sg_imgui_capture_item_t e3548;
            public sg_imgui_capture_item_t e3549;
            public sg_imgui_capture_item_t e3550;
            public sg_imgui_capture_item_t e3551;
            public sg_imgui_capture_item_t e3552;
            public sg_imgui_capture_item_t e3553;
            public sg_imgui_capture_item_t e3554;
            public sg_imgui_capture_item_t e3555;
            public sg_imgui_capture_item_t e3556;
            public sg_imgui_capture_item_t e3557;
            public sg_imgui_capture_item_t e3558;
            public sg_imgui_capture_item_t e3559;
            public sg_imgui_capture_item_t e3560;
            public sg_imgui_capture_item_t e3561;
            public sg_imgui_capture_item_t e3562;
            public sg_imgui_capture_item_t e3563;
            public sg_imgui_capture_item_t e3564;
            public sg_imgui_capture_item_t e3565;
            public sg_imgui_capture_item_t e3566;
            public sg_imgui_capture_item_t e3567;
            public sg_imgui_capture_item_t e3568;
            public sg_imgui_capture_item_t e3569;
            public sg_imgui_capture_item_t e3570;
            public sg_imgui_capture_item_t e3571;
            public sg_imgui_capture_item_t e3572;
            public sg_imgui_capture_item_t e3573;
            public sg_imgui_capture_item_t e3574;
            public sg_imgui_capture_item_t e3575;
            public sg_imgui_capture_item_t e3576;
            public sg_imgui_capture_item_t e3577;
            public sg_imgui_capture_item_t e3578;
            public sg_imgui_capture_item_t e3579;
            public sg_imgui_capture_item_t e3580;
            public sg_imgui_capture_item_t e3581;
            public sg_imgui_capture_item_t e3582;
            public sg_imgui_capture_item_t e3583;
            public sg_imgui_capture_item_t e3584;
            public sg_imgui_capture_item_t e3585;
            public sg_imgui_capture_item_t e3586;
            public sg_imgui_capture_item_t e3587;
            public sg_imgui_capture_item_t e3588;
            public sg_imgui_capture_item_t e3589;
            public sg_imgui_capture_item_t e3590;
            public sg_imgui_capture_item_t e3591;
            public sg_imgui_capture_item_t e3592;
            public sg_imgui_capture_item_t e3593;
            public sg_imgui_capture_item_t e3594;
            public sg_imgui_capture_item_t e3595;
            public sg_imgui_capture_item_t e3596;
            public sg_imgui_capture_item_t e3597;
            public sg_imgui_capture_item_t e3598;
            public sg_imgui_capture_item_t e3599;
            public sg_imgui_capture_item_t e3600;
            public sg_imgui_capture_item_t e3601;
            public sg_imgui_capture_item_t e3602;
            public sg_imgui_capture_item_t e3603;
            public sg_imgui_capture_item_t e3604;
            public sg_imgui_capture_item_t e3605;
            public sg_imgui_capture_item_t e3606;
            public sg_imgui_capture_item_t e3607;
            public sg_imgui_capture_item_t e3608;
            public sg_imgui_capture_item_t e3609;
            public sg_imgui_capture_item_t e3610;
            public sg_imgui_capture_item_t e3611;
            public sg_imgui_capture_item_t e3612;
            public sg_imgui_capture_item_t e3613;
            public sg_imgui_capture_item_t e3614;
            public sg_imgui_capture_item_t e3615;
            public sg_imgui_capture_item_t e3616;
            public sg_imgui_capture_item_t e3617;
            public sg_imgui_capture_item_t e3618;
            public sg_imgui_capture_item_t e3619;
            public sg_imgui_capture_item_t e3620;
            public sg_imgui_capture_item_t e3621;
            public sg_imgui_capture_item_t e3622;
            public sg_imgui_capture_item_t e3623;
            public sg_imgui_capture_item_t e3624;
            public sg_imgui_capture_item_t e3625;
            public sg_imgui_capture_item_t e3626;
            public sg_imgui_capture_item_t e3627;
            public sg_imgui_capture_item_t e3628;
            public sg_imgui_capture_item_t e3629;
            public sg_imgui_capture_item_t e3630;
            public sg_imgui_capture_item_t e3631;
            public sg_imgui_capture_item_t e3632;
            public sg_imgui_capture_item_t e3633;
            public sg_imgui_capture_item_t e3634;
            public sg_imgui_capture_item_t e3635;
            public sg_imgui_capture_item_t e3636;
            public sg_imgui_capture_item_t e3637;
            public sg_imgui_capture_item_t e3638;
            public sg_imgui_capture_item_t e3639;
            public sg_imgui_capture_item_t e3640;
            public sg_imgui_capture_item_t e3641;
            public sg_imgui_capture_item_t e3642;
            public sg_imgui_capture_item_t e3643;
            public sg_imgui_capture_item_t e3644;
            public sg_imgui_capture_item_t e3645;
            public sg_imgui_capture_item_t e3646;
            public sg_imgui_capture_item_t e3647;
            public sg_imgui_capture_item_t e3648;
            public sg_imgui_capture_item_t e3649;
            public sg_imgui_capture_item_t e3650;
            public sg_imgui_capture_item_t e3651;
            public sg_imgui_capture_item_t e3652;
            public sg_imgui_capture_item_t e3653;
            public sg_imgui_capture_item_t e3654;
            public sg_imgui_capture_item_t e3655;
            public sg_imgui_capture_item_t e3656;
            public sg_imgui_capture_item_t e3657;
            public sg_imgui_capture_item_t e3658;
            public sg_imgui_capture_item_t e3659;
            public sg_imgui_capture_item_t e3660;
            public sg_imgui_capture_item_t e3661;
            public sg_imgui_capture_item_t e3662;
            public sg_imgui_capture_item_t e3663;
            public sg_imgui_capture_item_t e3664;
            public sg_imgui_capture_item_t e3665;
            public sg_imgui_capture_item_t e3666;
            public sg_imgui_capture_item_t e3667;
            public sg_imgui_capture_item_t e3668;
            public sg_imgui_capture_item_t e3669;
            public sg_imgui_capture_item_t e3670;
            public sg_imgui_capture_item_t e3671;
            public sg_imgui_capture_item_t e3672;
            public sg_imgui_capture_item_t e3673;
            public sg_imgui_capture_item_t e3674;
            public sg_imgui_capture_item_t e3675;
            public sg_imgui_capture_item_t e3676;
            public sg_imgui_capture_item_t e3677;
            public sg_imgui_capture_item_t e3678;
            public sg_imgui_capture_item_t e3679;
            public sg_imgui_capture_item_t e3680;
            public sg_imgui_capture_item_t e3681;
            public sg_imgui_capture_item_t e3682;
            public sg_imgui_capture_item_t e3683;
            public sg_imgui_capture_item_t e3684;
            public sg_imgui_capture_item_t e3685;
            public sg_imgui_capture_item_t e3686;
            public sg_imgui_capture_item_t e3687;
            public sg_imgui_capture_item_t e3688;
            public sg_imgui_capture_item_t e3689;
            public sg_imgui_capture_item_t e3690;
            public sg_imgui_capture_item_t e3691;
            public sg_imgui_capture_item_t e3692;
            public sg_imgui_capture_item_t e3693;
            public sg_imgui_capture_item_t e3694;
            public sg_imgui_capture_item_t e3695;
            public sg_imgui_capture_item_t e3696;
            public sg_imgui_capture_item_t e3697;
            public sg_imgui_capture_item_t e3698;
            public sg_imgui_capture_item_t e3699;
            public sg_imgui_capture_item_t e3700;
            public sg_imgui_capture_item_t e3701;
            public sg_imgui_capture_item_t e3702;
            public sg_imgui_capture_item_t e3703;
            public sg_imgui_capture_item_t e3704;
            public sg_imgui_capture_item_t e3705;
            public sg_imgui_capture_item_t e3706;
            public sg_imgui_capture_item_t e3707;
            public sg_imgui_capture_item_t e3708;
            public sg_imgui_capture_item_t e3709;
            public sg_imgui_capture_item_t e3710;
            public sg_imgui_capture_item_t e3711;
            public sg_imgui_capture_item_t e3712;
            public sg_imgui_capture_item_t e3713;
            public sg_imgui_capture_item_t e3714;
            public sg_imgui_capture_item_t e3715;
            public sg_imgui_capture_item_t e3716;
            public sg_imgui_capture_item_t e3717;
            public sg_imgui_capture_item_t e3718;
            public sg_imgui_capture_item_t e3719;
            public sg_imgui_capture_item_t e3720;
            public sg_imgui_capture_item_t e3721;
            public sg_imgui_capture_item_t e3722;
            public sg_imgui_capture_item_t e3723;
            public sg_imgui_capture_item_t e3724;
            public sg_imgui_capture_item_t e3725;
            public sg_imgui_capture_item_t e3726;
            public sg_imgui_capture_item_t e3727;
            public sg_imgui_capture_item_t e3728;
            public sg_imgui_capture_item_t e3729;
            public sg_imgui_capture_item_t e3730;
            public sg_imgui_capture_item_t e3731;
            public sg_imgui_capture_item_t e3732;
            public sg_imgui_capture_item_t e3733;
            public sg_imgui_capture_item_t e3734;
            public sg_imgui_capture_item_t e3735;
            public sg_imgui_capture_item_t e3736;
            public sg_imgui_capture_item_t e3737;
            public sg_imgui_capture_item_t e3738;
            public sg_imgui_capture_item_t e3739;
            public sg_imgui_capture_item_t e3740;
            public sg_imgui_capture_item_t e3741;
            public sg_imgui_capture_item_t e3742;
            public sg_imgui_capture_item_t e3743;
            public sg_imgui_capture_item_t e3744;
            public sg_imgui_capture_item_t e3745;
            public sg_imgui_capture_item_t e3746;
            public sg_imgui_capture_item_t e3747;
            public sg_imgui_capture_item_t e3748;
            public sg_imgui_capture_item_t e3749;
            public sg_imgui_capture_item_t e3750;
            public sg_imgui_capture_item_t e3751;
            public sg_imgui_capture_item_t e3752;
            public sg_imgui_capture_item_t e3753;
            public sg_imgui_capture_item_t e3754;
            public sg_imgui_capture_item_t e3755;
            public sg_imgui_capture_item_t e3756;
            public sg_imgui_capture_item_t e3757;
            public sg_imgui_capture_item_t e3758;
            public sg_imgui_capture_item_t e3759;
            public sg_imgui_capture_item_t e3760;
            public sg_imgui_capture_item_t e3761;
            public sg_imgui_capture_item_t e3762;
            public sg_imgui_capture_item_t e3763;
            public sg_imgui_capture_item_t e3764;
            public sg_imgui_capture_item_t e3765;
            public sg_imgui_capture_item_t e3766;
            public sg_imgui_capture_item_t e3767;
            public sg_imgui_capture_item_t e3768;
            public sg_imgui_capture_item_t e3769;
            public sg_imgui_capture_item_t e3770;
            public sg_imgui_capture_item_t e3771;
            public sg_imgui_capture_item_t e3772;
            public sg_imgui_capture_item_t e3773;
            public sg_imgui_capture_item_t e3774;
            public sg_imgui_capture_item_t e3775;
            public sg_imgui_capture_item_t e3776;
            public sg_imgui_capture_item_t e3777;
            public sg_imgui_capture_item_t e3778;
            public sg_imgui_capture_item_t e3779;
            public sg_imgui_capture_item_t e3780;
            public sg_imgui_capture_item_t e3781;
            public sg_imgui_capture_item_t e3782;
            public sg_imgui_capture_item_t e3783;
            public sg_imgui_capture_item_t e3784;
            public sg_imgui_capture_item_t e3785;
            public sg_imgui_capture_item_t e3786;
            public sg_imgui_capture_item_t e3787;
            public sg_imgui_capture_item_t e3788;
            public sg_imgui_capture_item_t e3789;
            public sg_imgui_capture_item_t e3790;
            public sg_imgui_capture_item_t e3791;
            public sg_imgui_capture_item_t e3792;
            public sg_imgui_capture_item_t e3793;
            public sg_imgui_capture_item_t e3794;
            public sg_imgui_capture_item_t e3795;
            public sg_imgui_capture_item_t e3796;
            public sg_imgui_capture_item_t e3797;
            public sg_imgui_capture_item_t e3798;
            public sg_imgui_capture_item_t e3799;
            public sg_imgui_capture_item_t e3800;
            public sg_imgui_capture_item_t e3801;
            public sg_imgui_capture_item_t e3802;
            public sg_imgui_capture_item_t e3803;
            public sg_imgui_capture_item_t e3804;
            public sg_imgui_capture_item_t e3805;
            public sg_imgui_capture_item_t e3806;
            public sg_imgui_capture_item_t e3807;
            public sg_imgui_capture_item_t e3808;
            public sg_imgui_capture_item_t e3809;
            public sg_imgui_capture_item_t e3810;
            public sg_imgui_capture_item_t e3811;
            public sg_imgui_capture_item_t e3812;
            public sg_imgui_capture_item_t e3813;
            public sg_imgui_capture_item_t e3814;
            public sg_imgui_capture_item_t e3815;
            public sg_imgui_capture_item_t e3816;
            public sg_imgui_capture_item_t e3817;
            public sg_imgui_capture_item_t e3818;
            public sg_imgui_capture_item_t e3819;
            public sg_imgui_capture_item_t e3820;
            public sg_imgui_capture_item_t e3821;
            public sg_imgui_capture_item_t e3822;
            public sg_imgui_capture_item_t e3823;
            public sg_imgui_capture_item_t e3824;
            public sg_imgui_capture_item_t e3825;
            public sg_imgui_capture_item_t e3826;
            public sg_imgui_capture_item_t e3827;
            public sg_imgui_capture_item_t e3828;
            public sg_imgui_capture_item_t e3829;
            public sg_imgui_capture_item_t e3830;
            public sg_imgui_capture_item_t e3831;
            public sg_imgui_capture_item_t e3832;
            public sg_imgui_capture_item_t e3833;
            public sg_imgui_capture_item_t e3834;
            public sg_imgui_capture_item_t e3835;
            public sg_imgui_capture_item_t e3836;
            public sg_imgui_capture_item_t e3837;
            public sg_imgui_capture_item_t e3838;
            public sg_imgui_capture_item_t e3839;
            public sg_imgui_capture_item_t e3840;
            public sg_imgui_capture_item_t e3841;
            public sg_imgui_capture_item_t e3842;
            public sg_imgui_capture_item_t e3843;
            public sg_imgui_capture_item_t e3844;
            public sg_imgui_capture_item_t e3845;
            public sg_imgui_capture_item_t e3846;
            public sg_imgui_capture_item_t e3847;
            public sg_imgui_capture_item_t e3848;
            public sg_imgui_capture_item_t e3849;
            public sg_imgui_capture_item_t e3850;
            public sg_imgui_capture_item_t e3851;
            public sg_imgui_capture_item_t e3852;
            public sg_imgui_capture_item_t e3853;
            public sg_imgui_capture_item_t e3854;
            public sg_imgui_capture_item_t e3855;
            public sg_imgui_capture_item_t e3856;
            public sg_imgui_capture_item_t e3857;
            public sg_imgui_capture_item_t e3858;
            public sg_imgui_capture_item_t e3859;
            public sg_imgui_capture_item_t e3860;
            public sg_imgui_capture_item_t e3861;
            public sg_imgui_capture_item_t e3862;
            public sg_imgui_capture_item_t e3863;
            public sg_imgui_capture_item_t e3864;
            public sg_imgui_capture_item_t e3865;
            public sg_imgui_capture_item_t e3866;
            public sg_imgui_capture_item_t e3867;
            public sg_imgui_capture_item_t e3868;
            public sg_imgui_capture_item_t e3869;
            public sg_imgui_capture_item_t e3870;
            public sg_imgui_capture_item_t e3871;
            public sg_imgui_capture_item_t e3872;
            public sg_imgui_capture_item_t e3873;
            public sg_imgui_capture_item_t e3874;
            public sg_imgui_capture_item_t e3875;
            public sg_imgui_capture_item_t e3876;
            public sg_imgui_capture_item_t e3877;
            public sg_imgui_capture_item_t e3878;
            public sg_imgui_capture_item_t e3879;
            public sg_imgui_capture_item_t e3880;
            public sg_imgui_capture_item_t e3881;
            public sg_imgui_capture_item_t e3882;
            public sg_imgui_capture_item_t e3883;
            public sg_imgui_capture_item_t e3884;
            public sg_imgui_capture_item_t e3885;
            public sg_imgui_capture_item_t e3886;
            public sg_imgui_capture_item_t e3887;
            public sg_imgui_capture_item_t e3888;
            public sg_imgui_capture_item_t e3889;
            public sg_imgui_capture_item_t e3890;
            public sg_imgui_capture_item_t e3891;
            public sg_imgui_capture_item_t e3892;
            public sg_imgui_capture_item_t e3893;
            public sg_imgui_capture_item_t e3894;
            public sg_imgui_capture_item_t e3895;
            public sg_imgui_capture_item_t e3896;
            public sg_imgui_capture_item_t e3897;
            public sg_imgui_capture_item_t e3898;
            public sg_imgui_capture_item_t e3899;
            public sg_imgui_capture_item_t e3900;
            public sg_imgui_capture_item_t e3901;
            public sg_imgui_capture_item_t e3902;
            public sg_imgui_capture_item_t e3903;
            public sg_imgui_capture_item_t e3904;
            public sg_imgui_capture_item_t e3905;
            public sg_imgui_capture_item_t e3906;
            public sg_imgui_capture_item_t e3907;
            public sg_imgui_capture_item_t e3908;
            public sg_imgui_capture_item_t e3909;
            public sg_imgui_capture_item_t e3910;
            public sg_imgui_capture_item_t e3911;
            public sg_imgui_capture_item_t e3912;
            public sg_imgui_capture_item_t e3913;
            public sg_imgui_capture_item_t e3914;
            public sg_imgui_capture_item_t e3915;
            public sg_imgui_capture_item_t e3916;
            public sg_imgui_capture_item_t e3917;
            public sg_imgui_capture_item_t e3918;
            public sg_imgui_capture_item_t e3919;
            public sg_imgui_capture_item_t e3920;
            public sg_imgui_capture_item_t e3921;
            public sg_imgui_capture_item_t e3922;
            public sg_imgui_capture_item_t e3923;
            public sg_imgui_capture_item_t e3924;
            public sg_imgui_capture_item_t e3925;
            public sg_imgui_capture_item_t e3926;
            public sg_imgui_capture_item_t e3927;
            public sg_imgui_capture_item_t e3928;
            public sg_imgui_capture_item_t e3929;
            public sg_imgui_capture_item_t e3930;
            public sg_imgui_capture_item_t e3931;
            public sg_imgui_capture_item_t e3932;
            public sg_imgui_capture_item_t e3933;
            public sg_imgui_capture_item_t e3934;
            public sg_imgui_capture_item_t e3935;
            public sg_imgui_capture_item_t e3936;
            public sg_imgui_capture_item_t e3937;
            public sg_imgui_capture_item_t e3938;
            public sg_imgui_capture_item_t e3939;
            public sg_imgui_capture_item_t e3940;
            public sg_imgui_capture_item_t e3941;
            public sg_imgui_capture_item_t e3942;
            public sg_imgui_capture_item_t e3943;
            public sg_imgui_capture_item_t e3944;
            public sg_imgui_capture_item_t e3945;
            public sg_imgui_capture_item_t e3946;
            public sg_imgui_capture_item_t e3947;
            public sg_imgui_capture_item_t e3948;
            public sg_imgui_capture_item_t e3949;
            public sg_imgui_capture_item_t e3950;
            public sg_imgui_capture_item_t e3951;
            public sg_imgui_capture_item_t e3952;
            public sg_imgui_capture_item_t e3953;
            public sg_imgui_capture_item_t e3954;
            public sg_imgui_capture_item_t e3955;
            public sg_imgui_capture_item_t e3956;
            public sg_imgui_capture_item_t e3957;
            public sg_imgui_capture_item_t e3958;
            public sg_imgui_capture_item_t e3959;
            public sg_imgui_capture_item_t e3960;
            public sg_imgui_capture_item_t e3961;
            public sg_imgui_capture_item_t e3962;
            public sg_imgui_capture_item_t e3963;
            public sg_imgui_capture_item_t e3964;
            public sg_imgui_capture_item_t e3965;
            public sg_imgui_capture_item_t e3966;
            public sg_imgui_capture_item_t e3967;
            public sg_imgui_capture_item_t e3968;
            public sg_imgui_capture_item_t e3969;
            public sg_imgui_capture_item_t e3970;
            public sg_imgui_capture_item_t e3971;
            public sg_imgui_capture_item_t e3972;
            public sg_imgui_capture_item_t e3973;
            public sg_imgui_capture_item_t e3974;
            public sg_imgui_capture_item_t e3975;
            public sg_imgui_capture_item_t e3976;
            public sg_imgui_capture_item_t e3977;
            public sg_imgui_capture_item_t e3978;
            public sg_imgui_capture_item_t e3979;
            public sg_imgui_capture_item_t e3980;
            public sg_imgui_capture_item_t e3981;
            public sg_imgui_capture_item_t e3982;
            public sg_imgui_capture_item_t e3983;
            public sg_imgui_capture_item_t e3984;
            public sg_imgui_capture_item_t e3985;
            public sg_imgui_capture_item_t e3986;
            public sg_imgui_capture_item_t e3987;
            public sg_imgui_capture_item_t e3988;
            public sg_imgui_capture_item_t e3989;
            public sg_imgui_capture_item_t e3990;
            public sg_imgui_capture_item_t e3991;
            public sg_imgui_capture_item_t e3992;
            public sg_imgui_capture_item_t e3993;
            public sg_imgui_capture_item_t e3994;
            public sg_imgui_capture_item_t e3995;
            public sg_imgui_capture_item_t e3996;
            public sg_imgui_capture_item_t e3997;
            public sg_imgui_capture_item_t e3998;
            public sg_imgui_capture_item_t e3999;
            public sg_imgui_capture_item_t e4000;
            public sg_imgui_capture_item_t e4001;
            public sg_imgui_capture_item_t e4002;
            public sg_imgui_capture_item_t e4003;
            public sg_imgui_capture_item_t e4004;
            public sg_imgui_capture_item_t e4005;
            public sg_imgui_capture_item_t e4006;
            public sg_imgui_capture_item_t e4007;
            public sg_imgui_capture_item_t e4008;
            public sg_imgui_capture_item_t e4009;
            public sg_imgui_capture_item_t e4010;
            public sg_imgui_capture_item_t e4011;
            public sg_imgui_capture_item_t e4012;
            public sg_imgui_capture_item_t e4013;
            public sg_imgui_capture_item_t e4014;
            public sg_imgui_capture_item_t e4015;
            public sg_imgui_capture_item_t e4016;
            public sg_imgui_capture_item_t e4017;
            public sg_imgui_capture_item_t e4018;
            public sg_imgui_capture_item_t e4019;
            public sg_imgui_capture_item_t e4020;
            public sg_imgui_capture_item_t e4021;
            public sg_imgui_capture_item_t e4022;
            public sg_imgui_capture_item_t e4023;
            public sg_imgui_capture_item_t e4024;
            public sg_imgui_capture_item_t e4025;
            public sg_imgui_capture_item_t e4026;
            public sg_imgui_capture_item_t e4027;
            public sg_imgui_capture_item_t e4028;
            public sg_imgui_capture_item_t e4029;
            public sg_imgui_capture_item_t e4030;
            public sg_imgui_capture_item_t e4031;
            public sg_imgui_capture_item_t e4032;
            public sg_imgui_capture_item_t e4033;
            public sg_imgui_capture_item_t e4034;
            public sg_imgui_capture_item_t e4035;
            public sg_imgui_capture_item_t e4036;
            public sg_imgui_capture_item_t e4037;
            public sg_imgui_capture_item_t e4038;
            public sg_imgui_capture_item_t e4039;
            public sg_imgui_capture_item_t e4040;
            public sg_imgui_capture_item_t e4041;
            public sg_imgui_capture_item_t e4042;
            public sg_imgui_capture_item_t e4043;
            public sg_imgui_capture_item_t e4044;
            public sg_imgui_capture_item_t e4045;
            public sg_imgui_capture_item_t e4046;
            public sg_imgui_capture_item_t e4047;
            public sg_imgui_capture_item_t e4048;
            public sg_imgui_capture_item_t e4049;
            public sg_imgui_capture_item_t e4050;
            public sg_imgui_capture_item_t e4051;
            public sg_imgui_capture_item_t e4052;
            public sg_imgui_capture_item_t e4053;
            public sg_imgui_capture_item_t e4054;
            public sg_imgui_capture_item_t e4055;
            public sg_imgui_capture_item_t e4056;
            public sg_imgui_capture_item_t e4057;
            public sg_imgui_capture_item_t e4058;
            public sg_imgui_capture_item_t e4059;
            public sg_imgui_capture_item_t e4060;
            public sg_imgui_capture_item_t e4061;
            public sg_imgui_capture_item_t e4062;
            public sg_imgui_capture_item_t e4063;
            public sg_imgui_capture_item_t e4064;
            public sg_imgui_capture_item_t e4065;
            public sg_imgui_capture_item_t e4066;
            public sg_imgui_capture_item_t e4067;
            public sg_imgui_capture_item_t e4068;
            public sg_imgui_capture_item_t e4069;
            public sg_imgui_capture_item_t e4070;
            public sg_imgui_capture_item_t e4071;
            public sg_imgui_capture_item_t e4072;
            public sg_imgui_capture_item_t e4073;
            public sg_imgui_capture_item_t e4074;
            public sg_imgui_capture_item_t e4075;
            public sg_imgui_capture_item_t e4076;
            public sg_imgui_capture_item_t e4077;
            public sg_imgui_capture_item_t e4078;
            public sg_imgui_capture_item_t e4079;
            public sg_imgui_capture_item_t e4080;
            public sg_imgui_capture_item_t e4081;
            public sg_imgui_capture_item_t e4082;
            public sg_imgui_capture_item_t e4083;
            public sg_imgui_capture_item_t e4084;
            public sg_imgui_capture_item_t e4085;
            public sg_imgui_capture_item_t e4086;
            public sg_imgui_capture_item_t e4087;
            public sg_imgui_capture_item_t e4088;
            public sg_imgui_capture_item_t e4089;
            public sg_imgui_capture_item_t e4090;
            public sg_imgui_capture_item_t e4091;
            public sg_imgui_capture_item_t e4092;
            public sg_imgui_capture_item_t e4093;
            public sg_imgui_capture_item_t e4094;
            public sg_imgui_capture_item_t e4095;

            [UnscopedRef]
            public ref sg_imgui_capture_item_t this[int index]
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get
                {
                    return ref AsSpan()[index];
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [UnscopedRef]
            public Span<sg_imgui_capture_item_t> AsSpan() => MemoryMarshal.CreateSpan(ref e0, 4096);
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

        public partial struct _bucket_e__FixedBuffer
        {
            public sg_imgui_capture_bucket_t e0;
            public sg_imgui_capture_bucket_t e1;

            [UnscopedRef]
            public ref sg_imgui_capture_bucket_t this[int index]
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get
                {
                    return ref AsSpan()[index];
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [UnscopedRef]
            public Span<sg_imgui_capture_bucket_t> AsSpan() => MemoryMarshal.CreateSpan(ref e0, 2);
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
