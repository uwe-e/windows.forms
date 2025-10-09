namespace BSE.Platten.Tunes
{
    partial class ClipBoard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClipBoard));
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.clipboard1 = new BSE.CoverFlow.WPFLib.ClipboardPanel.Clipboard();
            this.SuspendLayout();
            // 
            // elementHost1
            // 
            this.elementHost1.AccessibleDescription = null;
            this.elementHost1.AccessibleName = null;
            resources.ApplyResources(this.elementHost1, "elementHost1");
            this.elementHost1.BackgroundImage = null;
            this.elementHost1.Font = null;
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Child = this.clipboard1;
            // 
            // ClipBoard
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.elementHost1);
            this.Font = null;
            this.Name = "ClipBoard";
            this.Load += new System.EventHandler(this.CClipBoard_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private BSE.CoverFlow.WPFLib.ClipboardPanel.Clipboard clipboard1;
    }
}
