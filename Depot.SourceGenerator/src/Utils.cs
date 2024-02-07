using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.IO;
using Microsoft.CodeAnalysis;

namespace Depot.SourceGenerator
{
    public static class Utils
    {
        static IEnumerable<(bool, AdditionalText)> GetLoadOptions(GeneratorExecutionContext context)
        {
            foreach (AdditionalText file in context.AdditionalFiles)
            {
                context.AnalyzerConfigOptions.GetOptions(file).TryGetValue("build_metadata.AdditionalFiles.GenerateDepotSource", out string generateDepotSourceString);
                bool.TryParse(generateDepotSourceString, out bool generateDepotSource);
                yield return (generateDepotSource,file);
            }
        }
        
        public static Depot.SourceGenerator.SheetData GetSheetDataFromGUID(ColumnData d, string guid)
        {
            return d.ParentFile.Sheets.Find(x => x.GUID == guid);
        }
        public static string GetSheetTypeNameFromGUID(ColumnData d, string guid)
        {
            return GetSheetDataFromGUID(d,guid).WriteSafeName;
        }
        public static string GetSheetDataPathFromGuid(LineData configuringLine, ColumnData d, string guid)
        {
            return $"Depot.Generated.{d.ParentFile.WriteSafeName}.{GetSheetTypeNameFromGUID(d,guid)}";
        }

        public static LineData GetLineDataFromGUID(ColumnData d, string lineGuid)
        {
            var sheetguid = d.JsonElement.GetProperty("sheet").ToString(); //this is the configured column data field that points to the sheet the line refs come from. every lineref has it
            return GetSheetDataFromGUID(d,sheetguid).Lines.Find(x => x.GUID == lineGuid);
        }
        public static string GetLineNameFromGUID(ColumnData d, string lineGuid)
        {
            return GetLineDataFromGUID(d,lineGuid).WriteSafeID;
        }
        public static string GetLineDataPathFromGuid(LineData configuringLine, ColumnData d, string lineguid)
        {
            var sheetguid = d.JsonElement.GetProperty("sheet").ToString(); //this is the configured column data field that points to the sheet the line refs come from. every lineref has it
            if(string.IsNullOrEmpty(lineguid))
            {
                //no line has been selected, return null
                DepotSourceGenerator.Logs.Add($"no line ref selection for {d.GetRawName()} in {GetSheetTypeNameFromGUID(d,sheetguid)} for line with id {configuringLine.ID}");
                return "null";
            }
            return $"Depot.Generated.{d.ParentFile.WriteSafeName}.{GetSheetTypeNameFromGUID(d,sheetguid)}.{GetLineNameFromGUID(d,lineguid)}";
        }
    }
}