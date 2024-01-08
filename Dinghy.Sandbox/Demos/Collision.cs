namespace Dinghy.Sandbox.Demos;

[DemoScene("12 Collision")]
public class Collision : Scene
{
    Color pt = Palettes.ENDESGA[1];
    Color pointer_col = Palettes.ENDESGA[9];
    Color no_collide = Palettes.ENDESGA[7];
    Color collide = Palettes.ENDESGA[3];

    private Shape static_collider;
    private Shape pointer;
    private Shape ptB;
    public override void Create()
    {
        Engine.SetTargetScene(this);
        
        pointer = new Shape(pointer_col,1,1){Name = "pointer"};
        pointer.OnCollision += CollisionCallbackTest;
        static_collider = new Shape(no_collide)
        {
            Name = "static_collider",
            X = Engine.Width/2f,
            Y = Engine.Height/2f
        };
    }

    private bool collidedThisFrame = false;
    public void CollisionCallbackTest(Entity e)
    {
        if (e == static_collider)
        {
            collidedThisFrame = true;
        }
        // way to get other collision meta
        // Console.WriteLine(CollisionChecks.GetCollisionInfo(pointer,static_collider));
    }

    public override void Update(double dt)
    {
        if(ptB != null){ptB.DestroyImmediate();}
        static_collider.Rotation = (float)Engine.Time;
        static_collider.ScaleX = MathF.Sin((float)Engine.Time) + 2;
        static_collider.ScaleY = MathF.Sin((float)Engine.Time) + 2;
		
        pointer.SetPosition((int)InputSystem.MouseX,(int)InputSystem.MouseY,0,1,1);
        // raw way to get collision data instead of relying on the system callbacks
        // static_collider.Color = CollisionChecks.CheckCollision(pointer, static_collider)
        //     ? collide
        //     : no_collide;
        static_collider.Color = collidedThisFrame ? collide : no_collide;
        var pts = Dinghy.Collision.GetClosestPoints(pointer, static_collider);
        ptB = new Shape(pt,5,5)
        {
            X = (int)pts.b.X,
            Y = (int)pts.b.Y,
            ColliderActive = false
        };
        collidedThisFrame = false;
    }

    public override void Cleanup()
    {
        pointer.OnCollision -= CollisionCallbackTest;
    }
}