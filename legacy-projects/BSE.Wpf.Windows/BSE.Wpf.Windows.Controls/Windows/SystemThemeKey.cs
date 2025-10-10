using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Reflection;

namespace BSE.Wpf.Windows
{
    public class SystemThemeKey : ResourceKey
    {
        #region FieldsPrivate
        private SystemResourceKeyID m_systemResourceKeyID;
        private static Assembly m_presentationFrameworkAssembly;

        #endregion

        #region MethodsPublic
        public SystemThemeKey(SystemResourceKeyID id)
        {
            this.m_systemResourceKeyID = id;
        }
        public override string ToString()
        {
            return this.m_systemResourceKeyID.ToString();
        }
        public override Assembly Assembly
        {
            get
            {
                if (m_presentationFrameworkAssembly == null)
                {
                    m_presentationFrameworkAssembly = System.Reflection.Assembly.GetExecutingAssembly();
                }
                return m_presentationFrameworkAssembly;
            }
        }

        #endregion
    }
}
