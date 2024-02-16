using System;
using System.IO;

namespace Afterschool.Common.Extensions
{
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
}