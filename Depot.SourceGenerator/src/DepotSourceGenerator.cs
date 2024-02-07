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
using Afterschool.Common;
using CodeWriter = Afterschool.Common.Utils.CodeWriter;


namespace Depot.SourceGenerator
{
    [Generator]
    public class DepotSourceGenerator : ISourceGenerator
    {
        public static List<string> Logs = new List<string>();
        public static Dictionary<string,Type> DepotTypeDict = new Dictionary<string, Type>();
        public void Execute(GeneratorExecutionContext context)
        {
            DepotTypeDict = new Dictionary<string, Type>();
            var cdt = typeof(ColumnData).Assembly.GetTypes().Where(t => t.IsSubclassOf(typeof(ColumnData)) && !t.IsAbstract);
            foreach (var dt in cdt)
            {
                var attr = (DepotTypeBinding) dt.GetCustomAttribute(typeof(DepotTypeBinding));
                if(attr != null && attr.BindingTypeStr != "skip")
                {
                    Console.WriteLine($"columntype {dt.Name} contribtuing {attr.BindingTypeStr}");
                    DepotTypeDict.Add(attr.BindingTypeStr,dt);
                }
            }
            
            //name/contens
            Dictionary<string,string> files = new Dictionary<string,string>();
// #if DEBUGGENERATOR
//             var testBody = System.IO.File.ReadAllText($"{Environment.CurrentDirectory}/core.cmod");
//             files.Add("test",testBody);
// #else
            IEnumerable<(bool generateDepotSource, AdditionalText additionalText)> options = GetLoadOptions(context);
            var depotFiles = options.Where(x => x.generateDepotSource);
            foreach (var file in depotFiles)
            {
                files.Add(Path.GetFileNameWithoutExtension(file.additionalText.Path),file.additionalText.GetText().ToString());
            }
// #endif
            var depotFileDatas = new List<DepotFileData>();
            var dir = Environment.CurrentDirectory;

            foreach (var depotFile in files)
            {
                var depotFileName = depotFile.Key;
                var depotFileText = depotFile.Value;
                using (JsonDocument document = JsonDocument.Parse(depotFileText))
                {
                    var DepotFileData = new DepotFileData(depotFileName,depotFileText,document.RootElement);
                    depotFileDatas.Add(DepotFileData);
                    foreach (var sheet in DepotFileData.Sheets.Where(x => !(x is SubsheetData)))
                    {
                        var cw = new CodeWriter();
                        cw.AddLine("using System.IO;");
                        cw.AddLine("using Depot.Core;");
                        cw.OpenScope($"namespace Depot.Generated.{DepotFileData.WriteSafeName}");
                        BuildSheet(cw,sheet);
                        cw.CloseScope();
                        context.AddSource($"{depotFileName}.{sheet.WriteSafeName}", cw.ToString());
                    }
                }
            }

            Logs = Logs.OrderBy(x => x).ToList();
            context.AddSource("Depot.LogOutput", $"/*{Environment.NewLine}{String.Join(Environment.NewLine,Logs)}{Environment.NewLine}*/");

#region Depot.Core.cs
            /*
                this defines the base types for a depot file
            */
            var coreTypesWriter = new CodeWriter();
            coreTypesWriter.AddLine("using System;");
            coreTypesWriter.AddLine("using System.Collections.Generic;");
            coreTypesWriter.OpenScope("namespace Depot.Core");

                coreTypesWriter.OpenScope("public abstract class DepotItem");
                    coreTypesWriter.AddLine("string guid;");
                    coreTypesWriter.AddLine("public virtual string GUID {get {return guid;}}");
                    coreTypesWriter.OpenScope("protected void SetGuid(string guid)");
                        coreTypesWriter.AddLine("this.guid = guid;");
                    coreTypesWriter.CloseScope();
                coreTypesWriter.CloseScope();

                coreTypesWriter.OpenScope("public abstract class DepotSheet : DepotItem");
                    coreTypesWriter.AddLine("// public abstract JsonNode Node {get;}");
                    coreTypesWriter.AddLine("public abstract string Name {get;}");
                    coreTypesWriter.AddLine("public abstract string Description {get;}");
                coreTypesWriter.CloseScope();

                coreTypesWriter.OpenScope("public abstract class DepotSheetLine : DepotItem");
                    coreTypesWriter.AddLine("// public abstract JsonNode Node {get;}");
                    coreTypesWriter.AddLine("public string ID {get; protected set;}");
                coreTypesWriter.CloseScope();
                
                coreTypesWriter.AddLine("public abstract class DepotProps : DepotItem {}");

            coreTypesWriter.CloseScope();


            context.AddSource("Depot.Core", coreTypesWriter.ToString());
#endregion

            void BuildSheet(CodeWriter cw, SheetData sheet)
            {
                if(sheet.IsProps)
                {
                    cw.OpenScope($"public class {sheet.WriteSafeName}Props : DepotProps");
                }
                else
                {
                    if(!(sheet is SubsheetData))
                    {
                        // cw.OpenScope($"public class {sheet.WriteSafeName} : DepotSheet, IUsesSheetLines<{sheet.WriteSafeName}.{sheet.WriteSafeName}Line>");
                        cw.OpenScope($"public class {sheet.WriteSafeName} : DepotSheet");
                    }
                    else
                    {
                        cw.OpenScope($"public class {sheet.WriteSafeName}List : DepotSheet");
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
                    cw.OpenScope($"public {sheet.WriteSafeName}Props({String.Join(",",sheet.Columns.Select(x => $"{x.CSharpType} {x.Name}"))})");
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

            void BuildIntermediaryTypes(CodeWriter cw, SheetData sheet)
            {
                foreach (IRequiresIntermediateType column in sheet.Columns.Where(x => x is IRequiresIntermediateType))
                {
                    column.BuildType(cw,sheet);
                }
            }

            string BuildSheetLineClass(CodeWriter cw, SheetData sheet)
            {
                var lineclassname = "";
                if(sheet is SubsheetData)
                {
                    lineclassname = $"{sheet.WriteSafeName}ListLine";
                }
                else
                {
                    lineclassname = $"{sheet.WriteSafeName}Line";
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
                return cw.ToString();
            }

            void BuildSheetLineReferenceClass(CodeWriter cw, SheetData sheet)
            {
                cw.OpenScope($"public class {sheet.WriteSafeName}LineReference");
                    cw.AddLine("public string LineGuid {get; protected set;}");
                    cw.AddLine($"{sheet.WriteSafeName}.{sheet.WriteSafeName}Line line;");
                    cw.OpenScope($"public {sheet.WriteSafeName}.{sheet.WriteSafeName}Line Line");
                        cw.OpenScope($"get");
                            cw.OpenScope($"if(line == null)");
                                cw.AddLine($"SetupReference();");
                            cw.CloseScope();
                            cw.AddLine("return line;");
                        cw.CloseScope();
                        cw.OpenScope($"set");
                            cw.AddLine("line = value;");
                        cw.CloseScope();
                    cw.CloseScope();
                    cw.OpenScope($"public {sheet.WriteSafeName}LineReference(string guid)");
                        cw.AddLine($"LineGuid = guid;");
                    cw.CloseScope();
                    cw.OpenScope("void SetupReference()");
                        cw.AddLine($"Line = {sheet.WriteSafeName}.Lines.Find(x => x.GUID == LineGuid);");
                    cw.CloseScope();
                cw.CloseScope();
            }

            string BuildSheetLines(CodeWriter cw, SheetData sheet) //NOTE: only top line sheets have this
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
                            var column = sheet.Columns.Where(x => x.GetRawName() == item.Key).FirstOrDefault();
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
                    lineItems.Add($"public static {sheet.WriteSafeName}Line {line.WriteSafeID} = new {sheet.WriteSafeName}Line({string.Join(",",lineValues)});");
                }

                foreach (var line in lineItems)
                {
                    cw.AddLine(line);
                }

                cw.OpenScope($"public static List<{sheet.WriteSafeName}Line> Lines = new List<{sheet.WriteSafeName}Line>()");
                foreach (var line in sheet.Lines)
                {
                    var c = line == sheet.Lines.Last() ? "" : ",";
                    cw.AddLine($"{line.WriteSafeID}{c}");
                }
                cw.CloseScope(";");

                return cw.ToString();
            }

            
        }

        public void Initialize(GeneratorInitializationContext context)
        {
            // if (!Debugger.IsAttached)
            // {
            //     Debugger.Launch();
            // }
            // No initialization required for this one
        }

        static IEnumerable<(bool, AdditionalText)> GetLoadOptions(GeneratorExecutionContext context)
        {
            foreach (AdditionalText file in context.AdditionalFiles)
            {
                context.AnalyzerConfigOptions.GetOptions(file).TryGetValue("build_metadata.AdditionalFiles.GenerateDepotSource", out string generateDepotSourceString);
                bool.TryParse(generateDepotSourceString, out bool generateDepotSource);
                yield return (generateDepotSource,file);
            }
        }
    }
}
