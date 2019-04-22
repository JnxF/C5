// This file is part of the C5 Generic Collection Library for C# and CLI
// See https://github.com/sestoft/C5/blob/master/LICENSE.txt for licensing details.

using System;
namespace C5
{
    [Serializable]
    class MultiplicityOne<K> : MappedCollectionValue<K, KeyValuePair<K, int>>
    {
        public MultiplicityOne(ICollectionValue<K> coll) : base(coll) { }
        public override KeyValuePair<K, int> Map(K k) { return new KeyValuePair<K, int>(k, 1); }
    }
}