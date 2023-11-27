using Dinghy.Core;
using static Dinghy.Resources;

namespace Dinghy;

public record struct SpriteRenderer
{
    public Resources.Image ImageResource { get;  set; }
    public Frame Frame { get; private set; }
    public SpriteRenderer(string texture, Frame r, bool alphaIsTransparency = true)
    {
        ImageResource = new (texture, alphaIsTransparency);
        Frame = r;
    }

    public void UpdateFrame(Frame r)
    {
        Frame = r;
    }
}

public record struct ShapeRenderer(Color Color, float Width, float Height);
public record struct SpriteAnimator(HashSet<Animation> animations)
{
    public Animation CurrentAnimation { get; private set; } = animations.First();
    public Frame CurrentAnimationFrame => CurrentAnimation.Frames[animationIndex];
    public double AnimationTime = 0f;
    public bool AnimationStarted = false;

    public void SetAnimation(string name)
    {
        var anim = animations.First(x => x.Name == name);
        if (anim != null)
        {
            CurrentAnimation = anim;
            animationIndex = 0;
        }
        else
        {
            Console.WriteLine($"anim {name} not found");
        }
    }

    private int animationIndex = 0;
    public void TickAnimation()
    {
        animationIndex++;
        if (animationIndex >= CurrentAnimation.FrameCount)
        {
            animationIndex = 0;
        }
    }
}
public record struct Position(int x = 0, int y = 0, float scaleX = 1, float scaleY = 1, float rotation = 0f);
public record struct Velocity (float x, float y);
public record ManagedComponent(Component managedComponent);
public record struct BunnyMark();
public readonly record struct Destroy();
public record struct Collider(Frame f);
public readonly record struct Active();
public readonly record struct HasManagedOwner(Dinghy.Entity e);
public record ParticleEmitterComponent
{
    public readonly record struct EmitterConfig(int maxParticles, float emissionRate, ParticleConfig particleConfig);
    public EmitterConfig Config { get; init; }
    public List<Particle> Particles = new List<Particle>();
    public float Accumulator = 0f;
    public ParticleEmitterComponent(EmitterConfig c)
    {
        Config = c;
        for (int i = 0; i < c.maxParticles; i++)
        {
            Particles.Add(new());
        }
    }

    public class ParticleConfig
    {
        public float Lifespan;
        public Transition<float> DX;
        public Transition<float> DY;
        public Transition<float> Width;
        public Transition<float> Height;

        public ParticleConfig(float lifespan, Transition<float> dx, Transition<float> dy, Transition<float> width,
            Transition<float> height)
        {
            Lifespan = lifespan;
            DX = dx;
            DY = dy;
            Width = width;
            Height = height;
        }

        public ParticleConfig(ParticleConfig c)
        {
            Lifespan = c.Lifespan;
            DX = c.DX;
            DY = c.DY;
            Width = c.Width;
            Height = c.Height;
        }
        
        public struct Transition<T>
        {
            public T StartValue;
            public T TargetValue;
            public delegate double TransitionFunction(double time);

            public TransitionFunction Sample;
            public Transition(T start, T end, TransitionFunction func)
            {
                StartValue = start;
                TargetValue = end;
                Sample = func;
            }
        }

        public struct TransitionResolution
        {
            public float DX;
            public float DY;
            public float Width;
            public float Height;
        }

        public TransitionResolution Resolve(double time)
        {
            var sampleTime = time / Lifespan;
            return new TransitionResolution()
            {
                DX = Quick.MapF((float)DX.Sample(sampleTime),0f,1f,DX.StartValue,DX.TargetValue),
                DY = Quick.MapF((float)DY.Sample(sampleTime),0f,1f,DY.StartValue,DY.TargetValue),
                Width = Quick.MapF((float)Width.Sample(sampleTime),0f,1f,Width.StartValue,Width.TargetValue),
                Height = Quick.MapF((float)Height.Sample(sampleTime),0f,1f,Height.StartValue,Height.TargetValue),
            };
        }
    }

    public class Particle
    {
        public bool Active;
        public float X;
        public float Y;
        public float DX;
        public float DY;
        public float Width;
        public float Height;
        public float Age;
        public ParticleConfig Config;

        public Particle()
        {
            Init();
        }

        public void Init()
        {
            X = 0;
            Y = 0;
            DX = 1; //temp
            DY = 1; //temp
            Width = 8; // temp
            Height = 8; //temp
            Age = 0;
        }

        public void Resolve()
        {
            var tr = Config.Resolve(Age);
            DX = tr.DX;
            DY = tr.DY;
            Width = tr.Width;
            Height = tr.Height;
        }
    }
}
