using Arch.CommandBuffer;
using Arch.Core;
using Arch.Core.Extensions;

namespace Dinghy.Sandbox.Demos.dungeon;



public record GameLogicEvent
{
    public void Emit()
    {
        Engine.ECSWorld.Create(
            new LogicEvents.Meta(Dungeon.LogicStackID),
            this);
        Dungeon.LogicStackID++;
    }
}


public static class LogicEvents
{
    public record struct Meta(int stackID, bool inprogress = false, bool dirty = false);
    
    public record Discard(int cardID) : GameLogicEvent;
    public record Destroyed(int cardID) : GameLogicEvent;
    public record Move : GameLogicEvent;
    public record Wait : GameLogicEvent;
    public record Draw : GameLogicEvent;
    public record Attack(int cardID) : GameLogicEvent;
}

// public void Act()
// {
//     //NEED TO MAKE THIS DISTINGUISH BETWEEN ACTING DIRECTLY AND CHASING (FROM MOVEMENT)
//     //MAYBE AN INTERFACE DIFFERENCE?
//         
//     //try to attack if in range
//     if (Distance <= 1)
//     {
//         Dungeon.Player.Damage(Attack);
//     }
//     else
//     {
//         Distance -= 1;
//     }
//     UpdateDebugText();
// }


public partial class Systems
{
    //THIS NEEDS TO BASICALLY BE A STATE MACHINE
    public class GameLogicSystem : DSystem, IUpdateSystem
    {
        QueryDescription trackCards = new QueryDescription().WithAll<Track.TrackComponent>();
        
        QueryDescription allEvents = new QueryDescription().WithAll<LogicEvents.Meta>();
        QueryDescription discard = new QueryDescription().WithAll<LogicEvents.Discard, LogicEvents.Meta>();
        public void Update(double dt)
        {
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
                    }
                });

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