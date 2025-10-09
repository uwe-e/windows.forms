using System;
using System.Collections.Generic;
using System.Text;

namespace BSE.Platten.Audio
{
    public class ThumbStateChangedEventArgs : EventArgs
    {
        #region FieldsPrivate
        private ThumbState m_oldThumbState;
        private ThumbState m_newThumbState;
        #endregion

        #region Properties
        /// <summary>
        /// Gets the old Thumbstate on the TrackBar.
        /// </summary>
        public ThumbState OldThumbState
        {
            get { return this.m_oldThumbState; }
        }
        /// <summary>
        /// Gets the new Thumbstate on the TrackBar.
        /// </summary>
        public ThumbState NewThumbState
        {
            get { return this.m_newThumbState; }
        }
        #endregion

        #region MethodsPublic
        /// <summary>
        /// Initializes a new instance of the ThumbStateChangedEventArgs class.
        /// </summary>
        /// <param name="oldThumbState">The old Thumbstate on the TrackBar.</param>
        /// <param name="newThumbState">The new Thumbstate on the TrackBar.</param>
        public ThumbStateChangedEventArgs(ThumbState oldThumbState, ThumbState newThumbState)
        {
            this.m_oldThumbState = oldThumbState;
            this.m_newThumbState = newThumbState;
        }
        #endregion
    }
}
