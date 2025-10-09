using System;
using System.Collections.Generic;
using System.Text;

namespace BSE.Platten.Common
{
    public interface IConfigurationSettings
    {
        string ConfigurationFolder { get;}
        string ConfigurationFileName { get;}
        string SettingsFileName { get;}
    }
}
