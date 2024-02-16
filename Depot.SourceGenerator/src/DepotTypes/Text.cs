using System.Text.Json;
using System.Linq;
using System.Collections.Generic;

namespace Depot.SourceGenerator
{
    public class Text : ColumnData
    {
        public override string CSharpType => "string";
        public override string GetValue(LineData configuringLine, object o)
        {
            var value = o.ToString();
            return string.Format(@"""{0}""",value);
        }
        public Text(JsonElement e, SheetData parentSheet) : base(e,parentSheet){}
    }
}