using System.Text;
using Arch.Core;

namespace Dinghy;

public abstract record EntityData
{
    public abstract void GetEntity(out Entity e);
}

public class DSystem {}
public interface IUpdateSystem
{
    void Update();
}
public class VelocitySystem : DSystem, IUpdateSystem
{
    QueryDescription query = new QueryDescription().WithAll<Position, Velocity>();      // Should have all specified components
    public void Update()
    {
        var r = new System.Random();
        Engine.World.Query(in query, (in Entity e, ref Position pos, ref Velocity vel) => {
            pos.x += (int)vel.x;
            pos.y += (int)vel.y;
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
                vel.y *= -1;
                pos.y = Engine.Height;
                if (r.NextDouble() > 0.5)
                {
                    vel.y -= (int)r.NextDouble() * 6;
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
            //TODO: should submit texture as an image resources
            Engine.AddRect(e, p.x,p.y, 0);
        });
    }
}

public record struct SpriteRenderer(string texture);
public record struct Position(int x, int y);
public record struct Velocity (float x, float y);


public class Quick
{
    public record SpriteData(string texture) : EntityData
    {
        public override void GetEntity(out Entity e)
        {
            e = Engine.World.Create(
                new Position(0, 0), 
                new SpriteRenderer(texture));
        }
    }

    public static Entity Add(EntityData d)
    {
        d.GetEntity(out var e);
        Engine.World.Add<Entity>(e);
        return e;
    }

    public static void Repeat(int amount, Action a)
    {
        for (int i = 0; i < amount; i++)
        {
            a();
        }
    }
}
