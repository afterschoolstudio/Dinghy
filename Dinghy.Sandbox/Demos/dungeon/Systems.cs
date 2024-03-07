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
        Coroutines.Start(LogicProcess());
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
            public int Index = 0;
            public Event ParentEvent { get; protected set; }
            public List<Event> ChildEvents { get; protected set; } = new List<Event>();
            public bool Executed;
            public bool Complete;
            public bool SpawnedPostEvents;
            public IEnumerator ExecutionRoutine { get; protected set; }
            private Action<Event> PostExecution;
            public Action OnComplete;
            public Event(Event parentEvent, IEnumerator executionRoutine, Action<Event> postExecution = null, Action onComplete = null)
            {
                Index = EventCounter;
                EventCounter++;
                ParentEvent = parentEvent;
                ParentEvent.ChildEvents.Add(this);
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
            dungeon.Logic.MetaEvents.DeathReap.Emit(RootEvent, postExecution: e =>
            {
                foreach (var c in Dungeon.Track.Cards.Where(x => x.Value != null && x.Value.Health <= 0))
                {
                    Depot.Generated.dungeon.logicTriggers.destroyed.Emit(e, new EventData(cardID: c.Value.ID));
                }
            });
        }
    }

    public static List<Logic.Event> ExecutedEvents = new ();
    static bool LogicEventExecuting => ActiveEvent != null;
    public static Logic.Event? LastExecutedEvent;
    public static Logic.Event? ActiveEvent;

    private static int lastDeathReapIndex = -1;
    static Logic.Event deathReapEventCheck;
    private static string currentNodeGraphDiagram;
    public static IEnumerator LogicProcess()
    {
        while(true)
        {
            currentNodeGraphDiagram = WriteNodeGraph();
            //prune the logic tree
            Logic.RootEvent.ChildEvents.RemoveAll(x => x.Complete);

            //reap dead cards
            if (Logic.RootEvent.ChildEvents.Any())
            {
                deathReapEventCheck = Logic.RootEvent.ChildEvents.FirstOrDefault(x => x.Index > lastDeathReapIndex);
                if(deathReapEventCheck != null)
                {
                    lastDeathReapIndex = deathReapEventCheck.Index;
                    Logic.EmitDeathReap();
                }
            }
            
            //note that getnextevent also marks nodes complete so it's important that we run it here. complete nodes will get pruned in next loop iteration
            if(Logic.RootEvent.ChildEvents.Any() && !LogicEventExecuting && GetNextEvent(Logic.RootEvent.ChildEvents.First(), out ActiveEvent))
            {
                Coroutines.Start(ActiveEvent.ExecutionRoutine, () =>
                {
                    ExecutedEvents.Add(ActiveEvent);
                    ActiveEvent.Executed = true;
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

            // If this point is reached, all children are executed or complete, so mark this node as complete
            if (!node.SpawnedPostEvents)
            {
                node.SpawnPostEvents();
                node.SpawnedPostEvents = true;
                return false; //we need to return so that the new children can be picked up (if added)
            }
            node.Complete = true;

            // No unexecuted child found and this node is either executed or marked complete, so return null
            return false;
        }
    }

    public static string WriteNodeGraph()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("flowchart TD");
        GetNodeRelations(sb,Logic.RootEvent);
        return sb.ToString();
        
        void GetNodeRelations(Logic.Event e)
        {
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

