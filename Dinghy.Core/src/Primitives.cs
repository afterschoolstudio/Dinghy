namespace Dinghy;

public record struct World
{
    public HashSet<Entity> Entities;
}

public record struct Entity
{
    public uint ID { get; }

    public HashSet<DComponent> Components;
    public Entity() :this(null)
    {
        ID = Engine.idCounter++;
    }
    public Entity(Entity original) : this(){}
    public Entity(params DComponent[] components)
    {
        ID = Engine.idCounter++;
        Components = new HashSet<DComponent>(components);
    }
}


public class DSystem {}

public interface IUpdateSystem
{
    private void Update(World w){}
}
public abstract class PositionSystem : DSystem, IUpdateSystem
{
    private void Update(World w)
    {
        foreach (var e in w.Entities)
        {
            foreach (Position p in e.Components.Where(x => x is Position))
            {
                // Engine.move(e.ID,p.X,p.Y);
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
            foreach (SpriteRenderer r in e.Components.Where(x => x is SpriteRenderer))
            {
                // Engine.draw(e.ID,r.Texture);
            }
        }
    }
}


public record DComponent()
{
    private uint id;
    public uint ID
    {
        get => id;
        init => id = Engine.idCounter++;
    }
    // public DComponent(DComponent original)
    // {
    //     ID = Engine.idCounter++;        
    // }
}
public record SpriteRenderer(string Texture) : DComponent {}
public record Position(int X, int Y) : DComponent {}



public class Quick
{
    public static Entity Entity = new();
    public static SpriteRenderer SpriteRenderer= new SpriteRenderer("logo.png");

    public static Entity Sprite = Entity with
    {
        Components = new()
        {
            SpriteRenderer with { Texture = "logo.png" }
        }
        
        /*
         dotnet 8
         Components = [
            SpriteRenderer with { texture = "logo.png" }
         ]
         */
    };

    public static void Repeat(int amount, Action a)
    {
        for (int i = 0; i < amount; i++)
        {
            a();
        }
    }
}
