using System.Text;

namespace Dinghy;

public record struct World()
{
    public HashSet<Entity> Entities = new HashSet<Entity>();
}

public abstract record EntityData
{
    public abstract void GetEntity(out Entity e);
}

//record structs dont allow custom copy semantics so its a bit hard to get a nice with api
public record struct Entity
{
    public uint ID { get; init; } = Engine.idCounter++;
    public Dictionary<Type, DComponent> Components;
    // public HashSet<DComponent> Components = Util.EmptyComponentList;
    public Entity(params DComponent[] components)
    {
        Components = new Dictionary<Type, DComponent>();
        foreach (var c in components)
        {
            if (Components.TryGetValue(c.GetType(), out var entry))
            {
                Console.WriteLine("adding another component of already added type");
            }
            else
            {
                Components.Add(c.GetType(),c);
            }
        }
    }

    private bool PrintMembers(StringBuilder builder)
    {
        builder.Append($"ID = {ID}, ");
        builder.Append(String.Join(", ",Components));
        return true;
    }

    public bool GetComponent<T>(out T component) where T : DComponent
    {
        component = default;
        if (Components.TryGetValue(typeof(T), out var c))
        {
            component = (T)c;
            return true;
        }
        return false;
    }

    public bool AddComponent(DComponent c)
    {
        if (Components.TryGetValue(c.GetType(), out var entry))
        {
            Console.WriteLine("skpping adding another component of already added type");
            return false;
        }
        else
        {
            Components.Add(c.GetType(),c);
            return true;
        }
    }
}

public static class Util
{
    public static HashSet<DComponent> EmptyComponentList = new HashSet<DComponent>();
}


public class DSystem {}

public interface IUpdateSystem
{
    public void Update(World w){}
}
public class VelocitySystem : DSystem, IUpdateSystem
{
    public void Update(World w)
    {
        foreach (var e in w.Entities)
        {
            if (e.GetComponent(out Position pc) && e.GetComponent(out Velocity v))
            {
                Console.WriteLine($"update vel str {v.X}{v.Y}");
                Console.WriteLine($"pc.X {pc.X}");
                Console.WriteLine($"adding {v.X}");
                pc.X += v.X;
                Console.WriteLine($"new pc.x {pc.X}");
                pc.Y += v.Y;
                Console.WriteLine("update vel" + pc.X);
            }
        }
    }
}
public abstract class RenderSystem : DSystem, IUpdateSystem
{
    public void Update(World w)
    {
        Render(w);
    }

    protected abstract void Render(World w);
}
public class SpriteRenderSystem : RenderSystem
{
    protected override void Render(World w)
    {
        foreach (var e in w.Entities)
        {
            if (e.GetComponent(out SpriteRenderer r))
            {
                Console.WriteLine("submitting for render");
                //TODO: should submit texture as an image resources
                // Engine.addRect(e.ID,r.Texture);
                Engine.addRect(e,0);
                //maybe add the SpriteRenderer directly? save the lookup on engine side
            }
        }
    }
}

//can clean this up in dotnet 8 i think
//using primary ctors for the components
public interface DComponent
{
    public uint ID { get; set; }
}

public struct SpriteRenderer : DComponent
{
    public uint ID { get;set;} 
    public required string Texture;
}

public struct Position : DComponent
{
    public uint ID { get;set;}
    public required int X, Y;
}

public struct Velocity : DComponent
{
    public uint ID { get;set;}
    public required int X, Y;
}


public class Quick
{
    private static Entity Entity = new();
    public static uint NextID()
    {
        Engine.idCounter++;
        return Engine.idCounter;
    }

    public static Position Position = new (){X = 0, Y = 0};
    public static SpriteRenderer SpriteRenderer = new (){Texture = "logo.png"};



    

    public record SpriteData(string texture) : EntityData
    {
        public override void GetEntity(out Entity e)
        {
            e = new Entity(
                new Position() { ID = NextID(), X = 0, Y = 0 }, 
                new SpriteRenderer(){ID = NextID(), Texture = texture});
            // e = Entity with
            // {
            //     ID = NextID(),
            //     Components = new()
            //     {
            //         Position with {ID = NextID()},
            //         SpriteRenderer with { ID = NextID(), Texture = texture }
            //     }
            //
            //     /*
            //      dotnet 8
            //      Components = [
            //         SpriteRenderer with { texture = "logo.png" }
            //      ]
            //      */
            // };
        }
    }

    public static Entity Add(EntityData d)
    {
        d.GetEntity(out var e);
        Engine.World.Entities.Add(e);
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
