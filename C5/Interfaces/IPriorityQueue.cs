// This file is part of the C5 Generic Collection Library for C# and CLI
// See https://github.com/sestoft/C5/blob/master/LICENSE.txt for licensing details.

namespace C5
{
    /// <summary>
    /// A generic collection of items prioritized by a comparison (order) relation.
    /// Supports adding items and reporting or removing extremal elements. 
    /// <para>
    /// 
    /// </para>
    /// When adding an item, the user may choose to have a handle allocated for this item in the queue. 
    /// The resulting handle may be used for deleting the item even if not extremal, and for replacing the item.
    /// A priority queue typically only holds numeric priorities associated with some objects
    /// maintained separately in other collection objects.
    /// </summary>
    public interface IPriorityQueue<T> : IExtensible<T>
    {
        /// <summary>
        /// Find the current least item of this priority queue.
        /// </summary>
        /// <returns>The least item.</returns>
        T FindMin();


        /// <summary>
        /// Remove the least item from this  priority queue.
        /// </summary>
        /// <returns>The removed item.</returns>
        T DeleteMin();


        /// <summary>
        /// Find the current largest item of this priority queue.
        /// </summary>
        /// <returns>The largest item.</returns>
        T FindMax();


        /// <summary>
        /// Remove the largest item from this priority queue.
        /// </summary>
        /// <returns>The removed item.</returns>
        T DeleteMax();

        /// <summary>
        /// The comparer object supplied at creation time for this collection
        /// </summary>
        /// <value>The comparer</value>
        System.Collections.Generic.IComparer<T> Comparer { get; }
        /// <summary>
        /// Get or set the item corresponding to a handle. Throws exceptions on 
        /// invalid handles.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        T this[IPriorityQueueHandle<T> handle] { get; set; }

        /// <summary>
        /// Check if the entry corresponding to a handle is in the priority queue.
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        bool Find(IPriorityQueueHandle<T> handle, out T item);

        /// <summary>
        /// Add an item to the priority queue, receiving a 
        /// handle for the item in the queue, 
        /// or reusing an existing unused handle.
        /// </summary>
        /// <param name="handle">On output: a handle for the added item. 
        /// On input: null for allocating a new handle, or a currently unused handle for reuse. 
        /// A handle for reuse must be compatible with this priority queue, 
        /// by being created by a priority queue of the same runtime type, but not 
        /// necessarily the same priority queue object.</param>
        /// <param name="item"></param>
        /// <returns></returns>
        bool Add(ref IPriorityQueueHandle<T> handle, T item);

        /// <summary>
        /// Delete an item with a handle from a priority queue
        /// </summary>
        /// <param name="handle">The handle for the item. The handle will be invalidated, but reusable.</param>
        /// <returns>The deleted item</returns>
        T Delete(IPriorityQueueHandle<T> handle);

        /// <summary>
        /// Replace an item with a handle in a priority queue with a new item. 
        /// Typically used for changing the priority of some queued object.
        /// </summary>
        /// <param name="handle">The handle for the old item</param>
        /// <param name="item">The new item</param>
        /// <returns>The old item</returns>
        T Replace(IPriorityQueueHandle<T> handle, T item);

        /// <summary>
        /// Find the current least item of this priority queue.
        /// </summary>
        /// <param name="handle">On return: the handle of the item.</param>
        /// <returns>The least item.</returns>
        T FindMin(out IPriorityQueueHandle<T> handle);

        /// <summary>
        /// Find the current largest item of this priority queue.
        /// </summary>
        /// <param name="handle">On return: the handle of the item.</param>
        /// <returns>The largest item.</returns>

        T FindMax(out IPriorityQueueHandle<T> handle);

        /// <summary>
        /// Remove the least item from this  priority queue.
        /// </summary>
        /// <param name="handle">On return: the handle of the removed item.</param>
        /// <returns>The removed item.</returns>

        T DeleteMin(out IPriorityQueueHandle<T> handle);

        /// <summary>
        /// Remove the largest item from this  priority queue.
        /// </summary>
        /// <param name="handle">On return: the handle of the removed item.</param>
        /// <returns>The removed item.</returns>
        T DeleteMax(out IPriorityQueueHandle<T> handle);
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
