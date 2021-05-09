/*
 *	  NEWEXE.H (C) Copyright Microsoft Corp 1984-1987
 *
 *	  Data structure definitions for the OS/2 & Windows
 *	  executable file format.
 *
 *	  Modified by IVS on 24-Jan-1991 for Resource DeCompiler
 *	  (C) Copyright IVS 1991
 *
 *    http://csn.ul.ie/~caolan/pub/winresdump/winresdump/newexe.h
 */

using System;

namespace WiseUnpacker.Files.Microsoft
{
    /// <summary>
    /// Segment data
    /// </summary>
    internal class NewSegdata
    {
        #region ns_iter

        /// <summary>
        /// Number of iterations
        /// </summary>
        public ushort Iterations { get; private set; }
        
        /// <summary>
        /// Number of bytes
        /// </summary>
        public ushort TotalBytes { get; private set; }
        
        /// <summary>
        /// Iterated data bytes
        /// </summary>
        public char IteratedDataBytes { get; private set; }

        #endregion

        #region ns_noiter

        /// <summary>
        /// Data bytes
        /// </summary>
        public char DataBytes { get; private set; }

        #endregion

        public static NewSegdata Deserialize(MultiPartFile file)
        {
            NewSegdata nsd = new NewSegdata();

            nsd.Iterations = file.ReadUInt16();
            nsd.TotalBytes = file.ReadUInt16();
            nsd.IteratedDataBytes = file.ReadChar();
            nsd.DataBytes = (char)BitConverter.GetBytes(nsd.Iterations)[0];

            return nsd;
        }
    }
}
