using Dinghy.Core;
using Dinghy.Core.ImGUI;
using Dinghy.Internal.Sokol;

namespace Dinghy.Sandbox.Demos.Genuary24;
using static Dinghy.Quick;

[DemoScene("02 No Palette")]
public class Jan02_NoPalette : Scene
{
    Color startColor = Palettes.ONE_BIT_MONITOR_GLOW[1];
    private Grid.GridCreationParams gp;
    Grid g;
    private List<Shape> shapes = new List<Shape>();
    public override void Create()
    {
        gp = new Grid.GridCreationParams((Engine.Width / 2f, Engine.Height / 2f),
            (0.5f, 0.5f), 30, 30, (0.5f, 0.5f), 50, 50);
        g = new Grid(gp);
        foreach (var p in g.Points)
        {
            shapes.Add(new Shape(startColor)
            {
                X = (int)p.X,
                Y = (int)p.Y
            });
        }
    }

    private float rotMod = 1f;
    private float gridRot = 1f;
    private float scaleMod = 1f;
    public override void Update(double dt)
    {
        DrawEditGUIForObject("grid",ref gp);
        ImGUIHelper.Wrappers.Begin("mods",ImGuiWindowFlags_.ImGuiWindowFlags_None);
        ImGUIHelper.Wrappers.SliderFloat("gridrot", ref gridRot, -5f, 5f, "", ImGuiSliderFlags_.ImGuiSliderFlags_Logarithmic);
        ImGUIHelper.Wrappers.SliderFloat("rot", ref rotMod, -5f, 5f, "", ImGuiSliderFlags_.ImGuiSliderFlags_Logarithmic);
        ImGUIHelper.Wrappers.SliderFloat("scale", ref scaleMod, -5f, 5f, "", ImGuiSliderFlags_.ImGuiSliderFlags_Logarithmic);
        ImGUIHelper.Wrappers.End();
        g = new Grid(gp);
        g.Rotation = (float)Engine.Time/gridRot;
        g.ApplyPositionsToEntites(shapes);
        foreach (var s in shapes)
        {
            s.Rotation = (float)Engine.Time/rotMod;
            s.ScaleX = (float)(Math.Cos(Engine.Time/scaleMod)) + 2;
            s.ScaleY = (float)(Math.Cos(Engine.Time/scaleMod)) + 2;
        }
        // var rand = RandUnitCircle();
        // ec.ParticleConfig.DX.StartValue = rand.x * 4;
        // ec.ParticleConfig.DY.StartValue = rand.y * 4;
    }
}