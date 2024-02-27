using System.Collections;
using Arch.Core.Extensions;
using Dinghy.Core;

namespace Dinghy.Sandbox.Demos.dungeon;

public class Track
{
    public readonly record struct TrackComponent(int cardID);
    public int MaxTrackCards { get; protected set; }
    public Dictionary<int,DeckCard?> Cards = new();
    
    public Grid Grid = new (new (
        new(Engine.Width / 2f, Engine.Height / 2f), 
        new(0.5f, 0.5f), 
        200, 450, 
        new(0.5f, 0.5f), 
        4,
        1));

    public void Init(int max)
    {
        Cards.Clear();
        
        MaxTrackCards = max;
        for (int i = 0; i < MaxTrackCards; i++)
        {
           Cards.Add(i,null); 
        }
    }

    public void MoveTrackCardsToLatestTrackPositions(bool applyPositionsDirectly = false)
    {
        foreach (var trackCard in Cards.Where(x => x.Value != null))
        {
            if (applyPositionsDirectly)
            {
                Grid.ApplyPositionToEntity(trackCard.Key,trackCard.Value!.Entity);
            }
            else
            {
                Coroutines.Add(movePosition(trackCard.Value!,trackCard.Value!.Entity.X,Grid.Points[trackCard.Key].X));
            }
        }

        IEnumerator movePosition(DeckCard c, float startX, float endX)
        {
            Console.WriteLine("Coroutine started!");
            TimeSince ts = 0;
            var trans = new Transition<float>(startX, endX, Easing.Option.EaseInOutSine);
            while (ts < 2)
            {
                Console.WriteLine(ts);
                c.Entity.X = (float)trans.Sample(ts/2f);
                yield return null;
            }
            yield return null;
            Console.WriteLine("coroutine ended passed!");
        }
    }

    public void RemoveTrackCard(int trackIndex) => RemoveTrackCard(Cards[trackIndex]);
    public void RemoveTrackCard(DeckCard card)
    {
        var index = Cards.First(x => x.Value == card).Key;
        Cards[index].Entity.ECSEntity.Remove<TrackComponent>();
        Cards[index].Entity.Active = false;
        Cards[index] = null;
    }

    public void FillEmptyTrackCardSpaces()
    {
        for (int i = 0; i < Cards.Count; i++)
        {
            if (Cards[i] == null)
            {
                fillInTrackForEmptyPos(i);
            }
        }

        void fillInTrackForEmptyPos(int empty)
        {
            //move everyone left
            for (int i = empty + 1; i < Cards.Count; i++)
            {
                Cards[i-1] = Cards[i];
                Cards[i] = null;
            }
        }
    }

    public void DamageTrackCard(DeckCard c)
    {
        new LogicEvents.Attack(c.ID).Emit(() =>
        {
            c.Health -= 1;
            c.Entity.ECSEntity.Add(new Systems.Shake());
            if (c.Health <= 0)
            {
                var cardPos = Cards.First(x => x.Value == c).Key;
                
                new LogicEvents.Destroyed(Cards[cardPos].ID).Emit(() =>
                {
                    Cards[cardPos].Entity.ECSEntity.Remove<TrackComponent>();
                    
                    Cards[cardPos] = null;
                    c.Entity.Active = false;
                    Dungeon.Graveyard.Add(c);
                    FillEmptyTrackCardSpaces();
                    Dungeon.Deck.Draw();
                });
            }
        });
    }
}