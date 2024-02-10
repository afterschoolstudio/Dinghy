using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Depot.SourceGenerator;

public static class DirectoryInfoExtensions
{
    public static bool ContainsPath(this DirectoryInfo baseDir, string checkPath)
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

public static class File
{
    public static string SanitizeFilename(string input, string replacement = "_")
    {
        //https://gist.github.com/sergiorykov/219605a220edf80d4b55fe87a9f92b38
        
        // https://msdn.microsoft.com/en-us/library/aa365247.aspx#naming_conventions
        // http://stackoverflow.com/questions/146134/how-to-remove-illegal-characters-from-path-and-filenames
        Regex removeInvalidChars = new Regex($"[{Regex.Escape(new string(Path.GetInvalidFileNameChars()))}]",
            RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.CultureInvariant);
        var final = removeInvalidChars.Replace(input, replacement);
        final = final.Replace(" ","_");
        final = final.Replace("'","_");
        final = final.Replace("-","_");
        final = final.Replace(".","_");
        if(char.IsDigit(final[0]))
        {
            final = final.Insert(0,"_");
        }
        return final;
    }
}

public static partial class Utils
{
    public class CodeWriter
    {
        public int CurrentIndent { get; protected set; } = 0;
        StringBuilder sb = new StringBuilder();
        public void AddLine(string line) => sb.Append(new string('\t', CurrentIndent)).AppendLine(line);
        public void AddLine() => sb.AppendLine();
        public void Add(string line) => sb.Append(line);
        public override string ToString() => sb.ToString();
        public void OpenScope(string text)
        {
            sb.Append(new string('\t', CurrentIndent)).AppendLine(text);
            sb.Append(new string('\t', CurrentIndent)).AppendLine("{");
            CurrentIndent += 1;
        }

        public void CloseScope(string additionalLineText = "")
        {
            if (CurrentIndent > 0)
            {
                CurrentIndent--;
            }
            sb.Append(new string('\t', CurrentIndent)).AppendLine("}"+additionalLineText);
        }

        public void AddLines(string literalLines)
        {
            var lines = literalLines.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);
            foreach (var l in lines)
            {
                AddLine(l);
            }
        }
    }
}
