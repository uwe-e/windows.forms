using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using BSE.Platten.Common.Properties;

namespace BSE.Platten.Common
{
    public class BaseControlSettingsData : BaseSettingsData
    {
        #region MethodsPublic

        public override BaseSettingsData LoadSettings(object objSettingsFor, BSE.Configuration.Configuration objConfiguration, BaseSettingsData baseSettingsData)
        {
            if (objSettingsFor == null)
            {
                throw new ArgumentNullException(
                    string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.IDS_ArgumentNullException, "objSettingsFor"));
            }

            if (objConfiguration == null)
            {
                throw new ArgumentNullException(
                    string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.IDS_ArgumentNullException, "objConfiguration"));
            }
            
            BaseControlSettingsData baseControlSettingsData = baseSettingsData as BaseControlSettingsData;
            if (baseControlSettingsData != null)
            {
                baseControlSettingsData = objConfiguration.GetValue(objSettingsFor.GetType().ToString(), baseControlSettingsData.GetType().ToString(), baseControlSettingsData) as BaseControlSettingsData;
            }
            return baseControlSettingsData;
        }

        public override BaseSettingsData SaveSettings(object objSettingsFor, BSE.Configuration.Configuration objConfiguration, BaseSettingsData baseSettingsData)
        {
            if (objSettingsFor == null)
            {
                throw new ArgumentNullException(
                    string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.IDS_ArgumentNullException, "objSettingsFor"));
            }

            if (objConfiguration == null)
            {
                throw new ArgumentNullException(
                    string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.IDS_ArgumentNullException, "objConfiguration"));
            }
            
            BaseControlSettingsData baseControlSettingsData = baseSettingsData as BaseControlSettingsData;
            if (baseControlSettingsData != null)
            {
                objConfiguration.SetValue(objSettingsFor.GetType().ToString(), baseControlSettingsData.GetType().ToString(), baseControlSettingsData);
            }
            return baseControlSettingsData;
        }

        #endregion
    }
}
