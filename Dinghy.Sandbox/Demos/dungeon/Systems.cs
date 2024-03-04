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
        Engine.RegisterSystem(new GameLogicSystem());
        
        Coroutines.Start(LogicProcess());
        // Engine.RegisterSystem(new CollisionSystem());
        // Engine.RegisterSystem(new MouseEnemyCollisonHandler());
    }

    public static class Logic
    {
        public static Event RootEvent = new(null); 
        public class Event
        {
            public Event ParentEvent { get; protected set; }
            public List<Event> ChildEvents { get; protected set; } = new List<Event>();
            public bool Executed;
            public Event(Event parentEvent)
            {
                ParentEvent = parentEvent;
                ParentEvent.ChildEvents.Add(this);
            }

            public void Execute()
            {
                Coroutines.Start(Executer(), () =>
                {
                    var nextChild = ChildEvents.FirstOrDefault(x => !x.Executed);
                    if (nextChild != null)
                    {
                        nextChild.Execute();
                    }
                    else if
                    {
                        
                    }
                    foreach (var child in ChildEvents)
                    {
                         child.Execute();
                    }
                });
            }

            public IEnumerator Executer()
            {
                //TODO: IMPLEMENT
                yield return null;
            }
        }
    }

    public static List<Logic.Event> ExecutedEvents = new List<Logic.Event>();
    static bool LogicEventExecuting => ActiveEvent != null;
    public static Logic.Event? LastExecutedEvent;
    public static Logic.Event? ActiveEvent;
    public static IEnumerator LogicProcess()
    {
        while(true)
        {
            if (Logic.RootEvent.ChildEvents.Count <= 0)
            {
                yield return Coroutines.WaitForSeconds(1.5f);
                continue;
            }
            
            if(!LogicEventExecuting)
            {
                ActiveEvent = GetNextEvent();
                Coroutines.Start(ActiveEvent.Executer(), () =>
                {
                    ExecutedEvents.Add(ActiveEvent);
                    ActiveEvent.Executed = true;
                    //prune the event tree
                    Logic.RootEvent.ChildEvents.RemoveAll(x => x.Executed);
                    LastExecutedEvent = ActiveEvent;
                    ActiveEvent = null;
                });
            }
        }

        Logic.Event GetNextEvent()
        {
            return GetNextValidNodeFromNode(LastExecutedEvent ?? Logic.RootEvent);

            Logic.Event GetNextValidNodeFromNode(Logic.Event start)
            {
                //depth first to first valid child
                var validChildEvent = start.ChildEvents.FirstOrDefault(x => !x.Executed);
                if (validChildEvent != null)
                {
                    return GetNextValidNodeFromNode(validChildEvent);
                }
                //then self
                if (start == LastExecutedEvent)
                {
                    LastExecutedEvent.ParentEvent
                }
                return start;
                
                //then to sibling
                var validSiblingEvent = start.ParentEvent.ChildEvents.FirstOrDefault(x => !x.Executed);
                if (validSiblingEvent != null)
                {
                    return GetNextValidNodeFromNode(validSiblingEvent);
                }
                
                //all the way down, then sibling, then parent
                //TODO: IMPLEMENT
                var startNode = start;
                var targetNode;
                while
            }
        }
    }
}

