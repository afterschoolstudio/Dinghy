using Arch.CommandBuffer;
using Arch.Core;
using Arch.Core.Extensions;

namespace Dinghy.Sandbox.Demos.dungeon;



public abstract record GameLogicEvent
{
    public Action OnComplete;
    public void Emit(Action onComplete = null)
    {
        OnComplete += onComplete;
        CreateECSObject();
    }
    protected abstract void CreateECSObject();
}
public static class LogicEvents
{
    public record struct Meta(int stackID, Action completionCallback, bool inprogress = false, bool dirty = false);
    public record Discard(int cardID) : GameLogicEvent
    {
        protected override void CreateECSObject()
        {
            Engine.ECSWorld.Create(
                new LogicEvents.Meta(Dungeon.LogicStackID,OnComplete),
                this);
            Dungeon.LogicStackID++;
        }
    }

    public record Destroyed(int cardID) : GameLogicEvent
    {
        protected override void CreateECSObject()
        {
            Engine.ECSWorld.Create(
                new LogicEvents.Meta(Dungeon.LogicStackID,OnComplete),
                this);
            Dungeon.LogicStackID++;
        }
    }

    public record Move : GameLogicEvent
    {
        protected override void CreateECSObject()
        {
            Engine.ECSWorld.Create(
                new LogicEvents.Meta(Dungeon.LogicStackID,OnComplete),
                this);
            Dungeon.LogicStackID++;
        }
    }

    public record Wait : GameLogicEvent
    {
        protected override void CreateECSObject()
        {
            Engine.ECSWorld.Create(
                new LogicEvents.Meta(Dungeon.LogicStackID,OnComplete),
                this);
            Dungeon.LogicStackID++;
        }
    }

    public record Draw : GameLogicEvent
    {
        protected override void CreateECSObject()
        {
            Engine.ECSWorld.Create(
                new LogicEvents.Meta(Dungeon.LogicStackID,OnComplete),
                this);
            Dungeon.LogicStackID++;
        }
    }

    public record Attack(int cardID) : GameLogicEvent
    {
        protected override void CreateECSObject()
        {
            Engine.ECSWorld.Create(
                new LogicEvents.Meta(Dungeon.LogicStackID,OnComplete),
                this);
            Dungeon.LogicStackID++;
        }
    }
}

public partial class Systems
{
    //THIS NEEDS TO BASICALLY BE A STATE MACHINE
    public class GameLogicSystem : DSystem, IUpdateSystem
    {
        QueryDescription trackCards = new QueryDescription().WithAll<Track.TrackComponent>();
        QueryDescription allEvents = new QueryDescription().WithAll<LogicEvents.Meta>();
        
        
        QueryDescription discard = new QueryDescription().WithAll<LogicEvents.Discard, LogicEvents.Meta>();
        QueryDescription move = new QueryDescription().WithAll<LogicEvents.Move, LogicEvents.Meta>();
        QueryDescription wait = new QueryDescription().WithAll<LogicEvents.Wait, LogicEvents.Meta>();
        QueryDescription destroyed = new QueryDescription().WithAll<LogicEvents.Destroyed, LogicEvents.Meta>();
        QueryDescription attacked = new QueryDescription().WithAll<LogicEvents.Attack, LogicEvents.Meta>();
        QueryDescription draw = new QueryDescription().WithAll<LogicEvents.Draw, LogicEvents.Meta>();
        
