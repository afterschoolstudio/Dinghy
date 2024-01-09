using System.Numerics;

namespace Dinghy.Core;

public interface ICollideable
{
    public bool ColliderActive { get; set; }
    public void Collide(Dinghy.Entity self, Dinghy.Entity other)
    {
        OnCollision?.Invoke(self,other);
    }
    public Action<Dinghy.Entity,Dinghy.Entity> OnCollision { get; set; }
}
