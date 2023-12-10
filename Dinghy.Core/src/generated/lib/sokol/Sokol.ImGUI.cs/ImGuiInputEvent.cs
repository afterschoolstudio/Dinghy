using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Dinghy.Internal.Sokol;

public partial struct ImGuiInputEvent
{
    public ImGuiInputEventType Type;

    public ImGuiInputSource Source;

    [NativeTypeName("ImU32")]
    public uint EventId;

    [NativeTypeName("__AnonymousRecord_cimgui_L1999_C5")]
    public _Anonymous_e__Union Anonymous;

    [NativeTypeName("bool")]
    public byte AddedByTestEngine;

    [UnscopedRef]
    public ref ImGuiInputEventMousePos MousePos
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return ref Anonymous.MousePos;
        }
    }

    [UnscopedRef]
    public ref ImGuiInputEventMouseWheel MouseWheel
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return ref Anonymous.MouseWheel;
        }
    }

    [UnscopedRef]
    public ref ImGuiInputEventMouseButton MouseButton
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return ref Anonymous.MouseButton;
        }
    }

    [UnscopedRef]
    public ref ImGuiInputEventMouseViewport MouseViewport
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return ref Anonymous.MouseViewport;
        }
    }

    [UnscopedRef]
    public ref ImGuiInputEventKey Key
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return ref Anonymous.Key;
        }
    }

    [UnscopedRef]
    public ref ImGuiInputEventText Text
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return ref Anonymous.Text;
        }
    }

    [UnscopedRef]
    public ref ImGuiInputEventAppFocused AppFocused
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return ref Anonymous.AppFocused;
        }
    }

    [StructLayout(LayoutKind.Explicit)]
    public partial struct _Anonymous_e__Union
    {
        [FieldOffset(0)]
        public ImGuiInputEventMousePos MousePos;

        [FieldOffset(0)]
        public ImGuiInputEventMouseWheel MouseWheel;

        [FieldOffset(0)]
        public ImGuiInputEventMouseButton MouseButton;

        [FieldOffset(0)]
        public ImGuiInputEventMouseViewport MouseViewport;

        [FieldOffset(0)]
        public ImGuiInputEventKey Key;

        [FieldOffset(0)]
        public ImGuiInputEventText Text;

        [FieldOffset(0)]
        public ImGuiInputEventAppFocused AppFocused;
    }
}
