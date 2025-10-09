namespace BSE.Platten.Tunes
{
    partial class SearchToolStrip
    {
        private System.Windows.Forms.ToolStripTextBox m_txtSearch;
        private System.Windows.Forms.ToolStripButton m_btnSearch;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchToolStrip));
            this.m_txtSearch = new System.Windows.Forms.ToolStripTextBox();
            this.m_btnSearch = new System.Windows.Forms.ToolStripButton();
            this.SuspendLayout();
            // 
            // m_txtSearch
            // 
            this.m_txtSearch.AccessibleDescription = null;
            this.m_txtSearch.AccessibleName = null;
            this.m_txtSearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            resources.ApplyResources(this.m_txtSearch, "m_txtSearch");
            this.m_txtSearch.Name = "m_txtSearch";
            this.m_txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchKeyDown);
            // 
            // m_btnSearch
            // 
            this.m_btnSearch.AccessibleDescription = null;
            this.m_btnSearch.AccessibleName = null;
            this.m_btnSearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            resources.ApplyResources(this.m_btnSearch, "m_btnSearch");
            this.m_btnSearch.BackgroundImage = null;
            this.m_btnSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_btnSearch.Image = global::BSE.Platten.Tunes.Properties.Resources.search;
            this.m_btnSearch.Name = "m_btnSearch";
            this.m_btnSearch.Click += new System.EventHandler(this.btnSearchClick);
            // 
            // SearchToolStrip
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Font = null;
            this.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_btnSearch,
            this.m_txtSearch});
            this.ResumeLayout(false);

        }

        #endregion
    }
}
