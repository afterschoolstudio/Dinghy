using System.Text.Json;
using System.Linq;
using System.Collections.Generic;

namespace Depot.SourceGenerator
{
    [DepotTypeBinding("lineReference")]
    public class LineReference : ColumnData
    {
        public override string CSharpType => handleLineReference();
        public string ReferenceLineType => getReferencedLineType();
        public SheetData ReferencedLineParentSheet => Utils.GetSheetDataFromGUID(this,JsonElement.GetProperty("sheet").ToString());
        public override string GetValue(LineData configuringLine, object o)
        {
            var lineguid = o.ToString();
            return $"new {ReferencedLineParentSheet.WriteSafeName}.{ReferencedLineParentSheet.WriteSafeName}LineReference({string.Format(@"""{0}""",lineguid)})";
        }
        string handleLineReference()
        {
            return $"{ReferencedLineParentSheet.WriteSafeName}.{ReferencedLineParentSheet.WriteSafeName}LineReference";
        }
        string getReferencedLineType()
        {
            var path = ParentFile.GetPathToSheet(ReferencedLineParentSheet);
            return $"{path}.{ReferencedLineParentSheet.WriteSafeName}Line";
        }
        public LineReference(JsonElement e, SheetData parentSheet) : base(e,parentSheet){}
    }
}