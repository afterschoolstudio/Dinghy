namespace Dinghy.Sandbox.Demos.dungeon;

public class Keyword
{
    public string Name { get; protected set; }
    public Keyword(Depot.Generated.dungeon.keywords.keywordsLine data)
    {
        Name = data.ID;
        //define trigger conditions in depot?
    }
}