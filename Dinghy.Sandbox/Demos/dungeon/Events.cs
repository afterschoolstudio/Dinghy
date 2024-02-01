using static Dinghy.Sandbox.Demos.dungeon.DataTypes;

namespace Dinghy.Sandbox.Demos.dungeon;

public static class Events
{
    public record struct EventMeta(string eventType, int index, bool processed = false, bool dirty = false);

    public abstract record Event();
    public record MouseEnemyCollision(EnemyComponent e) : Event;
    public record ButtonClicked() : Event;
    

    public static int EventCounter = 0;
    public static void Raise<T>(T e) where T : Event
    {
        Engine.ECSWorld.Create(
            new EventMeta(e.GetType().ToString(),EventCounter),
            e);
        EventCounter++;
    }
}