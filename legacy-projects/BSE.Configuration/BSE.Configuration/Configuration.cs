using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace BSE.Configuration
{
    public partial class Configuration : Component, IConfiguration
	{
		#region Konstanten

		public const string VisualObjectsElementName = "VisualObjects";

		#endregion

		#region FieldsPrivate

		private IConfiguration m_configuration;

        #endregion

        #region Properties

        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.Description("Gets or sets the name of the config- file")]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public string ConfigFileName
        {
            get { return this.m_configuration.ConfigFileName; }
            set { this.m_configuration.ConfigFileName = value; }
        }
        [Category("Appearance")]
        [Description("Gets the extension of the config- file")]
		public string ConfigFileExtension
		{
			get { return this.m_configuration.ConfigFileExtension; }
		}
        [Category("Appearance")]
        [Description("Gets the name of the entry- assembly")]
		public string AssemblyName
		{
			get { return this.m_configuration.AssemblyName; }
		}
        [Category("Appearance")]
        [Description("Gets or sets the corporate directory for user settings")]
        [DefaultValue(BaseConfiguration.ApplicationBaseDataDirectoryDefaultName)]
		public string ApplicationBaseDataDirectory
		{
			get { return this.m_configuration.ApplicationBaseDataDirectory; }
            set { this.m_configuration.ApplicationBaseDataDirectory = value; }
		}
        [Category("Appearance")]
        [Description("Gets the applicationdata directory for user settings")]
		public string ApplicationDataDirectory
		{
			get { return this.m_configuration.ApplicationDataDirectory; }
		}
        [Category("Appearance")]
        [Description("Gets or sets the directory for user settings")]
        public string ApplicationSubDirectory
        {
            get { return this.m_configuration.ApplicationSubDirectory; }
            set { this.m_configuration.ApplicationSubDirectory = value; }
        }

        #endregion

        #region MethodsPublic

        public Configuration()
        {
            InitializeComponent();
            this.m_configuration = new XmlConfiguration();
        }

        /// <summary>
        /// gets the sections value of the configuration
        /// </summary>
        /// <param name="section">section element in configuration</param>
        /// <param name="element">entry element in configuration</param>
        /// <returns>value as object (returns null if no value is available</returns>
        public object GetValue(string section, string element)
        {
            return this.m_configuration.GetValue(section, element);
        }

        /// <summary>
        /// Get the configuration value of an entry element as object. The object must be casted to the needed type
        /// </summary>
        /// <param name="section"></param>
        /// <param name="element"></param>
        /// <param name="defaultValue"></param>
        /// <returns>object of the needed type (cast)</returns>
        public object GetValue(string section, string element, object defaultValue)
        {
            return this.m_configuration.GetValue(section, element, defaultValue);
        }
        
        /// <summary>
        /// Get the configuration value of an entry element as object. The object must be casted to the needed type
        /// </summary>
        /// <param name="section">section element in configuration</param>
        /// <param name="element">entry element in configuration</param>
        /// <param name="visualObject">CVisualObject with description and type informations</param>
        /// <param name="valueNotFoundMessage">the error message if no value in configuration</param>
        /// <returns>value as string</returns>
        public object GetValue(string section, VisualObject visualObject)
        {
            return this.m_configuration.GetValue(section, visualObject);
        }
        /// <summary>
        /// Set the configuration value of an entry element as object. The object must be casted to the needed type
        /// </summary>
        /// <param name="section">section element</param>
        /// <param name="element">entry element</param>
        /// <param name="value">value of an entry element (cast to your type)</param>
        public void SetValue(string section, string element, object value)
        {
            this.m_configuration.SetValue(section, element, value);
        }
        /// <summary>
        /// Saves all VisualObjects in configuration. It's used by the CConfigListView
        /// </summary>
        /// <param name="section">Constant CConstants.VisualObjects</param>
        /// <param name="visualObjects">array of CVisualObject</param>
        public void SaveAllVisualObjects(string section, VisualObject[] visualObjects)
        {
            this.m_configuration.SaveAllVisualObjects(section, visualObjects);
        }

        /// <summary>
        /// Gets all VisualObjects in configuration. It's used by the CConfigListView
        /// </summary>
        /// <param name="section">Constant CConstants.VisualObjects</param>
        /// <returns>array of CVisualObject</returns>
        public VisualObject[] GetAllVisualObjects(string section)
        {
            return this.m_configuration.GetAllVisualObjects(section);
        }

        #endregion

    }
}
