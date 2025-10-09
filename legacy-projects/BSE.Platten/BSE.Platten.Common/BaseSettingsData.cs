using System;
using System.Collections.Generic;
using System.Text;

namespace BSE.Platten.Common
{
    public abstract class BaseSettingsData
    {
        #region MethodsPublic
        
        public abstract BaseSettingsData LoadSettings(object objSettingsFor, BSE.Configuration.Configuration objConfiguration, BaseSettingsData baseSettingsData);
        public abstract BaseSettingsData SaveSettings(object objSettingsFor, BSE.Configuration.Configuration objConfiguration, BaseSettingsData baseSettingsData);

        #endregion
    }
}
