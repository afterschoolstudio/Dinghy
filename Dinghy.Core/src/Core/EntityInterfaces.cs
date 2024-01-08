using System.Numerics;

namespace Dinghy.Core;

public interface ICollideable
{
    public bool ColliderActive { get; set; }
    public Action<Entity> OnCollision { get; set; }
}
