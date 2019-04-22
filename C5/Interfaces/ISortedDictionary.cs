// This file is part of the C5 Generic Collection Library for C# and CLI
// See https://github.com/sestoft/C5/blob/master/LICENSE.txt for licensing details.

using System;
using System.Collections.Generic;

namespace C5
{
    /// <summary>
    /// A dictionary with sorted keys.
    /// </summary>
    public interface ISortedDictionary<K, V> : IDictionary<K, V>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        new ISorted<K> Keys { get; }

        /// <summary>
        /// Find the current least item of this sorted collection.
        /// </summary>
        /// <exception cref="NoSuchItemException"> if the collection is empty.</exception>
        /// <returns>The least item.</returns>
        KeyValuePair<K, V> FindMin();


        /// <summary>
        /// Remove the least item from this sorted collection.
        /// </summary>
        /// <exception cref="NoSuchItemException"> if the collection is empty.</exception>
        /// <returns>The removed item.</returns>
        KeyValuePair<K, V> DeleteMin();


        /// <summary>
        /// Find the current largest item of this sorted collection.
        /// </summary>
        /// <exception cref="NoSuchItemException"> if the collection is empty.</exception>
        /// <returns>The largest item.</returns>
        KeyValuePair<K, V> FindMax();


        /// <summary>
        /// Remove the largest item from this sorted collection.
        /// </summary>
        /// <exception cref="NoSuchItemException"> if the collection is empty.</exception>
        /// <returns>The removed item.</returns>
        KeyValuePair<K, V> DeleteMax();

        /// <summary>
        /// The key comparer used by this dictionary.
        /// </summary>
        /// <value></value>
        System.Collections.Generic.IComparer<K> Comparer { get; }

        /// <summary>
        /// Find the entry in the dictionary whose key is the
        /// predecessor of the specified key.
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="res">The predecessor, if any</param>
        /// <returns>True if key has a predecessor</returns>
        bool TryPredecessor(K key, out KeyValuePair<K, V> res);

        /// <summary>
        /// Find the entry in the dictionary whose key is the
        /// successor of the specified key.
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="res">The successor, if any</param>
        /// <returns>True if the key has a successor</returns>
        bool TrySuccessor(K key, out KeyValuePair<K, V> res);

        /// <summary>
        /// Find the entry in the dictionary whose key is the
        /// weak predecessor of the specified key.
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="res">The predecessor, if any</param>
        /// <returns>True if key has a weak predecessor</returns>
        bool TryWeakPredecessor(K key, out KeyValuePair<K, V> res);

        /// <summary>
        /// Find the entry in the dictionary whose key is the
        /// weak successor of the specified key.
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="res">The weak successor, if any</param>
        /// <returns>True if the key has a weak successor</returns>
        bool TryWeakSuccessor(K key, out KeyValuePair<K, V> res);

        /// <summary>
        /// Find the entry with the largest key less than a given key.
        /// </summary>
        /// <exception cref="NoSuchItemException"> if there is no such entry. </exception>
        /// <param name="key">The key to compare to</param>
        /// <returns>The entry</returns>
        KeyValuePair<K, V> Predecessor(K key);


        /// <summary>
        /// Find the entry with the least key greater than a given key.
        /// </summary>
        /// <exception cref="NoSuchItemException"> if there is no such entry. </exception>
        /// <param name="key">The key to compare to</param>
        /// <returns>The entry</returns>
        KeyValuePair<K, V> Successor(K key);


        /// <summary>
        /// Find the entry with the largest key less than or equal to a given key.
        /// </summary>
        /// <exception cref="NoSuchItemException"> if there is no such entry. </exception>
        /// <param name="key">The key to compare to</param>
        /// <returns>The entry</returns>
        KeyValuePair<K, V> WeakPredecessor(K key);


        /// <summary>
        /// Find the entry with the least key greater than or equal to a given key.
        /// </summary>
        /// <exception cref="NoSuchItemException"> if there is no such entry. </exception>
        /// <param name="key">The key to compare to</param>
        /// <returns>The entry</returns>
        KeyValuePair<K, V> WeakSuccessor(K key);

