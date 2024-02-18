using System;
using System.Text;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System.Text.Json;


namespace Depot.SourceGenerator
{
    public static class DepotSourceGenerator
    {
        public static List<string> Logs = new List<string>();

        public static Dictionary<string, Type> DepotTypeDict = new()
        {
            { "bool", typeof(Bool) },
            { "enum", typeof(Enum) },
            { "file", typeof(FileColumn) },
            { "float", typeof(Float) },
            { "grid", typeof(Grid) },
            { "image", typeof(Image) },
            { "int", typeof(Int) },
            { "lineReference", typeof(LineReference) },
            { "list", typeof(List) },
            { "longtext", typeof(LongText) },
            { "multiple", typeof(Multiple) },
            { "props", typeof(Props) },
            { "sheetReference", typeof(SheetReference) },
            { "text", typeof(Text) },
        };

        public static void GenerateSource(AdditionalText a, GeneratorExecutionContext context)
        {
            var depotFileName = Path.GetFileNameWithoutExtension(a.Path);
            var depotFileText = a.GetText().ToString();
            using (JsonDocument document = JsonDocument.Parse(depotFileText))
            {
                var DepotFileData = new DepotFileData(depotFileName,depotFileText,document.RootElement);
                foreach (var sheet in DepotFileData.Sheets.Where(x => !(x is SubsheetData)))
                {
                    var cw = new Utils.CodeWriter();
                    cw.AddLine("using System.IO;");
                    cw.AddLine("using Depot.Core;");
                    cw.OpenScope($"namespace Depot.Generated.{DepotFileData.WriteSafeName}");
                    BuildSheet(cw,sheet);
                    cw.CloseScope();
                    context.AddSource($"{depotFileName}.{sheet.Name}", cw.ToString());
                }
            }
        }
        
        static void BuildSheet(Utils.CodeWriter cw, SheetData sheet)
        {
            if(sheet.IsProps)
            {
                cw.OpenScope($"public class {sheet.Name}Props : DepotProps");
            }
            else
            {
                if(!(sheet is SubsheetData))
                {
                    cw.OpenScope($"public class {sheet.Name} : DepotSheet");
                }
                else
                {
                    cw.OpenScope($"public class {sheet.Name}List : DepotSheet");
                }
                cw.AddLine($@"public override string Name => ""{sheet.RawName}"";");
                cw.AddLine($@"public override string Description => ""{sheet.Description}"";");
                cw.AddLine($@"public override string GUID => ""{sheet.GUID}"";");
            }
            if(sheet.IsProps)
            {
                foreach (var column in sheet.Columns.Where(x => !(x is Guid)))
                {
                    if(column is LineReference lr)
                    {
                        //handle references differently to help with circular references
                        /*
                            public Depot.Core.Sheet1.Sheet1Line CoolLine => _CoolLine.Line;
                            public Sheeet1LineReference _CoolLine;
                        */
                        cw.AddLine($"public {lr.ReferenceLineType} {column.Name} => _{column.Name}.Line;");
                        cw.AddLine($"{lr.CSharpType} _{column.Name};");
                    }
                    else
                    {
                        cw.AddLine($"public {column.CSharpType} {column.Name} {{get; protected set;}}");
                    }
                }
                cw.OpenScope($"public {sheet.Name}Props({String.Join(",",sheet.Columns.Select(x => $"{x.CSharpType} {x.Name}"))})");
                cw.AddLine($"SetGuid(guid);");
                foreach (var column in sheet.Columns.Where(x => !(x is Guid)))
                {
                    if(column is LineReference lr)
                    {
                        //handle references differently to help with circular references
                        cw.AddLine($"this._{column.Name} = {column.Name};");
                    }
                    else
                    {
                        cw.AddLine($"this.{column.Name} = {column.Name};");
                    }
                }
                cw.CloseScope();
            }
            BuildIntermediaryTypes(cw,sheet);
            if(sheet.ParentDepotFile.SubsheetTree.ContainsKey(sheet))
            {
                foreach (var subsheet in sheet.ParentDepotFile.SubsheetTree[sheet])
                {
                    BuildSheet(cw,subsheet);
                }
            }
            if(!sheet.IsProps)
            {
                BuildSheetLineClass(cw,sheet);
            }
            if(!(sheet is SubsheetData)) //these are only directly created as part of top level sheets
            {
                BuildSheetLineReferenceClass(cw,sheet);
                BuildSheetLines(cw,sheet);
            }
            cw.CloseScope();
        }

        static void BuildIntermediaryTypes(Utils.CodeWriter cw, SheetData sheet)
        {
            foreach (IRequiresIntermediateType column in sheet.Columns.Where(x => x is IRequiresIntermediateType))
            {
                column.BuildType(cw,sheet);
            }
        }

