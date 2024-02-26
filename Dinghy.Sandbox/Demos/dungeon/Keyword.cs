namespace Dinghy.Sandbox.Demos.dungeon;

public class Keyword
{
    public string Name => Data.ID;
    public string GUID => Data.GUID;
    public List<Trigger> Triggers = new();
    protected Depot.Generated.dungeon.keywords.keywordsLine Data;
    public Keyword(Depot.Generated.dungeon.keywords.keywordsLine data)
    {
        Data = data;
        if (Data.triggers != null)
        {
            foreach (var t in Data.triggers)
            {
                Triggers.Add(Dungeon.GameLogic.Triggers.Find(x => x.GUID == t.newLineReference.GUID));
            }
        }
    }

    public void TriggerFor(DeckCard c)
    {
        //this could maybe be linked scripts
        switch (Name)
        {
            case "rejuvenate":
                Dungeon.Player.Health += 1;
                break;
        }
    }
}

public class Trigger
{
    public string Name => Data.ID;
    public string GUID => Data.GUID;
    protected Depot.Generated.dungeon.logicTriggers.logicTriggersLine Data;
    public Trigger(Depot.Generated.dungeon.logicTriggers.logicTriggersLine data)
    {
        Data = data;
    }
}