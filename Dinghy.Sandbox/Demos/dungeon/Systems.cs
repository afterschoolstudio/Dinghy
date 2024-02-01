using Arch.Core;
using Arch.Core.Extensions;

namespace Dinghy.Sandbox.Demos.dungeon;

public class Systems
{
    public static void Init()
    {
        Engine.RegisterSystem(new EventCleaningSystem());
        Engine.RegisterSystem(new CollisionSystem());
        Engine.RegisterSystem(new MouseEnemyCollisonHandler());
    }

    public class EventCleaningSystem : DSystem, ICleanupSystem
    {
        private QueryDescription events = new QueryDescription().WithAll<Events.EventMeta>();
        public void Cleanup()
        {
            Engine.ECSWorld.Query(in events,
            (Arch.Core.Entity e, ref Events.EventMeta m) =>
            {
                Console.WriteLine(m.index + "  " + m.eventType);
                if (m.processed || m.dirty)
                {
                    e.Add(new Destroy());
                }
                else if (!m.dirty)
                {
                    m.dirty = true;
                }
            });
        }
    }
    
    public class CollisionSystem : DSystem, IUpdateSystem
    {
        QueryDescription query = new QueryDescription().WithAll<Active,Collider,Position,HasManagedOwner>();
        private List<(Arch.Core.Entity e,Collider c,Position p)> colliders = new();
        public void Update(double dt)
        {
            colliders.Clear();
            Engine.ECSWorld.Query(in query, (Arch.Core.Entity e, ref Position p, ref Collider c, ref HasManagedOwner o) =>
            {
                if(!c.active){return;}
                for (int i = 0; i < colliders.Count; i++)
                {
                    if (Dinghy.Collision.CheckCollision(c,p, colliders[i].c,colliders[i].p))
                    {
                        if (colliders[i].e.Has<DataTypes.EnemyComponent>())
                        {
                            Events.Raise(new Events.MouseEnemyCollision(colliders[i].e.Get<DataTypes.EnemyComponent>()));
                        }
                    }
                }
                colliders.Add((e,c,p));
            });
        }
    }
    
    public class MouseEnemyCollisonHandler : DSystem, ICleanupSystem
    {
        private QueryDescription events = new QueryDescription().WithAll<Events.EventMeta,Events.MouseEnemyCollision>();
        public void Cleanup()
        {
            Engine.ECSWorld.Query(in events,
                (Arch.Core.Entity e, ref Events.EventMeta m, ref Events.MouseEnemyCollision c) =>
                {
                    m.processed = true;
                    Console.WriteLine(c.e.name);
                });
        }
    }
}