using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Dinghy.Internal.Sokol;

public enum sgp_error
{
    SGP_NO_ERROR = 0,
    SGP_ERROR_SOKOL_INVALID,
    SGP_ERROR_VERTICES_FULL,
    SGP_ERROR_UNIFORMS_FULL,
    SGP_ERROR_COMMANDS_FULL,
    SGP_ERROR_VERTICES_OVERFLOW,
    SGP_ERROR_TRANSFORM_STACK_OVERFLOW,
    SGP_ERROR_TRANSFORM_STACK_UNDERFLOW,
    SGP_ERROR_STATE_STACK_OVERFLOW,
    SGP_ERROR_STATE_STACK_UNDERFLOW,
    SGP_ERROR_ALLOC_FAILED,
    SGP_ERROR_MAKE_VERTEX_BUFFER_FAILED,
    SGP_ERROR_MAKE_WHITE_IMAGE_FAILED,
    SGP_ERROR_MAKE_NEAREST_SAMPLER_FAILED,
    SGP_ERROR_MAKE_COMMON_SHADER_FAILED,
    SGP_ERROR_MAKE_COMMON_PIPELINE_FAILED,
}

    public enum sgp_blend_mode
    {
        SGP_BLENDMODE_NONE = 0,
        SGP_BLENDMODE_BLEND,
        SGP_BLENDMODE_ADD,
        SGP_BLENDMODE_MOD,
        SGP_BLENDMODE_MUL,
        _SGP_BLENDMODE_NUM,
    }

    public partial struct sgp_isize
    {
        public int w;

        public int h;
    }

    public partial struct sgp_irect
    {
        public int x;

        public int y;

        public int w;

        public int h;
    }

    public partial struct sgp_rect
    {
        public float x;

        public float y;

        public float w;

        public float h;
    }

    public partial struct sgp_textured_rect
    {
        public sgp_rect dst;

        public sgp_rect src;
    }

    public partial struct sgp_vec2
    {
        public float x;

        public float y;
    }

    public partial struct sgp_line
    {
        [NativeTypeName("sgp_point")]
        public sgp_vec2 a;

        [NativeTypeName("sgp_point")]
        public sgp_vec2 b;
    }

    public partial struct sgp_triangle
    {
        [NativeTypeName("sgp_point")]
        public sgp_vec2 a;

        [NativeTypeName("sgp_point")]
        public sgp_vec2 b;

        [NativeTypeName("sgp_point")]
        public sgp_vec2 c;
    }

    public unsafe partial struct sgp_mat2x3
    {
        [NativeTypeName("float[2][3]")]
        public fixed float v[2 * 3];
    }

    public partial struct sgp_color
    {
        public float r;

        public float g;

        public float b;

        public float a;
    }

    public unsafe partial struct sgp_uniform
    {
        [NativeTypeName("uint32_t")]
        public uint size;

        [NativeTypeName("float[4]")]
        public fixed float content[4];
    }

    public partial struct sgp_textures_uniform
    {
        [NativeTypeName("uint32_t")]
        public uint count;

        [NativeTypeName("sg_image[4]")]
        public _images_e__FixedBuffer images;

        [NativeTypeName("sg_sampler[4]")]
        public _samplers_e__FixedBuffer samplers;

        public partial struct _images_e__FixedBuffer
        {
            public sg_image e0;
            public sg_image e1;
            public sg_image e2;
            public sg_image e3;

            [UnscopedRef]
            public ref sg_image this[int index]
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get
                {
                    return ref AsSpan()[index];
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [UnscopedRef]
            public Span<sg_image> AsSpan() => MemoryMarshal.CreateSpan(ref e0, 4);
        }

        public partial struct _samplers_e__FixedBuffer
        {
            public sg_sampler e0;
            public sg_sampler e1;
            public sg_sampler e2;
            public sg_sampler e3;

            [UnscopedRef]
            public ref sg_sampler this[int index]
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get
                {
                    return ref AsSpan()[index];
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [UnscopedRef]
            public Span<sg_sampler> AsSpan() => MemoryMarshal.CreateSpan(ref e0, 4);
        }
    }

    public partial struct sgp_state
    {
        public sgp_isize frame_size;

        public sgp_irect viewport;

        public sgp_irect scissor;

        public sgp_mat2x3 proj;

        public sgp_mat2x3 transform;

        public sgp_mat2x3 mvp;

        public float thickness;

        public sgp_color color;

        public sgp_textures_uniform textures;

        public sgp_uniform uniform;

        public sgp_blend_mode blend_mode;

        public sg_pipeline pipeline;

        [NativeTypeName("uint32_t")]
        public uint _base_vertex;

        [NativeTypeName("uint32_t")]
        public uint _base_uniform;

        [NativeTypeName("uint32_t")]
        public uint _base_command;
    }

    public partial struct sgp_desc
    {
        [NativeTypeName("uint32_t")]
        public uint max_vertices;

        [NativeTypeName("uint32_t")]
        public uint max_commands;

        public sg_pixel_format pixel_format;
    }

    public partial struct sgp_pipeline_desc
    {
        public sg_shader_desc shader;

        public sg_primitive_type primitive_type;

        public sgp_blend_mode blend_mode;

        public sg_pixel_format pixel_format;
    }

    public static unsafe partial class GP
    {
        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void sgp_setup([NativeTypeName("const sgp_desc *")] sgp_desc* desc);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void sgp_shutdown();

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("bool")]
        public static extern byte sgp_is_valid();

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern sgp_error sgp_get_last_error();

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* sgp_get_error_message(sgp_error error);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern sg_pipeline sgp_make_pipeline([NativeTypeName("const sgp_pipeline_desc *")] sgp_pipeline_desc* desc);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void sgp_begin(int width, int height);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void sgp_flush();

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void sgp_end();

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void sgp_project(float left, float right, float top, float bottom);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void sgp_reset_project();

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void sgp_push_transform();

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void sgp_pop_transform();

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void sgp_reset_transform();

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void sgp_translate(float x, float y);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void sgp_rotate(float theta);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void sgp_rotate_at(float theta, float x, float y);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void sgp_scale(float sx, float sy);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void sgp_scale_at(float sx, float sy, float x, float y);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void sgp_set_pipeline(sg_pipeline pipeline);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void sgp_reset_pipeline();

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void sgp_set_uniform([NativeTypeName("const void *")] void* data, [NativeTypeName("uint32_t")] uint size);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void sgp_reset_uniform();

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void sgp_set_blend_mode(sgp_blend_mode blend_mode);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void sgp_reset_blend_mode();

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void sgp_set_color(float r, float g, float b, float a);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void sgp_reset_color();

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void sgp_set_image(int channel, sg_image image);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void sgp_unset_image(int channel);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void sgp_reset_image(int channel);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void sgp_set_sampler(int channel, sg_sampler sampler);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void sgp_reset_sampler(int channel);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void sgp_viewport(int x, int y, int w, int h);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void sgp_reset_viewport();

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void sgp_scissor(int x, int y, int w, int h);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void sgp_reset_scissor();

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void sgp_reset_state();

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void sgp_clear();

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void sgp_draw_points([NativeTypeName("const sgp_point *")] sgp_vec2* points, [NativeTypeName("uint32_t")] uint count);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void sgp_draw_point(float x, float y);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void sgp_draw_lines([NativeTypeName("const sgp_line *")] sgp_line* lines, [NativeTypeName("uint32_t")] uint count);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void sgp_draw_line(float ax, float ay, float bx, float by);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void sgp_draw_lines_strip([NativeTypeName("const sgp_point *")] sgp_vec2* points, [NativeTypeName("uint32_t")] uint count);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void sgp_draw_filled_triangles([NativeTypeName("const sgp_triangle *")] sgp_triangle* triangles, [NativeTypeName("uint32_t")] uint count);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void sgp_draw_filled_triangle(float ax, float ay, float bx, float by, float cx, float cy);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void sgp_draw_filled_triangles_strip([NativeTypeName("const sgp_point *")] sgp_vec2* points, [NativeTypeName("uint32_t")] uint count);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void sgp_draw_filled_rects([NativeTypeName("const sgp_rect *")] sgp_rect* rects, [NativeTypeName("uint32_t")] uint count);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void sgp_draw_filled_rect(float x, float y, float w, float h);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void sgp_draw_textured_rects(int channel, [NativeTypeName("const sgp_textured_rect *")] sgp_textured_rect* rects, [NativeTypeName("uint32_t")] uint count);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void sgp_draw_textured_rect(int channel, sgp_rect dest_rect, sgp_rect src_rect);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern sgp_state* sgp_query_state();

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern sgp_desc sgp_query_desc();
    }
