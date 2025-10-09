using System;
using System.Collections.Generic;
using System.Text;

namespace BSE.Windows.Forms
{
    /// <summary>
    /// Enum für die Comparer
    /// </summary>
    /// <remarks></remarks>
    /// <copyright>Copyright © 2003-2006 MCH Messe Schweiz (Basel) AG</copyright>
    public enum ListViewComparer
    {
        /// <summary>
        /// Comparer für Strings
        /// </summary>
        Strings,
        /// <summary>
        /// Comparer für Zahlen (int, float, double, ...)
        /// </summary>
        Numbers,
        /// <summary>
        /// Comparer für Daten
        /// </summary>
        Dates,
        /// <summary>
        /// Comparer für Guids
        /// </summary>
        Guids,
        /// <summary>
        /// Comparer für das Filesystem
        /// </summary>
        FileSystem
    }
}
