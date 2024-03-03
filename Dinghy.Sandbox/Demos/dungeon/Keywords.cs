using System.Collections;
using System.Runtime.CompilerServices;

namespace Dinghy.Sandbox.Demos.dungeon;

public static class Keywords
{
    //bool dictates if the calling event should be cancelled after the effect is invoked
    public static IEnumerator Trigger(
        DeckCard triggeringCard,
        int logicEventID,
        int stackExecutionID,
        LogicEvents.LogicData? data, 
        Depot.Generated.dungeon.keywords.keywordsLine triggeringKeyword, 
        Depot.Generated.dungeon.logicTriggers.logicTriggersLine triggeringLogic 
    )
    {
        //this could maybe be linked scripts

        //should potentially make this spawn other logic events?
        //things like counterattack shouldn't happen directly, instead they need to happen after an attack is successful
        if (triggeringKeyword == Depot.Generated.dungeon.keywords.rejuvenate)
        {
            Dungeon.Player.Health += 1;
        }
        else if (triggeringKeyword == Depot.Generated.dungeon.keywords.vengeance)
        {
            Dungeon.Track.RemoveTrackCard(Dungeon.AllCards[data.cardID]);
            Dungeon.Deck.Cards.Insert(0, Dungeon.AllCards[data.cardID]);
        }
        else if (triggeringKeyword == Depot.Generated.dungeon.keywords.cycles)
        {
            Dungeon.Track.RemoveTrackCard(Dungeon.AllCards[data.cardID]);
            Dungeon.Deck.Cards.Add(Dungeon.AllCards[data.cardID]);
        }
        else if (triggeringKeyword == Depot.Generated.dungeon.keywords.exit)
        {
            Dungeon.NextDungeonRoom();
        }
        else
        {
            Console.WriteLine("unhandled keyword: " + triggeringKeyword.ID);
        }
        yield return null;
    }

    public static bool KeywordCancelsMain(Depot.Generated.dungeon.keywords.keywordsLine keyword)
    {
        if(keyword == Depot.Generated.dungeon.keywords.obstacle)
        {
            return !Dungeon.Track.Cards.Any(x =>
                    x.Value != null && !x.Value.Keywords.Contains(Depot.Generated.dungeon.keywords.obstacle));
        }
        return false;
    }
}