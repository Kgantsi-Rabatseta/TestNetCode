using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Interfaces;

namespace Data.Objects
{
    public class HasKeyAndUser:HasKey
    {
        public User User { get; set; }
    }
}
