using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Objects;

namespace Data.Interfaces
{
    interface IHasKeyAndUser:IHasKey
    {
        User User { get; set; }
    }
}
