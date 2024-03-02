using System.Reflection;
using Arch.Core;

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


// PLAYERINPUT COMMANDS ARE THINGS A PLAYER CAN DIRECTLY "DO" WITH THE GAME INPUT
// THIS IS NOT RELATED TO LOGIC (THOUGH LOGIC CAN BE AN OUTCOME)
public abstract record PlayerInputCommand : GameCommand{}
public static class PlayerInputCommands
{
    [GameCommandSerializationInfo("PlayerMove")]
    public record Move : PlayerInputCommand
    {
        protected override void ExecuteCommand()
        {
            Dungeon.Player.Move(() => {
                Events.Commands.CommandExecuted?.Invoke(this);
            });
        }
    }

    [GameCommandSerializationInfo("PlayerWait")]
    public record Wait : PlayerInputCommand
    {
        protected override void ExecuteCommand()
        {
            Dungeon.Player.Wait(() => {
                Events.Commands.CommandExecuted?.Invoke(this);
            });
        }
    }

    [GameCommandSerializationInfo("PlayerAttackTrackCards")]
    public record Attack(List<DeckCard> cards) : PlayerInputCommand
    {
        protected override void ExecuteCommand()
        {
            Dungeon.Track.DamageTrackCards(cards, () => {
                Events.Commands.CommandExecuted?.Invoke(this);
            });
        }
    }
}

