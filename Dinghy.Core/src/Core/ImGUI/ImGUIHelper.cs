using Dinghy.Internal.Sokol;

namespace Dinghy.Core.ImGUI;

public static class ImGUIHelper
{
    public static class Wrappers
    {
        public static unsafe bool BeginMenu(string name, bool enabled = true)
        {
            var b = System.Text.Encoding.UTF8.GetBytes(name);
            fixed (byte* ptr = b)
            {
                return Internal.Sokol.ImGUI.igBeginMenu((sbyte*)ptr,(byte)(enabled ? 1 : 0)) > 0;
            }
        }
        public static void EndMenu() => Internal.Sokol.ImGUI.igEndMenu();
        
        public static unsafe bool MenuItem(string name, string shortcut = "", bool selected = false, bool enabled = true)
        {
            var n = System.Text.Encoding.UTF8.GetBytes(name);
            var s = System.Text.Encoding.UTF8.GetBytes(shortcut);
            fixed (byte* n_p = n, s_p = s)
            {
                return Internal.Sokol.ImGUI.igMenuItem_Bool((sbyte*)n_p,(sbyte*)s_p,(byte)(selected ? 1 : 0),(byte)(enabled ? 1 : 0)) > 0;
            }
        }

        public static unsafe bool Checkbox(string name, ref bool value)
        {
            var n = System.Text.Encoding.UTF8.GetBytes(name);
            fixed (byte* n_p = n)
            {
                fixed (bool* bool_p = &value)
                {
                    return Internal.Sokol.ImGUI.igCheckbox((sbyte*)n_p,bool_p) > 0;
                }
            }
        }
        
        public static unsafe bool Checkbox(string name, ref byte value)
        {
            var n = System.Text.Encoding.UTF8.GetBytes(name);
            bool v = value != 0;
            fixed (byte* n_p = n)
            {
                var r = Internal.Sokol.ImGUI.igCheckbox((sbyte*)n_p,&v) > 0;
                value = (byte)(v ? 1 : 0);
                return r;
            }
        }

        public static unsafe void Text(string text)
        {
            var t = System.Text.Encoding.UTF8.GetBytes(text);
            fixed (byte* t_p = t)
            {
                Internal.Sokol.ImGUI.igText((sbyte*)t_p);
            }
        }

        public static unsafe void DragFloat(string label, ref float value, float speed, float min, float max, string format, ImGuiSliderFlags_ flags)
        {
            var t = System.Text.Encoding.UTF8.GetBytes(label);
            var f = System.Text.Encoding.UTF8.GetBytes(format);
            float v = value;
            fixed (byte* t_p = t,fmt_p = f)
            {
                Internal.Sokol.ImGUI.igDragFloat((sbyte*)t_p, &v, speed, min, max, (sbyte*)fmt_p, (int)flags);
                value = v;
            }
        }
        public static void Seperator()
        {
            Internal.Sokol.ImGUI.igSeparator();
        }
        public static void BeginMainMenuBar() => Internal.Sokol.ImGUI.igBeginMainMenuBar();
        public static void EndMainMenuBar() => Internal.Sokol.ImGUI.igEndMainMenuBar();

        public static unsafe void Begin(string name, ImGuiWindowFlags_ flags)
        {
            var n = System.Text.Encoding.UTF8.GetBytes(name);
            fixed (byte* n_p = n)
            {
                var opened = false;
                Internal.Sokol.ImGUI.igBegin((sbyte*)n_p, &opened, (int)flags);
            }
        }

        public static void End()
        {
            Internal.Sokol.ImGUI.igEnd();
        }

        public static void SetNextWindowPosition(float x, float y, Internal.Sokol.ImGuiCond_ condition, float pivot_x, float pivot_y)
        {
            Internal.Sokol.ImGUI.igSetNextWindowPos(new(){x = x, y=y}, (int)condition, new ImVec2(){x = pivot_x,y=pivot_y});
        }
        public static unsafe void ShowStats(string frameRate, string entities, string mouse)
        {
            //ported from the demo
            const float padding = 10.0f;
            var window_flags = ImGuiWindowFlags_.ImGuiWindowFlags_NoDecoration | ImGuiWindowFlags_.ImGuiWindowFlags_NoDocking | ImGuiWindowFlags_.ImGuiWindowFlags_AlwaysAutoResize | ImGuiWindowFlags_.ImGuiWindowFlags_NoSavedSettings | ImGuiWindowFlags_.ImGuiWindowFlags_NoFocusOnAppearing | ImGuiWindowFlags_.ImGuiWindowFlags_NoNav;
            var viewport = Internal.Sokol.ImGUI.igGetMainViewport();
            var work_pos = viewport->WorkPos; // Use work area to avoid menu-bar/task-bar, if any!
            var work_size = viewport->WorkSize;
            ImVec2 window_pos = default;
            ImVec2 window_pos_pivot = default;
            window_pos.x = (work_pos.x + padding);
            window_pos.y = (work_pos.y + padding);
            Internal.Sokol.ImGUI.igSetNextWindowPos(window_pos, (int)Internal.Sokol.ImGuiCond_.ImGuiCond_Always, window_pos_pivot);
            Internal.Sokol.ImGUI.igSetNextWindowViewport(viewport->ID);
            window_flags |= ImGuiWindowFlags_.ImGuiWindowFlags_NoMove;
            Internal.Sokol.ImGUI.igSetNextWindowBgAlpha(0.35f);
            Begin("Dinghy Stats",window_flags);
            Text(frameRate);
            Text(entities);
            Text(mouse);
            End();
        }
    }
}