namespace BSE.Charts
{
    partial class Chart
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
            this.m_picCharts = new System.Windows.Forms.PictureBox();
            this.m_tltCharts = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.m_picCharts)).BeginInit();
            this.SuspendLayout();
            // 
            // m_picCharts
            // 
            this.m_picCharts.Location = new System.Drawing.Point(0, 0);
            this.m_picCharts.Name = "m_picCharts";
            this.m_picCharts.Size = new System.Drawing.Size(200, 200);
            this.m_picCharts.TabIndex = 0;
            this.m_picCharts.TabStop = false;
            this.m_picCharts.Click += new System.EventHandler(this.ChartsPictureClick);
            this.m_picCharts.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ChartsPictureMouseMove);
            // 
            // m_tltCharts
            // 
            this.m_tltCharts.Active = false;
            this.m_tltCharts.AutoPopDelay = 1000;
            this.m_tltCharts.InitialDelay = 500;
            this.m_tltCharts.ReshowDelay = 100;
            // 
            // Chart
            // 
            this.Controls.Add(this.m_picCharts);
            this.Size = new System.Drawing.Size(200, 200);
            ((System.ComponentModel.ISupportInitialize)(this.m_picCharts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox m_picCharts;
        private System.Windows.Forms.ToolTip m_tltCharts;

    }
}
