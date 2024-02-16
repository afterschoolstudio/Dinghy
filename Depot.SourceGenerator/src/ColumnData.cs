using System;
using System.Text.Json;
using System.Linq;
using System.Collections.Generic;

namespace Depot.SourceGenerator
{
    public abstract class ColumnData
    {
        public string Name {get;}
        public string RawName {get;}
        public string GUID {get;}
        public JsonElement JsonElement { get;}
        public SheetData ParentSheet {get;}
        public DepotFileData ParentFile => ParentSheet.ParentDepotFile;
        public ColumnData(JsonElement e, SheetData parentSheet)
        {
            JsonElement = e;
            ParentSheet = parentSheet;
            RawName = e.GetProperty("name").GetString();
            Name = File.SanitizeFilename(RawName);
            GUID = e.GetProperty("guid").GetString();
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
        void BuildType(Utils.CodeWriter cw, SheetData d);
    }
}

