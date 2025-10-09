using BSE.Platten.Tunes.Properties;
namespace BSE.Platten.Tunes.Filters
{
    partial class FilterGenre
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
            this.m_clmnGenre = new BSE.Windows.Forms.ColumnHeader();
            this.m_clmnCount = new BSE.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // m_lstvFilter
            // 
            this.m_lstvFilter.Columns.AddRange(new BSE.Windows.Forms.ColumnHeader[] {
            this.m_clmnGenre,
            this.m_clmnCount});
            // 
            // m_clmnGenre
            // 
            this.m_clmnGenre.ListViewComparer = BSE.Windows.Forms.ListViewComparer.Strings;
            this.m_clmnGenre.Text = Resources.IDS_FilterGenreColumnGenreText;
            this.m_clmnGenre.Width = 120;
            // 
            // m_clmnCount
            // 
            this.m_clmnCount.ListViewComparer = BSE.Windows.Forms.ListViewComparer.Strings;
            this.m_clmnCount.Text = Resources.IDS_FilterGenreColumnCountText;
            this.m_clmnCount.Width = 200;
            // 
            // CFilterGenre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "CFilterGenre";
            this.ResumeLayout(false);

        }

        #endregion

        private BSE.Windows.Forms.ColumnHeader m_clmnGenre;
        private BSE.Windows.Forms.ColumnHeader m_clmnCount;

    }
}
