using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using BSE.Platten.Common;
using BSE.Platten.Audio.Properties;

namespace BSE.Platten.Audio
{
    public partial class CMediaPlayerConfigurationControl : BaseConfigurationControl
    {
        #region MethodsPublic

        public CMediaPlayerConfigurationControl()
        {
            InitializeComponent();
            this.Text = Resources.CMediaPlayerConfigurationControlText;
            this.m_lblDescription.Text = Resources.CMediaPlayerConfigurationControlDescription;
        }

        public override void SaveConfigurationValues(BSE.Configuration.Configuration configuration)
        {
        }

        public override void LoadConfigurationValues(BSE.Configuration.Configuration configuration)
        {
        }

        #endregion
    }
}
