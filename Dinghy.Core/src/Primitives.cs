namespace Dinghy;

// public record obj (List<component> components);
// public record obj2d(List<component> components) : obj(components);
// public record sprite : obj2d();
//
// public record component {}
// public 
// public static obj2D Sprite = new obj2D() 


public record struct obj2D(int x, int y, string tex)
{
    public uint id { get; }
    public obj2D() :this(0,0,"null")
    {
        Engine.idCounter++;
        id = Engine.idCounter;
    }
    public obj2D(obj2D original) : this(){}

    public void draw() //hacky as shit move to ECS asap
    {
        Engine.addRect(id,x,y,0);
    }
}

public record component();

public record ISystem;
public record IUpdateSystem : ISystem;
public record IRenderSystem : IUpdateSystem;
public record SpriteRenderSystem : IRenderSystem;

public record system();
public record renderer : system

public class Quick
{
    public static obj2D Sprite = new obj2D(0, 0, "");

    public static void Repeat(int amount, Action a)
    {
        for (int i = 0; i < amount; i++)
        {
            a();
        }
    }
}
