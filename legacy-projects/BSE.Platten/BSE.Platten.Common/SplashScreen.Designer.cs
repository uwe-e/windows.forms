namespace BSE.Platten.Common
{
    partial class CSplashScreen
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
            try
            {
                if (disposing == true)
                {
                    if (m_instanceCallerThread != null)
                    {
                        m_instanceCallerThread = null;
                    }
                    if (components != null)
                    {
                        components.Dispose();
                    }
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CSplashScreen));
            this.m_pnlStatus = new System.Windows.Forms.Panel();
            this.m_lblStatusMessage = new System.Windows.Forms.Label();
            this.m_pnlStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_pnlStatus
            // 
            this.m_pnlStatus.BackColor = System.Drawing.Color.Transparent;
            this.m_pnlStatus.Controls.Add(this.m_lblStatusMessage);
            resources.ApplyResources(this.m_pnlStatus, "m_pnlStatus");
            this.m_pnlStatus.Name = "m_pnlStatus";
            this.m_pnlStatus.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelStatusPaint);
            // 
            // m_lblStatusMessage
            // 
            resources.ApplyResources(this.m_lblStatusMessage, "m_lblStatusMessage");
            this.m_lblStatusMessage.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.m_lblStatusMessage.Name = "m_lblStatusMessage";
            // 
            // CSplashScreen
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::BSE.Platten.Common.Properties.Resources.BSEsplash;
            this.Controls.Add(this.m_pnlStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CSplashScreen";
            this.TransparencyKey = System.Drawing.SystemColors.Control;
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SplashScreenMouseClick);
            this.m_pnlStatus.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel m_pnlStatus;
        private System.Windows.Forms.Label m_lblStatusMessage;





    }
}