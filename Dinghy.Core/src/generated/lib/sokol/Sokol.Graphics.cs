using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Dinghy.Internal.Sokol;

public partial struct sg_buffer
{
    [NativeTypeName("uint32_t")]
    public uint id;
}

    public partial struct sg_image
    {
        [NativeTypeName("uint32_t")]
        public uint id;
    }

    public partial struct sg_sampler
    {
        [NativeTypeName("uint32_t")]
        public uint id;
    }

    public partial struct sg_shader
    {
        [NativeTypeName("uint32_t")]
        public uint id;
    }

    public partial struct sg_pipeline
    {
        [NativeTypeName("uint32_t")]
        public uint id;
    }

    public partial struct sg_pass
    {
        [NativeTypeName("uint32_t")]
        public uint id;
    }

    public partial struct sg_context
    {
        [NativeTypeName("uint32_t")]
        public uint id;
    }

    public unsafe partial struct sg_range
    {
        [NativeTypeName("const void *")]
        public void* ptr;

        [NativeTypeName("size_t")]
        public nuint size;
    }

    public partial struct sg_color
    {
        public float r;

        public float g;

        public float b;

        public float a;
    }

    [NativeTypeName("unsigned int")]
    public enum sg_backend : uint
    {
        SG_BACKEND_GLCORE33,
        SG_BACKEND_GLES3,
        SG_BACKEND_D3D11,
        SG_BACKEND_METAL_IOS,
        SG_BACKEND_METAL_MACOS,
        SG_BACKEND_METAL_SIMULATOR,
        SG_BACKEND_WGPU,
        SG_BACKEND_DUMMY,
    }

    [NativeTypeName("unsigned int")]
    public enum sg_pixel_format : uint
    {
        _SG_PIXELFORMAT_DEFAULT,
        SG_PIXELFORMAT_NONE,
        SG_PIXELFORMAT_R8,
        SG_PIXELFORMAT_R8SN,
        SG_PIXELFORMAT_R8UI,
        SG_PIXELFORMAT_R8SI,
        SG_PIXELFORMAT_R16,
        SG_PIXELFORMAT_R16SN,
        SG_PIXELFORMAT_R16UI,
        SG_PIXELFORMAT_R16SI,
        SG_PIXELFORMAT_R16F,
        SG_PIXELFORMAT_RG8,
        SG_PIXELFORMAT_RG8SN,
        SG_PIXELFORMAT_RG8UI,
        SG_PIXELFORMAT_RG8SI,
        SG_PIXELFORMAT_R32UI,
        SG_PIXELFORMAT_R32SI,
        SG_PIXELFORMAT_R32F,
        SG_PIXELFORMAT_RG16,
        SG_PIXELFORMAT_RG16SN,
        SG_PIXELFORMAT_RG16UI,
        SG_PIXELFORMAT_RG16SI,
        SG_PIXELFORMAT_RG16F,
        SG_PIXELFORMAT_RGBA8,
        SG_PIXELFORMAT_SRGB8A8,
        SG_PIXELFORMAT_RGBA8SN,
        SG_PIXELFORMAT_RGBA8UI,
        SG_PIXELFORMAT_RGBA8SI,
        SG_PIXELFORMAT_BGRA8,
        SG_PIXELFORMAT_RGB10A2,
        SG_PIXELFORMAT_RG11B10F,
        SG_PIXELFORMAT_RG32UI,
        SG_PIXELFORMAT_RG32SI,
        SG_PIXELFORMAT_RG32F,
        SG_PIXELFORMAT_RGBA16,
        SG_PIXELFORMAT_RGBA16SN,
        SG_PIXELFORMAT_RGBA16UI,
        SG_PIXELFORMAT_RGBA16SI,
        SG_PIXELFORMAT_RGBA16F,
        SG_PIXELFORMAT_RGBA32UI,
        SG_PIXELFORMAT_RGBA32SI,
        SG_PIXELFORMAT_RGBA32F,
        SG_PIXELFORMAT_DEPTH,
        SG_PIXELFORMAT_DEPTH_STENCIL,
        SG_PIXELFORMAT_BC1_RGBA,
        SG_PIXELFORMAT_BC2_RGBA,
        SG_PIXELFORMAT_BC3_RGBA,
        SG_PIXELFORMAT_BC4_R,
        SG_PIXELFORMAT_BC4_RSN,
        SG_PIXELFORMAT_BC5_RG,
        SG_PIXELFORMAT_BC5_RGSN,
        SG_PIXELFORMAT_BC6H_RGBF,
        SG_PIXELFORMAT_BC6H_RGBUF,
        SG_PIXELFORMAT_BC7_RGBA,
        SG_PIXELFORMAT_PVRTC_RGB_2BPP,
        SG_PIXELFORMAT_PVRTC_RGB_4BPP,
        SG_PIXELFORMAT_PVRTC_RGBA_2BPP,
        SG_PIXELFORMAT_PVRTC_RGBA_4BPP,
        SG_PIXELFORMAT_ETC2_RGB8,
        SG_PIXELFORMAT_ETC2_RGB8A1,
        SG_PIXELFORMAT_ETC2_RGBA8,
        SG_PIXELFORMAT_ETC2_RG11,
        SG_PIXELFORMAT_ETC2_RG11SN,
        SG_PIXELFORMAT_RGB9E5,
        _SG_PIXELFORMAT_NUM,
        _SG_PIXELFORMAT_FORCE_U32 = 0x7FFFFFFF,
    }

    public partial struct sg_pixelformat_info
    {
        [NativeTypeName("bool")]
        public byte sample;

        [NativeTypeName("bool")]
        public byte filter;

        [NativeTypeName("bool")]
        public byte render;

        [NativeTypeName("bool")]
        public byte blend;

        [NativeTypeName("bool")]
        public byte msaa;

        [NativeTypeName("bool")]
        public byte depth;
    }

    public partial struct sg_features
    {
        [NativeTypeName("bool")]
        public byte origin_top_left;

        [NativeTypeName("bool")]
        public byte image_clamp_to_border;

        [NativeTypeName("bool")]
        public byte mrt_independent_blend_state;

        [NativeTypeName("bool")]
        public byte mrt_independent_write_mask;
    }

    public partial struct sg_limits
    {
        public int max_image_size_2d;

        public int max_image_size_cube;

        public int max_image_size_3d;

        public int max_image_size_array;

        public int max_image_array_layers;

        public int max_vertex_attrs;

        public int gl_max_vertex_uniform_vectors;

        public int gl_max_combined_texture_image_units;
    }

    [NativeTypeName("unsigned int")]
    public enum sg_resource_state : uint
    {
        SG_RESOURCESTATE_INITIAL,
        SG_RESOURCESTATE_ALLOC,
        SG_RESOURCESTATE_VALID,
        SG_RESOURCESTATE_FAILED,
        SG_RESOURCESTATE_INVALID,
        _SG_RESOURCESTATE_FORCE_U32 = 0x7FFFFFFF,
    }

    [NativeTypeName("unsigned int")]
    public enum sg_usage : uint
    {
        _SG_USAGE_DEFAULT,
        SG_USAGE_IMMUTABLE,
        SG_USAGE_DYNAMIC,
        SG_USAGE_STREAM,
        _SG_USAGE_NUM,
        _SG_USAGE_FORCE_U32 = 0x7FFFFFFF,
    }

    [NativeTypeName("unsigned int")]
    public enum sg_buffer_type : uint
    {
        _SG_BUFFERTYPE_DEFAULT,
        SG_BUFFERTYPE_VERTEXBUFFER,
        SG_BUFFERTYPE_INDEXBUFFER,
        _SG_BUFFERTYPE_NUM,
        _SG_BUFFERTYPE_FORCE_U32 = 0x7FFFFFFF,
    }

    [NativeTypeName("unsigned int")]
    public enum sg_index_type : uint
    {
        _SG_INDEXTYPE_DEFAULT,
        SG_INDEXTYPE_NONE,
        SG_INDEXTYPE_UINT16,
        SG_INDEXTYPE_UINT32,
        _SG_INDEXTYPE_NUM,
        _SG_INDEXTYPE_FORCE_U32 = 0x7FFFFFFF,
    }

    [NativeTypeName("unsigned int")]
    public enum sg_image_type : uint
    {
        _SG_IMAGETYPE_DEFAULT,
        SG_IMAGETYPE_2D,
        SG_IMAGETYPE_CUBE,
        SG_IMAGETYPE_3D,
        SG_IMAGETYPE_ARRAY,
        _SG_IMAGETYPE_NUM,
        _SG_IMAGETYPE_FORCE_U32 = 0x7FFFFFFF,
    }

    [NativeTypeName("unsigned int")]
    public enum sg_image_sample_type : uint
    {
        _SG_IMAGESAMPLETYPE_DEFAULT,
        SG_IMAGESAMPLETYPE_FLOAT,
        SG_IMAGESAMPLETYPE_DEPTH,
        SG_IMAGESAMPLETYPE_SINT,
        SG_IMAGESAMPLETYPE_UINT,
        SG_IMAGESAMPLETYPE_UNFILTERABLE_FLOAT,
        _SG_IMAGESAMPLETYPE_NUM,
        _SG_IMAGESAMPLETYPE_FORCE_U32 = 0x7FFFFFFF,
    }

    [NativeTypeName("unsigned int")]
    public enum sg_sampler_type : uint
    {
        _SG_SAMPLERTYPE_DEFAULT,
        SG_SAMPLERTYPE_FILTERING,
        SG_SAMPLERTYPE_NONFILTERING,
        SG_SAMPLERTYPE_COMPARISON,
        _SG_SAMPLERTYPE_NUM,
        _SG_SAMPLERTYPE_FORCE_U32,
    }

    [NativeTypeName("unsigned int")]
    public enum sg_cube_face : uint
    {
        SG_CUBEFACE_POS_X,
        SG_CUBEFACE_NEG_X,
        SG_CUBEFACE_POS_Y,
        SG_CUBEFACE_NEG_Y,
        SG_CUBEFACE_POS_Z,
        SG_CUBEFACE_NEG_Z,
        SG_CUBEFACE_NUM,
        _SG_CUBEFACE_FORCE_U32 = 0x7FFFFFFF,
    }

    [NativeTypeName("unsigned int")]
    public enum sg_shader_stage : uint
    {
        SG_SHADERSTAGE_VS,
        SG_SHADERSTAGE_FS,
        _SG_SHADERSTAGE_FORCE_U32 = 0x7FFFFFFF,
    }

    [NativeTypeName("unsigned int")]
    public enum sg_primitive_type : uint
    {
        _SG_PRIMITIVETYPE_DEFAULT,
        SG_PRIMITIVETYPE_POINTS,
        SG_PRIMITIVETYPE_LINES,
        SG_PRIMITIVETYPE_LINE_STRIP,
        SG_PRIMITIVETYPE_TRIANGLES,
        SG_PRIMITIVETYPE_TRIANGLE_STRIP,
        _SG_PRIMITIVETYPE_NUM,
        _SG_PRIMITIVETYPE_FORCE_U32 = 0x7FFFFFFF,
    }

    [NativeTypeName("unsigned int")]
    public enum sg_filter : uint
    {
        _SG_FILTER_DEFAULT,
        SG_FILTER_NONE,
        SG_FILTER_NEAREST,
        SG_FILTER_LINEAR,
        _SG_FILTER_NUM,
        _SG_FILTER_FORCE_U32 = 0x7FFFFFFF,
    }

    [NativeTypeName("unsigned int")]
    public enum sg_wrap : uint
    {
        _SG_WRAP_DEFAULT,
        SG_WRAP_REPEAT,
        SG_WRAP_CLAMP_TO_EDGE,
        SG_WRAP_CLAMP_TO_BORDER,
        SG_WRAP_MIRRORED_REPEAT,
        _SG_WRAP_NUM,
        _SG_WRAP_FORCE_U32 = 0x7FFFFFFF,
    }

    [NativeTypeName("unsigned int")]
    public enum sg_border_color : uint
    {
        _SG_BORDERCOLOR_DEFAULT,
        SG_BORDERCOLOR_TRANSPARENT_BLACK,
        SG_BORDERCOLOR_OPAQUE_BLACK,
        SG_BORDERCOLOR_OPAQUE_WHITE,
        _SG_BORDERCOLOR_NUM,
        _SG_BORDERCOLOR_FORCE_U32 = 0x7FFFFFFF,
    }

    [NativeTypeName("unsigned int")]
    public enum sg_vertex_format : uint
    {
        SG_VERTEXFORMAT_INVALID,
        SG_VERTEXFORMAT_FLOAT,
        SG_VERTEXFORMAT_FLOAT2,
        SG_VERTEXFORMAT_FLOAT3,
        SG_VERTEXFORMAT_FLOAT4,
        SG_VERTEXFORMAT_BYTE4,
        SG_VERTEXFORMAT_BYTE4N,
        SG_VERTEXFORMAT_UBYTE4,
        SG_VERTEXFORMAT_UBYTE4N,
        SG_VERTEXFORMAT_SHORT2,
        SG_VERTEXFORMAT_SHORT2N,
        SG_VERTEXFORMAT_USHORT2N,
        SG_VERTEXFORMAT_SHORT4,
        SG_VERTEXFORMAT_SHORT4N,
        SG_VERTEXFORMAT_USHORT4N,
        SG_VERTEXFORMAT_UINT10_N2,
        SG_VERTEXFORMAT_HALF2,
        SG_VERTEXFORMAT_HALF4,
        _SG_VERTEXFORMAT_NUM,
        _SG_VERTEXFORMAT_FORCE_U32 = 0x7FFFFFFF,
    }

    [NativeTypeName("unsigned int")]
    public enum sg_vertex_step : uint
    {
        _SG_VERTEXSTEP_DEFAULT,
        SG_VERTEXSTEP_PER_VERTEX,
        SG_VERTEXSTEP_PER_INSTANCE,
        _SG_VERTEXSTEP_NUM,
        _SG_VERTEXSTEP_FORCE_U32 = 0x7FFFFFFF,
    }

    [NativeTypeName("unsigned int")]
    public enum sg_uniform_type : uint
    {
        SG_UNIFORMTYPE_INVALID,
        SG_UNIFORMTYPE_FLOAT,
        SG_UNIFORMTYPE_FLOAT2,
        SG_UNIFORMTYPE_FLOAT3,
        SG_UNIFORMTYPE_FLOAT4,
        SG_UNIFORMTYPE_INT,
        SG_UNIFORMTYPE_INT2,
        SG_UNIFORMTYPE_INT3,
        SG_UNIFORMTYPE_INT4,
        SG_UNIFORMTYPE_MAT4,
        _SG_UNIFORMTYPE_NUM,
        _SG_UNIFORMTYPE_FORCE_U32 = 0x7FFFFFFF,
    }

    [NativeTypeName("unsigned int")]
    public enum sg_uniform_layout : uint
    {
        _SG_UNIFORMLAYOUT_DEFAULT,
        SG_UNIFORMLAYOUT_NATIVE,
        SG_UNIFORMLAYOUT_STD140,
        _SG_UNIFORMLAYOUT_NUM,
        _SG_UNIFORMLAYOUT_FORCE_U32 = 0x7FFFFFFF,
    }

    [NativeTypeName("unsigned int")]
    public enum sg_cull_mode : uint
    {
        _SG_CULLMODE_DEFAULT,
        SG_CULLMODE_NONE,
        SG_CULLMODE_FRONT,
        SG_CULLMODE_BACK,
        _SG_CULLMODE_NUM,
        _SG_CULLMODE_FORCE_U32 = 0x7FFFFFFF,
    }

    [NativeTypeName("unsigned int")]
    public enum sg_face_winding : uint
    {
        _SG_FACEWINDING_DEFAULT,
        SG_FACEWINDING_CCW,
        SG_FACEWINDING_CW,
        _SG_FACEWINDING_NUM,
        _SG_FACEWINDING_FORCE_U32 = 0x7FFFFFFF,
    }

    [NativeTypeName("unsigned int")]
    public enum sg_compare_func : uint
    {
        _SG_COMPAREFUNC_DEFAULT,
        SG_COMPAREFUNC_NEVER,
        SG_COMPAREFUNC_LESS,
        SG_COMPAREFUNC_EQUAL,
        SG_COMPAREFUNC_LESS_EQUAL,
        SG_COMPAREFUNC_GREATER,
        SG_COMPAREFUNC_NOT_EQUAL,
        SG_COMPAREFUNC_GREATER_EQUAL,
        SG_COMPAREFUNC_ALWAYS,
        _SG_COMPAREFUNC_NUM,
        _SG_COMPAREFUNC_FORCE_U32 = 0x7FFFFFFF,
    }

    [NativeTypeName("unsigned int")]
    public enum sg_stencil_op : uint
    {
        _SG_STENCILOP_DEFAULT,
        SG_STENCILOP_KEEP,
        SG_STENCILOP_ZERO,
        SG_STENCILOP_REPLACE,
        SG_STENCILOP_INCR_CLAMP,
        SG_STENCILOP_DECR_CLAMP,
        SG_STENCILOP_INVERT,
        SG_STENCILOP_INCR_WRAP,
        SG_STENCILOP_DECR_WRAP,
        _SG_STENCILOP_NUM,
        _SG_STENCILOP_FORCE_U32 = 0x7FFFFFFF,
    }

    [NativeTypeName("unsigned int")]
    public enum sg_blend_factor : uint
    {
        _SG_BLENDFACTOR_DEFAULT,
        SG_BLENDFACTOR_ZERO,
        SG_BLENDFACTOR_ONE,
        SG_BLENDFACTOR_SRC_COLOR,
        SG_BLENDFACTOR_ONE_MINUS_SRC_COLOR,
        SG_BLENDFACTOR_SRC_ALPHA,
        SG_BLENDFACTOR_ONE_MINUS_SRC_ALPHA,
        SG_BLENDFACTOR_DST_COLOR,
        SG_BLENDFACTOR_ONE_MINUS_DST_COLOR,
        SG_BLENDFACTOR_DST_ALPHA,
        SG_BLENDFACTOR_ONE_MINUS_DST_ALPHA,
        SG_BLENDFACTOR_SRC_ALPHA_SATURATED,
        SG_BLENDFACTOR_BLEND_COLOR,
        SG_BLENDFACTOR_ONE_MINUS_BLEND_COLOR,
        SG_BLENDFACTOR_BLEND_ALPHA,
        SG_BLENDFACTOR_ONE_MINUS_BLEND_ALPHA,
        _SG_BLENDFACTOR_NUM,
        _SG_BLENDFACTOR_FORCE_U32 = 0x7FFFFFFF,
    }

    [NativeTypeName("unsigned int")]
    public enum sg_blend_op : uint
    {
        _SG_BLENDOP_DEFAULT,
        SG_BLENDOP_ADD,
        SG_BLENDOP_SUBTRACT,
        SG_BLENDOP_REVERSE_SUBTRACT,
        _SG_BLENDOP_NUM,
        _SG_BLENDOP_FORCE_U32 = 0x7FFFFFFF,
    }

    [NativeTypeName("unsigned int")]
    public enum sg_color_mask : uint
    {
        _SG_COLORMASK_DEFAULT = 0,
        SG_COLORMASK_NONE = 0x10,
        SG_COLORMASK_R = 0x1,
        SG_COLORMASK_G = 0x2,
        SG_COLORMASK_RG = 0x3,
        SG_COLORMASK_B = 0x4,
        SG_COLORMASK_RB = 0x5,
        SG_COLORMASK_GB = 0x6,
        SG_COLORMASK_RGB = 0x7,
        SG_COLORMASK_A = 0x8,
        SG_COLORMASK_RA = 0x9,
        SG_COLORMASK_GA = 0xA,
        SG_COLORMASK_RGA = 0xB,
        SG_COLORMASK_BA = 0xC,
        SG_COLORMASK_RBA = 0xD,
        SG_COLORMASK_GBA = 0xE,
        SG_COLORMASK_RGBA = 0xF,
        _SG_COLORMASK_FORCE_U32 = 0x7FFFFFFF,
    }

    [NativeTypeName("unsigned int")]
    public enum sg_load_action : uint
    {
        _SG_LOADACTION_DEFAULT,
        SG_LOADACTION_CLEAR,
        SG_LOADACTION_LOAD,
        SG_LOADACTION_DONTCARE,
        _SG_LOADACTION_FORCE_U32 = 0x7FFFFFFF,
    }

    [NativeTypeName("unsigned int")]
    public enum sg_store_action : uint
    {
        _SG_STOREACTION_DEFAULT,
        SG_STOREACTION_STORE,
        SG_STOREACTION_DONTCARE,
        _SG_STOREACTION_FORCE_U32 = 0x7FFFFFFF,
    }

    public partial struct sg_color_attachment_action
    {
        public sg_load_action load_action;

        public sg_store_action store_action;

        public sg_color clear_value;
    }

    public partial struct sg_depth_attachment_action
    {
        public sg_load_action load_action;

        public sg_store_action store_action;

        public float clear_value;
    }

    public partial struct sg_stencil_attachment_action
    {
        public sg_load_action load_action;

        public sg_store_action store_action;

        [NativeTypeName("uint8_t")]
        public byte clear_value;
    }

    public partial struct sg_pass_action
    {
        [NativeTypeName("uint32_t")]
        public uint _start_canary;

        [NativeTypeName("sg_color_attachment_action[4]")]
        public _colors_e__FixedBuffer colors;

        public sg_depth_attachment_action depth;

        public sg_stencil_attachment_action stencil;

        [NativeTypeName("uint32_t")]
        public uint _end_canary;

        [InlineArray(4)]
        public partial struct _colors_e__FixedBuffer
        {
            public sg_color_attachment_action e0;
        }
    }

    public partial struct sg_stage_bindings
    {
        [NativeTypeName("sg_image[12]")]
        public _images_e__FixedBuffer images;

        [NativeTypeName("sg_sampler[8]")]
        public _samplers_e__FixedBuffer samplers;

        [InlineArray(12)]
        public partial struct _images_e__FixedBuffer
        {
            public sg_image e0;
        }

        [InlineArray(8)]
        public partial struct _samplers_e__FixedBuffer
        {
            public sg_sampler e0;
        }
    }

    public partial struct sg_bindings
    {
        [NativeTypeName("uint32_t")]
        public uint _start_canary;

        [NativeTypeName("sg_buffer[8]")]
        public _vertex_buffers_e__FixedBuffer vertex_buffers;

        [NativeTypeName("int[8]")]
        public _vertex_buffer_offsets_e__FixedBuffer vertex_buffer_offsets;

        public sg_buffer index_buffer;

        public int index_buffer_offset;

        public sg_stage_bindings vs;

        public sg_stage_bindings fs;

        [NativeTypeName("uint32_t")]
        public uint _end_canary;

        [InlineArray(8)]
        public partial struct _vertex_buffers_e__FixedBuffer
        {
            public sg_buffer e0;
        }

        [InlineArray(8)]
        public partial struct _vertex_buffer_offsets_e__FixedBuffer
        {
            public int e0;
        }
    }

    public unsafe partial struct sg_buffer_desc
    {
        [NativeTypeName("uint32_t")]
        public uint _start_canary;

        [NativeTypeName("size_t")]
        public nuint size;

        public sg_buffer_type type;

        public sg_usage usage;

        public sg_range data;

        [NativeTypeName("const char *")]
        public sbyte* label;

        [NativeTypeName("uint32_t[2]")]
        public _gl_buffers_e__FixedBuffer gl_buffers;

        [NativeTypeName("const void *[2]")]
        public _mtl_buffers_e__FixedBuffer mtl_buffers;

        [NativeTypeName("const void *")]
        public void* d3d11_buffer;

        [NativeTypeName("const void *")]
        public void* wgpu_buffer;

        [NativeTypeName("uint32_t")]
        public uint _end_canary;

        [InlineArray(2)]
        public partial struct _gl_buffers_e__FixedBuffer
        {
            public uint e0;
        }

        public unsafe partial struct _mtl_buffers_e__FixedBuffer
        {
            public void* e0;
            public void* e1;

            public ref void* this[int index]
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get
                {
                    fixed (void** pThis = &e0)
                    {
                        return ref pThis[index];
                    }
                }
            }
        }
    }

    public partial struct sg_image_data
    {
        [NativeTypeName("sg_range[6][16]")]
        public _subimage_e__FixedBuffer subimage;

        [InlineArray(6 * 16)]
        public partial struct _subimage_e__FixedBuffer
        {
            public sg_range e0_0;
        }
    }

    public unsafe partial struct sg_image_desc
    {
        [NativeTypeName("uint32_t")]
        public uint _start_canary;

        public sg_image_type type;

        [NativeTypeName("bool")]
        public byte render_target;

        public int width;

        public int height;

        public int num_slices;

        public int num_mipmaps;

        public sg_usage usage;

        public sg_pixel_format pixel_format;

        public int sample_count;

        public sg_image_data data;

        [NativeTypeName("const char *")]
        public sbyte* label;

        [NativeTypeName("uint32_t[2]")]
        public _gl_textures_e__FixedBuffer gl_textures;

        [NativeTypeName("uint32_t")]
        public uint gl_texture_target;

        [NativeTypeName("const void *[2]")]
        public _mtl_textures_e__FixedBuffer mtl_textures;

        [NativeTypeName("const void *")]
        public void* d3d11_texture;

        [NativeTypeName("const void *")]
        public void* d3d11_shader_resource_view;

        [NativeTypeName("const void *")]
        public void* wgpu_texture;

        [NativeTypeName("const void *")]
        public void* wgpu_texture_view;

        [NativeTypeName("uint32_t")]
        public uint _end_canary;

        [InlineArray(2)]
        public partial struct _gl_textures_e__FixedBuffer
        {
            public uint e0;
        }

        public unsafe partial struct _mtl_textures_e__FixedBuffer
        {
            public void* e0;
            public void* e1;

            public ref void* this[int index]
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get
                {
                    fixed (void** pThis = &e0)
                    {
                        return ref pThis[index];
                    }
                }
            }
        }
    }

    public unsafe partial struct sg_sampler_desc
    {
        [NativeTypeName("uint32_t")]
        public uint _start_canary;

        public sg_filter min_filter;

        public sg_filter mag_filter;

        public sg_filter mipmap_filter;

        public sg_wrap wrap_u;

        public sg_wrap wrap_v;

        public sg_wrap wrap_w;

        public float min_lod;

        public float max_lod;

        public sg_border_color border_color;

        public sg_compare_func compare;

        [NativeTypeName("uint32_t")]
        public uint max_anisotropy;

        [NativeTypeName("const char *")]
        public sbyte* label;

        [NativeTypeName("uint32_t")]
        public uint gl_sampler;

        [NativeTypeName("const void *")]
        public void* mtl_sampler;

        [NativeTypeName("const void *")]
        public void* d3d11_sampler;

        [NativeTypeName("const void *")]
        public void* wgpu_sampler;

        [NativeTypeName("uint32_t")]
        public uint _end_canary;
    }

    public unsafe partial struct sg_shader_attr_desc
    {
        [NativeTypeName("const char *")]
        public sbyte* name;

        [NativeTypeName("const char *")]
        public sbyte* sem_name;

        public int sem_index;
    }

    public unsafe partial struct sg_shader_uniform_desc
    {
        [NativeTypeName("const char *")]
        public sbyte* name;

        public sg_uniform_type type;

        public int array_count;
    }

    public partial struct sg_shader_uniform_block_desc
    {
        [NativeTypeName("size_t")]
        public nuint size;

        public sg_uniform_layout layout;

        [NativeTypeName("sg_shader_uniform_desc[16]")]
        public _uniforms_e__FixedBuffer uniforms;

        [InlineArray(16)]
        public partial struct _uniforms_e__FixedBuffer
        {
            public sg_shader_uniform_desc e0;
        }
    }

    public partial struct sg_shader_image_desc
    {
        [NativeTypeName("bool")]
        public byte used;

        [NativeTypeName("bool")]
        public byte multisampled;

        public sg_image_type image_type;

        public sg_image_sample_type sample_type;
    }

    public partial struct sg_shader_sampler_desc
    {
        [NativeTypeName("bool")]
        public byte used;

        public sg_sampler_type sampler_type;
    }

    public unsafe partial struct sg_shader_image_sampler_pair_desc
    {
        [NativeTypeName("bool")]
        public byte used;

        public int image_slot;

        public int sampler_slot;

        [NativeTypeName("const char *")]
        public sbyte* glsl_name;
    }

    public unsafe partial struct sg_shader_stage_desc
    {
        [NativeTypeName("const char *")]
        public sbyte* source;

        public sg_range bytecode;

        [NativeTypeName("const char *")]
        public sbyte* entry;

        [NativeTypeName("const char *")]
        public sbyte* d3d11_target;

        [NativeTypeName("sg_shader_uniform_block_desc[4]")]
        public _uniform_blocks_e__FixedBuffer uniform_blocks;

        [NativeTypeName("sg_shader_image_desc[12]")]
        public _images_e__FixedBuffer images;

        [NativeTypeName("sg_shader_sampler_desc[8]")]
        public _samplers_e__FixedBuffer samplers;

        [NativeTypeName("sg_shader_image_sampler_pair_desc[12]")]
        public _image_sampler_pairs_e__FixedBuffer image_sampler_pairs;

        [InlineArray(4)]
        public partial struct _uniform_blocks_e__FixedBuffer
        {
            public sg_shader_uniform_block_desc e0;
        }

        [InlineArray(12)]
        public partial struct _images_e__FixedBuffer
        {
            public sg_shader_image_desc e0;
        }

        [InlineArray(8)]
        public partial struct _samplers_e__FixedBuffer
        {
            public sg_shader_sampler_desc e0;
        }

        [InlineArray(12)]
        public partial struct _image_sampler_pairs_e__FixedBuffer
        {
            public sg_shader_image_sampler_pair_desc e0;
        }
    }

    public unsafe partial struct sg_shader_desc
    {
        [NativeTypeName("uint32_t")]
        public uint _start_canary;

        [NativeTypeName("sg_shader_attr_desc[16]")]
        public _attrs_e__FixedBuffer attrs;

        public sg_shader_stage_desc vs;

        public sg_shader_stage_desc fs;

        [NativeTypeName("const char *")]
        public sbyte* label;

        [NativeTypeName("uint32_t")]
        public uint _end_canary;

        [InlineArray(16)]
        public partial struct _attrs_e__FixedBuffer
        {
            public sg_shader_attr_desc e0;
        }
    }

    public partial struct sg_vertex_buffer_layout_state
    {
        public int stride;

        public sg_vertex_step step_func;

        public int step_rate;
    }

    public partial struct sg_vertex_attr_state
    {
        public int buffer_index;

        public int offset;

        public sg_vertex_format format;
    }

    public partial struct sg_vertex_layout_state
    {
        [NativeTypeName("sg_vertex_buffer_layout_state[8]")]
        public _buffers_e__FixedBuffer buffers;

        [NativeTypeName("sg_vertex_attr_state[16]")]
        public _attrs_e__FixedBuffer attrs;

        [InlineArray(8)]
        public partial struct _buffers_e__FixedBuffer
        {
            public sg_vertex_buffer_layout_state e0;
        }

        [InlineArray(16)]
        public partial struct _attrs_e__FixedBuffer
        {
            public sg_vertex_attr_state e0;
        }
    }

    public partial struct sg_stencil_face_state
    {
        public sg_compare_func compare;

        public sg_stencil_op fail_op;

        public sg_stencil_op depth_fail_op;

        public sg_stencil_op pass_op;
    }

    public partial struct sg_stencil_state
    {
        [NativeTypeName("bool")]
        public byte enabled;

        public sg_stencil_face_state front;

        public sg_stencil_face_state back;

        [NativeTypeName("uint8_t")]
        public byte read_mask;

        [NativeTypeName("uint8_t")]
        public byte write_mask;

        [NativeTypeName("uint8_t")]
        public byte @ref;
    }

    public partial struct sg_depth_state
    {
        public sg_pixel_format pixel_format;

        public sg_compare_func compare;

        [NativeTypeName("bool")]
        public byte write_enabled;

        public float bias;

        public float bias_slope_scale;

        public float bias_clamp;
    }

    public partial struct sg_blend_state
    {
        [NativeTypeName("bool")]
        public byte enabled;

        public sg_blend_factor src_factor_rgb;

        public sg_blend_factor dst_factor_rgb;

        public sg_blend_op op_rgb;

        public sg_blend_factor src_factor_alpha;

        public sg_blend_factor dst_factor_alpha;

        public sg_blend_op op_alpha;
    }

    public partial struct sg_color_target_state
    {
        public sg_pixel_format pixel_format;

        public sg_color_mask write_mask;

        public sg_blend_state blend;
    }

    public unsafe partial struct sg_pipeline_desc
    {
        [NativeTypeName("uint32_t")]
        public uint _start_canary;

        public sg_shader shader;

        public sg_vertex_layout_state layout;

        public sg_depth_state depth;

        public sg_stencil_state stencil;

        public int color_count;

        [NativeTypeName("sg_color_target_state[4]")]
        public _colors_e__FixedBuffer colors;

        public sg_primitive_type primitive_type;

        public sg_index_type index_type;

        public sg_cull_mode cull_mode;

        public sg_face_winding face_winding;

        public int sample_count;

        public sg_color blend_color;

        [NativeTypeName("bool")]
        public byte alpha_to_coverage_enabled;

        [NativeTypeName("const char *")]
        public sbyte* label;

        [NativeTypeName("uint32_t")]
        public uint _end_canary;

        [InlineArray(4)]
        public partial struct _colors_e__FixedBuffer
        {
            public sg_color_target_state e0;
        }
    }

    public partial struct sg_pass_attachment_desc
    {
        public sg_image image;

        public int mip_level;

        public int slice;
    }

    public unsafe partial struct sg_pass_desc
    {
        [NativeTypeName("uint32_t")]
        public uint _start_canary;

        [NativeTypeName("sg_pass_attachment_desc[4]")]
        public _color_attachments_e__FixedBuffer color_attachments;

        [NativeTypeName("sg_pass_attachment_desc[4]")]
        public _resolve_attachments_e__FixedBuffer resolve_attachments;

        public sg_pass_attachment_desc depth_stencil_attachment;

        [NativeTypeName("const char *")]
        public sbyte* label;

        [NativeTypeName("uint32_t")]
        public uint _end_canary;

        [InlineArray(4)]
        public partial struct _color_attachments_e__FixedBuffer
        {
            public sg_pass_attachment_desc e0;
        }

        [InlineArray(4)]
        public partial struct _resolve_attachments_e__FixedBuffer
        {
            public sg_pass_attachment_desc e0;
        }
    }

    public unsafe partial struct sg_trace_hooks
    {
        public void* user_data;

        [NativeTypeName("void (*)(void *)")]
        public delegate* unmanaged[Cdecl]<void*, void> reset_state_cache;

        [NativeTypeName("void (*)(const sg_buffer_desc *, sg_buffer, void *)")]
        public delegate* unmanaged[Cdecl]<sg_buffer_desc*, sg_buffer, void*, void> make_buffer;

        [NativeTypeName("void (*)(const sg_image_desc *, sg_image, void *)")]
        public delegate* unmanaged[Cdecl]<sg_image_desc*, sg_image, void*, void> make_image;

        [NativeTypeName("void (*)(const sg_sampler_desc *, sg_sampler, void *)")]
        public delegate* unmanaged[Cdecl]<sg_sampler_desc*, sg_sampler, void*, void> make_sampler;

        [NativeTypeName("void (*)(const sg_shader_desc *, sg_shader, void *)")]
        public delegate* unmanaged[Cdecl]<sg_shader_desc*, sg_shader, void*, void> make_shader;

        [NativeTypeName("void (*)(const sg_pipeline_desc *, sg_pipeline, void *)")]
        public delegate* unmanaged[Cdecl]<sg_pipeline_desc*, sg_pipeline, void*, void> make_pipeline;

        [NativeTypeName("void (*)(const sg_pass_desc *, sg_pass, void *)")]
        public delegate* unmanaged[Cdecl]<sg_pass_desc*, sg_pass, void*, void> make_pass;

        [NativeTypeName("void (*)(sg_buffer, void *)")]
        public delegate* unmanaged[Cdecl]<sg_buffer, void*, void> destroy_buffer;

        [NativeTypeName("void (*)(sg_image, void *)")]
        public delegate* unmanaged[Cdecl]<sg_image, void*, void> destroy_image;

        [NativeTypeName("void (*)(sg_sampler, void *)")]
        public delegate* unmanaged[Cdecl]<sg_sampler, void*, void> destroy_sampler;

        [NativeTypeName("void (*)(sg_shader, void *)")]
        public delegate* unmanaged[Cdecl]<sg_shader, void*, void> destroy_shader;

        [NativeTypeName("void (*)(sg_pipeline, void *)")]
        public delegate* unmanaged[Cdecl]<sg_pipeline, void*, void> destroy_pipeline;

        [NativeTypeName("void (*)(sg_pass, void *)")]
        public delegate* unmanaged[Cdecl]<sg_pass, void*, void> destroy_pass;

        [NativeTypeName("void (*)(sg_buffer, const sg_range *, void *)")]
        public delegate* unmanaged[Cdecl]<sg_buffer, sg_range*, void*, void> update_buffer;

        [NativeTypeName("void (*)(sg_image, const sg_image_data *, void *)")]
        public delegate* unmanaged[Cdecl]<sg_image, sg_image_data*, void*, void> update_image;

        [NativeTypeName("void (*)(sg_buffer, const sg_range *, int, void *)")]
        public delegate* unmanaged[Cdecl]<sg_buffer, sg_range*, int, void*, void> append_buffer;

        [NativeTypeName("void (*)(const sg_pass_action *, int, int, void *)")]
        public delegate* unmanaged[Cdecl]<sg_pass_action*, int, int, void*, void> begin_default_pass;

        [NativeTypeName("void (*)(sg_pass, const sg_pass_action *, void *)")]
        public delegate* unmanaged[Cdecl]<sg_pass, sg_pass_action*, void*, void> begin_pass;

        [NativeTypeName("void (*)(int, int, int, int, bool, void *)")]
        public delegate* unmanaged[Cdecl]<int, int, int, int, byte, void*, void> apply_viewport;

        [NativeTypeName("void (*)(int, int, int, int, bool, void *)")]
        public delegate* unmanaged[Cdecl]<int, int, int, int, byte, void*, void> apply_scissor_rect;

        [NativeTypeName("void (*)(sg_pipeline, void *)")]
        public delegate* unmanaged[Cdecl]<sg_pipeline, void*, void> apply_pipeline;

        [NativeTypeName("void (*)(const sg_bindings *, void *)")]
        public delegate* unmanaged[Cdecl]<sg_bindings*, void*, void> apply_bindings;

        [NativeTypeName("void (*)(sg_shader_stage, int, const sg_range *, void *)")]
        public delegate* unmanaged[Cdecl]<sg_shader_stage, int, sg_range*, void*, void> apply_uniforms;

        [NativeTypeName("void (*)(int, int, int, void *)")]
        public delegate* unmanaged[Cdecl]<int, int, int, void*, void> draw;

        [NativeTypeName("void (*)(void *)")]
        public delegate* unmanaged[Cdecl]<void*, void> end_pass;

        [NativeTypeName("void (*)(void *)")]
        public delegate* unmanaged[Cdecl]<void*, void> commit;

        [NativeTypeName("void (*)(sg_buffer, void *)")]
        public delegate* unmanaged[Cdecl]<sg_buffer, void*, void> alloc_buffer;

        [NativeTypeName("void (*)(sg_image, void *)")]
        public delegate* unmanaged[Cdecl]<sg_image, void*, void> alloc_image;

        [NativeTypeName("void (*)(sg_sampler, void *)")]
        public delegate* unmanaged[Cdecl]<sg_sampler, void*, void> alloc_sampler;

        [NativeTypeName("void (*)(sg_shader, void *)")]
        public delegate* unmanaged[Cdecl]<sg_shader, void*, void> alloc_shader;

        [NativeTypeName("void (*)(sg_pipeline, void *)")]
        public delegate* unmanaged[Cdecl]<sg_pipeline, void*, void> alloc_pipeline;

        [NativeTypeName("void (*)(sg_pass, void *)")]
        public delegate* unmanaged[Cdecl]<sg_pass, void*, void> alloc_pass;

        [NativeTypeName("void (*)(sg_buffer, void *)")]
        public delegate* unmanaged[Cdecl]<sg_buffer, void*, void> dealloc_buffer;

        [NativeTypeName("void (*)(sg_image, void *)")]
        public delegate* unmanaged[Cdecl]<sg_image, void*, void> dealloc_image;

        [NativeTypeName("void (*)(sg_sampler, void *)")]
        public delegate* unmanaged[Cdecl]<sg_sampler, void*, void> dealloc_sampler;

        [NativeTypeName("void (*)(sg_shader, void *)")]
        public delegate* unmanaged[Cdecl]<sg_shader, void*, void> dealloc_shader;

        [NativeTypeName("void (*)(sg_pipeline, void *)")]
        public delegate* unmanaged[Cdecl]<sg_pipeline, void*, void> dealloc_pipeline;

        [NativeTypeName("void (*)(sg_pass, void *)")]
        public delegate* unmanaged[Cdecl]<sg_pass, void*, void> dealloc_pass;

        [NativeTypeName("void (*)(sg_buffer, const sg_buffer_desc *, void *)")]
        public delegate* unmanaged[Cdecl]<sg_buffer, sg_buffer_desc*, void*, void> init_buffer;

        [NativeTypeName("void (*)(sg_image, const sg_image_desc *, void *)")]
        public delegate* unmanaged[Cdecl]<sg_image, sg_image_desc*, void*, void> init_image;

        [NativeTypeName("void (*)(sg_sampler, const sg_sampler_desc *, void *)")]
        public delegate* unmanaged[Cdecl]<sg_sampler, sg_sampler_desc*, void*, void> init_sampler;

        [NativeTypeName("void (*)(sg_shader, const sg_shader_desc *, void *)")]
        public delegate* unmanaged[Cdecl]<sg_shader, sg_shader_desc*, void*, void> init_shader;

        [NativeTypeName("void (*)(sg_pipeline, const sg_pipeline_desc *, void *)")]
        public delegate* unmanaged[Cdecl]<sg_pipeline, sg_pipeline_desc*, void*, void> init_pipeline;

        [NativeTypeName("void (*)(sg_pass, const sg_pass_desc *, void *)")]
        public delegate* unmanaged[Cdecl]<sg_pass, sg_pass_desc*, void*, void> init_pass;

        [NativeTypeName("void (*)(sg_buffer, void *)")]
        public delegate* unmanaged[Cdecl]<sg_buffer, void*, void> uninit_buffer;

        [NativeTypeName("void (*)(sg_image, void *)")]
        public delegate* unmanaged[Cdecl]<sg_image, void*, void> uninit_image;

        [NativeTypeName("void (*)(sg_sampler, void *)")]
        public delegate* unmanaged[Cdecl]<sg_sampler, void*, void> uninit_sampler;

        [NativeTypeName("void (*)(sg_shader, void *)")]
        public delegate* unmanaged[Cdecl]<sg_shader, void*, void> uninit_shader;

        [NativeTypeName("void (*)(sg_pipeline, void *)")]
        public delegate* unmanaged[Cdecl]<sg_pipeline, void*, void> uninit_pipeline;

        [NativeTypeName("void (*)(sg_pass, void *)")]
        public delegate* unmanaged[Cdecl]<sg_pass, void*, void> uninit_pass;

        [NativeTypeName("void (*)(sg_buffer, void *)")]
        public delegate* unmanaged[Cdecl]<sg_buffer, void*, void> fail_buffer;

        [NativeTypeName("void (*)(sg_image, void *)")]
        public delegate* unmanaged[Cdecl]<sg_image, void*, void> fail_image;

        [NativeTypeName("void (*)(sg_sampler, void *)")]
        public delegate* unmanaged[Cdecl]<sg_sampler, void*, void> fail_sampler;

        [NativeTypeName("void (*)(sg_shader, void *)")]
        public delegate* unmanaged[Cdecl]<sg_shader, void*, void> fail_shader;

        [NativeTypeName("void (*)(sg_pipeline, void *)")]
        public delegate* unmanaged[Cdecl]<sg_pipeline, void*, void> fail_pipeline;

        [NativeTypeName("void (*)(sg_pass, void *)")]
        public delegate* unmanaged[Cdecl]<sg_pass, void*, void> fail_pass;

        [NativeTypeName("void (*)(const char *, void *)")]
        public delegate* unmanaged[Cdecl]<sbyte*, void*, void> push_debug_group;

        [NativeTypeName("void (*)(void *)")]
        public delegate* unmanaged[Cdecl]<void*, void> pop_debug_group;
    }

    public partial struct sg_slot_info
    {
        public sg_resource_state state;

        [NativeTypeName("uint32_t")]
        public uint res_id;

        [NativeTypeName("uint32_t")]
        public uint ctx_id;
    }

    public partial struct sg_buffer_info
    {
        public sg_slot_info slot;

        [NativeTypeName("uint32_t")]
        public uint update_frame_index;

        [NativeTypeName("uint32_t")]
        public uint append_frame_index;

        public int append_pos;

        [NativeTypeName("bool")]
        public byte append_overflow;

        public int num_slots;

        public int active_slot;
    }

    public partial struct sg_image_info
    {
        public sg_slot_info slot;

        [NativeTypeName("uint32_t")]
        public uint upd_frame_index;

        public int num_slots;

        public int active_slot;
    }

    public partial struct sg_sampler_info
    {
        public sg_slot_info slot;
    }

    public partial struct sg_shader_info
    {
        public sg_slot_info slot;
    }

    public partial struct sg_pipeline_info
    {
        public sg_slot_info slot;
    }

    public partial struct sg_pass_info
    {
        public sg_slot_info slot;
    }

    public partial struct sg_frame_stats_gl
    {
        [NativeTypeName("uint32_t")]
        public uint num_bind_buffer;

        [NativeTypeName("uint32_t")]
        public uint num_active_texture;

        [NativeTypeName("uint32_t")]
        public uint num_bind_texture;

        [NativeTypeName("uint32_t")]
        public uint num_bind_sampler;

        [NativeTypeName("uint32_t")]
        public uint num_use_program;

        [NativeTypeName("uint32_t")]
        public uint num_render_state;

        [NativeTypeName("uint32_t")]
        public uint num_vertex_attrib_pointer;

        [NativeTypeName("uint32_t")]
        public uint num_vertex_attrib_divisor;

        [NativeTypeName("uint32_t")]
        public uint num_enable_vertex_attrib_array;

        [NativeTypeName("uint32_t")]
        public uint num_disable_vertex_attrib_array;

        [NativeTypeName("uint32_t")]
        public uint num_uniform;
    }

    public partial struct sg_frame_stats_d3d11_pass
    {
        [NativeTypeName("uint32_t")]
        public uint num_om_set_render_targets;

        [NativeTypeName("uint32_t")]
        public uint num_clear_render_target_view;

        [NativeTypeName("uint32_t")]
        public uint num_clear_depth_stencil_view;

        [NativeTypeName("uint32_t")]
        public uint num_resolve_subresource;
    }

    public partial struct sg_frame_stats_d3d11_pipeline
    {
        [NativeTypeName("uint32_t")]
        public uint num_rs_set_state;

        [NativeTypeName("uint32_t")]
        public uint num_om_set_depth_stencil_state;

        [NativeTypeName("uint32_t")]
        public uint num_om_set_blend_state;

        [NativeTypeName("uint32_t")]
        public uint num_ia_set_primitive_topology;

        [NativeTypeName("uint32_t")]
        public uint num_ia_set_input_layout;

        [NativeTypeName("uint32_t")]
        public uint num_vs_set_shader;

        [NativeTypeName("uint32_t")]
        public uint num_vs_set_constant_buffers;

        [NativeTypeName("uint32_t")]
        public uint num_ps_set_shader;

        [NativeTypeName("uint32_t")]
        public uint num_ps_set_constant_buffers;
    }

    public partial struct sg_frame_stats_d3d11_bindings
    {
        [NativeTypeName("uint32_t")]
        public uint num_ia_set_vertex_buffers;

        [NativeTypeName("uint32_t")]
        public uint num_ia_set_index_buffer;

        [NativeTypeName("uint32_t")]
        public uint num_vs_set_shader_resources;

        [NativeTypeName("uint32_t")]
        public uint num_ps_set_shader_resources;

        [NativeTypeName("uint32_t")]
        public uint num_vs_set_samplers;

        [NativeTypeName("uint32_t")]
        public uint num_ps_set_samplers;
    }

    public partial struct sg_frame_stats_d3d11_uniforms
    {
        [NativeTypeName("uint32_t")]
        public uint num_update_subresource;
    }

    public partial struct sg_frame_stats_d3d11_draw
    {
        [NativeTypeName("uint32_t")]
        public uint num_draw_indexed_instanced;

        [NativeTypeName("uint32_t")]
        public uint num_draw_indexed;

        [NativeTypeName("uint32_t")]
        public uint num_draw_instanced;

        [NativeTypeName("uint32_t")]
        public uint num_draw;
    }

    public partial struct sg_frame_stats_d3d11
    {
        public sg_frame_stats_d3d11_pass pass;

        public sg_frame_stats_d3d11_pipeline pipeline;

        public sg_frame_stats_d3d11_bindings bindings;

        public sg_frame_stats_d3d11_uniforms uniforms;

        public sg_frame_stats_d3d11_draw draw;

        [NativeTypeName("uint32_t")]
        public uint num_map;

        [NativeTypeName("uint32_t")]
        public uint num_unmap;
    }

    public partial struct sg_frame_stats_metal_idpool
    {
        [NativeTypeName("uint32_t")]
        public uint num_added;

        [NativeTypeName("uint32_t")]
        public uint num_released;

        [NativeTypeName("uint32_t")]
        public uint num_garbage_collected;
    }

    public partial struct sg_frame_stats_metal_pipeline
    {
        [NativeTypeName("uint32_t")]
        public uint num_set_blend_color;

        [NativeTypeName("uint32_t")]
        public uint num_set_cull_mode;

        [NativeTypeName("uint32_t")]
        public uint num_set_front_facing_winding;

        [NativeTypeName("uint32_t")]
        public uint num_set_stencil_reference_value;

        [NativeTypeName("uint32_t")]
        public uint num_set_depth_bias;

        [NativeTypeName("uint32_t")]
        public uint num_set_render_pipeline_state;

        [NativeTypeName("uint32_t")]
        public uint num_set_depth_stencil_state;
    }

    public partial struct sg_frame_stats_metal_bindings
    {
        [NativeTypeName("uint32_t")]
        public uint num_set_vertex_buffer;

        [NativeTypeName("uint32_t")]
        public uint num_set_vertex_texture;

        [NativeTypeName("uint32_t")]
        public uint num_set_vertex_sampler_state;

        [NativeTypeName("uint32_t")]
        public uint num_set_fragment_texture;

        [NativeTypeName("uint32_t")]
        public uint num_set_fragment_sampler_state;
    }

    public partial struct sg_frame_stats_metal_uniforms
    {
        [NativeTypeName("uint32_t")]
        public uint num_set_vertex_buffer_offset;

        [NativeTypeName("uint32_t")]
        public uint num_set_fragment_buffer_offset;
    }

    public partial struct sg_frame_stats_metal
    {
        public sg_frame_stats_metal_idpool idpool;

        public sg_frame_stats_metal_pipeline pipeline;

        public sg_frame_stats_metal_bindings bindings;

        public sg_frame_stats_metal_uniforms uniforms;
    }

    public partial struct sg_frame_stats_wgpu_uniforms
    {
        [NativeTypeName("uint32_t")]
        public uint num_set_bindgroup;

        [NativeTypeName("uint32_t")]
        public uint size_write_buffer;
    }

    public partial struct sg_frame_stats_wgpu_bindings
    {
        [NativeTypeName("uint32_t")]
        public uint num_set_vertex_buffer;

        [NativeTypeName("uint32_t")]
        public uint num_skip_redundant_vertex_buffer;

        [NativeTypeName("uint32_t")]
        public uint num_set_index_buffer;

        [NativeTypeName("uint32_t")]
        public uint num_skip_redundant_index_buffer;

        [NativeTypeName("uint32_t")]
        public uint num_create_bindgroup;

        [NativeTypeName("uint32_t")]
        public uint num_discard_bindgroup;

        [NativeTypeName("uint32_t")]
        public uint num_set_bindgroup;

        [NativeTypeName("uint32_t")]
        public uint num_skip_redundant_bindgroup;

        [NativeTypeName("uint32_t")]
        public uint num_bindgroup_cache_hits;

        [NativeTypeName("uint32_t")]
        public uint num_bindgroup_cache_misses;

        [NativeTypeName("uint32_t")]
        public uint num_bindgroup_cache_collisions;

        [NativeTypeName("uint32_t")]
        public uint num_bindgroup_cache_hash_vs_key_mismatch;
    }

    public partial struct sg_frame_stats_wgpu
    {
        public sg_frame_stats_wgpu_uniforms uniforms;

        public sg_frame_stats_wgpu_bindings bindings;
    }

    public partial struct sg_frame_stats
    {
        [NativeTypeName("uint32_t")]
        public uint frame_index;

        [NativeTypeName("uint32_t")]
        public uint num_passes;

        [NativeTypeName("uint32_t")]
        public uint num_apply_viewport;

        [NativeTypeName("uint32_t")]
        public uint num_apply_scissor_rect;

        [NativeTypeName("uint32_t")]
        public uint num_apply_pipeline;

        [NativeTypeName("uint32_t")]
        public uint num_apply_bindings;

        [NativeTypeName("uint32_t")]
        public uint num_apply_uniforms;

        [NativeTypeName("uint32_t")]
        public uint num_draw;

        [NativeTypeName("uint32_t")]
        public uint num_update_buffer;

        [NativeTypeName("uint32_t")]
        public uint num_append_buffer;

        [NativeTypeName("uint32_t")]
        public uint num_update_image;

        [NativeTypeName("uint32_t")]
        public uint size_apply_uniforms;

        [NativeTypeName("uint32_t")]
        public uint size_update_buffer;

        [NativeTypeName("uint32_t")]
        public uint size_append_buffer;

        [NativeTypeName("uint32_t")]
        public uint size_update_image;

        public sg_frame_stats_gl gl;

        public sg_frame_stats_d3d11 d3d11;

        public sg_frame_stats_metal metal;

        public sg_frame_stats_wgpu wgpu;
    }

    [NativeTypeName("unsigned int")]
    public enum sg_log_item : uint
    {
        SG_LOGITEM_OK,
        SG_LOGITEM_MALLOC_FAILED,
        SG_LOGITEM_GL_TEXTURE_FORMAT_NOT_SUPPORTED,
        SG_LOGITEM_GL_3D_TEXTURES_NOT_SUPPORTED,
        SG_LOGITEM_GL_ARRAY_TEXTURES_NOT_SUPPORTED,
        SG_LOGITEM_GL_SHADER_COMPILATION_FAILED,
        SG_LOGITEM_GL_SHADER_LINKING_FAILED,
        SG_LOGITEM_GL_VERTEX_ATTRIBUTE_NOT_FOUND_IN_SHADER,
        SG_LOGITEM_GL_TEXTURE_NAME_NOT_FOUND_IN_SHADER,
        SG_LOGITEM_GL_FRAMEBUFFER_STATUS_UNDEFINED,
        SG_LOGITEM_GL_FRAMEBUFFER_STATUS_INCOMPLETE_ATTACHMENT,
        SG_LOGITEM_GL_FRAMEBUFFER_STATUS_INCOMPLETE_MISSING_ATTACHMENT,
        SG_LOGITEM_GL_FRAMEBUFFER_STATUS_UNSUPPORTED,
        SG_LOGITEM_GL_FRAMEBUFFER_STATUS_INCOMPLETE_MULTISAMPLE,
        SG_LOGITEM_GL_FRAMEBUFFER_STATUS_UNKNOWN,
        SG_LOGITEM_D3D11_CREATE_BUFFER_FAILED,
        SG_LOGITEM_D3D11_CREATE_DEPTH_TEXTURE_UNSUPPORTED_PIXEL_FORMAT,
        SG_LOGITEM_D3D11_CREATE_DEPTH_TEXTURE_FAILED,
        SG_LOGITEM_D3D11_CREATE_2D_TEXTURE_UNSUPPORTED_PIXEL_FORMAT,
        SG_LOGITEM_D3D11_CREATE_2D_TEXTURE_FAILED,
        SG_LOGITEM_D3D11_CREATE_2D_SRV_FAILED,
        SG_LOGITEM_D3D11_CREATE_3D_TEXTURE_UNSUPPORTED_PIXEL_FORMAT,
        SG_LOGITEM_D3D11_CREATE_3D_TEXTURE_FAILED,
        SG_LOGITEM_D3D11_CREATE_3D_SRV_FAILED,
        SG_LOGITEM_D3D11_CREATE_MSAA_TEXTURE_FAILED,
        SG_LOGITEM_D3D11_CREATE_SAMPLER_STATE_FAILED,
        SG_LOGITEM_D3D11_LOAD_D3DCOMPILER_47_DLL_FAILED,
        SG_LOGITEM_D3D11_SHADER_COMPILATION_FAILED,
        SG_LOGITEM_D3D11_SHADER_COMPILATION_OUTPUT,
        SG_LOGITEM_D3D11_CREATE_CONSTANT_BUFFER_FAILED,
        SG_LOGITEM_D3D11_CREATE_INPUT_LAYOUT_FAILED,
        SG_LOGITEM_D3D11_CREATE_RASTERIZER_STATE_FAILED,
        SG_LOGITEM_D3D11_CREATE_DEPTH_STENCIL_STATE_FAILED,
        SG_LOGITEM_D3D11_CREATE_BLEND_STATE_FAILED,
        SG_LOGITEM_D3D11_CREATE_RTV_FAILED,
        SG_LOGITEM_D3D11_CREATE_DSV_FAILED,
        SG_LOGITEM_D3D11_MAP_FOR_UPDATE_BUFFER_FAILED,
        SG_LOGITEM_D3D11_MAP_FOR_APPEND_BUFFER_FAILED,
        SG_LOGITEM_D3D11_MAP_FOR_UPDATE_IMAGE_FAILED,
        SG_LOGITEM_METAL_CREATE_BUFFER_FAILED,
        SG_LOGITEM_METAL_TEXTURE_FORMAT_NOT_SUPPORTED,
        SG_LOGITEM_METAL_CREATE_TEXTURE_FAILED,
        SG_LOGITEM_METAL_CREATE_SAMPLER_FAILED,
        SG_LOGITEM_METAL_SHADER_COMPILATION_FAILED,
        SG_LOGITEM_METAL_SHADER_CREATION_FAILED,
        SG_LOGITEM_METAL_SHADER_COMPILATION_OUTPUT,
        SG_LOGITEM_METAL_VERTEX_SHADER_ENTRY_NOT_FOUND,
        SG_LOGITEM_METAL_FRAGMENT_SHADER_ENTRY_NOT_FOUND,
        SG_LOGITEM_METAL_CREATE_RPS_FAILED,
        SG_LOGITEM_METAL_CREATE_RPS_OUTPUT,
        SG_LOGITEM_METAL_CREATE_DSS_FAILED,
        SG_LOGITEM_WGPU_BINDGROUPS_POOL_EXHAUSTED,
        SG_LOGITEM_WGPU_BINDGROUPSCACHE_SIZE_GREATER_ONE,
        SG_LOGITEM_WGPU_BINDGROUPSCACHE_SIZE_POW2,
        SG_LOGITEM_WGPU_CREATEBINDGROUP_FAILED,
        SG_LOGITEM_WGPU_CREATE_BUFFER_FAILED,
        SG_LOGITEM_WGPU_CREATE_TEXTURE_FAILED,
        SG_LOGITEM_WGPU_CREATE_TEXTURE_VIEW_FAILED,
        SG_LOGITEM_WGPU_CREATE_SAMPLER_FAILED,
        SG_LOGITEM_WGPU_CREATE_SHADER_MODULE_FAILED,
        SG_LOGITEM_WGPU_SHADER_TOO_MANY_IMAGES,
        SG_LOGITEM_WGPU_SHADER_TOO_MANY_SAMPLERS,
        SG_LOGITEM_WGPU_SHADER_CREATE_BINDGROUP_LAYOUT_FAILED,
        SG_LOGITEM_WGPU_CREATE_PIPELINE_LAYOUT_FAILED,
        SG_LOGITEM_WGPU_CREATE_RENDER_PIPELINE_FAILED,
        SG_LOGITEM_WGPU_PASS_CREATE_TEXTURE_VIEW_FAILED,
        SG_LOGITEM_UNINIT_BUFFER_ACTIVE_CONTEXT_MISMATCH,
        SG_LOGITEM_UNINIT_IMAGE_ACTIVE_CONTEXT_MISMATCH,
        SG_LOGITEM_UNINIT_SAMPLER_ACTIVE_CONTEXT_MISMATCH,
        SG_LOGITEM_UNINIT_SHADER_ACTIVE_CONTEXT_MISMATCH,
        SG_LOGITEM_UNINIT_PIPELINE_ACTIVE_CONTEXT_MISMATCH,
        SG_LOGITEM_UNINIT_PASS_ACTIVE_CONTEXT_MISMATCH,
        SG_LOGITEM_IDENTICAL_COMMIT_LISTENER,
        SG_LOGITEM_COMMIT_LISTENER_ARRAY_FULL,
        SG_LOGITEM_TRACE_HOOKS_NOT_ENABLED,
        SG_LOGITEM_DEALLOC_BUFFER_INVALID_STATE,
        SG_LOGITEM_DEALLOC_IMAGE_INVALID_STATE,
        SG_LOGITEM_DEALLOC_SAMPLER_INVALID_STATE,
        SG_LOGITEM_DEALLOC_SHADER_INVALID_STATE,
        SG_LOGITEM_DEALLOC_PIPELINE_INVALID_STATE,
        SG_LOGITEM_DEALLOC_PASS_INVALID_STATE,
        SG_LOGITEM_INIT_BUFFER_INVALID_STATE,
        SG_LOGITEM_INIT_IMAGE_INVALID_STATE,
        SG_LOGITEM_INIT_SAMPLER_INVALID_STATE,
        SG_LOGITEM_INIT_SHADER_INVALID_STATE,
        SG_LOGITEM_INIT_PIPELINE_INVALID_STATE,
        SG_LOGITEM_INIT_PASS_INVALID_STATE,
        SG_LOGITEM_UNINIT_BUFFER_INVALID_STATE,
        SG_LOGITEM_UNINIT_IMAGE_INVALID_STATE,
        SG_LOGITEM_UNINIT_SAMPLER_INVALID_STATE,
        SG_LOGITEM_UNINIT_SHADER_INVALID_STATE,
        SG_LOGITEM_UNINIT_PIPELINE_INVALID_STATE,
        SG_LOGITEM_UNINIT_PASS_INVALID_STATE,
        SG_LOGITEM_FAIL_BUFFER_INVALID_STATE,
        SG_LOGITEM_FAIL_IMAGE_INVALID_STATE,
        SG_LOGITEM_FAIL_SAMPLER_INVALID_STATE,
        SG_LOGITEM_FAIL_SHADER_INVALID_STATE,
        SG_LOGITEM_FAIL_PIPELINE_INVALID_STATE,
        SG_LOGITEM_FAIL_PASS_INVALID_STATE,
        SG_LOGITEM_BUFFER_POOL_EXHAUSTED,
        SG_LOGITEM_IMAGE_POOL_EXHAUSTED,
        SG_LOGITEM_SAMPLER_POOL_EXHAUSTED,
        SG_LOGITEM_SHADER_POOL_EXHAUSTED,
        SG_LOGITEM_PIPELINE_POOL_EXHAUSTED,
        SG_LOGITEM_PASS_POOL_EXHAUSTED,
        SG_LOGITEM_DRAW_WITHOUT_BINDINGS,
        SG_LOGITEM_VALIDATE_BUFFERDESC_CANARY,
        SG_LOGITEM_VALIDATE_BUFFERDESC_SIZE,
        SG_LOGITEM_VALIDATE_BUFFERDESC_DATA,
        SG_LOGITEM_VALIDATE_BUFFERDESC_DATA_SIZE,
        SG_LOGITEM_VALIDATE_BUFFERDESC_NO_DATA,
        SG_LOGITEM_VALIDATE_IMAGEDATA_NODATA,
        SG_LOGITEM_VALIDATE_IMAGEDATA_DATA_SIZE,
        SG_LOGITEM_VALIDATE_IMAGEDESC_CANARY,
        SG_LOGITEM_VALIDATE_IMAGEDESC_WIDTH,
        SG_LOGITEM_VALIDATE_IMAGEDESC_HEIGHT,
        SG_LOGITEM_VALIDATE_IMAGEDESC_RT_PIXELFORMAT,
        SG_LOGITEM_VALIDATE_IMAGEDESC_NONRT_PIXELFORMAT,
        SG_LOGITEM_VALIDATE_IMAGEDESC_MSAA_BUT_NO_RT,
        SG_LOGITEM_VALIDATE_IMAGEDESC_NO_MSAA_RT_SUPPORT,
        SG_LOGITEM_VALIDATE_IMAGEDESC_MSAA_NUM_MIPMAPS,
        SG_LOGITEM_VALIDATE_IMAGEDESC_MSAA_3D_IMAGE,
        SG_LOGITEM_VALIDATE_IMAGEDESC_DEPTH_3D_IMAGE,
        SG_LOGITEM_VALIDATE_IMAGEDESC_RT_IMMUTABLE,
        SG_LOGITEM_VALIDATE_IMAGEDESC_RT_NO_DATA,
        SG_LOGITEM_VALIDATE_IMAGEDESC_INJECTED_NO_DATA,
        SG_LOGITEM_VALIDATE_IMAGEDESC_DYNAMIC_NO_DATA,
        SG_LOGITEM_VALIDATE_IMAGEDESC_COMPRESSED_IMMUTABLE,
        SG_LOGITEM_VALIDATE_SAMPLERDESC_CANARY,
        SG_LOGITEM_VALIDATE_SAMPLERDESC_MINFILTER_NONE,
        SG_LOGITEM_VALIDATE_SAMPLERDESC_MAGFILTER_NONE,
        SG_LOGITEM_VALIDATE_SAMPLERDESC_ANISTROPIC_REQUIRES_LINEAR_FILTERING,
        SG_LOGITEM_VALIDATE_SHADERDESC_CANARY,
        SG_LOGITEM_VALIDATE_SHADERDESC_SOURCE,
        SG_LOGITEM_VALIDATE_SHADERDESC_BYTECODE,
        SG_LOGITEM_VALIDATE_SHADERDESC_SOURCE_OR_BYTECODE,
        SG_LOGITEM_VALIDATE_SHADERDESC_NO_BYTECODE_SIZE,
        SG_LOGITEM_VALIDATE_SHADERDESC_NO_CONT_UBS,
        SG_LOGITEM_VALIDATE_SHADERDESC_NO_CONT_UB_MEMBERS,
        SG_LOGITEM_VALIDATE_SHADERDESC_NO_UB_MEMBERS,
        SG_LOGITEM_VALIDATE_SHADERDESC_UB_MEMBER_NAME,
        SG_LOGITEM_VALIDATE_SHADERDESC_UB_SIZE_MISMATCH,
        SG_LOGITEM_VALIDATE_SHADERDESC_UB_ARRAY_COUNT,
        SG_LOGITEM_VALIDATE_SHADERDESC_UB_STD140_ARRAY_TYPE,
        SG_LOGITEM_VALIDATE_SHADERDESC_NO_CONT_IMAGES,
        SG_LOGITEM_VALIDATE_SHADERDESC_NO_CONT_SAMPLERS,
        SG_LOGITEM_VALIDATE_SHADERDESC_IMAGE_SAMPLER_PAIR_IMAGE_SLOT_OUT_OF_RANGE,
        SG_LOGITEM_VALIDATE_SHADERDESC_IMAGE_SAMPLER_PAIR_SAMPLER_SLOT_OUT_OF_RANGE,
        SG_LOGITEM_VALIDATE_SHADERDESC_IMAGE_SAMPLER_PAIR_NAME_REQUIRED_FOR_GL,
        SG_LOGITEM_VALIDATE_SHADERDESC_IMAGE_SAMPLER_PAIR_HAS_NAME_BUT_NOT_USED,
        SG_LOGITEM_VALIDATE_SHADERDESC_IMAGE_SAMPLER_PAIR_HAS_IMAGE_BUT_NOT_USED,
        SG_LOGITEM_VALIDATE_SHADERDESC_IMAGE_SAMPLER_PAIR_HAS_SAMPLER_BUT_NOT_USED,
        SG_LOGITEM_VALIDATE_SHADERDESC_NONFILTERING_SAMPLER_REQUIRED,
        SG_LOGITEM_VALIDATE_SHADERDESC_COMPARISON_SAMPLER_REQUIRED,
        SG_LOGITEM_VALIDATE_SHADERDESC_IMAGE_NOT_REFERENCED_BY_IMAGE_SAMPLER_PAIRS,
        SG_LOGITEM_VALIDATE_SHADERDESC_SAMPLER_NOT_REFERENCED_BY_IMAGE_SAMPLER_PAIRS,
        SG_LOGITEM_VALIDATE_SHADERDESC_NO_CONT_IMAGE_SAMPLER_PAIRS,
        SG_LOGITEM_VALIDATE_SHADERDESC_ATTR_SEMANTICS,
        SG_LOGITEM_VALIDATE_SHADERDESC_ATTR_STRING_TOO_LONG,
        SG_LOGITEM_VALIDATE_PIPELINEDESC_CANARY,
        SG_LOGITEM_VALIDATE_PIPELINEDESC_SHADER,
        SG_LOGITEM_VALIDATE_PIPELINEDESC_NO_ATTRS,
        SG_LOGITEM_VALIDATE_PIPELINEDESC_LAYOUT_STRIDE4,
        SG_LOGITEM_VALIDATE_PIPELINEDESC_ATTR_SEMANTICS,
        SG_LOGITEM_VALIDATE_PASSDESC_CANARY,
        SG_LOGITEM_VALIDATE_PASSDESC_NO_ATTACHMENTS,
        SG_LOGITEM_VALIDATE_PASSDESC_NO_CONT_COLOR_ATTS,
        SG_LOGITEM_VALIDATE_PASSDESC_IMAGE,
        SG_LOGITEM_VALIDATE_PASSDESC_MIPLEVEL,
        SG_LOGITEM_VALIDATE_PASSDESC_FACE,
        SG_LOGITEM_VALIDATE_PASSDESC_LAYER,
        SG_LOGITEM_VALIDATE_PASSDESC_SLICE,
        SG_LOGITEM_VALIDATE_PASSDESC_IMAGE_NO_RT,
        SG_LOGITEM_VALIDATE_PASSDESC_COLOR_INV_PIXELFORMAT,
        SG_LOGITEM_VALIDATE_PASSDESC_DEPTH_INV_PIXELFORMAT,
        SG_LOGITEM_VALIDATE_PASSDESC_IMAGE_SIZES,
        SG_LOGITEM_VALIDATE_PASSDESC_IMAGE_SAMPLE_COUNTS,
        SG_LOGITEM_VALIDATE_PASSDESC_RESOLVE_COLOR_IMAGE_MSAA,
        SG_LOGITEM_VALIDATE_PASSDESC_RESOLVE_IMAGE,
        SG_LOGITEM_VALIDATE_PASSDESC_RESOLVE_SAMPLE_COUNT,
        SG_LOGITEM_VALIDATE_PASSDESC_RESOLVE_MIPLEVEL,
        SG_LOGITEM_VALIDATE_PASSDESC_RESOLVE_FACE,
        SG_LOGITEM_VALIDATE_PASSDESC_RESOLVE_LAYER,
        SG_LOGITEM_VALIDATE_PASSDESC_RESOLVE_SLICE,
        SG_LOGITEM_VALIDATE_PASSDESC_RESOLVE_IMAGE_NO_RT,
        SG_LOGITEM_VALIDATE_PASSDESC_RESOLVE_IMAGE_SIZES,
        SG_LOGITEM_VALIDATE_PASSDESC_RESOLVE_IMAGE_FORMAT,
        SG_LOGITEM_VALIDATE_PASSDESC_DEPTH_IMAGE,
        SG_LOGITEM_VALIDATE_PASSDESC_DEPTH_MIPLEVEL,
        SG_LOGITEM_VALIDATE_PASSDESC_DEPTH_FACE,
        SG_LOGITEM_VALIDATE_PASSDESC_DEPTH_LAYER,
        SG_LOGITEM_VALIDATE_PASSDESC_DEPTH_SLICE,
        SG_LOGITEM_VALIDATE_PASSDESC_DEPTH_IMAGE_NO_RT,
        SG_LOGITEM_VALIDATE_PASSDESC_DEPTH_IMAGE_SIZES,
        SG_LOGITEM_VALIDATE_PASSDESC_DEPTH_IMAGE_SAMPLE_COUNT,
        SG_LOGITEM_VALIDATE_BEGINPASS_PASS,
        SG_LOGITEM_VALIDATE_BEGINPASS_COLOR_ATTACHMENT_IMAGE,
        SG_LOGITEM_VALIDATE_BEGINPASS_RESOLVE_ATTACHMENT_IMAGE,
        SG_LOGITEM_VALIDATE_BEGINPASS_DEPTHSTENCIL_ATTACHMENT_IMAGE,
        SG_LOGITEM_VALIDATE_APIP_PIPELINE_VALID_ID,
        SG_LOGITEM_VALIDATE_APIP_PIPELINE_EXISTS,
        SG_LOGITEM_VALIDATE_APIP_PIPELINE_VALID,
        SG_LOGITEM_VALIDATE_APIP_SHADER_EXISTS,
        SG_LOGITEM_VALIDATE_APIP_SHADER_VALID,
        SG_LOGITEM_VALIDATE_APIP_ATT_COUNT,
        SG_LOGITEM_VALIDATE_APIP_COLOR_FORMAT,
        SG_LOGITEM_VALIDATE_APIP_DEPTH_FORMAT,
        SG_LOGITEM_VALIDATE_APIP_SAMPLE_COUNT,
        SG_LOGITEM_VALIDATE_ABND_PIPELINE,
        SG_LOGITEM_VALIDATE_ABND_PIPELINE_EXISTS,
        SG_LOGITEM_VALIDATE_ABND_PIPELINE_VALID,
        SG_LOGITEM_VALIDATE_ABND_VBS,
        SG_LOGITEM_VALIDATE_ABND_VB_EXISTS,
        SG_LOGITEM_VALIDATE_ABND_VB_TYPE,
        SG_LOGITEM_VALIDATE_ABND_VB_OVERFLOW,
        SG_LOGITEM_VALIDATE_ABND_NO_IB,
        SG_LOGITEM_VALIDATE_ABND_IB,
        SG_LOGITEM_VALIDATE_ABND_IB_EXISTS,
        SG_LOGITEM_VALIDATE_ABND_IB_TYPE,
        SG_LOGITEM_VALIDATE_ABND_IB_OVERFLOW,
        SG_LOGITEM_VALIDATE_ABND_VS_EXPECTED_IMAGE_BINDING,
        SG_LOGITEM_VALIDATE_ABND_VS_IMG_EXISTS,
        SG_LOGITEM_VALIDATE_ABND_VS_IMAGE_TYPE_MISMATCH,
        SG_LOGITEM_VALIDATE_ABND_VS_IMAGE_MSAA,
        SG_LOGITEM_VALIDATE_ABND_VS_EXPECTED_FILTERABLE_IMAGE,
        SG_LOGITEM_VALIDATE_ABND_VS_EXPECTED_DEPTH_IMAGE,
        SG_LOGITEM_VALIDATE_ABND_VS_UNEXPECTED_IMAGE_BINDING,
        SG_LOGITEM_VALIDATE_ABND_VS_EXPECTED_SAMPLER_BINDING,
        SG_LOGITEM_VALIDATE_ABND_VS_UNEXPECTED_SAMPLER_COMPARE_NEVER,
        SG_LOGITEM_VALIDATE_ABND_VS_EXPECTED_SAMPLER_COMPARE_NEVER,
        SG_LOGITEM_VALIDATE_ABND_VS_EXPECTED_NONFILTERING_SAMPLER,
        SG_LOGITEM_VALIDATE_ABND_VS_UNEXPECTED_SAMPLER_BINDING,
        SG_LOGITEM_VALIDATE_ABND_VS_SMP_EXISTS,
        SG_LOGITEM_VALIDATE_ABND_FS_EXPECTED_IMAGE_BINDING,
        SG_LOGITEM_VALIDATE_ABND_FS_IMG_EXISTS,
        SG_LOGITEM_VALIDATE_ABND_FS_IMAGE_TYPE_MISMATCH,
        SG_LOGITEM_VALIDATE_ABND_FS_IMAGE_MSAA,
        SG_LOGITEM_VALIDATE_ABND_FS_EXPECTED_FILTERABLE_IMAGE,
        SG_LOGITEM_VALIDATE_ABND_FS_EXPECTED_DEPTH_IMAGE,
        SG_LOGITEM_VALIDATE_ABND_FS_UNEXPECTED_IMAGE_BINDING,
        SG_LOGITEM_VALIDATE_ABND_FS_EXPECTED_SAMPLER_BINDING,
        SG_LOGITEM_VALIDATE_ABND_FS_UNEXPECTED_SAMPLER_COMPARE_NEVER,
        SG_LOGITEM_VALIDATE_ABND_FS_EXPECTED_SAMPLER_COMPARE_NEVER,
        SG_LOGITEM_VALIDATE_ABND_FS_EXPECTED_NONFILTERING_SAMPLER,
        SG_LOGITEM_VALIDATE_ABND_FS_UNEXPECTED_SAMPLER_BINDING,
        SG_LOGITEM_VALIDATE_ABND_FS_SMP_EXISTS,
        SG_LOGITEM_VALIDATE_AUB_NO_PIPELINE,
        SG_LOGITEM_VALIDATE_AUB_NO_UB_AT_SLOT,
        SG_LOGITEM_VALIDATE_AUB_SIZE,
        SG_LOGITEM_VALIDATE_UPDATEBUF_USAGE,
        SG_LOGITEM_VALIDATE_UPDATEBUF_SIZE,
        SG_LOGITEM_VALIDATE_UPDATEBUF_ONCE,
        SG_LOGITEM_VALIDATE_UPDATEBUF_APPEND,
        SG_LOGITEM_VALIDATE_APPENDBUF_USAGE,
        SG_LOGITEM_VALIDATE_APPENDBUF_SIZE,
        SG_LOGITEM_VALIDATE_APPENDBUF_UPDATE,
        SG_LOGITEM_VALIDATE_UPDIMG_USAGE,
        SG_LOGITEM_VALIDATE_UPDIMG_ONCE,
        SG_LOGITEM_VALIDATION_FAILED,
    }

    public unsafe partial struct sg_metal_context_desc
    {
        [NativeTypeName("const void *")]
        public void* device;

        [NativeTypeName("const void *(*)()")]
        public delegate* unmanaged[Cdecl]<void*> renderpass_descriptor_cb;

        [NativeTypeName("const void *(*)(void *)")]
        public delegate* unmanaged[Cdecl]<void*, void*> renderpass_descriptor_userdata_cb;

        [NativeTypeName("const void *(*)()")]
        public delegate* unmanaged[Cdecl]<void*> drawable_cb;

        [NativeTypeName("const void *(*)(void *)")]
        public delegate* unmanaged[Cdecl]<void*, void*> drawable_userdata_cb;

        public void* user_data;
    }

    public unsafe partial struct sg_d3d11_context_desc
    {
        [NativeTypeName("const void *")]
        public void* device;

        [NativeTypeName("const void *")]
        public void* device_context;

        [NativeTypeName("const void *(*)()")]
        public delegate* unmanaged[Cdecl]<void*> render_target_view_cb;

        [NativeTypeName("const void *(*)(void *)")]
        public delegate* unmanaged[Cdecl]<void*, void*> render_target_view_userdata_cb;

        [NativeTypeName("const void *(*)()")]
        public delegate* unmanaged[Cdecl]<void*> depth_stencil_view_cb;

        [NativeTypeName("const void *(*)(void *)")]
        public delegate* unmanaged[Cdecl]<void*, void*> depth_stencil_view_userdata_cb;

        public void* user_data;
    }

    public unsafe partial struct sg_wgpu_context_desc
    {
        [NativeTypeName("const void *")]
        public void* device;

        [NativeTypeName("const void *(*)()")]
        public delegate* unmanaged[Cdecl]<void*> render_view_cb;

        [NativeTypeName("const void *(*)(void *)")]
        public delegate* unmanaged[Cdecl]<void*, void*> render_view_userdata_cb;

        [NativeTypeName("const void *(*)()")]
        public delegate* unmanaged[Cdecl]<void*> resolve_view_cb;

        [NativeTypeName("const void *(*)(void *)")]
        public delegate* unmanaged[Cdecl]<void*, void*> resolve_view_userdata_cb;

        [NativeTypeName("const void *(*)()")]
        public delegate* unmanaged[Cdecl]<void*> depth_stencil_view_cb;

        [NativeTypeName("const void *(*)(void *)")]
        public delegate* unmanaged[Cdecl]<void*, void*> depth_stencil_view_userdata_cb;

        public void* user_data;
    }

    public unsafe partial struct sg_gl_context_desc
    {
        [NativeTypeName("uint32_t (*)()")]
        public delegate* unmanaged[Cdecl]<uint> default_framebuffer_cb;

        [NativeTypeName("uint32_t (*)(void *)")]
        public delegate* unmanaged[Cdecl]<void*, uint> default_framebuffer_userdata_cb;

        public void* user_data;
    }

    public partial struct sg_context_desc
    {
        public sg_pixel_format color_format;

        public sg_pixel_format depth_format;

        public int sample_count;

        public sg_metal_context_desc metal;

        public sg_d3d11_context_desc d3d11;

        public sg_wgpu_context_desc wgpu;

        public sg_gl_context_desc gl;
    }

    public unsafe partial struct sg_commit_listener
    {
        [NativeTypeName("void (*)(void *)")]
        public delegate* unmanaged[Cdecl]<void*, void> func;

        public void* user_data;
    }

    public unsafe partial struct sg_allocator
    {
        [NativeTypeName("void *(*)(size_t, void *)")]
        public delegate* unmanaged[Cdecl]<nuint, void*, void*> alloc_fn;

        [NativeTypeName("void (*)(void *, void *)")]
        public delegate* unmanaged[Cdecl]<void*, void*, void> free_fn;

        public void* user_data;
    }

    public unsafe partial struct sg_logger
    {
        [NativeTypeName("void (*)(const char *, uint32_t, uint32_t, const char *, uint32_t, const char *, void *)")]
        public delegate* unmanaged[Cdecl]<sbyte*, uint, uint, sbyte*, uint, sbyte*, void*, void> func;

        public void* user_data;
    }

    public partial struct sg_desc
    {
        [NativeTypeName("uint32_t")]
        public uint _start_canary;

        public int buffer_pool_size;

        public int image_pool_size;

        public int sampler_pool_size;

        public int shader_pool_size;

        public int pipeline_pool_size;

        public int pass_pool_size;

        public int context_pool_size;

        public int uniform_buffer_size;

        public int max_commit_listeners;

        [NativeTypeName("bool")]
        public byte disable_validation;

        [NativeTypeName("bool")]
        public byte mtl_force_managed_storage_mode;

        [NativeTypeName("bool")]
        public byte wgpu_disable_bindgroups_cache;

        public int wgpu_bindgroups_cache_size;

        public sg_allocator allocator;

        public sg_logger logger;

        public sg_context_desc context;

        [NativeTypeName("uint32_t")]
        public uint _end_canary;
    }

    public unsafe partial struct sg_d3d11_buffer_info
    {
        [NativeTypeName("const void *")]
        public void* buf;
    }

    public unsafe partial struct sg_d3d11_image_info
    {
        [NativeTypeName("const void *")]
        public void* tex2d;

        [NativeTypeName("const void *")]
        public void* tex3d;

        [NativeTypeName("const void *")]
        public void* res;

        [NativeTypeName("const void *")]
        public void* srv;
    }

    public unsafe partial struct sg_d3d11_sampler_info
    {
        [NativeTypeName("const void *")]
        public void* smp;
    }

    public unsafe partial struct sg_d3d11_shader_info
    {
        [NativeTypeName("const void *[4]")]
        public _vs_cbufs_e__FixedBuffer vs_cbufs;

        [NativeTypeName("const void *[4]")]
        public _fs_cbufs_e__FixedBuffer fs_cbufs;

        [NativeTypeName("const void *")]
        public void* vs;

        [NativeTypeName("const void *")]
        public void* fs;

        public unsafe partial struct _vs_cbufs_e__FixedBuffer
        {
            public void* e0;
            public void* e1;
            public void* e2;
            public void* e3;

            public ref void* this[int index]
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get
                {
                    fixed (void** pThis = &e0)
                    {
                        return ref pThis[index];
                    }
                }
            }
        }

        public unsafe partial struct _fs_cbufs_e__FixedBuffer
        {
            public void* e0;
            public void* e1;
            public void* e2;
            public void* e3;

            public ref void* this[int index]
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get
                {
                    fixed (void** pThis = &e0)
                    {
                        return ref pThis[index];
                    }
                }
            }
        }
    }

    public unsafe partial struct sg_d3d11_pipeline_info
    {
        [NativeTypeName("const void *")]
        public void* il;

        [NativeTypeName("const void *")]
        public void* rs;

        [NativeTypeName("const void *")]
        public void* dss;

        [NativeTypeName("const void *")]
        public void* bs;
    }

    public unsafe partial struct sg_d3d11_pass_info
    {
        [NativeTypeName("const void *[4]")]
        public _color_rtv_e__FixedBuffer color_rtv;

        [NativeTypeName("const void *[4]")]
        public _resolve_rtv_e__FixedBuffer resolve_rtv;

        [NativeTypeName("const void *")]
        public void* dsv;

        public unsafe partial struct _color_rtv_e__FixedBuffer
        {
            public void* e0;
            public void* e1;
            public void* e2;
            public void* e3;

            public ref void* this[int index]
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get
                {
                    fixed (void** pThis = &e0)
                    {
                        return ref pThis[index];
                    }
                }
            }
        }

        public unsafe partial struct _resolve_rtv_e__FixedBuffer
        {
            public void* e0;
            public void* e1;
            public void* e2;
            public void* e3;

            public ref void* this[int index]
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get
                {
                    fixed (void** pThis = &e0)
                    {
                        return ref pThis[index];
                    }
                }
            }
        }
    }

    public partial struct sg_mtl_buffer_info
    {
        [NativeTypeName("const void *[2]")]
        public _buf_e__FixedBuffer buf;

        public int active_slot;

        public unsafe partial struct _buf_e__FixedBuffer
        {
            public void* e0;
            public void* e1;

            public ref void* this[int index]
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get
                {
                    fixed (void** pThis = &e0)
                    {
                        return ref pThis[index];
                    }
                }
            }
        }
    }

    public partial struct sg_mtl_image_info
    {
        [NativeTypeName("const void *[2]")]
        public _tex_e__FixedBuffer tex;

        public int active_slot;

        public unsafe partial struct _tex_e__FixedBuffer
        {
            public void* e0;
            public void* e1;

            public ref void* this[int index]
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get
                {
                    fixed (void** pThis = &e0)
                    {
                        return ref pThis[index];
                    }
                }
            }
        }
    }

    public unsafe partial struct sg_mtl_sampler_info
    {
        [NativeTypeName("const void *")]
        public void* smp;
    }

    public unsafe partial struct sg_mtl_shader_info
    {
        [NativeTypeName("const void *")]
        public void* vs_lib;

        [NativeTypeName("const void *")]
        public void* fs_lib;

        [NativeTypeName("const void *")]
        public void* vs_func;

        [NativeTypeName("const void *")]
        public void* fs_func;
    }

    public unsafe partial struct sg_mtl_pipeline_info
    {
        [NativeTypeName("const void *")]
        public void* rps;

        [NativeTypeName("const void *")]
        public void* dss;
    }

    public unsafe partial struct sg_wgpu_buffer_info
    {
        [NativeTypeName("const void *")]
        public void* buf;
    }

    public unsafe partial struct sg_wgpu_image_info
    {
        [NativeTypeName("const void *")]
        public void* tex;

        [NativeTypeName("const void *")]
        public void* view;
    }

    public unsafe partial struct sg_wgpu_sampler_info
    {
        [NativeTypeName("const void *")]
        public void* smp;
    }

    public unsafe partial struct sg_wgpu_shader_info
    {
        [NativeTypeName("const void *")]
        public void* vs_mod;

        [NativeTypeName("const void *")]
        public void* fs_mod;

        [NativeTypeName("const void *")]
        public void* bgl;
    }

    public unsafe partial struct sg_wgpu_pipeline_info
    {
        [NativeTypeName("const void *")]
        public void* pip;
    }

    public unsafe partial struct sg_wgpu_pass_info
    {
        [NativeTypeName("const void *[4]")]
        public _color_view_e__FixedBuffer color_view;

        [NativeTypeName("const void *[4]")]
        public _resolve_view_e__FixedBuffer resolve_view;

        [NativeTypeName("const void *")]
        public void* ds_view;

        public unsafe partial struct _color_view_e__FixedBuffer
        {
            public void* e0;
            public void* e1;
            public void* e2;
            public void* e3;

            public ref void* this[int index]
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get
                {
                    fixed (void** pThis = &e0)
                    {
                        return ref pThis[index];
                    }
                }
            }
        }

        public unsafe partial struct _resolve_view_e__FixedBuffer
        {
            public void* e0;
            public void* e1;
            public void* e2;
            public void* e3;

            public ref void* this[int index]
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get
                {
                    fixed (void** pThis = &e0)
                    {
                        return ref pThis[index];
                    }
                }
            }
        }
    }

    public partial struct sg_gl_buffer_info
    {
        [NativeTypeName("uint32_t[2]")]
        public _buf_e__FixedBuffer buf;

        public int active_slot;

        [InlineArray(2)]
        public partial struct _buf_e__FixedBuffer
        {
            public uint e0;
        }
    }

    public partial struct sg_gl_image_info
    {
        [NativeTypeName("uint32_t[2]")]
        public _tex_e__FixedBuffer tex;

        [NativeTypeName("uint32_t")]
        public uint tex_target;

        [NativeTypeName("uint32_t")]
        public uint msaa_render_buffer;

        public int active_slot;

        [InlineArray(2)]
        public partial struct _tex_e__FixedBuffer
        {
            public uint e0;
        }
    }

    public partial struct sg_gl_sampler_info
    {
        [NativeTypeName("uint32_t")]
        public uint smp;
    }

    public partial struct sg_gl_shader_info
    {
        [NativeTypeName("uint32_t")]
        public uint prog;
    }

    public partial struct sg_gl_pass_info
    {
        [NativeTypeName("uint32_t")]
        public uint frame_buffer;

        [NativeTypeName("uint32_t[4]")]
        public _msaa_resolve_framebuffer_e__FixedBuffer msaa_resolve_framebuffer;

        [InlineArray(4)]
        public partial struct _msaa_resolve_framebuffer_e__FixedBuffer
        {
            public uint e0;
        }
    }

    public static unsafe partial class Gfx
    {
        public const uint SG_INVALID_ID = 0;
        public const uint SG_NUM_SHADER_STAGES = 2;
        public const uint SG_NUM_INFLIGHT_FRAMES = 2;
        public const uint SG_MAX_COLOR_ATTACHMENTS = 4;
        public const uint SG_MAX_VERTEX_BUFFERS = 8;
        public const uint SG_MAX_SHADERSTAGE_IMAGES = 12;
        public const uint SG_MAX_SHADERSTAGE_SAMPLERS = 8;
        public const uint SG_MAX_SHADERSTAGE_IMAGESAMPLERPAIRS = 12;
        public const uint SG_MAX_SHADERSTAGE_UBS = 4;
        public const uint SG_MAX_UB_MEMBERS = 16;
        public const uint SG_MAX_VERTEX_ATTRIBUTES = 16;
        public const uint SG_MAX_MIPMAPS = 16;
        public const uint SG_MAX_TEXTUREARRAY_LAYERS = 128;

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_setup", ExactSpelling = true)]
        public static extern void setup([NativeTypeName("const sg_desc *")] sg_desc* desc);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_shutdown", ExactSpelling = true)]
        public static extern void shutdown();

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_isvalid", ExactSpelling = true)]
        [return: NativeTypeName("bool")]
        public static extern byte isvalid();

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_reset_state_cache", ExactSpelling = true)]
        public static extern void reset_state_cache();

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_install_trace_hooks", ExactSpelling = true)]
        public static extern sg_trace_hooks install_trace_hooks([NativeTypeName("const sg_trace_hooks *")] sg_trace_hooks* trace_hooks);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_push_debug_group", ExactSpelling = true)]
        public static extern void push_debug_group([NativeTypeName("const char *")] sbyte* name);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_pop_debug_group", ExactSpelling = true)]
        public static extern void pop_debug_group();

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_add_commit_listener", ExactSpelling = true)]
        [return: NativeTypeName("bool")]
        public static extern byte add_commit_listener(sg_commit_listener listener);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_remove_commit_listener", ExactSpelling = true)]
        [return: NativeTypeName("bool")]
        public static extern byte remove_commit_listener(sg_commit_listener listener);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_make_buffer", ExactSpelling = true)]
        public static extern sg_buffer make_buffer([NativeTypeName("const sg_buffer_desc *")] sg_buffer_desc* desc);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_make_image", ExactSpelling = true)]
        public static extern sg_image make_image([NativeTypeName("const sg_image_desc *")] sg_image_desc* desc);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_make_sampler", ExactSpelling = true)]
        public static extern sg_sampler make_sampler([NativeTypeName("const sg_sampler_desc *")] sg_sampler_desc* desc);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_make_shader", ExactSpelling = true)]
        public static extern sg_shader make_shader([NativeTypeName("const sg_shader_desc *")] sg_shader_desc* desc);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_make_pipeline", ExactSpelling = true)]
        public static extern sg_pipeline make_pipeline([NativeTypeName("const sg_pipeline_desc *")] sg_pipeline_desc* desc);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_make_pass", ExactSpelling = true)]
        public static extern sg_pass make_pass([NativeTypeName("const sg_pass_desc *")] sg_pass_desc* desc);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_destroy_buffer", ExactSpelling = true)]
        public static extern void destroy_buffer(sg_buffer buf);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_destroy_image", ExactSpelling = true)]
        public static extern void destroy_image(sg_image img);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_destroy_sampler", ExactSpelling = true)]
        public static extern void destroy_sampler(sg_sampler smp);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_destroy_shader", ExactSpelling = true)]
        public static extern void destroy_shader(sg_shader shd);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_destroy_pipeline", ExactSpelling = true)]
        public static extern void destroy_pipeline(sg_pipeline pip);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_destroy_pass", ExactSpelling = true)]
        public static extern void destroy_pass(sg_pass pass);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_update_buffer", ExactSpelling = true)]
        public static extern void update_buffer(sg_buffer buf, [NativeTypeName("const sg_range *")] sg_range* data);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_update_image", ExactSpelling = true)]
        public static extern void update_image(sg_image img, [NativeTypeName("const sg_image_data *")] sg_image_data* data);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_append_buffer", ExactSpelling = true)]
        public static extern int append_buffer(sg_buffer buf, [NativeTypeName("const sg_range *")] sg_range* data);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_query_buffer_overflow", ExactSpelling = true)]
        [return: NativeTypeName("bool")]
        public static extern byte query_buffer_overflow(sg_buffer buf);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_query_buffer_will_overflow", ExactSpelling = true)]
        [return: NativeTypeName("bool")]
        public static extern byte query_buffer_will_overflow(sg_buffer buf, [NativeTypeName("size_t")] nuint size);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_begin_default_pass", ExactSpelling = true)]
        public static extern void begin_default_pass([NativeTypeName("const sg_pass_action *")] sg_pass_action* pass_action, int width, int height);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_begin_default_passf", ExactSpelling = true)]
        public static extern void begin_default_passf([NativeTypeName("const sg_pass_action *")] sg_pass_action* pass_action, float width, float height);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_begin_pass", ExactSpelling = true)]
        public static extern void begin_pass(sg_pass pass, [NativeTypeName("const sg_pass_action *")] sg_pass_action* pass_action);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_apply_viewport", ExactSpelling = true)]
        public static extern void apply_viewport(int x, int y, int width, int height, [NativeTypeName("bool")] byte origin_top_left);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_apply_viewportf", ExactSpelling = true)]
        public static extern void apply_viewportf(float x, float y, float width, float height, [NativeTypeName("bool")] byte origin_top_left);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_apply_scissor_rect", ExactSpelling = true)]
        public static extern void apply_scissor_rect(int x, int y, int width, int height, [NativeTypeName("bool")] byte origin_top_left);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_apply_scissor_rectf", ExactSpelling = true)]
        public static extern void apply_scissor_rectf(float x, float y, float width, float height, [NativeTypeName("bool")] byte origin_top_left);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_apply_pipeline", ExactSpelling = true)]
        public static extern void apply_pipeline(sg_pipeline pip);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_apply_bindings", ExactSpelling = true)]
        public static extern void apply_bindings([NativeTypeName("const sg_bindings *")] sg_bindings* bindings);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_apply_uniforms", ExactSpelling = true)]
        public static extern void apply_uniforms(sg_shader_stage stage, int ub_index, [NativeTypeName("const sg_range *")] sg_range* data);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_draw", ExactSpelling = true)]
        public static extern void draw(int base_element, int num_elements, int num_instances);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_end_pass", ExactSpelling = true)]
        public static extern void end_pass();

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_commit", ExactSpelling = true)]
        public static extern void commit();

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_query_desc", ExactSpelling = true)]
        public static extern sg_desc query_desc();

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_query_backend", ExactSpelling = true)]
        public static extern sg_backend query_backend();

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_query_features", ExactSpelling = true)]
        public static extern sg_features query_features();

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_query_limits", ExactSpelling = true)]
        public static extern sg_limits query_limits();

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_query_pixelformat", ExactSpelling = true)]
        public static extern sg_pixelformat_info query_pixelformat(sg_pixel_format fmt);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_query_buffer_state", ExactSpelling = true)]
        public static extern sg_resource_state query_buffer_state(sg_buffer buf);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_query_image_state", ExactSpelling = true)]
        public static extern sg_resource_state query_image_state(sg_image img);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_query_sampler_state", ExactSpelling = true)]
        public static extern sg_resource_state query_sampler_state(sg_sampler smp);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_query_shader_state", ExactSpelling = true)]
        public static extern sg_resource_state query_shader_state(sg_shader shd);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_query_pipeline_state", ExactSpelling = true)]
        public static extern sg_resource_state query_pipeline_state(sg_pipeline pip);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_query_pass_state", ExactSpelling = true)]
        public static extern sg_resource_state query_pass_state(sg_pass pass);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_query_buffer_info", ExactSpelling = true)]
        public static extern sg_buffer_info query_buffer_info(sg_buffer buf);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_query_image_info", ExactSpelling = true)]
        public static extern sg_image_info query_image_info(sg_image img);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_query_sampler_info", ExactSpelling = true)]
        public static extern sg_sampler_info query_sampler_info(sg_sampler smp);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_query_shader_info", ExactSpelling = true)]
        public static extern sg_shader_info query_shader_info(sg_shader shd);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_query_pipeline_info", ExactSpelling = true)]
        public static extern sg_pipeline_info query_pipeline_info(sg_pipeline pip);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_query_pass_info", ExactSpelling = true)]
        public static extern sg_pass_info query_pass_info(sg_pass pass);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_query_buffer_desc", ExactSpelling = true)]
        public static extern sg_buffer_desc query_buffer_desc(sg_buffer buf);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_query_image_desc", ExactSpelling = true)]
        public static extern sg_image_desc query_image_desc(sg_image img);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_query_sampler_desc", ExactSpelling = true)]
        public static extern sg_sampler_desc query_sampler_desc(sg_sampler smp);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_query_shader_desc", ExactSpelling = true)]
        public static extern sg_shader_desc query_shader_desc(sg_shader shd);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_query_pipeline_desc", ExactSpelling = true)]
        public static extern sg_pipeline_desc query_pipeline_desc(sg_pipeline pip);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_query_pass_desc", ExactSpelling = true)]
        public static extern sg_pass_desc query_pass_desc(sg_pass pass);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_query_buffer_defaults", ExactSpelling = true)]
        public static extern sg_buffer_desc query_buffer_defaults([NativeTypeName("const sg_buffer_desc *")] sg_buffer_desc* desc);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_query_image_defaults", ExactSpelling = true)]
        public static extern sg_image_desc query_image_defaults([NativeTypeName("const sg_image_desc *")] sg_image_desc* desc);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_query_sampler_defaults", ExactSpelling = true)]
        public static extern sg_sampler_desc query_sampler_defaults([NativeTypeName("const sg_sampler_desc *")] sg_sampler_desc* desc);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_query_shader_defaults", ExactSpelling = true)]
        public static extern sg_shader_desc query_shader_defaults([NativeTypeName("const sg_shader_desc *")] sg_shader_desc* desc);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_query_pipeline_defaults", ExactSpelling = true)]
        public static extern sg_pipeline_desc query_pipeline_defaults([NativeTypeName("const sg_pipeline_desc *")] sg_pipeline_desc* desc);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_query_pass_defaults", ExactSpelling = true)]
        public static extern sg_pass_desc query_pass_defaults([NativeTypeName("const sg_pass_desc *")] sg_pass_desc* desc);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_alloc_buffer", ExactSpelling = true)]
        public static extern sg_buffer alloc_buffer();

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_alloc_image", ExactSpelling = true)]
        public static extern sg_image alloc_image();

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_alloc_sampler", ExactSpelling = true)]
        public static extern sg_sampler alloc_sampler();

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_alloc_shader", ExactSpelling = true)]
        public static extern sg_shader alloc_shader();

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_alloc_pipeline", ExactSpelling = true)]
        public static extern sg_pipeline alloc_pipeline();

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_alloc_pass", ExactSpelling = true)]
        public static extern sg_pass alloc_pass();

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_dealloc_buffer", ExactSpelling = true)]
        public static extern void dealloc_buffer(sg_buffer buf);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_dealloc_image", ExactSpelling = true)]
        public static extern void dealloc_image(sg_image img);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_dealloc_sampler", ExactSpelling = true)]
        public static extern void dealloc_sampler(sg_sampler smp);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_dealloc_shader", ExactSpelling = true)]
        public static extern void dealloc_shader(sg_shader shd);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_dealloc_pipeline", ExactSpelling = true)]
        public static extern void dealloc_pipeline(sg_pipeline pip);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_dealloc_pass", ExactSpelling = true)]
        public static extern void dealloc_pass(sg_pass pass);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_init_buffer", ExactSpelling = true)]
        public static extern void init_buffer(sg_buffer buf, [NativeTypeName("const sg_buffer_desc *")] sg_buffer_desc* desc);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_init_image", ExactSpelling = true)]
        public static extern void init_image(sg_image img, [NativeTypeName("const sg_image_desc *")] sg_image_desc* desc);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_init_sampler", ExactSpelling = true)]
        public static extern void init_sampler(sg_sampler smg, [NativeTypeName("const sg_sampler_desc *")] sg_sampler_desc* desc);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_init_shader", ExactSpelling = true)]
        public static extern void init_shader(sg_shader shd, [NativeTypeName("const sg_shader_desc *")] sg_shader_desc* desc);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_init_pipeline", ExactSpelling = true)]
        public static extern void init_pipeline(sg_pipeline pip, [NativeTypeName("const sg_pipeline_desc *")] sg_pipeline_desc* desc);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_init_pass", ExactSpelling = true)]
        public static extern void init_pass(sg_pass pass, [NativeTypeName("const sg_pass_desc *")] sg_pass_desc* desc);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_uninit_buffer", ExactSpelling = true)]
        public static extern void uninit_buffer(sg_buffer buf);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_uninit_image", ExactSpelling = true)]
        public static extern void uninit_image(sg_image img);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_uninit_sampler", ExactSpelling = true)]
        public static extern void uninit_sampler(sg_sampler smp);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_uninit_shader", ExactSpelling = true)]
        public static extern void uninit_shader(sg_shader shd);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_uninit_pipeline", ExactSpelling = true)]
        public static extern void uninit_pipeline(sg_pipeline pip);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_uninit_pass", ExactSpelling = true)]
        public static extern void uninit_pass(sg_pass pass);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_fail_buffer", ExactSpelling = true)]
        public static extern void fail_buffer(sg_buffer buf);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_fail_image", ExactSpelling = true)]
        public static extern void fail_image(sg_image img);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_fail_sampler", ExactSpelling = true)]
        public static extern void fail_sampler(sg_sampler smp);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_fail_shader", ExactSpelling = true)]
        public static extern void fail_shader(sg_shader shd);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_fail_pipeline", ExactSpelling = true)]
        public static extern void fail_pipeline(sg_pipeline pip);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_fail_pass", ExactSpelling = true)]
        public static extern void fail_pass(sg_pass pass);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_enable_frame_stats", ExactSpelling = true)]
        public static extern void enable_frame_stats();

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_disable_frame_stats", ExactSpelling = true)]
        public static extern void disable_frame_stats();

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_frame_stats_enabled", ExactSpelling = true)]
        [return: NativeTypeName("bool")]
        public static extern byte frame_stats_enabled();

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_query_frame_stats", ExactSpelling = true)]
        public static extern sg_frame_stats query_frame_stats();

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_setup_context", ExactSpelling = true)]
        public static extern sg_context setup_context();

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_activate_context", ExactSpelling = true)]
        public static extern void activate_context(sg_context ctx_id);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_discard_context", ExactSpelling = true)]
        public static extern void discard_context(sg_context ctx_id);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_d3d11_device", ExactSpelling = true)]
        [return: NativeTypeName("const void *")]
        public static extern void* d3d11_device();

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_d3d11_device_context", ExactSpelling = true)]
        [return: NativeTypeName("const void *")]
        public static extern void* d3d11_device_context();

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_d3d11_query_buffer_info", ExactSpelling = true)]
        public static extern sg_d3d11_buffer_info d3d11_query_buffer_info(sg_buffer buf);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_d3d11_query_image_info", ExactSpelling = true)]
        public static extern sg_d3d11_image_info d3d11_query_image_info(sg_image img);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_d3d11_query_sampler_info", ExactSpelling = true)]
        public static extern sg_d3d11_sampler_info d3d11_query_sampler_info(sg_sampler smp);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_d3d11_query_shader_info", ExactSpelling = true)]
        public static extern sg_d3d11_shader_info d3d11_query_shader_info(sg_shader shd);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_d3d11_query_pipeline_info", ExactSpelling = true)]
        public static extern sg_d3d11_pipeline_info d3d11_query_pipeline_info(sg_pipeline pip);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_d3d11_query_pass_info", ExactSpelling = true)]
        public static extern sg_d3d11_pass_info d3d11_query_pass_info(sg_pass pass);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_mtl_device", ExactSpelling = true)]
        [return: NativeTypeName("const void *")]
        public static extern void* mtl_device();

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_mtl_render_command_encoder", ExactSpelling = true)]
        [return: NativeTypeName("const void *")]
        public static extern void* mtl_render_command_encoder();

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_mtl_query_buffer_info", ExactSpelling = true)]
        public static extern sg_mtl_buffer_info mtl_query_buffer_info(sg_buffer buf);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_mtl_query_image_info", ExactSpelling = true)]
        public static extern sg_mtl_image_info mtl_query_image_info(sg_image img);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_mtl_query_sampler_info", ExactSpelling = true)]
        public static extern sg_mtl_sampler_info mtl_query_sampler_info(sg_sampler smp);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_mtl_query_shader_info", ExactSpelling = true)]
        public static extern sg_mtl_shader_info mtl_query_shader_info(sg_shader shd);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_mtl_query_pipeline_info", ExactSpelling = true)]
        public static extern sg_mtl_pipeline_info mtl_query_pipeline_info(sg_pipeline pip);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_wgpu_device", ExactSpelling = true)]
        [return: NativeTypeName("const void *")]
        public static extern void* wgpu_device();

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_wgpu_queue", ExactSpelling = true)]
        [return: NativeTypeName("const void *")]
        public static extern void* wgpu_queue();

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_wgpu_command_encoder", ExactSpelling = true)]
        [return: NativeTypeName("const void *")]
        public static extern void* wgpu_command_encoder();

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_wgpu_render_pass_encoder", ExactSpelling = true)]
        [return: NativeTypeName("const void *")]
        public static extern void* wgpu_render_pass_encoder();

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_wgpu_query_buffer_info", ExactSpelling = true)]
        public static extern sg_wgpu_buffer_info wgpu_query_buffer_info(sg_buffer buf);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_wgpu_query_image_info", ExactSpelling = true)]
        public static extern sg_wgpu_image_info wgpu_query_image_info(sg_image img);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_wgpu_query_sampler_info", ExactSpelling = true)]
        public static extern sg_wgpu_sampler_info wgpu_query_sampler_info(sg_sampler smp);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_wgpu_query_shader_info", ExactSpelling = true)]
        public static extern sg_wgpu_shader_info wgpu_query_shader_info(sg_shader shd);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_wgpu_query_pipeline_info", ExactSpelling = true)]
        public static extern sg_wgpu_pipeline_info wgpu_query_pipeline_info(sg_pipeline pip);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_wgpu_query_pass_info", ExactSpelling = true)]
        public static extern sg_wgpu_pass_info wgpu_query_pass_info(sg_pass pass);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_gl_query_buffer_info", ExactSpelling = true)]
        public static extern sg_gl_buffer_info gl_query_buffer_info(sg_buffer buf);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_gl_query_image_info", ExactSpelling = true)]
        public static extern sg_gl_image_info gl_query_image_info(sg_image img);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_gl_query_sampler_info", ExactSpelling = true)]
        public static extern sg_gl_sampler_info gl_query_sampler_info(sg_sampler smp);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_gl_query_shader_info", ExactSpelling = true)]
        public static extern sg_gl_shader_info gl_query_shader_info(sg_shader shd);

        [DllImport("sokol", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sg_gl_query_pass_info", ExactSpelling = true)]
        public static extern sg_gl_pass_info gl_query_pass_info(sg_pass pass);
    }
