using System.Collections;
using System.Reflection;
using Arch.CommandBuffer;
using Arch.Core;
using Arch.Core.Extensions;
using Dinghy.Core;

namespace Dinghy.Sandbox.Demos.dungeon;

public static class Logic
{
    public class LogicBindingAttribute : System.Attribute
    {
        public string LogicID { get; protected set; }
        public LogicBindingAttribute(string logicID)
        {
            LogicID = logicID;
        }
    }

    public static Dictionary<string, MethodInfo> LogicBindingDict = new Dictionary<string, MethodInfo>();
    public static void InitBindings()
    {
        // Get all methods in the current class
        foreach (var method in typeof(Logic).GetMethods(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance))
        {
            // Check if the method has the KeywordBinding attribute
            var attribute = method.GetCustomAttribute<LogicBindingAttribute>();
            if (attribute != null && method.IsStatic && method.ReturnType == typeof(IEnumerator) && method.GetParameters().Length == 0)
            {
                LogicBindingDict.Add(attribute.LogicID, method);
            }
        }
    }

    public static Systems.Logic.Event Emit(
        this Depot.Generated.dungeon.logicTriggers.logicTriggersLine logicEvent,
        Systems.Logic.Event parent = null,
        Systems.Logic.EventData? data = null)
    {
        if (LogicBindingDict.TryGetValue(logicEvent.ID, out MethodInfo methodInfo))
        {
            var main = new Systems.Logic.Event(parent, (IEnumerator)methodInfo.Invoke(null, null));

            //attach pre-events to our event
            foreach (var trackCard in Dungeon.Track.Cards.Where(x => x.Value != null))
            {
                foreach (var keyword in trackCard.Value!.Keywords)
                {
                    if (keyword.trigger.trigger == logicEvent &&
                        keyword.trigger.phase == Depot.Generated.dungeon.keywords.triggerProps.phase_ENUM.pre &&
                        ValidateKeywordTriggerTarget(trackCard.Value!, keyword, data)
                       )
                    {
                        keyword.Emit(main);
                    }
                }

            }

            return main;
        }

        throw new KeyNotFoundException($"No method bound to logic '{logicEvent.ID}'.");

        bool ValidateKeywordTriggerTarget(
            DeckCard triggeringCard,
            Depot.Generated.dungeon.keywords.keywordsLine triggeringKeyword,
            Systems.Logic.EventData? data)
        {
            if (data == null)
            {
                return true;
            }

            return triggeringKeyword.trigger.target.ToString() switch
            {
                "self" => triggeringCard.ID == data.cardID,
                "any" => true,
                _ => false
            };
        }
    }

    [LogicBinding("move")]
    public static IEnumerator Move()
    {
        yield return null;
    }
    [LogicBinding("wait")]
    public static IEnumerator Wait()
    {
        yield return null;
    }
    [LogicBinding("draw")]
    public static IEnumerator Draw()
    {
        yield return null;
    }
    [LogicBinding("discard")]
    public static IEnumerator Discard()
    {
        yield return null;
    }
    [LogicBinding("attackedByPlayer")]
    public static IEnumerator AttackedByPlayer()
    {
        yield return null;
    }
    [LogicBinding("destroyed")]
    public static IEnumerator Destroyed()
    {
        yield return null;
    }
    [LogicBinding("attacking")]
    public static IEnumerator Attacking()
    {
        yield return null;
    }
}
