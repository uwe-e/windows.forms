using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using BSE.Platten.Common;

namespace BSE.Platten.Audio
{
    public partial class OptionsDialog : BSE.Platten.Common.BaseDialog
    {
        #region FieldsPrivate

        private bool m_bAudioOptionsConfigChange;
        private BSE.Configuration.Configuration m_Configuration;

        #endregion

        #region MethodsPublic

        public OptionsDialog()
        {
            InitializeComponent();
        }

        public OptionsDialog(BSE.Configuration.Configuration configuration)
            : this()
		{
            this.m_Configuration = configuration;
            this.m_audioImportOptions.EnableAudioImportOptions = true;
            this.m_audioImportOptions.LoadConfigurationValues(this.m_Configuration);
		}

        #endregion

        #region MethodsProtected

        protected override bool SaveSettings()
        {
            try
            {
                if (this.m_bAudioOptionsConfigChange == true)
                {
                    this.m_audioImportOptions.SaveConfigurationValues(this.m_Configuration);
                    OnConfigurationChanged(new EventArgs());

                }
                return true;
            }
            catch (Exception exception)
            {
                GlobalizedMessageBox.Show(this,exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        #endregion

        #region MethodsPrivate

        private void m_cAudioOptions_ConfigChange(object sender, EventArgs e)
        {
            this.m_bAudioOptionsConfigChange = true;
        }

        #endregion

        
    }
}