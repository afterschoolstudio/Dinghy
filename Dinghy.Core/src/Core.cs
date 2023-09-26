using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Dinghy.Internal.STB;
using Dinghy.NativeInterop;

namespace Dinghy;
using Internal.Sokol;

public static class Engine
{
    static Action Update;

    private static HashSet<DSystem> DefaultSystems = new HashSet<DSystem>()
    {
        SpriteRenderSystem,
        PositionSystem
    };
    public static void Init(Action update = null)
    {
        if (update != null)
        {
            Update += update;
        }
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
                desc.width = 400;
                desc.height = 400;
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
        public imageInfo checkerboard;
        public imageInfo logo;
        public sg_sampler smp;
        public sgl_pipeline alpha_pip;
    }

    public struct imageInfo
    {
        public int width;
        public int height;
        public sg_image img;
    }

    public static core_state state = default;

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
        var checkerboardTexSize = 128;
        var checkSize = checkerboardTexSize / 8;
        uint WHITE = 0xFFFFFFFF;
        uint BLUE = 0xFFFF0000;
        var pixels = new Utils.NativeArray<uint>(checkerboardTexSize*checkerboardTexSize);
        for (int i = 0; i < (checkerboardTexSize*checkerboardTexSize); i++)
        {
            var x = i % checkerboardTexSize;
            var y = i / checkerboardTexSize;
            if ((y / checkSize) % 2 == 0)
            {
                pixels[i] = (x / checkSize) % 2 == 0 ? BLUE : WHITE;
            }
            else
            {
                pixels[i] = (x / checkSize) % 2 == 0 ? WHITE : BLUE;
            }
        }

        var checkerboard_desc = default(sg_image_desc);
        checkerboard_desc.width = checkerboardTexSize;
        checkerboard_desc.height = checkerboardTexSize;
        checkerboard_desc.data.subimage.e0_0 = pixels.AsSgRange();
        state.checkerboard.img = Gfx.make_image(&checkerboard_desc);
        state.checkerboard.width = checkerboardTexSize;
        state.checkerboard.height = checkerboardTexSize;
        
        
        var logo_desc = default(sg_image_desc);
        var fileBytes = File.ReadAllBytes("logo_re.png");
        fixed (byte* imgptr = fileBytes)
        {
            int imgx, imgy, channels;
            // var ok = STB.stbi_info_from_memory(imgptr, fileBytes.Length, &imgx, &imgy, &channels); 
            // Console.WriteLine($"mem test: {ok}: {imgx} {imgy} {channels}");
            STB.stbi_set_flip_vertically_on_load(1);
            var stbimg = STB.stbi_load_from_memory(imgptr, fileBytes.Length, &imgx,&imgy, &channels, 4);
            sg_image_desc stb_img_desc = default;
            stb_img_desc.width = imgx;
            stb_img_desc.height = imgy;
            stb_img_desc.pixel_format = sg_pixel_format.SG_PIXELFORMAT_RGBA8;
            
            stb_img_desc.data.subimage.e0_0.ptr = stbimg;
            stb_img_desc.data.subimage.e0_0.size = (nuint)(imgx * imgy * 4);

            
            state.logo.img = Gfx.make_image(&stb_img_desc);
            state.logo.width = imgx;
            state.logo.height = imgy;
            STB.stbi_image_free(stbimg);
        }
        
        
        // ... and a sampler
        sg_sampler_desc sample_desc = default;
        sample_desc.min_filter = sg_filter.SG_FILTER_LINEAR;
        sample_desc.mag_filter = sg_filter.SG_FILTER_LINEAR;
        sample_desc.mipmap_filter = sg_filter.SG_FILTER_NONE;
        sample_desc.max_anisotropy = 8;
        // sample_desc.mipmap_filter = sg_filter.SG_FILTER_NEAREST;
        state.smp = Gfx.make_sampler(&sample_desc);
        
        var d = Gfx.query_sampler_desc(state.smp);
        Console.WriteLine("init: " + d.mipmap_filter);
        
