using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace BSE.Platten.Common
{
    public static class RenderStyles
    {
        /// <summary>
        /// Contains a usable collection of RenderStyles
        /// </summary>
        /// <returns></returns>
        public static Collection<RenderStyle> GetRenderStyles()
        {
            Collection<RenderStyle> renderStyles = new Collection<RenderStyle>();

            RenderStyle renderStyleBse = new RenderStyle();
            renderStyleBse.Name = "BSE";
            renderStyleBse.TypeToolStripProfessionalRenderer = typeof(BSE.Windows.Forms.BseRenderer);
            renderStyleBse.PanelStyle = BSE.Windows.Forms.PanelStyle.Office2007;
            renderStyles.Add(renderStyleBse);

            RenderStyle renderStyleOffice2007 = new RenderStyle();
            renderStyleOffice2007.Name = "Office2007";
            renderStyleOffice2007.TypeToolStripProfessionalRenderer = typeof(BSE.Windows.Forms.Office2007Renderer);
            renderStyleOffice2007.PanelStyle = BSE.Windows.Forms.PanelStyle.Office2007;
            renderStyles.Add(renderStyleOffice2007);

            return renderStyles;
        }
    }

    public class RenderStyle
    {
        #region FieldsPrivate

        private string m_strName;
        private Type m_typeToolStripProfessionalRenderer;
        private BSE.Windows.Forms.PanelStyle m_panelStyle;
        private Type m_typeProfessionalColorTable;
        private Type m_typePanelColors;

        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the name of the Renderer
        /// </summary>
        public string Name
        {
            get { return m_strName; }
            set { m_strName = value; }
        }
        /// <summary>
        /// Gets or sets the type of the specified Renderer
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public Type TypeToolStripProfessionalRenderer
        {
            get { return this.m_typeToolStripProfessionalRenderer; }
            set { this.m_typeToolStripProfessionalRenderer = value; }
        }
        /// <summary>
        /// Gets or sets the PanelStyle for rendering
        /// </summary>
        public BSE.Windows.Forms.PanelStyle PanelStyle
        {
            get { return this.m_panelStyle; }
            set { this.m_panelStyle = value; }
        }
        /// <summary>
        /// Gets or sets the type of the specified ProfessionalColorTable class
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public Type TypeProfessionalColorTable
        {
            get { return this.m_typeProfessionalColorTable; }
            set { this.m_typeProfessionalColorTable = value; }
        }
        
        /// <summary>
        /// Gets or sets the type of the specified PanelColors class
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public Type TypePanelColors
        {
            get { return this.m_typePanelColors; }
            set { this.m_typePanelColors = value; }
        }
        /// <summary>
        /// Converts the type of the specified renderer into it's AssemblyQualifiedName
        /// </summary>
        [System.Xml.Serialization.XmlElement("TypeToolStripProfessionalRenderer")]
        public string ToolStripProfessionalRendererNameAssemblyQualifiedName
        {
            get
            {
                if (this.TypeToolStripProfessionalRenderer != null)
                {
                    return this.TypeToolStripProfessionalRenderer.AssemblyQualifiedName;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (value != null)
                {
                    this.TypeToolStripProfessionalRenderer = Type.GetType(value);
                }
                else
                {
                    this.TypeToolStripProfessionalRenderer = null;
                }
            }
        }
        /// <summary>
        /// Converts the type of the specified ProfessionalColorTable class into it's AssemblyQualifiedName
        /// </summary>
        [System.Xml.Serialization.XmlElement("TypeProfessionalColorTable")]
        public string ProfessionalColorTableAssemblyQualifiedName
        {
            get
            {
                if (this.TypeProfessionalColorTable != null)
                {
                    return this.TypeProfessionalColorTable.AssemblyQualifiedName;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (value != null)
                {
                    this.TypeProfessionalColorTable = Type.GetType(value);
                }
                else
                {
                    this.TypeProfessionalColorTable = null;
                }
            }
        }
        /// <summary>
        /// Converts the type of the specified PanelColors class into it's AssemblyQualifiedName
        /// </summary>
        [System.Xml.Serialization.XmlElement("TypePanelColors")]
        public string PanelColorsAssemblyQualifiedName
        {
            get
            {
                if (this.TypePanelColors != null)
                {
                    return this.TypePanelColors.AssemblyQualifiedName;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (value != null)
                {
                    this.TypePanelColors = Type.GetType(value);
                }
                else
                {
                    this.TypePanelColors = null;
                }
            }
        }
        #endregion

        #region MethodsPublic
        /// <summary>
        /// Determines whether the specified Object is equal to the current Object.
        /// </summary>
        /// <param name="item">The Object to compare with the current Object.</param>
        /// <returns>true if the specified Object is equal to the current Object; otherwise, false. </returns>
        public virtual bool Equals(RenderStyle item)
        {
            if (item == null)
            {
                return false;
            }
            if (string.Equals(this.m_strName, item.Name) == false)
            {
                return false;
            }
            if (this.m_typeToolStripProfessionalRenderer != item.TypeToolStripProfessionalRenderer)
            {
                return false;
            }
            if (this.m_typeProfessionalColorTable != item.TypeProfessionalColorTable)
            {
                return false;
            }
            if (this.m_panelStyle.Equals(item.PanelStyle) == false)
            {
                return false;
            }
            return true;
        }
        #endregion
    }
}
