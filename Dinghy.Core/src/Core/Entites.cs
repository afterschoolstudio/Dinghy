using System.Numerics;
using Arch.Core;
using Arch.Core.Extensions;
using Dinghy.Collision;
using Dinghy.Core;
using Dinghy.Internal.Cute;
using Dinghy.Internal.Sokol;
using Dinghy.Internal.STB;
using Volatile;

namespace Dinghy;

public class Scene
{
    public List<Dinghy.Entity> Entities = new List<Dinghy.Entity>();
}


public class Entity
{
    public string Name { get; set; } = "entity";
    private bool enabled = true;
    public bool Enabled
    {
        get => enabled;
        set
        {
            if (value == enabled)
            {
                //do nothing if same
                return;
            }
            if (value)
            {
                ECSEntityReference.Entity.Add<Active>();
            }
            else
            {
                ECSEntityReference.Entity.Remove<Active>();
            }
            enabled = value;
        }
    }
    private int x = 0;
    public int X
    {
        get => x;
        set
        {
            ref var pos = ref ECSEntity.Get<Position>();
            pos.x = value;
            x = value;
        }
    }

    private int y = 0;
    public int Y
    {
        get => y;
        set
        {
            ref var pos = ref ECSEntity.Get<Position>();
            pos.y = value;
            y = value;
        }
    }
    
    private float scaleY = 1;
    public float ScaleY
    {
        get => scaleY;
        set
        {
            ref var pos = ref ECSEntity.Get<Position>();
            pos.scaleY = value;
            scaleY = value;
        }
    }
    
    private float scaleX = 1;
    public float ScaleX
    {
        get => scaleX;
        set
        {
            ref var pos = ref ECSEntity.Get<Position>();
            pos.scaleX = value;
            scaleX = value;
        }
    }
    
    private float rotation = 0;
    public float Rotation
    {
        get => rotation;
        set
        {
            ref var pos = ref ECSEntity.Get<Position>();
            pos.rotation = value;
            rotation = value;
        }
    }


    public void SetPositionRaw(int x, int y, float rotation, float scaleX, float scaleY)
    {
        this.x = x;
        this.y = y;
        this.scaleX = scaleX;
        this.scaleY = scaleY;
        this.rotation = rotation;
    }

    public void SetPosition(int x, int y, float rotation, float scaleX, float scaleY)
    {
        ref var pos = ref ECSEntity.Get<Position>();
        pos.x = x;
        pos.y = y;
        pos.scaleY = scaleY;
        pos.scaleX = scaleX;
        pos.rotation = rotation;
        SetPositionRaw(x,y,rotation,scaleX,scaleY);
    }
    
    private float dx = 0;
    public float DX
    {
        get => dx;
        set
        {
            ref var vel = ref ECSEntity.Get<Velocity>();
            vel.x = value;
            dx = value;
        }
    }

    private float dy = 0;
    public float DY
    {
        get => dy;
        set
        {
            ref var vel = ref ECSEntity.Get<Velocity>();
            vel.y = value;
            dy = value;
        }
    }
    
    public List<Component> Components = new List<Component>();
    public Arch.Core.EntityReference ECSEntityReference;
    public Arch.Core.Entity ECSEntity => ECSEntityReference.Entity;
    public Entity(bool startEnabled, Scene? scene = null)
    {
        Arch.Core.Entity e;
        if (startEnabled)
        {
            e = Engine.World.Create(
                new Active(),
                new HasManagedOwner(this),
                new Position(X,Y), 
                new Velocity(0,0)
            );
        }
        else
        {
            e = Engine.World.Create(
                new HasManagedOwner(this),
                new Position(X,Y), 
                new Velocity(0,0)
            );
        }
        ECSEntityReference = Engine.World.Reference(e);
        Engine.World.Add<Entity>(ECSEntity);
        if (scene == null)
        {
            Engine.GlobalScene.Entities.Add(this);
        }
        else
        {
            scene.Entities.Add(this);
        }
    }

    public void Shift(int x, int y)
    {
        this.x += x;
        this.y += y;
        ref var pos = ref ECSEntity.Get<Position>();
        pos.x = this.x;
        pos.y = this.y;
    }

    public void SetVelocity(float x, float y)
    {
        dx = x;
        dy = y;
        ref var vel = ref ECSEntity.Get<Velocity>();
        vel.x = dx;
        vel.y = dy;
    }

    public void Destroy()
    {
        ECSEntity.Add(new Destroy());
    }

    public void DestroyImmediate()
    {
        Engine.GlobalScene.Entities.Remove(this); //TODO: note this assumes a global scene
        Engine.World.Destroy(ECSEntity);
    }

    public static implicit operator Checks.Transform2D(Entity e) =>
        new Checks.Transform2D(0, 0, 0);
        // new Checks.Transform2D(e.X, e.Y, e.Rotation);
        // new Checks.Transform2D(e.X, e.Y, e.Rotation); //we assume world space
}

public class Component
{
    private Dinghy.Entity parentEntity;
    public Component(Dinghy.Entity parentEntity)
    {
        this.parentEntity = parentEntity;
        parentEntity.ECSEntity.Add(new ManagedComponent(this));
    }
    public virtual void PreUpdate(){}
    public virtual void Update(){}
    public virtual void PostUpdate(){}
}

public class Shape : Entity, IHasSize
{
    private Color c;
    private float height = 0;
    public float Height
    {
        get => height;
        set
        {
            ref var r = ref ECSEntity.Get<ShapeRenderer>();
            r.Height = value;
            height = value;
        }
    }
    private float width = 0;
    public float Width
    {
        get => width;
        set
        {
            ref var r = ref ECSEntity.Get<ShapeRenderer>();
            r.Width = value;
            width = value;
        }
    }
    public Color Color
    {
        get => c;
        set
        {
            ref var sr = ref ECSEntity.Get<ShapeRenderer>();
            sr.Color = value;
            c = value;
        }
    }
    public Shape(Color color, int width = 32, int height = 32, bool startEnabled = true) : base(startEnabled)
    {
        c = color;
        this.width = width;
        this.height = height;
        ECSEntity.Add(new ShapeRenderer(color,width,height));
        ECSEntity.Add(new Collider());
    }
}

public class Sprite : Entity
{
    public SpriteData Data { get; init; }
    public Sprite(SpriteData spriteData, bool startEnabled = true) : base(startEnabled)
    {
        Data = spriteData;
        ECSEntity.Add(new SpriteRenderer(Data.TextureData.texturePath,Data.Frame));
    }
}

public class AnimatedSprite : Entity
{
    public AnimatedSpriteData Data { get; init; }
    public AnimatedSprite(AnimatedSpriteData animatedSpriteData, bool startEnabled = true) : base(startEnabled)
    {
        Data = animatedSpriteData;
        ECSEntity.Add(
            new SpriteRenderer(Data.TextureData.texturePath, Data.Animations.First().Frames[0]),
            new SpriteAnimator(Data.Animations));
    }
}

public class TestBunny : Entity
{
    public SpriteData Data { get; init; }
    public TestBunny(SpriteData spriteData, bool startEnabled = true) : base(startEnabled)
    {
        Data = spriteData;
        ECSEntity.Add(
            new SpriteRenderer(Data.TextureData.texturePath, Data.Frame),
            new BunnyMark());
    }
}
