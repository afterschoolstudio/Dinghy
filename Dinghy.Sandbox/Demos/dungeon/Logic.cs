using System.Collections;
using Arch.CommandBuffer;
using Arch.Core;
using Arch.Core.Extensions;
using Dinghy.Core;

namespace Dinghy.Sandbox.Demos.dungeon;

public static class LogicExtensions
{
    public static Systems.Logic.Event Emit(
        this Depot.Generated.dungeon.logicTriggers.logicTriggersLine logicEvent,
        Systems.Logic.Event parentEvent = null,
        Systems.Logic.EventData? data = null)
    {
        var mainEvent = new Systems.Logic.Event(parentEvent,
            logicEvent == Depot.Generated.dungeon.logicTriggers.move ? Move :
            logicEvent == Depot.Generated.dungeon.logicTriggers.wait ? Wait :
            logicEvent == Depot.Generated.dungeon.logicTriggers.draw ? Draw :
            logicEvent == Depot.Generated.dungeon.logicTriggers.discard ? Discard :
            logicEvent == Depot.Generated.dungeon.logicTriggers.attackedByPlayer ? AttackedByPlayer :
            logicEvent == Depot.Generated.dungeon.logicTriggers.destroyed ? Destroyed :
            logicEvent == Depot.Generated.dungeon.logicTriggers.attacking ? Attacking :
            null);

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
                    keyword.Emit(mainEvent);
                }
            }

        }

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

        return mainEvent;

        IEnumerator Move()
        {
            yield return null;
        }

        IEnumerator Wait()
        {
            yield return null;
        }

        IEnumerator Draw()
        {
            yield return null;
        }

        IEnumerator Discard()
        {
            yield return null;
        }

        IEnumerator AttackedByPlayer()
        {
            yield return null;
        }

        IEnumerator Destroyed()
        {
            yield return null;
        }

        IEnumerator Attacking()
        {
            yield return null;
        }
    }
}