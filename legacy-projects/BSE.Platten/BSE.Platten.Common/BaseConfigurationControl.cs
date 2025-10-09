using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace BSE.Platten.Common
{
    [DesignTimeVisible(false)]
    [DefaultEvent("ConfigChanged")]
    public partial class BaseConfigurationControl : UserControl, IOptionsConfiguration
    {
        #region EventsPublic
        /// <summary>
        /// Occurs when the configuration in the configuration control changes. 
        /// </summary>
        [Description("Occurs when the configuration in the configuration control changes.")]
        public virtual event System.EventHandler ConfigChanging;
        #endregion

        #region Constants
        /// <summary>
        /// Gets the name of the main element for the configuration settings
        /// </summary>
        public const string OptionsConfiguration = "options";

        #endregion

        #region FieldsPrivate

        private string m_strText;

        #endregion

        #region Properties

        [BindableAttribute(true)]
        public override string Text
        {
            get { return this.m_strText; }
            set { this.m_strText = value; }
        }

        #endregion

        #region MethodsPublic

        public BaseConfigurationControl()
        {
            InitializeComponent();
        }

        public virtual void SaveConfigurationValues(BSE.Configuration.Configuration configuration)
        {
        }

        public virtual void LoadConfigurationValues(BSE.Configuration.Configuration configuration)
        {
        }

        #endregion

        #region MethodsProtected
        /// <summary>
        /// Raises the ConfigChanging event.
        /// </summary>
        /// <param name="e">A EventArgs that contains the event data.</param>
        protected virtual void OnConfigChanging(System.EventArgs e)
        {
            if (ConfigChanging != null)
            {
                ConfigChanging(this, e);
            }
        }
        #endregion

    }
}
