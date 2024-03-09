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
                var newCard = Dungeon.CreateNewCard(i.ID + $"{j}", i);
                newCard.Entity.X = Engine.Width + 200;
                Cards.Add(newCard);
            }
        }
        
        Cards = Cards.OrderBy(x => Quick.RandFloat()).ToList();
        
        var rock = Dungeon.CreateNewCard("seeded_rock", Depot.Generated.dungeon.cards.rock);
        rock.Entity.X = Engine.Width + 200;
        Cards.Insert(0,rock);
        
        var seededEnemy = Dungeon.CreateNewCard("seeded_enemy", Depot.Generated.dungeon.cards.enemy);
        seededEnemy.Entity.X = Engine.Width + 200;
        Cards.Insert(1,seededEnemy);
        
        var seededFloor1 = Dungeon.CreateNewCard("seeded_floor1", Depot.Generated.dungeon.cards.floor);
        seededFloor1.Entity.X = Engine.Width + 200;
        Cards.Insert(2,seededFloor1);
        
        var seededFloor2 = Dungeon.CreateNewCard("seeded_floor2", Depot.Generated.dungeon.cards.floor);
        seededFloor2.Entity.X = Engine.Width + 200;
        Cards.Insert(3,seededFloor2);
        
        var seededFloor3 = Dungeon.CreateNewCard("seeded_floor3", Depot.Generated.dungeon.cards.floor);
        seededFloor3.Entity.X = Engine.Width + 200;
        Cards.Insert(4,seededFloor3);
    }
}