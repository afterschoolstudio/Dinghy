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
        
        public static Event RootEvent = new(null,null);
        private static int EventCounter = 0;
        public class Event
        {
            public string Name { get; protected set; }
            public int Index = 0;
            public List<Event> ChildEvents { get; protected set; } = new List<Event>();
            public bool Executed;
            public bool Complete;
            public bool SpawnedPostEvents;
            public IEnumerator ExecutionRoutine { get; protected set; }
            private Action<Event> PostExecution;
            public Action OnComplete;
            public Event(string name, IEnumerator executionRoutine, Action<Event> postExecution = null, Action onComplete = null)
            {
                //NOTE: In onComplete you should not add new nodes to this, they will not be addressed
                Index = EventCounter;
                Name = $"{name}_{Index}";
                EventCounter++;
                ExecutionRoutine = executionRoutine;
                PostExecution = postExecution;
                OnComplete = onComplete;
            }

            public void SpawnPostEvents()
            {
                PostExecution?.Invoke(this);
            }
        }

        public static void EmitDeathReap()
        {
            var destroyedNumber = 0;
            dungeon.Logic.MetaEvents.DeathReap.Emit(RootEvent, postExecution: e =>
            {
                destroyedNumber = 0;
                foreach (var c in Dungeon.Track.Cards.Where(x => x.Value != null && x.Value.Health <= 0))
                {
                    destroyedNumber++;
                    Depot.Generated.dungeon.logicTriggers.destroyed.Emit(e, new EventData(cardID: c.Value.ID));
                }
            }, onComplete: () =>
            {
                if (destroyedNumber > 0)
                {
                    dungeon.Logic.MetaEvents.DrawingMultipleCards.Emit(RootEvent, postExecution: e =>
                    {
                        for (int i = 0; i < destroyedNumber; i++)
                        {
                            Depot.Generated.dungeon.logicTriggers.draw.Emit(e);
                        }
                    }, onComplete: () =>
                    {
                        Dungeon.Track.MoveTrackCardsToLatestTrackPositions();
                        if (Dungeon.Player.Health <= 0)
                        {
                            Dungeon.Player.Kill();
                        }
                    });
                }
                else
                {
                    if (Dungeon.Player.Health <= 0)
                    {
                        Dungeon.Player.Kill();
                    }
                }
            });
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
    public static IEnumerator LogicProcess()
    {
        while(true)
        {
            lastTickNodeGraphDiagram = currentNodeGraphDiagram;
            currentNodeGraphDiagram = WriteNodeGraph();
            //prune the logic tree
            Logic.RootEvent.ChildEvents.RemoveAll(x => x.Complete);

            //reap dead cards
            if (Logic.RootEvent.ChildEvents.Any())
            {
                deathReapEventCheck = Logic.RootEvent.ChildEvents.FirstOrDefault(x => x.Index > lastDeathReapIndex);
                if(deathReapEventCheck != null)
                {
                    lastDeathReapIndex = deathReapEventCheck.Index + 1; //we add one because when we emit outselves that is the new index
                    Logic.EmitDeathReap();
                }
            }
            
            //note that getnextevent also marks nodes complete so it's important that we run it here. complete nodes will get pruned in next loop iteration
            if(Logic.RootEvent.ChildEvents.Any() && !LogicEventExecuting && GetNextEvent(Logic.RootEvent.ChildEvents.First(), out ActiveEvent))
            {
                Coroutines.Start(ActiveEvent.ExecutionRoutine, $"event{ActiveEvent.Index}", () =>
                {
                    ExecutedEvents.Add(ActiveEvent);
                    ActiveEvent.Executed = true;
                    ActiveEvent.SpawnPostEvents();
                    LastExecutedEvent = ActiveEvent;
                    ActiveEvent = null;
                });
            }
            
            yield return Coroutines.WaitForSeconds(1.5f);

        }
        
        bool GetNextEvent(Logic.Event node, out Logic.Event nextEvent)
        {
            nextEvent = null;
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

            // if (!node.SpawnedPostEvents)
            // {
            //     node.SpawnPostEvents();
            //     node.SpawnedPostEvents = true;
            //     return false; //we need to return so that the new children can be picked up (if added)
            // }
            // If this point is reached, all children are executed or complete, so mark this node as complete
            node.OnComplete?.Invoke();
            node.Complete = true;

            // No unexecuted child found and this node is either executed or marked complete, so return null
            return false;
        }
    }

    public static string WriteNodeGraph()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("flowchart TD");
        GetNodeRelations(Logic.RootEvent);
        return sb.ToString();
        
        void GetNodeRelations(Logic.Event e)
        {
            foreach (var c in e.ChildEvents)
            {
                sb.AppendLine($"{e.Index}[{e.Name}]-->{c.Index}[{c.Name}]");
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

