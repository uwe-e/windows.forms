using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections.ObjectModel;

namespace BSE.Configuration.TestApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //Nur wenn die Konfiguration in einem eigenen Unterverzeichnis gespeichert werden soll
            //werden diese Parameter benötigt
            //ansonsten müssen keine Angaben gemacht werden
            this.cConfiguration1.ApplicationSubDirectory = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
            this.cConfiguration1.ConfigFileName = "HalloUwe";
        }

		private void btnAddObject1_Click(object sender, EventArgs e)
		{
			string strValue = string.Empty;
			VisualObject vo1 = new VisualObject();
			vo1.Element = "Test1";
			vo1.Description = "VisualObject OpenFileDialog";
			vo1.VisualObjectType = VisualObjectType.OpenFileDialog;
			vo1.ErrorMessage = "\r\nAchtung!\nHost -> Optionen.";
			try
			{
				strValue = cConfiguration1.GetValue(Configuration.VisualObjectsElementName, vo1).ToString();
				MessageBox.Show("Value: " + strValue);
			}
			catch (ConfigurationValueNotFoundException ex)
			{
				MessageBox.Show(ex.Message);
				this.m_btnOptions_Click(this, new System.EventArgs());
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void btnAddObject2_Click(object sender, EventArgs e)
		{
			string strValue = string.Empty;
			VisualObject vo1 = new VisualObject();
			vo1.Element = "Test2";
			vo1.Description = "VisualObject OpenFolderBrowseDialog";
			vo1.VisualObjectType = VisualObjectType.OpenFolderBrowseDialog;
			vo1.ErrorMessage = "\r\nAchtung!\n noch ein test -> Optionen.";
			try
			{
				strValue = cConfiguration1.GetValue(Configuration.VisualObjectsElementName,vo1).ToString();
				MessageBox.Show("Value: " + strValue);
			}
			catch (ConfigurationValueNotFoundException ex)
			{
				MessageBox.Show(ex.Message);
				this.m_btnOptions_Click(this, new System.EventArgs());
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void btnAddObject3_Click(object sender, EventArgs e)
		{
			string strValue = string.Empty;
			VisualObject vo1 = new VisualObject();
			vo1.Element = "Test3";
			vo1.Description = "VisualObject OpenTextBox";
			vo1.VisualObjectType = VisualObjectType.OpenTextBox;
			vo1.ErrorMessage = "\r\nAchtung!\n noch ein weiterer test -> Optionen.";
			try
			{
				strValue = cConfiguration1.GetValue(Configuration.VisualObjectsElementName, vo1).ToString();
				MessageBox.Show("Value: " + strValue);
			}
			catch (ConfigurationValueNotFoundException ex)
			{
				MessageBox.Show(ex.Message);
				this.m_btnOptions_Click(this, new System.EventArgs());
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		private void btnAddObject4_Click(object sender, EventArgs e)
		{
			string strValue = string.Empty;
			VisualObject visualObject = new VisualObject();
			visualObject.Element = "Test4";
			visualObject.Description = "VisualObject OpenNumericUpDown";
			visualObject.VisualObjectType = VisualObjectType.OpenNumericUpDown;
			visualObject.ErrorMessage = "\r\nAchtung!\n noch ein weiterer test -> Optionen.";
			try
			{
				strValue = cConfiguration1.GetValue(Configuration.VisualObjectsElementName, visualObject).ToString();
				MessageBox.Show("Value: " + strValue);
			}
			catch (ConfigurationValueNotFoundException ex)
			{
				MessageBox.Show(ex.Message);
				this.m_btnOptions_Click(this, new System.EventArgs());
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
		private void btnAddObject5_Click(object sender, EventArgs e)
		{
			Collection<VisualObjectItem> collection = new Collection<VisualObjectItem>();
			VisualObjectItem person1 = new VisualObjectItem();
			person1.DisplayMember = "Uwe Eichkorn";
			collection.Add(person1);

			VisualObjectItem person2 = new VisualObjectItem();
			person2.DisplayMember = "Alfred E. Neumann";
			collection.Add(person2);

			string strValue = string.Empty;

			VisualObject visualObject = new VisualObject();
			visualObject.Element = "Test5";
			visualObject.Description = "VisualObject ComboBox";
			visualObject.VisualObjectType = VisualObjectType.OpenComboBox;
			visualObject.VisualObjectItems = collection;
			visualObject.ErrorMessage = "\r\nAchtung!\n es müsste die Auswahl au der ComboBox getätigt werden -> Optionen.";
			try
			{
				strValue = cConfiguration1.GetValue(Configuration.VisualObjectsElementName, visualObject).ToString();
				MessageBox.Show("Value: " + strValue);
			}
			catch (ConfigurationValueNotFoundException ex)
			{
				MessageBox.Show(ex.Message);
				this.m_btnOptions_Click(this, new System.EventArgs());
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
		private void m_btnOptions_Click(object sender, EventArgs e)
		{
			COptions options = new COptions(this.cConfiguration1);
			options.ShowDialog();
		}

        private void Form1_Load(object sender, EventArgs e)
        {
            bool bTest = (bool)this.cConfiguration1.GetValue("section", "element", false);
            MessageBox.Show("Value: " + bTest);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.cConfiguration1.SetValue("section", "element", true);
        }

    }

	public class CPerson
	{
		private int m_iId;
		private string m_strVorname;
		private string m_strName;

		public int Id
		{
			get { return this.m_iId; }
			set { this.m_iId = value; }
		}

		public string Vorname
		{
			get { return this.m_strVorname; }
			set { this.m_strVorname = value; }
		}

		public string Name
		{
			get { return this.m_strName; }
			set { this.m_strName = value; }
		}
	}
}