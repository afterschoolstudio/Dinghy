using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Dinghy.Internal.Sokol;

[NativeTypeName("unsigned int")]
public enum sgp_error : uint
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

    [NativeTypeName("unsigned int")]
    public enum sgp_blend_mode : uint
    {
        SGP_BLENDMODE_NONE = 0,
        SGP_BLENDMODE_BLEND,
        SGP_BLENDMODE_ADD,
        SGP_BLENDMODE_MOD,
        SGP_BLENDMODE_MUL,
        _SGP_BLENDMODE_NUM,
    }

    [NativeTypeName("unsigned int")]
    public enum sgp_vs_attr_location : uint
    {
        SGP_VS_ATTR_COORD = 0,
        SGP_VS_ATTR_COLOR = 1,
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

    public partial struct sgp_mat2x3
    {
        [NativeTypeName("float[2][3]")]
        public _v_e__FixedBuffer v;

        [InlineArray(2 * 3)]
        public partial struct _v_e__FixedBuffer
        {
            public float e0_0;
        }
    }

    public partial struct sgp_color
    {
        public float r;

        public float g;

        public float b;

        public float a;
    }

    public partial struct sgp_color_ub4
    {
        [NativeTypeName("uint8_t")]
        public byte r;

        [NativeTypeName("uint8_t")]
        public byte g;

        [NativeTypeName("uint8_t")]
        public byte b;

        [NativeTypeName("uint8_t")]
        public byte a;
    }

    public partial struct sgp_uniform
    {
        [NativeTypeName("uint32_t")]
        public uint size;

        [NativeTypeName("float[4]")]
        public _content_e__FixedBuffer content;

        [InlineArray(4)]
        public partial struct _content_e__FixedBuffer
        {
            public float e0;
        }
    }

    public partial struct sgp_textures_uniform
    {
        [NativeTypeName("uint32_t")]
        public uint count;

        [NativeTypeName("sg_image[4]")]
        public _images_e__FixedBuffer images;

        [NativeTypeName("sg_sampler[4]")]
        public _samplers_e__FixedBuffer samplers;

        [InlineArray(4)]
        public partial struct _images_e__FixedBuffer
        {
            public sg_image e0;
        }

        [InlineArray(4)]
        public partial struct _samplers_e__FixedBuffer
        {
            public sg_sampler e0;
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

        public sgp_color_ub4 color;

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

        public sg_pixel_format color_format;

        public sg_pixel_format depth_format;

        public int sample_count;
    }

    public partial struct sgp_pipeline_desc
    {
        public sg_shader_desc shader;

        public sg_primitive_type primitive_type;

        public sgp_blend_mode blend_mode;

        public sg_pixel_format color_format;

        public sg_pixel_format depth_format;

        public int sample_count;

        [NativeTypeName("bool")]
        public byte has_vs_color;
    }

    public static unsafe partial class GP
    {
        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgp_setup", ExactSpelling = true)]
        public static extern void setup([NativeTypeName("const sgp_desc *")] sgp_desc* desc);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgp_shutdown", ExactSpelling = true)]
        public static extern void shutdown();

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgp_is_valid", ExactSpelling = true)]
        [return: NativeTypeName("bool")]
        public static extern byte is_valid();

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgp_get_last_error", ExactSpelling = true)]
        public static extern sgp_error get_last_error();

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgp_get_error_message", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* get_error_message(sgp_error error);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgp_make_pipeline", ExactSpelling = true)]
        public static extern sg_pipeline make_pipeline([NativeTypeName("const sgp_pipeline_desc *")] sgp_pipeline_desc* desc);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgp_begin", ExactSpelling = true)]
        public static extern void begin(int width, int height);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgp_flush", ExactSpelling = true)]
        public static extern void flush();

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgp_end", ExactSpelling = true)]
        public static extern void end();

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgp_project", ExactSpelling = true)]
        public static extern void project(float left, float right, float top, float bottom);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgp_reset_project", ExactSpelling = true)]
        public static extern void reset_project();

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgp_push_transform", ExactSpelling = true)]
        public static extern void push_transform();

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgp_pop_transform", ExactSpelling = true)]
        public static extern void pop_transform();

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgp_reset_transform", ExactSpelling = true)]
        public static extern void reset_transform();

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgp_translate", ExactSpelling = true)]
        public static extern void translate(float x, float y);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgp_rotate", ExactSpelling = true)]
        public static extern void rotate(float theta);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgp_rotate_at", ExactSpelling = true)]
        public static extern void rotate_at(float theta, float x, float y);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgp_scale", ExactSpelling = true)]
        public static extern void scale(float sx, float sy);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgp_scale_at", ExactSpelling = true)]
        public static extern void scale_at(float sx, float sy, float x, float y);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgp_set_pipeline", ExactSpelling = true)]
        public static extern void set_pipeline(sg_pipeline pipeline);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgp_reset_pipeline", ExactSpelling = true)]
        public static extern void reset_pipeline();

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgp_set_uniform", ExactSpelling = true)]
        public static extern void set_uniform([NativeTypeName("const void *")] void* data, [NativeTypeName("uint32_t")] uint size);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgp_reset_uniform", ExactSpelling = true)]
        public static extern void reset_uniform();

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgp_set_blend_mode", ExactSpelling = true)]
        public static extern void set_blend_mode(sgp_blend_mode blend_mode);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgp_reset_blend_mode", ExactSpelling = true)]
        public static extern void reset_blend_mode();

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgp_set_color", ExactSpelling = true)]
        public static extern void set_color(float r, float g, float b, float a);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgp_reset_color", ExactSpelling = true)]
        public static extern void reset_color();

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgp_set_image", ExactSpelling = true)]
        public static extern void set_image(int channel, sg_image image);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgp_unset_image", ExactSpelling = true)]
        public static extern void unset_image(int channel);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgp_reset_image", ExactSpelling = true)]
        public static extern void reset_image(int channel);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgp_set_sampler", ExactSpelling = true)]
        public static extern void set_sampler(int channel, sg_sampler sampler);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgp_reset_sampler", ExactSpelling = true)]
        public static extern void reset_sampler(int channel);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgp_viewport", ExactSpelling = true)]
        public static extern void viewport(int x, int y, int w, int h);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgp_reset_viewport", ExactSpelling = true)]
        public static extern void reset_viewport();

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgp_scissor", ExactSpelling = true)]
        public static extern void scissor(int x, int y, int w, int h);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgp_reset_scissor", ExactSpelling = true)]
        public static extern void reset_scissor();

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgp_reset_state", ExactSpelling = true)]
        public static extern void reset_state();

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgp_clear", ExactSpelling = true)]
        public static extern void clear();

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgp_draw_points", ExactSpelling = true)]
        public static extern void draw_points([NativeTypeName("const sgp_point *")] sgp_vec2* points, [NativeTypeName("uint32_t")] uint count);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgp_draw_point", ExactSpelling = true)]
        public static extern void draw_point(float x, float y);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgp_draw_lines", ExactSpelling = true)]
        public static extern void draw_lines([NativeTypeName("const sgp_line *")] sgp_line* lines, [NativeTypeName("uint32_t")] uint count);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgp_draw_line", ExactSpelling = true)]
        public static extern void draw_line(float ax, float ay, float bx, float by);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgp_draw_lines_strip", ExactSpelling = true)]
        public static extern void draw_lines_strip([NativeTypeName("const sgp_point *")] sgp_vec2* points, [NativeTypeName("uint32_t")] uint count);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgp_draw_filled_triangles", ExactSpelling = true)]
        public static extern void draw_filled_triangles([NativeTypeName("const sgp_triangle *")] sgp_triangle* triangles, [NativeTypeName("uint32_t")] uint count);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgp_draw_filled_triangle", ExactSpelling = true)]
        public static extern void draw_filled_triangle(float ax, float ay, float bx, float by, float cx, float cy);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgp_draw_filled_triangles_strip", ExactSpelling = true)]
        public static extern void draw_filled_triangles_strip([NativeTypeName("const sgp_point *")] sgp_vec2* points, [NativeTypeName("uint32_t")] uint count);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgp_draw_filled_rects", ExactSpelling = true)]
        public static extern void draw_filled_rects([NativeTypeName("const sgp_rect *")] sgp_rect* rects, [NativeTypeName("uint32_t")] uint count);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgp_draw_filled_rect", ExactSpelling = true)]
        public static extern void draw_filled_rect(float x, float y, float w, float h);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgp_draw_textured_rects", ExactSpelling = true)]
        public static extern void draw_textured_rects(int channel, [NativeTypeName("const sgp_textured_rect *")] sgp_textured_rect* rects, [NativeTypeName("uint32_t")] uint count);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgp_draw_textured_rect", ExactSpelling = true)]
        public static extern void draw_textured_rect(int channel, sgp_rect dest_rect, sgp_rect src_rect);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgp_query_state", ExactSpelling = true)]
        public static extern sgp_state* query_state();

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgp_query_desc", ExactSpelling = true)]
        public static extern sgp_desc query_desc();
    }
