namespace Dinghy.Sandbox.Demos.dungeon;

public static class DA_STACK
{
    static DA_STACK()
    {
        Events.Commands.ExecutedCommandsUpdated += OnExecutedCommandUpdated;
    }

    static void OnExecutedCommandUpdated(GameCommand c)
    {
        if(c is IUpdatesCardDisplayState)
            Dungeon.Track.UpdategGameCardState();

        if(c is IMakesTrackAct)
            Dungeon.Track.Act();
    }
}