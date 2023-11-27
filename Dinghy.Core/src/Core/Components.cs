﻿using Dinghy.Core;
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
        public Point EmissionPoint;
        public Transition<float> DX;
        public Transition<float> DY;
        public Transition<float> Width;
        public Transition<float> Height;
        public Transition<Color> Color;

        public ParticleConfig(Point emissionPoint, float lifespan, Transition<float> dx, Transition<float> dy, Transition<float> width,
            Transition<float> height, Transition<Color> color)
        {
            EmissionPoint = emissionPoint;
            Lifespan = lifespan;
            DX = dx;
            DY = dy;
            Width = width;
            Height = height;
            Color = color;
        }

        public ParticleConfig(ParticleConfig c)
        {
            Lifespan = c.Lifespan;
            DX = c.DX;
            DY = c.DY;
            Width = c.Width;
            Height = c.Height;
            Color = c.Color;
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
            public Color Color;
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
                Color = ResolveColorTransition()
            };

            Color ResolveColorTransition()
            {
                var a = Quick.MapF((float)Color.Sample(sampleTime),0f,1f,Color.StartValue.internal_color.a,Color.TargetValue.internal_color.a);
                var r = Quick.MapF((float)Color.Sample(sampleTime),0f,1f,Color.StartValue.internal_color.r,Color.TargetValue.internal_color.r);
                var g = Quick.MapF((float)Color.Sample(sampleTime),0f,1f,Color.StartValue.internal_color.g,Color.TargetValue.internal_color.g);
                var b = Quick.MapF((float)Color.Sample(sampleTime),0f,1f,Color.StartValue.internal_color.b,Color.TargetValue.internal_color.b);
                return new Color(a,r,g,b);
            }
        }
    }

    public class Particle
    {
        public bool Active = false;
        public float X = 0;
        public float Y = 0;
        public float DX = 0;
        public float DY = 0;
        public float Width = 8;
        public float Height = 8;
        public float Age = 0;
        public Color Color = Palettes.ENDESGA[19];
        public ParticleConfig Config;

        public void Reset()
        {
            Age = 0;
            X = 0;
            Y = 0;
            DX = 0;
            DY = 0;
        }

        public void Resolve()
        {
            var tr = Config.Resolve(Age);
            DX = tr.DX;
            DY = tr.DY;
            Width = tr.Width;
            Height = tr.Height;
            Color = tr.Color;
        }
    }
}
