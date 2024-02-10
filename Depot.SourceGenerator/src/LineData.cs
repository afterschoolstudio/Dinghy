using System.Text.Json;

namespace Depot.SourceGenerator
{
    public class LineData
    {
        public string WriteSafeID {get;}
        public string ID {get;}
        public string GUID {get;}
        public JsonElement JsonElement {get;}
        public SheetData ParentSheet {get;}
        public LineData(JsonElement e, SheetData parentSheet)
        {
            JsonElement = e;
            ID = e.GetProperty("id").GetString();
            WriteSafeID = File.SanitizeFilename(ID);
            GUID = e.GetProperty("guid").GetString();
            ParentSheet = parentSheet;
        }
    }
}