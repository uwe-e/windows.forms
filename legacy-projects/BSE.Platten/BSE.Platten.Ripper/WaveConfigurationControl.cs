using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using BSE.Platten.Common;
using System.Globalization;
using BSE.Platten.Ripper.Properties;
using BSE.Platten.Ripper.AudioWriters;
using BSE.Platten.Ripper;

namespace BSE.Platten.Ripper
{
    public partial class WaveConfigurationControl : BaseConfigurationControl, IAudioWriterConfiguration
    {
        #region FieldsPrivate

        private BSE.Configuration.Configuration m_configuration;
        private WaveFormat m_waveFormat;

        #endregion

        #region Properties

        public WaveWriterConfiguration AudioWriterConfiguration
        {
            get
            {
                WaveConfigurationData configurationObject = GetConfiguration(this.m_configuration) as WaveConfigurationData;
                this.m_waveFormat.SamplesPerSec = (int)configurationObject.Bitrate;
                this.m_waveFormat.BitsPerSample = (short)configurationObject.BitsPerSample;
                this.m_waveFormat.Channels = (short)configurationObject.Channels;
                return new WaveWriterConfiguration(this.m_waveFormat);
            }
            set
            {
                if (value != null)
                {
                    this.m_waveFormat = value.WaveFormat;
                }
            }
        }

        #endregion

        #region MethodsPublic

        public WaveConfigurationControl(BSE.Configuration.Configuration configuration)
        {
            InitializeComponent();
            this.m_configuration = configuration;
            this.m_waveFormat = new WaveFormat(
                Constants.WavSamplesPerSecDefaultValue,
                Constants.WavBitsPerSampleDefaultValue,
                Constants.WavChannelsDefaultValue
                ); //Set default values
            LoadConfigurationValues(configuration);
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
            WaveConfigurationData configurationObject =
                GetConfiguration(configuration) as WaveConfigurationData;

            if (configurationObject != null)
            {
                this.m_cboSampleRate.DataSource = GetBitRates();
                this.m_cboSampleRate.ValueMember = "Bitrate";
                this.m_cboSampleRate.DisplayMember = "Description";
                this.m_cboSampleRate.SelectedValue = configurationObject.Bitrate;

                this.m_rdo16BitPerSample.Checked = true;
                if (configurationObject.BitsPerSample == 8)
                {
                    this.m_rdo8BitPerSample.Checked = true;
                }
                this.m_rdoStereo.Checked = true;
                if (configurationObject.Channels == 1)
                {
                    this.m_rdoMono.Checked = true;
                }
            }
        }

        public override void SaveConfigurationValues(BSE.Configuration.Configuration configuration)
        {
            this.m_configuration = configuration;

            WaveConfigurationData configurationObject = new WaveConfigurationData();
            configurationObject.Bitrate = uint.Parse(this.m_cboSampleRate.SelectedValue.ToString(),CultureInfo.InvariantCulture);
            configurationObject.BitsPerSample = 16;
            if (this.m_rdo8BitPerSample.Checked == true)
            {
                configurationObject.BitsPerSample = 8;
            }
            configurationObject.Channels = 2;
            if (this.m_rdoMono.Checked == true)
            {
                configurationObject.Channels = 1;
            }

            configuration.SetValue(
                BaseConfigurationControl.OptionsConfiguration,
                typeof(WaveConfigurationData).Name,
                configurationObject);
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
                typeof(WaveConfigurationData).Name,
                new WaveConfigurationData()) as WaveConfigurationData;
        }

        #endregion

        #region MethodsPrivate

        private static List<BitrateData> GetBitRates()
        {
            List<BitrateData> bitRateList = new List<BitrateData>();

            BitrateData waveSampleRate44100 = new BitrateData();
            waveSampleRate44100.Bitrate = 44100;
            waveSampleRate44100.Description = @"44.100 Samples/Sek (1:1)";
            bitRateList.Add(waveSampleRate44100);

            BitrateData waveSampleRate22050 = new BitrateData();
            waveSampleRate22050.Bitrate = 22050;
            waveSampleRate22050.Description = @"22.050 Samples/Sek (1:1)";
            bitRateList.Add(waveSampleRate22050);

            BitrateData waveSampleRate11025 = new BitrateData();
            waveSampleRate11025.Bitrate = 11025;
            waveSampleRate11025.Description = @"11.025 Samples/Sek (1:1)";
            bitRateList.Add(waveSampleRate11025);

            return bitRateList;
        }

        #endregion

    }
}
