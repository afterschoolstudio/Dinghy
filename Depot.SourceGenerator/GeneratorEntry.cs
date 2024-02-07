using System.Collections.Generic;
using System.IO;
using Afterschool.Common.Extensions;
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
    
        // If you would like to put some data to non-compilable file (e.g. a .txt file), mark it as an Additional File.
        // Go through all files marked as an Additional File in file properties.
        List<(AdditionalText,string)> resFiles = new ();
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
        
        NEED TO TIE THIS TO THE ACTUAL DEPOT GENERATOR
        AssetRouter.HandleResFiles(context,resFiles);
    }
}