using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Globalization;
using BSE.Windows.Forms.Properties;

namespace BSE.Windows.Forms
{
    public partial class About : System.Windows.Forms.Form
    {
        #region FieldsPrivate

        private AssemblyName[] m_ReferencedAssemblies;
        private string m_strAssemblyProduct;
        private string m_strAssemblyDescription;
        private string m_strAssemblyVersion;
        private string m_strAssemblyTitle;

        #endregion

        #region Properties

        public AssemblyName[] ReferencedAssemblies
        {
            set
            {
                this.m_ReferencedAssemblies = value;
                if (this.m_ReferencedAssemblies != null)
                {
                    AssemblyName[] referencedAssemblies = this.m_ReferencedAssemblies;
                    foreach (AssemblyName assemblyName in referencedAssemblies)
                    {
                        if ((assemblyName.Name.IndexOf("System", 0, 6) != 0) &&
                            (assemblyName.Name.IndexOf("mscorlib", 0, 8) != 0))
                        {
                            ListViewItem listViewItem = this.m_lstvAbout.Items.Add(assemblyName.Name);
                            listViewItem.SubItems.Add(assemblyName.Version.ToString());
                        }
                    }
                }
            }
        }

        public string AssemblyProduct
        {
            set
            {
                this.m_strAssemblyProduct = value;
                if (this.m_strAssemblyProduct != null)
                {
                    this.m_lblProduct.Text = this.m_strAssemblyProduct;
                }
            }
        }

        public string AssemblyDescription
        {
            set
            {
                this.m_strAssemblyDescription = value;
                if (this.m_strAssemblyDescription != null)
                {
                    this.m_lblDescription.Text = this.m_strAssemblyDescription;
                }
            }
        }

        public string AssemblyVersion
        {
            set
            {
                this.m_strAssemblyVersion = value;
                if (this.m_strAssemblyVersion != null)
                {
                    this.m_lblVersion.Text = this.m_strAssemblyVersion;
                }
            }
        }

        public string AssemblyTitle
        {
            set
            {
                this.m_strAssemblyTitle = value;
                if (this.m_strAssemblyTitle != null)
                {
                    this.Text = this.m_strAssemblyTitle;
                }
            }
        }
        /// <summary>
        /// Gets or sets the background color of odd-numbered rows of the listView
        /// </summary>
        public Color AlternatingBackColor
        {
            get { return this.m_lstvAbout.AlternatingBackColor; }
            set { this.m_lstvAbout.AlternatingBackColor = value; }
        }
        #endregion

        #region MethodsPublic

        public About()
        {
            InitializeComponent();
            this.m_lblWarning.Text = string.Format(CultureInfo.CurrentUICulture,
                "{0}", Resources.IDS_About_Warnings);
            
            int iColumnWidth = this.m_lstvAbout.Width / 2;
            this.m_lstvAboutclmnHeaderName.Width = iColumnWidth - (2 * SystemInformation.CaretWidth);
            this.m_lstvAboutclmnHeaderVersion.Width = iColumnWidth - (2 * SystemInformation.CaretWidth);
        }

        #endregion

        #region MethodsPrivate

        private void About_Load(object sender, EventArgs e)
        {
            if (this.m_ReferencedAssemblies == null)
            {
                System.Reflection.AssemblyName[] referencedAssembly = System.Reflection.Assembly.GetEntryAssembly().GetReferencedAssemblies();
                this.ReferencedAssemblies = referencedAssembly;
            }
            if (this.m_strAssemblyProduct == null)
            {
                // Get all Product attributes on this assembly
                object[] attributes = Assembly.GetEntryAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                // If there aren't any Product attributes, return an empty string
                if (attributes.Length > 0)
                {
                    // If there is a Product attribute, return its value
                    this.m_lblProduct.Text = ((AssemblyProductAttribute)attributes[0]).Product;
                }
            }
            if (this.m_strAssemblyDescription == null)
            {
                // Get all Description attributes on this assembly
                object[] attributes = Assembly.GetEntryAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                // If there aren't any Description attributes, return an empty string
                if (attributes.Length > 0)
                {
                    // If there is a Description attribute, return its value
                    this.m_lblDescription.Text = ((AssemblyDescriptionAttribute)attributes[0]).Description;
                }
            }
            if (this.m_strAssemblyVersion == null)
            {
                this.m_lblVersion.Text = Assembly.GetEntryAssembly().GetName().Version.ToString();
            }
            if (this.m_strAssemblyTitle == null)
            {
                string strAssemblyTitle = string.Empty;
                object[] attributes = Assembly.GetEntryAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                // If there is at least one Title attribute
                if (attributes.Length > 0)
                {
                    // Select the first one
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    // If it is not an empty string, return it
                    if (string.IsNullOrEmpty(titleAttribute.Title) == false)
                    {
                        strAssemblyTitle = titleAttribute.Title;
                    }
                }
                else
                {
                    // If there was no Title attribute, or if the Title attribute was the empty string, return the .exe name
                    strAssemblyTitle = System.IO.Path.GetFileNameWithoutExtension(Assembly.GetEntryAssembly().CodeBase);
                }

                this.Text = String.Format(
                    CultureInfo.CurrentUICulture,
                    Resources.IDS_About_FormTitle
                    , strAssemblyTitle);
            }
        }
        
        private void m_lstvAbout_Resize(object sender, EventArgs e)
        {
            int iColumnWidth = this.m_lstvAbout.Width / 2;
            this.m_lstvAboutclmnHeaderName.Width = iColumnWidth - (2 * SystemInformation.CaretWidth);
            this.m_lstvAboutclmnHeaderVersion.Width = iColumnWidth - (2 * SystemInformation.CaretWidth);
        }
        
        #endregion
        
    }
}