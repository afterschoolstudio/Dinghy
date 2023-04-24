namespace Dinghy;

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
                var desc = default(sapp_desc);
                desc.width = 1920;
                desc.height = 1080;
                desc.icon.sokol_default = 1;
                desc.window_title = (sbyte*)ptr;
                desc.init_cb = &Initialize;
                desc.event_cb = &Event;
                desc.frame_cb = &Frame;
                desc.cleanup_cb = &Cleanup;
                desc.logger.func = &Sokol.slog_func;
                Sokol.sapp_run(&desc);
            }
        }
    }
    
    [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
    private static unsafe void Event(sapp_event* e)
    {
        // var width = Sokol.sapp_width();
        // var height = Sokol.sapp_height();
        // Console.WriteLine(e->type);
    }
    
    [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
    private static unsafe void Initialize()
    {
        //sokol init
        var desc = default(sg_desc);
        desc.context = Sokol.sapp_sgcontext();
        Sokol.sg_setup(&desc);

        //sokol_gp init
        var sgp_desc = default(sgp_desc);
        Sokol.sgp_setup(&sgp_desc);

        LoadImage("testimg.png");

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
        var width = Sokol.sapp_width();
        var height = Sokol.sapp_height();
        float ratio = width/(float)height;
        
        var ptbf = new util.NativeArray<sgp_vec2>(4096);


        
        // clearTest(width,height,ratio);
        // rectangleTest(width,height,ratio);
        // primitivesTest(width,height,ratio);
        textureTest(width,height,ratio);

        static void textureTest(int width,int height,float ratio)
        {
            Sokol.sgp_begin(width, height);
            Sokol.sgp_viewport(0, 0, width, height);
            // Sokol.sgp_project(-ratio, ratio, 1.0f, -1.0f);

            // Sokol.sgp_set_color(0.1f, 0.1f, 0.1f, 1.0f);
            Sokol.sgp_clear();


            Sokol.sgp_set_image(0,image);
            Sokol.sgp_draw_textured_rect(0, 0, width, height);
            Sokol.sgp_reset_image(0);

            // Begin a render pass.
            var pass = default(sg_pass_action);
            Sokol.sg_begin_default_pass(&pass, width, height);
            // Dispatch all draw commands to Sokol GFX.
            Sokol.sgp_flush();
            // Finish a draw command queue, clearing it.
            Sokol.sgp_end();
            // End render pass.
            Sokol.sg_end_pass();
            // Commit Sokol render.
            Sokol.sg_commit();
        }

        static void clearTest(int width,int height,float ratio)
        {
            var pass = default(sg_pass_action);
            pass.colors.e0.action = sg_action.SG_ACTION_CLEAR;
            pass.colors.e0.value = new sg_color(){r = 1.0f,g=0f,b=0f,a=1.0f};
            Sokol.sg_begin_default_pass(&pass,Sokol.sapp_width(),Sokol.sapp_height());
            Sokol.sg_end_pass();
            Sokol.sg_commit();
        }

        static void rectangleTest(int width,int height,float ratio)
        {
            //sgptest rectangle
            // Begin recording draw commands for a frame buffer of size (width, height).
            Sokol.sgp_begin(width, height);
            // Set frame buffer drawing region to (0,0,width,height).
            Sokol.sgp_viewport(0, 0, width, height);
            // Set drawing coordinate space to (left=-ratio, right=ratio, top=1, bottom=-1).
            Sokol.sgp_project(-ratio, ratio, 1.0f, -1.0f);

            // Clear the frame buffer.
            Sokol.sgp_set_color(0.1f, 0.1f, 0.1f, 1.0f);
            Sokol.sgp_clear();

            // Draw an animated rectangle that rotates and changes its colors.
            double time = Sokol.sapp_frame_count() * Sokol.sapp_frame_duration();
            var r = (float)(Math.Sin(time)*0.5+0.5);
            var g = (float)(Math.Cos(time)*0.5+0.5);
            Sokol.sgp_set_color(r, g, 0.3f, 1.0f);
            Sokol.sgp_rotate_at((float)time, 0.0f, 0.0f);
            Sokol.sgp_draw_filled_rect(-0.5f, -0.5f, 1.0f, 1.0f);

            // Begin a render pass.
            var pass = default(sg_pass_action);
            Sokol.sg_begin_default_pass(&pass, width, height);
            // Dispatch all draw commands to Sokol GFX.
            Sokol.sgp_flush();
            // Finish a draw command queue, clearing it.
            Sokol.sgp_end();
            // End render pass.
            Sokol.sg_end_pass();
            // Commit Sokol render.
            Sokol.sg_commit();
        }

        static void primitivesTest(int width,int height,float ratio)
        {

            //sgptest primitives
            // /*
            Sokol.sgp_begin(width, height);

            int hw = width / 2;
            int hh = height / 2;

            // draw background
            Sokol.sgp_set_color(0.05f, 0.05f, 0.05f, 1.0f);
            Sokol.sgp_clear();
            Sokol.sgp_reset_color();

            // top left
            Sokol.sgp_viewport(0, 0, hw, hh);
            Sokol.sgp_set_color(0.1f, 0.1f, 0.1f, 1.0f);
            Sokol.sgp_clear();
            Sokol.sgp_reset_color();
            Sokol.sgp_push_transform();
            Sokol.sgp_translate(0.0f, -hh / 4.0f);
            draw_rects();
            Sokol.sgp_pop_transform();
            Sokol.sgp_push_transform();
            Sokol.sgp_translate(0.0f, hh / 4.0f);
            Sokol.sgp_scissor(0, 0, hw, (int)(3.0f*hh / 4.0f));
            draw_rects();
            Sokol.sgp_reset_scissor();
            Sokol.sgp_pop_transform();

            // top right
            Sokol.sgp_viewport(hw, 0, hw, hh);
            draw_triangles();

            // bottom left
            Sokol.sgp_viewport(0, hh, hw, hh);
            draw_points();

            // bottom right
            Sokol.sgp_viewport(hw, hh, hw, hh);
            Sokol.sgp_set_color(0.1f, 0.1f, 0.1f, 1.0f);
            Sokol.sgp_clear();
            Sokol.sgp_reset_color();
            draw_lines();

            // dispatch draw commands
            var pass = default(sg_pass_action);
            Sokol.sg_begin_default_pass(&pass, width, height);
            Sokol.sgp_flush();
            Sokol.sgp_end();
            Sokol.sg_end_pass();
            Sokol.sg_commit();

            static void draw_rects()
            {
                sgp_irect viewport = Sokol.sgp_query_state()->viewport;
                int width = viewport.w, height = viewport.h;
                int size = 64;
                int hsize = size / 2;
                float time = Sokol.sapp_frame_count() / 60.0f;
                float t = (float)(1.0f+Math.Sin(time))/2.0f;

                // left
                Sokol.sgp_push_transform();
                Sokol.sgp_translate(width*0.25f - hsize, height*0.5f - hsize);
                Sokol.sgp_translate(0.0f, 2*size*t - size);
                Sokol.sgp_set_color(t, 0.3f, 1.0f-t, 1.0f);
                Sokol.sgp_draw_filled_rect(0, 0, size, size);
                Sokol.sgp_pop_transform();

                // middle
                Sokol.sgp_push_transform();
                Sokol.sgp_translate(width*0.5f - hsize, height*0.5f - hsize);
                Sokol.sgp_rotate_at(time, hsize, hsize);
                Sokol.sgp_set_color(t, 1.0f - t, 0.3f, 1.0f);
                Sokol.sgp_draw_filled_rect(0, 0, size, size);
                Sokol.sgp_pop_transform();

                // right
                Sokol.sgp_push_transform();
                Sokol.sgp_translate(width*0.75f - hsize, height*0.5f - hsize);
                Sokol.sgp_scale_at(t + 0.25f, t + 0.5f, hsize, hsize);
                Sokol.sgp_set_color(0.3f, t, 1.0f - t, 1.0f);
                Sokol.sgp_draw_filled_rect(0, 0, size, size);
                Sokol.sgp_pop_transform();
            }

            static void draw_points()
            {
                Sokol.sgp_set_color(1.0f, 1.0f, 1.0f, 1.0f);
                sgp_irect viewport = Sokol.sgp_query_state()->viewport;
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
                // Sokol.sgp_draw_points((sgp_vec2*) Unsafe.AsPointer(ref points_buffer), count);
                
                //working - but bad becuase ptr isnt stable
                // Span<sgp_vec2> s = points_buffer.AsSpan();
                // ref var reference = ref MemoryMarshal.GetReference(s);
                // Sokol.sgp_draw_points((sgp_vec2*) Unsafe.AsPointer(ref reference), count);

                //working + maybe slow
                // Sokol.sgp_draw_points((sgp_vec2*) bufferHandle.AddrOfPinnedObject(), count);

                //new and improved
                Sokol.sgp_draw_points(ptbf.Ptr, count);
                
            }

            static void draw_lines()
            {
                Sokol.sgp_set_color(1.0f, 1.0f, 1.0f, 1.0f);
                uint count = 0;
                sgp_irect viewport = Sokol.sgp_query_state()->viewport;
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
                // Sokol.sgp_draw_lines_strip((sgp_vec2*) Unsafe.AsPointer(ref points_buffer), count);

                //working
                // Span<sgp_vec2> s = points_buffer.AsSpan();
                // ref var reference = ref MemoryMarshal.GetReference(s);
                // Sokol.sgp_draw_lines_strip((sgp_vec2*) Unsafe.AsPointer(ref reference), count);

                //working + maybe slow
                // Sokol.sgp_draw_lines_strip((sgp_vec2*) bufferHandle.AddrOfPinnedObject(), count);
                Sokol.sgp_draw_lines_strip(ptbf.Ptr, count);
            }

            static void draw_triangles()
            {
                sgp_irect viewport = Sokol.sgp_query_state()->viewport;
                int width = viewport.w, height = viewport.h;
                float hw = width * 0.5f;
                float hh = height * 0.5f;
                float w = height*0.2f;
                float ax = hw - w, ay = hh + w;
                float bx = hw,     by = hh - w;
                float cx = hw + w, cy = hh + w;
                Sokol.sgp_set_color(1.0f, 0.0f, 1.0f, 1.0f);
                Sokol.sgp_push_transform();
                Sokol.sgp_translate(-w*1.5f, 0.0f);
                Sokol.sgp_draw_filled_triangle(ax, ay, bx, by, cx, cy);
                Sokol.sgp_translate(w*3.0f, 0.0f);
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
                Sokol.sgp_set_color(0.0f, 1.0f, 1.0f, 1.0f);
                // Sokol.sgp_draw_filled_triangles_strip((sgp_vec2*) bufferHandle.AddrOfPinnedObject(), count);
                Sokol.sgp_draw_filled_triangles_strip(ptbf.Ptr, count);
                Sokol.sgp_pop_transform();
            }
            // */
        }

    }

    [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
    private static unsafe void Cleanup()
    {
        Sokol.sg_destroy_image(image);
        Sokol.sgp_shutdown();
        Sokol.sg_shutdown();
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
                var image_desc = default(sg_image_desc);
                image_desc.width = 64;
                image_desc.height = 64;
                image_desc.min_filter = sg_filter.SG_FILTER_LINEAR;
                image_desc.mag_filter = sg_filter.SG_FILTER_LINEAR;
                image_desc.wrap_u = sg_wrap.SG_WRAP_REPEAT;
                image_desc.wrap_v = sg_wrap.SG_WRAP_REPEAT;
                // image_desc.data = default(sg_image_data);
                image_desc.data.subimage.e0_0.ptr = imgPtr;
                // var r = default(sg_range);
                // r.size
                // image_desc.data.subimage.e0_0.size = (nuint)2; // * 4?
                image_desc.data.subimage.e0_0.size = (nuint)(64*64*4*sizeof(byte)); //works
                // image_desc.data.subimage.e0_0.size = (nuint)(testImgBytes.Length * sizeof(byte)); //works
                var image = Sokol.sg_make_image(&image_desc);
                
                if(Sokol.sg_query_image_state(image) != sg_resource_state.SG_RESOURCESTATE_VALID) {
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