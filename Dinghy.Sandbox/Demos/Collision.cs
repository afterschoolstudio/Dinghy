using System.Numerics;
using Arch.Core.Extensions;

namespace Dinghy.Sandbox.Demos;

[DemoScene("12 Collision")]
public class Collision : Scene
{
    Color pt = Palettes.ENDESGA[1];
    Color pointer_col = Palettes.ENDESGA[9];
    Color no_collide = Palettes.ENDESGA[7];
    Color collide = Palettes.ENDESGA[3];

    private Shape static_colliderA;
    private Shape static_colliderB;
    private Shape static_colliderC;
    private Shape pointer;
    private Shape ptA;
    private Shape ptB;
    private Shape ptC;
    public override void Create()
    {
        pointer = new Shape(pointer_col,1,1,
            collisionStart: (self,other) =>
            {
                other.Entity.Get<ShapeRenderer>().Color = collide;
            },
            collisionStop: (self,other) => {
                other.Entity.Get<ShapeRenderer>().Color = no_collide;
            },
            collisionContinue: (self,other) => {
                
            })
        {Name = "pointer",ColliderActive = true};
        
        static_colliderA = new Shape(no_collide)
        {
            Name = "static_colliderA",
            X = Engine.Width/2f,
            Y = Engine.Height/2f,
            ColliderActive = true,
            // Enabled = false
        };
        
        static_colliderB = new Shape(no_collide)
        {
            Name = "static_colliderB",
            X = Engine.Width/2f - 200f,
            Y = Engine.Height/2f - 200f,
            ColliderActive = true,
            PivotX = 16,
            PivotY = 16,
        };
        
        static_colliderC = new Shape(no_collide)
        {
            Name = "static_colliderB",
            X = Engine.Width/2f + 200f,
            Y = Engine.Height/2f - 200f,
            ColliderActive = true,
            PivotX = 16,
            PivotY = 16,
            // Enabled = false
        };

        ptA = new Shape(pt, 5, 5){Name ="ptA"};
        ptB = new Shape(pt, 5, 5){Name ="ptB"};;
        ptC = new Shape(pt, 5, 5){Name ="ptC"};;
    }

    public override void Update(double dt)
    {
        static_colliderA.Rotation = (float)Engine.Time;
        static_colliderA.ScaleX = MathF.Sin((float)Engine.Time) + 2;
        static_colliderA.ScaleY = MathF.Sin((float)Engine.Time) + 2;
        static_colliderA.X = Engine.Width/2f + MathF.Cos((float)Engine.Time) * 50;
        // static_colliderB.Rotation = (float)Engine.Time;
        // static_colliderB.ScaleX = MathF.Sin((float)Engine.Time) + 2;
        // static_colliderB.ScaleY = MathF.Sin((float)Engine.Time) + 2;
        static_colliderC.Rotation = (float)Engine.Time;
        static_colliderC.ScaleX = MathF.Sin((float)Engine.Time) + 2;
        static_colliderC.ScaleY = MathF.Sin((float)Engine.Time) + 2;
        
        Quick.MoveToMouse(pointer);
        // raw way to get collision data instead of relying on the system callbacks
        // static_collider.Color = CollisionChecks.CheckCollision(pointer, static_collider)
        //     ? collide
        //     : no_collide;
        var ptsA = Dinghy.Collision.GetClosestPoints(pointer, static_colliderA);
        ptA.X = ptsA.b.Value.X;
        ptA.Y = ptsA.b.Value.Y;
        var ptsB = Dinghy.Collision.GetClosestPoints(pointer, static_colliderB);
        ptB.X = ptsB.b.Value.X;
        ptB.Y = ptsB.b.Value.Y;
        var ptsC = Dinghy.Collision.GetClosestPoints(pointer, static_colliderC);
        ptC.X = ptsC.b.Value.X;
        ptC.Y = ptsC.b.Value.Y;
    }
}