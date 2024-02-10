using System;
using System.Text.Json;
using System.Linq;
using System.Collections.Generic;

namespace Depot.SourceGenerator
{
    public class SheetData
    {
        public string RawName {get;}
        public string Name {get;}
        public string Description {get;}
        public string GUID {get;}
        public bool Hidden {get;}
        public bool IsProps {get;}
        public DepotFileData ParentDepotFile {get;}
        public JsonElement JsonElement {get;}
        public List<LineData> Lines {get; protected set;}
        public List<ColumnData> Columns {get; protected set;}
        public string DataPath => ParentDepotFile.GetPathToSheet(this);
        public SheetData(JsonElement e, DepotFileData parentDepotFile)
        {
            JsonElement = e;
            ParentDepotFile = parentDepotFile;
            RawName = e.GetProperty("name").GetString();
            Name = File.SanitizeFilename(RawName);
            Description = e.GetProperty("description").GetString();
            GUID = e.GetProperty("guid").GetString();
            Hidden = e.GetProperty("hidden").GetBoolean();
            IsProps = false; //old sheets dont have this already defined (but those sheets were also never props)
            if(e.TryGetProperty("isProps", out var p))
            {
                IsProps = p.GetBoolean();
            }
        }

        public void InitColumns()
        {
            Columns = new List<ColumnData>(){
                new Guid(this)
            };
            if(!IsProps)
            {
                Columns.Add(new Id(this));
            }
            foreach (var column in JsonElement.GetProperty("columns").EnumerateArray())
            {
                var type = DepotSourceGenerator.DepotTypeDict[column.GetProperty("typeStr").ToString()];
                var cd = (ColumnData) Activator.CreateInstance(type,column,this);
                Columns.Add(cd);
            }

            Columns = Columns.OrderBy(x => x.Name).ToList();
        }
        
        public void InitLines()
        {
            Lines = new List<LineData>();
            foreach (var line in JsonElement.GetProperty("lines").EnumerateArray())
            {
                Lines.Add(new LineData(line,this));
            }
        }
    }

    public class SubsheetData : SheetData
    {
        public string ParentSheetGUID {get;}
        public string ColumnGUID {get;}
        public SubsheetData(JsonElement e, DepotFileData d) : base(e,d)
        {
            ParentSheetGUID = e.GetProperty("parentSheetGUID").GetString();
            ColumnGUID = e.GetProperty("columnGUID").GetString();
        }

    }
}