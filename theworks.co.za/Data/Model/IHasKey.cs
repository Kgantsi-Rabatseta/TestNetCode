using System;

namespace Data.Model
{
    public interface IHasKey
    {
        Guid Key { get; set; }
        bool NoKey();
    }
}