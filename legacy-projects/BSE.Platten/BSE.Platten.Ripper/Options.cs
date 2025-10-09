using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using BSE.Platten.Common;

namespace BSE.Platten.Ripper
{
    /// <summary>
    /// Provides the capability to diplay the ripper options.
    /// </summary>
    public partial class OptionsDialog : BSE.Platten.Common.BaseDialog
    {
        #region FieldsPrivate

        private BSE.Configuration.Configuration m_configuration;
        private bool m_bRippingOptionsChange;

        #endregion

        #region MethodsPublic
        /// <summary>
        /// Initializes a new instance of the <see cref="OptionsDialog"/> class.
        /// </summary>
        public OptionsDialog()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="OptionsDialog"/> class.
        /// </summary>
        /// <param name="configuration">The <see cref="BSE.Configuration.Configuration"/> object with the application settings</param>
        public OptionsDialog(BSE.Configuration.Configuration configuration) : this()
		{
			this.m_configuration = configuration;
			this.m_rippingOptions.LoadConfigurationValues(this.m_configuration);
		}

        #endregion

        #region MethodsProtected
        /// <summary>
        /// Saves the application settings.
        /// </summary>
        /// <returns></returns>
        protected override bool SaveSettings()
        {
            try
            {
                if (this.m_bRippingOptionsChange == true)
                {
                    this.m_rippingOptions.SaveConfigurationValues(this.m_configuration);
                    OnConfigurationChanged(new EventArgs());
                }
                return true;
            }
            catch (Exception exception)
            {
                GlobalizedMessageBox.Show(this,exception.Message,MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        #endregion

        #region MethodsPrivate
        
        private void m_rippingOptions_ConfigChange(object sender, EventArgs e)
        {
            this.m_bRippingOptionsChange = true;
        }
        
        #endregion
        
    }
}