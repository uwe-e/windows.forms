using System;
using System.Collections.Generic;
using System.Text;

namespace BSE.Configuration
{
    public abstract class BaseConfiguration : IConfiguration
    {
		#region Konstanten

		/// <summary>
		/// Setzt das Corporate- Verzeichnis in welchem die Konfiguration gespeichert wird
		/// </summary>
        public const string ApplicationBaseDataDirectoryDefaultName = "BSE";

		#endregion
		
		#region Properties

        public abstract string ConfigFileName
        {
            get;
            set;
        }

		public abstract string ConfigFileExtension
		{
			get;
		}

		public string AssemblyName
		{
			get
			{
                try
                {
                    return System.Reflection.Assembly.GetEntryAssembly().GetName().Name;
                }
                catch
                {
                    return "Configuration";
                }
			}
		}

		public abstract string ApplicationBaseDataDirectory
		{
			get;
            set;
		}

        public abstract string ApplicationSubDirectory
        {
            get;
            set;
        }

		public abstract string ApplicationDataDirectory
		{
			get;
		}

        #endregion

        #region MethodsPublic

        public abstract object GetValue(string section, string element);
        /// <summary>
        /// Gets the value of an entry node
        /// </summary>
        /// <param name="section"></param>
        /// <param name="entry"></param>
        /// <param name="defaultValue"></param>
        /// <returns>value of this entry node if available else default value</returns>
        public virtual object GetValue(string section, string element, object defaultValue)
        {
            return GetValue(section, element);
        }
        public abstract object GetValue(string section, VisualObject visualObject);
        public abstract void SetValue(string section, string element, object value);
        public abstract void SaveAllVisualObjects(string section, VisualObject[] visualObjects);
        public abstract VisualObject[] GetAllVisualObjects(string section);

        #endregion            

    }
}
