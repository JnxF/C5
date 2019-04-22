// This file is part of the C5 Generic Collection Library for C# and CLI
// See https://github.com/sestoft/C5/blob/master/LICENSE.txt for licensing details.

using System;
using System.Collections.Generic;

namespace C5
{
    /// <summary>
    /// A sequenced collection, where indices of items in the order are maintained
    /// </summary>
    public interface IIndexed<T> : ISequenced<T>, IReadOnlyList<T>
    {
        /// <summary>
        /// Gets the number of elements in the collection.
        /// </summary>
        new int Count { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        Speed IndexingSpeed { get; }

        /// <summary>
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <value>The directed collection of items in a specific index interval.</value>
        /// <param name="start">The low index of the interval (inclusive).</param>
        /// <param name="count">The size of the range.</param>
        IDirectedCollectionValue<T> this[int start, int count] { get; }


        /// <summary>
        /// Searches for an item in the list going forwards from the start. 
        /// </summary>
        /// <param name="item">Item to search for.</param>
        /// <returns>Index of item from start. A negative number if item not found, 
        /// namely the one's complement of the index at which the Add operation would put the item.</returns>
        int IndexOf(T item);


        /// <summary>
        /// Searches for an item in the list going backwards from the end.
        /// </summary>
        /// <param name="item">Item to search for.</param>
        /// <returns>Index of of item from the end. A negative number if item not found, 
        /// namely the two-complement of the index at which the Add operation would put the item.</returns>
        int LastIndexOf(T item);

        /// <summary>
        /// Check if there exists an item  that satisfies a
        /// specific predicate in this collection and return the index of the first one.
        /// </summary>
        /// <param name="predicate">A delegate 
        /// (<see cref="T:Func`2"/> with <code>R == bool</code>) defining the predicate</param>
        /// <returns>the index, if found, a negative value else</returns>
        int FindIndex(Func<T, bool> predicate);

        /// <summary>
        /// Check if there exists an item  that satisfies a
        /// specific predicate in this collection and return the index of the last one.
        /// </summary>
        /// <param name="predicate">A delegate 
        /// (<see cref="T:Func`2"/> with <code>R == bool</code>) defining the predicate</param>
        /// <returns>the index, if found, a negative value else</returns>
        int FindLastIndex(Func<T, bool> predicate);


        /// <summary>
        /// Remove the item at a specific position of the list.
        /// </summary>
        /// <exception cref="IndexOutOfRangeException"> if <code>index</code> is negative or
        /// &gt;= the size of the collection.</exception>
        /// <param name="index">The index of the item to remove.</param>
        /// <returns>The removed item.</returns>
        T RemoveAt(int index);


        /// <summary>
        /// Remove all items in an index interval.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"> if start or count 
        /// is negative or start+count &gt; the size of the collection.</exception>
        /// <param name="start">The index of the first item to remove.</param>
        /// <param name="count">The number of items to remove.</param>
        void RemoveInterval(int start, int count);
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
