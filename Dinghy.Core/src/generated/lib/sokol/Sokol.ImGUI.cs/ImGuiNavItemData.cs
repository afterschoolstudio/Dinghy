namespace Dinghy.Internal.Sokol;

public unsafe partial struct ImGuiNavItemData
{
    public ImGuiWindow* Window;

    [NativeTypeName("ImGuiID")]
    public uint ID;

    [NativeTypeName("ImGuiID")]
    public uint FocusScopeId;

    public ImRect RectRel;

    [NativeTypeName("ImGuiItemFlags")]
    public int InFlags;

    [NativeTypeName("ImGuiSelectionUserData")]
    public long SelectionUserData;

    public float DistBox;

    public float DistCenter;

    public float DistAxial;
}
