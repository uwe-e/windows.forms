using System;
using BSE.Platten.Common;

namespace BSE.Platten.Tunes
{
    partial class StatusStrip
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
                    if (this.m_lblCheckDb != null)
                    {
                        this.m_lblCheckDb.HostAvailabilityChanged -= new EventHandler<HostAvailableEventArgs>(CheckDbHostAvailabilityChanged);
                        this.m_lblCheckDb.Dispose();
                    }
                    if (this.m_imgSong != null)
                    {
                        this.m_imgSong.Dispose();
                    }
                    if (this.m_imgCD != null)
                    {
                        this.m_imgCD.Dispose();
                    }
                    if (this.m_imgPlaylist != null)
                    {
                        this.m_imgPlaylist.Dispose();
                    }
                    if (this.m_imgRandom != null)
                    {
                        this.m_imgRandom.Dispose();
                    }
                    components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StatusStrip));
            this.m_lblPlayerTitle = new System.Windows.Forms.ToolStripStatusLabel();
            this.m_removableDeviceController = new BSE.RemovableDrives.ToolStripRemovableDeviceController();
            this.SuspendLayout();
            // 
            // m_lblPlayerTitle
            // 
            this.m_lblPlayerTitle.AutoSize = false;
            this.m_lblPlayerTitle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_lblPlayerTitle.Name = "m_lblPlayerTitle";
            this.m_lblPlayerTitle.Size = new System.Drawing.Size(163, 17);
            this.m_lblPlayerTitle.Spring = true;
            this.m_lblPlayerTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_removableDeviceController
            // 
            this.m_removableDeviceController.BackColor = System.Drawing.Color.Transparent;
            this.m_removableDeviceController.Image = ((System.Drawing.Image)(resources.GetObject("m_removableDeviceController.Image")));
            this.m_removableDeviceController.Name = "m_removableDeviceController";
            this.m_removableDeviceController.Size = new System.Drawing.Size(22, 17);
            this.m_removableDeviceController.Text = "removableDeviceController";
            this.m_removableDeviceController.DriveChanges += new System.EventHandler<BSE.RemovableDrives.DriveChangeEventArgs>(this.RemovableDriveControllerDriveChanges);
            this.m_removableDeviceController.DriveRemoved += new System.EventHandler<BSE.RemovableDrives.DriveChangeEventArgs>(this.RemovableDriveControllerDriveRemoved);
            this.m_removableDeviceController.DriveAdded += new System.EventHandler<BSE.RemovableDrives.DriveChangeEventArgs>(this.RemovableDriveControllerDriveAdded);
            // 
            // StatusStrip
            // 
            this.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_lblPlayerTitle,
            this.m_removableDeviceController});
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripStatusLabel m_lblPlayerTitle;
        private BSE.RemovableDrives.ToolStripRemovableDeviceController m_removableDeviceController;
    }
}
