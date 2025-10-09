using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using BSE.Platten.Common;
using System.Globalization;
using BSE.Platten.Audio.Properties;

namespace BSE.Platten.Audio
{
    public partial class CPlayerOptionsDialog : Form
    {
        #region EventsPublic

        public event System.EventHandler ConfigChange;

        #endregion
        
        #region FieldsPrivate

        private BSE.Configuration.Configuration m_configuration;
        private BaseConfigurationControl m_configurationControl;

        #endregion

        #region Properties
        public BaseConfigurationControl ChangedConfiguration
        {
            get
            {
                BaseConfigurationControl configurationControl = null;
                if (this.m_configurationControl != null)
                {
                    configurationControl = this.m_configurationControl;
                }
                return configurationControl;
            }
        }
        #endregion

        #region MethodsPublic

        public CPlayerOptionsDialog(BSE.Configuration.Configuration configuration)
        {
            InitializeComponent();
            this.m_configuration = configuration;
        }

        public void SetConfigurationControl(BaseConfigurationControl configurationControl)
        {
            if (configurationControl == null)
            {
                throw new ArgumentNullException(
                    string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.IDS_ArgumentNullException, "configurationControl"));
            }
            this.m_configurationControl = configurationControl;
            this.m_configurationControl.Dock = DockStyle.Fill;
            this.Text = this.m_configurationControl.Text;
            if (this.m_configuration != null)
            {
                this.m_configurationControl.LoadConfigurationValues(this.m_configuration);
            }
            this.m_grpPlayerProperties.Text = this.m_configurationControl.Text;
            this.m_grpPlayerProperties.Controls.Add(this.m_configurationControl);
        }

        #endregion

        #region MethodsProtected

        protected void OnConfigChange(System.EventArgs e)
        {
            if (ConfigChange != null)
            {
                ConfigChange(this, e);
            }
        }

        #endregion

        #region MethodsPrivate

        private void m_btnOK_Click(object sender, EventArgs e)
        {
            if (this.m_configurationControl != null)
            {
                this.m_configurationControl.SaveConfigurationValues(this.m_configuration);
                OnConfigChange(new EventArgs());
            }
        }

        #endregion
    }
}