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
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes("my window");
            fixed (byte* ptr = bytes)
            {
                //init
                sapp_desc desc = default;
                desc.width = 1920;
                desc.height = 1080;
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
        public sg_sampler smp;
        public sg_pipeline pip_3d;
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
        var pixels = new Utils.NativeArray<uint>(64);
        for (int y = 0; y < 8; y++) {
            for (int x = 0; x < 8; x++) {
                pixels[y,x] = ((y ^ x) & 1) > 0 ? 0xFFFFFFFF : 0xFF000000;
            }
        }
        
        var img_desc = default(sg_image_desc);
        img_desc.width = 8;
        img_desc.height = 8;
        img_desc.data.subimage.e0_0 = pixels.AsSgRange();
        state.img = Gfx.make_image(&img_desc);
        
        
        // ... and a sampler
        var sample_desc = default(sg_sampler_desc);
        sample_desc.min_filter = sg_filter.SG_FILTER_NEAREST;
        sample_desc.mag_filter = sg_filter.SG_FILTER_NEAREST;
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
        state.pip_3d = Gfx.make_pipeline(&pipeline_desc);

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

        //sokol_gp init
        // var sgp_desc = default(sgp_desc);
        // GP.sgp_setup(&sgp_desc);

        // LoadImage("testimg.png");

        // //init shader
        // var pip_desc = default(sgp_pipeline_desc);
        // var shader_desc = default(sg_shader_desc);
        // shader_desc.attrs
        // pip_desc.shader = 
        // fixed()
        // pip_desc.shader = *effect_program_shader_desc(sg_query_backend());
        // pip = sgp_make_pipeline(&pip_desc);
        // if(sg_query_pipeline_state(pip) != SG_RESOURCESTATE_VALID) {
        //     fprintf(stderr, "failed to make custom pipeline\n");
        //     exit(-1);
        // }
    }
    
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
        GL.viewport(x0, y0, ww, hh, 1);
            GL.defaults();
            GL.begin_triangles();
            GL.v2f_c3b( 0.0f,  0.5f, 255, 0, 0);
            GL.v2f_c3b(-0.5f, -0.5f, 0, 0, 255);
            GL.v2f_c3b( 0.5f, -0.5f, 0, 255, 0);
            GL.end();
        
        //draw quad
        GL.viewport(x1, y0, ww, hh, 1);
            float angle_deg = 0.0f;
            float scale = 1.0f + MathF.Sin(GL.rad(angle_deg)) * 0.5f;
            angle_deg += 1.0f * t;
            GL.defaults();
            GL.rotate(GL.rad(angle_deg), 0.0f, 0.0f, 1.0f);
            GL.scale(scale, scale, 1.0f);
            GL.begin_quads();
            GL.v2f_c3b( -0.5f, -0.5f,  255, 255, 0);
            GL.v2f_c3b(  0.5f, -0.5f,  0, 255, 0);
            GL.v2f_c3b(  0.5f,  0.5f,  0, 0, 255);
            GL.v2f_c3b( -0.5f,  0.5f,  255, 0, 0);
            GL.end();

        fixed (sg_pass_action* pass = &state.pass_action)
        {
            Gfx.begin_default_pass(pass,dw,dh);
            GL.draw();
            Gfx.end_pass();
            Gfx.commit();
        }
        
        
        
        
        
        
          /*
          float ratio = width/(float)height;
          
          var ptbf = new Utils.NativeArray<sgp_vec2>(4096);


          
          clearTest(width,height,ratio);
          rectangleTest(width,height,ratio);
          primitivesTest(width,height,ratio, ptbf);
          // textureTest(width,height,ratio);

          static void textureTest(int width,int height,float ratio)
          {
              GP.sgp_begin(width, height);
              GP.sgp_viewport(0, 0, width, height);
              GP.sgp_project(-ratio, ratio, 1.0f, -1.0f);

              GP.sgp_set_color(0.1f, 0.1f, 0.1f, 1.0f);
              GP.sgp_clear();


              // GP.sgp_set_image(0,image);
              GP.sgp_draw_textured_rect(0, 0, width, height);
              GP.sgp_reset_image(0);

              // Begin a render pass.
              var pass = default(sg_pass_action);
              Gfx.begin_default_pass(&pass, width, height);
              // Dispatch all draw commands to Sokol GFX.
              GP.sgp_flush();
              // Finish a draw command queue, clearing it.
              GP.sgp_end();
              // End render pass.
              Gfx.end_pass();
              // Commit Sokol render.
              Gfx.commit();
          }

          static void clearTest(int width,int height,float ratio)
          {
              var pass = default(sg_pass_action);
              pass.colors.e0.load_action = sg_load_action.SG_LOADACTION_CLEAR;
              pass.colors.e0.clear_value = new sg_color(){r = 1.0f,g=0f,b=0f,a=1.0f};
              Gfx.begin_default_pass(&pass,App.width(),App.height());
              Gfx.end_pass();
              Gfx.commit();
          }

          static void rectangleTest(int width,int height,float ratio)
          {
              //sgptest rectangle
              // Begin recording draw commands for a frame buffer of size (width, height).
              GP.sgp_begin(width, height);
              // Set frame buffer drawing region to (0,0,width,height).
              GP.sgp_viewport(0, 0, width, height);
              // Set drawing coordinate space to (left=-ratio, right=ratio, top=1, bottom=-1).
              GP.sgp_project(-ratio, ratio, 1.0f, -1.0f);

              // Clear the frame buffer.
              GP.sgp_set_color(0.1f, 0.1f, 0.1f, 1.0f);
              GP.sgp_clear();

              // Draw an animated rectangle that rotates and changes its colors.
              double time = App.frame_count() * App.frame_duration();
              var r = (float)(Math.Sin(time)*0.5+0.5);
              var g = (float)(Math.Cos(time)*0.5+0.5);
              GP.sgp_set_color(r, g, 0.3f, 1.0f);
              GP.sgp_rotate_at((float)time, 0.0f, 0.0f);
              GP.sgp_draw_filled_rect(-0.5f, -0.5f, 1.0f, 1.0f);

              // Begin a render pass.
              var pass = default(sg_pass_action);
              Gfx.begin_default_pass(&pass, width, height);
              // Dispatch all draw commands to Sokol GFX.
              GP.sgp_flush();
              // Finish a draw command queue, clearing it.
              GP.sgp_end();
              // End render pass.
              Gfx.end_pass();
              // Commit Sokol render.
              Gfx.commit();
          }

          static void primitivesTest(int width,int height,float ratio, Utils.NativeArray<sgp_vec2> ptbf)
          {

              //sgptest primitives
              // /*
              GP.sgp_begin(width, height);

              int hw = width / 2;
              int hh = height / 2;

              // draw background
              GP.sgp_set_color(0.05f, 0.05f, 0.05f, 1.0f);
              GP.sgp_clear();
              GP.sgp_reset_color();

              // top left
              GP.sgp_viewport(0, 0, hw, hh);
              GP.sgp_set_color(0.1f, 0.1f, 0.1f, 1.0f);
              GP.sgp_clear();
              GP.sgp_reset_color();
              GP.sgp_push_transform();
              GP.sgp_translate(0.0f, -hh / 4.0f);
              draw_rects();
              GP.sgp_pop_transform();
              GP.sgp_push_transform();
              GP.sgp_translate(0.0f, hh / 4.0f);
              GP.sgp_scissor(0, 0, hw, (int)(3.0f*hh / 4.0f));
              draw_rects();
              GP.sgp_reset_scissor();
              GP.sgp_pop_transform();

              // top right
              GP.sgp_viewport(hw, 0, hw, hh);
              draw_triangles(ptbf);

              // bottom left
              GP.sgp_viewport(0, hh, hw, hh);
              draw_points(ptbf);

              // bottom right
              GP.sgp_viewport(hw, hh, hw, hh);
              GP.sgp_set_color(0.1f, 0.1f, 0.1f, 1.0f);
              GP.sgp_clear();
              GP.sgp_reset_color();
              draw_lines(ptbf);

              // dispatch draw commands
              var pass = default(sg_pass_action);
              Gfx.begin_default_pass(&pass, width, height);
              GP.sgp_flush();
              GP.sgp_end();
              Gfx.end_pass();
              Gfx.commit();

              static void draw_rects()
              {
                  sgp_irect viewport = GP.sgp_query_state()->viewport;
                  int width = viewport.w, height = viewport.h;
                  int size = 64;
                  int hsize = size / 2;
                  float time = App.frame_count() / 60.0f;
                  float t = (float)(1.0f+Math.Sin(time))/2.0f;

                  // left
                  GP.sgp_push_transform();
                  GP.sgp_translate(width*0.25f - hsize, height*0.5f - hsize);
                  GP.sgp_translate(0.0f, 2*size*t - size);
                  GP.sgp_set_color(t, 0.3f, 1.0f-t, 1.0f);
                  GP.sgp_draw_filled_rect(0, 0, size, size);
                  GP.sgp_pop_transform();

                  // middle
                  GP.sgp_push_transform();
                  GP.sgp_translate(width*0.5f - hsize, height*0.5f - hsize);
                  GP.sgp_rotate_at(time, hsize, hsize);
                  GP.sgp_set_color(t, 1.0f - t, 0.3f, 1.0f);
                  GP.sgp_draw_filled_rect(0, 0, size, size);
                  GP.sgp_pop_transform();

                  // right
                  GP.sgp_push_transform();
                  GP.sgp_translate(width*0.75f - hsize, height*0.5f - hsize);
                  GP.sgp_scale_at(t + 0.25f, t + 0.5f, hsize, hsize);
                  GP.sgp_set_color(0.3f, t, 1.0f - t, 1.0f);
                  GP.sgp_draw_filled_rect(0, 0, size, size);
                  GP.sgp_pop_transform();
              }

              static void draw_points(Utils.NativeArray<sgp_vec2> ptbf)
              {
                  GP.sgp_set_color(1.0f, 1.0f, 1.0f, 1.0f);
                  sgp_irect viewport = GP.sgp_query_state()->viewport;
                  int width = viewport.w, height = viewport.h;
                  uint count = 0;
                  for(int y=64;y<height-64 && count < 4096;y+=8) {
                      for(int x=64;x<width-64 && count < 4096;x+=8) {
                          ptbf[(int)count].x = (float)x;
                          ptbf[(int)count].y = (float)y;
                          count++;
                      }
                  }
                  
                  //not working
                  // GP.sgp_draw_points((sgp_vec2*) Unsafe.AsPointer(ref points_buffer), count);
                  
                  //working - but bad becuase ptr isnt stable
                  // Span<sgp_vec2> s = points_buffer.AsSpan();
                  // ref var reference = ref MemoryMarshal.GetReference(s);
                  // GP.sgp_draw_points((sgp_vec2*) Unsafe.AsPointer(ref reference), count);

                  //working + maybe slow
                  // GP.sgp_draw_points((sgp_vec2*) bufferHandle.AddrOfPinnedObject(), count);

                  //new and improved
                  GP.sgp_draw_points(ptbf.Ptr, count);
                  
              }

              static void draw_lines(Utils.NativeArray<sgp_vec2> ptbf)
              {
                  GP.sgp_set_color(1.0f, 1.0f, 1.0f, 1.0f);
                  uint count = 0;
                  sgp_irect viewport = GP.sgp_query_state()->viewport;
                  ptbf[(int)count].x = viewport.w / 2.0f;
                  ptbf[(int)count].y = viewport.h / 2.0f;
                  var c = ptbf[0];
                  count++;
                  for(float theta = 0.0f; theta <= Math.PI*8.0f; theta+=(float)Math.PI/16.0f) {
                      float r = 10.0f*theta;
                      ptbf[(int)count].x = (float)(c.x + r*Math.Cos((double)theta));
                      ptbf[(int)count].y = (float)(c.y + r*Math.Sin((double)theta));
                      count++;
                  }
                  
                  //not working
                  // GP.sgp_draw_lines_strip((sgp_vec2*) Unsafe.AsPointer(ref points_buffer), count);

                  //working
                  // Span<sgp_vec2> s = points_buffer.AsSpan();
                  // ref var reference = ref MemoryMarshal.GetReference(s);
                  // GP.sgp_draw_lines_strip((sgp_vec2*) Unsafe.AsPointer(ref reference), count);

                  //working + maybe slow
                  // GP.sgp_draw_lines_strip((sgp_vec2*) bufferHandle.AddrOfPinnedObject(), count);
                  GP.sgp_draw_lines_strip(ptbf.Ptr, count);
              }

              static void draw_triangles(Utils.NativeArray<sgp_vec2> ptbf)
              {
                  sgp_irect viewport = GP.sgp_query_state()->viewport;
                  int width = viewport.w, height = viewport.h;
                  float hw = width * 0.5f;
                  float hh = height * 0.5f;
                  float w = height*0.2f;
                  float ax = hw - w, ay = hh + w;
                  float bx = hw,     by = hh - w;
                  float cx = hw + w, cy = hh + w;
                  GP.sgp_set_color(1.0f, 0.0f, 1.0f, 1.0f);
                  GP.sgp_push_transform();
                  GP.sgp_translate(-w*1.5f, 0.0f);
                  GP.sgp_draw_filled_triangle(ax, ay, bx, by, cx, cy);
                  GP.sgp_translate(w*3.0f, 0.0f);
                  uint count = 0;
                  float step = (float)(2.0f*Math.PI)/6.0f;
                  for(float theta = 0.0f; theta <= 2.0f*Math.PI + step*0.5f; theta+=step) {
                      ptbf[(int)count].x = (float)(hw + w*Math.Cos((double)theta));
                      ptbf[(int)count].y = (float)(hh - w*Math.Sin((double)theta));
                      count++;
                      if(count % 3 == 1) {
                          ptbf[(int)count].x = hw;
                          ptbf[(int)count].y = hh;
                          count++;
                      }
                  }
                  GP.sgp_set_color(0.0f, 1.0f, 1.0f, 1.0f);
                  // GP.sgp_draw_filled_triangles_strip((sgp_vec2*) bufferHandle.AddrOfPinnedObject(), count);
                  GP.sgp_draw_filled_triangles_strip(ptbf.Ptr, count);
                  GP.sgp_pop_transform();
              }
        }
              */

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

        // var TagStr = Marshal.PtrToStringAnsi((IntPtr)tag);
        // var MesageStr = Marshal.PtrToStringAnsi((IntPtr)message);
        // var FilenameStr = Marshal.PtrToStringAnsi((IntPtr)filename);
        var TagStr = new string(tag);
        var MesageStr = new string(message);
        var FilenameStr = new string(filename);
        Console.WriteLine($"[{(LogLevel)log_level}][{TagStr}] {(sg_log_item)log_item} {FilenameStr} Line={line_nr}");
        Console.WriteLine($"    {MesageStr}\n");
        System.Diagnostics.Debug.WriteLine($"Tag={TagStr} Level={log_level} Item={(sg_log_item)log_item} Message={MesageStr} Line={line_nr} FileName={FilenameStr}\n");
        
        // Gfx.destroy_image(image);
        /*
         * [sg][error][id:139] C:\Users\kyle\Workspace\Dinghy\Dinghy.Bootstrapper\libs\sokol\build/../src/sokol/sokol_gfx.h:14888:0: 
        VALIDATE_PIPELINEDESC_SHADER: sg_pipeline_desc.shader missing or invalid

[sg][error][id:140] C:\Users\kyle\Workspace\Dinghy\Dinghy.Bootstrapper\libs\sokol\build/../src/sokol/sokol_gfx.h:14896:0: 
        VALIDATE_PIPELINEDESC_NO_ATTRS: sg_pipeline_desc.layout.attrs is empty or not continuous

[sg][error][id:139] C:\Users\kyle\Workspace\Dinghy\Dinghy.Bootstrapper\libs\sokol\build/../src/sokol/sokol_gfx.h:14898:0: 
        VALIDATE_PIPELINEDESC_SHADER: sg_pipeline_desc.shader missing or invalid

[sg][panic][id:233] C:\Users\kyle\Workspace\Dinghy\Dinghy.Bootstrapper\libs\sokol\build/../src/sokol/sokol_gfx.h:14574:0: 
        VALIDATION_FAILED: validation layer checks failed

         */
        // GP.sgp_shutdown();
        // GL.shutdown();
        // Gfx.shutdown();
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