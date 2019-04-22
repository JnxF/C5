﻿// This file is part of the C5 Generic Collection Library for C# and CLI
// See https://github.com/sestoft/C5/blob/master/LICENSE.txt for licensing details.

using System;
using SCG = System.Collections.Generic;
namespace C5
{
    /// <summary>
    /// A base class for implementing a sorted dictionary based on a sorted set collection implementation.
    /// <i>See the source code for <see cref="T:C5.TreeDictionary`2"/> for an example</i>
    /// 
    /// </summary>
    [Serializable]
    public abstract class SortedDictionaryBase<K, V> : DictionaryBase<K, V>, ISortedDictionary<K, V>
    {
        #region Fields

        /// <summary>
        /// 
        /// </summary>
        protected ISorted<KeyValuePair<K, V>> sortedpairs;
        SCG.IComparer<K> keycomparer;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keycomparer"></param>
        /// <param name="keyequalityComparer"></param>
        protected SortedDictionaryBase(SCG.IComparer<K> keycomparer, SCG.IEqualityComparer<K> keyequalityComparer) : base(keyequalityComparer) { this.keycomparer = keycomparer; }

        #endregion

        #region ISortedDictionary<K,V> Members

        /// <summary>
        /// The key comparer used by this dictionary.
        /// </summary>
        /// <value></value>
        public SCG.IComparer<K> Comparer { get { return keycomparer; } }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public new ISorted<K> Keys { get { return new SortedKeysCollection(this, sortedpairs, keycomparer, EqualityComparer); } }

        /// <summary>
        /// Find the entry in the dictionary whose key is the
        /// predecessor of the specified key.
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="res">The predecessor, if any</param>
        /// <returns>True if key has a predecessor</returns>
        public bool TryPredecessor(K key, out KeyValuePair<K, V> res)
        {
            return sortedpairs.TryPredecessor(new KeyValuePair<K, V>(key), out res);
        }

        /// <summary>
        /// Find the entry in the dictionary whose key is the
        /// successor of the specified key.
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="res">The successor, if any</param>
        /// <returns>True if the key has a successor</returns>
        public bool TrySuccessor(K key, out KeyValuePair<K, V> res)
        {
            return sortedpairs.TrySuccessor(new KeyValuePair<K, V>(key), out res);
        }

        /// <summary>
        /// Find the entry in the dictionary whose key is the
        /// weak predecessor of the specified key.
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="res">The predecessor, if any</param>
        /// <returns>True if key has a weak predecessor</returns>
        public bool TryWeakPredecessor(K key, out KeyValuePair<K, V> res)
        {
            return sortedpairs.TryWeakPredecessor(new KeyValuePair<K, V>(key), out res);
        }

        /// <summary>
        /// Find the entry in the dictionary whose key is the
        /// weak successor of the specified key.
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="res">The weak successor, if any</param>
        /// <returns>True if the key has a weak successor</returns>
        public bool TryWeakSuccessor(K key, out KeyValuePair<K, V> res)
        {
            return sortedpairs.TryWeakSuccessor(new KeyValuePair<K, V>(key), out res);
        }

        /// <summary>
        /// Get the entry in the dictionary whose key is the
        /// predecessor of the specified key.
        /// </summary>
        /// <exception cref="NoSuchItemException"></exception>
        /// <param name="key">The key</param>
        /// <returns>The entry</returns>
        public KeyValuePair<K, V> Predecessor(K key)
        {
            return sortedpairs.Predecessor(new KeyValuePair<K, V>(key));
        }

        /// <summary>
        /// Get the entry in the dictionary whose key is the
        /// successor of the specified key.
        /// </summary>
        /// <exception cref="NoSuchItemException"></exception>
        /// <param name="key">The key</param>
        /// <returns>The entry</returns>
        public KeyValuePair<K, V> Successor(K key)
        {
            return sortedpairs.Successor(new KeyValuePair<K, V>(key));
        }

