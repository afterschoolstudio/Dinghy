using System.Numerics;

namespace Dinghy.Core;

public interface IHasSize
{
    public float Width { get;}
    public float Height { get;}
}

public static partial class Utils
{
    public static Point[] GetEntityBounds<T>(T e) where T : Entity, IHasSize
    {
        var pivot = new Vector2(e.X + e.Width / 2f, e.Y + e.Height / 2f);
        Point[] pts = [
            TransformEntityPoint((e.X, e.Y),e,pivot),
            TransformEntityPoint((e.X + e.Width, e.Y),e,pivot),
            TransformEntityPoint((e.X + e.Width, e.Y + e.Height),e,pivot),
            TransformEntityPoint((e.X, e.Y + e.Height),e,pivot)
        ];
        return pts;

        Point TransformEntityPoint(Point p, Entity e, Vector2 pivot)
        {
            return TransformPoint(new Vector2(p.X,p.Y),e.Rotation, e.ScaleX, e.ScaleY, pivot);
        }

        Vector2 TransformPoint(
            Vector2 point, 
            float rotation, 
            float scaleX, 
            float scaleY, 
            Vector2? pivot = null)
        {
            Vector2 pivotPoint = pivot ?? Vector2.Zero;
            Matrix3x2 transformation =
                Matrix3x2.CreateTranslation(point) *
                Matrix3x2.CreateRotation(rotation, pivotPoint) *
                Matrix3x2.CreateScale(scaleX, scaleY, pivotPoint);

                

            return Vector2.Transform(Vector2.Zero, transformation);
        }
    }
}
