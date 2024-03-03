using Arch.CommandBuffer;
using Arch.Core;
using Arch.Core.Extensions;

namespace Dinghy.Sandbox.Demos.dungeon;

public static class LogicEvents
{
    //we assume the null logic data is a player action
    public record LogicData(int cardID);
    public record struct LogicEvent(
        int stackID,
        Action<bool> completionCallback,
        Depot.Generated.dungeon.logicTriggers.logicTriggersLine logicEvent,
        LogicData? data,
        bool cancelled = false,
        bool dirty = false);
    public static void Emit(Depot.Generated.dungeon.logicTriggers.logicTriggersLine logic, LogicData? data = null, Action<bool> onComplete = null)
    {
        Engine.ECSWorld.Create(new LogicEvent(Dungeon.LogicStackID,onComplete,logic,data));
        Dungeon.LogicStackID++;
    }
}

public static class LogicExtentions
{
    public static void Emit(this Depot.Generated.dungeon.logicTriggers.logicTriggersLine line, LogicEvents.LogicData? data = null, Action<bool> onComplete = null)
    {
        LogicEvents.Emit(line,data,onComplete);
    }
}

public partial class Systems
{
    //THIS NEEDS TO BASICALLY BE A STATE MACHINE
    public class GameLogicSystem : DSystem, IUpdateSystem
    {
        QueryDescription trackCards = new QueryDescription().WithAll<Track.TrackComponent>();
        QueryDescription allEvents = new QueryDescription().WithAll<LogicEvents.LogicEvent>();
        
        
        // QueryDescription discard = new QueryDescription().WithAll<LogicEvents.Discard, LogicEvents.LogicEvent>();
        // QueryDescription move = new QueryDescription().WithAll<LogicEvents.Move, LogicEvents.LogicEvent>();
        // QueryDescription wait = new QueryDescription().WithAll<LogicEvents.Wait, LogicEvents.LogicEvent>();
        // QueryDescription destroyed = new QueryDescription().WithAll<LogicEvents.Destroyed, LogicEvents.LogicEvent>();
        // QueryDescription playerAttacked = new QueryDescription().WithAll<LogicEvents.AttackTrackCard, LogicEvents.LogicEvent>();
        // QueryDescription draw = new QueryDescription().WithAll<LogicEvents.Draw, LogicEvents.LogicEvent>();
        // QueryDescription trackCardAttacked = new QueryDescription().WithAll<LogicEvents.TrackCardAttackPlayer, LogicEvents.LogicEvent>();
        
        int nextLogicEventIndex = 0;
        public void Update(double dt)
        {
            Engine.ECSWorld.Query(in allEvents, (Arch.Core.Entity logicEntity, ref LogicEvents.LogicEvent e) =>
            {
                if(e.stackID == nextLogicEventIndex)
                {
                    var stackID = e.stackID;
                    var activeData = e.data;
                    var logicEvent = e.logicEvent;

                    Engine.ECSWorld.Query(in trackCards, (Arch.Core.Entity trackEntity, ref Track.TrackComponent t) =>
                    {
                        foreach (var trackCardKeyword in Dungeon.AllCards[t.cardID].Keywords)
                        {
                            if (trackCardKeyword.triggers.Select(x => x.trigger).Contains(logicEvent))
                            {
                                Keywords.Trigger(Dungeon.AllCards[t.cardID],stackID,activeData,trackCardKeyword,logicEvent,KeywordTriggerComplete);
                            }
                        }
                    });

                }
            });

            CommandBuffer cb = new CommandBuffer(Engine.ECSWorld);
            Engine.ECSWorld.Query(in allEvents, (Arch.Core.Entity e, ref LogicEvents.LogicEvent em) =>
            {
                if (em.dirty)
                {
                    cb.Add(in e, new Destroy());
                }
            });
            cb.Playback();
        }

        void KeywordTriggerComplete(bool cancelEvent, int stackID)
        {
            Action<bool> eventCallback = null;
            Engine.ECSWorld.Query(in allEvents, (Arch.Core.Entity logicEntity, ref LogicEvents.LogicEvent e) =>
            {
                if(e.stackID == stackID)
                {
                    eventCallback = e.completionCallback;
                    e.dirty = true;
                }
            });
            eventCallback?.Invoke(!cancelEvent);
            nextLogicEventIndex++;
        }
    }
}