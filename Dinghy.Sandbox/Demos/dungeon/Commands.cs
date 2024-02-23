using System.Reflection;

namespace Dinghy.Sandbox.Demos.dungeon;

public class GameCommandSerializationInfoAttribute : System.Attribute
{
    public string SerializedTypeName { get; protected set; }
    public GameCommandSerializationInfoAttribute(string serializedTypeName)
    {
        SerializedTypeName = serializedTypeName;
    }
}

public record GameCommand
{
    public string guid;
    public int id;
    public string TypeString;
    public void Execute()
    {
        ExecuteCommand();
    }

    protected virtual void ExecuteCommand()
    {
        Events.Commands.Execute?.Invoke(this);
    }

    public string Serialize()
    {
        var attr = (GameCommandSerializationInfoAttribute) this.GetType().GetCustomAttribute(typeof(GameCommandSerializationInfoAttribute));
        if(attr == null) {Console.WriteLine($"trying to serialize a player command of type {this.GetType().Name} that has no serialization attribute, command will be unreachable");}
        TypeString = attr.SerializedTypeName;
        return ToString();
    }
}


public abstract record PlayerCommand : GameCommand{}

[GameCommandSerializationInfo("PlayerMove")]
public record PlayerMove : PlayerCommand, IMakesTrackAct, IUpdatesCardDisplayState
{
    public int NumberRemoved { get; protected set; }
    protected override void ExecuteCommand()
    {
        Dungeon.Player.Move();
        Events.Commands.CommandExecuted?.Invoke(this);
    }
}

[GameCommandSerializationInfo("PlayerWait")]
public record PlayerWait : PlayerCommand, IMakesTrackAct
{
    protected override void ExecuteCommand()
    {
        Dungeon.Player.Wait();
        Events.Commands.CommandExecuted?.Invoke(this);
    }
}

[GameCommandSerializationInfo("PlayerAttackTrackCards")]
public record PlayerAttackTrackCards(List<int> trackIndicies) : PlayerCommand, IMakesTrackAct
{
    protected override void ExecuteCommand()
    {
        Dungeon.Player.Attack(trackIndicies);
        Events.Commands.CommandExecuted?.Invoke(this);
    }
}

[GameCommandSerializationInfo("PlayerDeath")]
public record PlayerDeath : PlayerCommand, IMakesTrackAct
{
    protected override void ExecuteCommand()
    {
        Events.Commands.CommandExecuted?.Invoke(this);
    }
}