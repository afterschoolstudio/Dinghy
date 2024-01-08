using Dinghy.Core;

namespace Dinghy.Sandbox.Demos;

[DemoScene("13 Grid")]
public class GridDemo : Scene
{
    Color shape1c = Palettes.ENDESGA[9];
    Color shape2c = Palettes.ENDESGA[8];
    List<Shape> shapes1 = new();
    List<Shape> shapes2 = new();
    Grid g = new Grid(new ((Engine.Width / 2f, Engine.Height / 2f), (0.5f, 0.5f), 10, 10, (0.5f, 0.5f), 30, 30));
    public override void Create()
    {
        Engine.SetTargetScene(this);
        foreach (var p in g.Points)
        {
            shapes1.Add(new Shape(shape1c,5,5) { X = (int)p.X, Y = (int)p.Y, ColliderActive = false});
            shapes2.Add(new Shape(shape2c,5,5) { X = (int)p.X, Y = (int)p.Y, ColliderActive = false});
        }
    }

    public override void Update(double dt)
    {
        g.SetAndApplyGridTransforms((float)Engine.Time,1f,1f);
        g.ApplyPositionsToEntites(shapes1);
        g.SetAndApplyGridTransforms(-(float)Engine.Time,MathF.Sin((float)Engine.Time) + 2,MathF.Sin((float)Engine.Time) + 2);
        g.ApplyPositionsToEntites(shapes2);
    }
}