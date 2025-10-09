using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using BSE.Platten.Common;
using System.Globalization;
using BSE.Platten.Audio.Properties;

namespace BSE.Platten.Audio
{
    public partial class CWinampConfigurationControl : BaseConfigurationControl
    {
        #region MethodsPublic

        public CWinampConfigurationControl()
        {
            InitializeComponent();
            this.Text = Resources.IDS_WinampPropertiesTitle;
            this.m_lblPath.Text = Resources.IDS_WinampPropertiesPathTo;
        }

        public override void LoadConfigurationValues(BSE.Configuration.Configuration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException("configuration",
                    string.Format(System.Globalization.CultureInfo.InvariantCulture,
                    Properties.Resources.IDS_ArgumentNullException,
                    "configuration"));
            }
            
            WinampConfigurationData winampConfigurationObject = 
                GetConfiguration(configuration) as WinampConfigurationData;
            
            if (winampConfigurationObject != null)
            {
                this.m_txtPath.Text = winampConfigurationObject.FileName;
            }
        }

        public override void SaveConfigurationValues(BSE.Configuration.Configuration configuration)
        {
            WinampConfigurationData winampConfigurationObject = new WinampConfigurationData();
            winampConfigurationObject.FileName = this.m_txtPath.Text;
            configuration.SetValue(
                BaseConfigurationControl.OptionsConfiguration,
                typeof(WinampConfigurationData).Name,
                winampConfigurationObject);
        }

        public static IConfigurationData GetConfiguration(BSE.Configuration.Configuration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException("configuration",
                    string.Format(System.Globalization.CultureInfo.InvariantCulture,
                    Properties.Resources.IDS_ArgumentNullException,
                    "configuration"));
            }
            return configuration.GetValue(
               BSE.Platten.Common.BaseConfigurationControl.OptionsConfiguration,
               typeof(WinampConfigurationData).Name,
               new WinampConfigurationData()) as WinampConfigurationData;
        }

        #endregion

        #region MethodsPrivate

        private void m_btnConfig_Click(object sender, EventArgs e)
        {
            if (this.m_ofdlgFileSearch.ShowDialog() == DialogResult.OK)
            {
                if (String.IsNullOrEmpty(this.m_ofdlgFileSearch.FileName) == false)
                {
                    string strPath = string.Format(
                        CultureInfo.InvariantCulture,
                        this.m_ofdlgFileSearch.FileName.ToLower(CultureInfo.InvariantCulture));
                    if (strPath.EndsWith("winamp.exe", StringComparison.OrdinalIgnoreCase) == true)
                    {
                        this.m_txtPath.Text = this.m_ofdlgFileSearch.FileName;
                        OnConfigChanging(new EventArgs());
                    }
                }
            }
        }

        #endregion
    }
}
