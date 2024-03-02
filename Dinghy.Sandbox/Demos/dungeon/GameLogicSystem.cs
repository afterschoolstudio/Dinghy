using Arch.CommandBuffer;
using Arch.Core;
using Arch.Core.Extensions;

namespace Dinghy.Sandbox.Demos.dungeon;



public abstract record GameLogicEvent
{
    public Action<bool> OnComplete;
    public void Emit(Action<bool> onComplete = null)
    {
        OnComplete += onComplete;
        CreateECSObject();
        Dungeon.LogicStackID++;
    }
    protected abstract void CreateECSObject();
}
public static class LogicEvents
{
    public record struct Meta(int stackID, Action<bool> completionCallback, bool cancelled = false, bool dirty = false);
    public record Discard(int cardID) : GameLogicEvent
    {
        protected override void CreateECSObject()
        {
            Engine.ECSWorld.Create(
                new LogicEvents.Meta(Dungeon.LogicStackID,OnComplete),
                this);
        }
    }

    public record Destroyed(int cardID) : GameLogicEvent
    {
        protected override void CreateECSObject()
        {
            Engine.ECSWorld.Create(
                new LogicEvents.Meta(Dungeon.LogicStackID,OnComplete),
                this);
        }
    }
    
    public record TrackCardAttackPlayer(int cardID) : GameLogicEvent
    {
        protected override void CreateECSObject()
        {
            Engine.ECSWorld.Create(
                new LogicEvents.Meta(Dungeon.LogicStackID,OnComplete),
                this);
        }
    }

    public record Move : GameLogicEvent
    {
        protected override void CreateECSObject()
        {
            Engine.ECSWorld.Create(
                new LogicEvents.Meta(Dungeon.LogicStackID,OnComplete),
                this);
        }
    }

    public record Wait : GameLogicEvent
    {
        protected override void CreateECSObject()
        {
            Engine.ECSWorld.Create(
                new LogicEvents.Meta(Dungeon.LogicStackID,OnComplete),
                this);
        }
    }

    public record Draw : GameLogicEvent
    {
        protected override void CreateECSObject()
        {
            Engine.ECSWorld.Create(
                new LogicEvents.Meta(Dungeon.LogicStackID,OnComplete),
                this);
        }
    }

