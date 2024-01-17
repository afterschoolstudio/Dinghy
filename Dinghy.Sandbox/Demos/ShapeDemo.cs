using Volatile;

namespace Dinghy.Sandbox.Demos;

[DemoScene("08 Shape")]
public class ShapeDemo : Scene
{
    public override void Create()
    {
        new Shape(new Color(Palettes.ENDESGA[9]))
        {
            X = Engine.Width / 2f,
            Y = Engine.Height / 2f,
            PivotX = 16,
            PivotY = 16
        };
    }
}
