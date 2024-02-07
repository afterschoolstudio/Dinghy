using System.Text.Json;
using System.Linq;
using System.Collections.Generic;

namespace Depot.SourceGenerator
{
    [DepotTypeBinding("sheetReference")]
    public class SheetReference : ColumnData
    {
        public override string CSharpType => "DepotSheet";
        public override string GetValue(LineData configuringLine, object o)
        {
            var value = o.ToString();
            return Utils.GetSheetDataPathFromGuid(configuringLine,this,value);
        }
        public SheetReference(JsonElement e, SheetData parentSheet) : base(e,parentSheet){}
    }
}