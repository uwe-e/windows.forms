using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using BSE.Platten.BO;
using BSE.Platten.Common;
using System.Globalization;
using BSE.Platten.Tunes.Properties;

namespace BSE.Platten.Tunes.Filters
{
    public partial class FilterBase : UserControl, IFilterConfiguration
    {
        #region Events

        public event EventHandler<FilterCheckStateChangeEventArgs> FilterCheckStateChanged;
        public event EventHandler<FilterNotificationEventArgs> FilterAdded;

        #endregion

        private CheckBox m_checkBoxFilter;
        private string m_strFilterName;
        
        #region Properties

        public virtual string FilterName
        {
            get { return this.m_strFilterName; }
            set { this.m_strFilterName = value; }
        }

        public virtual FilterSettings.FilterMode FilterMode
        {
            get { return FilterSettings.FilterMode.None; }
        }

        #endregion

        #region MethodsPublic

        public FilterBase()
        {
            InitializeComponent();
            this.m_strFilterName = Resources.IDS_FilterNoActiceFilterText;
            this.m_lstvFilter.AlternatingBackColor = BSE.Platten.Common.BSEColors.AlternatingBackColor;
            this.m_checkBoxFilter = new CheckBox();
            this.m_checkBoxFilter.CheckAlign = ContentAlignment.TopLeft;
            this.m_checkBoxFilter.TextAlign = ContentAlignment.TopLeft;
            this.m_checkBoxFilter.AutoSize = true;

        }

        public virtual FilterConfiguration GetFilterConfiguration(BSE.Platten.BO.Environment environment)
        {
            FilterConfiguration filterConfiguration = new FilterConfiguration();
            filterConfiguration.UsedFilterMode = this.FilterMode;
            filterConfiguration.FilterName = this.FilterName;
            FilterSettings filterSettings = GetFilterSettings(environment);
            if (filterSettings != null)
            {
                filterConfiguration.IsUsed = filterSettings.IsUsed;
                filterConfiguration.Value = filterSettings.Value;
            }
            return filterConfiguration;
        }

        public virtual void SafeFilterConfiguration(BSE.Platten.BO.Environment environment, bool bUsedFilter)
        {
            if (environment == null)
            {
                throw new ArgumentNullException(
                    string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.IDS_ArgumentNullException, "environment"));
            }
            string strValue = string.Empty;
            foreach (ListViewItem listViewItem in this.m_lstvFilter.Items)
            {
                if (listViewItem.Checked)
                {
                    CFilter filter = (CFilter)listViewItem.Tag;
                    strValue = strValue + filter.Id + ",";
                }
            }
            if (String.IsNullOrEmpty(strValue) == false)
            {
                strValue = strValue.Remove(strValue.Length - 1, 1);
            }

