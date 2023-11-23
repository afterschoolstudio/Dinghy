using System.Numerics;
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
    public static implicit operator Point(c2v c)
    {
        return new Point(c.x, c.y);
    }
    public static implicit operator Point(Vector2 c)
    {
        return new Point(c.X, c.Y);
    }
    
    public static implicit operator Vector2(Point p)
    {
        return new Vector2(p.X, p.Y);
    }
    
    public static Point operator +(Point a, Point b)
    {
        return new Point(a.X + b.X, a.Y + b.Y);
    }

    public static Point operator -(Point a, Point b)
    {
        return new Point(a.X - b.X, a.Y - b.Y);
    }
    
    public Point Transform(
        float rotation, 
        float scaleX, 
        float scaleY, 
        Vector2? pivot = null)
    {
        Vector2 pivotPoint = pivot ?? Vector2.Zero;
        Matrix3x2 transformation =
            Matrix3x2.CreateTranslation(new Vector2(this.X,this.Y)) *
            Matrix3x2.CreateRotation(rotation, pivotPoint) *
            Matrix3x2.CreateScale(scaleX, scaleY, pivotPoint);
        return Vector2.Transform(Vector2.Zero, transformation);
    }
}