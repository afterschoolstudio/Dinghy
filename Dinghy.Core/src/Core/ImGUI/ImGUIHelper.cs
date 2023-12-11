namespace Dinghy.Core.ImGUI;

public static class ImGUIHelper
{
    public static unsafe bool BeginMenu(string name)
    {
        var b = System.Text.Encoding.UTF8.GetBytes(name);
        fixed (byte* ptr = b)
        {
            return Internal.Sokol.ImGUI.igBeginMenu((sbyte*)ptr,1) > 0;
        }
    }
    
    public static unsafe bool MenuItem(string name, string shortcut)
    {
        var n = System.Text.Encoding.UTF8.GetBytes(name);
        var s = System.Text.Encoding.UTF8.GetBytes(shortcut);
        fixed (byte* n_p = n, s_p = s)
        {
            return Internal.Sokol.ImGUI.igMenuItem_Bool((sbyte*)n_p,(sbyte*)s_p,0,1) > 0;
        }
    }
}