namespace Dinghy.Internal.Sokol;

public unsafe partial struct ImGuiContextHook
{
    [NativeTypeName("ImGuiID")]
    public uint HookId;

    public ImGuiContextHookType Type;

    [NativeTypeName("ImGuiID")]
    public uint Owner;

    [NativeTypeName("ImGuiContextHookCallback")]
    public delegate* unmanaged[Cdecl]<ImGuiContext*, ImGuiContextHook*, void> Callback;

    public void* UserData;
}
