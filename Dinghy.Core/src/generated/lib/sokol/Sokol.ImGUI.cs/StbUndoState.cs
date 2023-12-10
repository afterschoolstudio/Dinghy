using System.Runtime.CompilerServices;

namespace Dinghy.Internal.Sokol;

public unsafe partial struct StbUndoState
{
    [NativeTypeName("StbUndoRecord[99]")]
    public _undo_rec_e__FixedBuffer undo_rec;

    [NativeTypeName("ImWchar[999]")]
    public fixed ushort undo_char[999];

    public short undo_point;

    public short redo_point;

    public int undo_char_point;

    public int redo_char_point;

    [InlineArray(99)]
    public partial struct _undo_rec_e__FixedBuffer
    {
        public StbUndoRecord e0;
    }
}
