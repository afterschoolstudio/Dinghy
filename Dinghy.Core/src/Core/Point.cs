using Dinghy.Internal.Cute;

namespace Dinghy.Core;

public record Point(int x, int y)
{
    public static implicit operator c2v(Point d) => new c2v(){x = d.x,y = d.y};
}