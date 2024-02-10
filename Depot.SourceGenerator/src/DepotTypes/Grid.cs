using System;
using System.Text.Json;
using System.Linq;
using System.Collections.Generic;


namespace Depot.SourceGenerator
{
    public class Grid : ColumnData, IRequiresIntermediateType
    {
        public override string CSharpType => $"{Name}_GRID";
        public override string GetValue(LineData configuringLine, object o)
        {
            var value = o.ToString();
            return !string.IsNullOrEmpty(value) ? BuildGridCtor(configuringLine,value) : "null"; //todo - this is just an object sonstructo;
        }
        string handlePropsReference()
        {
            var sheetGUID = JsonElement.GetProperty("sheet").ToString();
            return ParentSheet.ParentDepotFile.GetPathToSheet(Utils.GetSheetDataFromGUID(this,sheetGUID));
        }
        List<ColumnData> SpoofedSchemaColumns = new List<ColumnData>();
        public Grid(JsonElement e, SheetData parentSheet) : base(e,parentSheet)
        {
            var schema = JsonElement.GetProperty("schema").EnumerateArray().Select(x => x.ToString()).ToArray();
            for (int i = 0; i < schema.Count(); i++)
            {
                var sc = new HiddenDataType.SpoofedColumnData($"v{i}");
                var type = DepotSourceGenerator.DepotTypeDict[schema[i]];
                var cd = (ColumnData) Activator.CreateInstance(type,sc.ToJsonElement(),parentSheet);
                SpoofedSchemaColumns.Add(cd);
            }
        }
        public string BuildGridCtor(LineData configuringLine, string v)
        {
            var values = new List<string>();
            var data = JsonDocument.Parse(v).RootElement.EnumerateArray().Select(x => x.ToString()).ToArray();
            for (int i = 0; i < SpoofedSchemaColumns.Count(); i++)
            {
                values.Add(SpoofedSchemaColumns[i].GetValue(configuringLine,data[i]));
            }
            return $"new {ParentSheet.DataPath}.{CSharpType}({string.Join(",",values)})";
        }
        public void BuildType(Utils.CodeWriter cw, SheetData d)
        {
            cw.OpenScope($"public class {CSharpType}");
            var schema = JsonElement.GetProperty("schema").EnumerateArray();
            var schemaTypeDict = new Dictionary<int,string>();
            var index = 0;
            List<string> valueNames = new List<string>();
            foreach (var item in SpoofedSchemaColumns)
            {
                schemaTypeDict.Add(index,item.CSharpType);
                cw.AddLine($"public {item.CSharpType} Value{index} {{get; protected set;}}");
                valueNames.Add($"Value{index},");
                index++;
            }

            cw.AddLine("public List<object> AllValues = new List<object>();");
            cw.OpenScope($"public {CSharpType}({String.Join(",",schemaTypeDict.OrderBy(x => x.Key).Select(x => $"{x.Value} Value{x.Key}"))})");
            foreach (var item in schemaTypeDict)
            {
                cw.AddLine($"this.Value{item.Key} = Value{item.Key};");
                cw.AddLine($"AllValues.Add(Value{item.Key});");
            }
            cw.CloseScope();
            cw.CloseScope();
        }
    }
}