using System.Runtime.InteropServices;

namespace Dinghy.Internal.Sokol;

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
