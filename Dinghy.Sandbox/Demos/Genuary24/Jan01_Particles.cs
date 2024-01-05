using Dinghy.Core;

namespace Dinghy.Sandbox.Demos.Genuary24;
using static Dinghy.Quick;

[DemoScene("01 Particles")]
public class Jan01_Particles : Scene
{
    Color startColor = Palettes.ENDESGA[4];
    Color endColor = Palettes.ENDESGA[16];
    private List<ParticleEmitter> emitters = new List<ParticleEmitter>();

    private Grid.GridCreationParams gp;
    Grid g;
    private ParticleEmitterComponent.EmitterConfig ec =
        new ParticleEmitterComponent.EmitterConfig(10000, 100, new ParticleEmitterComponent.ParticleConfig());
    public override void Create()
    {
        gp = new Grid.GridCreationParams((Engine.Width / 2f, Engine.Height / 2f),
            (0.5f, 0.5f), 30, 30, (0.5f, 0.5f), 10, 10);
        g = new Grid(gp);
        Engine.SetTargetScene(this);
        foreach (var p in g.Points)
        {
            emitters.Add(new ParticleEmitter(ec)
            {
                X = (int)p.X,
                Y = (int)p.Y
            });
        }
    }
    public override void Update(double dt)
    {
        DrawEditGUIForObject("emitter",ref ec);
        DrawEditGUIForObject("grid",ref gp);
        g = new Grid(gp);
        // g.Rotation = (float)Engine.Time;
        g.ApplyPositionsToEntites(emitters);
        // var rand = RandUnitCircle();
        // ec.ParticleConfig.DX.StartValue = rand.x * 4;
        // ec.ParticleConfig.DY.StartValue = rand.y * 4;
    }
}