// This file is part of the C5 Generic Collection Library for C# and CLI
// See https://github.com/sestoft/C5/blob/master/LICENSE.txt for licensing details.

using System;
using SCG = System.Collections.Generic;
namespace C5
{
    [Serializable]
    abstract class MappedDirectedCollectionValue<T, V> : DirectedCollectionValueBase<V>, IDirectedCollectionValue<V>
    {
#pragma warning disable IDE0044 // Add readonly modifier
        IDirectedCollectionValue<T> directedcollectionvalue;
#pragma warning restore IDE0044 // Add readonly modifier

        abstract public V Map(T item);

        public MappedDirectedCollectionValue(IDirectedCollectionValue<T> directedcollectionvalue)
        {
            this.directedcollectionvalue = directedcollectionvalue;
        }

        public override V Choose() { return Map(directedcollectionvalue.Choose()); }

        public override bool IsEmpty { get { return directedcollectionvalue.IsEmpty; } }

        public override int Count { get { return directedcollectionvalue.Count; } }

        public override Speed CountSpeed { get { return directedcollectionvalue.CountSpeed; } }

        public override IDirectedCollectionValue<V> Backwards()
        {
            MappedDirectedCollectionValue<T, V> retval = (MappedDirectedCollectionValue<T, V>)MemberwiseClone();
            retval.directedcollectionvalue = directedcollectionvalue.Backwards();
            return retval;
            //If we made this classs non-abstract we could do
            //return new MappedDirectedCollectionValue<T,V>(directedcollectionvalue.Backwards());;
        }


        public override SCG.IEnumerator<V> GetEnumerator()
        {
            foreach (T item in directedcollectionvalue)
                yield return Map(item);
        }

        public override EnumerationDirection Direction
        {
            get { return directedcollectionvalue.Direction; }
        }

        IDirectedEnumerable<V> IDirectedEnumerable<V>.Backwards()
        {
            return Backwards();
        }


    }
}