        /// <summary>
        /// Get the entry in the dictionary whose key is the
        /// weak predecessor of the specified key.
        /// </summary>
        /// <exception cref="NoSuchItemException"></exception>
        /// <param name="key">The key</param>
        /// <returns>The entry</returns>
        public KeyValuePair<K, V> WeakPredecessor(K key)
        {
            return sortedpairs.WeakPredecessor(new KeyValuePair<K, V>(key));
        }

        /// <summary>
        /// Get the entry in the dictionary whose key is the
        /// weak successor of the specified key.
        /// </summary>
        /// <exception cref="NoSuchItemException"></exception>
        /// <param name="key">The key</param>
        /// <returns>The entry</returns>
        public KeyValuePair<K, V> WeakSuccessor(K key)
        {
            return sortedpairs.WeakSuccessor(new KeyValuePair<K, V>(key));
        }

        #endregion

        #region ISortedDictionary<K,V> Members

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public KeyValuePair<K, V> FindMin()
        {
            return sortedpairs.FindMin();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public KeyValuePair<K, V> DeleteMin()
        {
            return sortedpairs.DeleteMin();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public KeyValuePair<K, V> FindMax()
        {
            return sortedpairs.FindMax();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public KeyValuePair<K, V> DeleteMax()
        {
            return sortedpairs.DeleteMax();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cutter"></param>
        /// <param name="lowEntry"></param>
        /// <param name="lowIsValid"></param>
        /// <param name="highEntry"></param>
        /// <param name="highIsValid"></param>
        /// <returns></returns>
        public bool Cut(IComparable<K> cutter, out KeyValuePair<K, V> lowEntry, out bool lowIsValid, out KeyValuePair<K, V> highEntry, out bool highIsValid)
        {
            return sortedpairs.Cut(new KeyValuePairComparable(cutter), out lowEntry, out lowIsValid, out highEntry, out highIsValid);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bot"></param>
        /// <returns></returns>
        public IDirectedEnumerable<KeyValuePair<K, V>> RangeFrom(K bot)
        {
            return sortedpairs.RangeFrom(new KeyValuePair<K, V>(bot));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bot"></param>
        /// <param name="top"></param>
        /// <returns></returns>
        public IDirectedEnumerable<KeyValuePair<K, V>> RangeFromTo(K bot, K top)
        {
            return sortedpairs.RangeFromTo(new KeyValuePair<K, V>(bot), new KeyValuePair<K, V>(top));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="top"></param>
        /// <returns></returns>
        public IDirectedEnumerable<KeyValuePair<K, V>> RangeTo(K top)
        {
            return sortedpairs.RangeTo(new KeyValuePair<K, V>(top));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IDirectedCollectionValue<KeyValuePair<K, V>> RangeAll()
        {
            return sortedpairs.RangeAll();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        public void AddSorted(SCG.IEnumerable<KeyValuePair<K, V>> items)
        {
            sortedpairs.AddSorted(items);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lowKey"></param>
        public void RemoveRangeFrom(K lowKey)
        {
            sortedpairs.RemoveRangeFrom(new KeyValuePair<K, V>(lowKey));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lowKey"></param>
        /// <param name="highKey"></param>
        public void RemoveRangeFromTo(K lowKey, K highKey)
        {
            sortedpairs.RemoveRangeFromTo(new KeyValuePair<K, V>(lowKey), new KeyValuePair<K, V>(highKey));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="highKey"></param>
        public void RemoveRangeTo(K highKey)
        {
            sortedpairs.RemoveRangeTo(new KeyValuePair<K, V>(highKey));
        }

        #endregion
        [Serializable]
        class KeyValuePairComparable : IComparable<KeyValuePair<K, V>>
        {
            IComparable<K> cutter;

            internal KeyValuePairComparable(IComparable<K> cutter) { this.cutter = cutter; }

            public int CompareTo(KeyValuePair<K, V> other) { return cutter.CompareTo(other.Key); }

            public bool Equals(KeyValuePair<K, V> other) { return cutter.Equals(other.Key); }
        }

        [Serializable]
        class ProjectedDirectedEnumerable : MappedDirectedEnumerable<KeyValuePair<K, V>, K>
        {
            public ProjectedDirectedEnumerable(IDirectedEnumerable<KeyValuePair<K, V>> directedpairs) : base(directedpairs) { }

            public override K Map(KeyValuePair<K, V> pair) { return pair.Key; }

        }

        [Serializable]
        class ProjectedDirectedCollectionValue : MappedDirectedCollectionValue<KeyValuePair<K, V>, K>
        {
            public ProjectedDirectedCollectionValue(IDirectedCollectionValue<KeyValuePair<K, V>> directedpairs) : base(directedpairs) { }

            public override K Map(KeyValuePair<K, V> pair) { return pair.Key; }

        }

        [Serializable]
        class SortedKeysCollection : SequencedBase<K>, ISorted<K>
        {
            ISortedDictionary<K, V> sorteddict;
            //TODO: eliminate this. Only problem is the Find method because we lack method on dictionary that also 
            //      returns the actual key.
            ISorted<KeyValuePair<K, V>> sortedpairs;
            SCG.IComparer<K> comparer;

            internal SortedKeysCollection(ISortedDictionary<K, V> sorteddict, ISorted<KeyValuePair<K, V>> sortedpairs, SCG.IComparer<K> comparer, SCG.IEqualityComparer<K> itemequalityComparer)
                : base(itemequalityComparer)
            {
                this.sorteddict = sorteddict;
                this.sortedpairs = sortedpairs;
                this.comparer = comparer;
            }

            public override K Choose() { return sorteddict.Choose().Key; }

            public override SCG.IEnumerator<K> GetEnumerator()
            {
                foreach (KeyValuePair<K, V> p in sorteddict)
                    yield return p.Key;
            }

            public override bool IsEmpty { get { return sorteddict.IsEmpty; } }

            public override int Count { get { return sorteddict.Count; } }

            public override Speed CountSpeed { get { return sorteddict.CountSpeed; } }

            #region ISorted<K> Members

            public K FindMin() { return sorteddict.FindMin().Key; }

            public K DeleteMin() { throw new ReadOnlyCollectionException(); }

            public K FindMax() { return sorteddict.FindMax().Key; }

            public K DeleteMax() { throw new ReadOnlyCollectionException(); }

            public SCG.IComparer<K> Comparer { get { return comparer; } }

            public bool TryPredecessor(K item, out K res)
            {
                bool success = sorteddict.TryPredecessor(item, out KeyValuePair<K, V> pRes);
                res = pRes.Key;
                return success;
            }

            public bool TrySuccessor(K item, out K res)
            {
                bool success = sorteddict.TrySuccessor(item, out KeyValuePair<K, V> pRes);
                res = pRes.Key;
                return success;
            }

            public bool TryWeakPredecessor(K item, out K res)
            {
                bool success = sorteddict.TryWeakPredecessor(item, out KeyValuePair<K, V> pRes);
                res = pRes.Key;
                return success;
            }

            public bool TryWeakSuccessor(K item, out K res)
            {
                bool success = sorteddict.TryWeakSuccessor(item, out KeyValuePair<K, V> pRes);
                res = pRes.Key;
                return success;
            }

            public K Predecessor(K item) { return sorteddict.Predecessor(item).Key; }

            public K Successor(K item) { return sorteddict.Successor(item).Key; }

            public K WeakPredecessor(K item) { return sorteddict.WeakPredecessor(item).Key; }

            public K WeakSuccessor(K item) { return sorteddict.WeakSuccessor(item).Key; }

            public bool Cut(IComparable<K> c, out K low, out bool lowIsValid, out K high, out bool highIsValid)
            {
                bool retval = sorteddict.Cut(c, out KeyValuePair<K, V> lowpair, out lowIsValid, out KeyValuePair<K, V> highpair, out highIsValid);
                low = lowpair.Key;
                high = highpair.Key;
                return retval;
            }

            public IDirectedEnumerable<K> RangeFrom(K bot)
            {
                return new ProjectedDirectedEnumerable(sorteddict.RangeFrom(bot));
            }

            public IDirectedEnumerable<K> RangeFromTo(K bot, K top)
            {
                return new ProjectedDirectedEnumerable(sorteddict.RangeFromTo(bot, top));
            }

            public IDirectedEnumerable<K> RangeTo(K top)
            {
                return new ProjectedDirectedEnumerable(sorteddict.RangeTo(top));
            }

            public IDirectedCollectionValue<K> RangeAll()
            {
                return new ProjectedDirectedCollectionValue(sorteddict.RangeAll());
            }

            public void AddSorted(SCG.IEnumerable<K> items) { throw new ReadOnlyCollectionException(); }

            public void RemoveRangeFrom(K low) { throw new ReadOnlyCollectionException(); }

            public void RemoveRangeFromTo(K low, K hi) { throw new ReadOnlyCollectionException(); }

            public void RemoveRangeTo(K hi) { throw new ReadOnlyCollectionException(); }
            #endregion

            #region ICollection<K> Members
            public Speed ContainsSpeed { get { return sorteddict.ContainsSpeed; } }

            public bool Contains(K key) { return sorteddict.Contains(key); ; }

            public int ContainsCount(K item) { return sorteddict.Contains(item) ? 1 : 0; }

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public virtual ICollectionValue<K> UniqueItems()
            {
                return this;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public virtual ICollectionValue<KeyValuePair<K, int>> ItemMultiplicities()
            {
                return new MultiplicityOne<K>(this);
            }


            public bool ContainsAll(SCG.IEnumerable<K> items)
            {
                //TODO: optimize?
                foreach (K item in items)
                    if (!sorteddict.Contains(item))
                        return false;
                return true;
            }

            public bool Find(ref K item)
            {
                KeyValuePair<K, V> p = new KeyValuePair<K, V>(item);
                bool retval = sortedpairs.Find(ref p);
                item = p.Key;
                return retval;
            }

            public bool FindOrAdd(ref K item) { throw new ReadOnlyCollectionException(); }

            public bool Update(K item) { throw new ReadOnlyCollectionException(); }

            public bool Update(K item, out K olditem) { throw new ReadOnlyCollectionException(); }

            public bool UpdateOrAdd(K item) { throw new ReadOnlyCollectionException(); }

            public bool UpdateOrAdd(K item, out K olditem) { throw new ReadOnlyCollectionException(); }

            public bool Remove(K item) { throw new ReadOnlyCollectionException(); }

            public bool Remove(K item, out K removeditem) { throw new ReadOnlyCollectionException(); }

            public void RemoveAllCopies(K item) { throw new ReadOnlyCollectionException(); }

            public void RemoveAll(SCG.IEnumerable<K> items) { throw new ReadOnlyCollectionException(); }

            public void Clear() { throw new ReadOnlyCollectionException(); }

            public void RetainAll(SCG.IEnumerable<K> items) { throw new ReadOnlyCollectionException(); }

            #endregion

            #region IExtensible<K> Members
            public override bool IsReadOnly { get { return true; } }

            public bool AllowsDuplicates { get { return false; } }

            public bool DuplicatesByCounting { get { return true; } }

            public bool Add(K item) { throw new ReadOnlyCollectionException(); }

            void SCG.ICollection<K>.Add(K item) { throw new ReadOnlyCollectionException(); }

            public void AddAll(System.Collections.Generic.IEnumerable<K> items) { throw new ReadOnlyCollectionException(); }

            public bool Check() { return sorteddict.Check(); }

            #endregion

            #region IDirectedCollectionValue<K> Members

            public override IDirectedCollectionValue<K> Backwards()
            {
                return RangeAll().Backwards();
            }

            #endregion

            #region IDirectedEnumerable<K> Members

            IDirectedEnumerable<K> IDirectedEnumerable<K>.Backwards() { return Backwards(); }
            #endregion
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stringbuilder"></param>
        /// <param name="rest"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        public override bool Show(System.Text.StringBuilder stringbuilder, ref int rest, IFormatProvider formatProvider)
        {
            return Showing.ShowDictionary<K, V>(this, stringbuilder, ref rest, formatProvider);
        }

    }
}