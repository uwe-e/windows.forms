namespace BSE.Configuration.TestApp
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
			this.btnAddObject1 = new System.Windows.Forms.Button();
			this.m_btnOptions = new System.Windows.Forms.Button();
			this.btnAddObject2 = new System.Windows.Forms.Button();
			this.btnAddObject3 = new System.Windows.Forms.Button();
			this.btnAddObject4 = new System.Windows.Forms.Button();
			this.cConfiguration1 = new BSE.Configuration.Configuration();
			this.btnAddObject5 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnAddObject1
			// 
			this.btnAddObject1.Location = new System.Drawing.Point(12, 12);
			this.btnAddObject1.Name = "btnAddObject1";
			this.btnAddObject1.Size = new System.Drawing.Size(139, 23);
			this.btnAddObject1.TabIndex = 0;
			this.btnAddObject1.Text = "OpenFileDialog";
			this.btnAddObject1.UseVisualStyleBackColor = true;
			this.btnAddObject1.Click += new System.EventHandler(this.btnAddObject1_Click);
			// 
			// m_btnOptions
			// 
			this.m_btnOptions.Location = new System.Drawing.Point(471, 12);
			this.m_btnOptions.Name = "m_btnOptions";
			this.m_btnOptions.Size = new System.Drawing.Size(75, 23);
			this.m_btnOptions.TabIndex = 1;
			this.m_btnOptions.Text = "Options";
			this.m_btnOptions.UseVisualStyleBackColor = true;
			this.m_btnOptions.Click += new System.EventHandler(this.m_btnOptions_Click);
			// 
			// btnAddObject2
			// 
			this.btnAddObject2.Location = new System.Drawing.Point(12, 41);
			this.btnAddObject2.Name = "btnAddObject2";
			this.btnAddObject2.Size = new System.Drawing.Size(139, 23);
			this.btnAddObject2.TabIndex = 2;
			this.btnAddObject2.Text = "OpenFolderBrowseDialog";
			this.btnAddObject2.UseVisualStyleBackColor = true;
			this.btnAddObject2.Click += new System.EventHandler(this.btnAddObject2_Click);
			// 
			// btnAddObject3
			// 
			this.btnAddObject3.Location = new System.Drawing.Point(12, 70);
			this.btnAddObject3.Name = "btnAddObject3";
			this.btnAddObject3.Size = new System.Drawing.Size(139, 23);
			this.btnAddObject3.TabIndex = 3;
			this.btnAddObject3.Text = "OpenTextBox";
			this.btnAddObject3.UseVisualStyleBackColor = true;
			this.btnAddObject3.Click += new System.EventHandler(this.btnAddObject3_Click);
			// 
			// btnAddObject4
			// 
			this.btnAddObject4.Location = new System.Drawing.Point(13, 100);
			this.btnAddObject4.Name = "btnAddObject4";
			this.btnAddObject4.Size = new System.Drawing.Size(138, 23);
			this.btnAddObject4.TabIndex = 4;
			this.btnAddObject4.Text = "OpenNumericUpDown";
			this.btnAddObject4.UseVisualStyleBackColor = true;
			this.btnAddObject4.Click += new System.EventHandler(this.btnAddObject4_Click);
			// 
			// cConfiguration1
			// 
			this.cConfiguration1.ApplicationSubDirectory = null;
			// 
			// btnAddObject5
			// 
			this.btnAddObject5.Location = new System.Drawing.Point(13, 129);
			this.btnAddObject5.Name = "btnAddObject5";
			this.btnAddObject5.Size = new System.Drawing.Size(138, 23);
			this.btnAddObject5.TabIndex = 5;
			this.btnAddObject5.Text = "OpenComboBox";
			this.btnAddObject5.UseVisualStyleBackColor = true;
			this.btnAddObject5.Click += new System.EventHandler(this.btnAddObject5_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(558, 266);
			this.Controls.Add(this.btnAddObject5);
			this.Controls.Add(this.btnAddObject4);
			this.Controls.Add(this.btnAddObject3);
			this.Controls.Add(this.btnAddObject2);
			this.Controls.Add(this.m_btnOptions);
			this.Controls.Add(this.btnAddObject1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.ResumeLayout(false);

        }

        #endregion

		private System.Windows.Forms.Button btnAddObject1;
		private Configuration cConfiguration1;
		private System.Windows.Forms.Button m_btnOptions;
		private System.Windows.Forms.Button btnAddObject2;
		private System.Windows.Forms.Button btnAddObject3;
		private System.Windows.Forms.Button btnAddObject4;
		private System.Windows.Forms.Button btnAddObject5;


    }
}

