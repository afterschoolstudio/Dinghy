using Arch.Core;

namespace Dinghy;

public abstract record EntityData
{
    public abstract void GetEntity(out Entity e);
}