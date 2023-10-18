using System.Numerics;
using Arch.Core;
using Arch.Core.Extensions;
using Dinghy.Internal.STB;

namespace Dinghy;

public class Scene
{
    public Dictionary<int, Dinghy.Entity> ECSToManagedEntitiesDict = new Dictionary<int, Entity>();
}


public class Entity
{
    public string Name { get; set; } = "entity";
    private int x = 0;
    public int X
    {
        get => x;
        set
        {
            if (AddedToScene)
            {
                ref var pos = ref ECSEntity.Get<Position>();
                pos.x = value;
            }
            x = value;
        }
    }

    private int y = 0;
    public int Y
    {
        get => y;
        set
        {
            if (AddedToScene)
            {
                ref var pos = ref ECSEntity.Get<Position>();
                pos.y = value;
            }
            y = value;
        }
    }

    public void SetPositionRaw(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
    
    private float dx = 0;
    public float DX
    {
        get => dx;
        set
        {
            if (AddedToScene)
            {
                ref var vel = ref ECSEntity.Get<Velocity>();
                vel.x = value;
            }
            dx = value;
        }
    }

    private float dy = 0;
    public float DY
    {
        get => dy;
        set
        {
            if (AddedToScene)
            {
                ref var vel = ref ECSEntity.Get<Velocity>();
                vel.y = value;
            }
            dy = value;
        }
    }
    
    public List<Component> Components;
    protected virtual void AdditionalECSSetup(ref Arch.Core.Entity e){}
    public Arch.Core.Entity ECSEntity;
    public bool AddedToScene { get; private set; } = false;
    public void AddToScene(Scene scene = null)
    {
        if(AddedToScene){return;}
        //all entites this
        ECSEntity = Engine.World.Create(
            new Position(X,Y), 
            new Velocity(0,0)
        );
        AdditionalECSSetup(ref ECSEntity);
        Engine.World.Add<Entity>(ECSEntity);
        if (scene == null)
        {
            Engine.GlobalScene.ECSToManagedEntitiesDict.Add(ECSEntity.Id,this);
        }
        else
        {
            scene.ECSToManagedEntitiesDict.Add(ECSEntity.Id,this);
        }

        AddedToScene = true;
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
        //TODO: do destroy logic
    }
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

public class Sprite : Entity
{
    public SpriteData Data { get; init; }
    public Sprite(SpriteData spriteData)
    {
        Data = spriteData;
    }
    protected override void AdditionalECSSetup(ref Arch.Core.Entity e)
    {
        e.Add(new SpriteRenderer(Data.TextureData.texturePath,Data.Frame));
    }
}

public class AnimatedSprite : Entity
{
    public AnimatedSpriteData Data { get; init; }
    public AnimatedSprite(AnimatedSpriteData animatedSpriteData)
    {
        Data = animatedSpriteData;
    }
    protected override void AdditionalECSSetup(ref Arch.Core.Entity e)
    {
        e.Add(new SpriteRenderer(Data.TextureData.texturePath, Data.Animations.First().Frames[0]));
        e.Add(new SpriteAnimator(Data.Animations));
    }
}

public class TestBunny : Entity
{
    public SpriteData Data { get; init; }
    public TestBunny(SpriteData spriteData)
    {
        Data = spriteData;
    }
    protected override void AdditionalECSSetup(ref Arch.Core.Entity e)
    {
        e.Add(new SpriteRenderer(Data.TextureData.texturePath, Data.Frame));
        e.Add(new BunnyMark());
    }
}
