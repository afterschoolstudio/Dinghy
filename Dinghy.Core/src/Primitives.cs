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
    public HashSet<DComponent> Components = Util.EmptyComponentList;
    public Entity(params DComponent[] components)
    {
        Components = new HashSet<DComponent>(components);
    }

    private bool PrintMembers(StringBuilder builder)
    {
        builder.Append($"ID = {ID}, ");
        builder.Append(String.Join(", ",Components));
        return true;
    }

    //better cachce this list
    public List<T> GetComponents<T>() where T : DComponent
    {
        var t = new List<T>();
        foreach (var c in Components)
        {
            if (c is T casted)
            {
                t.Add(casted);
            }
        }
        return t; 
    }
    
    public bool GetComponent<T>(out T component) where T : DComponent
    {
        foreach (var c in Components)
        {
            if (c is T casted)
            {
                component = casted;
                return true;
            }
        }
        component = default;
        return false; 
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
            if (e.GetComponent(out Position pc))
            {
                e.GetComponents<Velocity>().ForEach(c =>
                {
                    pc.X += c.X;
                    pc.Y += c.Y;
                });
            }
        }
    }
}
public abstract class RenderSystem : DSystem, IUpdateSystem
{
    private void Update(World w)
    {
        Render(w);
    }

    public abstract void Render(World w);
}
public class SpriteRenderSystem : RenderSystem
{
    public override void Render(World w)
    {
        foreach (var e in w.Entities)
        {
            foreach (SpriteRenderer r in e.GetComponents<SpriteRenderer>())
            {
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
    public string Texture;
    public uint ID { get;set;} 
}

public struct Position : DComponent
{
    public uint ID { get;set;}
    public int X, Y;
}

public struct Velocity : DComponent
{
    public uint ID { get;set;}
    public int X, Y;
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
            e = Entity with
            {
                ID = NextID(),
                Components = new()
                {
                    Position with {ID = NextID()},
                    SpriteRenderer with { ID = NextID(), Texture = texture }
                }
        
                /*
                 dotnet 8
                 Components = [
                    SpriteRenderer with { texture = "logo.png" }
                 ]
                 */
            };
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
