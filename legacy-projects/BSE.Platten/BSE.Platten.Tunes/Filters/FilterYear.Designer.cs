using BSE.Platten.Tunes.Properties;
namespace BSE.Platten.Tunes.Filters
{
    partial class FilterYear
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.m_clmnYear = new BSE.Windows.Forms.ColumnHeader();
            this.m_clmnCount = new BSE.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // m_lstvFilter
            // 
            this.m_lstvFilter.Columns.AddRange(new BSE.Windows.Forms.ColumnHeader[] {
            this.m_clmnYear,
            this.m_clmnCount});
            // 
            // m_clmnYear
            // 
            this.m_clmnYear.ListViewComparer = BSE.Windows.Forms.ListViewComparer.Numbers;
            this.m_clmnYear.Text = Resources.IDS_FilterYearColumnYearText;
            this.m_clmnYear.Width = 120;
            // 
            // m_clmnCount
            // 
            this.m_clmnCount.ListViewComparer = BSE.Windows.Forms.ListViewComparer.Numbers;
            this.m_clmnCount.Text = Resources.IDS_FilterYearColumnCountText;
            this.m_clmnCount.Width = 156;
            // 
            // CFilterYear
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "CFilterYear";
            this.ResumeLayout(false);

        }

        #endregion

        private BSE.Windows.Forms.ColumnHeader m_clmnYear;
        private BSE.Windows.Forms.ColumnHeader m_clmnCount;
    }
}