            CTunesBusinessObject tunesBusinessObject = new CTunesBusinessObject(environment.GetConnectionString());
            try
            {
                FilterSettings filterSettings = new FilterSettings();
                filterSettings.UsedFilterMode = this.FilterMode;
                filterSettings.Value = strValue;
                filterSettings.IsUsed = bUsedFilter;
                filterSettings.Benutzer = environment.UserName;
                tunesBusinessObject.SaveFilterSettings(filterSettings);
            }
            catch (Exception exception)
            {
                GlobalizedMessageBox.Show(this,exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public virtual void SetFilterValues(BSE.Platten.BO.Environment environment)
        {
            LoadFilterValues(environment);
        }
        
        #endregion

        #region MethodsProtected
        #endregion

        #region MethodsPrivate
        
        private void FilterLoad(object sender, EventArgs e)
        {
            Control parentControl = this.Parent;
            if (parentControl != null)
            {
                parentControl.Text = this.FilterName;
            }
        }
        
        private void FilterItemCheck(object sender, ItemCheckEventArgs e)
        {
            bool bCheckBoxState = false;
            if (e.CurrentValue == CheckState.Checked)
            {
                bCheckBoxState = false;
            }
            if (e.CurrentValue == CheckState.Unchecked)
            {
                bCheckBoxState = true;
            }
            CheckListViewStatus(bCheckBoxState);
        }

        private void FilterResize(object sender, EventArgs e)
        {
            if (this.m_lstvFilter.Columns.Count == 2)
            {
                BSE.Windows.Forms.ColumnHeader columnHeader1 = this.m_lstvFilter.Columns[0];
                BSE.Windows.Forms.ColumnHeader columnHeader2 = this.m_lstvFilter.Columns[1];
                columnHeader2.Width = this.Width - columnHeader1.Width - ( 2 * SystemInformation.Border3DSize.Width);
            }
        }

        private void LoadFilterValues(BSE.Platten.BO.Environment environment)
        {
            bool bUsedFilter = false;
            CTunesBusinessObject tunesBusinessObject = new CTunesBusinessObject(environment.GetConnectionString());
            try
            {
                CFilter[] filters = tunesBusinessObject.GetFilterByFilterMode(this.FilterMode);
                if (filters != null)
                {
                    FilterSettings filterSettings = GetFilterSettings(environment);
                    if (filterSettings != null)
                    {
                        bUsedFilter = filterSettings.IsUsed;
                    }
                    ArrayList aFilterOptions = GetFilterSettingsArrayList(filterSettings);
                    
                    if (filters.Length > 0)
                    {
                        this.m_checkBoxFilter.Tag = this.GetType();
                        this.m_checkBoxFilter.Checked = bUsedFilter;
                        this.m_checkBoxFilter.Text = this.FilterName;
                        if (this.FilterAdded != null)
                        {
                            this.FilterAdded(this, new FilterNotificationEventArgs(this.m_checkBoxFilter));
                        }
                        CheckListViewStatus(bUsedFilter);
                    }

                    foreach (CFilter filter in filters)
                    {
                        ListViewItem listViewItem = new ListViewItem();
                        listViewItem.Checked = false;
                        if (aFilterOptions.Contains(filter.Id))
                        {
                            listViewItem.Checked = true;
                            CheckListViewStatus(listViewItem.Checked);
                        }
                        listViewItem.Text = filter.Name;
                        listViewItem.SubItems.Add(filter.Number.ToString(CultureInfo.InvariantCulture));
                        listViewItem.Tag = filter;
                        this.m_lstvFilter.Items.Add(listViewItem);
                    }
                }
            }
            catch (Exception exception)
            {
                GlobalizedMessageBox.Show(this,exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static ArrayList GetFilterSettingsArrayList(FilterSettings filterSettings)
        {
            ArrayList arrayList = new ArrayList();
            try
            {
                if (filterSettings != null)
                {
                    string strValue = filterSettings.Value;
                    if (String.IsNullOrEmpty(strValue) == false)
                    {
                        string[] strArray = strValue.Split(new Char[] { ',' });
                        foreach (string str in strArray)
                        {
                            arrayList.Add(int.Parse(str,CultureInfo.InvariantCulture));
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                IWin32Window owner = (IWin32Window)typeof(FilterBase);
                GlobalizedMessageBox.Show(owner, exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return arrayList;
        }

        private FilterSettings GetFilterSettings(BSE.Platten.BO.Environment environment)
        {
            FilterSettings filterSettings = null;
            CTunesBusinessObject tunesBusinessObject = new CTunesBusinessObject(environment.GetConnectionString());
            try
            {
                filterSettings = tunesBusinessObject.GetFilterSettings(this.FilterMode, environment.UserName);
            }
            catch (Exception exception)
            {
                GlobalizedMessageBox.Show(this,exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return filterSettings;
        }
        
        private void CheckListViewStatus(bool bCheckBoxCheckState)
        {
            int iCountCheckedItems = 0;
            try
            {
                iCountCheckedItems = m_lstvFilter.CheckedIndices.Count;
            }
            catch (System.ArgumentException)
            {
                System.Diagnostics.Trace.WriteLine("Error");
            }
            if (iCountCheckedItems > 1)
            {
                foreach (ListViewItem listViewItem in this.m_lstvFilter.Items)
                {
                    if (listViewItem.Checked)
                    {
                        bCheckBoxCheckState = true;
                        break;
                    }
                }
            }
            if (FilterCheckStateChanged != null)
            {
                FilterCheckStateChanged(this, new FilterCheckStateChangeEventArgs(this.m_checkBoxFilter, bCheckBoxCheckState));
            }
        }
        #endregion

    }
}
