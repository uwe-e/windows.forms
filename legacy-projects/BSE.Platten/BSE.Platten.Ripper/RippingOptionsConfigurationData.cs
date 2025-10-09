using System;
using System.Collections.Generic;
using System.Text;

using BSE.Platten.Common;

namespace BSE.Platten.Ripper
{
    /// <summary>
    /// Contains the properties of the RippingOptionsConfigurationData class.
    /// </summary>
    public class RippingOptionsConfigurationData : BSE.Platten.Common.IConfigurationData
    {
        #region FieldsPrivate

        private BSE.Platten.BO.CAudioFormat.AudioFormat m_eUsedAudioFormat = BSE.Platten.BO.CAudioFormat.AudioFormat.Mp3;

        #endregion

        #region Properties

        public BSE.Platten.BO.CAudioFormat.AudioFormat UsedAudioFormat
        {
            get { return m_eUsedAudioFormat; }
            set { m_eUsedAudioFormat = value; }
        }

        #endregion
    }
}
