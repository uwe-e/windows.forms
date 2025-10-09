using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using BSE.Platten.BO;
using BSE.Platten.Common;

namespace BSE.Platten.Tunes.Filters
{
    public partial class FilterMain : BaseForm
    {
        #region Events

        public event EventHandler<FilterChangedEventArgs> FilterChanged;

        #endregion

        #region FieldsPrivate

        private BSE.Platten.BO.Environment m_environment;

        #endregion

        #region Properties

        public BSE.Platten.BO.Environment Environment
        {
            get { return this.m_environment; }
            set { this.m_environment = value; }
        }

        #endregion

        #region MethodsPublic

        public FilterMain()
        {
            InitializeComponent();
        }

        public FilterMain(BSE.Platten.BO.Environment environment)
            : this()
        {
            this.m_environment = environment;
        }

        public static FilterConfiguration GetFilterConfiguration(BSE.Platten.BO.Environment environment)
        {
            FilterConfiguration filterConfiguration = new FilterConfiguration();
            
            Type typeOfInterface = typeof(IFilterConfiguration);
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetEntryAssembly();
            Type[] types = assembly.GetTypes();
            foreach (Type type in types)
            {
                if (type.IsClass && typeOfInterface.IsAssignableFrom(type))
                {
                    FilterBase filterBase = Activator.CreateInstance(type) as FilterBase;
                    if (filterBase != null)
                    {
                        FilterConfiguration tmpFilterConfiguration = filterBase.GetFilterConfiguration(environment);
                        if (tmpFilterConfiguration.IsUsed == true)
                        {
                            filterConfiguration = tmpFilterConfiguration;
                        }
                    }
                }
            }

            return filterConfiguration;
        }
        /// <summary>
        /// Gets a <see cref="TrackCollection"/> with randomized tracks for the current filter settings 
        /// </summary>
        /// <param name="environment"></param>
        /// <param name="filterSettings"></param>
        /// <returns>A <see cref="TrackCollection"/> with randomized tracks.</returns>
        public static TrackCollection GetRandomTracksByFilterSettings(BSE.Platten.BO.Environment environment, FilterSettings filterSettings)
        {
            TrackCollection trackCollection = GetTracksByFilterSettings(environment, filterSettings);
            if (trackCollection != null)
            {
                trackCollection = TrackCollection.GetRandomCollection(trackCollection);
            }
            return trackCollection;
        }

        public static TrackCollection GetTracksByFilterSettings(BSE.Platten.BO.Environment environment, FilterSettings filterSettings)
        {
            TrackCollection trackCollection = null;
            if (environment != null)
            {
                try
                {
                    CTunesBusinessObject tunesBusinessObject = new CTunesBusinessObject(environment.GetConnectionString());
                    trackCollection = tunesBusinessObject.GetTracksByFilterSettings(filterSettings);
                    if (trackCollection.Count > 0)
                    {
                        string strAudioHomeDirectory = Album.GetAudioHomeDirectory(environment);
                        System.Collections.IEnumerator enumerator = trackCollection.GetEnumerator();
                        while (enumerator.MoveNext())
                        {
                            CTrack track = enumerator.Current as CTrack;
                            if (track != null)
                            {
                                track.FileFullName = strAudioHomeDirectory + track.FileName;
                            }
                        }
                    }
                }
                catch (BSE.Configuration.ConfigurationValueNotFoundException)
                {
                    throw;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return trackCollection;
        }

        #endregion

        #region MethodsProtected
        #endregion

        #region MethodsPrivate
        
        private void FilterMainLoad(object sender, EventArgs e)
        {
            if (this.m_environment != null)
            {
                TabControl.TabPageCollection tabPageCollection = this.m_tabFilters.TabPages;
                foreach (TabPage tabPage in tabPageCollection)
                {
                    Type typeOfInterface = typeof(IFilterConfiguration);
                    if (typeOfInterface.IsAssignableFrom(tabPage.Controls[0].GetType()))
                    {
                        FilterBase filterBase = tabPage.Controls[0] as FilterBase;
                        if (filterBase != null)
                        {
                            filterBase.SetFilterValues(this.m_environment);
                        }
                    }
                }
            }
        }
        
        private void FilterCheckStateChanged(object sender, FilterCheckStateChangeEventArgs e)
        {
            foreach (Control control in this.m_pnlUsingFilters.Controls)
            {
                CheckBox checkBox = control as CheckBox;
                if (checkBox != null)
                {
                    if (checkBox.Tag == e.CheckBox.Tag)
                    {
                        checkBox.Enabled = e.CheckState;
                        if (!checkBox.Enabled)
                        {
                            checkBox.Checked = checkBox.Enabled;
                        }
                    }
                }
            }
        }
        
        private void FilterAdded(object sender, FilterNotificationEventArgs e)
        {
            bool bCheckBoxAvailable = false;
            int iCheckBoxTop = 10;
            foreach (Control control in this.m_pnlUsingFilters.Controls)
            {
                CheckBox checkBox = control as CheckBox;
                if (checkBox != null)
                {
                    iCheckBoxTop = checkBox.Top + checkBox.Height;
                    if (checkBox.Tag == e.CheckBox.Tag)
                    {
                        bCheckBoxAvailable = false;
                    }
                }
            }
            if (bCheckBoxAvailable == false)
            {
                e.CheckBox.Left = 10;
                e.CheckBox.Top = iCheckBoxTop;
                e.CheckBox.Width = this.m_pnlUsingFilters.Width - e.CheckBox.Left;
                e.CheckBox.CheckedChanged += new System.EventHandler(this.UsingFiltersCheckedChanged);
                this.m_pnlUsingFilters.Controls.Add(e.CheckBox);
            }
        }
        
        private void UsingFiltersCheckedChanged(object sender, System.EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            if (checkBox != null)
            {
                if (checkBox.Checked)
                {
                    foreach (Control control in this.m_pnlUsingFilters.Controls)
                    {
                        CheckBox tmpCheckBox = control as CheckBox;
                        if (tmpCheckBox != null)
                        {
                            if (tmpCheckBox.Tag != checkBox.Tag)
                            {
                                tmpCheckBox.Checked = false;
                            }
                        }
                    }
                }
            }
        }
        
        private void BtnOKClick(object sender, EventArgs e)
        {
            foreach (Control control in this.m_pnlUsingFilters.Controls)
            {
                CheckBox checkBox = control as CheckBox;
                if (checkBox != null)
                {
                    TabControl.TabPageCollection tabPageCollection = this.m_tabFilters.TabPages;
                    foreach (TabPage tabPage in tabPageCollection)
                    {
                        if (tabPage.Controls[0].GetType() == checkBox.Tag)
                        {
                            FilterBase filterBase = tabPage.Controls[0] as FilterBase;
                            if (filterBase != null)
                            {
                                filterBase.SafeFilterConfiguration(this.m_environment, checkBox.Checked);
                            }
                        }
                    }
                }
            }
            if (FilterChanged != null)
            {
                FilterChanged(this,new FilterChangedEventArgs());
            }
        }

        #endregion
    }
}