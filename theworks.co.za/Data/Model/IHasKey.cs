using System;

namespace Data.Model
{
    public interface IHasKey
    {
        Guid Key { get; set; }
        int Version { get; set; }
        DateTime DateInserted { get; set; }
        bool NoKey();
    }
}