using Volatile;

namespace Dinghy.Sandbox.Demos;

[DemoScene("08 Shape")]
public class ShapeDemo : Scene
{
    public override void Create()
    {
        Engine.SetTargetScene(this);
        new Shape(new Color(Palettes.ENDESGA[9]))
        {
            X = (int)(Engine.Width / 2f),
            Y = (int)(Engine.Height / 2f),
        };
    }
}
