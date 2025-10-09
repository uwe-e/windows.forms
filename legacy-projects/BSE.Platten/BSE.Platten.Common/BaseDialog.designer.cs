using System.Windows.Forms;
namespace BSE.Platten.Common
{
    partial class BaseDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseDialog));
            this.m_pnlBaseContent = new System.Windows.Forms.Panel();
            this.m_pnlAction = new System.Windows.Forms.Panel();
            this.m_btnCancel = new System.Windows.Forms.Button();
            this.m_btnOk = new System.Windows.Forms.Button();
            this.m_pnlAction.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_pnlBaseContent
            // 
            this.m_pnlBaseContent.AccessibleDescription = null;
            this.m_pnlBaseContent.AccessibleName = null;
            resources.ApplyResources(this.m_pnlBaseContent, "m_pnlBaseContent");
            this.m_pnlBaseContent.BackColor = System.Drawing.Color.Transparent;
            this.m_pnlBaseContent.BackgroundImage = null;
            this.m_pnlBaseContent.Font = null;
            this.m_pnlBaseContent.Name = "m_pnlBaseContent";
            // 
            // m_pnlAction
            // 
            this.m_pnlAction.AccessibleDescription = null;
            this.m_pnlAction.AccessibleName = null;
            resources.ApplyResources(this.m_pnlAction, "m_pnlAction");
            this.m_pnlAction.BackColor = System.Drawing.Color.Transparent;
            this.m_pnlAction.BackgroundImage = null;
            this.m_pnlAction.Controls.Add(this.m_btnCancel);
            this.m_pnlAction.Controls.Add(this.m_btnOk);
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
            // m_btnOk
            // 
            this.m_btnOk.AccessibleDescription = null;
            this.m_btnOk.AccessibleName = null;
            resources.ApplyResources(this.m_btnOk, "m_btnOk");
            this.m_btnOk.BackgroundImage = null;
            this.m_btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.m_btnOk.Font = null;
            this.m_btnOk.Name = "m_btnOk";
            this.m_btnOk.UseVisualStyleBackColor = true;
            // 
            // BaseDialog
            // 
            this.AcceptButton = this.m_btnOk;
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.CancelButton = this.m_btnCancel;
            this.Controls.Add(this.m_pnlBaseContent);
            this.Controls.Add(this.m_pnlAction);
            this.Font = null;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = null;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BaseDialog";
            this.ShowInTaskbar = false;
            this.m_pnlAction.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel m_pnlAction;
        private System.Windows.Forms.Button m_btnOk;
        private System.Windows.Forms.Button m_btnCancel;
        protected Panel m_pnlBaseContent;
    }
}