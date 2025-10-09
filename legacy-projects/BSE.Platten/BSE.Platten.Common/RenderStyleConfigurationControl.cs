using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using BSE.Platten.Common.Properties;
using System.Reflection;

namespace BSE.Platten.Common
{
    public partial class RenderStyleConfigurationControl : BaseConfigurationControl
    {
        #region MethodsPublic

        public RenderStyleConfigurationControl()
        {
            InitializeComponent();
        }
        public override void SaveConfigurationValues(BSE.Configuration.Configuration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException("configuration",
                    string.Format(System.Globalization.CultureInfo.InvariantCulture,
                    Resources.IDS_ArgumentNullException,
                    "configuration"));
            }

            RenderStyleConfigurationData configurationObject = new RenderStyleConfigurationData();
            RenderStyle renderStyle = this.m_cboRenderers.SelectedItem as RenderStyle;
            if (renderStyle != null)
            {
                if (renderStyle.TypeToolStripProfessionalRenderer != null)
                {
                    ToolStripProfessionalRenderer toolStripProfessionalRenderer =
                        Activator.CreateInstance(renderStyle.TypeToolStripProfessionalRenderer) as ToolStripProfessionalRenderer;
                    if (toolStripProfessionalRenderer != null)
                    {
                        BSE.Windows.Forms.ProfessionalColorTable colorTable = toolStripProfessionalRenderer.ColorTable as BSE.Windows.Forms.ProfessionalColorTable;
                        if (colorTable != null)
                        {
                            renderStyle.TypeProfessionalColorTable = colorTable.GetType();
                            renderStyle.TypePanelColors = colorTable.PanelColorTable.GetType();
                        }
                    }
                }
                if (renderStyle.TypeToolStripProfessionalRenderer == typeof(BSE.Windows.Forms.BseRenderer))
                {
                    renderStyle.PanelStyle = BSE.Windows.Forms.PanelStyle.Office2007;
                }
                if (renderStyle.TypeToolStripProfessionalRenderer == typeof(BSE.Windows.Forms.Office2007Renderer))
                {
                    renderStyle.PanelStyle = BSE.Windows.Forms.PanelStyle.Office2007;
                }
            }

            Type typeProfessionalColorTable = this.m_cboProfessionalColorTable.SelectedItem as Type;
            if (typeProfessionalColorTable != null)
            {
                BSE.Windows.Forms.ProfessionalColorTable colorTable =
                    Activator.CreateInstance(typeProfessionalColorTable) as BSE.Windows.Forms.ProfessionalColorTable;
                if (colorTable != null)
                {
                    renderStyle.TypeProfessionalColorTable = colorTable.GetType();
                    renderStyle.TypePanelColors = colorTable.PanelColorTable.GetType();
                }
            }

            configurationObject.RenderStyle = renderStyle;

            configuration.SetValue(
                OptionsConfiguration,
                typeof(RenderStyleConfigurationData).Name,
                configurationObject);
        }
        public override void LoadConfigurationValues(BSE.Configuration.Configuration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException("configuration",
                    string.Format(System.Globalization.CultureInfo.InvariantCulture,
                    Resources.IDS_ArgumentNullException,
                    "configuration"));
            }

