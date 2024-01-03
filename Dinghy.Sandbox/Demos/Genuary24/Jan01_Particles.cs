using Dinghy.Core;

namespace Dinghy.Sandbox.Demos.Genuary24;
using static Dinghy.Quick;

[DemoScene("01 Particles")]
public class Jan01_Particles : Scene
{
    Color startColor = Palettes.ENDESGA[4];
    Color endColor = Palettes.ENDESGA[16];
    private List<ParticleEmitter> emitters = new List<ParticleEmitter>();
    Grid g = new Grid((Engine.Width/2f,Engine.Height/2f), (0.5f, 0.5f), 30, 30, (0.5f,0.5f), 5, 5);
    private ParticleEmitterComponent.EmitterConfig ec =
        new ParticleEmitterComponent.EmitterConfig(100000, 100, new ParticleEmitterComponent.ParticleConfig());
    public override void Create()
    {
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
        g.Rotation = (float)Engine.Time;
        g.ApplyPositionsToEntites(emitters);
        // var rand = RandUnitCircle();
        // emitter.Config.particleConfig.DX.StartValue = rand.x * 4;
        // emitter.Config.particleConfig.DY.StartValue = rand.y * 4;
    }
}