// This file is part of the C5 Generic Collection Library for C# and CLI
// See https://github.com/sestoft/C5/blob/master/LICENSE.txt for licensing details.

using System;
using System.Collections.Generic;

namespace C5
{
    /// <summary>
    /// A sorted collection, i.e. a collection where items are maintained and can be searched for in sorted order.
    /// Thus the sequence order is given as a sorting order.
    /// 
    /// <para>The sorting order is defined by a comparer, an object of type IComparer&lt;T&gt; 
    /// (<see cref="T:C5.IComparer`1"/>). Implementors of this interface will normally let the user 
    /// define the comparer as an argument to a constructor. 
    /// Usually there will also be constructors without a comparer argument, in which case the 
    /// comparer should be the defalt comparer for the item type, <see cref="P:C5.Comparer`1.Default"/>.</para>
    /// 
    /// <para>The comparer of the sorted collection is available as the <code>System.Collections.Generic.Comparer</code> property 
    /// (<see cref="P:C5.ISorted`1.Comparer"/>).</para>
    /// 
    /// <para>The methods are grouped according to
    /// <list>
    /// <item>Extrema: report or report and delete an extremal item. This is reminiscent of simplified priority queues.</item>
    /// <item>Nearest neighbor: report predecessor or successor in the collection of an item. Cut belongs to this group.</item>
    /// <item>Range: report a view of a range of elements or remove all elements in a range.</item>
    /// <item>AddSorted: add a collection of items known to be sorted in the same order (should be faster) (to be removed?)</item>
    /// </list>
    /// </para>
    /// 
    /// <para>Since this interface extends ISequenced&lt;T&gt;, sorted collections will also have an 
    /// item equalityComparer (<see cref="P:C5.IExtensible`1.EqualityComparer"/>). This equalityComparer will not be used in connection with 
    /// the inner workings of the sorted collection, but will be used if the sorted collection is used as 
    /// an item in a collection of unsequenced or sequenced collections, 
    /// (<see cref="T:C5.ICollection`1"/> and <see cref="T:C5.ISequenced`1"/>)</para>
    /// 
    /// <para>Note that code may check if two sorted collections has the same sorting order 
    /// by checking if the Comparer properties are equal. This is done a few places in this library
    /// for optimization purposes.</para>
    /// </summary>
    public interface ISorted<T> : ISequenced<T>
    {
        /// <summary>
        /// Find the current least item of this sorted collection.
        /// </summary>
        /// <exception cref="NoSuchItemException"> if the collection is empty.</exception>
        /// <returns>The least item.</returns>
        T FindMin();


        /// <summary>
        /// Remove the least item from this sorted collection.
        /// </summary>
        /// <exception cref="NoSuchItemException"> if the collection is empty.</exception>
        /// <returns>The removed item.</returns>
        T DeleteMin();


        /// <summary>
        /// Find the current largest item of this sorted collection.
        /// </summary>
        /// <exception cref="NoSuchItemException"> if the collection is empty.</exception>
        /// <returns>The largest item.</returns>
        T FindMax();


        /// <summary>
        /// Remove the largest item from this sorted collection.
        /// </summary>
        /// <exception cref="NoSuchItemException"> if the collection is empty.</exception>
        /// <returns>The removed item.</returns>
        T DeleteMax();

        /// <summary>
        /// The comparer object supplied at creation time for this sorted collection.
        /// </summary>
        /// <value>The comparer</value>
        System.Collections.Generic.IComparer<T> Comparer { get; }

        /// <summary>
        /// Find the strict predecessor of item in the sorted collection,
        /// that is, the greatest item in the collection smaller than the item.
        /// </summary>
        /// <param name="item">The item to find the predecessor for.</param>
        /// <param name="res">The predecessor, if any; otherwise the default value for T.</param>
        /// <returns>True if item has a predecessor; otherwise false.</returns>
        bool TryPredecessor(T item, out T res);


        /// <summary>
        /// Find the strict successor of item in the sorted collection,
        /// that is, the least item in the collection greater than the supplied value.
        /// </summary>
        /// <param name="item">The item to find the successor for.</param>
        /// <param name="res">The successor, if any; otherwise the default value for T.</param>
        /// <returns>True if item has a successor; otherwise false.</returns>
        bool TrySuccessor(T item, out T res);


        /// <summary>
        /// Find the weak predecessor of item in the sorted collection,
        /// that is, the greatest item in the collection smaller than or equal to the item.
        /// </summary>
        /// <param name="item">The item to find the weak predecessor for.</param>
        /// <param name="res">The weak predecessor, if any; otherwise the default value for T.</param>
        /// <returns>True if item has a weak predecessor; otherwise false.</returns>
        bool TryWeakPredecessor(T item, out T res);


        /// <summary>
        /// Find the weak successor of item in the sorted collection,
        /// that is, the least item in the collection greater than or equal to the supplied value.
        /// </summary>
        /// <param name="item">The item to find the weak successor for.</param>
        /// <param name="res">The weak successor, if any; otherwise the default value for T.</param>
        /// <returns>True if item has a weak successor; otherwise false.</returns>
        bool TryWeakSuccessor(T item, out T res);


        /// <summary>
        /// Find the strict predecessor in the sorted collection of a particular value,
        /// that is, the largest item in the collection less than the supplied value.
        /// </summary>
        /// <exception cref="NoSuchItemException"> if no such element exists (the
        /// supplied  value is less than or equal to the minimum of this collection.)</exception>
        /// <param name="item">The item to find the predecessor for.</param>
        /// <returns>The predecessor.</returns>
        T Predecessor(T item);


