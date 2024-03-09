using System.Collections;
using System.Numerics;
using Arch.Core.Extensions;
using Dinghy.Core;

namespace Dinghy.Sandbox.Demos.dungeon;

public class Track
{
    public int MaxTrackCards => Dungeon.TrackSize;
    public Dictionary<int,DeckCard?> Cards = new();
    public Grid Grid;
    public List<DeckCard> ValidActors => Cards.Where(x => x.Value != null && x.Value.Health > 0).Select(x => x.Value!).ToList();
    public List<KeyValuePair<int,DeckCard?>> EmptyPositions => Cards.Where(x => x.Value == null).ToList();
    public bool HasEmptyPositions(out List<int> positions)
    {
        positions = new List<int>();
        foreach (var p in EmptyPositions)
        {
            positions.Add(p.Key);
        }
        return positions.Any();
    }
    
    

    public void Init()
    {
        Grid = new (new (
        new(Engine.Width / 2f, Engine.Height / 2f), 
        new(0.5f, 0.5f), 
        200, 450, 
        new(0.5f, 0.5f), 
        Dungeon.TrackSize,
        1));

        Cards.Clear();
        
        for (int i = 0; i < MaxTrackCards; i++)
        {
           Cards.Add(i,null); 
        }
    }

    private List<DeckCard> lastUpdatedTrackCards = new();
    public IEnumerator MoveTrackCardsToLatestTrackPositions(bool applyPositionsDirectly = false)
    {
        FillEmptyTrackCardSpaces();
        
        var updated = new List<DeckCard>();
        foreach (var trackCard in Cards.Where(x => x.Value != null))
        {
            if (applyPositionsDirectly)
            {
                Grid.ApplyPositionToEntity(trackCard.Key,trackCard.Value!.Entity);
            }
            else if(MathF.Abs(trackCard.Value!.Entity.X - Grid.Points[trackCard.Key].X) > 0.5f)
            {
                if (!lastUpdatedTrackCards.Contains(trackCard.Value))
                {
                    trackCard.Value!.Entity.X = Engine.Width + 200;
                }
                trackCard.Value!.Entity.Y = Grid.Points[trackCard.Key].Y;
                yield return movePosition(trackCard.Value!,trackCard.Value!.Entity.X,Grid.Points[trackCard.Key].X);
                // trackCard.Value!.Entity.X = Engine.Width + 100;
            }
            updated.Add(trackCard.Value);
        }
        
        lastUpdatedTrackCards = new List<DeckCard>(updated);
    }
    
    private void FillEmptyTrackCardSpaces()
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
    
    private IEnumerator movePosition(DeckCard c, float startX, float endX)
    {
        var trans = new Transition<float>(startX, endX, Easing.Option.EaseOutElastic);
        TimeSince ts = 0;
        while (ts < 0.5f)
        {
            c.Entity.X = startX + ((endX - startX) * (float)trans.Sample(ts / 0.5f));
            yield return null;
        }
        yield return null;
    }

    public void RemoveTrackCard(DeckCard card)
    {
        var index = Cards.First(x => x.Value == card).Key;
        Cards[index].Entity.Active = false;
        Cards[index] = null;
    }

    public void Act(Systems.Logic.Event? parentEvent = null,Action onComplete = null)
    {
        var spawningEvent = parentEvent ?? Systems.Logic.RootEvent;
        Logic.MetaEvents.CardsActing.Emit(spawningEvent, postExecution: e =>
        {
            foreach (var card in ValidActors)
            {
                //NOTE: right now acting is only attacking
                if (card.Attack > 0)
                {
                    Depot.Generated.dungeon.logicTriggers.attacking.Emit(e,new Systems.Logic.EventData(card.ID));
                }
            }
        }, onComplete: onComplete);
    }
}