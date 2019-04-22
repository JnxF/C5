// This file is part of the C5 Generic Collection Library for C# and CLI
// See https://github.com/sestoft/C5/blob/master/LICENSE.txt for licensing details.

using System;
using SCG = System.Collections.Generic;
namespace C5
{
    [Serializable]
    abstract class MappedDirectedEnumerable<T, V> : EnumerableBase<V>, IDirectedEnumerable<V>
    {
#pragma warning disable IDE0044 // Add readonly modifier
        IDirectedEnumerable<T> directedenumerable;
#pragma warning restore IDE0044 // Add readonly modifier

        abstract public V Map(T item);

        public MappedDirectedEnumerable(IDirectedEnumerable<T> directedenumerable)
        {
            this.directedenumerable = directedenumerable;
        }

        public IDirectedEnumerable<V> Backwards()
        {
            MappedDirectedEnumerable<T, V> retval = (MappedDirectedEnumerable<T, V>)MemberwiseClone();
            retval.directedenumerable = directedenumerable.Backwards();
            return retval;
            //If we made this classs non-abstract we could do
            //return new MappedDirectedCollectionValue<T,V>(directedcollectionvalue.Backwards());;
        }


        public override SCG.IEnumerator<V> GetEnumerator()
        {
            foreach (T item in directedenumerable)
                yield return Map(item);
        }

        public EnumerationDirection Direction
        {
            get { return directedenumerable.Direction; }
        }
    }
}