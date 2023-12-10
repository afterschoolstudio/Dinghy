namespace Dinghy.Internal.Sokol;

public unsafe partial struct sg_imgui_images_t
{
    [NativeTypeName("bool")]
    public byte open;

    public int num_slots;

    public sg_image sel_img;

    public sg_imgui_image_t* slots;
}
