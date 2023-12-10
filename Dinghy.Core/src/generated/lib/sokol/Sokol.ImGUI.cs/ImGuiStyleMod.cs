using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Dinghy.Internal.Sokol;

public unsafe partial struct ImGuiStyleMod
{
    [NativeTypeName("ImGuiStyleVar")]
    public int VarIdx;

    [NativeTypeName("__AnonymousRecord_cimgui_L1768_C5")]
    public _Anonymous_e__Union Anonymous;

    [UnscopedRef]
    public Span<int> BackupInt
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return MemoryMarshal.CreateSpan(ref Anonymous.BackupInt[0], 2);
        }
    }

    [UnscopedRef]
    public Span<float> BackupFloat
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return MemoryMarshal.CreateSpan(ref Anonymous.BackupFloat[0], 2);
        }
    }

    [StructLayout(LayoutKind.Explicit)]
    public unsafe partial struct _Anonymous_e__Union
    {
        [FieldOffset(0)]
        [NativeTypeName("int[2]")]
        public fixed int BackupInt[2];

        [FieldOffset(0)]
        [NativeTypeName("float[2]")]
        public fixed float BackupFloat[2];
    }
}
