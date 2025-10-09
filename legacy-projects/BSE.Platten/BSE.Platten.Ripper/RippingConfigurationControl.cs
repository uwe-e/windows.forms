using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using BSE.Platten.Common;
using BSE.Platten.BO;
using BSE.Platten.Ripper.Properties;

namespace BSE.Platten.Ripper
{
    public partial class RippingConfigurationControl : BaseConfigurationControl
    {
        #region FieldsPrivate

        private BSE.Configuration.Configuration m_configuration;

        #endregion

        #region Properties

        public bool EnableAudioSaveOptions
        {
            get { return this.m_fileOptions.Enabled;}
            set { this.m_fileOptions.Enabled = value; }
        }

        #endregion

        #region MethodsPublic

        public RippingConfigurationControl()
        {
            InitializeComponent();
        }

        public override void LoadConfigurationValues(BSE.Configuration.Configuration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException("configuration",
                    string.Format(System.Globalization.CultureInfo.InvariantCulture,
                    Resources.IDS_ArgumentNullException,
                    "configuration"));
            }
            
            this.m_configuration = configuration;
            RippingOptionsConfigurationData configurationObject =
                GetConfiguration(configuration) as RippingOptionsConfigurationData;

            if (configurationObject != null)
            {
                GetAudioFormats(configurationObject.UsedAudioFormat);

            }
            this.m_fileOptions.LoadConfigurationValues(configuration);
        }

        public override void SaveConfigurationValues(BSE.Configuration.Configuration configuration)
        {
            RippingOptionsConfigurationData configurationObject = new RippingOptionsConfigurationData();
            configurationObject.UsedAudioFormat = (CAudioFormat.AudioFormat)Enum.Parse(typeof(CAudioFormat.AudioFormat), m_cboFormats.SelectedValue.ToString());
            configuration.SetValue(
                OptionsConfiguration,
                typeof(RippingOptionsConfigurationData).Name,
                configurationObject);

            if (this.m_fileOptions.Enabled == true)
            {
                this.m_fileOptions.SaveConfigurationValues(configuration);
            }
            OnConfigChanging(new System.EventArgs());
        }

        public static IConfigurationData GetConfiguration(BSE.Configuration.Configuration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException("configuration",
                    string.Format(System.Globalization.CultureInfo.InvariantCulture,
                    Resources.IDS_ArgumentNullException,
                    "configuration"));
            }
            
            return configuration.GetValue(
               BSE.Platten.Common.BaseConfigurationControl.OptionsConfiguration,
               typeof(RippingOptionsConfigurationData).Name,
               new RippingOptionsConfigurationData()) as RippingOptionsConfigurationData;
        }
        
        public void SetSaveOptionsCheckBox(CheckBox changedCheckBox)
        {
            this.m_fileOptions.SetSaveCheckBox(changedCheckBox);
        }

        #endregion

        #region MethodsProtected

        #endregion

        #region MethodsPrivate

        private void GetAudioFormats(CAudioFormat.AudioFormat eAudioFormat)
        {
            CAudioFormat[] audioFormats = new CAudioFormat[2];
            CAudioFormat audioFormatWav = new CAudioFormat();
            audioFormatWav.UsedAudioFormat = CAudioFormat.AudioFormat.Wav;
            audioFormatWav.Description = "Wave";
            audioFormatWav.Extension = AudioformatExtensions.Wma;
            audioFormats[0] = audioFormatWav;
            CAudioFormat audioFormatMp3 = new CAudioFormat();
            audioFormatMp3.UsedAudioFormat = CAudioFormat.AudioFormat.Mp3;
            audioFormatMp3.Description = "mp3 LAME Enc";
            audioFormatMp3.Extension = AudioformatExtensions.Mp3;
            audioFormats[1] = audioFormatMp3;

            this.m_cboFormats.DataSource = audioFormats;
            this.m_cboFormats.ValueMember = "UsedAudioFormat";
            this.m_cboFormats.DisplayMember = "Description";

            this.m_cboFormats.SelectedValue = eAudioFormat;

        }

        private void m_btnConfigFormat_Click(object sender, EventArgs e)
        {
            CAudioFormat.AudioFormat eAudioFormat = (CAudioFormat.AudioFormat)this.m_cboFormats.SelectedValue;
            ConfigAudioFormat configAudioFormat = new ConfigAudioFormat(this.m_configuration, eAudioFormat);
            configAudioFormat.ShowDialog();
        }
        
        private void m_audioSaveOptions_ConfigChange(object sender, EventArgs e)
        {
            OnConfigChanging(new EventArgs());
        }

        private void m_cboFormats_Click(object sender, EventArgs e)
        {
            OnConfigChanging(new EventArgs());
        }

        #endregion
    }
}
