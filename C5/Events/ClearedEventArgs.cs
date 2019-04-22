// This file is part of the C5 Generic Collection Library for C# and CLI
// See https://github.com/sestoft/C5/blob/master/LICENSE.txt for licensing details.

using System;

namespace C5
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class ClearedEventArgs : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        public readonly bool Full;
        /// <summary>
        /// 
        /// </summary>
        public readonly int Count;
        /// <summary>
        /// 
        /// </summary>
        /// 
        /// <param name="full">True if the operation cleared all of the collection</param>
        /// <param name="count">The number of items removed by the clear.</param>
        public ClearedEventArgs(bool full, int count) { Full = full; Count = count; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("(ClearedEventArgs {0} {1})", Count, Full);
        }
    }
}