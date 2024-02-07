using System.Text.Json;
using System.Linq;
using System.Collections.Generic;

namespace Depot.SourceGenerator
{
    [DepotTypeBinding("longtext")]
    public class LongText : Text
    {
        public LongText(JsonElement e, SheetData parentSheet) : base(e,parentSheet){}
    }
}