using System.Text;
using Arch.Core;

namespace Dinghy;

// public record struct World()
// {
//     public HashSet<Entity> Entities = new HashSet<Entity>();
// }

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
        Console.WriteLine("velocity update tick");
            // WithAny<Player,Projectile>().      // Should have any of those
            // WithNone<AI>();
        Engine.World.Query(in query, (in Entity e, ref Position pos, ref Velocity vel) => {
            Console.WriteLine($"updating pos for e {e.Id}");
            pos.x += vel.x;
            pos.y += vel.y;
            Console.WriteLine($"po for e {e.Id}: {pos.x},{pos.y}");
        });
    }
}
public abstract class RenderSystem : DSystem, IUpdateSystem
{
    public void Update()
    {
        Console.WriteLine("base render update tick");
        Render();
    }

    protected abstract void Render();
}
public class SpriteRenderSystem : RenderSystem
{
    QueryDescription query = new QueryDescription().WithAll<Position,SpriteRenderer>();      // Should have all specified components
    protected override void Render()
    {
        Console.WriteLine("render system tick");
        Engine.World.Query(in query, (in Entity e, ref SpriteRenderer r, ref Position p) =>
        {
            Console.WriteLine($"submitting entity {e.Id} for draw");
            //TODO: should submit texture as an image resources
            Engine.AddRect(e, p.x,p.y, 0);
        });
    }
}

public record struct SpriteRenderer(string texture);
public record struct Position(int x, int y);
public record struct Velocity (int x, int y);


public class Quick
{
    // private static Entity Entity = new();
    // public static Position Position = new (0,0);
    // public static SpriteRenderer SpriteRenderer = new ("logo.png");
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
