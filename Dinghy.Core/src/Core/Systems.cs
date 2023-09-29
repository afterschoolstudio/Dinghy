using Arch.Core;
using Dinghy.Internal.Sokol;
using static Dinghy.Resources;

namespace Dinghy;

public class DSystem {}
public interface IUpdateSystem
{
    void Update();
}
public class VelocitySystem : DSystem, IUpdateSystem
{
    QueryDescription query = new QueryDescription().WithAll<Position, Velocity>();      // Should have all specified components
    QueryDescription bunny = new QueryDescription().WithAll<Position, Velocity,BunnyMark>();      // Should have all specified components
    public void Update()
    {
        Engine.World.Query(in query, (in Entity e, ref Position pos, ref Velocity vel) => {
            pos.x += (int)vel.x;
            pos.y += (int)vel.y;
        });
        
        Engine.World.Query(in bunny, (in Entity e, ref Position pos, ref Velocity vel) => {
            vel.y += 9.8f;
            
            if (pos.x > Engine.Width)
            {
                vel.x *= -1;
                pos.x = Engine.Width;
            }
            else if (pos.x < 0)
            {
                vel.x *= -1;
                pos.x = 0;
            }
            
            if (pos.y > Engine.Height)
            {
                vel.y *= -0.85f;
                pos.y = Engine.Height;
                if (Quick.RandFloat() > 0.5)
                {
                    vel.y -= (Quick.RandFloat() * 6);
                }
            }
            else if (pos.y < 0)
            {
                vel.y = 0;
                pos.y = 0;
            }
        });
    }
}
public abstract class RenderSystem : DSystem, IUpdateSystem
{
    public void Update()
    {
        Render();
    }

    protected abstract void Render();
}
public class SpriteRenderSystem : RenderSystem
{
    QueryDescription query = new QueryDescription().WithAll<Position,SpriteRenderer>();      // Should have all specified components
    protected override void Render()
    {
        Engine.World.Query(in query, (in Entity e, ref SpriteRenderer r, ref Position p) =>
        {
            if (!r.ImageResource.loaded)
            {
                r.ImageResource.Load();
            }
            Engine.DrawTexturedRect(p.x, p.y,r.ImageResource);
        });
    }
}

public class InputSystem : DSystem, IUpdateSystem
{
    public static class Events
    {
        public static class Key
        {
            public static Action<sapp_keycode> Pressed;
            public static Action<sapp_keycode> Down;
            public static Action<sapp_keycode> Up;
        }
    }
    public HashSet<sapp_event> FrameEvents = new HashSet<sapp_event>();
    public void Update()
    {
        // Dinghy.Internal.Sokol.App.ke
        foreach (var e in FrameEvents)
        {
            switch (e.type)
            {
                case sapp_event_type.SAPP_EVENTTYPE_INVALID:
                    break;
                case sapp_event_type.SAPP_EVENTTYPE_KEY_DOWN:
                    if (e.key_repeat > 0)
                    {
                        Events.Key.Pressed?.Invoke(e.key_code);
                    }
                    Events.Key.Down?.Invoke(e.key_code);
                    // Console.WriteLine($"{e.key_code} {e.key_repeat}");
                    break;
                case sapp_event_type.SAPP_EVENTTYPE_KEY_UP:
                    Events.Key.Up?.Invoke(e.key_code);
                    break;
                case sapp_event_type.SAPP_EVENTTYPE_CHAR:
                    break;
                case sapp_event_type.SAPP_EVENTTYPE_MOUSE_DOWN:
                    break;
                case sapp_event_type.SAPP_EVENTTYPE_MOUSE_UP:
                    break;
                case sapp_event_type.SAPP_EVENTTYPE_MOUSE_SCROLL:
                    break;
                case sapp_event_type.SAPP_EVENTTYPE_MOUSE_MOVE:
                    break;
                case sapp_event_type.SAPP_EVENTTYPE_MOUSE_ENTER:
                    break;
                case sapp_event_type.SAPP_EVENTTYPE_MOUSE_LEAVE:
                    break;
                case sapp_event_type.SAPP_EVENTTYPE_TOUCHES_BEGAN:
                    break;
                case sapp_event_type.SAPP_EVENTTYPE_TOUCHES_MOVED:
                    break;
                case sapp_event_type.SAPP_EVENTTYPE_TOUCHES_ENDED:
                    break;
                case sapp_event_type.SAPP_EVENTTYPE_TOUCHES_CANCELLED:
                    break;
                case sapp_event_type.SAPP_EVENTTYPE_RESIZED:
                    break;
                case sapp_event_type.SAPP_EVENTTYPE_ICONIFIED:
                    break;
                case sapp_event_type.SAPP_EVENTTYPE_RESTORED:
                    break;
                case sapp_event_type.SAPP_EVENTTYPE_FOCUSED:
                    break;
                case sapp_event_type.SAPP_EVENTTYPE_UNFOCUSED:
                    break;
                case sapp_event_type.SAPP_EVENTTYPE_SUSPENDED:
                    break;
                case sapp_event_type.SAPP_EVENTTYPE_RESUMED:
                    break;
                case sapp_event_type.SAPP_EVENTTYPE_QUIT_REQUESTED:
                    break;
                case sapp_event_type.SAPP_EVENTTYPE_CLIPBOARD_PASTED:
                    break;
                case sapp_event_type.SAPP_EVENTTYPE_FILES_DROPPED:
                    break;
            }
            Console.WriteLine(e.type);
        }
        FrameEvents.Clear();
    }
}

