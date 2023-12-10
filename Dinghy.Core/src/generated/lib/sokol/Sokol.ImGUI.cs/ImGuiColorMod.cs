namespace Dinghy.Internal.Sokol;

public partial struct ImGuiColorMod
{
    [NativeTypeName("ImGuiCol")]
    public int Col;

    public ImVec4 BackupValue;
}
