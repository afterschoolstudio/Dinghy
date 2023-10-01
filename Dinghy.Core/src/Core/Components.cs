using static Dinghy.Resources;

namespace Dinghy;

public record struct SpriteRenderer
{
    public Resources.Image ImageResource { get;  set; }
    private Frame _frame;
    public Frame Frame
    {
        get => _frame;
        private set
        {
            HasAssignedFrame = true;
            _frame = value;
        }
    }
    public bool HasAssignedFrame { get; private set; } = false;
    public SpriteRenderer(string texture, bool alphaIsTransparency = true)
    {
        ImageResource = new (texture, alphaIsTransparency);
    }

    public SpriteRenderer(string texture, Frame r, bool alphaIsTransparency = true)
        : this(texture, alphaIsTransparency)
    {
        Frame = r;
    }

    public void UpdateFrame(Frame r)
    {
        Frame = r;
    }
}

public record struct SpriteAnimator
{
    public Animation CurrentAnimation { get; private set; }
    public Frame AnimationFrame => CurrentAnimation.Frames[animationIndex];
    public HashSet<Animation> animations { get; set; }
    public SpriteAnimator(HashSet<Animation> animations)
    {
        this.animations = animations;
        CurrentAnimation = animations.First();
    }
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

    private int animationIndex;
    public void TickAnimation()
    {
        animationIndex++;
        if (animationIndex >= CurrentAnimation.FrameCount)
        {
            animationIndex = 0;
        }
    }
}
public record struct AnimatedSpriteRenderer
{
    public Resources.Image ImageResource { get;  set; }
    public HashSet<Resources.Animation> Animations { get; }
    public AnimatedSpriteRenderer(string texture, HashSet<Animation> animations, bool alphaIsTransparency = true)
    {
        ImageResource = new (texture, alphaIsTransparency);
        Animations = animations;
    }

}
public record struct Position(int x, int y);
public record struct Velocity (float x, float y);
public record struct BunnyMark();