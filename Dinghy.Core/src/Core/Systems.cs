using Arch.Core;
using Dinghy.Internal.Sokol;

namespace Dinghy;

public class DSystem {}
public interface IPreUpdateSystem
{
    void PreUpdate(double dt);
}
public interface IUpdateSystem
{
    void Update(double dt);
}
public interface IPostUpdateSystem
{
    void PostUpdate(double dt);
}
public interface ICleanupSystem
{
    void Cleanup(double dt);
}

public class ManagedComponentSystem : DSystem, IPreUpdateSystem, IPostUpdateSystem, IUpdateSystem
{
    QueryDescription query = new QueryDescription().WithAll<ManagedComponent>();      // Should have all specified components
    public void PreUpdate(double dt)
    {
        Engine.World.Query(in query, (in Arch.Core.Entity e, ref ManagedComponent c) => {
            c.managedComponent.PreUpdate();
        });
    }
    public void Update(double dt)
    {
        Engine.World.Query(in query, (in Arch.Core.Entity e, ref ManagedComponent c) => {
            c.managedComponent.Update();
        });
    }
    public void PostUpdate(double dt)
    {
        Engine.World.Query(in query, (in Arch.Core.Entity e, ref ManagedComponent c) => {
            c.managedComponent.PostUpdate();
        });
    }
}
public class VelocitySystem : DSystem, IUpdateSystem
{
    QueryDescription query = new QueryDescription().WithAll<Position, Velocity>();      // Should have all specified components
    QueryDescription bunny = new QueryDescription().WithAll<Position, Velocity,BunnyMark>();      // Should have all specified components
    public void Update(double dt)
    {
        Engine.World.Query(in query, (in Arch.Core.Entity e, ref Position pos, ref Velocity vel) => {
            pos.x += (int)vel.x;
            pos.y += (int)vel.y;
            //could maybe grab stuff like this at the top of the frame so an entity
            //has the most recent pos stuff at the start instead of changing it mid frame?
            Engine.GlobalScene.ECSToManagedEntitiesDict[e.Id].SetPositionRaw(pos.x,pos.y);
        });
        
        Engine.World.Query(in bunny, (in Arch.Core.Entity e, ref Position pos, ref Velocity vel) => {
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
            Engine.GlobalScene.ECSToManagedEntitiesDict[e.Id].SetPositionRaw(pos.x,pos.y);
        });
    }
}
public abstract class RenderSystem : DSystem, IUpdateSystem
{
    public void Update(double dt)
    {
        Render(dt);
    }

    protected abstract void Render(double dt);
}
public class SpriteRenderSystem : RenderSystem
{
    QueryDescription query = new QueryDescription().WithAll<Position,SpriteRenderer>();      // Should have all specified components
    protected override void Render(double dt)
    {
        Engine.World.Query(in query, (in Arch.Core.Entity e, ref SpriteRenderer r, ref Position p) =>
        {
            // // PixelCoordinate objectPosition = new(200, 150);
            // PixelCoordinate pivot = new(0, 0);
            // PixelCoordinate pixelCoord = new(p.x, p.y);
            //
            // // Transformations
            // // PixelCoordinate translated = Translate(pixelCoord, 50, 50);
            // PixelCoordinate rotated = Rotate(pixelCoord, 0, pivot);
            // PixelCoordinate scaled = Scale(rotated, 1, 1, pivot);
            // /* GL required transforming to clip, GP handles it directly as pixel coords
            // ClipSpaceCoordinate clip = ToClipSpace(scaled, pivot);
            // */
            if (!r.ImageResource.loaded)
            {
                r.ImageResource.Load();
            }
            Engine.DrawTexturedRect(p.x, p.y,r.Frame,r.ImageResource);
        });
    }
    
    public record struct PixelCoordinate(int X, int Y);
    public record struct ClipSpaceCoordinate(float X, float Y);
    public PixelCoordinate Translate(PixelCoordinate point, int dx, int dy) 
        => new(point.X + dx, point.Y + dy);
    public PixelCoordinate Rotate(PixelCoordinate point, double angleDegrees, PixelCoordinate pivot)
    {
        double angleRadians = Math.PI * angleDegrees / 180.0;
        int dx = point.X - pivot.X;
        int dy = point.Y - pivot.Y;
    
        int rotatedX = (int)(dx * Math.Cos(angleRadians) - dy * Math.Sin(angleRadians) + pivot.X);
        int rotatedY = (int)(dx * Math.Sin(angleRadians) + dy * Math.Cos(angleRadians) + pivot.Y);
    
        return new(rotatedX, rotatedY);
    }

