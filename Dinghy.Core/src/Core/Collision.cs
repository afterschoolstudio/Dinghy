using System.Numerics;
using Arch.Core.Extensions;
using Dinghy.Core;
using Dinghy.Internal.Cute;

namespace Dinghy.Collision;

public static class Checks
{
    //TODO:
    //wrap these:
    //C2.c2Collide();
    //C2.c2Collided();
    public static readonly Transform2D Identity = new Transform2D(0, 0, 0);
    
    public class Transform2D(int x, int y, float r)
    {
        public int X { get; } = x;
        public int Y { get; } = y;
        public float R { get; } = r;
        public static implicit operator c2x(Transform2D d) => 
            new c2x()
            {
                p = new (){x = d.X, y = d.Y},
                r = new c2r(){c = MathF.Cos(d.R),s = MathF.Sin(d.R)}
            };
    }

    public static bool CheckCollision(Entity e1, Entity e2)
    {
        if (e1.ECSEntity.Has<Collider>() && e2.ECSEntity.Has<Collider>())
        {
            return CheckCollision(e1.ECSEntity.Get<Collider>(), e1.ECSEntity.Get<Position>(), e2.ECSEntity.Get<Collider>(), e2.ECSEntity.Get<Position>());
        }
        
        Console.WriteLine("entites don't have colliders for collision checking");
        return false;
    }

    public static bool CheckCollision(Collider a, Position app, Collider b, Position bpp)
    {
        var ap = Utils.GetColliderBounds(a,app);
        var bp = Utils.GetColliderBounds(b,bpp);
        var c = 0;
        unsafe
        {
            fixed (c2Poly* a_ptr = &ap.poly, b_ptr = &bp.poly)
            {
                c = C2.c2PolytoPoly(a_ptr, null, b_ptr, null);
            }
        }
        return c > 0;
    }
    
    public static (Point a, Point b) GetClosestPoints(Entity e1, Entity e2)
    {
        if (e1.ECSEntity.Has<Collider>() && e2.ECSEntity.Has<Collider>())
        {
            return GetClosestPoints(e1.ECSEntity.Get<Collider>(), e1.ECSEntity.Get<Position>(), e2.ECSEntity.Get<Collider>(), e2.ECSEntity.Get<Position>());
        }
        
        Console.WriteLine("entites don't have colliders for collision checking");
        return (null,null);
    }
    
    public static (Point a, Point b) GetClosestPoints(Collider a, Position app, Collider b, Position bpp)
    {
        var ap = Utils.GetColliderBounds(a,app);
        var bp = Utils.GetColliderBounds(b,bpp);
        c2v outA = default;
        c2v outB = default;
        unsafe
        {
            fixed (c2Poly* a_ptr = &ap.poly, b_ptr = &bp.poly)
            {
                C2.c2GJK(a_ptr, C2_TYPE.C2_TYPE_POLY, null, b_ptr, C2_TYPE.C2_TYPE_POLY, null, &outA, &outB, 0, null, null);
            }
        }
        return (outA,outB);
    }
    
    public static CollisionInfo GetCollisionInfo(Entity e1, Entity e2)
    {
        if (e1.ECSEntity.Has<Collider>() && e2.ECSEntity.Has<Collider>())
        {
            return GetCollisionInfo(e1.ECSEntity.Get<Collider>(), e1.ECSEntity.Get<Position>(), e2.ECSEntity.Get<Collider>(), e2.ECSEntity.Get<Position>());
        }
        
        Console.WriteLine("entites don't have colliders for collision checking");
        return null;
    }
    public static CollisionInfo GetCollisionInfo(Collider a, Position app, Collider b, Position bpp)
    {
        c2Manifold manifold = default;
        var ap = Utils.GetColliderBounds(a,app);
        var bp = Utils.GetColliderBounds(b,bpp);
        unsafe
        {
            fixed (c2Poly* a_ptr = &ap.poly, b_ptr = &bp.poly)
            {
                C2.c2PolytoPolyManifold(a_ptr, null, b_ptr, null ,&manifold);
            }
        }
        return new CollisionInfo(manifold);
    }

    public record CollisionInfo
    {
        public int Count { get; init; }
        public System.Numerics.Vector2 RayFromAToB { get; init; }
        public Point PointA { get; init; }
        public Point PointB { get; init; }
        public CollisionInfo(c2Manifold m)
        {
            Count = m.count;
            RayFromAToB = new System.Numerics.Vector2(m.n.x,m.n.y);
            PointA = m.contact_points[0];
            PointB = m.contact_points[1];
        }
    }
}

public static class Utils
{
    public static Polygon GetColliderBounds(Collider c, Position entityPosition)
    {
        return new Polygon(4,GetBounds(c,entityPosition));
    }
    
    public static Point[] GetBounds(Collider c, Position entityPosition)
    {
        //TODO: when collision can be offet, need to use entityPosition + c.x/c.y for proper offset calc
        var pivot = new Vector2(c.x + c.width / 2f, c.y + c.height / 2f);
        Point[] pts = [
            TransformEntityPoint((c.x, c.y),entityPosition,pivot),
            TransformEntityPoint((c.x + c.width, c.y),entityPosition,pivot),
            TransformEntityPoint((c.x + c.width, c.y + c.height),entityPosition,pivot),
            TransformEntityPoint((c.x, c.y + c.height),entityPosition,pivot)
        ];
        return pts;

        Point TransformEntityPoint(Point p, Position e, Vector2 pivot)
        {
            return TransformPoint(new Vector2(p.X,p.Y),e.rotation, e.scaleX, e.scaleY, pivot);
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

public class Circle(float x, float y, float radius)
{
    private c2Circle collider = new()
    {
        p = new() { x = x, y = y }, 
        r = radius
    };
}

public class AABB(float minX, float minY, float maxX, float maxY)
{
    private c2AABB collider = new()
    {
        min = new c2v { x = minX, y = minY },
        max = new c2v { x = maxX, y = maxY }
    };
}

//Capsule: This struct represents a capsule shape, defined by two endpoints (a and b) and a radius r.
public class Capsule(float ax, float ay, float bx, float by, float radius)
{
    private c2Capsule collider = new()
    {
        a = new c2v { x = ax, y = ay },
        b = new c2v { x = bx, y = by },
        r = radius
    };
}

/*
 * c2v p;   // position
   c2v d;   // direction (normalized)
   float t; // distance along d from position p to find endpoint of ray
 */
public class Ray(float px, float py, float dx, float dy, float t)
{
    private c2Ray collider = new()
    {
        p = new c2v { x = px, y = py },
        d = new c2v { x = dx, y = dy },
        t = t
    };
}

/*
 * 	float t; // time of impact
   c2v n;   // normal of surface at impact (unit length)
 */
// public class Raycast(float t, float nx, float ny)
// {
//     private c2Raycast result = new()
//     {
//         t = t,
//         n = new c2v { x = nx, y = ny }
//     };
// }

public class Polygon
{
    public c2Poly poly;
    public Polygon(int count, Point[] points)
    {
        poly = default;
        poly.count = count;
        for (int i = 0; i < count; i++)
        {
            poly.verts[i] = points[i];
        }

        unsafe
        {
            fixed(c2Poly* ptr = &poly)
            {
                C2.c2MakePoly(ptr);
            }
        }
    }
}