        sg_pipeline_desc pipeline_desc = default;
        pipeline_desc.colors.e0.write_mask = sg_color_mask.SG_COLORMASK_RGB;
        pipeline_desc.colors.e0.blend.enabled = 1;
        pipeline_desc.colors.e0.blend.src_factor_rgb = sg_blend_factor.SG_BLENDFACTOR_SRC_ALPHA;
        pipeline_desc.colors.e0.blend.dst_factor_rgb = sg_blend_factor.SG_BLENDFACTOR_ONE_MINUS_SRC_ALPHA;
        state.alpha_pip = GL.make_pipeline(&pipeline_desc);

        // default pass action
        var pass_action = default(sg_pass_action);
        pass_action.colors.e0.load_action = sg_load_action.SG_LOADACTION_CLEAR;
        pass_action.colors.e0.clear_value.r = 0f;
        pass_action.colors.e0.clear_value.g = 0f;
        pass_action.colors.e0.clear_value.b = 0f;
        pass_action.colors.e0.clear_value.a = 1.0f;
    }

    private static float angle_deg = 0;
    private static float scale = 0;
    [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
    private static unsafe void Frame()
    {
        float t = (float)App.frame_duration() * 60.0f;

        var dw = App.width();
        var dh = App.height();
        
        //draw quad
        GL.viewport(0, 0, dw, dh, 1);  
        scale = 1.0f + MathF.Sin(GL.rad(angle_deg)) * 10.5f;
        angle_deg += 1.0f * t;
        GL.defaults();
        GL.enable_texture();
        
        Update?.Invoke();

        foreach (var rect in rects)
        {
            Console.WriteLine($"drawing {rect.Key} {rect.Value.X} {rect.Value.Y}");
            drawRect(rect.Value,dw,dh);
        }
        

        fixed (sg_pass_action* pass = &state.pass_action)
        {
            Gfx.begin_default_pass(pass, dw, dh);
            GL.draw();
            Gfx.end_pass();
            Gfx.commit();
        }
    }

    public static uint idCounter = 0;
    public static void addRect(uint id, int X, int Y, int tex)
    {
        if (rects.TryGetValue(id, out var r))
        {
            // rects[id].X = X;
            r.X = X;
            r.Y = Y;
            Console.WriteLine($"engine: {id} {r.X} {r.Y}");
        }
        else
        {
            rects.Add(id, new rect()
            {
                X = X,
                Y = Y,
                t = (tex)tex
            });
        }
    }

    public class rect
    {
        public int X;
        public int Y;
        public tex t;
    }

    private static Dictionary<uint, rect> rects = new();

    public enum tex
    {
        logo,
        checkerboard
    }
    static void drawRect(rect r, int dw, int dh)
    {
        (float x, float y) clipPos = ((float)r.X / dw, (float)r.Y / dh);
        var activeTex = r.t == tex.checkerboard ? state.checkerboard : state.logo;
        
        GL.texture(activeTex.img, state.smp);
        if (r.t == tex.logo)
        {
            GL.load_pipeline(state.alpha_pip);
        }
        else
        {
            GL.load_default_pipeline();
        }
        
        GL.push_matrix();
        //gl clip space is -1 -> + 1, lower left to top right
        GL.translate(-1 + clipPos.x,1-clipPos.y,0);
        // GL.scale(scale, scale, 1.0f);
        // GL.rotate(GL.rad(angle_deg), 0.0f, 0.0f, 1.0f);
        GL.begin_quads();
            
        var clip_img_height = activeTex.height / (float)dh;
        var clip_img_width =       activeTex.width / (float)dw;
        GL.v2f_t2f_c3b( -1, 1-clip_img_height,  0, 0,  255, 255, 0); //bottom left
        GL.v2f_t2f_c3b(  -1 + clip_img_width, 1-clip_img_height,  1, 0,  0, 255, 0); //bottom right
        GL.v2f_t2f_c3b(  -1 + clip_img_width, 1,  1, 1,  0, 0, 255); //top right
        GL.v2f_t2f_c3b( -1, 1,  0, 1,  255, 0, 0); //top left
        GL.translate(1f,-1f,0);
        GL.end();
        GL.pop_matrix();
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