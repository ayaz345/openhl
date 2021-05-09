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

namespace WiseUnpacker.Files.Microsoft
{
    internal class IMAGE_FILE_HEADER
    {
        public ushort Machine { get; private set; }
        public ushort NumberOfSections { get; private set; }
        public uint TimeDateStamp { get; private set; }
        public uint PointerToSymbolTable { get; private set; }
        public uint NumberOfSymbols { get; private set; }
        public ushort SizeOfOptionalHeader { get; private set; }
        public ushort Characteristics { get; private set; }

        public static IMAGE_FILE_HEADER Deserialize(MultiPartFile file)
        {
            IMAGE_FILE_HEADER ifh = new IMAGE_FILE_HEADER();

            ifh.Machine = file.ReadUInt16();
            ifh.NumberOfSections = file.ReadUInt16();
            ifh.TimeDateStamp = file.ReadUInt32();
            ifh.PointerToSymbolTable = file.ReadUInt32();
            ifh.NumberOfSymbols = file.ReadUInt32();
            ifh.SizeOfOptionalHeader = file.ReadUInt16();
            ifh.Characteristics = file.ReadUInt16();

            return ifh;
        }
    }
}