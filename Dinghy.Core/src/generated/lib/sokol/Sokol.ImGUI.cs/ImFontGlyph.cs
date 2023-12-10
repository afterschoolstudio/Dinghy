using System.Runtime.CompilerServices;

namespace Dinghy.Internal.Sokol;

public partial struct ImFontGlyph
{
    public uint _bitfield;

    [NativeTypeName("unsigned int : 1")]
    public uint Colored
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            return _bitfield & 0x1u;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            _bitfield = (_bitfield & ~0x1u) | (value & 0x1u);
        }
    }

    [NativeTypeName("unsigned int : 1")]
    public uint Visible
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            return (_bitfield >> 1) & 0x1u;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            _bitfield = (_bitfield & ~(0x1u << 1)) | ((value & 0x1u) << 1);
        }
    }

    [NativeTypeName("unsigned int : 30")]
    public uint Codepoint
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            return (_bitfield >> 2) & 0x3FFFFFFFu;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            _bitfield = (_bitfield & ~(0x3FFFFFFFu << 2)) | ((value & 0x3FFFFFFFu) << 2);
        }
    }

    public float AdvanceX;

    public float X0;

    public float Y0;

    public float X1;

    public float Y1;

    public float U0;

    public float V0;

    public float U1;

    public float V1;
}
