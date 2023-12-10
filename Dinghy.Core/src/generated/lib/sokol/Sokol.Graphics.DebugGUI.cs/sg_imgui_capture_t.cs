using System.Runtime.CompilerServices;

namespace Dinghy.Internal.Sokol;

public partial struct sg_imgui_capture_t
{
    [NativeTypeName("bool")]
    public byte open;

    public int bucket_index;

    public int sel_item;

    [NativeTypeName("sg_imgui_capture_bucket_t[2]")]
    public _bucket_e__FixedBuffer bucket;

    [InlineArray(2)]
    public partial struct _bucket_e__FixedBuffer
    {
        public sg_imgui_capture_bucket_t e0;
    }
}
