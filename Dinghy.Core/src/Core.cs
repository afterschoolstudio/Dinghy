using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Dinghy.Internal.STB;
using Arch.Core;
using Dinghy.Core;
using Dinghy.Core.ImGUI;
using Volatile;
using Utils = Dinghy.NativeInterop.Utils;

namespace Dinghy;
using Internal.Sokol;

public static partial class Engine
{
    public static Action Update;
    public static Action Setup;
    static InputSystem InputSystem = new InputSystem();
    public static string DebugTextStr = "";
    static Color ClearColor = new Color(Palettes.ONE_BIT_MONITOR_GLOW[0]);

    private static HashSet<DSystem> DefaultSystems = new HashSet<DSystem>()
    {
        new VelocitySystem(),
        new SpriteRenderSystem(),
        new ShapeRenderSystem(),
        new FrameAnimationSystem(),
        new ManagedComponentSystem(),
        new DestructionSystem(),
        new ParticleRenderSystem(),
        new SceneSystem(),
        InputSystem
    };

    public static uint idCounter;
    public static VoltWorld PhysicsWorld = new ();
    public static World ECSWorld = World.Create();
    public static Scene GlobalScene = new(){Name = "Global Scene"};

    public static Dictionary<Scene, List<Entity>> SceneEntityMap = new();

    static Dictionary<int, Scene> MountedScenes = new();
    public static void MountScene(int depth, Scene s, bool loadImmediate = true, Action loadCallback = null, bool startAfterLoad = true)
    {
        MountedScenes.Add(depth,s);
        s.Status = Scene.SceneStatus.Mounted;
        if (loadImmediate)
        {
            s.Load(() =>
            {
                SceneEntityMap.Add(s,new List<Entity>());
                loadCallback?.Invoke();

            },startAfterLoad);
        }
    }

    public static List<Scene> scenesStagedForUnmounting = new List<Scene>();
    private static bool hasScenesStagedForUnmounting = false;
    public static void UnmountScene(Scene s)
    {
        if (s.Status != Scene.SceneStatus.Unmounted)
        {
            var rmentites = new List<Entity>(SceneEntityMap[s]);
            foreach (var e in rmentites)
            {
                e.Destroy();
            }
            scenesStagedForUnmounting.Add(s);
            hasScenesStagedForUnmounting = true;
        }
    }

    public record RunOptions(int width, int height, string appName, Action setup = null, Action update = null);

    private static RunOptions defaultOpts = new(500, 500, "dinghy",null,null);
    public static void Run(RunOptions opts = null)
    {
        if (opts != null)
        {
            if (opts.update != null)
            {
                Update += opts.update;
            }
            if (opts.setup != null)
            {
                Setup += opts.setup;
            }
        }
        Boot(opts == null ? defaultOpts : opts);
    }
    
