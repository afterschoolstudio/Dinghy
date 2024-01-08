using System.Numerics;
using Arch.Core;
using Arch.Core.Extensions;
using Dinghy.Core;
using Dinghy.Internal.Cute;
using Dinghy.Internal.Sokol;
using Dinghy.Internal.STB;
using Volatile;

namespace Dinghy;

public class Entity
{
    public string Name { get; set; } = "entity";
    private bool enabled = true;
    // public bool DestoryOnLoad = true;
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
    private float x = 0;
    public float X
    {
        get => x;
        set
        {
            ref var pos = ref ECSEntity.Get<Position>();
            pos.x = value;
            x = value;
        }
    }

    private float y = 0;
    public float Y
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


    public void SetPositionRaw(float x, float y, float rotation, float scaleX, float scaleY)
    {
        this.x = x;
        this.y = y;
        this.scaleX = scaleX;
        this.scaleY = scaleY;
        this.rotation = rotation;
    }

    public void SetPosition(float x, float y, float rotation, float scaleX, float scaleY)
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
    public Scene? Scene;
    public Entity(bool startEnabled, Scene scene, bool addToSceneHeirarchy = true)
    {
        Arch.Core.Entity e;
        if (startEnabled)
        {
            e = Engine.ECSWorld.Create(
                new Active(),
                new HasManagedOwner(this),
                new Position(X,Y), 
                new Velocity(0,0)
            );
        }
        else
        {
            e = Engine.ECSWorld.Create(
                new HasManagedOwner(this),
                new Position(X,Y), 
                new Velocity(0,0)
            );
        }
        ECSEntityReference = Engine.ECSWorld.Reference(e);
        Engine.ECSWorld.Add<Entity>(ECSEntity);
        Scene = scene != null ? scene : Engine.TargetScene;
        if (addToSceneHeirarchy)
        {
            Engine.SceneEntityMap[Scene].Add(this);
        }
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
        Engine.SceneEntityMap[Scene].Remove(this);
        Engine.ECSWorld.Destroy(ECSEntity);
    }

    // public static implicit operator Checks.Transform2D(Entity e) =>
    //     new Checks.Transform2D(0, 0, 0);
    //     // new Checks.Transform2D(e.X, e.Y, e.Rotation);
    //     // new Checks.Transform2D(e.X, e.Y, e.Rotation); //we assume world space
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

public class Scene : Entity
{
    public enum SceneLoadStatus
    {
        Unloaded,
        Loading,
        Loaded
    }

    public enum SceneMountStatus
    {
        Unmounted,
        Mounted
    }
    public enum SceneStatus
    {
        Inactive,
        Creating,
        Running
    }

    public SceneStatus Status = SceneStatus.Inactive; 
    public SceneMountStatus MountStatus = SceneMountStatus.Unmounted; 
    public SceneLoadStatus LoadStatus = SceneLoadStatus.Unloaded; 
    public Scene(bool startEnabled = true) : base(startEnabled,null,false)
    {
        ECSEntity.Add(new SceneComponent(Update,this));
    }

    public virtual void Update(double dt){}
/*
 * mount -> load -> start -> unmount
 */
    public void Mount(int depth)
    {
        Engine.MountedScenes.Add(depth,this);
        Engine.SceneEntityMap.Add(this,new List<Entity>());
        MountStatus = SceneMountStatus.Mounted;
    }

    public void Unmount(Action callback = null)
    {
        if (MountStatus == SceneMountStatus.Mounted)
        {
            Cleanup();
            var rmentites = new List<Entity>(Engine.SceneEntityMap[this]);
            foreach (var e in rmentites)
            {
                e.Destroy();
            }
            Events.SceneUnmounted?.Invoke(this,callback);
        }
    }
    public void Load(Action loadedCallback)
    {
        if (LoadStatus != SceneLoadStatus.Loaded)
        {
            LoadStatus = SceneLoadStatus.Loading;
            Preload();
            LoadStatus = SceneLoadStatus.Loaded;
        }
        loadedCallback?.Invoke();
    }
    
    public virtual void Preload(){}
    public void Start()
    {
        if (MountStatus != SceneMountStatus.Mounted)
        {
            Console.WriteLine("mount and load scene before starting it");
            return;
        }
        if (LoadStatus != SceneLoadStatus.Loaded)
        {
            if (LoadStatus == SceneLoadStatus.Loading)
            {
                Console.WriteLine("scene still loading");
            }
            else
            {
                Console.WriteLine("load scene before starting it");
            }
            return;
        }
        Status = SceneStatus.Creating;
        Create();
        Status = SceneStatus.Running;
    }
    public virtual void Create(){}
    public virtual void Cleanup(){}
}

public class Shape : Entity, ICollideable
{
    private Color c;
    private float height = 0;
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
    public Shape(Color color, int width = 32, int height = 32, Scene? scene = null, bool startEnabled = true) : base(startEnabled,scene)
    {
        c = color;
        var rend = new ShapeRenderer(color, width, height);
        ECSEntity.Add(
            rend,
            new Collider(0,0,width,height));
    }


    private bool colliderActive;
    public bool ColliderActive
    {
        get => colliderActive;
        set
        {
            ref var c = ref ECSEntity.Get<Collider>();
            c.active = value;
            colliderActive = value;
        }
    }

    public Action<Entity> OnCollision { get; set; }

    // [BindECSComponentValue<Collider>("active")]
    // private bool colliderActives;
}

public class Sprite : Entity, ICollideable
{
    public SpriteData Data { get; init; }
    public Sprite(SpriteData spriteData, Scene? scene = null, bool startEnabled = true) : base(startEnabled,scene)
    {
        Data = spriteData;
        var rend = new SpriteRenderer(Data.TextureData.texturePath, Data.Rect);
        ECSEntity.Add(
            rend,
            new Collider(0,0,Data.Rect.width,Data.Rect.height));
    }
    
    private bool colliderActive;
    public bool ColliderActive
    {
        get => colliderActive;
        set
        {
            ref var c = ref ECSEntity.Get<Collider>();
            c.active = value;
            colliderActive = value;
        }
    }
    
    public Action<Entity> OnCollision { get; set; }
}

public class AnimatedSprite : Entity, ICollideable
{
    public AnimatedSpriteData Data { get; init; }
    public AnimatedSprite(AnimatedSpriteData animatedSpriteData, Scene? scene = null, bool startEnabled = true) : base(startEnabled,scene)
    {
        Data = animatedSpriteData;
        var rend = new SpriteRenderer(Data.TextureData.texturePath, Data.Animations.First().Frames[0]);
        ECSEntity.Add(
            rend,
            new SpriteAnimator(Data.Animations),
            new Collider(0,0,Data.Animations.First().Frames[0].width,Data.Animations.First().Frames[0].height));
    }
    
    private bool colliderActive;
    public bool ColliderActive
    {
        get => colliderActive;
        set
        {
            ref var c = ref ECSEntity.Get<Collider>();
            c.active = value;
            colliderActive = value;
        }
    }
    
    public Action<Entity> OnCollision { get; set; }
}

public class ParticleEmitter : Entity
{
    public ParticleEmitterComponent.EmitterConfig Config;
    public ParticleEmitter(ParticleEmitterComponent.EmitterConfig config, Scene? scene = null, bool startEnabled = true) : base(startEnabled,scene)
    {
        Config = config;
        ECSEntity.Add(
            new ParticleEmitterComponent(config));
    }
}
