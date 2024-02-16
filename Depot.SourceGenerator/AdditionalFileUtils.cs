using System.Collections.Generic;
using Microsoft.CodeAnalysis;

namespace Depot.SourceGenerator;

public static class AdditionalFileUtils
{
    //https://github.com/dotnet/roslyn/blob/main/docs/features/source-generators.cookbook.md#access-analyzer-config-properties
    //https://github.com/dotnet/roslyn/blob/main/docs/features/source-generators.cookbook.md#consume-msbuild-properties-and-metadata
    public static IEnumerable<(bool, AdditionalText)> GetLoadOptions(GeneratorExecutionContext context)
    {
        //this basically searches to see if we want to actually generate depot source for a file
        //could also add in other options here
        foreach (AdditionalText file in context.AdditionalFiles)
        {
            context.AnalyzerConfigOptions.GetOptions(file).TryGetValue("build_metadata.AdditionalFiles.GenerateDepotSource", out string generateDepotSourceString);
            bool.TryParse(generateDepotSourceString, out bool generateDepotSource);
            yield return (generateDepotSource,file);
        }
    }
}