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
    public class ItemAtEventArgs<T> : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        public readonly T Item;
        /// <summary>
        /// 
        /// </summary>
        public readonly int Index;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <param name="index"></param>
        public ItemAtEventArgs(T item, int index) { Item = item; Index = index; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("(ItemAtEventArgs {0} '{1}')", Index, Item);
        }
    }
}