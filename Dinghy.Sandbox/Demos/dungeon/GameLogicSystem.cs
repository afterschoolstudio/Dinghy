using Arch.Core;

namespace Dinghy.Sandbox.Demos.dungeon;


public record GameLogicEvent
{
    public void Emit()
    {
        Engine.ECSWorld.Create(
            this);
    }
}
public record Discard(DeckCard c);
public record Draw;
public record Attack(DeckCard c);

public partial class Systems
{
    //THIS NEEDS TO BASICALLY BE A STATE MACHINE
    public class GameLogicSystem : DSystem, IUpdateSystem
    {
        QueryDescription query = new QueryDescription().WithAll<Discard>();
        public void Update(double dt)
        {
            Engine.ECSWorld.Query(in query,
                (Arch.Core.Entity e, ref Discard d) =>
                {
                    //check all track cards for discard effects based on keyword interface?
                });
        }
    }
}