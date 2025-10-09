namespace BSE.Platten.Admin
{
    partial class DiskInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DiskInfo));
            this.m_pnlAction = new System.Windows.Forms.Panel();
            this.m_btnCancel = new System.Windows.Forms.Button();
            this.m_grpDiskInfo = new System.Windows.Forms.GroupBox();
            this.m_lblFreeSpaceGBytes = new System.Windows.Forms.Label();
            this.m_lblFreeSpaceBytes = new System.Windows.Forms.Label();
            this.m_lblUsedSpaceGBytes = new System.Windows.Forms.Label();
            this.m_lblFreeSpace = new System.Windows.Forms.Label();
            this.m_lblUsedSpaceBytes = new System.Windows.Forms.Label();
            this.m_picFreeSpace = new System.Windows.Forms.PictureBox();
            this.m_lblUsedSpace = new System.Windows.Forms.Label();
            this.m_picUsedSpace = new System.Windows.Forms.PictureBox();
            this.m_chrtDiskInfo = new BSE.Charts.Chart();
            this.ContentPanel.SuspendLayout();
            this.m_pnlAction.SuspendLayout();
            this.m_grpDiskInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_picFreeSpace)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_picUsedSpace)).BeginInit();
            this.SuspendLayout();
            // 
            // ContentPanel
            // 
            resources.ApplyResources(this.ContentPanel, "ContentPanel");
            this.ContentPanel.Controls.Add(this.m_grpDiskInfo);
            this.ContentPanel.Controls.Add(this.m_pnlAction);
            // 
            // m_pnlAction
            // 
            resources.ApplyResources(this.m_pnlAction, "m_pnlAction");
            this.m_pnlAction.BackColor = System.Drawing.Color.Transparent;
            this.m_pnlAction.Controls.Add(this.m_btnCancel);
            this.m_pnlAction.Name = "m_pnlAction";
            // 
            // m_btnCancel
            // 
            resources.ApplyResources(this.m_btnCancel, "m_btnCancel");
            this.m_btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_btnCancel.Name = "m_btnCancel";
            this.m_btnCancel.UseVisualStyleBackColor = true;
            // 
            // m_grpDiskInfo
            // 
            resources.ApplyResources(this.m_grpDiskInfo, "m_grpDiskInfo");
            this.m_grpDiskInfo.BackColor = System.Drawing.Color.Transparent;
            this.m_grpDiskInfo.Controls.Add(this.m_lblFreeSpaceGBytes);
            this.m_grpDiskInfo.Controls.Add(this.m_lblFreeSpaceBytes);
            this.m_grpDiskInfo.Controls.Add(this.m_lblUsedSpaceGBytes);
            this.m_grpDiskInfo.Controls.Add(this.m_lblFreeSpace);
            this.m_grpDiskInfo.Controls.Add(this.m_lblUsedSpaceBytes);
            this.m_grpDiskInfo.Controls.Add(this.m_picFreeSpace);
            this.m_grpDiskInfo.Controls.Add(this.m_lblUsedSpace);
            this.m_grpDiskInfo.Controls.Add(this.m_picUsedSpace);
            this.m_grpDiskInfo.Controls.Add(this.m_chrtDiskInfo);
            this.m_grpDiskInfo.Name = "m_grpDiskInfo";
            this.m_grpDiskInfo.TabStop = false;
            // 
            // m_lblFreeSpaceGBytes
            // 
            resources.ApplyResources(this.m_lblFreeSpaceGBytes, "m_lblFreeSpaceGBytes");
            this.m_lblFreeSpaceGBytes.Name = "m_lblFreeSpaceGBytes";
            // 
            // m_lblFreeSpaceBytes
            // 
            resources.ApplyResources(this.m_lblFreeSpaceBytes, "m_lblFreeSpaceBytes");
            this.m_lblFreeSpaceBytes.Name = "m_lblFreeSpaceBytes";
            // 
            // m_lblUsedSpaceGBytes
            // 
            resources.ApplyResources(this.m_lblUsedSpaceGBytes, "m_lblUsedSpaceGBytes");
            this.m_lblUsedSpaceGBytes.Name = "m_lblUsedSpaceGBytes";
            // 
            // m_lblFreeSpace
            // 
            resources.ApplyResources(this.m_lblFreeSpace, "m_lblFreeSpace");
            this.m_lblFreeSpace.Name = "m_lblFreeSpace";
            // 
            // m_lblUsedSpaceBytes
            // 
            resources.ApplyResources(this.m_lblUsedSpaceBytes, "m_lblUsedSpaceBytes");
            this.m_lblUsedSpaceBytes.Name = "m_lblUsedSpaceBytes";
            // 
            // m_picFreeSpace
            // 
            resources.ApplyResources(this.m_picFreeSpace, "m_picFreeSpace");
            this.m_picFreeSpace.Name = "m_picFreeSpace";
            this.m_picFreeSpace.TabStop = false;
            // 
            // m_lblUsedSpace
            // 
            resources.ApplyResources(this.m_lblUsedSpace, "m_lblUsedSpace");
            this.m_lblUsedSpace.Name = "m_lblUsedSpace";
            // 
            // m_picUsedSpace
            // 
            resources.ApplyResources(this.m_picUsedSpace, "m_picUsedSpace");
            this.m_picUsedSpace.Name = "m_picUsedSpace";
            this.m_picUsedSpace.TabStop = false;
            // 
            // m_chrtDiskInfo
            // 
            resources.ApplyResources(this.m_chrtDiskInfo, "m_chrtDiskInfo");
            this.m_chrtDiskInfo.Name = "m_chrtDiskInfo";
            // 
            // DiskInfo
            // 
            resources.ApplyResources(this, "$this");
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DiskInfo";
            this.ShowInStatisticNode = true;
            this.ShowInTaskbar = false;
            this.ShowInTreeView = true;
            this.TreeNodeImage = global::BSE.Platten.Admin.Properties.Resources.diskinfo;
            this.Load += new System.EventHandler(this.CDiskInfo_Load);
            this.Controls.SetChildIndex(this.ContentPanel, 0);
            this.ContentPanel.ResumeLayout(false);
            this.m_pnlAction.ResumeLayout(false);
            this.m_grpDiskInfo.ResumeLayout(false);
            this.m_grpDiskInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_picFreeSpace)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_picUsedSpace)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel m_pnlAction;
        private System.Windows.Forms.Button m_btnCancel;
        private System.Windows.Forms.GroupBox m_grpDiskInfo;
        private System.Windows.Forms.Label m_lblUsedSpaceBytes;
        private System.Windows.Forms.Label m_lblUsedSpace;
        private System.Windows.Forms.PictureBox m_picUsedSpace;
        private System.Windows.Forms.Label m_lblUsedSpaceGBytes;
        private System.Windows.Forms.Label m_lblFreeSpaceGBytes;
        private System.Windows.Forms.Label m_lblFreeSpaceBytes;
        private System.Windows.Forms.Label m_lblFreeSpace;
        private System.Windows.Forms.PictureBox m_picFreeSpace;
        private BSE.Charts.Chart m_chrtDiskInfo;
    }
}
