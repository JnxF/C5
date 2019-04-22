// This file is part of the C5 Generic Collection Library for C# and CLI
// See https://github.com/sestoft/C5/blob/master/LICENSE.txt for licensing details.

using System;
using System.Collections.Generic;

namespace C5
{
    /// <summary>
    /// A generic collection that may be enumerated and can answer
    /// efficiently how many items it contains. Like <code>IEnumerable&lt;T&gt;</code>,
    /// this interface does not prescribe any operations to initialize or update the 
    /// collection. The main usage for this interface is to be the return type of 
    /// query operations on generic collection.
    /// </summary>
    public interface ICollectionValue<T> : IEnumerable<T>, IShowable
    {
        /// <summary>
        /// A flag bitmap of the events subscribable to by this collection.
        /// </summary>
        /// <value></value>
        EventTypeEnum ListenableEvents { get; }

        /// <summary>
        /// A flag bitmap of the events currently subscribed to by this collection.
        /// </summary>
        /// <value></value>
        EventTypeEnum ActiveEvents { get; }

        /// <summary>
        /// The change event. Will be raised for every change operation on the collection.
        /// </summary>
        event CollectionChangedHandler<T> CollectionChanged;

        /// <summary>
        /// The change event. Will be raised for every clear operation on the collection.
        /// </summary>
        event CollectionClearedHandler<T> CollectionCleared;

        /// <summary>
        /// The item added  event. Will be raised for every individual addition to the collection.
        /// </summary>
        event ItemsAddedHandler<T> ItemsAdded;

        /// <summary>
        /// The item inserted  event. Will be raised for every individual insertion to the collection.
        /// </summary>
        event ItemInsertedHandler<T> ItemInserted;

        /// <summary>
        /// The item removed event. Will be raised for every individual removal from the collection.
        /// </summary>
        event ItemsRemovedHandler<T> ItemsRemoved;

        /// <summary>
        /// The item removed at event. Will be raised for every individual removal at from the collection.
        /// </summary>
        event ItemRemovedAtHandler<T> ItemRemovedAt;

        /// <summary>
        /// 
        /// </summary>
        /// <value>True if this collection is empty.</value>
        bool IsEmpty { get; }

        /// <summary>
        /// </summary>
        /// <value>The number of items in this collection</value>
        int Count { get; }

        /// <summary>
        /// The value is symbolic indicating the type of asymptotic complexity
        /// in terms of the size of this collection (worst-case or amortized as
        /// relevant).
        /// </summary>
        /// <value>A characterization of the speed of the 
        /// <code>Count</code> property in this collection.</value>
        Speed CountSpeed { get; }

        /// <summary>
        /// Copy the items of this collection to a contiguous part of an array.
        /// </summary>
        /// <param name="array">The array to copy to</param>
        /// <param name="index">The index at which to copy the first item</param>
        void CopyTo(T[] array, int index);

        /// <summary>
        /// Create an array with the items of this collection (in the same order as an
        /// enumerator would output them).
        /// </summary>
        /// <returns>The array</returns>
        T[] ToArray();

        /// <summary>
        /// Apply a delegate to all items of this collection.
        /// </summary>
        /// <param name="action">The delegate to apply</param>
        void Apply(Action<T> action);


        /// <summary>
        /// Check if there exists an item  that satisfies a
        /// specific predicate in this collection.
        /// </summary>
        /// <param name="predicate">A  delegate 
        /// (<see cref="T:Func`2"/> with <code>R == bool</code>) defining the predicate</param>
        /// <returns>True is such an item exists</returns>
        bool Exists(Func<T, bool> predicate);

        /// <summary>
        /// Check if there exists an item  that satisfies a
        /// specific predicate in this collection and return the first one in enumeration order.
        /// </summary>
        /// <param name="predicate">A delegate 
        /// (<see cref="T:Func`2"/> with <code>R == bool</code>) defining the predicate</param>
        /// <param name="item"></param>
        /// <returns>True is such an item exists</returns>
        bool Find(Func<T, bool> predicate, out T item);


        /// <summary>
        /// Check if all items in this collection satisfies a specific predicate.
        /// </summary>
        /// <param name="predicate">A delegate 
        /// (<see cref="T:Func`2"/> with <code>R == bool</code>) defining the predicate</param>
        /// <returns>True if all items satisfies the predicate</returns>
        bool All(Func<T, bool> predicate);

        /// <summary>
        /// Choose some item of this collection. 
        /// <para>Implementations must assure that the item 
        /// returned may be efficiently removed.</para>
        /// <para>Implementors may decide to implement this method in a way such that repeated
        /// calls do not necessarily give the same result, i.e. so that the result of the following 
        /// test is undetermined:
        /// <code>coll.Choose() == coll.Choose()</code></para>
        /// </summary>
        /// <exception cref="NoSuchItemException">if collection is empty.</exception>
        /// <returns></returns>
        T Choose();

        /// <summary>
        /// Create an enumerable, enumerating the items of this collection that satisfies 
        /// a certain condition.
        /// </summary>
        /// <param name="filter">The T->bool filter delegate defining the condition</param>
        /// <returns>The filtered enumerable</returns>
        IEnumerable<T> Filter(Func<T, bool> filter);
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
