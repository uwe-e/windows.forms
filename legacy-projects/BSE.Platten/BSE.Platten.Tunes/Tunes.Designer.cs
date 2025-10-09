namespace BSE.Platten.Tunes
{
    partial class Tunes
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
                if (disposing && (components != null))
                {
                    components.Dispose();
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Tunes));
            this.m_settings = new BSE.Configuration.Configuration();
            this.m_configuration = new BSE.Configuration.Configuration();
            this.m_ctxTunes = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_elementHostDesktop = new System.Windows.Forms.Integration.ElementHost();
            this.desktop1 = new BSE.CoverFlow.WPFLib.Desktop.Desktop();
            this.ContentPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ContentPanel
            // 
            this.ContentPanel.Controls.Add(this.m_elementHostDesktop);
            resources.ApplyResources(this.ContentPanel, "ContentPanel");
            // 
            // m_settings
            // 
            this.m_settings.ApplicationSubDirectory = null;
            // 
            // m_configuration
            // 
            this.m_configuration.ApplicationSubDirectory = null;
            // 
            // m_ctxTunes
            // 
            this.m_ctxTunes.Name = "m_ctxTunes";
            resources.ApplyResources(this.m_ctxTunes, "m_ctxTunes");
            // 
            // m_elementHostDesktop
            // 
            resources.ApplyResources(this.m_elementHostDesktop, "m_elementHostDesktop");
            this.m_elementHostDesktop.Name = "m_elementHostDesktop";
            this.m_elementHostDesktop.Child = this.desktop1;
            // 
            // Tunes
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.KeyPreview = true;
            this.Name = "Tunes";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CTunes_FormClosing);
            this.Load += new System.EventHandler(this.CTunes_Load);
            this.Controls.SetChildIndex(this.ContentPanel, 0);
            this.ContentPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private BSE.Configuration.Configuration m_configuration;
        private BSE.Configuration.Configuration m_settings;
        private System.Windows.Forms.ContextMenuStrip m_ctxTunes;
        private System.Windows.Forms.Integration.ElementHost m_elementHostDesktop;
        private CoverFlow.WPFLib.Desktop.Desktop desktop1;
    }
}