    public PixelCoordinate Scale(PixelCoordinate point, double scaleX, double scaleY, PixelCoordinate pivot) 
        => new((int)((point.X - pivot.X) * scaleX + pivot.X), (int)((point.Y - pivot.Y) * scaleY + pivot.Y));

    public ClipSpaceCoordinate ToClipSpace(PixelCoordinate pixelCoordinate, PixelCoordinate pivot)
    {
        int translatedX = pixelCoordinate.X - pivot.X;
        int translatedY = pixelCoordinate.Y - pivot.Y;

        float x = (translatedX * 2.0f / Engine.Width) - 1.0f;
        float y = 1.0f - (translatedY * 2.0f / Engine.Height);
        
        return new(x, y);
    }


}

public class InputSystem : DSystem, IUpdateSystem
{
    public static class Events
    {
        public static class Key
        {
            public static Action<Dinghy.Key> Pressed;
            public static Action<Dinghy.Key> Down;
            public static Action<Dinghy.Key> Up;
        }
    }
    public HashSet<sapp_event> FrameEvents = new HashSet<sapp_event>();
    public void Update(double dt)
    {
        foreach (var e in FrameEvents)
        {
            switch (e.type)
            {
                case sapp_event_type.SAPP_EVENTTYPE_INVALID:
                    break;
                case sapp_event_type.SAPP_EVENTTYPE_KEY_DOWN:
                    if (e.key_repeat > 0)
                    {
                        Events.Key.Pressed?.Invoke((Key)e.key_code);
                    }
                    Events.Key.Down?.Invoke((Key)e.key_code);
                    break;
                case sapp_event_type.SAPP_EVENTTYPE_KEY_UP:
                    Events.Key.Up?.Invoke((Key)e.key_code);
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
            // Console.WriteLine(e.type);
        }
        FrameEvents.Clear();
    }
}

public abstract class AnimationSystem : DSystem, IPreUpdateSystem
{
    public void PreUpdate(double dt)
    {
        Animate(dt);
    }

    protected abstract void Animate(double dt);
}

public class FrameAnimationSystem : AnimationSystem
{
    QueryDescription query = new QueryDescription().WithAll<SpriteRenderer,SpriteAnimator>();
    protected override void Animate(double dt)
    {
        Engine.World.Query(in query, (in Arch.Core.Entity e, ref SpriteRenderer r, ref SpriteAnimator a) =>
        {
            if (a.AnimationStarted == false)
            {
                //we do this to pump the first animation frame to the renderer so we dont render the whole texture first
                a.AnimationStarted = true;
                r.UpdateFrame(a.CurrentAnimationFrame);
            }
            else
            {
                a.AnimationTime += dt;
                if (!(a.AnimationTime > a.CurrentAnimation.FrameTime)) return;
                a.TickAnimation();
                    
                //note that there is currently no binding glue to imply that SpriteAnimator will work directly on an attached SpriteRenderer
                r.UpdateFrame(a.CurrentAnimationFrame);
                a.AnimationTime = 0;
            }
        });
    }
}

public class DestructionSystem : DSystem, ICleanupSystem
{
    QueryDescription query = new QueryDescription().WithAll<Destroy>();
    public void Cleanup(double dt)
    {
        Engine.World.Query(in query, (in Arch.Core.Entity e) =>
        {
            Engine.GlobalScene.ECSToManagedEntitiesDict.Remove(e.Id);
        });
        Engine.World.Destroy(in query);
    }
}

public class BasicCollisionSystem : DSystem, IUpdateSystem
{
    QueryDescription query = new QueryDescription().WithAll<Collider,Position>();
    public void Update(double dt)
    {
        Engine.World.Query(in query, (in Arch.Core.Entity e, ref Collider c, ref Position a) =>
        {
            //get collider position
            c.f.
        });
    }

}

