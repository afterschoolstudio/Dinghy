namespace Dinghy.Sandbox.Demos.dungeon;

public class GameLogic
{
    public List<Keyword> Keywords = new();
    public List<Trigger> Triggers = new();

    public void Init()
    {
        Keywords.Clear();
        Triggers.Clear();
        
        foreach (var t in Depot.Generated.dungeon.logicTriggers.Lines)
        {
            Triggers.Add(new Trigger(t));
        }
            
        foreach (var t in Depot.Generated.dungeon.keywords.Lines)
        {
            Keywords.Add(new Keyword(t));
        }

        foreach (var k in Keywords)
        {
            Console.WriteLine($"keyword: {k.Name}");
            foreach (var t in k.Triggers)
            {
                Console.WriteLine($"    triggers on: {t.Name}");
            }
        }
    }
}