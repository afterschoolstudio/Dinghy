namespace Dinghy.Sandbox.Demos.dungeon;

public class DA_STACK
{
    public DA_STACK()
    {
        Events.Commands.ExecutedCommandsUpdated += OnExecutedCommandUpdated;
    }

    static void OnExecutedCommandUpdated(GameCommand c)
    {
        if(c is IMakesTrackAct)
            Dungeon.Track.Act();
    }
}