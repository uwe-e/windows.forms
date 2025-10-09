using System;
using System.Collections.Generic;
using System.Text;

using BSE.Platten.Common;

namespace BSE.Platten.Audio
{
    /// <summary>
    /// Contains the properties of the UsedPlayerConfigurationData class.
    /// </summary>
    public class UsedPlayerConfigurationData : IConfigurationData
    {
        #region FieldsPrivate

        private UsedPlayer m_eUsedPlayer = UsedPlayer.MediaPlayer;

        #endregion

        #region Properties

        public UsedPlayer UsedPlayer
        {
            get { return this.m_eUsedPlayer; }
            set { this.m_eUsedPlayer = value; }
        }

        #endregion
    }
}