        /// <summary>
        /// Given a "cut" function from the items of the sorted collection to <code>int</code>
        /// whose only sign changes when going through items in increasing order
        /// can be 
        /// <list>
        /// <item>from positive to zero</item>
        /// <item>from positive to negative</item>
        /// <item>from zero to negative</item>
        /// </list>
        /// The "cut" function is supplied as the <code>CompareTo</code> method 
        /// of an object <code>c</code> implementing 
        /// <code>IComparable&lt;K&gt;</code>. 
        /// A typical example is the case where <code>K</code> is comparable and 
        /// <code>c</code> is itself of type <code>K</code>.
        /// <para>This method performs a search in the sorted collection for the ranges in which the
        /// "cut" function is negative, zero respectively positive. If <code>K</code> is comparable
        /// and <code>c</code> is of type <code>K</code>, this is a safe way (no exceptions thrown) 
        /// to find predecessor and successor of <code>c</code>.
        /// </para>
        /// <para> If the supplied cut function does not satisfy the sign-change condition, 
        /// the result of this call is undefined.
        /// </para>
        /// 
        /// </summary>
        /// <param name="cutFunction">The cut function <code>K</code> to <code>int</code>, given
        /// by the <code>CompareTo</code> method of an object implementing 
        /// <code>IComparable&lt;K&gt;</code>.</param>
        /// <param name="lowEntry">Returns the largest item in the collection, where the
        /// cut function is positive (if any).</param>
        /// <param name="lowIsValid">Returns true if the cut function is positive somewhere
        /// on this collection.</param>
        /// <param name="highEntry">Returns the least item in the collection, where the
        /// cut function is negative (if any).</param>
        /// <param name="highIsValid">Returns true if the cut function is negative somewhere
        /// on this collection.</param>
        /// <returns>True if the cut function is zero somewhere
        /// on this collection.</returns>
        bool Cut(IComparable<K> cutFunction, out KeyValuePair<K, V> lowEntry, out bool lowIsValid, out KeyValuePair<K, V> highEntry, out bool highIsValid);

        /// <summary>
        /// Query this sorted collection for items greater than or equal to a supplied value.
        /// <para>The returned collection is not a copy but a view into the collection.</para>
        /// <para>The view is fragile in the sense that changes to the underlying collection will 
        /// invalidate the view so that further operations on the view throws InvalidView exceptions.</para>
        /// </summary>
        /// <param name="bot">The lower bound (inclusive).</param>
        /// <returns>The result directed collection.</returns>
        IDirectedEnumerable<KeyValuePair<K, V>> RangeFrom(K bot);


        /// <summary>
        /// Query this sorted collection for items between two supplied values.
        /// <para>The returned collection is not a copy but a view into the collection.</para>
        /// <para>The view is fragile in the sense that changes to the underlying collection will 
        /// invalidate the view so that further operations on the view throws InvalidView exceptions.</para>
        /// </summary>
        /// <param name="lowerBound">The lower bound (inclusive).</param>
        /// <param name="upperBound">The upper bound (exclusive).</param>
        /// <returns>The result directed collection.</returns>
        IDirectedEnumerable<KeyValuePair<K, V>> RangeFromTo(K lowerBound, K upperBound);


        /// <summary>
        /// Query this sorted collection for items less than a supplied value.
        /// <para>The returned collection is not a copy but a view into the collection.</para>
        /// <para>The view is fragile in the sense that changes to the underlying collection will 
        /// invalidate the view so that further operations on the view throws InvalidView exceptions.</para>
        /// </summary>
        /// <param name="top">The upper bound (exclusive).</param>
        /// <returns>The result directed collection.</returns>
        IDirectedEnumerable<KeyValuePair<K, V>> RangeTo(K top);


