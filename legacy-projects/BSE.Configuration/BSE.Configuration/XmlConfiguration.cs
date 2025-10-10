using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Globalization;

namespace BSE.Configuration
{
    public class XmlConfiguration : BaseConfiguration
	{
		#region Konstanten

		private const string m_strConfigFileExtension = ".xml";

		#endregion

		#region FieldsPrivate

		private string m_strConfigFileName;
        private string m_strApplicationBaseDataDirectory;
        private string m_strApplicationSubDirectory;

        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the name of the configfile
        /// </summary>
        public override string ConfigFileName
        {
            get
            {
                if (String.IsNullOrEmpty(this.m_strConfigFileName) == true)
                {
                    this.m_strConfigFileName = this.AssemblyName;
                }
                return this.m_strConfigFileName;
            }
            set
            {
                this.m_strConfigFileName = value;
            }
        }
        /// <summary>
        /// Gets or sets the extension of the configfile
        /// </summary>
		public override string ConfigFileExtension
		{
			get { return m_strConfigFileExtension ; }
		}
        /// <summary>
        /// Gets or sets the name of the ApplicationDataDirectory
        /// </summary>
		public override string ApplicationDataDirectory
		{
			get
			{
				string strPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
				if (strPath.EndsWith(Convert.ToString(System.IO.Path.DirectorySeparatorChar,CultureInfo.InvariantCulture),StringComparison.OrdinalIgnoreCase) == false)
				{
					strPath += System.IO.Path.DirectorySeparatorChar;
				}
				strPath += this.ApplicationBaseDataDirectory;
				strPath += System.IO.Path.DirectorySeparatorChar;
				if (Directory.Exists(strPath) == false)
				{
					Directory.CreateDirectory(strPath);
				}
				return strPath;
			}
		}
        /// <summary>
        /// Gets or sets the name of the ApplicationBaseDataDirectory
        /// </summary>
        public override string ApplicationBaseDataDirectory
        {
            get
            {
                if (String.IsNullOrEmpty(this.m_strApplicationBaseDataDirectory) == true)
                {
                    this.m_strApplicationBaseDataDirectory = BaseConfiguration.ApplicationBaseDataDirectoryDefaultName;
                }
                return this.m_strApplicationBaseDataDirectory;
            }
            set { this.m_strApplicationBaseDataDirectory = value; }
        }
        /// <summary>
        /// Gets or sets the name of the ApplicationSubDirectory
        /// </summary>
        public override string ApplicationSubDirectory
        {
            get
            {
                if (String.IsNullOrEmpty(this.m_strApplicationSubDirectory) == false)
                {
                    if (this.m_strApplicationSubDirectory.EndsWith(Convert.ToString(System.IO.Path.DirectorySeparatorChar,CultureInfo.InvariantCulture),StringComparison.OrdinalIgnoreCase)== false)
                    {
                        this.m_strApplicationSubDirectory += System.IO.Path.DirectorySeparatorChar;
                    }
                    if (Directory.Exists(this.ApplicationDataDirectory + this.m_strApplicationSubDirectory) == false)
                    {
                        Directory.CreateDirectory(this.ApplicationDataDirectory + this.m_strApplicationSubDirectory);
                    }
                }
                return this.m_strApplicationSubDirectory; 
            }
            set
            {
                this.m_strApplicationSubDirectory = value;
                
            }
        }

        #endregion

