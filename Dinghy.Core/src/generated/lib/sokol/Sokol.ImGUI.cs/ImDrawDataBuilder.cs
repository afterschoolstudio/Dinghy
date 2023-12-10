using System.Runtime.CompilerServices;

namespace Dinghy.Internal.Sokol;

public partial struct ImDrawDataBuilder
{
    [NativeTypeName("ImVector_ImDrawListPtr *[2]")]
    public _Layers_e__FixedBuffer Layers;

    public ImVector_ImDrawListPtr LayerData1;

    public unsafe partial struct _Layers_e__FixedBuffer
    {
        public ImVector_ImDrawListPtr* e0;
        public ImVector_ImDrawListPtr* e1;

        public ref ImVector_ImDrawListPtr* this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                fixed (ImVector_ImDrawListPtr** pThis = &e0)
                {
                    return ref pThis[index];
                }
            }
        }
    }
}
