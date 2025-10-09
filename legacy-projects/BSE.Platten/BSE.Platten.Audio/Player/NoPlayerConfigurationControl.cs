using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using BSE.Platten.Common;

namespace BSE.Platten.Audio
{
    public partial class CNoPlayerConfigurationControl : BaseConfigurationControl
    {
        #region MethodsPublic

        public CNoPlayerConfigurationControl()
        {
            InitializeComponent();
            this.Text = global::BSE.Platten.Audio.Properties.Resources.CNoPlayerConfigurationControlText;
            this.m_lblDescription.Text = global::BSE.Platten.Audio.Properties.Resources.CNoPlayerConfigurationControlDescription;
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
