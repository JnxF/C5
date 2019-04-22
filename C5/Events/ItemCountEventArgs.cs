// This file is part of the C5 Generic Collection Library for C# and CLI
// See https://github.com/sestoft/C5/blob/master/LICENSE.txt for licensing details.

using System;

namespace C5
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public class ItemCountEventArgs<T> : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        public readonly T Item;
        /// <summary>
        /// 
        /// </summary>
        public readonly int Count;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="count"></param>
        /// <param name="item"></param>
        public ItemCountEventArgs(T item, int count) { Item = item; Count = count; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("(ItemCountEventArgs {0} '{1}')", Count, Item);
        }
    }
}