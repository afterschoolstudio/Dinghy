using System.Runtime.InteropServices.JavaScript;

namespace Dinghy.Sandbox.Demos.dungeon;

public class Deck
{
    public List<DeckCard> Cards = new();
    public void Init()
    {
        foreach (var card in Cards)
        {
            card.Destroy();
        }
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
                var card = new DeckCard(i.ID + $"{j}", i, 4);
                Cards.Add(card);
            }
        }
        
        Cards = Cards.OrderBy(x => Quick.RandFloat()).ToList();
        for (int i = 0; i < Cards.Count; i++)
        {
            Cards[i].SetDeckPosition(i);
            Cards[i].SetTrackPosition(null);
        }
    }

    public void Draw(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            var nextDraw = Cards[0];
            if (Dungeon.Track.TryAddNewTrackCard(nextDraw))
            {
                nextDraw.SetDeckPosition(null);
                Cards.RemoveAt(0);
            }
        }
        Dungeon.Track.UpdategGameCardState();
    }
}