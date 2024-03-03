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
        if (triggeringKeyword == Depot.Generated.dungeon.keywords.rejuvenate)
        {
            Dungeon.Player.Health += 1;
        }
        else if (triggeringKeyword == Depot.Generated.dungeon.keywords.vengeance)
        {
            Dungeon.Track.RemoveTrackCard(Dungeon.AllCards[data.cardID]);
            Dungeon.Deck.Cards.Insert(0, Dungeon.AllCards[data.cardID]);
            eventCancelled = true;
        }
        else if (triggeringKeyword == Depot.Generated.dungeon.keywords.cycles)
        {
            Dungeon.Track.RemoveTrackCard(Dungeon.AllCards[data.cardID]);
            Dungeon.Deck.Cards.Add(Dungeon.AllCards[data.cardID]);
            eventCancelled = true;
        }
        else if (triggeringKeyword == Depot.Generated.dungeon.keywords.obstacle)
        {
            if (!Dungeon.Track.Cards.Any(x =>
                    x.Value != null && !x.Value.Keywords.Contains(Depot.Generated.dungeon.keywords.obstacle)))
            {
                eventCancelled = true;
            }
        }
        else if (triggeringKeyword == Depot.Generated.dungeon.keywords.exit)
        {
            Dungeon.NextDungeonRoom();
            eventCancelled = true;
        }
        else
        {
            Console.WriteLine("unhandled keyword: " + triggeringKeyword.ID);
        }

        completionCallback?.Invoke(!eventCancelled,stackID);
    }

    
    public static bool ValidateLogicExecution(
        DeckCard triggeringCard,
        Depot.Generated.dungeon.keywords.keywordsLine triggeringKeyword, 
        Depot.Generated.dungeon.logicTriggers.logicTriggersLine triggeringLogic,
        LogicEvents.LogicData? data)
    {
        if(data == null){return true;} //we assume null right now is just a player action with no data associated, and hence is valid
        
        var keywordLogicBinding = triggeringKeyword.triggers.FirstOrDefault(x => x.trigger == triggeringLogic);
        if(keywordLogicBinding == null)
        {
            Console.WriteLine("BAD: LOGIC BINDING KEYWORD MISMATCH");
            return false;
        }

        return keywordLogicBinding.target.ToString() switch 
        {
            "self" => triggeringCard.ID == data.cardID,
            "any" => true,
            _ => false
        };
    }
}