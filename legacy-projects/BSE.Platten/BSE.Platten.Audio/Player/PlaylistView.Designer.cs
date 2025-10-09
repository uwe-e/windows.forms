namespace BSE.Platten.Audio
{
    partial class CPlaylistView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CPlaylistView));
            this.m_pnlBase = new BSE.Windows.Forms.Panel();
            this.m_lstvPlaylist = new System.Windows.Forms.ListView();
            this.m_clmnTrack = new System.Windows.Forms.ColumnHeader();
            this.m_clmnDuration = new System.Windows.Forms.ColumnHeader();
            this.m_pnlBase.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_pnlBase
            // 
            this.m_pnlBase.AssociatedSplitter = null;
            this.m_pnlBase.BackColor = System.Drawing.Color.Transparent;
            this.m_pnlBase.CaptionFont = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.m_pnlBase.CaptionHeight = 27;
            this.m_pnlBase.Controls.Add(this.m_lstvPlaylist);
            this.m_pnlBase.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(184)))), ((int)(((byte)(184)))));
            this.m_pnlBase.CustomColors.CaptionCloseIcon = System.Drawing.SystemColors.ControlText;
            this.m_pnlBase.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.m_pnlBase.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.m_pnlBase.CustomColors.CaptionGradientEnd = System.Drawing.SystemColors.ButtonFace;
            this.m_pnlBase.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.m_pnlBase.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.m_pnlBase.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.m_pnlBase.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.m_pnlBase.CustomColors.CollapsedCaptionText = System.Drawing.SystemColors.ControlText;
            this.m_pnlBase.CustomColors.ContentGradientBegin = System.Drawing.SystemColors.ButtonFace;
            this.m_pnlBase.CustomColors.ContentGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.m_pnlBase.CustomColors.InnerBorderColor = System.Drawing.SystemColors.Window;
            resources.ApplyResources(this.m_pnlBase, "m_pnlBase");
            this.m_pnlBase.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.m_pnlBase.Image = null;
            this.m_pnlBase.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.m_pnlBase.MinimumSize = new System.Drawing.Size(27, 27);
            this.m_pnlBase.Name = "m_pnlBase";
            this.m_pnlBase.PanelStyle = BSE.Windows.Forms.PanelStyle.Default;
            this.m_pnlBase.ShowCaptionbar = false;
            this.m_pnlBase.ToolTipTextCloseIcon = null;
            this.m_pnlBase.ToolTipTextExpandIconPanelCollapsed = null;
            this.m_pnlBase.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // m_lstvPlaylist
            // 
            this.m_lstvPlaylist.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_lstvPlaylist.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.m_clmnTrack,
            this.m_clmnDuration});
            resources.ApplyResources(this.m_lstvPlaylist, "m_lstvPlaylist");
            this.m_lstvPlaylist.FullRowSelect = true;
            this.m_lstvPlaylist.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.m_lstvPlaylist.HideSelection = false;
            this.m_lstvPlaylist.MultiSelect = false;
            this.m_lstvPlaylist.Name = "m_lstvPlaylist";
            this.m_lstvPlaylist.UseCompatibleStateImageBehavior = false;
            this.m_lstvPlaylist.View = System.Windows.Forms.View.Details;
            this.m_lstvPlaylist.Resize += new System.EventHandler(this.PlaylistResize);
            this.m_lstvPlaylist.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PlaylistMouseUp);
            this.m_lstvPlaylist.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PlaylistKeyUp);
            // 
            // m_clmnTrack
            // 
            resources.ApplyResources(this.m_clmnTrack, "m_clmnTrack");
            // 
            // CPlaylistView
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.m_pnlBase);
            this.Name = "CPlaylistView";
            this.Load += new System.EventHandler(this.PlayListViewLoad);
            this.m_pnlBase.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private BSE.Windows.Forms.Panel m_pnlBase;
        private System.Windows.Forms.ListView m_lstvPlaylist;
        private System.Windows.Forms.ColumnHeader m_clmnTrack;
        private System.Windows.Forms.ColumnHeader m_clmnDuration;
    }
}
