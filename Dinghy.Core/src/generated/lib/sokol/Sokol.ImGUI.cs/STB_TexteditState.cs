namespace Dinghy.Internal.Sokol;

public partial struct STB_TexteditState
{
    public int cursor;

    public int select_start;

    public int select_end;

    [NativeTypeName("unsigned char")]
    public byte insert_mode;

    public int row_count_per_page;

    [NativeTypeName("unsigned char")]
    public byte cursor_at_end_of_line;

    [NativeTypeName("unsigned char")]
    public byte initialized;

    [NativeTypeName("unsigned char")]
    public byte has_preferred_x;

    [NativeTypeName("unsigned char")]
    public byte single_line;

    [NativeTypeName("unsigned char")]
    public byte padding1;

    [NativeTypeName("unsigned char")]
    public byte padding2;

    [NativeTypeName("unsigned char")]
    public byte padding3;

    public float preferred_x;

    public StbUndoState undostate;
}
