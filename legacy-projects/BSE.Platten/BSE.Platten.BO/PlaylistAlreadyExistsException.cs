using System;
using System.Collections.Generic;
using System.Text;

namespace BSE.Platten.BO
{
    /// <summary>
    /// The exception that is thrown when an attempt to create a playlist that does already exist.
    /// </summary>
    public class PlaylistAlreadyExistsException : SystemException
    {
        #region Properties
        /// <summary>
        /// Gets or sets the name of the playlist
        /// </summary>
        public string PlaylistName
        {
            get;
            set;
        }
        #endregion

        #region MethodsPublic
        /// <summary>
        /// Initializes a new instance of the <see cref="PlaylistAlreadyExistsException"/>
        /// class with a specified error message and the name of the playlist
        /// </summary>
        /// <param name="strMessage">The error message that explains the reason for the exception.</param>
        /// <param name="strPlaylistName">A <see cref="String"/> containing the full name of the playlist.</param>
        public PlaylistAlreadyExistsException(string strMessage, string strPlaylistName)
            : base(strMessage)
        {
            this.PlaylistName = strPlaylistName;
        }
        #endregion
    }
}