        #region MethodsPublic
        /// <summary>
        /// The constructor
        /// </summary>
		public XmlConfiguration()
		{
		}
        /// <summary>
        ///  Gets a saved value from a section
        /// </summary>
        /// <param name="section">The section</param>
        /// <param name="element">The element</param>
        /// <returns>The node of the value as object</returns>
        public override object GetValue(string section, string element)
        {
            object value = null;
            try
            {
                string strFullName = GetConfigurationFullName();
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(strFullName);
                value = xmlDocument.SelectSingleNode("//" + section + "/" + element + "");
            }
            catch { }
            return value;
        }
        /// <summary>
        /// Gets a saved value from a section
        /// </summary>
        /// <param name="section">The section which contains the VisualObject</param>
        /// <param name="element">The element which contains the VisualObject</param>
        /// <param name="defaultValue">The default value</param>
        /// <returns>The value</returns>
        public override object GetValue(string section, string element, object defaultValue)
        {
            object value = base.GetValue(section, element, defaultValue);
            if (value == null)
            {
                return defaultValue;
            }
            else
            {
                XmlNode xmlNode = value as XmlNode;
                Type type = defaultValue.GetType();
                XmlSerializer xmlSerializer = new XmlSerializer(type);
                object desirializedObject;
                using (StringReader stringReader = new StringReader(xmlNode.InnerXml))
                {
                    desirializedObject = xmlSerializer.Deserialize(stringReader);
                }
                return desirializedObject;
            }
        }
        /// <summary>
        /// Gets a saved VisualObject from a section
        /// </summary>
        /// <param name="section">The section which contains the VisualObject</param>
        /// <param name="visualObject">The VisualObject with the default data</param>
        /// <returns>The VisualObject with the data</returns>
        public override object GetValue(string section, VisualObject visualObject)
        {
            string strValue = null;
            string strFullName = GetConfigurationFullName();
            if (IfXmlFileExists(strFullName) == true)
            {
				if (string.IsNullOrEmpty(visualObject.Element))
				{
                    throw new ArgumentException("the property visualobject.Element has no value");
				}
				if (string.IsNullOrEmpty(visualObject.Description))
				{
                    throw new ArgumentException("the property visualobject.Description has no value");
				}
				
				XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(strFullName);
                
                XmlNode selectXmlNode = xmlDocument.SelectSingleNode("//" + section + "/" + visualObject.Element + "");
                if (selectXmlNode == null)
                {
                    XmlNode sectionXmlNode = GetSectionsNode(xmlDocument, section);
                    XmlNode elementXmlNode = GetElementNode(xmlDocument, sectionXmlNode, visualObject.Element);
                    SetValue(sectionXmlNode.Name, elementXmlNode.Name, visualObject);

					throw new ConfigurationValueNotFoundException(visualObject.ErrorMessage);
                }
                else
                {
					visualObject = GetValue(section, visualObject.Element, visualObject) as VisualObject;
                    if (visualObject != null)
                    {
                        if (string.IsNullOrEmpty(visualObject.Value))
                        {
							throw new ConfigurationValueNotFoundException(visualObject.ErrorMessage);
                        }
                        else
                        {
                            strValue = visualObject.Value;
                        }
                    }
                }
            }
            return strValue;
        }
        /// <summary>
        /// Saves a value in an element into a section 
        /// </summary>
        /// <param name="section">The section in which the value are saved</param>
        /// <param name="element">An element in which the value are saved</param>
        /// <param name="value">The value to save</param>
        public override void SetValue(string section, string element, object value)
        {
            string strFullName = GetConfigurationFullName();
            if (IfXmlFileExists(strFullName) == true)
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(strFullName);

                XmlNode sectionXmlNode = GetSectionsNode(xmlDocument, section);
                XmlNode elementXmlNode = GetElementNode(xmlDocument, sectionXmlNode, element);

                try
                {
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        XmlSerializer serializer = new XmlSerializer(value.GetType());
                        serializer.Serialize(memoryStream, value);
                        memoryStream.Seek(0, System.IO.SeekOrigin.Begin);

                        XmlDocument doc = new XmlDocument();
                        doc.Load(memoryStream);

                        XmlNode xmlNode = doc.LastChild;
                        if (xmlNode != null)
                        {
                            //Bevor die aktuellen Nodes geschrieben werden müssen alle ChildNodes
                            //gelöscht werden
                            elementXmlNode.RemoveAll();
                            XmlNode newRootNode = xmlDocument.ImportNode(xmlNode, true);
                            elementXmlNode.AppendChild(newRootNode);
                        }
                    }
                    xmlDocument.Save(strFullName);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        /// <summary>
        /// Saves all visualObject values in a section into the xml- configuration file
        /// </summary>
        /// <param name="section">The section in which the visualobjects are saved</param>
        /// <param name="visualObjects">The visualObjetcs with the values</param>
        public override void SaveAllVisualObjects(string section, VisualObject[] visualObjects)
        {
            if (visualObjects != null)
            {
                foreach (VisualObject visualObject in visualObjects)
                {
                    SetValue(section, visualObject.Element, visualObject);
                }
            }
        }
        /// <summary>
        /// Gets all the visualObject values in the section
        /// </summary>
        /// <param name="section">The section in which the visualobjects are saved</param>
        /// <returns>The visualObjetcs with the values</returns>
        public override VisualObject[] GetAllVisualObjects(string section)
        {
            VisualObject[] visualObjects = null;
            string strFullName = GetConfigurationFullName();
            if (IfXmlFileExists(strFullName) == true)
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(strFullName);

                XmlNode selectXmlNode = xmlDocument.SelectSingleNode("//" + section + "");
                if (selectXmlNode != null)
                {
                    visualObjects = new VisualObject[selectXmlNode.ChildNodes.Count];
                    int i = 0;
                    foreach (XmlNode xmlNode in selectXmlNode.ChildNodes)
                    {
                        using (StringReader stringReader = new StringReader(xmlNode.InnerXml))
                        {
                            XmlSerializer xmlSerializer = new XmlSerializer(typeof(VisualObject));
                            visualObjects[i] = (VisualObject)xmlSerializer.Deserialize(stringReader);
                            i++;
                        }
                    }
                }
            }
            return visualObjects;
        }

