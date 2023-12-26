using System.Numerics;
using static Dinghy.Quick;

namespace Dinghy.Sandbox.Demos;

[DemoScene("11 Entity Emitter")]
public class EntityEmitter : Scene
{
    public override void Create()
    {
        Engine.SetTargetScene(this);
    }

    double timer = 0;
    public override void Update(double dt)
    {
        timer += dt;
        if (timer > 0.00001)
        {
            var startPos = new Vector2(InputSystem.MouseX, InputSystem.MouseY);
            var rand = RandUnitCircle();
            new Shape(new Color(Palettes.ENDESGA[Quick.Random.Next(Palettes.ENDESGA.Count)])) {
                X = (int)startPos.X,
                Y = (int)startPos.Y,
                DX = rand.x * 4,
                DY = rand.y * 4
            };
            timer = 0;
        }
    }
}