namespace Dinghy.Sandbox.Demos.dungeon;

public static class Events
{
    public class Commands
    {
        public static Action<GameCommand> Execute;
        public static Action<GameCommand> CommandExecuted;
        public static Action<GameCommand> ExecutedCommandsUpdated;
    }
}