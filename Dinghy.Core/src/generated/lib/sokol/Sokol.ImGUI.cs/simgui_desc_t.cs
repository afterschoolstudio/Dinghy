namespace Dinghy.Internal.Sokol;

public unsafe partial struct simgui_desc_t
{
    public int max_vertices;

    public int image_pool_size;

    public sg_pixel_format color_format;

    public sg_pixel_format depth_format;

    public int sample_count;

    [NativeTypeName("const char *")]
    public sbyte* ini_filename;

    [NativeTypeName("bool")]
    public byte no_default_font;

    [NativeTypeName("bool")]
    public byte disable_paste_override;

    [NativeTypeName("bool")]
    public byte disable_set_mouse_cursor;

    [NativeTypeName("bool")]
    public byte disable_windows_resize_from_edges;

    [NativeTypeName("bool")]
    public byte write_alpha_channel;

    public simgui_allocator_t allocator;

    public simgui_logger_t logger;
}
