using System;
using System.IO;
using Microsoft.CodeAnalysis;

namespace Dinghy.Magic;

/// <summary>
/// A sample source generator that creates C# classes based on the text file (in this case, Domain Driven Design ubiquitous language registry).
/// When using a simple text file as a baseline, we can create a non-incremental source generator.
/// </summary>
[Generator]
public class SampleSourceGenerator : ISourceGenerator
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
        FileInfo f;
        foreach (var additionalFile in context.AdditionalFiles)
        {
            if (additionalFile == null)
                continue;
            
            //see if we are something in res/
            if (ContainsPath(resPath, additionalFile.Path))
            {
                //could do different processing here based on some meta in .zinc or something
                var ext = Path.GetExtension(additionalFile.Path);
                if (ext == null)
                    continue;
                AssetRouter.RouteAsset(context,additionalFile,ext);
                continue;
            }
            //could check for other dirs with a .zinc in them or something?
        }
    }
    
    public bool ContainsPath(DirectoryInfo baseDir, string checkPath)
    {
        // Get the full path of the base directory and the path to check
        string baseDirPath = Path.GetFullPath(baseDir.FullName).TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar) + Path.DirectorySeparatorChar;
        string checkFullPath = Path.GetFullPath(checkPath).TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar) + Path.DirectorySeparatorChar;

        // Normalize the paths by replacing backslashes with forward slashes
        baseDirPath = baseDirPath.Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar);
        checkFullPath = checkFullPath.Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar);

        // Check if the base directory path contains the check path
        return checkFullPath.StartsWith(baseDirPath, StringComparison.OrdinalIgnoreCase);
    }
}