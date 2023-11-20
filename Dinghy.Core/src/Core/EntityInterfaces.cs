namespace Dinghy.Core;

public interface IHasSize
{
    public float Width { get; set; }
    public float Height { get; set; }
}

public static partial class Utils
{
    public static Point[] GetEntityBounds<T>(T e) where T : Entity, IHasSize =>
    [
        (e.X, e.Y),
        (e.X + e.Width, e.Y),
        (e.X + e.Width, e.Y + e.Height),
        (e.X, e.Y + e.Height)
    ];
}
