using System.Reflection;
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
                // Console.WriteLine(m.index + "  " + m.eventType);
                if (m.dirty)
                {
                    e.Add(new Destroy());
                }
                else
                {
                    m.dirty = true;
                }
            });
        }
    }
    
    public class CollisionSystem : DSystem, IUpdateSystem
    {
        QueryDescription query = new QueryDescription().WithAll<Active,Collider,Position,HasManagedOwner>();
        QueryDescription colQuery = new QueryDescription().WithAll<Events.EventMeta,Events.CollisionMeta>();
        private List<(Arch.Core.Entity e,Collider c,Position p)> colliders = new();
        
        private Dictionary<int, Events.CollisionEvent> bufferedCollisionEvents = new();
        public void Update(double dt)
        {
            colliders.Clear();
            Engine.ECSWorld.Query(in query, (Arch.Core.Entity e, ref Position p, ref Collider c, ref HasManagedOwner o) =>
            {
                if(!c.active){return;}
                for (int i = 0; i < colliders.Count; i++)
                {
                    if (e.Id != colliders[i].e.Id && Dinghy.Collision.CheckCollision(c,p, colliders[i].c,colliders[i].p))
                    {
                        if (colliders[i].e.Has<DataTypes.EnemyComponent>())
                        {
                            var hash = HashCode.Combine(e.Id, colliders[i].e.Id);
                            if (!bufferedCollisionEvents.ContainsKey(hash))
                            {
                                bufferedCollisionEvents.Add(
                                    hash, new Events.MouseEnemyCollision(colliders[i].e.Get<DataTypes.EnemyComponent>()));
                            }
                        }
                    }
                }
                colliders.Add((e,c,p));
            });

            Engine.ECSWorld.Query(in colQuery,
                (Arch.Core.Entity e, ref Events.CollisionMeta cm, ref Events.EventMeta em) =>
                {
                    em.dirty = false; //keep the event alive
                    if (bufferedCollisionEvents.ContainsKey(cm.hash)) //if we have buffered a collision that already exists
                    {
                        cm.state = Events.CollisionState.Continuing;
                        bufferedCollisionEvents.Remove(cm.hash);
                    }
                    else
                    {
                        cm.state = Events.CollisionState.Ending;
                        em.dirty = true;
                    }

                    
                });

            foreach (var e in bufferedCollisionEvents)
            {
                switch (e.Value)
                {
                    case Events.MouseEnemyCollision specificEvent:
                        Events.Raise(specificEvent, e.Key);
                        break;
                    default:
                        throw new InvalidOperationException("Unhandled event type");
                }
                //this doesnt work and instead assumes the base type - maybe a Arch bug?
                // Events.Raise(e.Value,e.Key);
            }
        }
    }
    
    public class MouseEnemyCollisonHandler : DSystem, IUpdateSystem
    {
        private QueryDescription eq = new QueryDescription().WithAll<Events.CollisionMeta,Events.MouseEnemyCollision>();
        public void Update(double dt)
        {
            Engine.ECSWorld.Query(in eq,
                (Arch.Core.Entity e, ref Events.CollisionMeta cm, ref Events.MouseEnemyCollision c) =>
                {
                    
                    switch (cm.state)
                    {
                        case Events.CollisionState.Starting:
                            c.e.enemy.MouseCollisionStart();
                            break;
                        case Events.CollisionState.Continuing:
                            c.e.enemy.MouseCollistionContinue();
                            break;
                        case Events.CollisionState.Ending:
                            c.e.enemy.MouseCollisionStop();
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                });
        }
    }
}