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
    public partial class CAudioImportConfigurationControl : BaseConfigurationControl
    {
        #region Properties

        public bool EnableAudioImportOptions
        {
            get { return this.m_fileOptions.Enabled; }
            set { this.m_fileOptions.Enabled = value; }
        }

        #endregion

        #region MethodsPublic

        public CAudioImportConfigurationControl()
        {
            InitializeComponent();
        }

        public override void LoadConfigurationValues(BSE.Configuration.Configuration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException("configuration",
                    string.Format(System.Globalization.CultureInfo.InvariantCulture,
                    Properties.Resources.IDS_ArgumentNullException ,
                    "configuration"));
            }

            AudioImportConfigurationData configurationObject =
                GetConfiguration(configuration)  as AudioImportConfigurationData;

            if (configurationObject != null)
            {
                if (configurationObject.FileOperations == BSE.Shell.FileOperation.FO_MOVE)
                {
                    this.m_chkCopyOrMove.Checked = false;
                }
                if (configurationObject.FileOperations == BSE.Shell.FileOperation.FO_COPY)
                {
                    this.m_chkCopyOrMove.Checked = true;
                }
            }
            this.m_fileOptions.LoadConfigurationValues(configuration);
        }

        public override void SaveConfigurationValues(BSE.Configuration.Configuration configuration)
        {
            AudioImportConfigurationData configurationObject = new AudioImportConfigurationData();
            if (this.m_chkCopyOrMove.Checked == true)
            {
                configurationObject.FileOperations = BSE.Shell.FileOperation.FO_COPY;
            }
            else
            {
                configurationObject.FileOperations = BSE.Shell.FileOperation.FO_MOVE;
            }
            configuration.SetValue(
                OptionsConfiguration,
                typeof(AudioImportConfigurationData).Name,
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
                    Properties.Resources.IDS_ArgumentNullException,
                    "configuration"));
            }
            return configuration.GetValue(
               BSE.Platten.Common.BaseConfigurationControl.OptionsConfiguration,
               typeof(AudioImportConfigurationData).Name,
               new AudioImportConfigurationData()) as AudioImportConfigurationData;
        }

        public void SetSaveOptionsCheckBox(CheckBox changedCheckBox)
        {
            this.m_fileOptions.SetSaveCheckBox(changedCheckBox);
        }

        #endregion

        #region MethodsPrivate

        private void m_chkCopyOrMove_Click(object sender, EventArgs e)
        {
            OnConfigChanging(new EventArgs());
        }

        private void m_fileOptions_ConfigChange(object sender, EventArgs e)
        {
            OnConfigChanging(new EventArgs());
        }

        #endregion
    }
}
