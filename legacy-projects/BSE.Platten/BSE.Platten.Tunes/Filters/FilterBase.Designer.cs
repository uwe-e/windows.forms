namespace BSE.Platten.Tunes.Filters
{
    partial class FilterBase
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
            this.m_lstvFilter = new BSE.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // m_lstvFilter
            // 
            this.m_lstvFilter.AllowColumnReorder = true;
            this.m_lstvFilter.AlternatingBackColor = System.Drawing.SystemColors.Window;
            this.m_lstvFilter.CheckBoxes = true;
            this.m_lstvFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lstvFilter.FitLargestItem = true;
            this.m_lstvFilter.Location = new System.Drawing.Point(0, 0);
            this.m_lstvFilter.Name = "m_lstvFilter";
            this.m_lstvFilter.Size = new System.Drawing.Size(280, 150);
            this.m_lstvFilter.TabIndex = 0;
            this.m_lstvFilter.UseCompatibleStateImageBehavior = false;
            this.m_lstvFilter.View = System.Windows.Forms.View.Details;
            this.m_lstvFilter.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.FilterItemCheck);
            this.m_lstvFilter.Resize += new System.EventHandler(this.FilterResize);
            // 
            // CFilterBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_lstvFilter);
            this.Name = "CFilterBase";
            this.Size = new System.Drawing.Size(280, 150);
            this.Load += new System.EventHandler(this.FilterLoad);
            this.ResumeLayout(false);

        }

        #endregion

        protected BSE.Windows.Forms.ListView m_lstvFilter;

    }
}
