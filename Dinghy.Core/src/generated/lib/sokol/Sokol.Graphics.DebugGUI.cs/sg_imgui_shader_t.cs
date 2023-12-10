using System.Runtime.CompilerServices;

namespace Dinghy.Internal.Sokol;

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
