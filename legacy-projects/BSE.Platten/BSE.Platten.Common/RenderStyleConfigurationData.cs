using System;
using System.Collections.Generic;
using System.Text;
using BSE.Platten.Common.Properties;

namespace BSE.Platten.Common
{
    /// <summary>
    /// Contains the properties of the RenderStyleConfigurationData class.
    /// </summary>
    public class RenderStyleConfigurationData : IConfigurationData
    {
        #region FieldsPrivate
        private RenderStyle m_renderStyle;
        #endregion

        #region MethodsPublic
        /// <summary>
        /// Initializes a new instance of the RenderStyleConfigurationData class.
        /// </summary>
        public RenderStyleConfigurationData()
        {
            this.m_renderStyle = RenderStyles.GetRenderStyles()[0];
        }

        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the renderer for the forms
        /// </summary>
        public RenderStyle RenderStyle
        {
            get { return this.m_renderStyle; }
            set { this.m_renderStyle = value; }
        }
        #endregion
    }
}
