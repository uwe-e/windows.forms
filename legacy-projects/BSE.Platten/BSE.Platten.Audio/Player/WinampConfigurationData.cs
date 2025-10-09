using System;
using System.Collections.Generic;
using System.Text;

using BSE.Platten.Common;
using System.Diagnostics.CodeAnalysis;

namespace BSE.Platten.Audio
{
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
    public class WinampConfigurationData : IConfigurationData
    {
        #region FieldsPrivate

        private string m_strFileName;

        #endregion

        #region Properties

        public string FileName
        {
            get { return this.m_strFileName; }
            set { this.m_strFileName = value; }
        }

        #endregion
    }
}
