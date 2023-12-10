namespace Dinghy.Internal.Sokol;

public partial struct ImGuiKeyOwnerData
{
    [NativeTypeName("ImGuiID")]
    public uint OwnerCurr;

    [NativeTypeName("ImGuiID")]
    public uint OwnerNext;

    [NativeTypeName("bool")]
    public byte LockThisFrame;

    [NativeTypeName("bool")]
    public byte LockUntilRelease;
}
