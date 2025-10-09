using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics.CodeAnalysis;

namespace BSE.Platten.Ripper.Lame
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class BeVersion
    {
        #region Constants
        public const int BeMaxHomepage = 256;
        #endregion

        #region FieldsPublic
        [SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public byte byDLLMajorVersion;
        [SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public byte byDLLMinorVersion;
        [SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public byte byMajorVersion;
        [SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public byte byMinorVersion;
        [SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public byte byDay;
        [SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public byte byMonth;
        [SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public ushort wYear;
        /// <summary>
        /// Gets or sets the Lame homepage url.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = BeMaxHomepage + 1/*BE_MAX_HOMEPAGE+1*/)]
        [SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public string zHomepage;
        /// <summary>
        /// 
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 125)]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public byte[] btReserved;
        #endregion

        #region MethodsPublic
        public BeVersion()
        {
            btReserved = new byte[125];
        }
        #endregion
    }
}
