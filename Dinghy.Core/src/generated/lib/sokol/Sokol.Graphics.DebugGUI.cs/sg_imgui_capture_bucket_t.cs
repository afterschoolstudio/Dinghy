using System.Runtime.CompilerServices;

namespace Dinghy.Internal.Sokol;

public unsafe partial struct sg_imgui_capture_bucket_t
{
    [NativeTypeName("size_t")]
    public nuint ubuf_size;

    [NativeTypeName("size_t")]
    public nuint ubuf_pos;

    [NativeTypeName("uint8_t *")]
    public byte* ubuf;

    public int num_items;

    [NativeTypeName("sg_imgui_capture_item_t[4096]")]
    public _items_e__FixedBuffer items;

    [InlineArray(4096)]
    public partial struct _items_e__FixedBuffer
    {
        public sg_imgui_capture_item_t e0;
    }
}
