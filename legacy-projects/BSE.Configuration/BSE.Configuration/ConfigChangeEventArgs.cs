using System;
using System.Collections.Generic;
using System.Text;

namespace BSE.Configuration
{
    public class ConfigChangeEventArgs : System.EventArgs
    {
        #region FieldsPrivate

        private VisualObject m_visualObject;

        #endregion

        #region Properties

        /// <summary>
        /// CVisualObject with changed values
        /// </summary>
        public VisualObject VisualObject
        {
            get { return this.m_visualObject; }
            set { this.m_visualObject = value; }
        }

        #endregion

        #region MethodsPublic

        /// <summary>
        /// fires an event when configuration has changed
        /// </summary>
        /// <param name="visualObject">BSE.Config.CVisualObject with changed values</param>
        public ConfigChangeEventArgs(VisualObject visualObject)
        {
            this.m_visualObject = visualObject;
        }

        #endregion
    }
}
