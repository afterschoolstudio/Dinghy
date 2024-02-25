namespace Dinghy.Sandbox.Demos.dungeon;

public class Keyword
{
    public string Name => Data.ID;
    public List<Trigger> Triggers = new();
    protected Depot.Generated.dungeon.keywords.keywordsLine Data;
    public Keyword(Depot.Generated.dungeon.keywords.keywordsLine data)
    {
        Data = data;
        foreach (var t in Data.triggers)
        {
            
        }
    }
}

public class Trigger
{
    public string Name => Data.ID;
    protected Depot.Generated.dungeon.logicTriggers.logicTriggersLine Data;
    public Trigger(Depot.Generated.dungeon.logicTriggers.logicTriggersLine data)
    {
        Data = data;
    }
}