using Arch.Core;

namespace Dinghy;

public static class Quick
{
    public static Random Random = new System.Random();
    public static int RandomInt() => Random.Next();
    public static float RandomFloat() => Random.NextSingle();
    public record SpriteData(string texture) : EntityData
    {
        public override void GetEntity(out Entity e)
        {
            e = Engine.World.Create(
                new Position(0, 0), 
                new SpriteRenderer(texture));
        }
    }

    public static Entity Add(EntityData d)
    {
        d.GetEntity(out var e);
        Engine.World.Add<Entity>(e);
        return e;
    }
}
