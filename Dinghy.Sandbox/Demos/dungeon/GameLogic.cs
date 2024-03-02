namespace Dinghy.Sandbox.Demos.dungeon;

public class GameLogic
{
    public List<Depot.Generated.dungeon.keywords.keywordsLine> Keywords => Depot.Generated.dungeon.keywords.Lines;
    public List<Depot.Generated.dungeon.logicTriggers.logicTriggersLine> Triggers => Depot.Generated.dungeon.logicTriggers.Lines;

    public void Init()
    {
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