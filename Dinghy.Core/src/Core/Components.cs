namespace Dinghy;

public record struct SpriteRenderer
{
    public Resources.Image ImageResource { get;  set; }
    public SpriteRenderer(string texture, bool alphaIsTransparency = true)
    {
        ImageResource = new (texture, alphaIsTransparency);
    }

}
public record struct Position(int x, int y);
public record struct Velocity (float x, float y);
public record struct BunnyMark();