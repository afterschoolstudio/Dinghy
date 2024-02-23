namespace Dinghy.Sandbox.Demos.dungeon;

public class Track
{
    public int MaxTrackCards { get; protected set; }
    public bool CanAddNewCards => Cards.Count < MaxTrackCards;
    public List<int> PositionList = new();
    public List<DataTypes.DeckCard> Cards = new();
    public Track(int max)
    {
        MaxTrackCards = max;
        for (int i = 0; i < MaxTrackCards; i++)
        {
            PositionList.Add(i); 
        }
        Events.Commands.ExecutedCommandsUpdated += OnExecutedCommandsUpdated;
    }

    void OnExecutedCommandsUpdated(GameCommand c)
    {
        switch (c)
        {
            case IMakesTrackAct:
                foreach (var dc in Cards)
                {
                    dc.Act();
                }
                break;
            default:
                break;
        }
    }

    public void AddTrackCard(DataTypes.DeckCard c)
    {
        Cards.Add(c);
    }

    public void UpdategGameCardState()
    {
        foreach (var trackCard in Cards)
        {
            Dungeon.g.ApplyPositionToEntity(trackCard.TrackPosition.Value,trackCard.Entity);
        }
    }

    public bool Discard()
    {
        var tc = Cards.FirstOrDefault(x => x.TrackPosition == 0);
        if (tc != null && tc.CanCycleOffBOard)
        {
            Cards.Remove(tc);
            tc.SetTrackPosition(null);
            Dungeon.DiscardStack.Add(tc);
            
            //move everyone left
            foreach (var dc in Cards)
            {
                if (dc.TrackPosition > 0)
                {
                    dc.SetTrackPosition(dc.TrackPosition-1);
                }
            }
            return true;
        }
        return false;
    }

    public void RemoveCard(DataTypes.DeckCard dc)
    {
        var ct = Cards.Count;
        Cards.Remove(dc);
        if (ct > Cards.Count)
        {
            //something was removed
            //move everyone left
            foreach (var tc in Cards)
            {
                if (tc.TrackPosition > dc.TrackPosition)
                {
                    tc.SetTrackPosition(tc.TrackPosition-1);
                }
            }
            Dungeon.Track.UpdategGameCardState();
            Dungeon.Deck.Draw(1);
            Dungeon.Track.UpdategGameCardState();
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

    public void CheckForDestroyedCards()
    {
        foreach (var c in Cards)
        {
            c.CheckForDestruction();
        }
    }
}