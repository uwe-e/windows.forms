using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BSE.CoverFlow.WPFLib.Properties;
using BSE.CoverFlow.WPFLib.Input;
using System.Windows.Input;

namespace BSE.CoverFlow.WPFLib.ViewModel
{
    public class CaptionMenuViewModel : ViewModelBase
    {
        #region Events
        public event EventHandler<EventArgs> ExecuteAdministration;
        public event EventHandler<EventArgs> ExecuteFilters;
        public event EventHandler<EventArgs> ExecuteSettings;
        public event EventHandler<EventArgs> ExecuteStatistics;
        #endregion

        #region Constants
        #endregion

        #region FieldsPrivate
        private RelayCommand m_openAdministrationCommand;
        private RelayCommand m_openFiltersCommand;
        private RelayCommand m_openSettingsCommand;
        private RelayCommand m_openStatisticsCommand;
        private string m_strFilterName;
        #endregion

        #region Properties
        public string MenuHeaderFilters
        {
            get
            {
                return Resources.IDS_WindowCaptionHeaderFilters;
            }
        }
        public string MenuHeaderExtras
        {
            get
            {
                return Resources.IDS_WindowCaptionHeaderExtras;
            }
        }
        public string MenuItemFiltersSettings
        {
            get
            {
                return Resources.IDS_WindowCaptionFiltersMenuSettings;
            }
        }
        public string FilterName
        {
            get
            {
                return this.m_strFilterName;
            }
            set
            {
                this.m_strFilterName = value;
                this.OnPropertyChanged("FilterName");
            }
        }
        public string MenuItemFiltersStatistics
        {
            get
            {
                return Resources.IDS_WindowCaptionFiltersMenuStatistics;
            }
        }
        public ICommand OpenAdministrationCommand
        {
            get
            {
                if (this.m_openAdministrationCommand == null)
                {
                    this.m_openAdministrationCommand = new RelayCommand(
                        this.OpenAdministration);
                }
                return this.m_openAdministrationCommand;
            }
        }
        public ICommand OpenFiltersCommand
        {
            get
            {
                if (this.m_openFiltersCommand == null)
                {
                    this.m_openFiltersCommand = new RelayCommand(
                        this.OpenFilters);
                }
                return this.m_openFiltersCommand;
            }
        }
        public ICommand OpenSettingsCommand
        {
            get
            {
                if (this.m_openSettingsCommand == null)
                {
                    this.m_openSettingsCommand = new RelayCommand(
                        this.OpenSettings);
                }
                return this.m_openSettingsCommand;
            }
        }
        public ICommand OpenStatisticsCommand
        {
            get
            {
                if (this.m_openStatisticsCommand == null)
                {
                    this.m_openStatisticsCommand = new RelayCommand(
                        this.OpenStatistics);
                }
                return this.m_openStatisticsCommand;
            }
        }
        #endregion

        #region MethodsPublic
        #endregion

        #region MethodsProtected
        #endregion

        #region MethodsPrivate
        private void OpenAdministration(object parameter)
        {
            if (this.ExecuteAdministration != null)
            {
                this.ExecuteAdministration(this, EventArgs.Empty);
            }
        }
        private void OpenFilters(object parameter)
        {
            if (this.ExecuteFilters != null)
            {
                this.ExecuteFilters(this, EventArgs.Empty);
            }
        }
        private void OpenSettings(object parameter)
        {
            if (this.ExecuteSettings != null)
            {
                this.ExecuteSettings(this, EventArgs.Empty);
            }
        }
        private void OpenStatistics(object parameter)
        {
            if (this.ExecuteStatistics != null)
            {
                this.ExecuteStatistics(this, EventArgs.Empty);
            }
        }
        #endregion

    }
}
