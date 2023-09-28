using Arch.Core;
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
    public void Update()
    {
        
    }
}

