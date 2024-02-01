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
                    //allow collision start event to pump through all systems once
                    if (cm.starting == true && !cm.startDirty)
                    {
                        cm.startDirty = true;
                    }
                    else
                    {
                        cm.starting = false;
                        if (bufferedCollisionEvents.ContainsKey(cm.hash))
                        {
                            //this means we have an existing collision event that is still happening
                            cm.continuing = true;
                            bufferedCollisionEvents.Remove(cm.hash);
                        }
                        else
                        {
                            cm.ending = true;
                            em.dirty = true;
                        }
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
                // Events.Raise<Events.MouseEnemyCollision>(e.Value as Events.MouseEnemyCollision,e.Key);
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
                    if (cm.starting)
                    {
                        Console.WriteLine($"{e.Id}:enemy {c.e.name}: collision start");
                    }

                    if (cm.continuing)
                    {
                        Console.WriteLine($"{e.Id}:enemy {c.e.name}: collision continuing");
                    }

                    if (cm.ending)
                    {
                        Console.WriteLine($"{e.Id}:enemy {c.e.name}: collision ending");
                    }
                });
        }
    }
}