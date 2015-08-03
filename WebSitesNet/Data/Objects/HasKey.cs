using System;
using Data.Interfaces;

namespace Data.Objects
{
    public class HasKey:IHasKey
    {
        private Guid _key;
        public Guid Key { get { return GenerateKey(); } set { _key = value; } }
        public int Version { get; set; }
        private Guid GenerateKey()
        {
            if (_key == Guid.Empty) 
                _key = Guid.NewGuid();
            return _key;
        }
    }
}