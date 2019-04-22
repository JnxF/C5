// This file is part of the C5 Generic Collection Library for C# and CLI
// See https://github.com/sestoft/C5/blob/master/LICENSE.txt for licensing details.

using System;
namespace C5
{
    [Serializable]
    class DropMultiplicity<K> : MappedCollectionValue<KeyValuePair<K, int>, K>
    {
        public DropMultiplicity(ICollectionValue<KeyValuePair<K, int>> coll) : base(coll) { }
        public override K Map(KeyValuePair<K, int> kvp) { return kvp.Key; }
    }
}