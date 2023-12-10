namespace Dinghy.Internal.Sokol;

public unsafe partial struct ImGuiPlatformIO
{
    [NativeTypeName("void (*)(ImGuiViewport *)")]
    public delegate* unmanaged[Cdecl]<ImGuiViewport*, void> Platform_CreateWindow;

    [NativeTypeName("void (*)(ImGuiViewport *)")]
    public delegate* unmanaged[Cdecl]<ImGuiViewport*, void> Platform_DestroyWindow;

    [NativeTypeName("void (*)(ImGuiViewport *)")]
    public delegate* unmanaged[Cdecl]<ImGuiViewport*, void> Platform_ShowWindow;

    [NativeTypeName("void (*)(ImGuiViewport *, ImVec2)")]
    public delegate* unmanaged[Cdecl]<ImGuiViewport*, ImVec2, void> Platform_SetWindowPos;

    [NativeTypeName("ImVec2 (*)(ImGuiViewport *)")]
    public delegate* unmanaged[Cdecl]<ImGuiViewport*, ImVec2> Platform_GetWindowPos;

    [NativeTypeName("void (*)(ImGuiViewport *, ImVec2)")]
    public delegate* unmanaged[Cdecl]<ImGuiViewport*, ImVec2, void> Platform_SetWindowSize;

    [NativeTypeName("ImVec2 (*)(ImGuiViewport *)")]
    public delegate* unmanaged[Cdecl]<ImGuiViewport*, ImVec2> Platform_GetWindowSize;

    [NativeTypeName("void (*)(ImGuiViewport *)")]
    public delegate* unmanaged[Cdecl]<ImGuiViewport*, void> Platform_SetWindowFocus;

    [NativeTypeName("bool (*)(ImGuiViewport *)")]
    public delegate* unmanaged[Cdecl]<ImGuiViewport*, byte> Platform_GetWindowFocus;

    [NativeTypeName("bool (*)(ImGuiViewport *)")]
    public delegate* unmanaged[Cdecl]<ImGuiViewport*, byte> Platform_GetWindowMinimized;

    [NativeTypeName("void (*)(ImGuiViewport *, const char *)")]
    public delegate* unmanaged[Cdecl]<ImGuiViewport*, sbyte*, void> Platform_SetWindowTitle;

    [NativeTypeName("void (*)(ImGuiViewport *, float)")]
    public delegate* unmanaged[Cdecl]<ImGuiViewport*, float, void> Platform_SetWindowAlpha;

    [NativeTypeName("void (*)(ImGuiViewport *)")]
    public delegate* unmanaged[Cdecl]<ImGuiViewport*, void> Platform_UpdateWindow;

    [NativeTypeName("void (*)(ImGuiViewport *, void *)")]
    public delegate* unmanaged[Cdecl]<ImGuiViewport*, void*, void> Platform_RenderWindow;

    [NativeTypeName("void (*)(ImGuiViewport *, void *)")]
    public delegate* unmanaged[Cdecl]<ImGuiViewport*, void*, void> Platform_SwapBuffers;

    [NativeTypeName("float (*)(ImGuiViewport *)")]
    public delegate* unmanaged[Cdecl]<ImGuiViewport*, float> Platform_GetWindowDpiScale;

    [NativeTypeName("void (*)(ImGuiViewport *)")]
    public delegate* unmanaged[Cdecl]<ImGuiViewport*, void> Platform_OnChangedViewport;

    [NativeTypeName("int (*)(ImGuiViewport *, ImU64, const void *, ImU64 *)")]
    public delegate* unmanaged[Cdecl]<ImGuiViewport*, ulong, void*, ulong*, int> Platform_CreateVkSurface;

    [NativeTypeName("void (*)(ImGuiViewport *)")]
    public delegate* unmanaged[Cdecl]<ImGuiViewport*, void> Renderer_CreateWindow;

    [NativeTypeName("void (*)(ImGuiViewport *)")]
    public delegate* unmanaged[Cdecl]<ImGuiViewport*, void> Renderer_DestroyWindow;

    [NativeTypeName("void (*)(ImGuiViewport *, ImVec2)")]
    public delegate* unmanaged[Cdecl]<ImGuiViewport*, ImVec2, void> Renderer_SetWindowSize;

    [NativeTypeName("void (*)(ImGuiViewport *, void *)")]
    public delegate* unmanaged[Cdecl]<ImGuiViewport*, void*, void> Renderer_RenderWindow;

    [NativeTypeName("void (*)(ImGuiViewport *, void *)")]
    public delegate* unmanaged[Cdecl]<ImGuiViewport*, void*, void> Renderer_SwapBuffers;

    public ImVector_ImGuiPlatformMonitor Monitors;

    public ImVector_ImGuiViewportPtr Viewports;
}
