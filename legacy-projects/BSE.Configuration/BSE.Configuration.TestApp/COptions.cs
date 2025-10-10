using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BSE.Configuration.TestApp
{
	public partial class COptions : Form
	{
		#region FieldsPrivate

		private bool m_bConfigHasChanged;

		#endregion

		#region Properties

		[System.ComponentModel.Category("Appearance")]
		[System.ComponentModel.Description("Used CConfiguration object")]
		[System.ComponentModel.Bindable(true)]
		public Configuration Configuration
		{
			get { return this.cVisualConfiguration1.Configuration; }
			set { this.cVisualConfiguration1.Configuration = value; }
		}

		#endregion

		#region MethodsPublic

		public COptions()
		{
			InitializeComponent();
			this.KeyPreview = true;
		}

		public COptions(Configuration configuration)
			: this()
		{
			this.cVisualConfiguration1.Configuration = configuration;
		}

		#endregion

		#region MethodsPrivate

		private void cVisualConfiguration1_ConfigurationChanged(object sender, ConfigChangeEventArgs e)
		{
			this.m_bConfigHasChanged = true;
			//MessageBox.Show("config.changed: " + e.VisualObject.Value);
		}
		
		private void COptions_Load(object sender, EventArgs e)
		{
			if (this.cVisualConfiguration1 != null)
			{
				this.cVisualConfiguration1.LoadObjects();
			}
		}

		#endregion

		private void m_btnOK_Click(object sender, EventArgs e)
		{
			if (this.m_bConfigHasChanged)
			{
				if (this.cVisualConfiguration1 != null)
				{
					this.cVisualConfiguration1.SaveObjects();
				}
			}
		}
		
	}
}