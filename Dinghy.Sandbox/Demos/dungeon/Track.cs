using Arch.Core.Extensions;
using Dinghy.Core;

namespace Dinghy.Sandbox.Demos.dungeon;

public class Track
{
    public readonly record struct TrackComponent();
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

    public void UpdategGameCardState()
    {
        foreach (var trackCard in Cards.Where(x => x.Value != null))
        {
            Grid.ApplyPositionToEntity(trackCard.Key,trackCard.Value!.Entity);
        }
    }

    public void Cycle()
    {
        if (Cards[0] != null)
        {
            Dungeon.DiscardStack.Add(Cards[0]);
            Cards[0] = null;
            
            FillSlotsAfterCardRemoval(0);
        }
    }

    public void FillSlotsAfterCardRemoval(int removedPos)
    {
        //move everyone left
        for (int i = removedPos + 1; i < Cards.Count; i++)
        {
            Cards[i-1] = Cards[i];
            Cards[i] = null;
        }
        //draw a replacement
        Dungeon.Deck.Draw(1);
        
        UpdategGameCardState();
    }

    public void DamageTrackCard(DeckCard c)
    {
        c.Health -= 1;
        c.Entity.ECSEntity.Add(new Systems.Shake());
        if (c.Health <= 0)
        {
            var cardPos = Cards.First(x => x.Value == c).Key;
            Cards[cardPos] = null;
            c.Entity.Active = false;
            Dungeon.Graveyard.Add(c);
            FillSlotsAfterCardRemoval(cardPos);
            // Dungeon.Player.GrantXP(XPValue);
        }
    }

    public bool TryAddNewTrackCard(DeckCard dc)
    {
        if (Cards.Any(x => x.Value == null))
        {
            var targetPos = Cards.First(x => x.Value == null).Key;
            Cards[targetPos] = dc;
            dc.Distance = 3;
            dc.Entity.Active = true;
            dc.Entity.ECSEntity.Add(new TrackComponent());
            UpdategGameCardState();
            return true;
        }
        return false;
    }

    public void IncreaseCardDistances(int dist)
    {
        foreach (var c in Cards.Where(x => x.Value != null))
        {
            c.Value!.Distance += dist;
        }
    }
}