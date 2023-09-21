using System.Runtime.InteropServices;

namespace Dinghy.Internal.Sokol;

public enum sgl_log_item_t
{
    SGL_LOGITEM_OK,
    SGL_LOGITEM_MALLOC_FAILED,
    SGL_LOGITEM_MAKE_PIPELINE_FAILED,
    SGL_LOGITEM_PIPELINE_POOL_EXHAUSTED,
    SGL_LOGITEM_ADD_COMMIT_LISTENER_FAILED,
    SGL_LOGITEM_CONTEXT_POOL_EXHAUSTED,
    SGL_LOGITEM_CANNOT_DESTROY_DEFAULT_CONTEXT,
}

    public unsafe partial struct sgl_logger_t
    {
        [NativeTypeName("void (*)(const char *, uint32_t, uint32_t, const char *, uint32_t, const char *, void *)")]
        public delegate* unmanaged[Cdecl]<sbyte*, uint, uint, sbyte*, uint, sbyte*, void*, void> func;

        public void* user_data;
    }

    public partial struct sgl_pipeline
    {
        [NativeTypeName("uint32_t")]
        public uint id;
    }

    public partial struct sgl_context
    {
        [NativeTypeName("uint32_t")]
        public uint id;
    }

    public enum sgl_error_t
    {
        SGL_NO_ERROR = 0,
        SGL_ERROR_VERTICES_FULL,
        SGL_ERROR_UNIFORMS_FULL,
        SGL_ERROR_COMMANDS_FULL,
        SGL_ERROR_STACK_OVERFLOW,
        SGL_ERROR_STACK_UNDERFLOW,
        SGL_ERROR_NO_CONTEXT,
    }

    public partial struct sgl_context_desc_t
    {
        public int max_vertices;

        public int max_commands;

        public sg_pixel_format color_format;

        public sg_pixel_format depth_format;

        public int sample_count;
    }

    public unsafe partial struct sgl_allocator_t
    {
        [NativeTypeName("void *(*)(size_t, void *)")]
        public delegate* unmanaged[Cdecl]<nuint, void*, void*> alloc;

        [NativeTypeName("void (*)(void *, void *)")]
        public delegate* unmanaged[Cdecl]<void*, void*, void> free;

        public void* user_data;
    }

    public partial struct sgl_desc_t
    {
        public int max_vertices;

        public int max_commands;

        public int context_pool_size;

        public int pipeline_pool_size;

        public sg_pixel_format color_format;

        public sg_pixel_format depth_format;

        public int sample_count;

        public sg_face_winding face_winding;

        public sgl_allocator_t allocator;

        public sgl_logger_t logger;
    }

    public static unsafe partial class GL
    {
        [NativeTypeName("const sgl_context")]
        public static readonly sgl_context SGL_DEFAULT_CONTEXT = new sgl_context
        {
            id = 0x00010001,
        };

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgl_setup", ExactSpelling = true)]
        public static extern void setup([NativeTypeName("const sgl_desc_t *")] sgl_desc_t* desc);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgl_shutdown", ExactSpelling = true)]
        public static extern void shutdown();

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgl_rad", ExactSpelling = true)]
        public static extern float rad(float deg);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgl_deg", ExactSpelling = true)]
        public static extern float deg(float rad);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgl_error", ExactSpelling = true)]
        public static extern sgl_error_t error();

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgl_context_error", ExactSpelling = true)]
        public static extern sgl_error_t context_error(sgl_context ctx);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgl_make_context", ExactSpelling = true)]
        public static extern sgl_context make_context([NativeTypeName("const sgl_context_desc_t *")] sgl_context_desc_t* desc);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgl_destroy_context", ExactSpelling = true)]
        public static extern void destroy_context(sgl_context ctx);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgl_set_context", ExactSpelling = true)]
        public static extern void set_context(sgl_context ctx);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgl_get_context", ExactSpelling = true)]
        public static extern sgl_context get_context();

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgl_default_context", ExactSpelling = true)]
        public static extern sgl_context default_context();

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgl_draw", ExactSpelling = true)]
        public static extern void draw();

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgl_context_draw", ExactSpelling = true)]
        public static extern void context_draw(sgl_context ctx);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgl_draw_layer", ExactSpelling = true)]
        public static extern void draw_layer(int layer_id);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgl_context_draw_layer", ExactSpelling = true)]
        public static extern void context_draw_layer(sgl_context ctx, int layer_id);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgl_make_pipeline", ExactSpelling = true)]
        public static extern sgl_pipeline make_pipeline([NativeTypeName("const sg_pipeline_desc *")] sg_pipeline_desc* desc);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgl_context_make_pipeline", ExactSpelling = true)]
        public static extern sgl_pipeline context_make_pipeline(sgl_context ctx, [NativeTypeName("const sg_pipeline_desc *")] sg_pipeline_desc* desc);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgl_destroy_pipeline", ExactSpelling = true)]
        public static extern void destroy_pipeline(sgl_pipeline pip);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgl_defaults", ExactSpelling = true)]
        public static extern void defaults();

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgl_viewport", ExactSpelling = true)]
        public static extern void viewport(int x, int y, int w, int h, [NativeTypeName("bool")] byte origin_top_left);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgl_viewportf", ExactSpelling = true)]
        public static extern void viewportf(float x, float y, float w, float h, [NativeTypeName("bool")] byte origin_top_left);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgl_scissor_rect", ExactSpelling = true)]
        public static extern void scissor_rect(int x, int y, int w, int h, [NativeTypeName("bool")] byte origin_top_left);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgl_scissor_rectf", ExactSpelling = true)]
        public static extern void scissor_rectf(float x, float y, float w, float h, [NativeTypeName("bool")] byte origin_top_left);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgl_enable_texture", ExactSpelling = true)]
        public static extern void enable_texture();

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgl_disable_texture", ExactSpelling = true)]
        public static extern void disable_texture();

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgl_texture", ExactSpelling = true)]
        public static extern void texture(sg_image img, sg_sampler smp);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgl_layer", ExactSpelling = true)]
        public static extern void layer(int layer_id);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgl_load_default_pipeline", ExactSpelling = true)]
        public static extern void load_default_pipeline();

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgl_load_pipeline", ExactSpelling = true)]
        public static extern void load_pipeline(sgl_pipeline pip);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgl_push_pipeline", ExactSpelling = true)]
        public static extern void push_pipeline();

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgl_pop_pipeline", ExactSpelling = true)]
        public static extern void pop_pipeline();

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgl_matrix_mode_modelview", ExactSpelling = true)]
        public static extern void matrix_mode_modelview();

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgl_matrix_mode_projection", ExactSpelling = true)]
        public static extern void matrix_mode_projection();

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgl_matrix_mode_texture", ExactSpelling = true)]
        public static extern void matrix_mode_texture();

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgl_load_identity", ExactSpelling = true)]
        public static extern void load_identity();

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgl_load_matrix", ExactSpelling = true)]
        public static extern void load_matrix([NativeTypeName("const float[16]")] float* m);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgl_load_transpose_matrix", ExactSpelling = true)]
        public static extern void load_transpose_matrix([NativeTypeName("const float[16]")] float* m);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgl_mult_matrix", ExactSpelling = true)]
        public static extern void mult_matrix([NativeTypeName("const float[16]")] float* m);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgl_mult_transpose_matrix", ExactSpelling = true)]
        public static extern void mult_transpose_matrix([NativeTypeName("const float[16]")] float* m);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgl_rotate", ExactSpelling = true)]
        public static extern void rotate(float angle_rad, float x, float y, float z);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgl_scale", ExactSpelling = true)]
        public static extern void scale(float x, float y, float z);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgl_translate", ExactSpelling = true)]
        public static extern void translate(float x, float y, float z);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgl_frustum", ExactSpelling = true)]
        public static extern void frustum(float l, float r, float b, float t, float n, float f);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgl_ortho", ExactSpelling = true)]
        public static extern void ortho(float l, float r, float b, float t, float n, float f);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgl_perspective", ExactSpelling = true)]
        public static extern void perspective(float fov_y, float aspect, float z_near, float z_far);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgl_lookat", ExactSpelling = true)]
        public static extern void lookat(float eye_x, float eye_y, float eye_z, float center_x, float center_y, float center_z, float up_x, float up_y, float up_z);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgl_push_matrix", ExactSpelling = true)]
        public static extern void push_matrix();

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgl_pop_matrix", ExactSpelling = true)]
        public static extern void pop_matrix();

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgl_t2f", ExactSpelling = true)]
        public static extern void t2f(float u, float v);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgl_c3f", ExactSpelling = true)]
        public static extern void c3f(float r, float g, float b);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgl_c4f", ExactSpelling = true)]
        public static extern void c4f(float r, float g, float b, float a);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgl_c3b", ExactSpelling = true)]
        public static extern void c3b([NativeTypeName("uint8_t")] byte r, [NativeTypeName("uint8_t")] byte g, [NativeTypeName("uint8_t")] byte b);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgl_c4b", ExactSpelling = true)]
        public static extern void c4b([NativeTypeName("uint8_t")] byte r, [NativeTypeName("uint8_t")] byte g, [NativeTypeName("uint8_t")] byte b, [NativeTypeName("uint8_t")] byte a);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgl_c1i", ExactSpelling = true)]
        public static extern void c1i([NativeTypeName("uint32_t")] uint rgba);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgl_point_size", ExactSpelling = true)]
        public static extern void point_size(float s);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgl_begin_points", ExactSpelling = true)]
        public static extern void begin_points();

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgl_begin_lines", ExactSpelling = true)]
        public static extern void begin_lines();

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgl_begin_line_strip", ExactSpelling = true)]
        public static extern void begin_line_strip();

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgl_begin_triangles", ExactSpelling = true)]
        public static extern void begin_triangles();

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgl_begin_triangle_strip", ExactSpelling = true)]
        public static extern void begin_triangle_strip();

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgl_begin_quads", ExactSpelling = true)]
        public static extern void begin_quads();

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgl_v2f", ExactSpelling = true)]
        public static extern void v2f(float x, float y);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgl_v3f", ExactSpelling = true)]
        public static extern void v3f(float x, float y, float z);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgl_v2f_t2f", ExactSpelling = true)]
        public static extern void v2f_t2f(float x, float y, float u, float v);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgl_v3f_t2f", ExactSpelling = true)]
        public static extern void v3f_t2f(float x, float y, float z, float u, float v);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgl_v2f_c3f", ExactSpelling = true)]
        public static extern void v2f_c3f(float x, float y, float r, float g, float b);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgl_v2f_c3b", ExactSpelling = true)]
        public static extern void v2f_c3b(float x, float y, [NativeTypeName("uint8_t")] byte r, [NativeTypeName("uint8_t")] byte g, [NativeTypeName("uint8_t")] byte b);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgl_v2f_c4f", ExactSpelling = true)]
        public static extern void v2f_c4f(float x, float y, float r, float g, float b, float a);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgl_v2f_c4b", ExactSpelling = true)]
        public static extern void v2f_c4b(float x, float y, [NativeTypeName("uint8_t")] byte r, [NativeTypeName("uint8_t")] byte g, [NativeTypeName("uint8_t")] byte b, [NativeTypeName("uint8_t")] byte a);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgl_v2f_c1i", ExactSpelling = true)]
        public static extern void v2f_c1i(float x, float y, [NativeTypeName("uint32_t")] uint rgba);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgl_v3f_c3f", ExactSpelling = true)]
        public static extern void v3f_c3f(float x, float y, float z, float r, float g, float b);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgl_v3f_c3b", ExactSpelling = true)]
        public static extern void v3f_c3b(float x, float y, float z, [NativeTypeName("uint8_t")] byte r, [NativeTypeName("uint8_t")] byte g, [NativeTypeName("uint8_t")] byte b);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgl_v3f_c4f", ExactSpelling = true)]
        public static extern void v3f_c4f(float x, float y, float z, float r, float g, float b, float a);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgl_v3f_c4b", ExactSpelling = true)]
        public static extern void v3f_c4b(float x, float y, float z, [NativeTypeName("uint8_t")] byte r, [NativeTypeName("uint8_t")] byte g, [NativeTypeName("uint8_t")] byte b, [NativeTypeName("uint8_t")] byte a);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgl_v3f_c1i", ExactSpelling = true)]
        public static extern void v3f_c1i(float x, float y, float z, [NativeTypeName("uint32_t")] uint rgba);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgl_v2f_t2f_c3f", ExactSpelling = true)]
        public static extern void v2f_t2f_c3f(float x, float y, float u, float v, float r, float g, float b);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgl_v2f_t2f_c3b", ExactSpelling = true)]
        public static extern void v2f_t2f_c3b(float x, float y, float u, float v, [NativeTypeName("uint8_t")] byte r, [NativeTypeName("uint8_t")] byte g, [NativeTypeName("uint8_t")] byte b);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgl_v2f_t2f_c4f", ExactSpelling = true)]
        public static extern void v2f_t2f_c4f(float x, float y, float u, float v, float r, float g, float b, float a);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgl_v2f_t2f_c4b", ExactSpelling = true)]
        public static extern void v2f_t2f_c4b(float x, float y, float u, float v, [NativeTypeName("uint8_t")] byte r, [NativeTypeName("uint8_t")] byte g, [NativeTypeName("uint8_t")] byte b, [NativeTypeName("uint8_t")] byte a);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgl_v2f_t2f_c1i", ExactSpelling = true)]
        public static extern void v2f_t2f_c1i(float x, float y, float u, float v, [NativeTypeName("uint32_t")] uint rgba);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgl_v3f_t2f_c3f", ExactSpelling = true)]
        public static extern void v3f_t2f_c3f(float x, float y, float z, float u, float v, float r, float g, float b);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgl_v3f_t2f_c3b", ExactSpelling = true)]
        public static extern void v3f_t2f_c3b(float x, float y, float z, float u, float v, [NativeTypeName("uint8_t")] byte r, [NativeTypeName("uint8_t")] byte g, [NativeTypeName("uint8_t")] byte b);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgl_v3f_t2f_c4f", ExactSpelling = true)]
        public static extern void v3f_t2f_c4f(float x, float y, float z, float u, float v, float r, float g, float b, float a);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgl_v3f_t2f_c4b", ExactSpelling = true)]
        public static extern void v3f_t2f_c4b(float x, float y, float z, float u, float v, [NativeTypeName("uint8_t")] byte r, [NativeTypeName("uint8_t")] byte g, [NativeTypeName("uint8_t")] byte b, [NativeTypeName("uint8_t")] byte a);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgl_v3f_t2f_c1i", ExactSpelling = true)]
        public static extern void v3f_t2f_c1i(float x, float y, float z, float u, float v, [NativeTypeName("uint32_t")] uint rgba);

        [DllImport("libs/sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sgl_end", ExactSpelling = true)]
        public static extern void end();
    }
