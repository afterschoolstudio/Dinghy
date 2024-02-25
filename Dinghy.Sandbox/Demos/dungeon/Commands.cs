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


[GameCommandSerializationInfo("KillPlayer")]
public record KillPlayer : GameCommand
{
    protected override void ExecuteCommand()
    {
        Events.Commands.CommandExecuted?.Invoke(this);
    }
}


public interface ITriggersLogic
{
    public GameLogicEvent CreateLogicEvent();
}

// PLAYERINPUT COMMANDS ARE THINGS A PLAYER CAN DIRECTLY "DO" WITH THE GAME INPUT
// THIS IS NOT RELATED TO LOGIC (THOUGH LOGIC CAN BE AN OUTCOME)
public abstract record PlayerInputCommand : GameCommand{}
public static class PlayerInputCommands
{
    [GameCommandSerializationInfo("PlayerMove")]
    public record Move : PlayerInputCommand, ITriggersLogic
    {
        protected override void ExecuteCommand()
        {
            Dungeon.Player.Move();
            Events.Commands.CommandExecuted?.Invoke(this);
        }

        public GameLogicEvent CreateLogicEvent() => new LogicEvents.Move();
    }

    [GameCommandSerializationInfo("PlayerWait")]
    public record Wait : PlayerInputCommand, ITriggersLogic
    {
        public GameLogicEvent CreateLogicEvent() => new LogicEvents.Wait();
        protected override void ExecuteCommand()
        {
            Dungeon.Player.Wait();
            Events.Commands.CommandExecuted?.Invoke(this);
        }
    }

    [GameCommandSerializationInfo("PlayerAttackTrackCards")]
    public record Attack(DeckCard card) : PlayerInputCommand, ITriggersLogic
    {
        public GameLogicEvent CreateLogicEvent() => new LogicEvents.Attack(card.ID);
        protected override void ExecuteCommand()
        {
            Dungeon.Track.DamageTrackCard(card);
            Events.Commands.CommandExecuted?.Invoke(this);
        }
    }
}
