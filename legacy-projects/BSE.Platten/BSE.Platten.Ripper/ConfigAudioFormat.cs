using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using BSE.Platten.Common;
using BSE.Platten.Ripper.AudioWriters;
using System.Globalization;
using BSE.Platten.Ripper.Properties;

namespace BSE.Platten.Ripper
{
    public partial class ConfigAudioFormat : BSE.Platten.Common.BaseDialog
    {
        #region FieldsPrivate

        private BSE.Configuration.Configuration m_configuration;
        private BSE.Platten.BO.CAudioFormat.AudioFormat m_eUsedAudioFormat;
        private IAudioWriterConfiguration m_audioWriterConfiguration;

        #endregion

        #region MethodsPublic

        public ConfigAudioFormat()
        {
            InitializeComponent();
        }

        public ConfigAudioFormat(BSE.Configuration.Configuration configuration, BSE.Platten.BO.CAudioFormat.AudioFormat usedAudioFormat) : this()
        {
            this.m_configuration = configuration;
            this.m_eUsedAudioFormat = usedAudioFormat;
            Control configurationControl = null;
            switch (this.m_eUsedAudioFormat)
            {
                case BSE.Platten.BO.CAudioFormat.AudioFormat.Wav:
                    this.m_audioWriterConfiguration = new WaveConfigurationControl(this.m_configuration);
                    configurationControl = this.m_audioWriterConfiguration as WaveConfigurationControl;
                    break;
                case BSE.Platten.BO.CAudioFormat.AudioFormat.Mp3:
                    this.m_audioWriterConfiguration = new MP3ConfigurationControl(this.m_configuration);
                    configurationControl = this.m_audioWriterConfiguration as MP3ConfigurationControl;
                    break;
            }
            if (configurationControl != null)
            {
                configurationControl.Dock = DockStyle.Fill;
                this.m_pnlBaseContent.Controls.Add(configurationControl);
            }
            this.Text = string.Format(
                CultureInfo.CurrentUICulture,
                "{0} {1}",
                this.m_eUsedAudioFormat.ToString(),
                Resources.IDS_ConfigAudioFormatFormHeader);
        }

        #endregion

        #region MethodsProtected

        protected override bool SaveSettings()
        {
            try
            {
                if (this.m_audioWriterConfiguration != null)
                {
                    this.m_audioWriterConfiguration.SaveConfigurationValues(this.m_configuration);
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

    }
}