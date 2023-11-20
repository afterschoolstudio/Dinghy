using Dinghy.Core;
using Dinghy.Internal.Cute;
using Volatile;

namespace Dinghy.Collision;

public static class Checks
{
    //TODO:
    //wrap these:
    //C2.c2Collide();
    //C2.c2Collided();
    
    public class Transform2D(int x, int y, float r)
    {
        public int X { get; } = x;
        public int Y { get; } = y;
        public float R { get; } = r;
        public static implicit operator c2x(Transform2D d) => 
            new c2x()
            {
                p = new (){x = d.X, y = d.Y},
                r = new c2r(){c = Mathf.Cos(d.R),s = Mathf.Sin(d.R)}
            };
    }
    
    public static bool CheckCollision(Polygon a, Transform2D at, Polygon b, Transform2D bt)
    {
        int c = 0;
        unsafe
        {
            
            c2x ac2x = at;
            c2x bc2x = bt;
            fixed (c2Poly* a_ptr = &a.poly, b_ptr = &b.poly)
            {
                // c = C2.c2PolytoPoly(a_ptr, &ac2x, b_ptr, &bc2x);
                c = C2.c2PolytoPoly(a_ptr, null, b_ptr, null);
            }
        }
        return c > 0;
    }

    public static c2Manifold GetManifold(Polygon a, Transform2D at, Polygon b, Transform2D bt)
    {
        c2Manifold manifold = default;
        unsafe
        {
            
            c2x ac2x = at;
            c2x bc2x = bt;
            fixed (c2Poly* a_ptr = &a.poly, b_ptr = &b.poly)
            {
                // C2.c2PolytoPolyManifold(a_ptr, &ac2x, b_ptr, &bc2x,&manifold);
                C2.c2PolytoPolyManifold(a_ptr, null, b_ptr, null,&manifold);
            }
        }
        return manifold;
    }
}

public static class Utils
{
    public static Polygon GetEntityPolygon<T>(T e) where T : Entity, IHasSize
    {
        return new Polygon(4,Core.Utils.GetEntityBounds(e));
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



