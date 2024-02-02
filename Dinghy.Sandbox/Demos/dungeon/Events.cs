using static Dinghy.Sandbox.Demos.dungeon.DataTypes;

namespace Dinghy.Sandbox.Demos.dungeon;

public static class Events
{
    public record struct EventMeta(string eventType, int index, bool dirty = false);

    public abstract record Event();

    public abstract record ActionEvent() : Event;
    public record ButtonClicked() : ActionEvent;

    public enum CollisionState
    {
        Starting,
        Continuing,
        Ending
    }

    public record struct CollisionMeta(int hash, CollisionState state = CollisionState.Starting);

    public record CollisionEvent : Event;

    public record MouseEnemyCollision(EnemyComponent e) : CollisionEvent;
    

    public static int EventCounter = 0;
    public static void Raise<T>(T e) where T : ActionEvent
    {
        Engine.ECSWorld.Create(
            new EventMeta(e.GetType().ToString(),EventCounter),
            e);
        EventCounter++;
    }

    public static void Raise<T>(T e, int hash) where T : CollisionEvent
    {
        Engine.ECSWorld.Create(
            new EventMeta(e.GetType().ToString(),EventCounter),
            new CollisionMeta(hash),
            e);
        EventCounter++;
    }
}