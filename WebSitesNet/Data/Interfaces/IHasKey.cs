using System;

namespace Data.Interfaces
{
    public interface IHasKey
    {
        Guid Key { get; set; }
        int Version { get; set; }
    }
}