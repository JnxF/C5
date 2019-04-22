// This file is part of the C5 Generic Collection Library for C# and CLI
// See https://github.com/sestoft/C5/blob/master/LICENSE.txt for licensing details.

namespace C5
{
    /// <summary>
    /// An editable collection maintaining a definite sequence order of the items.
    ///
    /// <i>Implementations of this interface must compute the hash code and 
    /// equality exactly as prescribed in the method definitions in order to
    /// be consistent with other collection classes implementing this interface.</i>
    /// <i>This interface is usually implemented by explicit interface implementation,
    /// not as ordinary virtual methods.</i>
    /// </summary>
    public interface ISequenced<T> : ICollection<T>, IDirectedCollectionValue<T>
    {
        /// <summary>
        /// The hashcode is defined as <code>h(...h(h(h(x1),x2),x3),...,xn)</code> for
        /// <code>h(a,b)=CONSTANT*a+b</code> and the x's the hash codes of the items of 
        /// this collection.
        /// </summary>
        /// <returns>The sequence order hashcode of this collection.</returns>
        int GetSequencedHashCode();


        /// <summary>
        /// Compare this sequenced collection to another one in sequence order.
        /// </summary>
        /// <param name="otherCollection">The sequenced collection to compare to.</param>
        /// <returns>True if this collection and that contains equal (according to
        /// this collection's itemequalityComparer) in the same sequence order.</returns>
        bool SequencedEquals(ISequenced<T> otherCollection);
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
