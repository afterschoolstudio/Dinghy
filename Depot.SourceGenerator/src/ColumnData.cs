using System;
using System.Text.Json;
using System.Linq;
using System.Collections.Generic;
using Afterschool.Common;
using CodeWriter = Afterschool.Common.Utils.CodeWriter;

namespace Depot.SourceGenerator
{
    public abstract class ColumnData
    {
        public string Name {get;}
        // public string RawName {get;}
        public string GUID {get;}
        public JsonElement JsonElement { get;}
        public SheetData ParentSheet {get;}
        public DepotFileData ParentFile => ParentSheet.ParentDepotFile;
        public ColumnData(JsonElement e, SheetData parentSheet)
        {
            JsonElement = e;
            ParentSheet = parentSheet;
            Name = File.SanitizeFilename(e.GetProperty("name").GetString());
            GUID = e.GetProperty("guid").GetString();
        }
        public string GetRawName()
        {
            return JsonElement.GetProperty("name").GetString();
        }
        /// <summary>
        /// This type is used to build the constructors for a type
        /// </summary>
        /// <value></value>
        public abstract string CSharpType {get;}
        /// <summary>
        /// This wraps the passed in object value as the type of this column. This is used as the actual constructor values.
        /// </summary>
        /// <param name="configuringLine">Parent confguring line</param>
        /// <param name="o">Value from Depot</param>
        /// <returns>String value to be placed directly in constructor</returns>
        public abstract string GetValue(LineData configuringLine, object o);
    }

    public interface IRequiresIntermediateType
    {
        void BuildType(CodeWriter cw, SheetData d);
    }

    [System.AttributeUsage(System.AttributeTargets.Class)]  
    public class DepotTypeBinding : Attribute
    {
        public string BindingTypeStr {get; protected set;}
        public DepotTypeBinding(string typeStr)
        {
            BindingTypeStr = typeStr;
        }
    }
}

