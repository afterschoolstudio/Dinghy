using System.Collections.Generic;
using System.IO;
using Microsoft.CodeAnalysis;

namespace Depot.SourceGenerator;

[Generator]
public class GeneratorEntry : ISourceGenerator
{
    public void Initialize(GeneratorInitializationContext context)
    {
        // No initialization required for this generator.
    }

    public void Execute(GeneratorExecutionContext context)
    {
        context.AnalyzerConfigOptions.GlobalOptions.TryGetValue("build_property.projectdir",
            out string? projectDirectoryPath);
        var resPath = new DirectoryInfo(Path.Combine(projectDirectoryPath, "res"));
    
        List<(AdditionalText additionalText,string extension)> resFiles = new ();
        foreach (var additionalFile in context.AdditionalFiles)
        {
            if (additionalFile == null)
                continue;
        
            //see if we are something in res/
            if (resPath.ContainsPath(additionalFile.Path))
            {
                //could do different processing here based on some meta in .zinc or something
                var ext = Path.GetExtension(additionalFile.Path);
                if (ext == null)
                    continue;
                resFiles.Add((additionalFile,ext));
            }
            //could check for other dirs with a .zinc in them or something?
        }

        bool generatedConst = false;
        foreach (var f in resFiles)
        {
            if (f.extension == ".depot" || f.extension == ".dpo")
            {
                if (!generatedConst)
                {
                    context.AddSource($"Depot.Core.cs", ConstantSourceFiles.Core);
                    generatedConst = true;
                }
                // could use AdditionalText stuff to filter on if we want to generate source, other options, etc.
                // IEnumerable<(bool generateDepotSource, AdditionalText additionalText)> options = AdditionalFileUtils.GetLoadOptions(context);
                // var depotFiles = options.Where(x => x.generateDepotSource);
                // foreach (var file in depotFiles)
                // {
                //     files.Add(Path.GetFileNameWithoutExtension(file.additionalText.Path),file.additionalText.GetText().ToString());
                // }
                DepotSourceGenerator.GenerateSource(f.additionalText, context);
            }
        }
        
        // context.AddSource("Logs.g.cs","//log test");
    }
}