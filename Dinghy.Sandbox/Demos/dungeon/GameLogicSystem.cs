using Arch.Core;

namespace Dinghy.Sandbox.Demos.dungeon;



public record GameLogicEvent
{
    public void Emit()
    {
        Engine.ECSWorld.Create(
            new GameLogicEventMeta(Dungeon.LogicStackID),
            this);
        Dungeon.LogicStackID++;
    }
}

public record GameLogicEventMeta(int stackID, bool inprogress = false, bool dirty = false);

public static class LogicEvents
{
    public record Discard(int cardID) : GameLogicEvent;
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
        
        QueryDescription discard = new QueryDescription().WithAll<LogicEvents.Discard>();
        public void Update(double dt)
        {
            Engine.ECSWorld.Query(in discard, (Arch.Core.Entity e, ref LogicEvents.Discard d) =>
                {
                    //check all track cards for discard effects based on keyword interface?
                    Engine.ECSWorld.Query(in trackCards, (Arch.Core.Entity e, ref Track.TrackComponent t) =>
                    {
                        //make this an enum flag for logic type
                        foreach (var keyword in Dungeon.AllCards[t.cardID].Keywords)
                        {
                            if (keyword.Triggers.Any(x => x.Name == "discardSelf"))
                            {
                                //do stuff
                            }
                        }
                    });
                });
        }
    }
}