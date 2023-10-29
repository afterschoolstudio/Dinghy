using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Dinghy.Internal.Cute;

public partial struct c2v
{
    public float x;

    public float y;
}

    public partial struct c2r
    {
        public float c;

        public float s;
    }

    public partial struct c2m
    {
        public c2v x;

        public c2v y;
    }

    public partial struct c2x
    {
        public c2v p;

        public c2r r;
    }

    public partial struct c2h
    {
        public c2v n;

        public float d;
    }

    public partial struct c2Circle
    {
        public c2v p;

        public float r;
    }

    public partial struct c2AABB
    {
        public c2v min;

        public c2v max;
    }

    public partial struct c2Capsule
    {
        public c2v a;

        public c2v b;

        public float r;
    }

    public partial struct c2Poly
    {
        public int count;

        [NativeTypeName("c2v[8]")]
        public _verts_e__FixedBuffer verts;

        [NativeTypeName("c2v[8]")]
        public _norms_e__FixedBuffer norms;

        public partial struct _verts_e__FixedBuffer
        {
            public c2v e0;
            public c2v e1;
            public c2v e2;
            public c2v e3;
            public c2v e4;
            public c2v e5;
            public c2v e6;
            public c2v e7;

            [UnscopedRef]
            public ref c2v this[int index]
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get
                {
                    return ref AsSpan()[index];
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [UnscopedRef]
            public Span<c2v> AsSpan() => MemoryMarshal.CreateSpan(ref e0, 8);
        }

        public partial struct _norms_e__FixedBuffer
        {
            public c2v e0;
            public c2v e1;
            public c2v e2;
            public c2v e3;
            public c2v e4;
            public c2v e5;
            public c2v e6;
            public c2v e7;

            [UnscopedRef]
            public ref c2v this[int index]
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get
                {
                    return ref AsSpan()[index];
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [UnscopedRef]
            public Span<c2v> AsSpan() => MemoryMarshal.CreateSpan(ref e0, 8);
        }
    }

    public partial struct c2Ray
    {
        public c2v p;

        public c2v d;

        public float t;
    }

    public partial struct c2Raycast
    {
        public float t;

        public c2v n;
    }

    public unsafe partial struct c2Manifold
    {
        public int count;

        [NativeTypeName("float[2]")]
        public fixed float depths[2];

        [NativeTypeName("c2v[2]")]
        public _contact_points_e__FixedBuffer contact_points;

        public c2v n;

        public partial struct _contact_points_e__FixedBuffer
        {
            public c2v e0;
            public c2v e1;

            [UnscopedRef]
            public ref c2v this[int index]
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get
                {
                    return ref AsSpan()[index];
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [UnscopedRef]
            public Span<c2v> AsSpan() => MemoryMarshal.CreateSpan(ref e0, 2);
        }
    }

    [NativeTypeName("unsigned int")]
    public enum C2_TYPE : uint
    {
        C2_TYPE_CIRCLE,
        C2_TYPE_AABB,
        C2_TYPE_CAPSULE,
        C2_TYPE_POLY,
    }

    public unsafe partial struct c2GJKCache
    {
        public float metric;

        public int count;

        [NativeTypeName("int[3]")]
        public fixed int iA[3];

        [NativeTypeName("int[3]")]
        public fixed int iB[3];

        public float div;
    }

    public partial struct c2TOIResult
    {
        public int hit;

        public float toi;

        public c2v n;

        public c2v p;

        public int iterations;
    }

    public static unsafe partial class C2
    {
        [DllImport("libs/cute", CallingConvention = CallingConvention.Cdecl, EntryPoint = "__Z16c2CircletoCircle8c2CircleS_", ExactSpelling = true)]
        public static extern int c2CircletoCircle(c2Circle A, c2Circle B);

        [DllImport("libs/cute", CallingConvention = CallingConvention.Cdecl, EntryPoint = "__Z14c2CircletoAABB8c2Circle6c2AABB", ExactSpelling = true)]
        public static extern int c2CircletoAABB(c2Circle A, c2AABB B);

        [DllImport("libs/cute", CallingConvention = CallingConvention.Cdecl, EntryPoint = "__Z17c2CircletoCapsule8c2Circle9c2Capsule", ExactSpelling = true)]
        public static extern int c2CircletoCapsule(c2Circle A, c2Capsule B);

        [DllImport("libs/cute", CallingConvention = CallingConvention.Cdecl, EntryPoint = "__Z12c2AABBtoAABB6c2AABBS_", ExactSpelling = true)]
        public static extern int c2AABBtoAABB(c2AABB A, c2AABB B);

        [DllImport("libs/cute", CallingConvention = CallingConvention.Cdecl, EntryPoint = "__Z15c2AABBtoCapsule6c2AABB9c2Capsule", ExactSpelling = true)]
        public static extern int c2AABBtoCapsule(c2AABB A, c2Capsule B);

        [DllImport("libs/cute", CallingConvention = CallingConvention.Cdecl, EntryPoint = "__Z18c2CapsuletoCapsule9c2CapsuleS_", ExactSpelling = true)]
        public static extern int c2CapsuletoCapsule(c2Capsule A, c2Capsule B);

        [DllImport("libs/cute", CallingConvention = CallingConvention.Cdecl, EntryPoint = "__Z14c2CircletoPoly8c2CirclePK6c2PolyPK3c2x", ExactSpelling = true)]
        public static extern int c2CircletoPoly(c2Circle A, [NativeTypeName("const c2Poly *")] c2Poly* B, [NativeTypeName("const c2x *")] c2x* bx);

        [DllImport("libs/cute", CallingConvention = CallingConvention.Cdecl, EntryPoint = "__Z12c2AABBtoPoly6c2AABBPK6c2PolyPK3c2x", ExactSpelling = true)]
        public static extern int c2AABBtoPoly(c2AABB A, [NativeTypeName("const c2Poly *")] c2Poly* B, [NativeTypeName("const c2x *")] c2x* bx);

        [DllImport("libs/cute", CallingConvention = CallingConvention.Cdecl, EntryPoint = "__Z15c2CapsuletoPoly9c2CapsulePK6c2PolyPK3c2x", ExactSpelling = true)]
        public static extern int c2CapsuletoPoly(c2Capsule A, [NativeTypeName("const c2Poly *")] c2Poly* B, [NativeTypeName("const c2x *")] c2x* bx);

        [DllImport("libs/cute", CallingConvention = CallingConvention.Cdecl, EntryPoint = "__Z12c2PolytoPolyPK6c2PolyPK3c2xS1_S4_", ExactSpelling = true)]
        public static extern int c2PolytoPoly([NativeTypeName("const c2Poly *")] c2Poly* A, [NativeTypeName("const c2x *")] c2x* ax, [NativeTypeName("const c2Poly *")] c2Poly* B, [NativeTypeName("const c2x *")] c2x* bx);

        [DllImport("libs/cute", CallingConvention = CallingConvention.Cdecl, EntryPoint = "__Z13c2RaytoCircle5c2Ray8c2CircleP9c2Raycast", ExactSpelling = true)]
        public static extern int c2RaytoCircle(c2Ray A, c2Circle B, c2Raycast* @out);

        [DllImport("libs/cute", CallingConvention = CallingConvention.Cdecl, EntryPoint = "__Z11c2RaytoAABB5c2Ray6c2AABBP9c2Raycast", ExactSpelling = true)]
        public static extern int c2RaytoAABB(c2Ray A, c2AABB B, c2Raycast* @out);

        [DllImport("libs/cute", CallingConvention = CallingConvention.Cdecl, EntryPoint = "__Z14c2RaytoCapsule5c2Ray9c2CapsuleP9c2Raycast", ExactSpelling = true)]
        public static extern int c2RaytoCapsule(c2Ray A, c2Capsule B, c2Raycast* @out);

        [DllImport("libs/cute", CallingConvention = CallingConvention.Cdecl, EntryPoint = "__Z11c2RaytoPoly5c2RayPK6c2PolyPK3c2xP9c2Raycast", ExactSpelling = true)]
        public static extern int c2RaytoPoly(c2Ray A, [NativeTypeName("const c2Poly *")] c2Poly* B, [NativeTypeName("const c2x *")] c2x* bx_ptr, c2Raycast* @out);

        [DllImport("libs/cute", CallingConvention = CallingConvention.Cdecl, EntryPoint = "__Z24c2CircletoCircleManifold8c2CircleS_P10c2Manifold", ExactSpelling = true)]
        public static extern void c2CircletoCircleManifold(c2Circle A, c2Circle B, c2Manifold* m);

        [DllImport("libs/cute", CallingConvention = CallingConvention.Cdecl, EntryPoint = "__Z22c2CircletoAABBManifold8c2Circle6c2AABBP10c2Manifold", ExactSpelling = true)]
        public static extern void c2CircletoAABBManifold(c2Circle A, c2AABB B, c2Manifold* m);

        [DllImport("libs/cute", CallingConvention = CallingConvention.Cdecl, EntryPoint = "__Z25c2CircletoCapsuleManifold8c2Circle9c2CapsuleP10c2Manifold", ExactSpelling = true)]
        public static extern void c2CircletoCapsuleManifold(c2Circle A, c2Capsule B, c2Manifold* m);

        [DllImport("libs/cute", CallingConvention = CallingConvention.Cdecl, EntryPoint = "__Z20c2AABBtoAABBManifold6c2AABBS_P10c2Manifold", ExactSpelling = true)]
        public static extern void c2AABBtoAABBManifold(c2AABB A, c2AABB B, c2Manifold* m);

        [DllImport("libs/cute", CallingConvention = CallingConvention.Cdecl, EntryPoint = "__Z23c2AABBtoCapsuleManifold6c2AABB9c2CapsuleP10c2Manifold", ExactSpelling = true)]
        public static extern void c2AABBtoCapsuleManifold(c2AABB A, c2Capsule B, c2Manifold* m);

        [DllImport("libs/cute", CallingConvention = CallingConvention.Cdecl, EntryPoint = "__Z26c2CapsuletoCapsuleManifold9c2CapsuleS_P10c2Manifold", ExactSpelling = true)]
        public static extern void c2CapsuletoCapsuleManifold(c2Capsule A, c2Capsule B, c2Manifold* m);

        [DllImport("libs/cute", CallingConvention = CallingConvention.Cdecl, EntryPoint = "__Z22c2CircletoPolyManifold8c2CirclePK6c2PolyPK3c2xP10c2Manifold", ExactSpelling = true)]
        public static extern void c2CircletoPolyManifold(c2Circle A, [NativeTypeName("const c2Poly *")] c2Poly* B, [NativeTypeName("const c2x *")] c2x* bx, c2Manifold* m);

        [DllImport("libs/cute", CallingConvention = CallingConvention.Cdecl, EntryPoint = "__Z20c2AABBtoPolyManifold6c2AABBPK6c2PolyPK3c2xP10c2Manifold", ExactSpelling = true)]
        public static extern void c2AABBtoPolyManifold(c2AABB A, [NativeTypeName("const c2Poly *")] c2Poly* B, [NativeTypeName("const c2x *")] c2x* bx, c2Manifold* m);

        [DllImport("libs/cute", CallingConvention = CallingConvention.Cdecl, EntryPoint = "__Z23c2CapsuletoPolyManifold9c2CapsulePK6c2PolyPK3c2xP10c2Manifold", ExactSpelling = true)]
        public static extern void c2CapsuletoPolyManifold(c2Capsule A, [NativeTypeName("const c2Poly *")] c2Poly* B, [NativeTypeName("const c2x *")] c2x* bx, c2Manifold* m);

        [DllImport("libs/cute", CallingConvention = CallingConvention.Cdecl, EntryPoint = "__Z20c2PolytoPolyManifoldPK6c2PolyPK3c2xS1_S4_P10c2Manifold", ExactSpelling = true)]
        public static extern void c2PolytoPolyManifold([NativeTypeName("const c2Poly *")] c2Poly* A, [NativeTypeName("const c2x *")] c2x* ax, [NativeTypeName("const c2Poly *")] c2Poly* B, [NativeTypeName("const c2x *")] c2x* bx, c2Manifold* m);

        [DllImport("libs/cute", CallingConvention = CallingConvention.Cdecl, EntryPoint = "__Z5c2GJKPKv7C2_TYPEPK3c2xS0_S1_S4_P3c2vS6_iPiP10c2GJKCache", ExactSpelling = true)]
        public static extern float c2GJK([NativeTypeName("const void *")] void* A, C2_TYPE typeA, [NativeTypeName("const c2x *")] c2x* ax_ptr, [NativeTypeName("const void *")] void* B, C2_TYPE typeB, [NativeTypeName("const c2x *")] c2x* bx_ptr, c2v* outA, c2v* outB, int use_radius, int* iterations, c2GJKCache* cache);

        [DllImport("libs/cute", CallingConvention = CallingConvention.Cdecl, EntryPoint = "__Z5c2TOIPKv7C2_TYPEPK3c2x3c2vS0_S1_S4_S5_i", ExactSpelling = true)]
        public static extern c2TOIResult c2TOI([NativeTypeName("const void *")] void* A, C2_TYPE typeA, [NativeTypeName("const c2x *")] c2x* ax_ptr, c2v vA, [NativeTypeName("const void *")] void* B, C2_TYPE typeB, [NativeTypeName("const c2x *")] c2x* bx_ptr, c2v vB, int use_radius);

        [DllImport("libs/cute", CallingConvention = CallingConvention.Cdecl, EntryPoint = "__Z9c2InflatePv7C2_TYPEf", ExactSpelling = true)]
        public static extern void c2Inflate(void* shape, C2_TYPE type, float skin_factor);

        [DllImport("libs/cute", CallingConvention = CallingConvention.Cdecl, EntryPoint = "__Z6c2HullP3c2vi", ExactSpelling = true)]
        public static extern int c2Hull(c2v* verts, int count);

        [DllImport("libs/cute", CallingConvention = CallingConvention.Cdecl, EntryPoint = "__Z7c2NormsP3c2vS0_i", ExactSpelling = true)]
        public static extern void c2Norms(c2v* verts, c2v* norms, int count);

        [DllImport("libs/cute", CallingConvention = CallingConvention.Cdecl, EntryPoint = "__Z10c2MakePolyP6c2Poly", ExactSpelling = true)]
        public static extern void c2MakePoly(c2Poly* p);

        [DllImport("libs/cute", CallingConvention = CallingConvention.Cdecl, EntryPoint = "__Z10c2CollidedPKvPK3c2x7C2_TYPES0_S3_S4_", ExactSpelling = true)]
        public static extern int c2Collided([NativeTypeName("const void *")] void* A, [NativeTypeName("const c2x *")] c2x* ax, C2_TYPE typeA, [NativeTypeName("const void *")] void* B, [NativeTypeName("const c2x *")] c2x* bx, C2_TYPE typeB);

        [DllImport("libs/cute", CallingConvention = CallingConvention.Cdecl, EntryPoint = "__Z9c2CollidePKvPK3c2x7C2_TYPES0_S3_S4_P10c2Manifold", ExactSpelling = true)]
        public static extern void c2Collide([NativeTypeName("const void *")] void* A, [NativeTypeName("const c2x *")] c2x* ax, C2_TYPE typeA, [NativeTypeName("const void *")] void* B, [NativeTypeName("const c2x *")] c2x* bx, C2_TYPE typeB, c2Manifold* m);

        [DllImport("libs/cute", CallingConvention = CallingConvention.Cdecl, EntryPoint = "__Z9c2CastRay5c2RayPKvPK3c2x7C2_TYPEP9c2Raycast", ExactSpelling = true)]
        public static extern int c2CastRay(c2Ray A, [NativeTypeName("const void *")] void* B, [NativeTypeName("const c2x *")] c2x* bx, C2_TYPE typeB, c2Raycast* @out);
    }
