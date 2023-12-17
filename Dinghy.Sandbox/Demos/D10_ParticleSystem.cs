using Dinghy.Core;
using static Dinghy.Quick;

namespace Dinghy.Sandbox.Demos;

public class D10_ParticleSystem : Scene
{
    Color startColor = Palettes.ENDESGA[4];
    Color endColor = Palettes.ENDESGA[16];
    ParticleEmitter emitter;
    public override void Create()
    {
        emitter = new ParticleEmitter(
            new(100000, 100, new ParticleEmitterComponent.ParticleConfig()),this)
        {
            X = 200,
            Y = 200
        };
    }

    public override void Update(double time)
    {
        MoveToMouse(emitter);
        DrawEditGUIForObject("emitter",ref emitter);
        // var rand = RandUnitCircle();
        // emitter.Config.particleConfig.DX.StartValue = rand.x * 4;
        // emitter.Config.particleConfig.DY.StartValue = rand.y * 4;
    }
}