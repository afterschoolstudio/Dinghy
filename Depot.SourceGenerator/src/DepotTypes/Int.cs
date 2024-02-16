using System.Text.Json;
using System.Linq;
using System.Collections.Generic;

namespace Depot.SourceGenerator
{
    public class Int : ColumnData
    {
        public override string CSharpType => "int";
        public override string GetValue(LineData configuringLine, object o)
        {
            return o.ToString();
        }
        public Int(JsonElement e, SheetData parentSheet) : base(e,parentSheet){}
    }
}