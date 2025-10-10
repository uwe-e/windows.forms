namespace BSE.RemovableDrives
{
    partial class RemovableDeviceController
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
            this.components = new System.ComponentModel.Container();
            this.m_ctxUsb = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SuspendLayout();
            // 
            // m_ctxUsb
            // 
            this.m_ctxUsb.Name = "m_ctxUsb";
            this.m_ctxUsb.Size = new System.Drawing.Size(61, 4);
            // 
            // UsbControl
            // 
            this.Size = new System.Drawing.Size(16, 16);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UsbControlMouseDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip m_ctxUsb;
    }
}
