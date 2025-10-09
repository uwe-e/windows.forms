using System;
using System.Collections.Generic;
using System.Text;

namespace BSE.Platten.Admin
{
    /// <summary>
    /// Represents the different data-entry modes of a data form.
    /// </summary>
    public enum DataFormViewMode
    {
        /// <summary>
        /// An mode that allows the user to execute a new search.
        /// </summary>
        Clear,
        /// <summary>
        /// An selecting mode that allows the user to page through the data records.
        /// </summary>
        Select,
        /// <summary>
        /// An inserting mode that allows the user to enter the values for a new record.
        /// </summary>
        Insert
    }
}
