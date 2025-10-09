namespace BSE.Platten.Admin
{
    partial class Statistic
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Statistic));
            this.m_pnlAction = new System.Windows.Forms.Panel();
            this.m_btnCancel = new System.Windows.Forms.Button();
            this.m_statistik = new BSE.Platten.Statistic.Statistic();
            this.ContentPanel.SuspendLayout();
            this.m_pnlAction.SuspendLayout();
            this.SuspendLayout();
            // 
            // ContentPanel
            // 
            this.ContentPanel.AccessibleDescription = null;
            this.ContentPanel.AccessibleName = null;
            resources.ApplyResources(this.ContentPanel, "ContentPanel");
            this.ContentPanel.BackgroundImage = null;
            this.ContentPanel.Controls.Add(this.m_statistik);
            this.ContentPanel.Controls.Add(this.m_pnlAction);
            this.ContentPanel.Font = null;
            // 
            // m_pnlAction
            // 
            this.m_pnlAction.AccessibleDescription = null;
            this.m_pnlAction.AccessibleName = null;
            resources.ApplyResources(this.m_pnlAction, "m_pnlAction");
            this.m_pnlAction.BackColor = System.Drawing.Color.Transparent;
            this.m_pnlAction.BackgroundImage = null;
            this.m_pnlAction.Controls.Add(this.m_btnCancel);
            this.m_pnlAction.Font = null;
            this.m_pnlAction.Name = "m_pnlAction";
            // 
            // m_btnCancel
            // 
            this.m_btnCancel.AccessibleDescription = null;
            this.m_btnCancel.AccessibleName = null;
            resources.ApplyResources(this.m_btnCancel, "m_btnCancel");
            this.m_btnCancel.BackgroundImage = null;
            this.m_btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_btnCancel.Font = null;
            this.m_btnCancel.Name = "m_btnCancel";
            this.m_btnCancel.UseVisualStyleBackColor = true;
            // 
            // m_statistik
            // 
            this.m_statistik.AccessibleDescription = null;
            this.m_statistik.AccessibleName = null;
            resources.ApplyResources(this.m_statistik, "m_statistik");
            this.m_statistik.BackColor = System.Drawing.Color.Transparent;
            this.m_statistik.BackgroundImage = null;
            this.m_statistik.ConnectionString = null;
            this.m_statistik.Font = null;
            this.m_statistik.Name = "m_statistik";
            // 
            // Statistic
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.CancelButton = this.m_btnCancel;
            this.Font = null;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Statistic";
            this.ShowIcon = false;
            this.ShowInStatisticNode = true;
            this.ShowInTaskbar = false;
            this.ShowInTreeView = true;
            this.TreeNodeImage = global::BSE.Platten.Admin.Properties.Resources.diskinfo;
            this.ContentPanel.ResumeLayout(false);
            this.m_pnlAction.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel m_pnlAction;
        private System.Windows.Forms.Button m_btnCancel;
        private BSE.Platten.Statistic.Statistic m_statistik;
    }
}
