namespace BSE.Platten.Common
{
    partial class RenderStyleConfigurationControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RenderStyleConfigurationControl));
            this.m_grpFormStyles = new System.Windows.Forms.GroupBox();
            this.m_lblColorSchemes = new System.Windows.Forms.Label();
            this.m_cboProfessionalColorTable = new System.Windows.Forms.ComboBox();
            this.m_lblRenderers = new System.Windows.Forms.Label();
            this.m_cboRenderers = new System.Windows.Forms.ComboBox();
            this.m_grpFormStyles.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_grpFormStyles
            // 
            this.m_grpFormStyles.AccessibleDescription = null;
            this.m_grpFormStyles.AccessibleName = null;
            resources.ApplyResources(this.m_grpFormStyles, "m_grpFormStyles");
            this.m_grpFormStyles.BackgroundImage = null;
            this.m_grpFormStyles.Controls.Add(this.m_lblColorSchemes);
            this.m_grpFormStyles.Controls.Add(this.m_cboProfessionalColorTable);
            this.m_grpFormStyles.Controls.Add(this.m_lblRenderers);
            this.m_grpFormStyles.Controls.Add(this.m_cboRenderers);
            this.m_grpFormStyles.Font = null;
            this.m_grpFormStyles.Name = "m_grpFormStyles";
            this.m_grpFormStyles.TabStop = false;
            // 
            // m_lblColorSchemes
            // 
            this.m_lblColorSchemes.AccessibleDescription = null;
            this.m_lblColorSchemes.AccessibleName = null;
            resources.ApplyResources(this.m_lblColorSchemes, "m_lblColorSchemes");
            this.m_lblColorSchemes.Font = null;
            this.m_lblColorSchemes.Name = "m_lblColorSchemes";
            // 
            // m_cboProfessionalColorTable
            // 
            this.m_cboProfessionalColorTable.AccessibleDescription = null;
            this.m_cboProfessionalColorTable.AccessibleName = null;
            resources.ApplyResources(this.m_cboProfessionalColorTable, "m_cboProfessionalColorTable");
            this.m_cboProfessionalColorTable.BackgroundImage = null;
            this.m_cboProfessionalColorTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboProfessionalColorTable.Font = null;
            this.m_cboProfessionalColorTable.FormattingEnabled = true;
            this.m_cboProfessionalColorTable.Name = "m_cboProfessionalColorTable";
            this.m_cboProfessionalColorTable.SelectedValueChanged += new System.EventHandler(this.ColorSchemesSelectedValueChanged);
            // 
            // m_lblRenderers
            // 
            this.m_lblRenderers.AccessibleDescription = null;
            this.m_lblRenderers.AccessibleName = null;
            resources.ApplyResources(this.m_lblRenderers, "m_lblRenderers");
            this.m_lblRenderers.Font = null;
            this.m_lblRenderers.Name = "m_lblRenderers";
            // 
            // m_cboRenderers
            // 
            this.m_cboRenderers.AccessibleDescription = null;
            this.m_cboRenderers.AccessibleName = null;
            resources.ApplyResources(this.m_cboRenderers, "m_cboRenderers");
            this.m_cboRenderers.BackgroundImage = null;
            this.m_cboRenderers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboRenderers.Font = null;
            this.m_cboRenderers.FormattingEnabled = true;
            this.m_cboRenderers.Name = "m_cboRenderers";
            this.m_cboRenderers.SelectedValueChanged += new System.EventHandler(this.RenderersSelectedValueChanged);
            // 
            // RenderStyleConfigurationControl
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.m_grpFormStyles);
            this.Font = null;
            this.Name = "RenderStyleConfigurationControl";
            this.m_grpFormStyles.ResumeLayout(false);
            this.m_grpFormStyles.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox m_grpFormStyles;
        private System.Windows.Forms.ComboBox m_cboRenderers;
        private System.Windows.Forms.Label m_lblColorSchemes;
        private System.Windows.Forms.ComboBox m_cboProfessionalColorTable;
        private System.Windows.Forms.Label m_lblRenderers;
    }
}
