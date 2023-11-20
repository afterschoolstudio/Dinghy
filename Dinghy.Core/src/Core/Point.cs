using Dinghy.Internal.Cute;

namespace Dinghy.Core;

public record Point(float X, float Y)
{
    public static implicit operator c2v(Point d) => new c2v(){x = d.X,y = d.Y};
    public static implicit operator Point((float, float) tuple)
    {
        return new Point(tuple.Item1, tuple.Item2);
    }
    public static implicit operator Point((int, int) tuple)
    {
        return new Point(tuple.Item1, tuple.Item2);
    }
}