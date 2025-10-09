namespace BSE.Charts.TestApp
{
    partial class Form1
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
            BSE.Charts.ChartItem chartItem1 = new BSE.Charts.ChartItem();
            BSE.Charts.ChartItem chartItem2 = new BSE.Charts.ChartItem();
            BSE.Charts.ChartItem chartItem3 = new BSE.Charts.ChartItem();
            BSE.Charts.ChartItem chartItem4 = new BSE.Charts.ChartItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.charts1 = new BSE.Charts.Chart();
            this.chart1 = new BSE.Charts.Chart();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(413, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(413, 118);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 100);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(328, 410);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // charts1
            // 
            chartItem1.Color = System.Drawing.Color.Tomato;
            chartItem1.ExpandingOffset = new System.Drawing.Point(10, 5);
            chartItem1.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(148)))), ((int)(((byte)(106)))));
            chartItem1.Index = 0;
            chartItem1.IsExpanded = false;
            chartItem1.MouseOver = false;
            chartItem1.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(66)))), ((int)(((byte)(47)))));
            chartItem1.StartAngle = 0F;
            chartItem1.SweepAngle = 58.06452F;
            chartItem1.Text = "Hallo";
            chartItem1.Value = 10F;
            chartItem2.Color = System.Drawing.Color.LimeGreen;
            chartItem2.ExpandingOffset = new System.Drawing.Point(-5, 10);
            chartItem2.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(255)))), ((int)(((byte)(75)))));
            chartItem2.Index = 1;
            chartItem2.IsExpanded = false;
            chartItem2.MouseOver = false;
            chartItem2.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(136)))), ((int)(((byte)(33)))));
            chartItem2.StartAngle = 58.06452F;
            chartItem2.SweepAngle = 121.9355F;
            chartItem2.Text = "Hallo1";
            chartItem2.Value = 21F;
            chartItem3.Color = System.Drawing.Color.Orange;
            chartItem3.ExpandingOffset = new System.Drawing.Point(0, -9);
            chartItem3.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(0)))));
            chartItem3.Index = 2;
            chartItem3.IsExpanded = false;
            chartItem3.MouseOver = false;
            chartItem3.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(110)))), ((int)(((byte)(0)))));
            chartItem3.StartAngle = 180F;
            chartItem3.SweepAngle = 180F;
            chartItem3.Text = "dddddd";
            chartItem3.Value = 31F;
            chartItem4.Color = System.Drawing.Color.DarkSeaGreen;
            chartItem4.ExpandingOffset = new System.Drawing.Point(9, 0);
            chartItem4.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(255)))), ((int)(((byte)(208)))));
            chartItem4.Index = 3;
            chartItem4.IsExpanded = false;
            chartItem4.MouseOver = false;
            chartItem4.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(125)))), ((int)(((byte)(92)))));
            chartItem4.StartAngle = 360F;
            chartItem4.SweepAngle = 0F;
            chartItem4.Text = "sdasdads";
            chartItem4.Value = 0F;
            this.charts1.ChartItems.Add(chartItem1);
            this.charts1.ChartItems.Add(chartItem2);
            this.charts1.ChartItems.Add(chartItem3);
            this.charts1.ChartItems.Add(chartItem4);
            this.charts1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.charts1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.charts1.Location = new System.Drawing.Point(33, 56);
            this.charts1.Name = "charts1";
            this.charts1.ShowLegend = true;
            this.charts1.ShowToolTip = true;
            this.charts1.Size = new System.Drawing.Size(330, 330);
            this.charts1.TabIndex = 0;
            this.charts1.Text = "charts1";
            // 
            // chart1
            // 
            this.chart1.Location = new System.Drawing.Point(413, 224);
            this.chart1.Name = "chart1";
            this.chart1.ShowLegend = true;
            this.chart1.Size = new System.Drawing.Size(200, 200);
            this.chart1.TabIndex = 4;
            this.chart1.Text = "chart1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(672, 490);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.charts1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Chart charts1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private Chart chart1;










    }
}

