// This file is part of the C5 Generic Collection Library for C# and CLI
// See https://github.com/sestoft/C5/blob/master/LICENSE.txt for licensing details.

using System.Collections.Generic;

namespace C5
{
    /// <summary>
    /// A generic collection to which one may add items. This is just the intersection
    /// of the main stream generic collection interfaces and the priority queue interface,
    /// <see cref="T:C5.ICollection`1"/> and <see cref="T:C5.IPriorityQueue`1"/>.
    /// </summary>
    public interface IExtensible<T> : ICollectionValue<T>
    {
        /// <summary>
        /// If true any call of an updating operation will throw an
        /// <code>ReadOnlyCollectionException</code>
        /// </summary>
        /// <value>True if this collection is read-only.</value>
        bool IsReadOnly { get; }

        //TODO: wonder where the right position of this is
        /// <summary>
        /// 
        /// </summary>
        /// <value>False if this collection has set semantics, true if bag semantics.</value>
        bool AllowsDuplicates { get; }

        //TODO: wonder where the right position of this is. And the semantics.
        /// <summary>
        /// (Here should be a discussion of the role of equalityComparers. Any ). 
        /// </summary>
        /// <value>The equalityComparer used by this collection to check equality of items. 
        /// Or null (????) if collection does not check equality at all or uses a comparer.</value>
        System.Collections.Generic.IEqualityComparer<T> EqualityComparer { get; }

        //ItemEqualityTypeEnum ItemEqualityType {get ;}

        //TODO: find a good name

        /// <summary>
        /// By convention this is true for any collection with set semantics.
        /// </summary>
        /// <value>True if only one representative of a group of equal items 
        /// is kept in the collection together with the total count.</value>
        bool DuplicatesByCounting { get; }

        /// <summary>
        /// Add an item to this collection if possible. If this collection has set
        /// semantics, the item will be added if not already in the collection. If
        /// bag semantics, the item will always be added.
        /// </summary>
        /// <param name="item">The item to add.</param>
        /// <returns>True if item was added.</returns>
        bool Add(T item);

        /// <summary>
        /// Add the elements from another collection with a more specialized item type 
        /// to this collection. If this
        /// collection has set semantics, only items not already in the collection
        /// will be added.
        /// </summary>
        /// <param name="items">The items to add</param>
        void AddAll(IEnumerable<T> items);

        //void Clear(); // for priority queue
        //int Count why not?
        /// <summary>
        /// Check the integrity of the internal data structures of this collection.
        /// <i>This is only relevant for developers of the library</i>
        /// </summary>
        /// <returns>True if check was passed.</returns>
        bool Check();
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
