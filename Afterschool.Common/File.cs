using System.IO;
using System.Text.RegularExpressions;

namespace Afterschool.Common
{
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
}