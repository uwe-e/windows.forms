namespace BSE.Configuration
{
    partial class VisualConfiguration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VisualConfiguration));
            this.m_lstConfiguration = new System.Windows.Forms.ListView();
            this.m_clmnHeaderKey = new System.Windows.Forms.ColumnHeader();
            this.m_clmnHeaderValue = new System.Windows.Forms.ColumnHeader();
            this.m_oddlgDirectorySearch = new System.Windows.Forms.FolderBrowserDialog();
            this.m_ofdlgFileSearch = new System.Windows.Forms.OpenFileDialog();
            this.m_txtEdit = new System.Windows.Forms.TextBox();
            this.m_txtNumeric = new System.Windows.Forms.NumericUpDown();
            this.m_cboValue = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.m_txtNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // m_lstConfiguration
            // 
            this.m_lstConfiguration.AccessibleDescription = null;
            this.m_lstConfiguration.AccessibleName = null;
            resources.ApplyResources(this.m_lstConfiguration, "m_lstConfiguration");
            this.m_lstConfiguration.BackgroundImage = null;
            this.m_lstConfiguration.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.m_clmnHeaderKey,
            this.m_clmnHeaderValue});
            this.m_lstConfiguration.Font = null;
            this.m_lstConfiguration.FullRowSelect = true;
            this.m_lstConfiguration.MultiSelect = false;
            this.m_lstConfiguration.Name = "m_lstConfiguration";
            this.m_lstConfiguration.UseCompatibleStateImageBehavior = false;
            this.m_lstConfiguration.View = System.Windows.Forms.View.Details;
            this.m_lstConfiguration.DoubleClick += new System.EventHandler(this.m_lstConfiguration_DoubleClick);
            // 
            // m_clmnHeaderKey
            // 
            resources.ApplyResources(this.m_clmnHeaderKey, "m_clmnHeaderKey");
            // 
            // m_clmnHeaderValue
            // 
            resources.ApplyResources(this.m_clmnHeaderValue, "m_clmnHeaderValue");
            // 
            // m_oddlgDirectorySearch
            // 
            resources.ApplyResources(this.m_oddlgDirectorySearch, "m_oddlgDirectorySearch");
            // 
            // m_ofdlgFileSearch
            // 
            resources.ApplyResources(this.m_ofdlgFileSearch, "m_ofdlgFileSearch");
            // 
            // m_txtEdit
            // 
            this.m_txtEdit.AccessibleDescription = null;
            this.m_txtEdit.AccessibleName = null;
            resources.ApplyResources(this.m_txtEdit, "m_txtEdit");
            this.m_txtEdit.BackgroundImage = null;
            this.m_txtEdit.Font = null;
            this.m_txtEdit.Name = "m_txtEdit";
            // 
            // m_txtNumeric
            // 
            this.m_txtNumeric.AccessibleDescription = null;
            this.m_txtNumeric.AccessibleName = null;
            resources.ApplyResources(this.m_txtNumeric, "m_txtNumeric");
            this.m_txtNumeric.Font = null;
            this.m_txtNumeric.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.m_txtNumeric.Name = "m_txtNumeric";
            // 
            // m_cboValue
            // 
            this.m_cboValue.AccessibleDescription = null;
            this.m_cboValue.AccessibleName = null;
            resources.ApplyResources(this.m_cboValue, "m_cboValue");
            this.m_cboValue.BackgroundImage = null;
            this.m_cboValue.Font = null;
            this.m_cboValue.FormattingEnabled = true;
            this.m_cboValue.Name = "m_cboValue";
            // 
            // VisualConfiguration
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.m_txtEdit);
            this.Controls.Add(this.m_lstConfiguration);
            this.Font = null;
            this.Resize += new System.EventHandler(this.CConfiguration_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.m_txtNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView m_lstConfiguration;
        private System.Windows.Forms.ColumnHeader m_clmnHeaderKey;
        private System.Windows.Forms.ColumnHeader m_clmnHeaderValue;
        private System.Windows.Forms.FolderBrowserDialog m_oddlgDirectorySearch;
        private System.Windows.Forms.OpenFileDialog m_ofdlgFileSearch;
		private System.Windows.Forms.TextBox m_txtEdit;
        private System.Windows.Forms.NumericUpDown m_txtNumeric;
        private System.Windows.Forms.ComboBox m_cboValue;
    }
}
