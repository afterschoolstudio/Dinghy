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
}