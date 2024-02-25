namespace Dinghy.Sandbox.Demos.dungeon;

public class GameLogic
{
    public List<Keyword> Keywords = new();
    public List<Trigger> Triggers = new();
    public GameLogic()
    {
        foreach (var t in Depot.Generated.dungeon.logicTriggers.Lines)
        {
            Triggers.Add(new Trigger(t));
        }
        
        foreach (var t in Depot.Generated.dungeon.keywords.Lines)
        {
            Keywords.Add(new Keyword(t));
        }
    }
}