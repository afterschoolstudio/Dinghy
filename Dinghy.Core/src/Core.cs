using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Dinghy.NativeInterop;

namespace Dinghy;
using Internal.Sokol;

public static class Engine
{
    public static void Init()
    {
        Boot();
    }

    static internal void Boot()
    {
        unsafe
        {
            var window_title = "my window"u8;
            fixed (byte* ptr = window_title)
            {
                //init
                sapp_desc desc = default;
                desc.width = 500;
                desc.height = 500;
                desc.icon.sokol_default = 1;
                desc.window_title = (sbyte*)ptr;
                desc.init_cb = &Initialize;
                desc.event_cb = &Event;
                desc.frame_cb = &Frame;
                desc.cleanup_cb = &Cleanup;
                //call our own logger
                desc.logger.func = &Sokol_Logger;
                //call native logger
                // desc.logger.func = (delegate* unmanaged[Cdecl]<sbyte*, uint, uint, sbyte*, uint, sbyte*, void*, void>)NativeLibrary.GetExport(NativeLibrary.Load("libs/sokol"), "slog_func");
                App.run(&desc);
            }
        }
    }
    
    [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
    private static unsafe void Event(sapp_event* e)
    {
        // var width = App.width();
        // var height = App.height();
        // Console.WriteLine(e->type);
    }

    public struct core_state
    {
        public sg_pass_action pass_action ;
        public sg_image img;
        public int imageWidth;
        public int imageHeight;
        public sg_sampler smp;
        public sgl_pipeline pip_3d;
    }

    public static core_state state = default(core_state);

    [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
    private static unsafe void Initialize()
    {
        //sokol init
        sg_desc desc = default;
        desc.context = Glue.sapp_sgcontext();
        //call our own logger
        desc.logger.func = &Sokol_Logger;
        //call native logger
        // desc.logger.func = (delegate* unmanaged[Cdecl]<sbyte*, uint, uint, sbyte*, uint, sbyte*, void*, void>)NativeLibrary.GetExport(NativeLibrary.Load("libs/sokol"), "slog_func");
        Gfx.setup(&desc);

        sgl_desc_t gl_desc = default;
        //call our own logger
        gl_desc.logger.func = &Sokol_Logger;
        //call native logger
        // gl_desc.logger.func = (delegate* unmanaged[Cdecl]<sbyte*, uint, uint, sbyte*, uint, sbyte*, void*, void>)NativeLibrary.GetExport(NativeLibrary.Load("libs/sokol"), "slog_func");
        GL.setup(&gl_desc);
        
        // a checkerboard texture
        var texSize = 32;
        var pixels = new Utils.NativeArray<uint>(texSize*texSize);
        for (int i = 0; i < (texSize*texSize); i++)
        {
            pixels[i] = (i + (i / texSize)) % 2 == 0 ? 0xFFFFFFFF : 0xFFFF0000;
        }
        
        var img_desc = default(sg_image_desc);
        img_desc.width = texSize;
        img_desc.height = texSize;
        img_desc.data.subimage.e0_0 = pixels.AsSgRange();
        state.img = Gfx.make_image(&img_desc);
        state.imageWidth = texSize;
        state.imageHeight = texSize;
        
        
        // ... and a sampler
        var sample_desc = default(sg_sampler_desc);
        sample_desc.min_filter = sg_filter.SG_FILTER_NEAREST;
        sample_desc.mag_filter = sg_filter.SG_FILTER_NEAREST;
        sample_desc.wrap_u = sg_wrap.SG_WRAP_CLAMP_TO_EDGE;
        sample_desc.wrap_v = sg_wrap.SG_WRAP_CLAMP_TO_EDGE;
        state.smp = Gfx.make_sampler(&sample_desc);
        /* create a pipeline object for 3d rendering, with less-equal
           depth-test and cull-face enabled, note that we don't provide
           a shader, vertex-layout, pixel formats and sample count here,
           these are all filled in by sokol-gl
        */
        sg_pipeline_desc pipeline_desc = default;
        pipeline_desc.cull_mode = sg_cull_mode.SG_CULLMODE_BACK;
        pipeline_desc.depth.write_enabled = 1;
        pipeline_desc.depth.compare = sg_compare_func.SG_COMPAREFUNC_LESS_EQUAL;
        state.pip_3d = GL.make_pipeline(&pipeline_desc);

        // default pass action
        var pass_action = default(sg_pass_action);
        pass_action.colors[0].load_action = sg_load_action.SG_LOADACTION_CLEAR;
        pass_action.colors[0].clear_value = new sg_color()
        {
            r = 0f,
            g = 0f,
            b = 0f,
            a = 1.0f
        };
    }

    private static float angle_deg = 0;
    private static Vector2 rectPos = new Vector2(0,0);
    
    [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
    private static unsafe void Frame()
    {
        float t = (float)App.frame_duration() * 60.0f;

        var dw = App.width();
        var dh = App.height();
        
        int ww = dh/2; // not a bug
        int hh = dh/2;
        int x0 = dw/2 - hh;
        int x1 = dw/2;
        int y0 = 0;
        int y1 = dh/2;
        
        // draw_triangle();
        // GL.viewport(x0, y0, ww, hh, 1);
        //     GL.defaults();
        //     GL.begin_triangles();
        //     GL.v2f_c3b( 0.0f,  0.5f, 255, 0, 0);
        //     GL.v2f_c3b(-0.5f, -0.5f, 0, 0, 255);
        //     GL.v2f_c3b( 0.5f, -0.5f, 0, 255, 0);
        //     GL.end();
        
        //draw quad
        // GL.viewport(x1, y0, ww, hh, 1);        
        GL.viewport(0, 0, dw, dh, 1);  
            // float scale = 1.0f + MathF.Sin(GL.rad(angle_deg)) * 0.5f;
            // angle_deg += 1.0f * t;
            GL.defaults();
            // GL.load_pipeline(state.pip_3d);
            GL.enable_texture();
            GL.texture(state.img, state.smp);
            // GL.matrix_mode_texture();
            // GL.scale(scale, scale, 1.0f);

            // GL.rotate(GL.rad(angle_deg), 0.0f, 0.0f, 1.0f);
            // GL.scale(scale, scale, 1.0f);
            GL.begin_quads();
            var clip_img_width =       ((state.imageWidth / (float)dw) * 2f) - 1f;
            var clip_img_height = -1 * (((state.imageHeight / (float)dh) * 2f) - 1f);
            // GL.translate(.3f,(float)MathF.Sin(t),0); 
            //draw the verts at the clip size of the texture
            // GL.v2f_t2f_c3b( -0.5f, -0.5f,  0, 0,  255, 255, 0); //bottom left
            // GL.v2f_t2f_c3b(  0.5f, -0.5f,  1, 0,  0, 255, 0); //bottom right
            // GL.v2f_t2f_c3b(  0.5f,  0.5f,  1, 1,  0, 0, 255); //top right
            // GL.v2f_t2f_c3b( -0.5f,  0.5f,  0, 1,  255, 0, 0); //top left
            
            //gl clip space is -1 -> + 1, lower left to top right
            //this is a top left quad that stays in the top left quadrant of the screen
            // GL.v2f_t2f_c3b( -1, 0,  0, 0,  255, 255, 0); //bottom left
            // GL.v2f_t2f_c3b(  0f, 0f,  1, 0,  0, 255, 0); //bottom right
            // GL.v2f_t2f_c3b(  0,  1,  1, 1,  0, 0, 255); //top right
            // GL.v2f_t2f_c3b( -1,  1,  0, 1,  255, 0, 0); //top left
            
            //this quad maintains its pos based on the texture size
            GL.v2f_t2f_c3b( -1, clip_img_height,  0, 0,  255, 255, 0); //bottom left
            GL.v2f_t2f_c3b(  clip_img_width, clip_img_height,  1, 0,  0, 255, 0); //bottom right
            GL.v2f_t2f_c3b(  clip_img_width,  1,  1, 1,  0, 0, 255); //top right
            GL.v2f_t2f_c3b( -1,  1,  0, 1,  255, 0, 0); //top left
            
            GL.end();

            fixed (sg_pass_action* pass = &state.pass_action)
            {
                Gfx.begin_default_pass(pass, dw, dh);
                GL.draw();
                Gfx.end_pass();
                Gfx.commit();
            }
    }

    public enum LogLevel
    {
        PANIC,
        ERROR,
        WARN,
        INFO
    }
    [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
    private static unsafe void Sokol_Logger(sbyte* tag, uint log_level, uint log_item, sbyte* message, uint line_nr, sbyte* filename, void* user_data)
    {

        var TagStr = new string(tag); //Marshal.PtrToStringAnsi((IntPtr)tag);
        var MesageStr = new string(message);
        var FilenameStr = new string(filename);
        Console.WriteLine($"[{(LogLevel)log_level}][{TagStr}] {(sg_log_item)log_item} {FilenameStr} Line={line_nr}");
        Console.WriteLine($"    {MesageStr}\n");
        // System.Diagnostics.Debug.WriteLine($"Tag={TagStr} Level={log_level} Item={(sg_log_item)log_item} Message={MesageStr} Line={line_nr} FileName={FilenameStr}\n");
    }
    
    [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
    private static unsafe void Cleanup()
    {
        // Gfx.destroy_image(image);
        // GP.sgp_shutdown();
        GL.shutdown();
        Gfx.shutdown();
    }
    
    // static unsafe sg_shader makeShaderFromSource()
    // {
    //     var desc = default(sg_shader_desc);
    //     byte[] fc = System.Text.Encoding.UTF8.GetBytes("frag_color");
    //     byte[] uv = System.Text.Encoding.UTF8.GetBytes("uv");
    //     byte[] fs_source = File.ReadAllBytes("shaders/compiled/_loadpng_hlsl4_fs.hlsl");
    //     byte[] vs_source = File.ReadAllBytes("shaders/compiled/_loadpng_hlsl4_vs.hlsl");
    //     fixed (byte* fc_ptr = fc, uv_ptr = uv, fs_source_ptr = fs_source, vs_source_ptr = vs_source)
    //     {
    //         desc.attrs.e0.sem_name = (sbyte*)fc_ptr;
    //         desc.attrs.e1.sem_name = (sbyte*)uv_ptr;
    //         desc.vs.source = (sbyte*)vs_source_ptr;
    //         desc.fs.source = (sbyte*)fs_source_ptr;
    //     }
    // }
    

    public static sg_image LoadImage(string path)
    {
        byte[] testImgBytes = File.ReadAllBytes(path);
        
        //load image
        var s = testImgBytes.Length * sizeof(byte);
        Console.WriteLine(s);
        
        //note: need to use stbsharp here to actually turn the bytes into an image
        unsafe
        {
            fixed (byte* imgPtr = testImgBytes)
            {
                var sampler_desc = default(sg_sampler_desc);
                sampler_desc.mag_filter = sg_filter.SG_FILTER_LINEAR;
                sampler_desc.min_filter = sg_filter.SG_FILTER_LINEAR;
                sampler_desc.wrap_u = sg_wrap.SG_WRAP_REPEAT;
                sampler_desc.wrap_v = sg_wrap.SG_WRAP_REPEAT;
                sampler_desc.mipmap_filter = sg_filter.SG_FILTER_NONE;
                
                var image_desc = default(sg_image_desc);
                image_desc.width = 64;
                image_desc.height = 64;
                // image_desc.data = default(sg_image_data);
                image_desc.data.subimage.e0_0.ptr = imgPtr;
                // var r = default(sg_range);
                // r.size
                // image_desc.data.subimage.e0_0.size = (nuint)2; // * 4?
                image_desc.data.subimage.e0_0.size = (nuint)(64*64*4*sizeof(byte)); //works
                // image_desc.data.subimage.e0_0.size = (nuint)(testImgBytes.Length * sizeof(byte)); //works
                var image = Gfx.make_image(&image_desc);
                
                if(Gfx.query_image_state(image) != sg_resource_state.SG_RESOURCESTATE_VALID) {
                    Console.WriteLine("failed to load image");
                    return image;
                } else {
                    Console.WriteLine("loaded image");
                    return image;
                }
            }
        }
        
    }
}