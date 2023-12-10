using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Dinghy.Internal.Sokol;

public unsafe partial struct ImGuiStoragePair
{
    [NativeTypeName("ImGuiID")]
    public uint key;

    [NativeTypeName("__AnonymousRecord_cimgui_L1138_C9")]
    public _Anonymous_e__Union Anonymous;

    [UnscopedRef]
    public ref int val_i
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return ref Anonymous.val_i;
        }
    }

    [UnscopedRef]
    public ref float val_f
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return ref Anonymous.val_f;
        }
    }

    [UnscopedRef]
    public ref void* val_p
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return ref Anonymous.val_p;
        }
    }

    [StructLayout(LayoutKind.Explicit)]
    public unsafe partial struct _Anonymous_e__Union
    {
        [FieldOffset(0)]
        public int val_i;

        [FieldOffset(0)]
        public float val_f;

        [FieldOffset(0)]
        public void* val_p;
    }
}
