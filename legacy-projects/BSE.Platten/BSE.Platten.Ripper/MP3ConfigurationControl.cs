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
using BSE.Platten.Ripper.Lame;
using BSE.Platten.Ripper.AudioWriters;

namespace BSE.Platten.Ripper
{
    public partial class MP3ConfigurationControl : BaseConfigurationControl , IAudioWriterConfiguration
    {
        #region Konstanten

        private const string Mpeg1BitRates = "32,40,48,56,64,80,96,112,128,160,192,224,256,320";
        private const string Mpeg2BitRates = "8,16,24,32,40,48,56,64,80,96,112,128,144,160";

        #endregion

        #region FieldsPrivate

        private BSE.Configuration.Configuration m_configuration;
        private WaveFormat m_waveFormat;

        #endregion

        #region Properties

        public WaveWriterConfiguration AudioWriterConfiguration
        {
            get
            {
                MP3ConfigurationData configurationObject = GetConfiguration(this.m_configuration) as MP3ConfigurationData;
                BeConfiguration config = new BeConfiguration(this.m_waveFormat, configurationObject.BitrateMpeg1);
                config.Format.LHV1.Copyright = configurationObject.CopyrightBit ? 1 : 0;
                config.Format.LHV1.CRC = configurationObject.CRCChecksum ? 1 : 0;
                config.Format.LHV1.Original = configurationObject.OriginalBit ? 1 : 0;
                config.Format.LHV1.Private = configurationObject.PrivateBit ? 1 : 0;
                config.Format.LHV1.Mode = configurationObject.MpegMode;

                return new MP3WriterConfiguration(this.m_waveFormat, config);
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

        public MP3ConfigurationControl()
        {
            InitializeComponent();
        }

        public MP3ConfigurationControl(BSE.Configuration.Configuration configuration)
            : this()
        {
            this.m_configuration = configuration;
            this.m_waveFormat = new WaveFormat(
                Constants.WavSamplesPerSecDefaultValue,
                Constants.WavBitsPerSampleDefaultValue,
                Constants.WavChannelsDefaultValue
                ); //Set default values
            SetConfigurationValues(this.m_configuration, false);
        }
        
        public void SetConfigurationValues(BSE.Configuration.Configuration configuration, bool externalOutputConfiguration)
        {
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
            MP3ConfigurationData configurationObject =
                GetConfiguration(configuration) as MP3ConfigurationData;

            if (configurationObject != null)
            {
                this.m_cboBitRate.DataSource = GetBitRatesMpeg1();
                this.m_cboBitRate.ValueMember = "Bitrate";
                this.m_cboBitRate.DisplayMember = "Description";
                this.m_cboBitRate.SelectedValue = configurationObject.BitrateMpeg1;
                if (configurationObject.MpegMode == MPEGMode.JointStereo)
                {
                    this.m_rdoJointStereo.Checked = true;
                }
                if (configurationObject.MpegMode == MPEGMode.Stereo)
                {
                    this.m_rdo2ChannelStereo.Checked = true;
                }
                /*
                 * not longer in use
                 */
                //this.m_chkCopyRight.Checked = configurationObject.CopyrightBit;
                //this.m_chkCRC.Checked = configurationObject.CRCChecksum;
                //this.m_chkOrigin.Checked = configurationObject.OriginalBit;
                //this.m_chkPrivate.Checked = configurationObject.PrivateBit;
            }
        }

        public override void SaveConfigurationValues(BSE.Configuration.Configuration configuration)
        {
            this.m_configuration = configuration;

            MP3ConfigurationData configurationObject = new MP3ConfigurationData();
            configurationObject.BitrateMpeg1 = int.Parse(this.m_cboBitRate.SelectedValue.ToString(),CultureInfo.InvariantCulture);
            configurationObject.MpegMode = MPEGMode.Stereo;
            if (this.m_rdoJointStereo.Checked == true)
            {
                configurationObject.MpegMode = MPEGMode.JointStereo;
            }
            /*
             * not longer in use
            */
            //configurationObject.CopyrightBit = this.m_chkCopyRight.Checked;
            //configurationObject.CRCChecksum = this.m_chkCRC.Checked;
            //configurationObject.OriginalBit = this.m_chkOrigin.Checked;
            //configurationObject.PrivateBit = this.m_chkPrivate.Checked;

            configuration.SetValue(
                BaseConfigurationControl.OptionsConfiguration,
                typeof(MP3ConfigurationData).Name,
                configurationObject);
            OnConfigChanging(new System.EventArgs());
        }

        public static IConfigurationData GetConfiguration(BSE.Configuration.Configuration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(
                    string.Format(
                    CultureInfo.InvariantCulture, Resources.IDS_ArgumentNullException, "configuration"));
            }
            
            return configuration.GetValue(
                BSE.Platten.Common.BaseConfigurationControl.OptionsConfiguration,
                typeof(MP3ConfigurationData).Name,
                new MP3ConfigurationData()) as MP3ConfigurationData;
        }

        #endregion

        #region MethodsPrivate
        
        private void m_btnAboutLame_Click(object sender, EventArgs e)
        {
            LameAboutForm  lameAbout = new LameAboutForm();
            lameAbout.ShowDialog();
        }
        
        private static List<BitrateData> GetBitRatesMpeg1()
        {
            List<BitrateData> bitRateList = new List<BitrateData>();
            
            BitrateData bitRateMpeg32 = new BitrateData();
            bitRateMpeg32.Bitrate = 32;
            bitRateMpeg32.Description = 32 + @"kBit/sek";
            bitRateList.Add(bitRateMpeg32);
            
            BitrateData bitRateMpeg40 = new BitrateData();
            bitRateMpeg40.Bitrate = 40;
            bitRateMpeg40.Description = 40 + @"kBit/sek";
            bitRateList.Add(bitRateMpeg40);
            
            BitrateData bitRateMpeg48 = new BitrateData();
            bitRateMpeg48.Bitrate = 48;
            bitRateMpeg48.Description = 48 + @"kBit/sek";
            bitRateList.Add(bitRateMpeg48);
            
            BitrateData bitRateMpeg56 = new BitrateData();
            bitRateMpeg56.Bitrate = 56;
            bitRateMpeg56.Description = 56 + @"kBit/sek";
            bitRateList.Add(bitRateMpeg56);
            
            BitrateData bitRateMpeg64 = new BitrateData();
            bitRateMpeg64.Bitrate = 64;
            bitRateMpeg64.Description = 64 + @"kBit/sek";
            bitRateList.Add(bitRateMpeg64);
            
            BitrateData bitRateMpeg80 = new BitrateData();
            bitRateMpeg80.Bitrate = 80;
            bitRateMpeg80.Description = 80 + @"kBit/sek";
            bitRateList.Add(bitRateMpeg80);
            
            BitrateData bitRateMpeg96 = new BitrateData();
            bitRateMpeg96.Bitrate = 96;
            bitRateMpeg96.Description = 96 + @"kBit/sek";
            bitRateList.Add(bitRateMpeg96);
            
            BitrateData bitRateMpeg112 = new BitrateData();
            bitRateMpeg112.Bitrate = 112;
            bitRateMpeg112.Description = 112 + @"kBit/sek";
            bitRateList.Add(bitRateMpeg112);
            
            BitrateData bitRateMpeg128 = new BitrateData();
            bitRateMpeg128.Bitrate = 128;
            bitRateMpeg128.Description = 128 + @"kBit/sek";
            bitRateList.Add(bitRateMpeg128);
            
            BitrateData bitRateMpeg160 = new BitrateData();
            bitRateMpeg160.Bitrate = 160;
            bitRateMpeg160.Description = 160 + @"kBit/sek";
            bitRateList.Add(bitRateMpeg160);
            
            BitrateData bitRateMpeg192 = new BitrateData();
            bitRateMpeg192.Bitrate = 192;
            bitRateMpeg192.Description = 192 + @"kBit/sek";
            bitRateList.Add(bitRateMpeg192);
            
            BitrateData bitRateMpeg224 = new BitrateData();
            bitRateMpeg224.Bitrate = 224;
            bitRateMpeg224.Description = 224 + @"kBit/sek";
            bitRateList.Add(bitRateMpeg224);
            
            BitrateData bitRateMpeg256 = new BitrateData();
            bitRateMpeg256.Bitrate = 256;
            bitRateMpeg256.Description = 256 + @"kBit/sek";
            bitRateList.Add(bitRateMpeg256);
            
            BitrateData bitRateMpeg320 = new BitrateData();
            bitRateMpeg320.Bitrate = 320;
            bitRateMpeg320.Description = 320 + @"kBit/sek";
            bitRateList.Add(bitRateMpeg320);

            return bitRateList;
        }

        #endregion

    }
}