            RenderStyleConfigurationData configurationObject =
                GetConfiguration(configuration) as RenderStyleConfigurationData;
            if (configurationObject != null)
            {
                this.m_cboProfessionalColorTable.SelectedValueChanged -= new EventHandler(ColorSchemesSelectedValueChanged);
                this.m_cboRenderers.SelectedValueChanged -= new EventHandler(RenderersSelectedValueChanged);
                LoadFormStyles(configurationObject);
            }
        }

        public static IConfigurationData GetConfiguration(BSE.Configuration.Configuration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException("configuration",
                    string.Format(System.Globalization.CultureInfo.InvariantCulture,
                    Resources.IDS_ArgumentNullException,
                    "configuration"));
            }
            return configuration.GetValue(
                OptionsConfiguration,
                typeof(RenderStyleConfigurationData).Name,
                new RenderStyleConfigurationData()) as RenderStyleConfigurationData;
        }
        #endregion

        #region MethodsPrivate
        private void LoadFormStyles(RenderStyleConfigurationData configurationObject)
        {
            RenderStyle renderStyle = configurationObject.RenderStyle;
            if (renderStyle != null)
            {
                if (renderStyle.TypeToolStripProfessionalRenderer != null)
                {
                    this.m_cboRenderers.DataSource = RenderStyles.GetRenderStyles();
                    this.m_cboRenderers.DisplayMember = "Name";
                    this.m_cboRenderers.ValueMember = "TypeToolStripProfessionalRenderer";
                    this.m_cboRenderers.SelectedValue = renderStyle.TypeToolStripProfessionalRenderer;

                    ToolStripProfessionalRenderer toolStripRenderer =
                        Activator.CreateInstance(renderStyle.TypeToolStripProfessionalRenderer) as ToolStripProfessionalRenderer;
                    if (toolStripRenderer != null)
                    {
                        Type typeOfClass = toolStripRenderer.ColorTable.GetType().BaseType;
                        Assembly assembly = toolStripRenderer.ColorTable.GetType().Assembly;
                        Type[] types = assembly.GetTypes();
                        foreach (Type colorTableType in types)
                        {
                            if ((colorTableType.IsClass == true) &&
                                (typeOfClass.IsAssignableFrom(colorTableType) == true) &&
                                (typeOfClass != colorTableType) &&
                                (typeOfClass.BaseType == typeof(BSE.Windows.Forms.ProfessionalColorTable)))
                            {
                                this.m_cboProfessionalColorTable.Items.Add(colorTableType);
                            }
                        }

                        if (renderStyle.TypeProfessionalColorTable == null)
                        {
                            Type typeProfessionalColorTable = toolStripRenderer.ColorTable.GetType();
                            if (typeProfessionalColorTable != null)
                            {
                                this.m_cboProfessionalColorTable.SelectedItem = typeProfessionalColorTable;
                            }
                        }
                        else
                        {
                            this.m_cboProfessionalColorTable.SelectedItem = renderStyle.TypeProfessionalColorTable;
                        }
                    }
                    this.m_cboProfessionalColorTable.SelectedValueChanged += new EventHandler(ColorSchemesSelectedValueChanged);
                    this.m_cboRenderers.SelectedValueChanged += new EventHandler(RenderersSelectedValueChanged);
                }
            }
        }

        private void RenderersSelectedValueChanged(object sender, EventArgs e)
        {
            RenderStyle renderStyle = this.m_cboRenderers.SelectedItem as RenderStyle;
            if (renderStyle != null)
            {
                Type rendererType = renderStyle.TypeToolStripProfessionalRenderer;
                ToolStripProfessionalRenderer toolStripProfessionalRenderer = Activator.CreateInstance(rendererType) as ToolStripProfessionalRenderer;
                if (toolStripProfessionalRenderer != null)
                {
                    this.m_cboProfessionalColorTable.Items.Clear();
                    Assembly assembly = toolStripProfessionalRenderer.ColorTable.GetType().Assembly;
                    Type typeOfClass = toolStripProfessionalRenderer.ColorTable.GetType().BaseType;
                    Type[] types = assembly.GetTypes();
                    foreach (Type colorTableType in types)
                    {
                        if ((colorTableType.IsClass == true) &&
                            (typeOfClass.IsAssignableFrom(colorTableType) == true) &&
                            (typeOfClass != colorTableType) &&
                            (typeOfClass.BaseType == typeof(BSE.Windows.Forms.ProfessionalColorTable)))
                        {
                            this.m_cboProfessionalColorTable.Items.Add(colorTableType);
                        }
                    }

                }
                OnConfigChanging(EventArgs.Empty);
            }
        }
        
        private void ColorSchemesSelectedValueChanged(object sender, EventArgs e)
        {
            OnConfigChanging(EventArgs.Empty);
        }

        #endregion

    }
}
