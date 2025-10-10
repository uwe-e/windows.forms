using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace BSE.Configuration
{
    [ToolboxBitmap(typeof(ListView))]
    public partial class VisualConfiguration : ScrollableControl
    {
        #region Events

        public event EventHandler<ConfigChangeEventArgs> ConfigurationChanged;

        #endregion

		#region FieldsPrivate

		private Configuration m_configuration;
		private string m_strFolderBrowserDialogDescription;
		private ListViewItem m_selectedListViewItem;

		#endregion

		#region Properties

		[Category("Appearance")]
		[Description("Used CConfiguration object")]
		[Bindable(true)]
		public Configuration Configuration
		{
			get { return this.m_configuration; }
			set { this.m_configuration = value; }
		}

		[Category("Appearance")]
		[Description("Description for Folderbrowserdialog")]
		[DefaultValue("Geben Sie das Verzeichnis an")]
		[Bindable(true)]
		public string FolderBrowserDialogDescription
		{
			get { return this.m_strFolderBrowserDialogDescription; }
			set { this.m_strFolderBrowserDialogDescription = value; }
		}

		#endregion

		#region MethodsPublic

		public VisualConfiguration()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Loads all VisibleObjects into the ListView
		/// </summary>
        public void LoadObjects()
        {
			if (this.m_configuration != null)
			{
				VisualObject[] visualObjects = this.m_configuration.GetAllVisualObjects(Configuration.VisualObjectsElementName);
				if (visualObjects != null)
				{
					LoadObjects(visualObjects);
				}
			}
        }

		/// <summary>
		/// Save all visible Objects in the listView
		/// </summary>
		public void SaveObjects()
		{
			VisualObject[] visualObjects = new VisualObject[this.m_lstConfiguration.Items.Count];
			int i = 0;
			foreach (ListViewItem listViewItem in this.m_lstConfiguration.Items)
			{
				VisualObject visualObject = (VisualObject)listViewItem.Tag;
				visualObjects[i] = visualObject;
				i++;
			}
			this.m_configuration.SaveAllVisualObjects(Configuration.VisualObjectsElementName, visualObjects);
		}

        #endregion

        #region MethodsProtected

        protected virtual void OnConfigurationChanged(object sender, ConfigChangeEventArgs e)
        {
            if (this.ConfigurationChanged != null)
            {
                this.ConfigurationChanged(sender, e);
            }
        }

        #endregion

        #region MethodsPrivate

		private void LoadObjects(VisualObject[] visualObjects)
		{
			this.m_lstConfiguration.Items.Clear();
			if (visualObjects.Length > 0)
			{
				foreach (VisualObject visualObject in visualObjects)
				{
					ListViewItem listViewItem = new ListViewItem();
					listViewItem.Text = visualObject.Description;
					listViewItem.SubItems.Add(visualObject.Value);
					listViewItem.Tag = visualObject;
					this.m_lstConfiguration.Items.Add(listViewItem);
				}
			}
		}

        private void CConfiguration_Resize(object sender, EventArgs e)
        {
            this.m_clmnHeaderKey.Width = this.m_lstConfiguration.Width / 2 - (1 * SystemInformation.Border3DSize.Width);
            this.m_clmnHeaderValue.Width = this.m_lstConfiguration.Width / 2 - (1 * SystemInformation.Border3DSize.Width);
        }

		private void m_lstConfiguration_DoubleClick(object sender, EventArgs e)
		{
			if (this.m_lstConfiguration.SelectedItems.Count > 0)
			{
				ListViewItem selectedListViewItem = this.m_lstConfiguration.SelectedItems[0];
				if (selectedListViewItem != null)
				{
					VisualObject visualObject = selectedListViewItem.Tag as VisualObject;
					if (visualObject != null)
					{
						VisualObjectType visualObjectType = visualObject.VisualObjectType;
						switch (visualObjectType)
						{
							case VisualObjectType.OpenFileDialog:
								OpenFileDialog(selectedListViewItem);
								break;
							case VisualObjectType.OpenTextBox:
								OpenTextBox(selectedListViewItem);
								break;
							case VisualObjectType.OpenFolderBrowseDialog:
								OpenFolderBrowseDialog(selectedListViewItem);
								break;
                            case VisualObjectType.OpenNumericUpDown:
                                OpenNumericUpDown(selectedListViewItem);
                                break;
                            case VisualObjectType.OpenComboBox:
                                OpenComboBox(selectedListViewItem);
                                break;
						}
					}
				}
			}
		}

		private void OpenFileDialog(ListViewItem selectedListViewItem)
		{
			if (selectedListViewItem != null)
			{
				VisualObject visualObject = selectedListViewItem.Tag as VisualObject;
				if (visualObject != null)
				{
					this.m_ofdlgFileSearch.Filter = "*.exe Dateien (*.exe)|*.exe|All files (*.*)|*.*";
					if (this.m_ofdlgFileSearch.ShowDialog(this) == DialogResult.OK)
					{
						visualObject.Value = this.m_ofdlgFileSearch.FileName;
						selectedListViewItem.SubItems[1].Text = visualObject.Value;
						selectedListViewItem.Tag = visualObject;
						this.m_lstConfiguration.Refresh();
						OnConfigurationChanged(this, new ConfigChangeEventArgs(visualObject));
					}
				}
			}
		}

		private void OpenFolderBrowseDialog(ListViewItem selectedListViewItem)
		{
			if (selectedListViewItem != null)
			{
				VisualObject visualObject = selectedListViewItem.Tag as VisualObject;

				this.m_oddlgDirectorySearch.Description = this.FolderBrowserDialogDescription;
				if (visualObject != null)
				{
					if (this.m_oddlgDirectorySearch.ShowDialog(this) == DialogResult.OK)
					{
						visualObject.Value = this.m_oddlgDirectorySearch.SelectedPath;
						selectedListViewItem.SubItems[1].Text = visualObject.Value;
						OnConfigurationChanged(this, new ConfigChangeEventArgs(visualObject));
					}
				}
			}
		}

		private void OpenTextBox(ListViewItem selectedListViewItem)
		{
            if (selectedListViewItem != null)
            {
                VisualObject visualObject = selectedListViewItem.Tag as VisualObject;
                if (visualObject != null)
                {
                    this.m_selectedListViewItem = selectedListViewItem;
                    int iX = this.m_lstConfiguration.Columns[0].Width;
                    int iY = selectedListViewItem.Bounds.Y;
                    int iWidth = this.m_lstConfiguration.Columns[1].Width;
                    int iHeight = selectedListViewItem.Bounds.Height;

                    this.m_txtEdit = null;
                    this.m_txtEdit = new System.Windows.Forms.TextBox();
                    this.m_txtEdit.Parent = this.m_lstConfiguration;
                    this.m_txtEdit.Size = new System.Drawing.Size(iWidth, iHeight);
                    this.m_txtEdit.Location = new System.Drawing.Point(iX, iY);
                    this.m_txtEdit.Visible = true;
                    this.m_txtEdit.Text = visualObject.Value;
                    this.m_txtEdit.BringToFront();
                    this.m_txtEdit.Focus();
                    this.m_txtEdit.Leave += new EventHandler(this.ControlLeave);
                    this.m_txtEdit.KeyPress += new KeyPressEventHandler(this.ControlKeyPress);
                }
            }
		}

		private void TextBoxEdited()
		{
            if ((this.m_txtEdit != null) && (this.m_selectedListViewItem != null))
            {
                using (TextBox textBox = this.m_txtEdit)
                {
                    VisualObject visualObject = this.m_selectedListViewItem.Tag as VisualObject;
                    if ((visualObject != null) && (visualObject.Value != textBox.Text))
                    {
                        visualObject.Value = textBox.Text;
                        this.m_selectedListViewItem.Tag = visualObject;
                        this.m_selectedListViewItem.SubItems[1].Text = textBox.Text;
                        OnConfigurationChanged(this, new ConfigChangeEventArgs(visualObject));
                    }
                    textBox.Visible = false;
                    textBox.Leave -= new EventHandler(this.ControlLeave);
                    textBox.KeyPress -= new KeyPressEventHandler(this.ControlKeyPress);
                }
            }
		}

        private void OpenNumericUpDown(ListViewItem selectedListViewItem)
        {
            if (selectedListViewItem != null)
            {
                VisualObject visualObject = selectedListViewItem.Tag as VisualObject;
                if (visualObject != null)
                {
                    this.m_selectedListViewItem = selectedListViewItem;
                    int iX = this.m_lstConfiguration.Columns[0].Width;
                    int iY = selectedListViewItem.Bounds.Y;
                    int iWidth = this.m_lstConfiguration.Columns[1].Width;
                    int iHeight = selectedListViewItem.Bounds.Height;

                    this.m_txtNumeric = null;
                    this.m_txtNumeric = new NumericUpDown();
                    this.m_txtNumeric.Parent = this.m_lstConfiguration;
                    this.m_txtNumeric.Size = new Size(iWidth, iHeight);
                    this.m_txtNumeric.Location = new Point(iX, iY);
                    this.m_txtNumeric.Visible = true;
                    this.m_txtNumeric.Maximum = 10000M;
                    this.m_txtNumeric.Text = visualObject.Value;
                    this.m_txtNumeric.BringToFront();
                    this.m_txtNumeric.Focus();
                    this.m_txtNumeric.Leave += new EventHandler(this.ControlLeave);
                    this.m_txtNumeric.KeyPress += new KeyPressEventHandler(this.ControlKeyPress);
                }
            }
        }

        private void NumericUpDownEdited()
        {
            if ((this.m_txtNumeric != null) && (this.m_selectedListViewItem != null))
            {
                using (NumericUpDown numericUpDown = this.m_txtNumeric)
                {
                    VisualObject visualObject = this.m_selectedListViewItem.Tag as VisualObject;
                    if ((visualObject != null) && (visualObject.Value != numericUpDown.Text))
                    {
                        visualObject.Value = numericUpDown.Text;
                        this.m_selectedListViewItem.Tag = visualObject;
                        this.m_selectedListViewItem.SubItems[1].Text = numericUpDown.Text;
                        this.OnConfigurationChanged(this, new ConfigChangeEventArgs(visualObject));
                    }
                    numericUpDown.Visible = false;
                    numericUpDown.Leave -= new EventHandler(this.ControlLeave);
                    numericUpDown.KeyPress -= new KeyPressEventHandler(this.ControlKeyPress);
                }
            }
        }

        private void OpenComboBox(ListViewItem selectedListViewItem)
        {
            if (selectedListViewItem != null)
            {
                VisualObject visualObject = selectedListViewItem.Tag as VisualObject;
                if ((visualObject != null) && (visualObject.VisualObjectItems != null))
                {
                    this.m_selectedListViewItem = selectedListViewItem;
                    int iX = this.m_lstConfiguration.Columns[0].Width;
                    int iY = selectedListViewItem.Bounds.Y;
                    int iWidth = this.m_lstConfiguration.Columns[1].Width;
                    int iHeight = selectedListViewItem.Bounds.Height;

                    this.m_cboValue = null;
                    this.m_cboValue = new ComboBox();
                    this.m_cboValue.DropDownStyle = ComboBoxStyle.DropDownList;
                    this.m_cboValue.Parent = this.m_lstConfiguration;
                    this.m_cboValue.Size = new Size(iWidth, iHeight);
                    this.m_cboValue.Location = new Point(iX, iY);
                    this.m_cboValue.Visible = true;
                    this.m_cboValue.DataSource = visualObject.VisualObjectItems;
                    this.m_cboValue.DisplayMember = "DisplayMember";
                    this.m_cboValue.BringToFront();
                    this.m_cboValue.Focus();
                    this.m_cboValue.Leave += new EventHandler(this.ControlLeave);
                    this.m_cboValue.KeyPress += new KeyPressEventHandler(this.ControlKeyPress);

                    foreach (VisualObjectItem visualObjectItem in visualObject.VisualObjectItems)
                    {
                        if ((string.IsNullOrEmpty(visualObjectItem.DisplayMember) == false)
                            && (selectedListViewItem.SubItems[1].Text.Equals(visualObjectItem.DisplayMember) == true))
                        {
                            this.m_cboValue.SelectedItem = visualObjectItem;
                        }
                    }
                }
            }
        }

        private void ComboBoxEdited()
        {
            if ((this.m_cboValue != null) && (this.m_selectedListViewItem != null))
            {
                using (ComboBox comboBox = this.m_cboValue)
                {
                    VisualObject visualObject = this.m_selectedListViewItem.Tag as VisualObject;
                    if ((visualObject != null) && (comboBox.SelectedItem != null))
                    {
                        VisualObjectItem visualObjectItem = comboBox.SelectedItem as VisualObjectItem;
                        if (visualObjectItem != null)
                        {
                            visualObject.Value = visualObjectItem.DisplayMember;
                            this.m_selectedListViewItem.Tag = visualObject;
                            this.m_selectedListViewItem.SubItems[1].Text = visualObject.Value;
                            this.OnConfigurationChanged(this, new ConfigChangeEventArgs(visualObject));
                        }
                    }
                    comboBox.Visible = false;
                    comboBox.Leave -= new EventHandler(this.ControlLeave);
                    comboBox.KeyPress -= new KeyPressEventHandler(this.ControlKeyPress);
                }
            }
        }

        private void ControlLeave(object sender, EventArgs e)
        {
            Control control = sender as Control;
            if (control != null)
            {
                TextBox textBox = control as TextBox;
                if (textBox != null)
                {
                    this.TextBoxEdited();
                }
                NumericUpDown numericUpDown = control as NumericUpDown;
                if (numericUpDown != null)
                {
                    this.NumericUpDownEdited();
                }
                ComboBox comboBox = control as ComboBox;
                if (comboBox != null)
                {
                    this.ComboBoxEdited();
                }
            }
        }

        private void ControlKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            Control control = sender as Control;
            if (control != null)
            {
                TextBox textBox = control as TextBox;
                NumericUpDown numericUpDown = control as NumericUpDown;
                ComboBox comboBox = control as ComboBox;

                switch (e.KeyChar)
                {
                    case (char)(int)Keys.Escape:
                        {
                            if (textBox != null)
                            {
                                TextBoxEdited();
                            }
                            if (numericUpDown != null)
                            {
                                NumericUpDownEdited();
                            }
                            if (comboBox != null)
                            {
                                this.ComboBoxEdited();
                            }
                            break;
                        }

                    case (char)(int)Keys.Enter:
                        {
                            if (textBox != null)
                            {
                                TextBoxEdited();
                            }
                            if (numericUpDown != null)
                            {
                                NumericUpDownEdited();
                            }
                            if (comboBox != null)
                            {
                                this.ComboBoxEdited();
                            }
                            break;
                        }
                }
            }
        }

        #endregion
		
    }
}
