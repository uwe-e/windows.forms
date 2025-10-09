using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using BSE.Configuration;
using BSE.Platten.Common;

namespace BSE.Platten.Admin
{
    public partial class Options : BSE.Platten.Common.BaseDialog
    {
        #region Events

        public event EventHandler AudioPlayerChanged;

        #endregion

        #region FieldsPrivate

        private bool m_beditBaseOptionsConfigChange;
        private bool m_baudioSaveOptionsConfigChange;
        private bool m_brippingSaveOptionsConfigChange;
        private bool m_baudioImportOptionsConfigChange;
        private BSE.Configuration.Configuration m_configuration;

        #endregion

        #region Properties

        public BSE.Configuration.Configuration Configuration
        {
            set { this.m_configuration = value; }
        }

        #endregion

        #region MethodsPublic

        public Options()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }

        public Options(BSE.Configuration.Configuration configuration)
            : this()
        {
            this.m_configuration = configuration;
        }

        #endregion

        #region MethodsProtected
        
        protected override bool SaveSettings()
        {
            try
            {
                if (this.m_beditBaseOptionsConfigChange)
                {
                    this.m_visualConfiguration.SaveObjects();
                    OnConfigurationChanged(new EventArgs());
                }
                if (this.m_baudioSaveOptionsConfigChange)
                {
                    this.m_audioSaveOptions.SaveConfigurationValues(this.m_configuration);
                }
                if (this.m_brippingSaveOptionsConfigChange)
                {
                    this.m_rippingOptions.SaveConfigurationValues(this.m_configuration);
                }
                if (this.m_baudioImportOptionsConfigChange)
                {
                    this.m_audioImportOptions.SaveConfigurationValues(this.m_configuration);
                }
                return true;
            }
            catch (Exception exception)
            {
                GlobalizedMessageBox.Show(this, exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        protected void OnAudioPlayerChanged(EventArgs e)
        {
            if (AudioPlayerChanged != null)
            {
                AudioPlayerChanged(this, e);
            }
        }

        #endregion

        #region MethodsPrivate

        private void COptions_Load(object sender, EventArgs e)
        {
            if (this.m_configuration != null)
            {
                this.m_visualConfiguration.Configuration = this.m_configuration;
                this.m_visualConfiguration.LoadObjects();
                this.m_audioSaveOptions.LoadConfigurationValues(this.m_configuration);
                this.m_rippingOptions.EnableAudioSaveOptions = false;
                this.m_rippingOptions.LoadConfigurationValues(this.m_configuration);
                this.m_audioImportOptions.EnableAudioImportOptions = false;
                this.m_audioImportOptions.LoadConfigurationValues(this.m_configuration);
            }
        }
        
        private void m_visualConfiguration_ConfigurationChanged(object sender, ConfigChangeEventArgs e)
        {
            this.m_beditBaseOptionsConfigChange = true;
        }
        
        private void m_audioSaveOptions_ConfigChange(object sender, EventArgs e)
        {
            this.m_baudioSaveOptionsConfigChange = true;
        }

        private void m_audioSaveOptions_SaveCheckBoxChanged(object sender, CheckBoxChangeEventArgs e)
        {
            this.m_rippingOptions.SetSaveOptionsCheckBox(e.ChangedCheckBox);
            this.m_audioImportOptions.SetSaveOptionsCheckBox(e.ChangedCheckBox);
        }

        private void m_rippingOptions_ConfigChange(object sender, EventArgs e)
        {
            this.m_brippingSaveOptionsConfigChange = true;
        }

        private void m_audioImportOptions_ConfigChange(object sender, EventArgs e)
        {
            this.m_baudioImportOptionsConfigChange = true;
        }
        #endregion

    }
}