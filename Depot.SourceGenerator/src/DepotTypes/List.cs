using System.Text.Json;
using System.Linq;
using System.Collections.Generic;

namespace Depot.SourceGenerator
{
    public class List : ColumnData
    {
        public override string CSharpType => handleListReference();
        public override string GetValue(LineData configuringLine, object o)
        {
            var value = o.ToString();
            return !string.IsNullOrEmpty(value) ? BuildListCtor(configuringLine,value,JsonElement.GetProperty("sheet").ToString(),this) : "null"; //todo - this is a line constructor for the subsheet typ;
        }
        string handleListReference()
        {
            var sheetGUID = JsonElement.GetProperty("sheet").ToString();
            var path = ParentSheet.ParentDepotFile.GetPathToSheet(Utils.GetSheetDataFromGUID(this,sheetGUID));
            return $"List<{path}.{Utils.GetSheetTypeNameFromGUID(this,sheetGUID)}ListLine>";
        }
        public List(JsonElement e, SheetData parentSheet) : base(e,parentSheet){}

        public string BuildListCtor(LineData configuringLine, string v, string listSheetGuid, ColumnData parentColumn)
        {
            var lineCtors = new List<string>();
            var sheet = Utils.GetSheetDataFromGUID(this,listSheetGuid);
            var path = ParentSheet.ParentDepotFile.GetPathToSheet(sheet);
            var listItemTypePath = $"{path}.{sheet.Name}ListLine";
            var data = JsonDocument.Parse(v);
            if(data.RootElement.EnumerateArray().Count() == 0){return "null";}
            foreach (var e in data.RootElement.EnumerateArray()) //this is the array of lines at this element
            {
                var s = e.ToString();
                var listValues = new List<string>();
                var reqColumns = new List<ColumnData>(sheet.Columns);
                //depot kvp value placement is indeterminat,so we just alphabetize here
                foreach (var l in e.EnumerateObject().OrderBy(x => x.Name)) //these are the actual values in the array
                {
                    var typeColumn = sheet.Columns.Find(x => x.RawName == l.Name);
                    if(typeColumn == null)
                    {
                        //no line has been selected, return null
                        DepotSourceGenerator.Logs.Add($"WARN: unable to find matching column for line data key {l.Name} with value {l.Value} on line with id {configuringLine.ID}, data will not be reflected in source");
                        continue;
                    }
                    if(typeColumn is Props p)
                    {
                        listValues.Add(p.BuildPropsCtor(configuringLine,l.Value.ToString(),typeColumn.JsonElement.GetProperty("sheet").ToString(),this));
                    }
                    else if(typeColumn is List li)
                    {
                        listValues.Add(li.BuildListCtor(configuringLine,l.Value.ToString(),typeColumn.JsonElement.GetProperty("sheet").ToString(),this));
                    }
                    else
                    {
                        listValues.Add(typeColumn.GetValue(configuringLine,l.Value));
                    }
                    reqColumns.Remove(typeColumn);
                }
                if(reqColumns.Count > 0)
                {
                    //this means the data on this object lacked some of the values needed for this colum
                    //this happens sometimes because of large data changes in depot or just old depot files having sort of broken data
                    //we emit a report here to the logs so you can fix your data (often by just adding in a value at the problem path and saving)
                    foreach (var item in reqColumns.Where(x => !(x is Id || x is Guid)))
                    {
                        //note we do this hacky parent path thing because we sometimes hack depot parent sheet references to re-used column configs
                        //in cantata, we use BuildableInteractables.ProjectInfo for all project types, and instead of redefining it we create the props column
                        //and then manually change the guid to the BuildableInteractables.ProjectInfo guid, allowing us to reuse that config
                        //however this means if you used item.ParentSheet, all projects would point to the path of BuildableInteractables.ProjectInfo
                        //this is _technically_ correct, but isnt useful as a log statement, as it accidentally obscures the path you actually care about
                        //so instead we pass in the parent column here and use that as a way to get where this is actually happening
                        DepotSourceGenerator.Logs.Add($"ERROR: {configuringLine.ID} at {parentColumn.ParentSheet.DataPath}.{item.ParentSheet.RawName} did not have a value for {item.RawName}, ctor will be broken");
                    }
                }
                lineCtors.Add($"new {listItemTypePath}({string.Join(",",listValues)})");
            }
            return $"new List<{listItemTypePath}>(){{{string.Join(",",lineCtors)}}}";
        }
    }
}