// This file is part of the C5 Generic Collection Library for C# and CLI
// See https://github.com/sestoft/C5/blob/master/LICENSE.txt for licensing details.

using System;
using SCG = System.Collections.Generic;
namespace C5
{
    [Serializable]
    abstract class MappedCollectionValue<T, V> : CollectionValueBase<V>, ICollectionValue<V>
    {
        readonly ICollectionValue<T> collectionvalue;

        abstract public V Map(T item);

        public MappedCollectionValue(ICollectionValue<T> collectionvalue)
        {
            this.collectionvalue = collectionvalue;
        }

        public override V Choose() { return Map(collectionvalue.Choose()); }

        public override bool IsEmpty { get { return collectionvalue.IsEmpty; } }

        public override int Count { get { return collectionvalue.Count; } }

        public override Speed CountSpeed { get { return collectionvalue.CountSpeed; } }

        public override SCG.IEnumerator<V> GetEnumerator()
        {
            foreach (T item in collectionvalue)
                yield return Map(item);
        }
    }
}