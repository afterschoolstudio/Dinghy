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
public readonly record struct Destroy();
public record struct Collider(Frame f);
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
        for (int i = 0; i < c.MaxParticles; i++)
        {
            Particles.Add(new());
        }
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
            ParticleType = DefaultParticleConfig.ParticleType;
            Lifespan = DefaultParticleConfig.Lifespan;
            DX = DefaultParticleConfig.DX;
            DY = DefaultParticleConfig.DY;
            Width = DefaultParticleConfig.Width;
            Height = DefaultParticleConfig.Height;
            Color = DefaultParticleConfig.Color;
            Rotation = DefaultParticleConfig.Rotation;
        }
        
        public class Transition<T>
        {
            public T StartValue;
            public T TargetValue;
            public Easing.Option EasingOption;
            // public delegate double TransitionFunction(double time);

            // public TransitionFunction Sample;
            public Transition(T start, T end, Easing.Option option)
            {
                StartValue = start;
                TargetValue = end;
                EasingOption = option;
            }

            public double Sample(double time) => EasingOption switch
            {
                Easing.Option.Linear => Easing.Linear(time),
                Easing.Option.EaseInQuad => Easing.EaseInQuad(time),
                Easing.Option.EaseOutQuad => Easing.EaseOutQuad(time),
                Easing.Option.EaseInOutQuad => Easing.EaseInOutQuad(time),
                Easing.Option.EaseInCubic => Easing.EaseInCubic(time),
                Easing.Option.EaseOutCubic => Easing.EaseOutCubic(time),
                Easing.Option.EaseInOutCubic => Easing.EaseInOutCubic(time),
                Easing.Option.EaseInQuart => Easing.EaseInQuart(time),
                Easing.Option.EaseOutQuart => Easing.EaseOutQuart(time),
                Easing.Option.EaseInOutQuart => Easing.EaseInOutQuart(time),
                Easing.Option.EaseInQuint => Easing.EaseInQuint(time),
                Easing.Option.EaseOutQuint => Easing.EaseOutQuint(time),
                Easing.Option.EaseInOutQuint => Easing.EaseInOutQuint(time),
                Easing.Option.EaseInSine => Easing.EaseInSine(time),
                Easing.Option.EaseOutSine => Easing.EaseOutSine(time),
                Easing.Option.EaseInOutSine => Easing.EaseInOutSine(time),
                Easing.Option.EaseInExpo => Easing.EaseInExpo(time),
                Easing.Option.EaseOutExpo => Easing.EaseOutExpo(time),
                Easing.Option.EaseInOutExpo => Easing.EaseInOutExpo(time),
                Easing.Option.EaseInCirc => Easing.EaseInCirc(time),
                Easing.Option.EaseOutCirc => Easing.EaseOutCirc(time),
                Easing.Option.EaseInOutCirc => Easing.EaseInOutCirc(time),
                Easing.Option.EaseInBack => Easing.EaseInBack(time),
                Easing.Option.EaseOutBack => Easing.EaseOutBack(time),
                Easing.Option.EaseInOutBack => Easing.EaseInOutBack(time),
                Easing.Option.EaseInElastic => Easing.EaseInElastic(time),
                Easing.Option.EaseOutElastic => Easing.EaseOutElastic(time),
                Easing.Option.EaseInOutElastic => Easing.EaseInOutElastic(time),
                Easing.Option.EaseInBounce => Easing.EaseInBounce(time),
                Easing.Option.EaseOutBounce => Easing.EaseOutBounce(time),
                Easing.Option.EaseInOutBounce => Easing.EaseInOutBounce(time)
            };
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
