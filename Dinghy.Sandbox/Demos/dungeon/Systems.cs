using System.Reflection;
using System.Collections;
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
        public class Event
        {
            public Event ParentEvent { get; protected set; }
            public List<Event> ChildEvents { get; protected set; } = new List<Event>();
            public bool Executed;
            public bool Complete;
            public IEnumerator ExecutionRoutine { get; protected set; }
            public Event(Event parentEvent, IEnumerator executionRoutine)
            {
                ParentEvent = parentEvent;
                ParentEvent.ChildEvents.Add(this);
                ExecutionRoutine = executionRoutine;
            }
        }
    }

    public static List<Logic.Event> ExecutedEvents = new ();
    static bool LogicEventExecuting => ActiveEvent != null;
    public static Logic.Event? LastExecutedEvent;
    public static Logic.Event? ActiveEvent;
    public static IEnumerator LogicProcess()
    {
        while(true)
        {
            //prune the logic tree
            Logic.RootEvent.ChildEvents.RemoveAll(x => x.Complete);
            
            //do we have any incomplete children
            if(Logic.RootEvent.ChildEvents.Any() && !LogicEventExecuting)
            {
                //TODO: need to check if LastExecutedEvent is logic event and then spawn post-events from this at the parent of LastExecutedEvent
                GetNextEvent(Logic.RootEvent.ChildEvents.First(), out ActiveEvent);
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
            node.Complete = true;

            // No unexecuted child found and this node is either executed or marked complete, so return null
            return false;
        }
    }
}

