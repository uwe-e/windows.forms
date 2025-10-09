namespace BSE.Platten.Tunes.Filters
{
    partial class FilterMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FilterMain));
            this.m_pnlFilterSelection = new BSE.Windows.Forms.Panel();
            this.m_pnlUsingFilters = new System.Windows.Forms.Panel();
            this.m_splLeft = new BSE.Windows.Forms.Splitter();
            this.m_pnlFilters = new BSE.Windows.Forms.Panel();
            this.m_tabFilters = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.m_filterGenre = new BSE.Platten.Tunes.Filters.FilterGenre();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.m_filterYear = new BSE.Platten.Tunes.Filters.FilterYear();
            this.m_pnlAction = new System.Windows.Forms.Panel();
            this.m_btnCancel = new System.Windows.Forms.Button();
            this.m_btnOK = new System.Windows.Forms.Button();
            this.ContentPanel.SuspendLayout();
            this.m_pnlFilterSelection.SuspendLayout();
            this.m_pnlFilters.SuspendLayout();
            this.m_tabFilters.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.m_pnlAction.SuspendLayout();
            this.SuspendLayout();
            // 
            // ContentPanel
            // 
            resources.ApplyResources(this.ContentPanel, "ContentPanel");
            this.ContentPanel.BackColor = System.Drawing.SystemColors.Control;
            this.ContentPanel.Controls.Add(this.m_pnlFilters);
            this.ContentPanel.Controls.Add(this.m_splLeft);
            this.ContentPanel.Controls.Add(this.m_pnlFilterSelection);
            // 
            // m_pnlFilterSelection
            // 
            resources.ApplyResources(this.m_pnlFilterSelection, "m_pnlFilterSelection");
            this.m_pnlFilterSelection.AssociatedSplitter = null;
            this.m_pnlFilterSelection.BackColor = System.Drawing.Color.Transparent;
            this.m_pnlFilterSelection.CaptionFont = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_pnlFilterSelection.CaptionHeight = 27;
            this.m_pnlFilterSelection.Controls.Add(this.m_pnlUsingFilters);
            this.m_pnlFilterSelection.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(184)))), ((int)(((byte)(184)))));
            this.m_pnlFilterSelection.CustomColors.CaptionCloseIcon = System.Drawing.SystemColors.ControlText;
            this.m_pnlFilterSelection.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.m_pnlFilterSelection.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.m_pnlFilterSelection.CustomColors.CaptionGradientEnd = System.Drawing.SystemColors.ButtonFace;
            this.m_pnlFilterSelection.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.m_pnlFilterSelection.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.m_pnlFilterSelection.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.m_pnlFilterSelection.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.m_pnlFilterSelection.CustomColors.CollapsedCaptionText = System.Drawing.SystemColors.ControlText;
            this.m_pnlFilterSelection.CustomColors.ContentGradientBegin = System.Drawing.SystemColors.ButtonFace;
            this.m_pnlFilterSelection.CustomColors.ContentGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.m_pnlFilterSelection.CustomColors.InnerBorderColor = System.Drawing.SystemColors.Window;
            this.m_pnlFilterSelection.ForeColor = System.Drawing.SystemColors.ControlText;
            this.m_pnlFilterSelection.Image = null;
            this.m_pnlFilterSelection.Name = "m_pnlFilterSelection";
            this.m_pnlFilterSelection.ToolTipTextCloseIcon = null;
            this.m_pnlFilterSelection.ToolTipTextExpandIconPanelCollapsed = null;
            this.m_pnlFilterSelection.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // m_pnlUsingFilters
            // 
            resources.ApplyResources(this.m_pnlUsingFilters, "m_pnlUsingFilters");
            this.m_pnlUsingFilters.BackColor = System.Drawing.SystemColors.Window;
            this.m_pnlUsingFilters.Name = "m_pnlUsingFilters";
            // 
            // m_splLeft
            // 
            resources.ApplyResources(this.m_splLeft, "m_splLeft");
            this.m_splLeft.BackColor = System.Drawing.Color.Transparent;
            this.m_splLeft.Name = "m_splLeft";
            this.m_splLeft.TabStop = false;
            // 
            // m_pnlFilters
            // 
            resources.ApplyResources(this.m_pnlFilters, "m_pnlFilters");
            this.m_pnlFilters.AssociatedSplitter = null;
            this.m_pnlFilters.BackColor = System.Drawing.Color.Transparent;
            this.m_pnlFilters.CaptionFont = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_pnlFilters.CaptionHeight = 27;
            this.m_pnlFilters.Controls.Add(this.m_tabFilters);
            this.m_pnlFilters.Controls.Add(this.m_pnlAction);
            this.m_pnlFilters.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(184)))), ((int)(((byte)(184)))));
            this.m_pnlFilters.CustomColors.CaptionCloseIcon = System.Drawing.SystemColors.ControlText;
            this.m_pnlFilters.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.m_pnlFilters.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.m_pnlFilters.CustomColors.CaptionGradientEnd = System.Drawing.SystemColors.ButtonFace;
            this.m_pnlFilters.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.m_pnlFilters.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.m_pnlFilters.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.m_pnlFilters.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.m_pnlFilters.CustomColors.CollapsedCaptionText = System.Drawing.SystemColors.ControlText;
            this.m_pnlFilters.CustomColors.ContentGradientBegin = System.Drawing.SystemColors.ButtonFace;
            this.m_pnlFilters.CustomColors.ContentGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.m_pnlFilters.CustomColors.InnerBorderColor = System.Drawing.SystemColors.Window;
            this.m_pnlFilters.ForeColor = System.Drawing.SystemColors.ControlText;
            this.m_pnlFilters.Image = null;
            this.m_pnlFilters.Name = "m_pnlFilters";
            this.m_pnlFilters.ToolTipTextCloseIcon = null;
            this.m_pnlFilters.ToolTipTextExpandIconPanelCollapsed = null;
            this.m_pnlFilters.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // m_tabFilters
            // 
            resources.ApplyResources(this.m_tabFilters, "m_tabFilters");
            this.m_tabFilters.Controls.Add(this.tabPage1);
            this.m_tabFilters.Controls.Add(this.tabPage2);
            this.m_tabFilters.Name = "m_tabFilters";
            this.m_tabFilters.SelectedIndex = 0;
            // 
            // tabPage1
            // 
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Controls.Add(this.m_filterGenre);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // m_filterGenre
            // 
            resources.ApplyResources(this.m_filterGenre, "m_filterGenre");
            this.m_filterGenre.FilterName = "Filter By Genre";
            this.m_filterGenre.Name = "m_filterGenre";
            this.m_filterGenre.FilterCheckStateChanged += new System.EventHandler<BSE.Platten.Tunes.Filters.FilterCheckStateChangeEventArgs>(this.FilterCheckStateChanged);
            this.m_filterGenre.FilterAdded += new System.EventHandler<BSE.Platten.Tunes.Filters.FilterNotificationEventArgs>(this.FilterAdded);
            // 
            // tabPage2
            // 
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Controls.Add(this.m_filterYear);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // m_filterYear
            // 
            resources.ApplyResources(this.m_filterYear, "m_filterYear");
            this.m_filterYear.FilterName = "Filter By Publishing Year";
            this.m_filterYear.Name = "m_filterYear";
            this.m_filterYear.FilterCheckStateChanged += new System.EventHandler<BSE.Platten.Tunes.Filters.FilterCheckStateChangeEventArgs>(this.FilterCheckStateChanged);
            this.m_filterYear.FilterAdded += new System.EventHandler<BSE.Platten.Tunes.Filters.FilterNotificationEventArgs>(this.FilterAdded);
            // 
            // m_pnlAction
            // 
            resources.ApplyResources(this.m_pnlAction, "m_pnlAction");
            this.m_pnlAction.BackColor = System.Drawing.Color.Transparent;
            this.m_pnlAction.Controls.Add(this.m_btnCancel);
            this.m_pnlAction.Controls.Add(this.m_btnOK);
            this.m_pnlAction.Name = "m_pnlAction";
            // 
            // m_btnCancel
            // 
            resources.ApplyResources(this.m_btnCancel, "m_btnCancel");
            this.m_btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_btnCancel.Name = "m_btnCancel";
            this.m_btnCancel.UseVisualStyleBackColor = true;
            // 
            // m_btnOK
            // 
            resources.ApplyResources(this.m_btnOK, "m_btnOK");
            this.m_btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.m_btnOK.Name = "m_btnOK";
            this.m_btnOK.UseVisualStyleBackColor = true;
            this.m_btnOK.Click += new System.EventHandler(this.BtnOKClick);
            // 
            // FilterMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "FilterMain";
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.FilterMainLoad);
            this.Controls.SetChildIndex(this.ContentPanel, 0);
            this.ContentPanel.ResumeLayout(false);
            this.m_pnlFilterSelection.ResumeLayout(false);
            this.m_pnlFilters.ResumeLayout(false);
            this.m_tabFilters.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.m_pnlAction.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private BSE.Windows.Forms.Panel m_pnlFilterSelection;
        private BSE.Windows.Forms.Splitter m_splLeft;
        private BSE.Windows.Forms.Panel m_pnlFilters;
        private System.Windows.Forms.TabControl m_tabFilters;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel m_pnlAction;
        private System.Windows.Forms.Button m_btnCancel;
        private System.Windows.Forms.Button m_btnOK;
        private FilterGenre m_filterGenre;
        private System.Windows.Forms.Panel m_pnlUsingFilters;
        private FilterYear m_filterYear;
    }
}