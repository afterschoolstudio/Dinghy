using System.Runtime.CompilerServices;

namespace Dinghy.Sandbox.Demos.dungeon;

public static class Keywords
{
    //bool dictates if the calling event should be cancelled after the effect is invoked
    public static void Trigger(
        DeckCard triggeringCard,
        int stackID,
        LogicEvents.LogicData? data, 
        Depot.Generated.dungeon.keywords.keywordsLine triggeringKeyword, 
        Depot.Generated.dungeon.logicTriggers.logicTriggersLine triggeringLogic, 
        //success,stackID
        Action<bool,int> completionCallback
    )
    {
        bool eventCancelled = false;
        if(!ValidateLogicExecution(triggeringCard,triggeringKeyword,triggeringLogic,data))
        {
            eventCancelled = true;
            completionCallback?.Invoke(!eventCancelled,stackID);
            return;
        }

        //by the time we pass this we can assume the keywords target the requisite cards in the data

        //this could maybe be linked scripts

        //should potentially make this spawn other logic events?
        //things like counterattack shouldn't happen directly, instead they need to happen after an attack is successful
        switch (triggeringKeyword)
        {
            case Depot.Generated.dungeon.keywords.rejuvenate:
                Dungeon.Player.Health += 1;
                break;
            case Depot.Generated.dungeon.keywords.vengeance:
                var card = Dungeon.AllCards[data.cardID];
                Dungeon.Track.RemoveTrackCard(card);
                Dungeon.Deck.Cards.Insert(0,card);
                eventCancelled = true;
                break;
            case Depot.Generated.dungeon.keywords.cycles:
                var card = Dungeon.AllCards[data.cardID];
                Dungeon.Track.RemoveTrackCard(card);
                Dungeon.Deck.Cards.Add(card);
                eventCancelled = true;
                break;
            case Depot.Generated.dungeon.keywords.obstacle:
                if(!Dungeon.Track.Cards.Any(x => x.Value != null && !x.Value.Keywords.Any(z => z.Name == "obstacle")))
                {
                    eventCancelled = true;
                }
                break;
            case Depot.Generated.dungeon.keywords.exit:
                Dungeon.NextDungeonRoom();
                eventCancelled = true;
                break;
            default:
                Console.WriteLine("unhandled keyword: " + triggeringKeyword.ID);
                break;
        }

        completionCallback?.Invoke(!eventCancelled,stackID);
    }

    
    public static bool ValidateLogicExecution(
        DeckCard triggeringCard,
        Depot.Generated.dungeon.keywords.keywordsLine triggeringKeyword, 
        Depot.Generated.dungeon.logicTriggers.logicTriggersLine triggeringLogic,
        LogicData? data)
    {
        if(!data.HasValue){return true;} //we assume null right now is just a player action with no data associated, and hence is valid
        
        var keywordLogicBinding = triggeringKeyword.triggers.FirstOrDefault(x => x.trigger = triggeringLogic);
        if(keywordLogicBinding == null)
        {
            Console.WriteLine("BAD: LOGIC BINDING KEYWORD MISMATCH");
            return false;
        }

        return keywordLogicBinding.target switch 
        {
            "self" => triggeringCard.ID == data.Value.cardID,
            "any" => true,
            _ => false
        };
    }
}