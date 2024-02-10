using System;
using System.Text.Json;
using System.Linq;
using System.Collections.Generic;


namespace Depot.SourceGenerator
{
    public class Multiple : ColumnData, IRequiresIntermediateType
    {
        public override string CSharpType => $"{Name}_FLAGS";
        public override string GetValue(LineData configuringLine, object o)
        {
            var value = o.ToString();
            return (!string.IsNullOrEmpty(value) && ((JsonElement)o).EnumerateArray().Count() > 0 && !string.IsNullOrEmpty(((JsonElement)o).EnumerateArray().First().ToString())) ? string.Join("|",((JsonElement)o).EnumerateArray().Select(x => $"{ParentSheet.DataPath}.{CSharpType}.{x}")) : $"{ParentSheet.DataPath}.{CSharpType}.None";
        }
        public Multiple(JsonElement e, SheetData parentSheet) : base(e,parentSheet){}
        public void BuildType(Utils.CodeWriter cw, SheetData d)
        {
            var index = 0;
            var enumValues = JsonElement.GetProperty("options").GetString().Split(',').ToList();
            cw.AddLine($"[Flags]");
            cw.OpenScope($"public enum {CSharpType}");
            List<string> lines = new List<string>();
            lines.Add("None = 0,");
            enumValues.ForEach(value => {lines.Add(value.Replace(" ","") + $" = {Math.Pow(2,index)}" + ","); index++;});
            lines.Last().TrimEnd(',',' ');
            foreach (var item in lines)
            {
                cw.AddLine(item);
            }
            cw.CloseScope();
        }
    }
}