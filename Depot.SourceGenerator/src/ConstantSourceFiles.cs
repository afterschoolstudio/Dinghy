namespace Depot.SourceGenerator;

public static class ConstantSourceFiles
{
    public static readonly string Core = @"
using System;
using System.Collections.Generic;

namespace Depot.Core
{
    public abstract class DepotItem
    {
        string guid;
        public virtual string GUID => guid;
        protected void SetGuid(string guid)
        {
            this.guid = guid;
        }
    }

    public abstract class DepotSheet : DepotItem
    {
        public abstract string Name {get;}
        public abstract string Description {get;}
    }

    public abstract class DepotSheetLine : DepotItem
    {
        public string ID {get; protected set;}
    }

    public abstract class DepotProps : DepotItem {}
}
";
}