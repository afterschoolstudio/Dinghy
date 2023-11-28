namespace Dinghy.Core;

public class Scene(string Name)
{
    public List<Dinghy.Entity> Entities = new ();

    public void DestroyAllEntites()
    {
        foreach (var e in Entities)
        {
            e.Destroy();
        }
    }
}