        /// <summary>
        /// Find the strict successor in the sorted collection of a particular value,
        /// that is, the least item in the collection greater than the supplied value.
        /// </summary>
        /// <exception cref="NoSuchItemException"> if no such element exists (the
        /// supplied  value is greater than or equal to the maximum of this collection.)</exception>
        /// <param name="item">The item to find the successor for.</param>
        /// <returns>The successor.</returns>
        T Successor(T item);


        /// <summary>
        /// Find the weak predecessor in the sorted collection of a particular value,
        /// that is, the largest item in the collection less than or equal to the supplied value.
        /// </summary>
        /// <exception cref="NoSuchItemException"> if no such element exists (the
        /// supplied  value is less than the minimum of this collection.)</exception>
        /// <param name="item">The item to find the weak predecessor for.</param>
        /// <returns>The weak predecessor.</returns>
        T WeakPredecessor(T item);


        /// <summary>
        /// Find the weak successor in the sorted collection of a particular value,
        /// that is, the least item in the collection greater than or equal to the supplied value.
        /// </summary>
        /// <exception cref="NoSuchItemException"> if no such element exists (the
        /// supplied  value is greater than the maximum of this collection.)</exception>
        ///<param name="item">The item to find the weak successor for.</param>
        /// <returns>The weak successor.</returns>
        T WeakSuccessor(T item);


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
        /// <code>IComparable&lt;T&gt;</code>. 
        /// A typical example is the case where <code>T</code> is comparable and 
        /// <code>cutFunction</code> is itself of type <code>T</code>.
        /// <para>This method performs a search in the sorted collection for the ranges in which the
        /// "cut" function is negative, zero respectively positive. If <code>T</code> is comparable
        /// and <code>c</code> is of type <code>T</code>, this is a safe way (no exceptions thrown) 
        /// to find predecessor and successor of <code>c</code>.
        /// </para>
        /// <para> If the supplied cut function does not satisfy the sign-change condition, 
        /// the result of this call is undefined.
        /// </para>
        /// 
        /// </summary>
        /// <param name="cutFunction">The cut function <code>T</code> to <code>int</code>, given
        /// by the <code>CompareTo</code> method of an object implementing 
        /// <code>IComparable&lt;T&gt;</code>.</param>
        /// <param name="low">Returns the largest item in the collection, where the
        /// cut function is positive (if any).</param>
        /// <param name="lowIsValid">Returns true if the cut function is positive somewhere
        /// on this collection.</param>
        /// <param name="high">Returns the least item in the collection, where the
        /// cut function is negative (if any).</param>
        /// <param name="highIsValid">Returns true if the cut function is negative somewhere
        /// on this collection.</param>
        /// <returns>True if the cut function is zero somewhere
        /// on this collection.</returns>
        bool Cut(IComparable<T> cutFunction, out T low, out bool lowIsValid, out T high, out bool highIsValid);


        /// <summary>
        /// Query this sorted collection for items greater than or equal to a supplied value.
        /// <para>The returned collection is not a copy but a view into the collection.</para>
        /// <para>The view is fragile in the sense that changes to the underlying collection will 
        /// invalidate the view so that further operations on the view throws InvalidView exceptions.</para>
        /// </summary>
        /// <param name="bot">The lower bound (inclusive).</param>
        /// <returns>The result directed collection.</returns>
        IDirectedEnumerable<T> RangeFrom(T bot);


        /// <summary>
        /// Query this sorted collection for items between two supplied values.
        /// <para>The returned collection is not a copy but a view into the collection.</para>
        /// <para>The view is fragile in the sense that changes to the underlying collection will 
        /// invalidate the view so that further operations on the view throws InvalidView exceptions.</para>
        /// </summary>
        /// <param name="bot">The lower bound (inclusive).</param>
        /// <param name="top">The upper bound (exclusive).</param>
        /// <returns>The result directed collection.</returns>
        IDirectedEnumerable<T> RangeFromTo(T bot, T top);


        /// <summary>
        /// Query this sorted collection for items less than a supplied value.
        /// <para>The returned collection is not a copy but a view into the collection.</para>
        /// <para>The view is fragile in the sense that changes to the underlying collection will 
        /// invalidate the view so that further operations on the view throws InvalidView exceptions.</para>
        /// </summary>
        /// <param name="top">The upper bound (exclusive).</param>
        /// <returns>The result directed collection.</returns>
        IDirectedEnumerable<T> RangeTo(T top);


        /// <summary>
        /// Create a directed collection with the same items as this collection.
        /// <para>The returned collection is not a copy but a view into the collection.</para>
        /// <para>The view is fragile in the sense that changes to the underlying collection will 
        /// invalidate the view so that further operations on the view throws InvalidView exceptions.</para>
        /// </summary>
        /// <returns>The result directed collection.</returns>
        IDirectedCollectionValue<T> RangeAll();


        //TODO: remove now that we assume that we can check the sorting order?
        /// <summary>
        /// Add all the items from another collection with an enumeration order that 
        /// is increasing in the items.
        /// </summary>
        /// <exception cref="ArgumentException"> if the enumerated items turns out
        /// not to be in increasing order.</exception>
        /// <param name="items">The collection to add.</param>
        void AddSorted(IEnumerable<T> items);


        /// <summary>
        /// Remove all items of this collection above or at a supplied threshold.
        /// </summary>
        /// <param name="low">The lower threshold (inclusive).</param>
        void RemoveRangeFrom(T low);


        /// <summary>
        /// Remove all items of this collection between two supplied thresholds.
        /// </summary>
        /// <param name="low">The lower threshold (inclusive).</param>
        /// <param name="hi">The upper threshold (exclusive).</param>
        void RemoveRangeFromTo(T low, T hi);


        /// <summary>
        /// Remove all items of this collection below a supplied threshold.
        /// </summary>
        /// <param name="hi">The upper threshold (exclusive).</param>
        void RemoveRangeTo(T hi);
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
