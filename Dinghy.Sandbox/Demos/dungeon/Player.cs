using System.Collections;
using Dinghy.Core;

namespace Dinghy.Sandbox.Demos.dungeon;

public class Player
{
    public int MaxHealth { get; set; } = 10;
    public int Health { get; set; } = 10;
    public int Fullness { get; set; } = 10;
    public int XP { get; private set; } = 0;
    public int MovedDistance { get; set; } = 0;
    public bool Dead { get; protected set; }

    public void Init()
    {
        Health = MaxHealth;
        Fullness = 10;
        XP = 0;
        MovedDistance = 0;
        Dead = false;
    }
    public void GrantXP(int xp)
    {
        XP += xp;
        if (XP % 5 == 0)
        {
            Health = MaxHealth;
        }
    }

    public void Kill()
    {
        Dead = true;
    }

    public void Move(Action onComplete = null)
    {
        Console.WriteLine("player initirated move, spawning move");
        Depot.Generated.dungeon.logicTriggers.move.Emit(Systems.Logic.RootEvent, postExecution: move =>
        {
            move.Frozen = true;
            Depot.Generated.dungeon.logicTriggers.discard.Emit(move,new Systems.Logic.EventData(Dungeon.Track.Cards[0].ID), postExecution:discard =>
            {
                discard.Frozen = true;
                Coroutines.Start(Dungeon.Track.MoveTrackCardsToLatestTrackPositions(),"player movement card update after discard",() =>
                {
                    Depot.Generated.dungeon.logicTriggers.draw.Emit(discard,onComplete: () =>
                    {
                        Coroutines.Start(Dungeon.Track.MoveTrackCardsToLatestTrackPositions(),
                            "player movement card update after draw",
                            () =>
                            {
                                move.Frozen = false;
                                discard.Frozen = false;
                            });
                    });
                    
                });
            });
        }, onComplete:onComplete);
    }

    public void Wait(Action onComplete = null)
    {
        Depot.Generated.dungeon.logicTriggers.wait.Emit(Systems.Logic.RootEvent, postExecution: e =>
        {
            Dungeon.Track.Act(e);
        }, onComplete:onComplete);
    }
    
    public void DamageTrackCards(List<DeckCard> cards, Action onComplete = null)
    {
        Logic.MetaEvents.PlayerAttacking.Emit(Systems.Logic.RootEvent, postExecution: e =>
        {
            foreach (var card in cards)
            {
                Depot.Generated.dungeon.logicTriggers.attackedByPlayer.Emit(e,new Systems.Logic.EventData(cardID:card.ID));
            }
            Dungeon.Track.Act(e);
        }, onComplete: onComplete);
    }
}