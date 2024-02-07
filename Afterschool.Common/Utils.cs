using System;
using System.Text;

namespace Afterschool.Common
{
    public static class Utils
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
                CurrentIndent -= 1;
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
}
