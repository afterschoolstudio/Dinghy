using System.Collections;
using Arch.CommandBuffer;
using Arch.Core;
using Arch.Core.Extensions;
using Dinghy.Core;

namespace Dinghy.Sandbox.Demos.dungeon;

public static class LogicEvents
{
    public class EventInfo
    {
        public int LogicEventID;
        public Depot.Generated.dungeon.keywords.triggerProps.phase_ENUM Phase;
        public bool CancelBaseElement = false;
    }
    //we assume the null logic data is a player action
    public record LogicData(int cardID);
    public record struct LogicEvent(
        EventInfo info,
        Action<bool> completionCallback,
        Depot.Generated.dungeon.logicTriggers.logicTriggersLine logicEvent,
        LogicData? data,
        bool cancelled = false,
        bool dirty = false);
}

public static class LogicExtentions
{
    public static void Emit(this Depot.Generated.dungeon.logicTriggers.logicTriggersLine line, LogicEvents.LogicData? data = null, Action executeMain = null, Action finalCompletion = null, Action cancelled = null)
    {
        Console.WriteLine("emitting " + line.ID);
        var info = new LogicEvents.EventInfo()
        {
            Phase = Depot.Generated.dungeon.keywords.triggerProps.phase_ENUM.pre,
            LogicEventID = Dungeon.LogicStackID
        };
        //spawn the pre event
        Engine.ECSWorld.Create(new LogicEvents.LogicEvent(info,(success) => {
            if(success)
            {
                //call the completion event for the main event (this actually does the work of drawing/discard/etc.)
                executeMain?.Invoke();

                //spawn the post event - success doesn't matter here because the main body always executes
                var info = new LogicEvents.EventInfo()
                {
                    Phase = Depot.Generated.dungeon.keywords.triggerProps.phase_ENUM.post,
                    LogicEventID = Dungeon.LogicStackID
                };
                Engine.ECSWorld.Create(new LogicEvents.LogicEvent(info,(success) => {
                    finalCompletion?.Invoke();
                },line,data));
                Dungeon.LogicStackID++;
            }
            else
            {
                cancelled?.Invoke();
                finalCompletion?.Invoke();
            }
        },line,data));
        Dungeon.LogicStackID++;
    }
}

public partial class Systems
{
    //THIS NEEDS TO BASICALLY BE A STATE MACHINE
    public class GameLogicSystem : DSystem, IUpdateSystem
    {
        QueryDescription trackCards = new QueryDescription().WithAll<Track.TrackComponent>();
        QueryDescription allEvents = new QueryDescription().WithAll<LogicEvents.LogicEvent>();
        
        int nextLogicEventIndex = 0;
        int nextExecutionStackID = 0;

        public record TriggeredKeyword(
            DeckCard c,
            int stackExecutionID,
            int logicEventID,
            LogicEvents.LogicData data,
            Depot.Generated.dungeon.keywords.keywordsLine triggeringKeyword,
            Depot.Generated.dungeon.logicTriggers.logicTriggersLine triggeringLogic);
        List<TriggeredKeyword> triggered = new List<TriggeredKeyword>();
        List<TriggeredKeyword> lastTriggeredKeywords = new List<TriggeredKeyword>();
        public void Update(double dt)
        {
            triggered.Clear();
            Engine.ECSWorld.Query(in allEvents, (Arch.Core.Entity logicEntity, ref LogicEvents.LogicEvent e) =>
            {
                if(e.info.LogicEventID == nextLogicEventIndex)
                {
                    var eventInfo = e.info;
                    var logicEventID = e.info.LogicEventID;
                    var activeData = e.data;
                    var logicEvent = e.logicEvent;

                    bool hadValidExecution = false;
                    Engine.ECSWorld.Query(in trackCards, (Arch.Core.Entity trackEntity, ref Track.TrackComponent t) =>
                    {
                        foreach (var trackCardKeyword in Dungeon.AllCards[t.cardID].Keywords)
                        {
                            if (trackCardKeyword.trigger.trigger == logicEvent && trackCardKeyword.trigger.phase == eventInfo.Phase)
                            {
                                if(ValidateTriggerAdd(Dungeon.AllCards[t.cardID],trackCardKeyword,logicEvent,activeData))
                                {
                                    hadValidExecution = true;
                                    triggered.Add(new TriggeredKeyword(Dungeon.AllCards[t.cardID],nextExecutionStackID,logicEventID,activeData,trackCardKeyword,logicEvent));
                                    //NOTE: a definite runtime FIXME: here is that we are FIFO for exection and not depth-first
                                    nextExecutionStackID++;
                                    // Keywords.Trigger(Dungeon.AllCards[t.cardID],stackID,activeData,trackCardKeyword,logicEvent,KeywordTriggerComplete);
                                }
                            }
                        }
                    });

                    if(!hadValidExecution)
                    {
                        e.dirty = true;
                        nextLogicEventIndex++;
                    }

                }
            });

            if(triggered.Any())
            {
                lastTriggeredKeywords = new List<TriggeredKeyword>(triggered);
                Coroutines.Start(TriggerSequence(triggered),SequenceComplete);
            }

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

        public bool ValidateTriggerAdd(
            DeckCard triggeringCard,
            Depot.Generated.dungeon.keywords.keywordsLine triggeringKeyword, 
            Depot.Generated.dungeon.logicTriggers.logicTriggersLine triggeringLogic,
            LogicEvents.LogicData? data)
        {
            return triggeringKeyword.trigger.target.ToString() switch 
            {
                "self" => triggeringCard.ID == data.cardID,
                "any" => true,
                _ => false
            };
        }

        IEnumerator TriggerSequence(List<TriggeredKeyword> triggeredKeywords)
        {
            foreach (var k in triggeredKeywords)
            {
                yield return Keywords.Trigger(k.c,k.logicEventID,k.stackExecutionID,k.data,k.triggeringKeyword,k.triggeringLogic);
            }
        }

        void SequenceComplete()
        {
            Action<bool> eventCallback = null;
            var logicId = lastTriggeredKeywords.First().stackExecutionID;
            Engine.ECSWorld.Query(in allEvents, (Arch.Core.Entity logicEntity, ref LogicEvents.LogicEvent e) =>
            {
                if(e.info.LogicEventID == logicId)
                {
                    eventCallback = e.completionCallback;
                    e.dirty = true;
                }
            });
            bool cancelled = lastTriggeredKeywords.Select(x => Keywords.KeywordCancelsMain(x.triggeringKeyword)).Where(x => x == true).Any();
            eventCallback?.Invoke(cancelled);
            lastTriggeredKeywords.Clear();
            nextLogicEventIndex++;
        }
    }
}