        public void Update(double dt)
        {
            //discard
            Engine.ECSWorld.Query(in discard, (Arch.Core.Entity e, ref LogicEvents.Discard d, ref LogicEvents.Meta em) =>
            {
                var discardedCard = Dungeon.AllCards[d.cardID];
                //check all track cards triggers that listen to discard effects
                Engine.ECSWorld.Query(in trackCards, (Arch.Core.Entity e, ref Track.TrackComponent t) =>
                {
                    //make this an enum flag for logic type
                    foreach (var keyword in Dungeon.AllCards[t.cardID].Keywords)
                    {
                        if (keyword.Triggers.Any(x => x.Name == "discardSelf") && discardedCard == Dungeon.AllCards[t.cardID])
                        {
                            keyword.TriggerFor(Dungeon.AllCards[t.cardID]);
                        }
                        
                        if (keyword.Triggers.Any(x => x.Name == "discard"))
                        {
                            keyword.TriggerFor(Dungeon.AllCards[t.cardID]);
                        }
                    }
                });
                
                em.completionCallback?.Invoke();
                em.dirty = true;
            });
            
            //move
            Engine.ECSWorld.Query(in move, (Arch.Core.Entity e, ref LogicEvents.Move m, ref LogicEvents.Meta em) =>
            {
                //check all track cards triggers that listen to discard effects
                Engine.ECSWorld.Query(in trackCards, (Arch.Core.Entity e, ref Track.TrackComponent t) =>
                {
                    //make this an enum flag for logic type
                    foreach (var keyword in Dungeon.AllCards[t.cardID].Keywords)
                    {
                        if (keyword.Triggers.Any(x => x.Name == "move"))
                        {
                            keyword.TriggerFor(Dungeon.AllCards[t.cardID]);
                        }
                    }
                });
                
                em.completionCallback?.Invoke();
                em.dirty = true;
            });
            
            //wait
            Engine.ECSWorld.Query(in wait, (Arch.Core.Entity e, ref LogicEvents.Wait w, ref LogicEvents.Meta em) =>
            {
                //check all track cards triggers that listen to discard effects
                Engine.ECSWorld.Query(in trackCards, (Arch.Core.Entity e, ref Track.TrackComponent t) =>
                {
                    //make this an enum flag for logic type
                    foreach (var keyword in Dungeon.AllCards[t.cardID].Keywords)
                    {
                        if (keyword.Triggers.Any(x => x.Name == "wait"))
                        {
                            keyword.TriggerFor(Dungeon.AllCards[t.cardID]);
                        }
                    }
                });
                
                em.completionCallback?.Invoke();
                em.dirty = true;
            });
            
            //draw
            Engine.ECSWorld.Query(in draw, (Arch.Core.Entity e, ref LogicEvents.Draw d, ref LogicEvents.Meta em) =>
            {
                //check all track cards triggers that listen to discard effects
                Engine.ECSWorld.Query(in trackCards, (Arch.Core.Entity e, ref Track.TrackComponent t) =>
                {
                    //make this an enum flag for logic type
                    foreach (var keyword in Dungeon.AllCards[t.cardID].Keywords)
                    {
                        if (keyword.Triggers.Any(x => x.Name == "draw"))
                        {
                            keyword.TriggerFor(Dungeon.AllCards[t.cardID]);
                        }
                    }
                });
                
                em.completionCallback?.Invoke();
                em.dirty = true;
            });
            
            //wait
            Engine.ECSWorld.Query(in wait, (Arch.Core.Entity e, ref LogicEvents.Wait d, ref LogicEvents.Meta em) =>
            {
                //check all track cards triggers that listen to discard effects
                Engine.ECSWorld.Query(in trackCards, (Arch.Core.Entity e, ref Track.TrackComponent t) =>
                {
                    //make this an enum flag for logic type
                    foreach (var keyword in Dungeon.AllCards[t.cardID].Keywords)
                    {
                        if (keyword.Triggers.Any(x => x.Name == "wait"))
                        {
                            keyword.TriggerFor(Dungeon.AllCards[t.cardID]);
                        }
                    }
                });
                
                em.completionCallback?.Invoke();
                em.dirty = true;
            });
            
            //attacked
            Engine.ECSWorld.Query(in attacked, (Arch.Core.Entity e, ref LogicEvents.Attack d, ref LogicEvents.Meta em) =>
            {
                var attackedCard = Dungeon.AllCards[d.cardID];
                //check all track cards triggers that listen to discard effects
                Engine.ECSWorld.Query(in trackCards, (Arch.Core.Entity e, ref Track.TrackComponent t) =>
                {
                    //make this an enum flag for logic type
                    foreach (var keyword in Dungeon.AllCards[t.cardID].Keywords)
                    {
                        if (keyword.Triggers.Any(x => x.Name == "attack") && attackedCard == Dungeon.AllCards[t.cardID])
                        {
                            keyword.TriggerFor(Dungeon.AllCards[t.cardID]);
                        }
                    }
                });
                
                em.completionCallback?.Invoke();
                em.dirty = true;
            });

            CommandBuffer cb = new CommandBuffer(Engine.ECSWorld);
            Engine.ECSWorld.Query(in allEvents, (Arch.Core.Entity e, ref LogicEvents.Meta em) =>
            {
                if (em.dirty)
                {
                    cb.Add(in e, new Destroy());
                }
            });
            cb.Playback();

        }
    }
}