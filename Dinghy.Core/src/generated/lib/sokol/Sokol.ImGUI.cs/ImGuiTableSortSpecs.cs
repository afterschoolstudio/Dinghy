namespace Dinghy.Internal.Sokol;

public unsafe partial struct ImGuiTableSortSpecs
{
    [NativeTypeName("const ImGuiTableColumnSortSpecs *")]
    public ImGuiTableColumnSortSpecs* Specs;

    public int SpecsCount;

    [NativeTypeName("bool")]
    public byte SpecsDirty;
}
