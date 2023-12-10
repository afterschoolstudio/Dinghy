namespace Dinghy.Internal.Sokol;

public unsafe partial struct ImGuiSettingsHandler
{
    [NativeTypeName("const char *")]
    public sbyte* TypeName;

    [NativeTypeName("ImGuiID")]
    public uint TypeHash;

    [NativeTypeName("void (*)(ImGuiContext *, ImGuiSettingsHandler *)")]
    public delegate* unmanaged[Cdecl]<ImGuiContext*, ImGuiSettingsHandler*, void> ClearAllFn;

    [NativeTypeName("void (*)(ImGuiContext *, ImGuiSettingsHandler *)")]
    public delegate* unmanaged[Cdecl]<ImGuiContext*, ImGuiSettingsHandler*, void> ReadInitFn;

    [NativeTypeName("void *(*)(ImGuiContext *, ImGuiSettingsHandler *, const char *)")]
    public delegate* unmanaged[Cdecl]<ImGuiContext*, ImGuiSettingsHandler*, sbyte*, void*> ReadOpenFn;

    [NativeTypeName("void (*)(ImGuiContext *, ImGuiSettingsHandler *, void *, const char *)")]
    public delegate* unmanaged[Cdecl]<ImGuiContext*, ImGuiSettingsHandler*, void*, sbyte*, void> ReadLineFn;

    [NativeTypeName("void (*)(ImGuiContext *, ImGuiSettingsHandler *)")]
    public delegate* unmanaged[Cdecl]<ImGuiContext*, ImGuiSettingsHandler*, void> ApplyAllFn;

    [NativeTypeName("void (*)(ImGuiContext *, ImGuiSettingsHandler *, ImGuiTextBuffer *)")]
    public delegate* unmanaged[Cdecl]<ImGuiContext*, ImGuiSettingsHandler*, ImGuiTextBuffer*, void> WriteAllFn;

    public void* UserData;
}
