namespace BSE.Platten.Audio
{
    partial class CNoPlayerConfigurationControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CNoPlayerConfigurationControl));
            this.m_lblDescription = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // m_lblDescription
            // 
            resources.ApplyResources(this.m_lblDescription, "m_lblDescription");
            this.m_lblDescription.Name = "m_lblDescription";
            // 
            // CNoPlayerConfigurationControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_lblDescription);
            this.Name = "CNoPlayerConfigurationControl";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label m_lblDescription;
    }
}
