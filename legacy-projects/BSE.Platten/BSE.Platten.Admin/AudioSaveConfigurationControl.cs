using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using BSE.Platten.Common;

namespace BSE.Platten.Admin
{
    public partial class AudioSaveConfigurationControl : BaseConfigurationControl
    {
        #region EventsPublic

        public event EventHandler<CheckBoxChangeEventArgs> SaveCheckBoxChanged;

        #endregion

        #region MethodsPublic

        public AudioSaveConfigurationControl()
        {
            InitializeComponent();
        }

        public override void LoadConfigurationValues(BSE.Configuration.Configuration configuration)
        {
            this.m_fileOptions.LoadConfigurationValues(configuration);
        }

        public override void SaveConfigurationValues(BSE.Configuration.Configuration configuration)
        {
            this.m_fileOptions.SaveConfigurationValues(configuration);
        }

        public static IConfigurationData GetConfiguration(BSE.Configuration.Configuration configuration)
        {
            return FileConfigurationControl.GetConfiguration(configuration);
        }

        #endregion

        #region MethodsProtected
        #endregion

        #region MethodsPrivate

        private void m_fileOptions_CheckBoxChanged(object sender, CheckBoxChangeEventArgs e)
        {
            if (SaveCheckBoxChanged != null)
            {
                SaveCheckBoxChanged(this, new CheckBoxChangeEventArgs(e.ChangedCheckBox));
            }
        }

        private void m_fileOptions_ConfigChange(object sender, EventArgs e)
        {
            OnConfigChanging(new EventArgs());
        }
        
        #endregion
        
    }
}
