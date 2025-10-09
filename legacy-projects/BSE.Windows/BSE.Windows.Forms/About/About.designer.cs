namespace BSE.Windows.Forms
{
    partial class About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            this.m_lblProduct = new System.Windows.Forms.Label();
            this.m_lblDescription = new System.Windows.Forms.Label();
            this.m_lblVersion = new System.Windows.Forms.Label();
            this.m_lblComponents = new System.Windows.Forms.Label();
            this.m_btnOK = new System.Windows.Forms.Button();
            this.m_lblWarning = new System.Windows.Forms.Label();
            this.m_lstvAbout = new BSE.Windows.Forms.ListView();
            this.m_lstvAboutclmnHeaderName = new BSE.Windows.Forms.ColumnHeader();
            this.m_lstvAboutclmnHeaderVersion = new BSE.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // m_lblProduct
            // 
            resources.ApplyResources(this.m_lblProduct, "m_lblProduct");
            this.m_lblProduct.BackColor = System.Drawing.Color.Transparent;
            this.m_lblProduct.Font = null;
            this.m_lblProduct.Name = "m_lblProduct";
            // 
            // m_lblDescription
            // 
            resources.ApplyResources(this.m_lblDescription, "m_lblDescription");
            this.m_lblDescription.BackColor = System.Drawing.Color.Transparent;
            this.m_lblDescription.Font = null;
            this.m_lblDescription.Name = "m_lblDescription";
            // 
            // m_lblVersion
            // 
            resources.ApplyResources(this.m_lblVersion, "m_lblVersion");
            this.m_lblVersion.BackColor = System.Drawing.Color.Transparent;
            this.m_lblVersion.Font = null;
            this.m_lblVersion.Name = "m_lblVersion";
            // 
            // m_lblComponents
            // 
            this.m_lblComponents.AccessibleDescription = null;
            this.m_lblComponents.AccessibleName = null;
            resources.ApplyResources(this.m_lblComponents, "m_lblComponents");
            this.m_lblComponents.BackColor = System.Drawing.Color.Transparent;
            this.m_lblComponents.Font = null;
            this.m_lblComponents.Name = "m_lblComponents";
            // 
            // m_btnOK
            // 
            this.m_btnOK.AccessibleDescription = null;
            this.m_btnOK.AccessibleName = null;
            resources.ApplyResources(this.m_btnOK, "m_btnOK");
            this.m_btnOK.BackgroundImage = null;
            this.m_btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.m_btnOK.Font = null;
            this.m_btnOK.Name = "m_btnOK";
            // 
            // m_lblWarning
            // 
            this.m_lblWarning.AccessibleDescription = null;
            this.m_lblWarning.AccessibleName = null;
            resources.ApplyResources(this.m_lblWarning, "m_lblWarning");
            this.m_lblWarning.BackColor = System.Drawing.Color.Transparent;
            this.m_lblWarning.Font = null;
            this.m_lblWarning.Name = "m_lblWarning";
            // 
            // m_lstvAbout
            // 
            this.m_lstvAbout.AccessibleDescription = null;
            this.m_lstvAbout.AccessibleName = null;
            resources.ApplyResources(this.m_lstvAbout, "m_lstvAbout");
            this.m_lstvAbout.AllowColumnReorder = true;
            this.m_lstvAbout.AlternatingBackColor = System.Drawing.SystemColors.ControlLight;
            this.m_lstvAbout.BackgroundImage = null;
            this.m_lstvAbout.Columns.AddRange(new BSE.Windows.Forms.ColumnHeader[] {
            this.m_lstvAboutclmnHeaderName,
            this.m_lstvAboutclmnHeaderVersion});
            this.m_lstvAbout.FitLargestItem = true;
            this.m_lstvAbout.Font = null;
            this.m_lstvAbout.FullRowSelect = true;
            this.m_lstvAbout.MultiSelect = false;
            this.m_lstvAbout.Name = "m_lstvAbout";
            this.m_lstvAbout.UseCompatibleStateImageBehavior = false;
            this.m_lstvAbout.View = System.Windows.Forms.View.Details;
            this.m_lstvAbout.Resize += new System.EventHandler(this.m_lstvAbout_Resize);
            // 
            // m_lstvAboutclmnHeaderName
            // 
            this.m_lstvAboutclmnHeaderName.ListViewComparer = BSE.Windows.Forms.ListViewComparer.Strings;
            resources.ApplyResources(this.m_lstvAboutclmnHeaderName, "m_lstvAboutclmnHeaderName");
            // 
            // m_lstvAboutclmnHeaderVersion
            // 
            this.m_lstvAboutclmnHeaderVersion.ListViewComparer = BSE.Windows.Forms.ListViewComparer.Strings;
            resources.ApplyResources(this.m_lstvAboutclmnHeaderVersion, "m_lstvAboutclmnHeaderVersion");
            // 
            // About
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.m_lstvAbout);
            this.Controls.Add(this.m_lblWarning);
            this.Controls.Add(this.m_lblProduct);
            this.Controls.Add(this.m_lblDescription);
            this.Controls.Add(this.m_lblVersion);
            this.Controls.Add(this.m_lblComponents);
            this.Controls.Add(this.m_btnOK);
            this.Font = null;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = null;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "About";
            this.Load += new System.EventHandler(this.About_Load);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Label m_lblProduct;
        internal System.Windows.Forms.Label m_lblDescription;
        internal System.Windows.Forms.Label m_lblVersion;
        private System.Windows.Forms.Label m_lblComponents;
        private System.Windows.Forms.Button m_btnOK;
        private System.Windows.Forms.Label m_lblWarning;
        private ListView m_lstvAbout;
        private ColumnHeader m_lstvAboutclmnHeaderName;
        private ColumnHeader m_lstvAboutclmnHeaderVersion;
    }
}