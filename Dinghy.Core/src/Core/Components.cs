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

public record struct ShapeRenderer(Color Color);
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