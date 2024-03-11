using System.Reflection;
using System.Collections;
using System.Text;
using Arch.CommandBuffer;
using Arch.Core;
using Arch.Core.Extensions;
using Dinghy.Core;
using Dinghy.Internal.Sokol;
using Volatile;

namespace Dinghy.Sandbox.Demos.dungeon;

public partial class Systems
{
    public static void Init()
    {
        Coroutines.Start(LogicProcess(),"main logic process");
        // Engine.RegisterSystem(new CollisionSystem());
        // Engine.RegisterSystem(new MouseEnemyCollisonHandler());
    }

    public static class Logic
    {
        public record EventData(int cardID);
        
        public static Event RootEvent = new("root",null,null); //root is ID 0
        static int EventCounter = 1;
        public static int GetCurrentEventCounter() => EventCounter;

        public static (Event self, Event parent)? FindEventWithID(int id)
        {
            var result = FindInNode(RootEvent);
            if (result == null)
            {
                Console.WriteLine("Unable to find node with id: " + id);
            }
            return result;
            
            //

            (Event,Event)? FindInNode(Logic.Event e)
            {
                if (e.Index == id)
                {
                    return (e,RootEvent); // In case the root itself is the event we're looking for
                }
        
                foreach (var c in e.ChildEvents)
                {
                    if (c.Index == id)
                    {
                        return (c,e); // Found the event, return it
                    }
                    (Event,Event)? found = FindInNode(c); // Continue searching in the child
                    if (found != null)
                    {
                        return found; // If found in a deeper level, return the found event
                    }
                }
                return null; // If not found in this node or its children, return null
            }
        }
        
        
        public class Event
        {
            public string Name { get; protected set; }
            public int Index = 0;
            public List<Event> ChildEvents { get; protected set; } = new List<Event>();
            public bool Executed;
            public bool Complete;
            public bool Cancelled;
            public IEnumerator ExecutionRoutine { get; protected set; }
            private Action<Event> PostExecution;
            public Action OnComplete;
            public EventData? Data { get; protected set; }
            public Event(string name, EventData? data, IEnumerator executionRoutine, Action<Event> postExecution = null, Action onComplete = null)
            {
                //NOTE: In onComplete you should not add new nodes to this, they will not be addressed
                Index = EventCounter;
                Name = $"{name}_{Index}";
                EventCounter++;
                ExecutionRoutine = executionRoutine;
                PostExecution = postExecution;
                OnComplete = onComplete;
                Data = data;
            }
            
            public void SpawnPostEvents()
            {
                PostExecution?.Invoke(this);
            }

