﻿using Dinghy.Core;
using static Dinghy.Resources;

namespace Dinghy;

public record struct SpriteRenderer : IHasSize
{
    public Resources.Image ImageResource { get;  set; }
    public Rect Rect { get; private set; }
    public Rect SizeRect { get; private set; }
    public float Width => SizeRect.width;
    public float Height => SizeRect.height;
    public SpriteRenderer(string texture, Rect r, bool alphaIsTransparency = true)
    {
        ImageResource = new (texture, alphaIsTransparency);
        Rect = r;
        SizeRect = new Rect(0, 0, Rect.width, Rect.height);
    }

    public void UpdateRect(Rect r)
    {
        Rect = r;
        SizeRect = new Rect(0, 0, Rect.width, Rect.height);
    }
}

public record struct ShapeRenderer(Color Color, float Width, float Height) : IHasSize;
public record struct SpriteAnimator(HashSet<Animation> animations)
{
    public Animation CurrentAnimation { get; private set; } = animations.First();
    public Rect CurrentAnimationFrame => CurrentAnimation.Frames[animationIndex];
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
public record struct Position(float x = 0, float y = 0, float scaleX = 1, float scaleY = 1, float rotation = 0f);
public record struct Velocity (float x, float y);
public record ManagedComponent(Component managedComponent);
public readonly record struct Destroy();
public readonly record struct Active();
public readonly record struct HasManagedOwner(Dinghy.Entity e);
public record ParticleEmitterComponent
{
    public class EmitterConfig
    {
        public int MaxParticles;
        public float EmissionRate;
        public ParticleConfig ParticleConfig;
        public EmitterConfig(int maxParticles, float emissionRate, ParticleConfig particleConfig)
        {
            MaxParticles = maxParticles;
            EmissionRate = emissionRate;
            ParticleConfig = particleConfig;
        }
    }

    public EmitterConfig Config { get; set; }
    public List<Particle> Particles = new List<Particle>();
    public double Accumulator = 0f;
    public ParticleEmitterComponent(EmitterConfig c)
    {
        Config = c;
        Particles = new List<Particle>(c.MaxParticles);
    }

    public class ParticleConfig
    {
        public enum ParticlePrimitiveType
        {
            Rectangle,
            Line,
            LineStrip,
            Triangle,
            // TriangleStrip looks like shit
        }
        public float Lifespan;
        public Point EmissionPoint;
        public ParticlePrimitiveType ParticleType;
        public Transition<float> DX;
        public Transition<float> DY;
        public Transition<float> Width;
        public Transition<float> Height;
        public Transition<float> Rotation;
        public Transition<Color> Color;

        public ParticleConfig(Point emissionPoint, ParticlePrimitiveType type, float lifespan, Transition<float> dx, Transition<float> dy, Transition<float> width,
            Transition<float> height, Transition<Color> color, Transition<float> rotation)
        {
            ParticleType = type;
            EmissionPoint = emissionPoint;
            Lifespan = lifespan;
            DX = dx;
            DY = dy;
            Width = width;
            Height = height;
            Color = color;
            Rotation = rotation;
        }

        public ParticleConfig(ParticleConfig c)
        {
            ParticleType = c.ParticleType;
            EmissionPoint = c.EmissionPoint;
            Lifespan = c.Lifespan;
            DX = c.DX;
            DY = c.DY;
            Width = c.Width;
            Height = c.Height;
            Color = c.Color;
            Rotation = c.Rotation;
        }

        public ParticleConfig()
        {
            EmissionPoint = (0, 0);
            ParticleType = DefaultParticleConfig.ParticleType;
            Lifespan = DefaultParticleConfig.Lifespan;
            DX = DefaultParticleConfig.DX;
            DY = DefaultParticleConfig.DY;
            Width = DefaultParticleConfig.Width;
            Height = DefaultParticleConfig.Height;
            Color = DefaultParticleConfig.Color;
            Rotation = DefaultParticleConfig.Rotation;
        }

        public void Resolve(double time,ref float dx, ref float dy, ref float rotation, ref float width,ref float height,ref Color color)
        {
            var sampleTime = time / Lifespan;
            dx = Quick.MapF((float)DX.Sample(sampleTime), 0f, 1f, DX.StartValue, DX.TargetValue);
            dy = Quick.MapF((float)DY.Sample(sampleTime), 0f, 1f, DY.StartValue, DY.TargetValue);
            width = Quick.MapF((float)Width.Sample(sampleTime), 0f, 1f, Width.StartValue, Width.TargetValue);
            height = Quick.MapF((float)Height.Sample(sampleTime), 0f, 1f, Height.StartValue, Height.TargetValue);
            rotation = Quick.MapF((float)Rotation.Sample(sampleTime), 0f, 1f, Rotation.StartValue,
                Rotation.TargetValue);
            ResolveColorTransition(ref color, sampleTime);
        }
        void ResolveColorTransition(ref Color color,double sampleTime)
        {
            float sample = (float)Color.Sample(sampleTime);
            color.A = Quick.MapF(sample,0f,1f,Color.StartValue.internal_color.a,Color.TargetValue.internal_color.a);
            color.R = Quick.MapF(sample,0f,1f,Color.StartValue.internal_color.r,Color.TargetValue.internal_color.r);
            color.G = Quick.MapF(sample,0f,1f,Color.StartValue.internal_color.g,Color.TargetValue.internal_color.g);
            color.B = Quick.MapF(sample,0f,1f,Color.StartValue.internal_color.b,Color.TargetValue.internal_color.b);
        }
    }

    public static readonly ParticleConfig DefaultParticleConfig = new ParticleConfig((0,0),
        ParticleEmitterComponent.ParticleConfig.ParticlePrimitiveType.Rectangle,
        1.5f,
        new (4,0.1f,Easing.Option.EaseInOutExpo),
        new (4,0.1f,Easing.Option.EaseInOutExpo),
        new (4,200,Easing.Option.EaseInOutExpo),
        new (4,16,Easing.Option.EaseInOutExpo),
        new (new Color(1,1,1,1),new Color(0,1,1,1),Easing.Option.EaseInOutExpo),
        new (0,3 *MathF.PI,Easing.Option.EaseInOutExpo));
    public class Particle
    {
        public bool Active = false;
        public float X = 0;
        public float Y = 0;
        public float DX = 0;
        public float DY = 0;
        public float Width = 8;
        public float Height = 8;
        public float Rotation = 0;
        public double Age = 0;
        public Color Color = Palettes.ENDESGA[19];
        public ParticleConfig Config = DefaultParticleConfig;

        public Particle(){}

        public void Reset()
        {
            Age = 0;
            X = 0;
            Y = 0;
            DX = 0;
            DY = 0;
            Rotation = 0;
        }

        public void Resolve()
        {
            Config.Resolve(Age,ref DX, ref DY, ref Rotation, ref Width,ref Height,ref Color);
        }
    }
}

public record SceneComponent
{
    public Action<double> Update;
    public Scene ManagedScene;
    public SceneComponent(Action<double> update, Scene managedScene)
    {
        Update = update;
        ManagedScene = managedScene;
    }
}

public readonly record struct Collider(Position p, IHasSize sizeProvider);
