namespace Dinghy.Sandbox.Demos.dungeon;

public class Deck
{
    public List<DataTypes.DeckCard> Cards = new();
    public Deck()
    {
        Events.Commands.ExecutedCommandsUpdated += OnExecutedCommandsUpdated;
    }

    public void Init()
    {
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
                var card = new DataTypes.DeckCard(i.ID + $"{j}", i, 4);
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
            if (Dungeon.Track.HasValidTrackPosition(out var pos))
            {
                var draw = Cards[0];
                draw.SetTrackPosition(pos);
                draw.SetDeckPosition(null);
                draw.SetDistance(3);
                Dungeon.Track.AddTrackCard(draw);
                Cards.RemoveAt(0);
            }
        }
    }

    void OnExecutedCommandsUpdated(GameCommand c)
    {
        
    }
}