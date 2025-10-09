using System;
using System.Collections.Generic;
using System.Text;

namespace BSE.Platten.Common
{
    public interface IOptionsConfiguration
    {
        event System.EventHandler ConfigChanging;
        void SaveConfigurationValues(BSE.Configuration.Configuration configuration);
        void LoadConfigurationValues(BSE.Configuration.Configuration configuration);
    }
}
