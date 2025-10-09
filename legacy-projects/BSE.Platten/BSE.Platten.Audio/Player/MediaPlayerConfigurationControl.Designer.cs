namespace BSE.Platten.Audio
{
    partial class CMediaPlayerConfigurationControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CMediaPlayerConfigurationControl));
            this.m_lblDescription = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // m_lblDescription
            // 
            resources.ApplyResources(this.m_lblDescription, "m_lblDescription");
            this.m_lblDescription.Name = "m_lblDescription";
            // 
            // CMediaPlayerConfigurationControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_lblDescription);
            this.Name = "CMediaPlayerConfigurationControl";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label m_lblDescription;
    }
}
