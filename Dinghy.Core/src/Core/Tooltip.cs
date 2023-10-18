using System.Text;

namespace Dinghy;

public class Tooltips
{
    public record Tooltip(string header, params TooltipElement[] elements)
    {
        public void WriteIL()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<start>");
            foreach (var e in elements)
            {
                e.WriteIL(sb);
            }
            sb.Append("<end");
            Console.WriteLine(sb);
        }
    }

    public abstract record TooltipElement()
    {
        public abstract void WriteIL(StringBuilder sb);
    }

    public record Image() : TooltipElement
    {
        public override void WriteIL(StringBuilder sb)
        {
            sb.Append("<image>");
            sb.Append("</image>");
        }
    }

    public Tooltip BaseTooltip = new Tooltip("Header");
    public Image SmallImage;

    Tooltip Test()
    {
        (BaseTooltip with
        {
            header = "my new tooltip",
            elements = new[]
            {
                SmallImage,
                SmallImage with { }
            }
        }).WriteIL();
    };
}