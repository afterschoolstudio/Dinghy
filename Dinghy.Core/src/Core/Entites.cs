using Arch.Core;

namespace Dinghy;

public abstract record EntityData
{
    public abstract void GetEntity(out Arch.Core.Entity e);
}

public abstract class Entity
{
    public HashSet<Component> Components { get; protected set; } 
    public AddComponent<T>() where T : Component;
}

public abstract class Component
{
    public virtual void AddECSRepresentation(){}
    public virtual void Update();
}