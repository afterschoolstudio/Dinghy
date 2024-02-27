namespace Dinghy.Sandbox.Demos.dungeon;

public class EventBus
{
    public EventBus()
    {
        Events.Commands.Execute += OnExecuteCommand;
        Events.Commands.CommandExecuted += OnCommandExecuted;
    }

    public void Cleanup()
    {
        Events.Commands.Execute -= OnExecuteCommand;
        Events.Commands.CommandExecuted -= OnCommandExecuted;
    }

    void OnExecuteCommand(GameCommand c)
    {
        c.Execute();
    }

    private List<GameCommand> executedCommands = new();
    void OnCommandExecuted(GameCommand c)
    {
        //re-emit this to network
        //add to command list
        //say we're done
        executedCommands.Add(c);
        Events.Commands.ExecutedCommandsUpdated?.Invoke(c);
    }
}