            public string GetDebugName()
            {
                var activeNodeString = ActiveEvent == this ? ":::activeEvent" : "";
                return @$"{Index}[""`{Name}
complete:{Complete}
cancelled:{Cancelled}
executed:{Executed}`""]{activeNodeString}";
            }
        }
    }

    public static List<Logic.Event> ExecutedEvents = new ();
    static bool LogicEventExecuting => ActiveEvent != null;
    public static Logic.Event? ActiveEvent;
    public static Logic.Event? LastExecutedEvent;

    private static int lastDeathReapIndex = -1;
    static Logic.Event deathReapEventCheck;
    private static string lastTickNodeGraphDiagram = "";
    private static string currentNodeGraphDiagram = "";
    private static TimeSince writeTick; 
    public static IEnumerator LogicProcess()
    {
        while(true)
        {
            //prune the logic tree
            Logic.RootEvent.ChildEvents.RemoveAll(x => x.Complete);

            //reap dead cards
            if (Logic.RootEvent.ChildEvents.Any())
            {
                deathReapEventCheck = Logic.RootEvent.ChildEvents.FirstOrDefault(x => x.Index > lastDeathReapIndex);
                if(deathReapEventCheck != null)
                {
                    lastDeathReapIndex = deathReapEventCheck.Index + 1; //we add one because when we emit outselves that is the new index
                    
                    #region Emit Death Reap
                    dungeon.Logic.MetaEvents.DeathReap.Emit(Logic.RootEvent, postExecution: e =>
                    {
                        foreach (var c in Dungeon.Track.Cards.Where(x => x.Value != null && x.Value.Health <= 0))
                        {
                            Depot.Generated.dungeon.logicTriggers.destroyed.Emit(e,
                                new Logic.EventData(cardID: c.Value.ID));
                        }
                    }, onComplete: () =>
                    {
                        if (Dungeon.Track.HasEmptyPositions(out var pos))
                        {
                            dungeon.Logic.MetaEvents.DrawingMultipleCards.Emit(Logic.RootEvent, postExecution: e =>
                            {
                                for (int i = 0; i < pos.Count; i++)
                                {
                                    Depot.Generated.dungeon.logicTriggers.draw.Emit(e);
                                }
                            }, onComplete: () =>
                            {
                                if (Dungeon.Player.Health <= 0)
                                {
                                    Dungeon.Player.Kill();
                                }
                                else
                                {
                                    dungeon.Logic.MetaEvents.UpdateCardPositions.Emit(Logic.RootEvent);
                                }
                            });
                        }
                        else if (Dungeon.Player.Health <= 0)
                        {
                            Dungeon.Player.Kill();
                        }
                    });
                    #endregion
                }
            }
            
            //note that getnextevent also marks nodes complete so it's important that we run it here. complete nodes will get pruned in next loop iteration
            if(Logic.RootEvent.ChildEvents.Any() && !LogicEventExecuting && GetNextEvent(Logic.RootEvent.ChildEvents.First(), out ActiveEvent))
            {
                UpdateDebugGraph();
                
                Coroutines.Start(ActiveEvent.ExecutionRoutine, $"event_{ActiveEvent.Name}", () =>
                {
                    ExecutedEvents.Add(ActiveEvent);
                    ActiveEvent.Executed = true;
                    UpdateDebugGraph();

                    if (!ActiveEvent.Cancelled)
                    {
                        //we only spawn post events if our main event was a success
                        ActiveEvent.SpawnPostEvents();
                    }
                    LastExecutedEvent = ActiveEvent;
                    ActiveEvent = null;
                    
                    UpdateDebugGraph();
                });
            }

            yield return null;
        }
        
        bool GetNextEvent(Logic.Event node, out Logic.Event nextEvent)
        {
            nextEvent = null;

            if (!node.Complete && node.Cancelled)
            {
                //if we happened to cancel this elsewhere we mark this as complete and invoke complete
                //it does not get executed/postexecution called
                node.OnComplete?.Invoke();
                node.Complete = true;
                return false;
            }
            
            if (node == null || node.Complete)
            {
                return false; // Node is either null or fully processed, so return null.
            }

            if (!node.Executed)
            {
                // This checks if the node itself is the next unexecuted event,
                // but doesn't immediately mark it as executed; that should be done after the actual execution logic.
                nextEvent = node;
                return true;
            }

            foreach (var child in node.ChildEvents)
            {
                // Recursively search for an unexecuted event in the children
                if (GetNextEvent(child,out var n))
                {
                    nextEvent = n; // Found an unexecuted event in the children
                    return true;
                }
            }

            // If this point is reached, all children are executed or complete, so mark this node as complete
            // nodes can also explicitly be marked as non-Compleatable in order for exeuction to basically keep trying at that node position
            // this is useful for waiting on animation type stuff
            if (!node.Complete)
            {
                node.OnComplete?.Invoke();
                node.Complete = true;
            }

            // No unexecuted child found and this node is either executed or marked complete, so return null
            return false;
        }
    }

    public static void UpdateDebugGraph()
    {
        lastTickNodeGraphDiagram = currentNodeGraphDiagram;
        currentNodeGraphDiagram = WriteNodeGraph();
        File.WriteAllText("lastTick.md",lastTickNodeGraphDiagram);
        File.WriteAllText("thistick.md",currentNodeGraphDiagram);
    }

    public static string WriteNodeGraph()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("```mermaid");
        sb.AppendLine("flowchart TD");
        sb.AppendLine("classDef activeEvent fill:#f96");
        GetNodeRelations(Logic.RootEvent);
        sb.AppendLine("```");
        return sb.ToString();
        
        void GetNodeRelations(Logic.Event e)
        {
            sb.AppendLine(e.GetDebugName());
            foreach (var c in e.ChildEvents)
            {
                sb.AppendLine($"{e.Index}-->{c.Index}");
                GetNodeRelations(c);
            }
        }
        /*
flowchart TD
    A[Start] --> B{Is it?}
    B -- Yes --> C[OK]
    C --> D[Rethink]
    D --> B
    B -- No ----> E[End]
         */

    }
}

