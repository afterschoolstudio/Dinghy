namespace Dinghy.Sandbox.Demos.dungeon;

public class LootTable
{
    private class LootItem
    {
        public Depot.Generated.dungeon.cards.cardsLine Item { get; set; }
        public int Weight { get; set; }
        public int RangeStart { get; set; }
        public int RangeEnd { get; set; }
    }

    private List<LootItem> items = new List<LootItem>();
    private int totalWeight;
    private Random random = new Random();

    public void AddItem(Depot.Generated.dungeon.cards.cardsLine item, int weight)
    {
        if (weight <= 0)
            throw new ArgumentException("Weight must be positive.");

        LootItem lootItem = new LootItem
        {
            Item = item,
            Weight = weight
        };

        items.Add(lootItem);
        totalWeight += weight;
    }

    public void PrepareRanges()
    {
        int rangeStart = 1;
        foreach (LootItem item in items)
        {
            item.RangeStart = rangeStart;
            rangeStart += item.Weight;
            item.RangeEnd = rangeStart - 1;
        }
    }

    Depot.Generated.dungeon.cards.cardsLine RollForLoot()
    {
        int roll = random.Next(1, totalWeight + 1);

        foreach (LootItem item in items)
        {
            if (roll >= item.RangeStart && roll <= item.RangeEnd)
                return item.Item;
        }

        throw new Exception("Invalid roll value.");
    }

    public bool GetNextDrop(out DeckCard card)
    {
        var data = RollForLoot();
        card = null;
        if (data != null) //null options are valid because we may not drop anything
        {
            card = Dungeon.CreateNewCard(data.ID, data);
            return true;
        }

        return false;
    }
}