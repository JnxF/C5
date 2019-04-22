// This file is part of the C5 Generic Collection Library for C# and CLI
// See https://github.com/sestoft/C5/blob/master/LICENSE.txt for licensing details.

using System;

namespace C5
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class ClearedRangeEventArgs : ClearedEventArgs
    {
        //WE could let this be of type int? to  allow 
        /// <summary>
        /// 
        /// </summary>
        public readonly int? Start;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="full"></param>
        /// <param name="count"></param>
        /// <param name="start"></param>
        public ClearedRangeEventArgs(bool full, int count, int? start) : base(full, count) { Start = start; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("(ClearedRangeEventArgs {0} {1} {2})", Count, Full, Start);
        }
    }
}