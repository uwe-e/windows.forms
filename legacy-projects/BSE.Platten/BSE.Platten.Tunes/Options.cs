using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using BSE.Configuration;
using BSE.Platten.Common;

namespace BSE.Platten.Tunes
{
    public partial class Options : BSE.Platten.Common.BaseDialog
    {
        #region FieldsPrivate

        private bool m_bEditBaseOptionsConfigChanging;
        private BSE.Configuration.Configuration m_configuration;

        #endregion

        #region Properties

        public BSE.Configuration.Configuration Configuration
        {
            get { return this.m_configuration; }
            set { this.m_configuration = value; }
        }

        #endregion

        #region MethodsPublic

        public Options()
        {
            InitializeComponent();
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
                if (this.m_bEditBaseOptionsConfigChanging)
                {
                    this.m_visualConfiguration.SaveObjects();
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
        
        private void VisualConfigurationChanged(object sender, ConfigChangeEventArgs e)
        {
            this.m_bEditBaseOptionsConfigChanging = true;
        }
        
        private void COptions_Load(object sender, EventArgs e)
        {
            if (this.m_configuration != null)
            {
                this.m_visualConfiguration.Configuration = this.m_configuration;
                this.m_visualConfiguration.LoadObjects();
            }
        }
        private void ButtonClearCoverflowCacheClick(object sender, EventArgs e)
        {
            BSE.Platten.Tunes.Cache.ImageFlowCache.DeleteCacheDirectory();
        }
        #endregion
        
    }
}