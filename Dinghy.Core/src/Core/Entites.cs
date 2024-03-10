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
    public int ID;
    public string Name { get; set; } = "entity";
    public string DebugText = "";
    // public bool DestoryOnLoad = true;
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
    
    private bool active = true;
    public bool Active
    {
        get => active;
        set
        {
            ref var a = ref ECSEntity.Get<Active>();
            a.active = value;
            active = value;
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
    
    //NOTE: maybe get rid of rotation/scale/pivot for an entity specifically?
    //they are more about component things instead of intrinsic entity things
    
    //also make physics and actual system to get rid of the jank setters
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
    
    private float pivotX = 0;
    public float PivotX
    {
        get => pivotX;
        set
        {
            ref var pos = ref ECSEntity.Get<Position>();
            pos.pivotX = value;
            pivotX = value;
        }
    }
    
    private float pivotY = 0;
    public float PivotY
    {
        get => pivotY;
        set
        {
            ref var pos = ref ECSEntity.Get<Position>();
            pos.pivotY = value;
            pivotY = value;
        }
    }


    public void SetPositionRaw(float x, float y, float rotation, float scaleX, float scaleY, float pivotX, float pivotY)
    {
        this.x = x;
        this.y = y;
        this.scaleX = scaleX;
        this.scaleY = scaleY;
        this.rotation = rotation;
        this.pivotX = pivotX;
        this.pivotY = pivotY;
    }

    public void SetPosition(float x, float y, float rotation, float scaleX, float scaleY, float pivotX, float pivotY)
    {
        ref var pos = ref ECSEntity.Get<Position>();
        pos.x = x;
        pos.y = y;
        pos.scaleY = scaleY;
        pos.scaleX = scaleX;
        pos.rotation = rotation;
        pos.pivotX = pivotX;
        pos.pivotY = pivotY;
        SetPositionRaw(x,y,rotation,scaleX,scaleY,pivotX,pivotY);
    }
    
    public List<Component> Components = new List<Component>();
    public Arch.Core.EntityReference ECSEntityReference;
    public Arch.Core.Entity ECSEntity => ECSEntityReference.Entity;
    public Scene? Scene;
    public Entity(bool startEnabled, Scene scene, bool addToSceneHeirarchy = true, Action<Entity,double> update = null)
    {
        ID = Engine.GetNextEntityID();
        Scene = scene != null ? scene : Engine.TargetScene;
        Arch.Core.Entity e = addToSceneHeirarchy
            //in-scene entity
            ? Engine.ECSWorld.Create(
                new Active(startEnabled),
                new HasManagedOwner(this),
                new Position(X, Y),
                new UpdateListener(this, update),
                new SceneMember(Scene.ID)
            )
            //non-in-scene entity
            : Engine.ECSWorld.Create(
                new Active(startEnabled),
                new HasManagedOwner(this),
                new Position(X, Y),
                new UpdateListener(this, update));
        ECSEntityReference = Engine.ECSWorld.Reference(e);
        Engine.ECSWorld.Add<Entity>(ECSEntity);
        if (addToSceneHeirarchy)
        {
            Engine.SceneEntityMap[Scene].Add(this);
        }
    }
    
    public void Destroy()
    {
        if (!ECSEntity.Has<Destroy>())
        {
            ECSEntity.Add(new Destroy());
        }
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
    private int sceneRenderCounter = 0;
    public int GetNextSceneRenderCounter()
    {
        var curr = sceneRenderCounter;
        sceneRenderCounter++;
        return curr;
    }
    
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
    public void Start(bool setAsTargetScene = true)
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
        if (setAsTargetScene)
        {
            Engine.SetTargetScene(this);
        }
        Create();
        Status = SceneStatus.Running;
    }
    public virtual void Create(){}
    public virtual void Cleanup(){}
}

public class Shape : Entity
{
    private Color c;
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
    
    public Shape(Color color, int width = 32, int height = 32, Scene? scene = null, bool startEnabled = true, 
        Action<Entity,double> update = null,
        Action<EntityReference,EntityReference> collisionStart = null, 
        Action<EntityReference,EntityReference> collisionStop = null, 
        Action<EntityReference,EntityReference> collisionContinue = null,
        Action<Arch.Core.Entity,List<Modifiers>> OnMouseUp = null,
        Action<Arch.Core.Entity,List<Modifiers>> OnMousePressed = null,
        Action<Arch.Core.Entity,List<Modifiers>> OnMouseDown = null,
        Action<Arch.Core.Entity,List<Modifiers>> OnMouseEnter = null,
        Action<Arch.Core.Entity,List<Modifiers>> OnMouseLeave = null,
        Action<Arch.Core.Entity,List<Modifiers>> OnMouseOver = null,
        Action<Arch.Core.Entity,List<Modifiers>,float,float> OnMouseScroll = null
        
        ) : base(startEnabled,scene,update:update)
    {
        c = color;
        var rend = new ShapeRenderer(color, width, height);
        sceneRenderOrder = Scene.GetNextSceneRenderCounter();
        ECSEntity.Add(
            rend,
            new RenderItem(sceneRenderOrder),
            new Collider(0,0,width,height,false,collisionStart,collisionContinue,collisionStop,OnMouseUp, OnMousePressed, OnMouseDown, OnMouseScroll,OnMouseEnter,OnMouseLeave,OnMouseOver));
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
    
    private int sceneRenderOrder;
    public int SceneRenderOrder
    {
        get => sceneRenderOrder;
        set
        {
            ref var r = ref ECSEntity.Get<RenderItem>();
            r.renderOrder = value;
            sceneRenderOrder = value;
        }
    }
    // [BindECSComponentValue<Collider>("active")]
    // private bool colliderActives;
}

public class Pointer : Entity
{
    public Pointer(bool startEnabled = true) : base(startEnabled,null,false)
    {
        ECSEntity.Add(new Collider(0,0,1,1,active:true));
    }
}


public record SpriteData(Resources.Texture Texture, Rect Rect);


public class Sprite : Entity
{
    public SpriteData Data { get; init; }
    public Sprite(SpriteData spriteData, Scene? scene = null, bool startEnabled = true, 
        Action<Entity,double> update = null,
        Action<EntityReference,EntityReference> collisionStart = null, 
        Action<EntityReference,EntityReference> collisionStop = null, 
        Action<EntityReference,EntityReference> collisionContinue = null,
        Action<Arch.Core.Entity,List<Modifiers>> OnMouseUp = null,
        Action<Arch.Core.Entity,List<Modifiers>> OnMousePressed = null,
        Action<Arch.Core.Entity,List<Modifiers>> OnMouseDown = null,
        Action<Arch.Core.Entity,List<Modifiers>> OnMouseEnter = null,
        Action<Arch.Core.Entity,List<Modifiers>> OnMouseLeave = null,
        Action<Arch.Core.Entity,List<Modifiers>> OnMouseOver = null,
        Action<Arch.Core.Entity,List<Modifiers>,float,float> OnMouseScroll = null
        
        
        ) : base(startEnabled,scene,update:update)
    {
        Data = spriteData;
        sceneRenderOrder = Scene.GetNextSceneRenderCounter();
        var rend = new SpriteRenderer(Data.Texture, Data.Rect);
        ECSEntity.Add(
            rend,
            new RenderItem(sceneRenderOrder),
            new Collider(0,0,Data.Rect.width,Data.Rect.height,false,collisionStart,collisionContinue,collisionStop,OnMouseUp, OnMousePressed, OnMouseDown, OnMouseScroll,OnMouseEnter,OnMouseLeave,OnMouseOver));
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
    
    private int sceneRenderOrder;
    public int SceneRenderOrder
    {
        get => sceneRenderOrder;
        set
        {
            ref var r = ref ECSEntity.Get<RenderItem>();
            r.renderOrder = value;
            sceneRenderOrder = value;
        }
    }
}

public record AnimatedSpriteData(Resources.Texture Texture, HashSet<Animation> Animations);
public class AnimatedSprite : Entity
{
    public AnimatedSpriteData Data { get; init; }
    public AnimatedSprite(AnimatedSpriteData animatedSpriteData, Scene? scene = null, bool startEnabled = true, 
        Action<Entity,double> update = null,
        Action<EntityReference,EntityReference> collisionStart = null, 
        Action<EntityReference,EntityReference> collisionStop = null, 
        Action<EntityReference,EntityReference> collisionContinue = null,
        Action<Arch.Core.Entity,List<Modifiers>> OnMouseUp = null,
        Action<Arch.Core.Entity,List<Modifiers>> OnMousePressed = null,
        Action<Arch.Core.Entity,List<Modifiers>> OnMouseDown = null,
        Action<Arch.Core.Entity,List<Modifiers>> OnMouseEnter = null,
        Action<Arch.Core.Entity,List<Modifiers>> OnMouseLeave = null,
        Action<Arch.Core.Entity,List<Modifiers>> OnMouseOver = null,
        Action<Arch.Core.Entity,List<Modifiers>,float,float> OnMouseScroll = null
        
        
        ) : base(startEnabled,scene,update:update)
    {
        Data = animatedSpriteData;
        var rend = new SpriteRenderer(Data.Texture, Data.Animations.First().Frames[0]);
        sceneRenderOrder = Scene.GetNextSceneRenderCounter();
        ECSEntity.Add(
            rend,
            new RenderItem(sceneRenderOrder),
            new SpriteAnimator(Data.Animations),
            new Collider(0,0,Data.Animations.First().Frames[0].width,Data.Animations.First().Frames[0].height,false,collisionStart,collisionContinue,collisionStop,OnMouseUp,OnMousePressed, OnMouseDown, OnMouseScroll,OnMouseEnter,OnMouseLeave,OnMouseOver));
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
    
    private int sceneRenderOrder;
    public int SceneRenderOrder
    {
        get => sceneRenderOrder;
        set
        {
            ref var r = ref ECSEntity.Get<RenderItem>();
            r.renderOrder = value;
            sceneRenderOrder = value;
        }
    }
}

public class ParticleEmitter : Entity
{
    public ParticleEmitterComponent.EmitterConfig Config;
    public ParticleEmitter(ParticleEmitterComponent.EmitterConfig config, Scene? scene = null, bool startEnabled = true) : base(startEnabled,scene)
    {
        Config = config;
        ECSEntity.Add(
            new RenderItem(scene.GetNextSceneRenderCounter()),
            new ParticleEmitterComponent(config));
    }
}