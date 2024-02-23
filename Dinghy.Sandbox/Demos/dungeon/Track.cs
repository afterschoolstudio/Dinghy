namespace Dinghy.Sandbox.Demos.dungeon;

public class Track
{
    public int MaxTrackCards { get; protected set; }
    public bool CanAddNewCards => Cards.Count < MaxTrackCards;
    public List<int> PositionList = new();
    public List<DeckCard> Cards = new();

    public void Init(int max)
    {
        foreach (var card in Cards)
        {
            card.Destroy();
        }
        Cards.Clear();
        
        MaxTrackCards = max;
        for (int i = 0; i < MaxTrackCards; i++)
        {
            PositionList.Add(i); 
        }
    }

    public void UpdategGameCardState()
    {
        foreach (var trackCard in Cards)
        {
            Dungeon.g.ApplyPositionToEntity(trackCard.TrackPosition.Value,trackCard.Entity);
        }
    }

    public void Cycle()
    {
        var tc = Cards.FirstOrDefault(x => x.TrackPosition == 0);
        if (tc != null && tc.CanCycleOffBOard)
        {
            Discard(tc);
            Dungeon.Deck.Draw(1);
        }
    }

    public void Discard(DeckCard tc, bool addToDiscard = true)
    {
        if (Cards.Contains(tc))
        {
            var removedPos = tc.TrackPosition;
            Cards.Remove(tc);
            tc.SetTrackPosition(null);
            if (addToDiscard)
            {
                Dungeon.DiscardStack.Add(tc);
            }
            
            //move everyone left
            foreach (var dc in Cards)
            {
                if (dc.TrackPosition > removedPos)
                {
                    dc.SetTrackPosition(dc.TrackPosition-1);
                }
            }
            Dungeon.Deck.Draw(1);
        }
    }

    public bool TryAddNewTrackCard(DeckCard dc)
    {
        if (Cards.Count < MaxTrackCards)
        {
            int targetPos = 0;
            if (Cards.Any())
            {
                targetPos = PositionList.Except(Cards.Select(x => x.TrackPosition.Value)).Min();
            }
            Cards.Add(dc);
            dc.SetTrackPosition(targetPos);
            dc.SetDistance(3);
            return true;
        }
        return false;
    }

    public void IncreaseCardDistances(int dist)
    {
        foreach (var c in Cards)
        {
            c.Distance += dist;
        }
    }

    public bool HasValidTrackPosition(out int pos)
    {
        var l = PositionList.Except(Cards.Select(x => x.TrackPosition.Value));
        if (!l.Any())
        {
            pos = -1;
            return false;
        }
        pos = l.MinBy(x => x);
        return true;
    }

    public void Act()
    {
        foreach (var c in Cards)
        {   
            c.Act();
        }
    }
}