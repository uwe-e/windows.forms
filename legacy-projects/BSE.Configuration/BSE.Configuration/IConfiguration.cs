using System;
using System.Collections.Generic;
using System.Text;

namespace BSE.Configuration
{
    public interface IConfiguration
    {
		string AssemblyName { get;}
        string ApplicationBaseDataDirectory { get; set;}
		string ApplicationDataDirectory { get;}
        string ApplicationSubDirectory { get;set;}
        string ConfigFileExtension { get;}
		string ConfigFileName { get;set;}
        object GetValue(string section, string element);
        object GetValue(string section, string element, object defaultValue);
        object GetValue(string section, VisualObject visualObject);
        void SetValue(string section, string element, object value);
        void SaveAllVisualObjects(string section, VisualObject[] visualObjects);
        VisualObject[] GetAllVisualObjects(string section);
    }
}
