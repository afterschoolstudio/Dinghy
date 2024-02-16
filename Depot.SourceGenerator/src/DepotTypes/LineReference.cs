using System.Text.Json;
using System.Linq;
using System.Collections.Generic;

namespace Depot.SourceGenerator
{
    public class LineReference : ColumnData
    {
        public override string CSharpType => handleLineReference();
        public string ReferenceLineType => getReferencedLineType();
        public SheetData ReferencedLineParentSheet => Utils.GetSheetDataFromGUID(this,JsonElement.GetProperty("sheet").ToString());
        public override string GetValue(LineData configuringLine, object o)
        {
            var lineguid = o.ToString();
            return $"new {ReferencedLineParentSheet.Name}.{ReferencedLineParentSheet.Name}LineReference({string.Format(@"""{0}""",lineguid)})";
        }
        string handleLineReference()
        {
            return $"{ReferencedLineParentSheet.Name}.{ReferencedLineParentSheet.Name}LineReference";
        }
        string getReferencedLineType()
        {
            var path = ParentFile.GetPathToSheet(ReferencedLineParentSheet);
            return $"{path}.{ReferencedLineParentSheet.Name}Line";
        }
        public LineReference(JsonElement e, SheetData parentSheet) : base(e,parentSheet){}
    }
}