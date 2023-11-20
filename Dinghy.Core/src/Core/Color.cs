using Dinghy.Internal.Sokol;

namespace Dinghy;

public class Color
{
    public sg_color internal_color {get; init;}
    public Color(uint hex)
    {
        internal_color = Internal.Sokol.Color.sg_make_color_1i(hex);
    }
    
    public static implicit operator Color(uint c)
    {
        return new Color(c);
    }
    
}