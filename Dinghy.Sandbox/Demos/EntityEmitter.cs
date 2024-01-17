using System.Numerics;
using Dinghy.Core.ImGUI;
using Dinghy.Internal.Sokol;
using static Dinghy.Quick;

namespace Dinghy.Sandbox.Demos;

[DemoScene("11 Entity Emitter")]
public class EntityEmitter : Scene
{
    double timer = 0;
    private int emissionRate = 1;
    public override void Update(double dt)
    {
        ImGUIHelper.Wrappers.Begin("mods",ImGuiWindowFlags_.ImGuiWindowFlags_None);
        ImGUIHelper.Wrappers.SliderInt("rate", ref emissionRate, 1, 10, "", ImGuiSliderFlags_.ImGuiSliderFlags_Logarithmic);
        ImGUIHelper.Wrappers.End();
        timer += dt;
        if (timer > 0.00001)
        {
            var startPos = new Vector2(InputSystem.MouseX, InputSystem.MouseY);
            var rand = RandUnitCircle();
            for (int i = 0; i < emissionRate; i++)
            {
                new Shape(new Color(Palettes.ENDESGA[Quick.Random.Next(Palettes.ENDESGA.Count)])) {
                    X = startPos.X,
                    Y = startPos.Y,
                    DX = rand.x * 4,
                    DY = rand.y * 4,
                    ColliderActive = false
                };
            }
            timer = 0;
        }
    }
}