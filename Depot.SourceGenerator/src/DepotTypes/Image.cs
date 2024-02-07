using System.Text.Json;
using System.Linq;
using System.Collections.Generic;

namespace Depot.SourceGenerator
{
    [DepotTypeBinding("image")]
    public class Image : FileColumn
    {
        public Image(JsonElement e, SheetData parentSheet) : base(e,parentSheet){}
    }
}