    public record AttackTrackCard(int cardID) : GameLogicEvent
    {
        protected override void CreateECSObject()
        {
            Engine.ECSWorld.Create(
                new LogicEvents.Meta(Dungeon.LogicStackID,OnComplete),
                this);
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
        QueryDescription playerAttacked = new QueryDescription().WithAll<LogicEvents.AttackTrackCard, LogicEvents.Meta>();
        QueryDescription draw = new QueryDescription().WithAll<LogicEvents.Draw, LogicEvents.Meta>();
        QueryDescription trackCardAttacked = new QueryDescription().WithAll<LogicEvents.TrackCardAttackPlayer, LogicEvents.Meta>();
        
        public void Update(double dt)
        {
            //discard
            Engine.ECSWorld.Query(in discard, (Arch.Core.Entity e, ref LogicEvents.Discard d, ref LogicEvents.Meta em) =>
            {
                var discardedCard = Dungeon.AllCards[d.cardID];
                bool eventCancelled = false;
                //check all track cards triggers that listen to discard effects
                Engine.ECSWorld.Query(in trackCards, (Arch.Core.Entity e, ref Track.TrackComponent t) =>
                {
                    //make this an enum flag for logic type
                    foreach (var keyword in Dungeon.AllCards[t.cardID].Keywords)
                    {
                        if (keyword.Triggers.Any(x => x.Name == "discardSelf") && discardedCard == Dungeon.AllCards[t.cardID])
                        {
                            keyword.TriggerFor(Dungeon.AllCards[t.cardID], ref eventCancelled,"discardSelf");
                        }
                        
                        if (keyword.Triggers.Any(x => x.Name == "discard"))
                        {
                            keyword.TriggerFor(Dungeon.AllCards[t.cardID], ref eventCancelled,"discard");
                        }
                    }
                });

                em.completionCallback?.Invoke(!eventCancelled);
                em.dirty = true;
            });
            
            //move
            Engine.ECSWorld.Query(in move, (Arch.Core.Entity e, ref LogicEvents.Move m, ref LogicEvents.Meta em) =>
            {
                bool eventCancelled = false;
                //check all track cards triggers that listen to discard effects
                Engine.ECSWorld.Query(in trackCards, (Arch.Core.Entity e, ref Track.TrackComponent t) =>
                {
                    //make this an enum flag for logic type
                    foreach (var keyword in Dungeon.AllCards[t.cardID].Keywords)
                    {
                        if (keyword.Triggers.Any(x => x.Name == "move"))
                        {
                            keyword.TriggerFor(Dungeon.AllCards[t.cardID], ref eventCancelled,"move");
                        }
                    }
                });
                
                em.completionCallback?.Invoke(!eventCancelled);
                em.dirty = true;
            });
            
            //wait
            Engine.ECSWorld.Query(in wait, (Arch.Core.Entity e, ref LogicEvents.Wait w, ref LogicEvents.Meta em) =>
            {
                bool eventCancelled = false;
                //check all track cards triggers that listen to discard effects
                Engine.ECSWorld.Query(in trackCards, (Arch.Core.Entity e, ref Track.TrackComponent t) =>
                {
                    //make this an enum flag for logic type
                    foreach (var keyword in Dungeon.AllCards[t.cardID].Keywords)
                    {
                        if (keyword.Triggers.Any(x => x.Name == "wait"))
                        {
                            keyword.TriggerFor(Dungeon.AllCards[t.cardID], ref eventCancelled,"wait");
                        }
                    }
                });
                
                em.completionCallback?.Invoke(!eventCancelled);
                em.dirty = true;
            });
            
            //draw
            Engine.ECSWorld.Query(in draw, (Arch.Core.Entity e, ref LogicEvents.Draw d, ref LogicEvents.Meta em) =>
            {
                bool eventCancelled = false;
                //check all track cards triggers that listen to discard effects
                Engine.ECSWorld.Query(in trackCards, (Arch.Core.Entity e, ref Track.TrackComponent t) =>
                {
                    //make this an enum flag for logic type
                    foreach (var keyword in Dungeon.AllCards[t.cardID].Keywords)
                    {
                        if (keyword.Triggers.Any(x => x.Name == "draw"))
                        {
                            keyword.TriggerFor(Dungeon.AllCards[t.cardID], ref eventCancelled,"draw");
                        }
                    }
                });
                
                em.completionCallback?.Invoke(!eventCancelled);
                em.dirty = true;
            });
            
            //attacked
            Engine.ECSWorld.Query(in playerAttacked, (Arch.Core.Entity e, ref LogicEvents.AttackTrackCard d, ref LogicEvents.Meta em) =>
            {
                bool eventCancelled = false;
                var attackedCard = Dungeon.AllCards[d.cardID];
                //check all track cards triggers that listen to discard effects
                Engine.ECSWorld.Query(in trackCards, (Arch.Core.Entity e, ref Track.TrackComponent t) =>
                {
                    //make this an enum flag for logic type
                    foreach (var keyword in Dungeon.AllCards[t.cardID].Keywords)
                    {
                        if (keyword.Triggers.Any(x => x.Name == "attackedByPlayer") && attackedCard == Dungeon.AllCards[t.cardID])
                        {
                            keyword.TriggerFor(Dungeon.AllCards[t.cardID], ref eventCancelled,"attackedByPlayer");
                        }
                    }
                });
                
                em.completionCallback?.Invoke(!eventCancelled);
                em.dirty = true;
            });
            
            //card is attacking
            Engine.ECSWorld.Query(in trackCardAttacked, (Arch.Core.Entity e, ref LogicEvents.TrackCardAttackPlayer d, ref LogicEvents.Meta em) =>
            {
                bool eventCancelled = false;
                var attackingCard = Dungeon.AllCards[d.cardID];
                //check all track cards triggers that listen to discard effects
                Engine.ECSWorld.Query(in trackCards, (Arch.Core.Entity e, ref Track.TrackComponent t) =>
                {
                    //make this an enum flag for logic type
                    foreach (var keyword in Dungeon.AllCards[t.cardID].Keywords)
                    {
                        if (keyword.Triggers.Any(x => x.Name == "selfAttacking") && attackingCard == Dungeon.AllCards[t.cardID])
                        {
                            keyword.TriggerFor(Dungeon.AllCards[t.cardID], ref eventCancelled,"selfAttacking");
                        }
                        
                        if (keyword.Triggers.Any(x => x.Name == "anyAttacking"))
                        {
                            keyword.TriggerFor(Dungeon.AllCards[t.cardID], ref eventCancelled,"selfAttacking");
                        }
                    }
                });
                
                em.completionCallback?.Invoke(!eventCancelled);
                em.dirty = true;
            });
            
            //destroyed
            Engine.ECSWorld.Query(in destroyed, (Arch.Core.Entity e, ref LogicEvents.Destroyed d, ref LogicEvents.Meta em) =>
            {
                bool eventCancelled = false;
                var destroyedCard = Dungeon.AllCards[d.cardID];
                //check all track cards triggers that listen to discard effects
                Engine.ECSWorld.Query(in trackCards, (Arch.Core.Entity e, ref Track.TrackComponent t) =>
                {
                    //make this an enum flag for logic type
                    foreach (var keyword in Dungeon.AllCards[t.cardID].Keywords)
                    {
                        if (keyword.Triggers.Any(x => x.Name == "destroyedAny"))
                        {
                            keyword.TriggerFor(Dungeon.AllCards[t.cardID], ref eventCancelled,"destroyedAny");
                        }
                    }
                });
                
                Engine.ECSWorld.Query(in trackCards, (Arch.Core.Entity e, ref Track.TrackComponent t) =>
                {
                    //make this an enum flag for logic type
                    foreach (var keyword in Dungeon.AllCards[t.cardID].Keywords)
                    {
                        if (keyword.Triggers.Any(x => x.Name == "destroyedSelf") && destroyedCard == Dungeon.AllCards[t.cardID])
                        {
                            keyword.TriggerFor(Dungeon.AllCards[t.cardID], ref eventCancelled,"destroyedSelf");
                        }
                    }
                });
                
                em.completionCallback?.Invoke(!eventCancelled);
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