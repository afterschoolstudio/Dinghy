namespace Dinghy.Core.ImGUI;

public static class ImGUIHelper
{
    public static unsafe bool BeginMenu(string name, bool enabled = true)
    {
        var b = System.Text.Encoding.UTF8.GetBytes(name);
        fixed (byte* ptr = b)
        {
            return Internal.Sokol.ImGUI.igBeginMenu((sbyte*)ptr,(byte)(enabled ? 1 : 0)) > 0;
        }
    }
    
    public static unsafe bool MenuItem(string name, string shortcut = "", bool selected = false, bool enabled = true)
    {
        var n = System.Text.Encoding.UTF8.GetBytes(name);
        var s = System.Text.Encoding.UTF8.GetBytes(shortcut);
        fixed (byte* n_p = n, s_p = s)
        {
            return Internal.Sokol.ImGUI.igMenuItem_Bool((sbyte*)n_p,(sbyte*)s_p,(byte)(selected ? 1 : 0),(byte)(enabled ? 1 : 0)) > 0;
        }
    }

    public static unsafe bool Checkbox(string name, bool value)
    {
        var n = System.Text.Encoding.UTF8.GetBytes(name);
        fixed (byte* n_p = n)
        {
            return Internal.Sokol.ImGUI.igCheckbox((sbyte*)n_p,&value) > 0;
        }
    }

    public readonly record struct Menu(string Name, List<MenuItemR> Items);
    public readonly record struct MenuItemR(string Name, string Shortcut = "", bool Enabled = true, bool Selected = false, Action OnSelected = null);
    public readonly record struct MainMenuBar(List<Menu> menuOptions)
    {
        public void Render()
        {
            Internal.Sokol.ImGUI.igBeginMainMenuBar();
            foreach (var menuOption in menuOptions)
            {
                if (BeginMenu(menuOption.Name))
                {
                    foreach (var menuItem in menuOption.Items)
                    {
                        if (MenuItem(menuItem.Name, menuItem.Shortcut, menuItem.Selected, menuItem.Enabled))
                        {
                            menuItem.OnSelected?.Invoke();
                        }
                    }
                    Internal.Sokol.ImGUI.igEndMenu();
                }
            }
            Internal.Sokol.ImGUI.igEndMainMenuBar();
        }
    }

    public static MainMenuBar MainMenuBarT = new MainMenuBar(null);
    public static Menu MenuT = new Menu("",null);
    public static MenuItemR MenuItemT = new MenuItemR("");
    
}