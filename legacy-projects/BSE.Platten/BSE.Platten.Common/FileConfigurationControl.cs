using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using BSE.Platten.Common.Properties;

namespace BSE.Platten.Common
{
    public partial class FileConfigurationControl : BaseConfigurationControl
    {
        #region Konstanten

        public const string EachAlbumGetsDirectoryElement = "EachAlbumGetsDirectory";
        public const string TitleAsFileNameElement = "TitleAsFileName";

        #endregion
        
        #region Events

        public event EventHandler<CheckBoxChangeEventArgs> CheckBoxChanged;

        #endregion

        #region Properties

        public bool EnableEditSaveOptions
        {
            get { return this.Enabled; }
            set { this.Enabled = value; }
        }

        #endregion

        #region MethodsPublic

        public FileConfigurationControl()
        {
            InitializeComponent();
        }

        public override void SaveConfigurationValues(BSE.Configuration.Configuration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(
                    string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.IDS_ArgumentNullException, "configuration"));
            }
            FileConfigurationData configurationObject = new FileConfigurationData();
            configurationObject.EachAlbumGetsDirectory = this.m_chkEachAlbumGetsDirectory.Checked;
            configurationObject.TitleAsFileName = this.m_chkTitleAsFileName.Checked;

            configuration.SetValue(
                OptionsConfiguration,
                typeof(FileConfigurationData).Name,
                configurationObject);
            OnConfigChanging(new System.EventArgs());
        }

        public override void LoadConfigurationValues(BSE.Configuration.Configuration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(
                    string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.IDS_ArgumentNullException, "configuration"));
            }
            FileConfigurationData configurationObject =
                GetConfiguration(configuration) as FileConfigurationData;
            
            if (configurationObject != null)
            {
                this.m_chkEachAlbumGetsDirectory.Checked = configurationObject.EachAlbumGetsDirectory;
                this.m_chkTitleAsFileName.Checked = configurationObject.TitleAsFileName;
            }
        }

        public static IConfigurationData GetConfiguration(BSE.Configuration.Configuration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(
                    string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.IDS_ArgumentNullException, "configuration"));
            }
            return configuration.GetValue(
                OptionsConfiguration,
                typeof(FileConfigurationData).Name,
                new FileConfigurationData()) as FileConfigurationData;
        }
        
        public void SetSaveCheckBox(CheckBox changedCheckBox)
        {
            if (changedCheckBox == null)
            {
                throw new ArgumentNullException(
                    string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.IDS_ArgumentNullException, "changedCheckBox"));
            }
            foreach (Control control in this.m_grpDirectoryInfo.Controls)
            {
                CheckBox checkBox = control as CheckBox;
                if (checkBox != null)
                {
                    if (checkBox.Name == changedCheckBox.Name)
                    {
                        checkBox.Checked = changedCheckBox.Checked;
                    }
                }
            }
        }

        #endregion

        #region MethodsProtected

        protected virtual void OnCheckBoxChanged(CheckBoxChangeEventArgs e)
        {
            if (CheckBoxChanged != null)
            {
                CheckBoxChanged(this, e);
            }
        }

        #endregion

        #region MethodsPrivate

        private void Checkbox_Click(object sender, EventArgs e)
        {
            CheckBox changedCheckBox = (CheckBox)sender;
            OnConfigChanging(new EventArgs());
            OnCheckBoxChanged(new CheckBoxChangeEventArgs(changedCheckBox));
        }

        #endregion
    }
}
