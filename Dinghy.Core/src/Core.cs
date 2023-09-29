using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Dinghy.Internal.STB;
using Dinghy.NativeInterop;
using Arch.Core;

namespace Dinghy;
using Internal.Sokol;

public static class Engine
{
    static Action Update;
    static Action Setup;
    static InputSystem InputSystem = new InputSystem();

    private static HashSet<DSystem> DefaultSystems = new HashSet<DSystem>()
    {
        new VelocitySystem(),
        new SpriteRenderSystem(),
        InputSystem
    };

    public static uint idCounter;
    public static World World = World.Create();

    public record RunOptions(int width, int height, string appName);

    private static RunOptions defaultOpts = new(500, 500, "dinghy");
    public static void Run(RunOptions opts = null, Action update = null)
    {
        if (update != null)
        {
            Update += update;
        }
        if (opts == null)
        {
            
        }
        Boot(opts == null ? defaultOpts : opts);
    }
    
    static internal void Boot(RunOptions opts)
    {
        unsafe
        {
            // var window_title = "dinghy"u8;
            var window_title = System.Text.Encoding.UTF8.GetBytes(opts.appName);
            fixed (byte* ptr = window_title)
            {
                //init
                sapp_desc desc = default;
                desc.width = opts.width;
                desc.height = opts.height;
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
        sapp_event ev = *e;
        InputSystem.FrameEvents.Add(ev);
        // Console.WriteLine(ev);
        // var width = App.width();
        // var height = App.height();
        // Console.WriteLine(e->type);
    }

    public struct core_state
    {
        public sg_pass_action pass_action ;
        public imageInfo checkerboard;
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


        sdtx_desc_t debug_text_desc = default;
        debug_text_desc.fonts.e0 = DebugText.font_kc853();
        debug_text_desc.fonts.e1 = DebugText.font_kc854();
        debug_text_desc.fonts.e2 = DebugText.font_z1013();
        debug_text_desc.fonts.e3 = DebugText.font_cpc();
        debug_text_desc.fonts.e4 = DebugText.font_c64();
        debug_text_desc.fonts.e5 = DebugText.font_oric();
        debug_text_desc.logger.func = &Sokol_Logger;
        DebugText.setup(&debug_text_desc);
        
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
        
        // var logo = LoadImage("logo.png", out var imageWidth, out var imageHeight);
        // state.logo.img = logo;
        // state.logo.width = imageWidth;
        // state.logo.height = imageHeight;
        
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
        
        Setup?.Invoke();
    }

    public static int Width;
    public static int Height;

    private static float angle_deg = 0;
    private static float scale = 0;
    [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
    private static unsafe void Frame()
    {
        App.frame_count();
        // float t = (float)App.frame_duration() * 60.0f;
        float t = (float)App.frame_duration() * 1000.0f;
        // Console.WriteLine($"{t}ms");
        Width = App.width();
        Height = App.height();
        
        //draw quad
        GL.viewport(0, 0, Width, Height, 1);  
        scale = 1.0f + MathF.Sin(GL.rad(angle_deg)) * 10.5f;
        angle_deg += 1.0f * t;
        GL.defaults();
        GL.enable_texture();
        
        Update?.Invoke();
        foreach (var s in DefaultSystems)
        {
            //TODO: need to sort systems by priority
            if (s is IUpdateSystem us)
            {
                us.Update();
            }
        }

        drawDebugText(DebugFont.C64,$"{t}ms");

        fixed (sg_pass_action* pass = &state.pass_action)
        {
            Gfx.begin_default_pass(pass, Width, Height);
            GL.draw();
            DebugText.draw();
            Gfx.end_pass();
            Gfx.commit();
        }
    }

    public enum DebugFont
    {
        KC853,
        KC854,
        Z1013,
        AMSTRAD,
        C64,
        ORIC
    }
    static void drawDebugText(DebugFont f, string debugText)
    {
        DebugText.canvas(Width*0.5f, Height*0.5f);
        DebugText.origin(0.0f, 2.0f);
        DebugText.home();
        printFont(debugText);

        void printFont(string t)
        {
            DebugText.font((int)f);
            DebugText.color3b(255, 255, 0);
            unsafe
            {
                var text = System.Text.Encoding.UTF8.GetBytes(t);
                fixed (byte* ptr = text)
                {
                    DebugText.puts((sbyte*)ptr);
                }
            }
            DebugText.crlf();
        }
    }

    public static void DrawTexturedRect(int x, int y, Resources.Image img)
    {
        (float x, float y) clipPos = 
            (2f * (x / (Width * App.dpi_scale())),
            2f * (y / (Height * App.dpi_scale())));
        GL.texture(img.internalData.sg_image, state.smp);
        if (img.alphaIsTransparecy)
        {
            GL.load_pipeline(state.alpha_pip);
        }
        else
        {
            GL.load_default_pipeline();
        }
        // GL.texture(state.checkerboard.img, state.smp);
        // GL.load_default_pipeline();

        
        GL.push_matrix();
        //gl clip space is -1 -> + 1, lower left to top right
        GL.translate(-1 + clipPos.x,1-clipPos.y,0); //this puts us at the top left of the image
        // GL.scale(scale, scale, 1.0f);
        // GL.rotate(GL.rad(angle_deg), 0.0f, 0.0f, 1.0f);
        GL.begin_quads();
        var clip_img_height = img.internalData.height / (Height * App.dpi_scale());
        var clip_img_width =       img.internalData.width / (Width * App.dpi_scale());
        
        // var clip_img_height = state.checkerboard.height / (Height * App.dpi_scale());
        // var clip_img_width =       state.checkerboard.width / (Width * App.dpi_scale());
        
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
    

    public static sg_image LoadImage(string path, out int width, out int height)
    {
        var logo_desc = default(sg_image_desc);
        var fileBytes = File.ReadAllBytes(path);
        unsafe
        {
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

                var img = Gfx.make_image(&stb_img_desc);
                STB.stbi_image_free(stbimg);
                width = imgx;
                height = imgy;
                return img;
            }
        }
    }
}