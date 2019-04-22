﻿// This file is part of the C5 Generic Collection Library for C# and CLI
// See https://github.com/sestoft/C5/blob/master/LICENSE.txt for licensing details.

using System;

namespace C5
{
    /// <summary>
    /// 
    /// </summary>
    [Flags]
    public enum EventTypeEnum
    {
        /// <summary>
        /// 
        /// </summary>
        None = 0x00000000,
        /// <summary>
        /// 
        /// </summary>
        Changed = 0x00000001,
        /// <summary>
        /// 
        /// </summary>
        Cleared = 0x00000002,
        /// <summary>
        /// 
        /// </summary>
        Added = 0x00000004,
        /// <summary>
        /// 
        /// </summary>
        Removed = 0x00000008,
        /// <summary>
        /// 
        /// </summary>
        Basic = 0x0000000f,
        /// <summary>
        /// 
        /// </summary>
        Inserted = 0x00000010,
        /// <summary>
        /// 
        /// </summary>
        RemovedAt = 0x00000020,
        /// <summary>
        /// 
        /// </summary>
        All = 0x0000003f
    }
}