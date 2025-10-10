namespace BSE.Configuration.TestApp
{
	partial class COptions
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
			this.m_btnOK = new System.Windows.Forms.Button();
			this.m_btnCancel = new System.Windows.Forms.Button();
			this.cVisualConfiguration1 = new BSE.Configuration.VisualConfiguration();
			this.cConfiguration1 = new BSE.Configuration.Configuration();
			this.SuspendLayout();
			// 
			// m_btnOK
			// 
			this.m_btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.m_btnOK.Location = new System.Drawing.Point(311, 252);
			this.m_btnOK.Name = "m_btnOK";
			this.m_btnOK.Size = new System.Drawing.Size(75, 23);
			this.m_btnOK.TabIndex = 1;
			this.m_btnOK.Text = "OK";
			this.m_btnOK.UseVisualStyleBackColor = true;
			this.m_btnOK.Click += new System.EventHandler(this.m_btnOK_Click);
			// 
			// m_btnCancel
			// 
			this.m_btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.m_btnCancel.Location = new System.Drawing.Point(402, 252);
			this.m_btnCancel.Name = "m_btnCancel";
			this.m_btnCancel.Size = new System.Drawing.Size(75, 23);
			this.m_btnCancel.TabIndex = 2;
			this.m_btnCancel.Text = "Abbrechen";
			this.m_btnCancel.UseVisualStyleBackColor = true;
			// 
			// cVisualConfiguration1
			// 
			this.cVisualConfiguration1.Configuration = this.cConfiguration1;
			this.cVisualConfiguration1.FolderBrowserDialogDescription = "gfgfggf";
			this.cVisualConfiguration1.Location = new System.Drawing.Point(12, 12);
			this.cVisualConfiguration1.Name = "cVisualConfiguration1";
			this.cVisualConfiguration1.Size = new System.Drawing.Size(465, 221);
			this.cVisualConfiguration1.TabIndex = 0;
            this.cVisualConfiguration1.ConfigurationChanged += new System.EventHandler<ConfigChangeEventArgs>(this.cVisualConfiguration1_ConfigurationChanged);
			// 
			// COptions
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(490, 370);
			this.Controls.Add(this.m_btnCancel);
			this.Controls.Add(this.m_btnOK);
			this.Controls.Add(this.cVisualConfiguration1);
			this.KeyPreview = true;
			this.Name = "COptions";
			this.Text = "COptions";
			this.Load += new System.EventHandler(this.COptions_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private VisualConfiguration cVisualConfiguration1;
		private System.Windows.Forms.Button m_btnOK;
		private System.Windows.Forms.Button m_btnCancel;
		private Configuration cConfiguration1;
	}
}