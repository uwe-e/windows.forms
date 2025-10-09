namespace BSE.Platten.Tunes
{
    partial class Statistics
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Statistics));
            this.m_pnlBase = new System.Windows.Forms.Panel();
            this.m_btnCancel = new System.Windows.Forms.Button();
            this.m_statistik = new BSE.Platten.Statistic.Statistic();
            this.ContentPanel.SuspendLayout();
            this.m_pnlBase.SuspendLayout();
            this.SuspendLayout();
            // 
            // ContentPanel
            // 
            this.ContentPanel.Controls.Add(this.m_statistik);
            this.ContentPanel.Controls.Add(this.m_pnlBase);
            resources.ApplyResources(this.ContentPanel, "ContentPanel");
            // 
            // m_pnlBase
            // 
            this.m_pnlBase.BackColor = System.Drawing.Color.Transparent;
            this.m_pnlBase.Controls.Add(this.m_btnCancel);
            resources.ApplyResources(this.m_pnlBase, "m_pnlBase");
            this.m_pnlBase.Name = "m_pnlBase";
            // 
            // m_btnCancel
            // 
            resources.ApplyResources(this.m_btnCancel, "m_btnCancel");
            this.m_btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_btnCancel.Name = "m_btnCancel";
            this.m_btnCancel.UseVisualStyleBackColor = true;
            // 
            // m_statistik
            // 
            this.m_statistik.BackColor = System.Drawing.Color.Transparent;
            this.m_statistik.ConnectionString = null;
            resources.ApplyResources(this.m_statistik, "m_statistik");
            this.m_statistik.Name = "m_statistik";
            // 
            // Statistics
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.m_btnCancel;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Statistics";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.ContentPanel.ResumeLayout(false);
            this.m_pnlBase.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel m_pnlBase;
        private BSE.Platten.Statistic.Statistic m_statistik;
        private System.Windows.Forms.Button m_btnCancel;
    }
}