        static void BuildSheetLineClass(Utils.CodeWriter cw, SheetData sheet)
        {
            var lineclassname = "";
            if(sheet is SubsheetData)
            {
                lineclassname = $"{sheet.Name}ListLine";
            }
            else
            {
                lineclassname = $"{sheet.Name}Line";
            }
            cw.OpenScope($"public class {lineclassname} : DepotSheetLine");
                foreach (var column in sheet.Columns.Where(x => !(x is Id || x is Guid)))
                {
                    if(column is LineReference lr)
                    {
                        //handle references differently to help with circular references
                        /*
                            public Depot.Core.Sheet1.Sheet1Line CoolLine => _CoolLine.Line;
                            public Sheeet1LineReference _CoolLine;
                        */
                        cw.AddLine($"public {lr.ReferenceLineType} {column.Name} => _{column.Name}.Line;");
                        cw.AddLine($"{lr.CSharpType} _{column.Name};");
                    }
                    else
                    {
                        cw.AddLine($"public {column.CSharpType} {column.Name} {{get; protected set;}}");
                    }
                }
                cw.OpenScope($"public {lineclassname}({String.Join(",",sheet.Columns.Select(x => $"{x.CSharpType} {x.Name}"))})");
                    cw.AddLine("ID = id;");
                    cw.AddLine("SetGuid(guid);");
                    foreach (var column in sheet.Columns.Where(x => !(x is Id || x is Guid)))
                    {
                        if(column is LineReference lr)
                        {
                            //handle references differently to help with circular references
                            cw.AddLine($"this._{column.Name} = {column.Name};");
                        }
                        else
                        {
                            cw.AddLine($"this.{column.Name} = {column.Name};");
                        }
                    }
                cw.CloseScope();
            cw.CloseScope();
        }

        static void BuildSheetLineReferenceClass(Utils.CodeWriter cw, SheetData sheet)
        {
            var source = $@"
public class {sheet.Name}LineReference
{{
    public string LineGuid {{get; protected set;}}
    {sheet.Name}.{sheet.Name}Line line;
    public {sheet.Name}.{sheet.Name}Line Line
    {{
        get
        {{
            if(line == null)
            {{
                SetupReference();
            }}
            return line;
        }}
        set
        {{
            line = value;
        }}
    }}
    public {sheet.Name}LineReference(string guid)
    {{
        LineGuid = guid;
    }}
    void SetupReference()
    {{
        Line = {sheet.Name}.Lines.Find(x => x.GUID == LineGuid);   
    }}
}}
";
            cw.AddLines(source);
            //
            // cw.OpenScope($"public class {sheet.WriteSafeName}LineReference");
            //     cw.AddLine("public string LineGuid {get; protected set;}");
            //     cw.AddLine($"{sheet.WriteSafeName}.{sheet.WriteSafeName}Line line;");
            //     cw.OpenScope($"public {sheet.WriteSafeName}.{sheet.WriteSafeName}Line Line");
            //         cw.OpenScope($"get");
            //             cw.OpenScope($"if(line == null)");
            //                 cw.AddLine($"SetupReference();");
            //             cw.CloseScope();
            //             cw.AddLine("return line;");
            //         cw.CloseScope();
            //         cw.OpenScope($"set");
            //             cw.AddLine("line = value;");
            //         cw.CloseScope();
            //     cw.CloseScope();
            //     cw.OpenScope($"public {sheet.WriteSafeName}LineReference(string guid)");
            //         cw.AddLine($"LineGuid = guid;");
            //     cw.CloseScope();
            //     cw.OpenScope("void SetupReference()");
            //         cw.AddLine($"Line = {sheet.WriteSafeName}.Lines.Find(x => x.GUID == LineGuid);");
            //     cw.CloseScope();
            // cw.CloseScope();
        }

        static void BuildSheetLines(Utils.CodeWriter cw, SheetData sheet) //NOTE: only top line sheets have this
            {
                var lineItems = new List<string>();
                foreach (var line in sheet.Lines)
                {
                    var lineValueDict = new Dictionary<string,object>()
                    {
                        {"id",line.ID},
                        {"guid",line.GUID}
                    };
                    foreach (var prop in line.JsonElement.EnumerateObject())
                    {
                        if(prop.NameEquals("id") || prop.NameEquals("guid")){continue;}
                        lineValueDict.Add(prop.Name,prop.Value);
                    }
                    var lineValues = new List<string>();
                    foreach (var item in lineValueDict.OrderBy(x=>x.Key))
                    {
                        if(item.Key == "id" || item.Key == "guid")
                        {
                            lineValues.Add(string.Format(@"""{0}""", item.Value));
                        }
                        else
                        {
                            var column = sheet.Columns.FirstOrDefault(x => x.RawName == item.Key);
                            if(column == null)
                            {
                                Console.WriteLine($"ERROR: column for id {item.Key} not found");
                            }
                            else
                            {
                                lineValues.Add(column.GetValue(line,item.Value));
                            }
                        }
                    }
                    lineItems.Add($"public static {sheet.Name}Line {line.WriteSafeID} = new {sheet.Name}Line({string.Join(",",lineValues)});");
                }

                foreach (var line in lineItems)
                {
                    cw.AddLine(line);
                }

                cw.OpenScope($"public static List<{sheet.Name}Line> Lines = new List<{sheet.Name}Line>()");
                foreach (var line in sheet.Lines)
                {
                    var c = line == sheet.Lines.Last() ? "" : ",";
                    cw.AddLine($"{line.WriteSafeID}{c}");
                }
                cw.CloseScope(";");
            }
    }
}
