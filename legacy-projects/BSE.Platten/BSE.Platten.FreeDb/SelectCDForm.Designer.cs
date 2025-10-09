namespace BSE.Platten.FreeDb
{
    partial class SelectCDForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectCDForm));
            this.m_pnlAction = new System.Windows.Forms.Panel();
            this.m_btnCancel = new System.Windows.Forms.Button();
            this.m_btnOK = new System.Windows.Forms.Button();
            this.m_pnlBase = new System.Windows.Forms.Panel();
            this.m_lstvSelectCD = new System.Windows.Forms.ListView();
            this.m_columnHeader = new System.Windows.Forms.ColumnHeader();
            this.ContentPanel.SuspendLayout();
            this.m_pnlAction.SuspendLayout();
            this.m_pnlBase.SuspendLayout();
            this.SuspendLayout();
            // 
            // ContentPanel
            // 
            this.ContentPanel.AccessibleDescription = null;
            this.ContentPanel.AccessibleName = null;
            resources.ApplyResources(this.ContentPanel, "ContentPanel");
            this.ContentPanel.BackgroundImage = null;
            this.ContentPanel.Controls.Add(this.m_pnlBase);
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
            this.m_pnlAction.Controls.Add(this.m_btnOK);
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
            this.m_btnCancel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.m_btnCancel.Name = "m_btnCancel";
            this.m_btnCancel.UseVisualStyleBackColor = true;
            // 
            // m_btnOK
            // 
            this.m_btnOK.AccessibleDescription = null;
            this.m_btnOK.AccessibleName = null;
            resources.ApplyResources(this.m_btnOK, "m_btnOK");
            this.m_btnOK.BackgroundImage = null;
            this.m_btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.m_btnOK.Font = null;
            this.m_btnOK.Name = "m_btnOK";
            this.m_btnOK.UseVisualStyleBackColor = true;
            this.m_btnOK.Click += new System.EventHandler(this.m_btnOK_Click);
            // 
            // m_pnlBase
            // 
            this.m_pnlBase.AccessibleDescription = null;
            this.m_pnlBase.AccessibleName = null;
            resources.ApplyResources(this.m_pnlBase, "m_pnlBase");
            this.m_pnlBase.BackColor = System.Drawing.Color.Transparent;
            this.m_pnlBase.BackgroundImage = null;
            this.m_pnlBase.Controls.Add(this.m_lstvSelectCD);
            this.m_pnlBase.Font = null;
            this.m_pnlBase.Name = "m_pnlBase";
            // 
            // m_lstvSelectCD
            // 
            this.m_lstvSelectCD.AccessibleDescription = null;
            this.m_lstvSelectCD.AccessibleName = null;
            resources.ApplyResources(this.m_lstvSelectCD, "m_lstvSelectCD");
            this.m_lstvSelectCD.BackgroundImage = null;
            this.m_lstvSelectCD.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.m_columnHeader});
            this.m_lstvSelectCD.Font = null;
            this.m_lstvSelectCD.MultiSelect = false;
            this.m_lstvSelectCD.Name = "m_lstvSelectCD";
            this.m_lstvSelectCD.UseCompatibleStateImageBehavior = false;
            this.m_lstvSelectCD.View = System.Windows.Forms.View.Details;
            this.m_lstvSelectCD.SelectedIndexChanged += new System.EventHandler(this.m_lstvSelectCD_SelectedIndexChanged);
            this.m_lstvSelectCD.MouseDown += new System.Windows.Forms.MouseEventHandler(this.m_lstvSelectCD_MouseDown);
            // 
            // m_columnHeader
            // 
            resources.ApplyResources(this.m_columnHeader, "m_columnHeader");
            // 
            // SelectCDForm
            // 
            this.AcceptButton = this.m_btnOK;
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.CancelButton = this.m_btnCancel;
            this.Font = null;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = null;
            this.Name = "SelectCDForm";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.FormLoad);
            this.ContentPanel.ResumeLayout(false);
            this.m_pnlAction.ResumeLayout(false);
            this.m_pnlBase.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel m_pnlAction;
        private System.Windows.Forms.Button m_btnCancel;
        private System.Windows.Forms.Button m_btnOK;
        private System.Windows.Forms.Panel m_pnlBase;
        private System.Windows.Forms.ListView m_lstvSelectCD;
        private System.Windows.Forms.ColumnHeader m_columnHeader;
    }
}