namespace BSE.Platten.Admin
{
    partial class MySqlConnect
    {
        #region FieldsPrivate
        
        private System.Windows.Forms.GroupBox m_grpConnect;
        private System.Windows.Forms.TextBox m_txtHost;
        private System.Windows.Forms.Label m_lblHost;
        private System.Windows.Forms.TextBox m_txtPassword;
        private System.Windows.Forms.Label m_lblPassword;
        private System.Windows.Forms.TextBox m_txtUser;
        private System.Windows.Forms.Label m_lblUser;
        private System.Windows.Forms.NumericUpDown m_txtPort;
        private System.Windows.Forms.Label m_lblPort;
        private System.Windows.Forms.Button m_btnConnect;
        private System.Windows.Forms.Button m_btnCancel;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #endregion

        #region MethodsProtected

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

        #endregion

        #region MethodsPrivate

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MySqlConnect));
            this.m_grpConnect = new System.Windows.Forms.GroupBox();
            this.m_txtPort = new System.Windows.Forms.NumericUpDown();
            this.m_txtHost = new System.Windows.Forms.TextBox();
            this.m_lblPort = new System.Windows.Forms.Label();
            this.m_lblHost = new System.Windows.Forms.Label();
            this.m_txtPassword = new System.Windows.Forms.TextBox();
            this.m_lblPassword = new System.Windows.Forms.Label();
            this.m_txtUser = new System.Windows.Forms.TextBox();
            this.m_lblUser = new System.Windows.Forms.Label();
            this.m_btnConnect = new System.Windows.Forms.Button();
            this.m_btnCancel = new System.Windows.Forms.Button();
            this.ContentPanel.SuspendLayout();
            this.m_grpConnect.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_txtPort)).BeginInit();
            this.SuspendLayout();
            // 
            // ContentPanel
            // 
            this.ContentPanel.AccessibleDescription = null;
            this.ContentPanel.AccessibleName = null;
            resources.ApplyResources(this.ContentPanel, "ContentPanel");
            this.ContentPanel.BackgroundImage = null;
            this.ContentPanel.Controls.Add(this.m_grpConnect);
            this.ContentPanel.Controls.Add(this.m_btnCancel);
            this.ContentPanel.Controls.Add(this.m_btnConnect);
            this.ContentPanel.Font = null;
            // 
            // m_grpConnect
            // 
            this.m_grpConnect.AccessibleDescription = null;
            this.m_grpConnect.AccessibleName = null;
            resources.ApplyResources(this.m_grpConnect, "m_grpConnect");
            this.m_grpConnect.BackColor = System.Drawing.Color.Transparent;
            this.m_grpConnect.BackgroundImage = null;
            this.m_grpConnect.Controls.Add(this.m_txtPort);
            this.m_grpConnect.Controls.Add(this.m_txtHost);
            this.m_grpConnect.Controls.Add(this.m_lblPort);
            this.m_grpConnect.Controls.Add(this.m_lblHost);
            this.m_grpConnect.Controls.Add(this.m_txtPassword);
            this.m_grpConnect.Controls.Add(this.m_lblPassword);
            this.m_grpConnect.Controls.Add(this.m_txtUser);
            this.m_grpConnect.Controls.Add(this.m_lblUser);
            this.m_grpConnect.Font = null;
            this.m_grpConnect.Name = "m_grpConnect";
            this.m_grpConnect.TabStop = false;
            // 
            // m_txtPort
            // 
            this.m_txtPort.AccessibleDescription = null;
            this.m_txtPort.AccessibleName = null;
            resources.ApplyResources(this.m_txtPort, "m_txtPort");
            this.m_txtPort.Font = null;
            this.m_txtPort.Maximum = new decimal(new int[] {
            3400,
            0,
            0,
            0});
            this.m_txtPort.Minimum = new decimal(new int[] {
            3200,
            0,
            0,
            0});
            this.m_txtPort.Name = "m_txtPort";
            this.m_txtPort.ReadOnly = true;
            this.m_txtPort.Value = new decimal(new int[] {
            3307,
            0,
            0,
            0});
            // 
            // m_txtHost
            // 
            this.m_txtHost.AccessibleDescription = null;
            this.m_txtHost.AccessibleName = null;
            resources.ApplyResources(this.m_txtHost, "m_txtHost");
            this.m_txtHost.BackgroundImage = null;
            this.m_txtHost.Font = null;
            this.m_txtHost.Name = "m_txtHost";
            this.m_txtHost.ReadOnly = true;
            // 
            // m_lblPort
            // 
            this.m_lblPort.AccessibleDescription = null;
            this.m_lblPort.AccessibleName = null;
            resources.ApplyResources(this.m_lblPort, "m_lblPort");
            this.m_lblPort.Font = null;
            this.m_lblPort.Name = "m_lblPort";
            // 
            // m_lblHost
            // 
            this.m_lblHost.AccessibleDescription = null;
            this.m_lblHost.AccessibleName = null;
            resources.ApplyResources(this.m_lblHost, "m_lblHost");
            this.m_lblHost.Font = null;
            this.m_lblHost.Name = "m_lblHost";
            // 
            // m_txtPassword
            // 
            this.m_txtPassword.AccessibleDescription = null;
            this.m_txtPassword.AccessibleName = null;
            resources.ApplyResources(this.m_txtPassword, "m_txtPassword");
            this.m_txtPassword.BackgroundImage = null;
            this.m_txtPassword.Font = null;
            this.m_txtPassword.Name = "m_txtPassword";
            this.m_txtPassword.UseSystemPasswordChar = true;
            // 
            // m_lblPassword
            // 
            this.m_lblPassword.AccessibleDescription = null;
            this.m_lblPassword.AccessibleName = null;
            resources.ApplyResources(this.m_lblPassword, "m_lblPassword");
            this.m_lblPassword.Font = null;
            this.m_lblPassword.Name = "m_lblPassword";
            // 
            // m_txtUser
            // 
            this.m_txtUser.AccessibleDescription = null;
            this.m_txtUser.AccessibleName = null;
            resources.ApplyResources(this.m_txtUser, "m_txtUser");
            this.m_txtUser.BackgroundImage = null;
            this.m_txtUser.Font = null;
            this.m_txtUser.Name = "m_txtUser";
            // 
            // m_lblUser
            // 
            this.m_lblUser.AccessibleDescription = null;
            this.m_lblUser.AccessibleName = null;
            resources.ApplyResources(this.m_lblUser, "m_lblUser");
            this.m_lblUser.Font = null;
            this.m_lblUser.Name = "m_lblUser";
            // 
            // m_btnConnect
            // 
            this.m_btnConnect.AccessibleDescription = null;
            this.m_btnConnect.AccessibleName = null;
            resources.ApplyResources(this.m_btnConnect, "m_btnConnect");
            this.m_btnConnect.BackgroundImage = null;
            this.m_btnConnect.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.m_btnConnect.Font = null;
            this.m_btnConnect.Name = "m_btnConnect";
            this.m_btnConnect.UseVisualStyleBackColor = true;
            this.m_btnConnect.Click += new System.EventHandler(this.m_btnConnect_Click);
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
            this.m_btnCancel.Click += new System.EventHandler(this.m_btnCancel_Click);
            // 
            // MySqlConnect
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Font = null;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MySqlConnect";
            this.ShowInTaskbar = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CMySqlConnect_FormClosing);
            this.ContentPanel.ResumeLayout(false);
            this.m_grpConnect.ResumeLayout(false);
            this.m_grpConnect.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_txtPort)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion


        #endregion
    }
}