namespace Dinghy.Internal.Sokol;

public unsafe partial struct ImGuiWindowDockStyle
{
    [NativeTypeName("ImU32[6]")]
    public fixed uint Colors[6];
}
