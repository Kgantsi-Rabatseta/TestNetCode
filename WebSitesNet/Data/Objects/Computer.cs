using System;

namespace Data.Objects
{
    public class Computer:HasKey
    {
        public string ComputerName { get { return Environment.MachineName; }}
        public string DomainName { get { return Environment.UserDomainName; } }
        public string DomainUserName { get { return Environment.UserName; } }
    }
}