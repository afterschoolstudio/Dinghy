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

    private List<DeckCard> lastUpdatedTrackCards = new();
    public void MoveTrackCardsToLatestTrackPositions(bool applyPositionsDirectly = false)
    {
        var updated = new List<DeckCard>();
        float timeOffset = 0f;
        foreach (var trackCard in Cards.Where(x => x.Value != null))
        {
            if (applyPositionsDirectly)
            {
                Grid.ApplyPositionToEntity(trackCard.Key,trackCard.Value!.Entity);
            }
            else
            {
                if (!lastUpdatedTrackCards.Contains(trackCard.Value))
                {
                    trackCard.Value!.Entity.X = Engine.Width + 200;
                }
                trackCard.Value!.Entity.Y = Grid.Points[trackCard.Key].Y;
                // trackCard.Value!.Entity.X = Engine.Width + 100;
                Coroutines.Add(movePosition(trackCard.Value!,trackCard.Value!.Entity.X,Grid.Points[trackCard.Key].X,timeOffset));
                timeOffset += 0.2f;
            }
            updated.Add(trackCard.Value);
        }

        lastUpdatedTrackCards = new List<DeckCard>(updated);
    }
    
    IEnumerator movePosition(DeckCard c, float startX, float endX, float timeOffset)
    {
        TimeSince off = 0;
        var trans = new Transition<float>(startX, endX, Easing.Option.EaseOutElastic);
        while (off < timeOffset)
        {
            yield return null;
        }
        TimeSince ts = 0;
        while (ts < 0.5f)
        {
            c.Entity.X = startX + ((endX - startX) * (float)trans.Sample(ts / 0.5f));
            yield return null;
        }
        yield return null;
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
                Console.WriteLine("destroying");
                new LogicEvents.Destroyed(c.ID).Emit(() =>
                {
                    Console.WriteLine("destroy callback");
                    c.Entity.ECSEntity.Remove<TrackComponent>();
                    Cards[Cards.First(x => x.Value == c).Key] = null;
                    c.Entity.Active = false;
                    Dungeon.Graveyard.Add(c);
                    FillEmptyTrackCardSpaces();
                    Dungeon.Deck.Draw();
                });
            }
        });
    }
}