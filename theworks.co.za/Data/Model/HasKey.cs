using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Model
{
    public class HasKey:IHasKey
    {
        public Guid Key { get; set; }
        public bool NoKey()
        {
            return Key.Equals(Guid.Empty);
        }

        public int Version { get; set; }
        public DateTime DateInserted { get; set; }
    }
}