        /// <summary>
        /// Create a directed collection with the same items as this collection.
        /// <para>The returned collection is not a copy but a view into the collection.</para>
        /// <para>The view is fragile in the sense that changes to the underlying collection will 
        /// invalidate the view so that further operations on the view throws InvalidView exceptions.</para>
        /// </summary>
        /// <returns>The result directed collection.</returns>
        IDirectedCollectionValue<KeyValuePair<K, V>> RangeAll();


        //TODO: remove now that we assume that we can check the sorting order?
        /// <summary>
        /// Add all the items from another collection with an enumeration order that 
        /// is increasing in the items.
        /// </summary>
        /// <exception cref="ArgumentException"> if the enumerated items turns out
        /// not to be in increasing order.</exception>
        /// <param name="items">The collection to add.</param>
        void AddSorted(IEnumerable<KeyValuePair<K, V>> items);


        /// <summary>
        /// Remove all items of this collection above or at a supplied threshold.
        /// </summary>
        /// <param name="low">The lower threshold (inclusive).</param>
        void RemoveRangeFrom(K low);


        /// <summary>
        /// Remove all items of this collection between two supplied thresholds.
        /// </summary>
        /// <param name="low">The lower threshold (inclusive).</param>
        /// <param name="hi">The upper threshold (exclusive).</param>
        void RemoveRangeFromTo(K low, K hi);


        /// <summary>
        /// Remove all items of this collection below a supplied threshold.
        /// </summary>
        /// <param name="hi">The upper threshold (exclusive).</param>
        void RemoveRangeTo(K hi);
    }



    /*******************************************************************/
    /*/// <summary>
    /// The type of an item comparer
    /// <i>Implementations of this interface must asure that the method is self-consistent
    /// and defines a sorting order on items, or state precise conditions under which this is true.</i>
    /// <i>Implementations <b>must</b> assure that repeated calls of
    /// the method to the same (in reference or binary identity sense) arguments 
    /// will return values with the same sign (-1, 0 or +1), or state precise conditions
    /// under which the user 
    /// can be assured repeated calls will return the same sign.</i>
    /// <i>Implementations of this interface must always return values from the method
    /// and never throw exceptions.</i>
    /// <i>This interface is identical to System.Collections.Generic.IComparer&lt;T&gt;</i>
    /// </summary>
    public interface ISystem.Collections.Generic.Comparer<T>
    {
      /// <summary>
      /// Compare two items with respect to this item comparer
      /// </summary>
      /// <param name="item1">First item</param>
      /// <param name="item2">Second item</param>
      /// <returns>Positive if item1 is greater than item2, 0 if they are equal, negative if item1 is less than item2</returns>
      int Compare(T item1, T item2);
    }

    /// <summary>
    /// The type of an item equalityComparer. 
    /// <i>Implementations of this interface <b>must</b> assure that the methods are 
    /// consistent, that is, that whenever two items i1 and i2 satisfies that Equals(i1,i2)
    /// returns true, then GetHashCode returns the same value for i1 and i2.</i>
    /// <i>Implementations of this interface <b>must</b> assure that repeated calls of
    /// the methods to the same (in reference or binary identity sense) arguments 
    /// will return the same values, or state precise conditions under which the user 
    /// can be assured repeated calls will return the same values.</i>
    /// <i>Implementations of this interface must always return values from the methods
    /// and never throw exceptions.</i>
    /// <i>This interface is similar in function to System.IKeyComparer&lt;T&gt;</i>
    /// </summary>
    public interface System.Collections.Generic.IEqualityComparer<T>
    {
      /// <summary>
      /// Get the hash code with respect to this item equalityComparer
      /// </summary>
      /// <param name="item">The item</param>
      /// <returns>The hash code</returns>
      int GetHashCode(T item);


      /// <summary>
      /// Check if two items are equal with respect to this item equalityComparer
      /// </summary>
      /// <param name="item1">first item</param>
      /// <param name="item2">second item</param>
      /// <returns>True if equal</returns>
      bool Equals(T item1, T item2);
    }*/
}
