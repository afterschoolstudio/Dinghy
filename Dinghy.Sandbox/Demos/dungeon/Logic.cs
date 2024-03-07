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
            if (attribute != null && method.IsStatic && method.ReturnType == typeof(IEnumerator))
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
            var main = new Systems.Logic.Event(parent, (IEnumerator)methodInfo.Invoke(null, [data]));

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
                        keyword.Emit(main,data);
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
    public static IEnumerator Move(Systems.Logic.EventData? d)
    {
        yield return null;
    }
    [LogicBinding("wait")]
    public static IEnumerator Wait(Systems.Logic.EventData? d)
    {
        yield return null;
    }
    [LogicBinding("draw")]
    public static IEnumerator Draw(Systems.Logic.EventData? d)
    {
        yield return null;
    }
    [LogicBinding("discard")]
    public static IEnumerator Discard(Systems.Logic.EventData? d)
    {
        yield return null;
    }
    [LogicBinding("attackedByPlayer")]
    public static IEnumerator AttackedByPlayer(Systems.Logic.EventData? d)
    {
        var card = Dungeon.AllCards[d.cardID];
        yield return Dungeon.Effects.Shake(card);
        card.Health -= 1;
        yield return null;
    }
    [LogicBinding("destroyed")]
    public static IEnumerator Destroyed(Systems.Logic.EventData? d)
    {
        c.Entity.ECSEntity.Remove<TrackComponent>();
        Cards[Cards.First(x => x.Value == c).Key] = null;
        c.Entity.Active = false;
        Dungeon.Graveyard.Add(c);

        //note right now this assumes one death
        //should instead do this after multiple deaths processed
        Dungeon.Track.Act(() => {
            FillEmptyTrackCardSpaces();
            Dungeon.Deck.Draw();
            onComplete?.Invoke();
        });
        yield return null;
    }
    [LogicBinding("attacking")]
    public static IEnumerator Attacking(Systems.Logic.EventData? d)
    {
        yield return null;
    }
}
