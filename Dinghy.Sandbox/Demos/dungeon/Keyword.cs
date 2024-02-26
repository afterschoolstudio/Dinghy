namespace Dinghy.Sandbox.Demos.dungeon;

public class Keyword
{
    public string Name => Data.ID;
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