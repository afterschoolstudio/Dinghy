using System.Runtime.InteropServices.JavaScript;

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
                _ => 0
            };
            for (int j = 0; j < iterations; j++)
            {
                Cards.Add(Dungeon.CreateNewCard(i.ID + $"{j}", i));
            }
        }
        
        Cards = Cards.OrderBy(x => Quick.RandFloat()).ToList();
    }

    public void Draw(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            var nextDraw = Cards.First();
            if (Dungeon.Track.TryAddNewTrackCard(nextDraw))
            {
                Cards.RemoveAt(0);
            }
        }
    }
}