    static internal void Boot(RunOptions opts)
    {
        unsafe
        {
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
                desc.logger.func = &Sokol_Logger;
                App.run(&desc);
            }
        }
    }

    
    [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
    private static unsafe void Event(sapp_event* e)
    {
        sapp_event ev = *e;
         if (ImGUI.handle_event(e) > 0)
         {
             /*
              * if you're using sokol_app.h, from inside the sokol_app.h event callback,
                 call:

                 bool simgui_handle_event(const sapp_event* ev);

                 The return value is the value of ImGui::GetIO().WantCaptureKeyboard,
                 if this is true, you might want to skip keyboard input handling
                 in your own event handler.

                 If you want to use the ImGui functions for checking if a key is pressed
                 (e.g. ImGui::IsKeyPressed()) the following helper function to map
                 an sapp_keycode to an ImGuiKey value may be useful:

                 int simgui_map_keycode(sapp_keycode c);

                 Note that simgui_map_keycode() can be called outside simgui_setup()/simgui_shutdown().
              */
         }
         else
         {
             InputSystem.FrameEvents.Add(ev);
         }
        // InputSystem.FrameEvents.Add(ev);

        // Console.WriteLine(ev);
        // var width = App.width();
        // var height = App.height();
        // Console.WriteLine(e->type);
    }

    public struct core_state
    {
        public sg_pass_action pass_action;
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

    public static bool Clear = true;

    public static core_state state = default;
    
    public static sg_imgui_t gfx_dbgui = default;

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

        simgui_desc_t imgui_desc = default;
        imgui_desc.logger.func = &Sokol_Logger;
        ImGUI.setup(&imgui_desc);
        
        sg_imgui_desc_t sg_imgui_desc = default;
        gfx_dbgui.buffers.open = 1;
        gfx_dbgui.images.open = 1;
        gfx_dbgui.samplers.open = 1;
        gfx_dbgui.shaders.open = 1;
        gfx_dbgui.pipelines.open = 1;
        gfx_dbgui.passes.open = 1;
        gfx_dbgui.capture.open = 1;
        fixed (sg_imgui_t* ctx = &gfx_dbgui)
        {
            GfxDebugGUI.init(ctx,&sg_imgui_desc);
        }

        sgp_desc gp_desc = default;
        gp_desc.max_vertices = 1000000;
        GP.sgp_setup(&gp_desc);

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
        
        // ... and a sampler
        sg_sampler_desc sample_desc = default;
        sample_desc.min_filter = sg_filter.SG_FILTER_LINEAR;
        sample_desc.mag_filter = sg_filter.SG_FILTER_LINEAR;
        sample_desc.mipmap_filter = sg_filter.SG_FILTER_LINEAR;
        sample_desc.max_anisotropy = 8;
        // sample_desc.mipmap_filter = sg_filter.SG_FILTER_NEAREST;
        state.smp = Gfx.make_sampler(&sample_desc);
        // GP.sgp_set_sampler(0,state.smp);
        
        Width = App.width();
        Height = App.height();
        MountScene(-1,GlobalScene);
        Setup?.Invoke();
    }

    public static int Width;
    public static int Height;

    private static float angle_deg = 0;
    private static float scale = 0;

    public static ulong FrameCount;
    public static double DeltaTime;
    public static double Time;


    public static bool showStats = true;

    [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
    private static unsafe void Frame()
    {
        FrameCount = App.frame_count();
        DeltaTime = App.frame_duration();
        Time += DeltaTime;
        
        // float t = (float)App.frame_duration() * 60.0f;
        float t = (float)DeltaTime * 1000.0f;
        // Console.WriteLine($"{t}ms");
        Width = App.width();
        Height = App.height();

        simgui_frame_desc_t imgui_frame = default;
        imgui_frame.width = Width;
        imgui_frame.height = Height;
        imgui_frame.delta_time = DeltaTime;
        imgui_frame.dpi_scale = App.dpi_scale();
        ImGUI.new_frame(&imgui_frame);

        ImGUIHelper.Wrappers.BeginMainMenuBar();
        if (ImGUIHelper.Wrappers.BeginMenu("Dinghy"))
        {
            ImGUIHelper.Wrappers.Checkbox("Show Stats", ref showStats);
            foreach (var i in MountedScenes)
            {
                ImGUIHelper.Wrappers.Text($"{i.Value.Name} {i.Value.Status}");
            }
            ImGUIHelper.Wrappers.EndMenu();
        }
        
        if (ImGUIHelper.Wrappers.BeginMenu("Sokol"))
        {
            ImGUIHelper.Wrappers.Checkbox("Capabilities", ref gfx_dbgui.caps.open);
            ImGUIHelper.Wrappers.Checkbox("Frame Stats", ref gfx_dbgui.frame_stats.open);
            ImGUIHelper.Wrappers.Checkbox("Buffers", ref gfx_dbgui.buffers.open);
            ImGUIHelper.Wrappers.Checkbox("Images", ref gfx_dbgui.images.open);
            ImGUIHelper.Wrappers.Checkbox("Samplers", ref gfx_dbgui.samplers.open);
            ImGUIHelper.Wrappers.Checkbox("Shaders", ref gfx_dbgui.shaders.open);
            ImGUIHelper.Wrappers.Checkbox("Pipelines", ref gfx_dbgui.pipelines.open);
            ImGUIHelper.Wrappers.Checkbox("Passes", ref gfx_dbgui.passes.open);
            ImGUIHelper.Wrappers.Checkbox("Capture", ref gfx_dbgui.capture.open);
            ImGUIHelper.Wrappers.EndMenu();
        }
        ImGUIHelper.Wrappers.EndMainMenuBar();
        
        if (showStats)
        {
            int ec = 0;
            foreach (var l in SceneEntityMap.Values)
            {
                ec += l.Count;
            }
            ImGUIHelper.Wrappers.ShowStats($"{t}ms",$"Entities: {ec}",$"{InputSystem.MouseX},{InputSystem.MouseY}");
        }
        
        fixed (sg_imgui_t* ctx = &gfx_dbgui)
        {
            var db_title = System.Text.Encoding.UTF8.GetBytes("debug window");
            var other_title = System.Text.Encoding.UTF8.GetBytes("hello imgui");
            var label = System.Text.Encoding.UTF8.GetBytes("label");
            fixed (byte* ptr = db_title,other_ptr = other_title, label_ptr = label)
            {
                var txt = "sokol debug"u8;
                GfxDebugGUI.draw(ctx);
                // GfxDebugGUI.draw_menu(ctx, (sbyte*)ptr);
                bool open = false;
                ImGUI.igShowDemoWindow(&open);
            }
        }
        
        float ratio = Width/(float)Height;

        // Begin recording draw commands for a frame buffer of size (width, height).
        GP.sgp_begin(Width, Height);
        // Set frame buffer drawing region to (0,0,width,height).
        GP.sgp_viewport(0, 0, Width, Height);
        // Set drawing coordinate space to (left=-ratio, right=ratio, top=1, bottom=-1).
        // GP.sgp_project(-ratio, ratio, 1.0f, -1.0f);

        // Clear the frame buffer.
        if (Clear)
        {
            GP.sgp_set_color(ClearColor.internal_color.r, ClearColor.internal_color.g, ClearColor.internal_color.b, ClearColor.internal_color.a);
            // GP.sgp_set_color(ClearColor.internal_color.r, ClearColor.internal_color.g, ClearColor.internal_color.b, 1f);
            GP.sgp_clear();
            GP.sgp_reset_color();
        }

        foreach (var s in DefaultSystems)
        {
            //TODO: need to sort systems by priority
            if (s is IPreUpdateSystem us)
            {
                us.PreUpdate(DeltaTime);
            }
        }
        PhysicsWorld.Update();
        Update?.Invoke();
        foreach (var s in DefaultSystems)
        {
            //TODO: need to sort systems by priority
            if (s is IUpdateSystem us)
            {
                us.Update(DeltaTime);
            }
        }
        foreach (var s in DefaultSystems)
        {
            //TODO: need to sort systems by priority
            if (s is IPostUpdateSystem ps)
            {
                ps.PostUpdate(DeltaTime);
            }
        }

        // drawDebugText(DebugFont.C64,$"{t}ms \ne: {GlobalScene.Entities.Count} \n {InputSystem.MouseX},{InputSystem.MouseY} \n {DebugTextStr}");

        // setting this to load instead of clear allows us to toggle sokol_gp clearing
        state.pass_action.colors.e0.load_action = sg_load_action.SG_LOADACTION_LOAD;
        fixed (sg_pass_action* pass = &state.pass_action)
        {
            Gfx.begin_default_pass(pass, Width, Height);
            // Dispatch all draw commands to Sokol GFX.
            GP.sgp_flush();
            // Finish a draw command queue, clearing it.
            GP.sgp_end();
            DebugText.draw();
            ImGUI.render();
            Gfx.end_pass();
            Gfx.commit();
        }
        
        foreach (var s in DefaultSystems)
        {
            if (s is ICleanupSystem cs)
            {
                cs.Cleanup();
            }
        }

        if (hasScenesStagedForUnmounting)
        {
            foreach (var s in scenesStagedForUnmounting)
            {
                SceneEntityMap.Remove(s);
                var rm = MountedScenes.Where(x => x.Value == s);
                foreach (var rms in rm)
                {
                    MountedScenes.Remove(rms.Key);
                }
                s.Status = Scene.SceneStatus.Unmounted;
            }
            scenesStagedForUnmounting.Clear();
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

    public static void DrawTexturedRect(float x, float y, float rotation, float scaleX, float scaleY, Frame f, Resources.Image img)
    {
        GP.sgp_set_color(1.0f, 1.0f, 1.0f, 1.0f);
        GP.sgp_set_blend_mode(sgp_blend_mode.SGP_BLENDMODE_BLEND);
        GP.sgp_set_image(0,img.internalData.sg_image);
        GP.sgp_push_transform();
        GP.sgp_translate(x,y);
        GP.sgp_rotate_at(rotation, f.width / 2f, f.height / 2f);
        GP.sgp_scale_at(scaleX, scaleY, f.width / 2f, f.height / 2f);
        GP.sgp_draw_textured_rect(0,
            //this is the rect to draw the source "to", basically can scale the rect (maybe do wrapping?)
            //we assume this is the width and height of the frame itself
            f.SizeRect,
            //this is the rect index into the texture itself
            f.InternalRect);
        GP.sgp_pop_transform();
        // GP.sgp_draw_filled_rect(x,y,img.internalData.width,img.internalData.height);
        GP.sgp_reset_image(0);
        
        /*
        // (float x, float y) clipPos = 
        //     (2f * (x / (Width * App.dpi_scale())),
        //     2f * (y / (Height * App.dpi_scale())));
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

        
        // GL.push_matrix();
        //gl clip space is -1 -> + 1, lower left to top right
        // GL.translate(-1 + clipPos.x,1-clipPos.y,0); //this puts us at the top left of the image
        // GL.scale(scale, scale, 1.0f);
        // GL.rotate(GL.rad(angle_deg), 0.0f, 0.0f, 1.0f);
        GL.begin_quads();
        var clip_img_height = img.internalData.height / (Height * App.dpi_scale());
        var clip_img_width =       img.internalData.width / (Width * App.dpi_scale());
        
        // var clip_img_height = state.checkerboard.height / (Height * App.dpi_scale());
        // var clip_img_width =       state.checkerboard.width / (Width * App.dpi_scale());
        
        GL.v2f_t2f_c3b( x, y-clip_img_height,  0, 0,  255, 255, 0); //bottom left
        GL.v2f_t2f_c3b(  x + clip_img_width, y-clip_img_height,  1, 0,  0, 255, 0); //bottom right
        GL.v2f_t2f_c3b(  x + clip_img_width, y,  1, 1,  0, 0, 255); //top right
        GL.v2f_t2f_c3b( x, y,  0, 1,  255, 0, 0); //top left
        // GL.translate(1f,-1f,0);
        GL.end();
        // GL.pop_matrix();
        */
    }
    
    public static void DrawShape(float x, float y, float rotation, float scaleX, float scaleY, Color c, Frame f)
    {
        //argb
        //rgba
        GP.sgp_set_color(c.internal_color.g, c.internal_color.b, c.internal_color.a, c.internal_color.r);
        GP.sgp_set_blend_mode(sgp_blend_mode.SGP_BLENDMODE_NONE);
        GP.sgp_push_transform();
        GP.sgp_translate(x,y);
        GP.sgp_rotate_at(rotation, f.width / 2f, f.height / 2f);
        GP.sgp_scale_at(scaleX, scaleY, f.width / 2f, f.height / 2f);
        GP.sgp_draw_filled_rect(0,0,f.width,f.height);
        GP.sgp_pop_transform();
        GP.sgp_reset_color();
    }
    
    public static void DrawParticles(Position p, ParticleEmitterComponent c, List<int> activeIndicies)
    {
        GP.sgp_set_blend_mode(sgp_blend_mode.SGP_BLENDMODE_NONE);
        switch (c.Config.ParticleConfig.ParticleType)
        {
            case ParticleEmitterComponent.ParticleConfig.ParticlePrimitiveType.Rectangle:
                foreach (var i in activeIndicies)
                {
                    GP.sgp_push_transform();
                    GP.sgp_set_color(c.Particles[i].Color.internal_color.g, c.Particles[i].Color.internal_color.b, c.Particles[i].Color.internal_color.a, c.Particles[i].Color.internal_color.r);
                    // GP.sgp_translate(p.x, p.y); makes all particles move as if emission point was p.x,p.y
                    GP.sgp_translate(c.Particles[i].Config.EmissionPoint.X + c.Particles[i].X,c.Particles[i].Config.EmissionPoint.Y + c.Particles[i].Y);
                    GP.sgp_rotate_at(c.Particles[i].Rotation, c.Particles[i].Width / 2f, c.Particles[i].Height / 2f);
                    // GP.sgp_scale_at(scaleX, scaleY, f.width / 2f, f.height / 2f); we dont scale, just use width/height
                    GP.sgp_draw_filled_rect(0,0,c.Particles[i].Width,c.Particles[i].Height);
                    GP.sgp_pop_transform();
                }
                break;
            case ParticleEmitterComponent.ParticleConfig.ParticlePrimitiveType.Line:
                foreach (var i in activeIndicies)
                {
                    GP.sgp_push_transform();
                    GP.sgp_set_color(c.Particles[i].Color.internal_color.g, c.Particles[i].Color.internal_color.b, c.Particles[i].Color.internal_color.a, c.Particles[i].Color.internal_color.r);
                    // GP.sgp_translate(p.x, p.y); makes all particles move as if emission point was p.x,p.y
                    GP.sgp_translate(c.Particles[i].Config.EmissionPoint.X + c.Particles[i].X,c.Particles[i].Config.EmissionPoint.Y + c.Particles[i].Y);
                    GP.sgp_rotate_at(c.Particles[i].Rotation, c.Particles[i].Width / 2f, c.Particles[i].Height / 2f);
                    // GP.sgp_scale_at(scaleX, scaleY, f.width / 2f, f.height / 2f); we dont scale, just use width/height
                    GP.sgp_draw_line(0,0,c.Particles[i].Width,c.Particles[i].Height);
                    GP.sgp_pop_transform();
                }
                break;
            case ParticleEmitterComponent.ParticleConfig.ParticlePrimitiveType.Triangle:
                foreach (var i in activeIndicies)
                {
                    GP.sgp_push_transform();
                    GP.sgp_set_color(c.Particles[i].Color.internal_color.g, c.Particles[i].Color.internal_color.b, c.Particles[i].Color.internal_color.a, c.Particles[i].Color.internal_color.r);
                    // GP.sgp_translate(p.x, p.y); makes all particles move as if emission point was p.x,p.y
                    GP.sgp_translate(c.Particles[i].Config.EmissionPoint.X + c.Particles[i].X,c.Particles[i].Config.EmissionPoint.Y + c.Particles[i].Y);
                    GP.sgp_rotate_at(c.Particles[i].Rotation, c.Particles[i].Width / 2f, c.Particles[i].Height / 2f);
                    // GP.sgp_scale_at(scaleX, scaleY, f.width / 2f, f.height / 2f); we dont scale, just use width/height
                    GP.sgp_draw_filled_triangle(0,0,c.Particles[i].Width,0,c.Particles[i].Width / 2f,c.Particles[i].Height);
                    GP.sgp_pop_transform();
                }
                break;
            case ParticleEmitterComponent.ParticleConfig.ParticlePrimitiveType.LineStrip:
                var pts = new Utils.NativeArray<sgp_vec2>(activeIndicies.Count);
                int first = activeIndicies[0];
                int ct = 0;
                foreach (var i in activeIndicies)
                {
                    pts[ct] = new sgp_vec2() { x = c.Particles[i].X, y = c.Particles[i].Y };
                    ct++;
                }
                GP.sgp_push_transform();
                GP.sgp_set_color(c.Particles[first].Color.internal_color.g, c.Particles[first].Color.internal_color.b, c.Particles[first].Color.internal_color.a, c.Particles[0].Color.internal_color.r);
                // GP.sgp_translate(p.x, p.y);
                GP.sgp_translate(c.Particles[first].Config.EmissionPoint.X + c.Particles[first].X,c.Particles[first].Config.EmissionPoint.Y + c.Particles[first].Y);
                GP.sgp_rotate_at(c.Particles[first].Rotation, c.Particles[first].Width / 2f, c.Particles[first].Height / 2f);
                // GP.sgp_scale_at(scaleX, scaleY, f.width / 2f, f.height / 2f); we dont scale, just use width/height
                unsafe
                {
                    GP.sgp_draw_lines_strip(pts.Ptr,(uint)activeIndicies.Count);
                }
                GP.sgp_pop_transform();
                break;
            // case ParticleEmitterComponent.ParticleConfig.ParticlePrimitiveType.TriangleStrip:
            //     var strip_pts = new Utils.NativeArray<sgp_vec2>(activeIndicies.Count);
            //     int first_strip_pt = activeIndicies[0];
            //     int pt_ct = 0;
            //     foreach (var i in activeIndicies)
            //     {
            //         strip_pts[pt_ct] = new sgp_vec2() { x = c.Particles[i].X, y = c.Particles[i].Y };
            //         pt_ct++;
            //     }
            //     GP.sgp_push_transform();
            //     GP.sgp_set_color(c.Particles[first_strip_pt].Color.internal_color.g, c.Particles[first_strip_pt].Color.internal_color.b, c.Particles[first_strip_pt].Color.internal_color.a, c.Particles[0].Color.internal_color.r);
            //     // GP.sgp_translate(p.x, p.y);
            //     GP.sgp_translate(c.Particles[first_strip_pt].Config.EmissionPoint.X + c.Particles[first_strip_pt].X,c.Particles[first_strip_pt].Config.EmissionPoint.Y + c.Particles[first_strip_pt].Y);
            //     GP.sgp_rotate_at(c.Particles[first_strip_pt].Rotation, c.Particles[first_strip_pt].Width / 2f, c.Particles[first_strip_pt].Height / 2f);
            //     // GP.sgp_scale_at(scaleX, scaleY, f.width / 2f, f.height / 2f); we dont scale, just use width/height
            //     unsafe
            //     {
            //         GP.sgp_draw_filled_triangles_strip(strip_pts.Ptr,(uint)activeIndicies.Count);
            //     }
            //     GP.sgp_pop_transform();
            //     break;
            
        }
        GP.sgp_reset_color();
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
        ImGUI.shutdown();
        fixed (sg_imgui_t* ctx = &gfx_dbgui)
        {
            GfxDebugGUI.discard(ctx);
        }
        // Gfx.destroy_image(image);
        GP.sgp_shutdown();
        // GL.shutdown();
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
                var ok = STB.stbi_info_from_memory(imgptr, fileBytes.Length, &imgx, &imgy, &channels); 
                Console.WriteLine($"mem test: {ok}: {imgx} {imgy} {channels}");
                // STB.stbi_set_flip_vertically_on_load(1);
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