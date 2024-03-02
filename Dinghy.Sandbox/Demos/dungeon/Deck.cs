using System.Runtime.InteropServices.JavaScript;
using Arch.Core.Extensions;

namespace Dinghy.Sandbox.Demos.dungeon;

public class Deck
{
    public List<DeckCard> Cards = new();
    public void Init()
    {
        Cards.Clear();
        
        foreach (var i in Depot.Generated.dungeon.cards.Lines)
        {
            int iterations = i.ID switch
            {
                "enemy" => 6,
                "big enemy" => 2,
                "rock" => 8,
                "floor" => 15,
                "stairs" => 1,
                _ => 0
            };
            for (int j = 0; j < iterations; j++)
            {
                Cards.Add(Dungeon.CreateNewCard(i.ID + $"{j}", i));
            }
        }
        
        Cards = Cards.OrderBy(x => Quick.RandFloat()).ToList();
    }

    public void Draw(bool applyNewPositionsDirectly = false)
    {
        new LogicEvents.Draw().Emit(() =>
        {
            var nextDraw = Cards.First();
            
            var targetPos = Dungeon.Track.Cards.First(x => x.Value == null).Key;
            Dungeon.Track.Cards[targetPos] = nextDraw;
            nextDraw.Distance = 3;
            nextDraw.Entity.Active = true;
            nextDraw.Entity.ECSEntity.Add(new Track.TrackComponent(nextDraw.ID));
            
            Cards.Remove(nextDraw);
            
            Dungeon.Track.MoveTrackCardsToLatestTrackPositions(applyNewPositionsDirectly);
        });
    }
}