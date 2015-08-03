using System;
using Data.Interfaces;

namespace Data.Objects
{
    public class User : HasKey
    {
        public String UserName { get; set; }
        public String Password { get; set; }
        public String OldPassword { get; set; }
        public String EmailAddress { get; set; }
        public DateTime LastAccessDate { get; set; }
        public Computer Computer { get; set; }
    }
}