        #endregion

        #region MethodsPrivate

        private string GetConfigurationFullName()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(this.ApplicationDataDirectory);
            if (String.IsNullOrEmpty(this.ApplicationSubDirectory) == false)
            {
                stringBuilder.Append(this.ApplicationSubDirectory);
            }
            if (String.IsNullOrEmpty(this.ConfigFileName) == false)
            {
                stringBuilder.Append(this.ConfigFileName);
            }
            stringBuilder.Append(this.ConfigFileExtension);

            return stringBuilder.ToString();
        }

        private static bool IfXmlFileExists(string strFullName)
        {
            bool bXmlFileExists = false;
            if (File.Exists(strFullName) == false)
            {
                try
                {
                    using (StreamWriter streamWriter = new StreamWriter(strFullName))
                    {
                        XmlSerializer xmlSerializer = new XmlSerializer(typeof(XmlBaseDocument));
                        xmlSerializer.Serialize(streamWriter, new XmlBaseDocument());
                        bXmlFileExists = true;
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                bXmlFileExists = true;
            }

            return bXmlFileExists;
        }

        private static XmlNode GetSectionsNode(XmlDocument xmlDocument, string section)
        {
            XmlElement rootXmlElement = xmlDocument.DocumentElement;
            XmlNode sectionXmlNode = rootXmlElement.SelectSingleNode("//" + section + "");
            if (sectionXmlNode == null)
            {
                XmlElement xmlElement = xmlDocument.CreateElement(section);
                sectionXmlNode = rootXmlElement.AppendChild(xmlElement);
            }
            return sectionXmlNode;
        }

        private static XmlNode GetElementNode(XmlDocument xmlDocument, XmlNode parentXmlNode, string element)
        {
            XmlNode elementXmlNode = parentXmlNode.SelectSingleNode("//" + parentXmlNode.Name + "/" + element + "");
            if (elementXmlNode == null)
            {
                XmlElement xmlElement = xmlDocument.CreateElement(element);
                elementXmlNode = parentXmlNode.AppendChild(xmlElement);
            }

            return elementXmlNode;
        }

        #endregion
    }
}
