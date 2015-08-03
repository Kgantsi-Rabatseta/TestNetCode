using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Data.Interfaces;
using Data.Objects;

namespace DataUtilities
{
    public class Builder:IBuilder
    {
        public static IHasKey BuildHasKey()
        {
            return new Keys().BuildAKey();
        }
        
        public static IList<IHasKey> BuildHasKeys(int numberOfKeys)
        {
            return new Keys().BuildKeys(numberOfKeys);
        }

        private class Keys
        {
            public IHasKey BuildAKey ()
            {
                return CreateKey(1);
            }

            public IList<IHasKey> BuildKeys(int numberOfKeys)
            {
                var keys = new List<IHasKey>();
                for (int i = 1; i <= numberOfKeys;i++ )
                {
                    keys.Add(CreateKey(i));
                }
                return keys;
            }

            private static IHasKey CreateKey(int keyNumber)
            {
                return new HasKey {Version = keyNumber};
            }
        }
    }
}