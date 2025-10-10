using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BSE.Platten.BO;
using BSE.Platten.Common;
using BSE.Configuration;
using BSE.Platten.Audio;
using System.Globalization;
using BSE.Windows.Forms;
using BSE.Platten.Tunes.Properties;
using System.IO;
using System.Windows.Interop;
using BSE.CoverFlow.WPFLib.ImageFlowPanel;

namespace BSE.Platten.Tunes
{
    public partial class Tunes : BaseForm, IConfigurationSettings
    {
        #region Constants

        private const string m_strSettingsFileNameSettingsPart = ".Settings";

        #endregion


        #region FieldsPrivate

        private TrackCollection m_trackCollectionByFilterSettings;
        private BSE.Platten.BO.Environment m_environment;
        private string m_strAudioHomeDirectory;
        private string m_strConnection;
        #endregion

        #region Properties

        #region IConfigurationSettings

        public string ConfigurationFolder
        {
            get { return this.GetType().Namespace; }
        }

        public string ConfigurationFileName
        {
            get { return this.GetType().Namespace; }
        }

        public string SettingsFileName
        {
            get { return this.GetType().Namespace + m_strSettingsFileNameSettingsPart; }
        }
        #endregion

        internal string AudioHomeDirectory
        {
            get { return this.m_strAudioHomeDirectory; }
            set { this.m_strAudioHomeDirectory = value; }
        }

        internal string ConnectionString
        {
            get { return this.m_strConnection; }
            set { this.m_strConnection = value; }
        }

        internal BSE.Platten.BO.Environment Environment
        {
            get { return this.m_environment; }
            set { this.m_environment = value; }
        }

        internal TrackCollection TrackCollectionByFilterSettings
        {
            get { return this.m_trackCollectionByFilterSettings; }
            set { this.m_trackCollectionByFilterSettings = value; }
        }

        #endregion

        #region MethodsPublic

        public Tunes()
            : base()
        {
            InitializeComponent();
            InitializeViewModels();

            this.BackColor = Color.FromArgb(17, 9, 15);
            //this.BorderColor = Color.FromArgb(184, 182, 183);

            this.m_configuration.ApplicationSubDirectory = this.ConfigurationFolder;
            this.m_configuration.ConfigFileName = this.ConfigurationFileName;

            this.m_environment = new BSE.Platten.BO.Environment(this.m_configuration);

            this.m_settings.ApplicationSubDirectory = this.ConfigurationFolder;
            this.m_settings.ConfigFileName = this.SettingsFileName;
        }

        #endregion

        #region MethodsPrivate

        private void CTunes_Load(object sender, EventArgs e)
        {
            BaseFormSettingsData settingsData = LoadSettings();
            if (settingsData != null && settingsData.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            try
            {
                ConfigureApplication();
            }
            catch (BSE.Configuration.ConfigurationValueNotFoundException configurationValueNotFoundException)
            {
                if (CSplashScreen.SplashScreen != null)
                {
                    CSplashScreen.CloseSplashScreen(this);
                }
                DialogResult dialogResult = GlobalizedMessageBox.Show(this, configurationValueNotFoundException.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                if (dialogResult == DialogResult.OK)
                {
                    OpenOptions();
                }
            }
            catch (Exception exception)
            {
                if (CSplashScreen.SplashScreen != null)
                {
                    CSplashScreen.CloseSplashScreen(this);
                }
                GlobalizedMessageBox.Show(this, exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (CSplashScreen.SplashScreen != null)
                {
                    CSplashScreen.CloseSplashScreen(this);
                }
            }
        }

        private void CTunes_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
            if (PlayerManager.HasPlayerStarted == true)
            {
                PlayerManager.Close();
            }
            Application.Exit();
        }

        private void OptionenClick(object sender, EventArgs e)
        {
            OpenOptions();
        }

        private void OpenOptions()
        {
            Application.DoEvents();
            try
            {
                using (Options options = new Options(this.m_configuration))
                {
                    options.ConfigurationChanged += new EventHandler(this.OptionsConfigurationChanged);
                    options.ShowDialog(this);
                }
            }
            catch (Exception exception)
            {
                GlobalizedMessageBox.Show(this, exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OptionsConfigurationChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                bool bHasChanged = false;
                //If the AudioHome Directory has changed
                string strAudioHomeDirectory = this.m_environment.GetAudioHomeDirectory();
                if (string.Compare(strAudioHomeDirectory,this.AudioHomeDirectory,  StringComparison.OrdinalIgnoreCase) != 0)
                {
                    this.AudioHomeDirectory = strAudioHomeDirectory;
                    bHasChanged = true;
                }

                //If the ConnectionString has changed
                string strConnection = this.m_environment.GetConnectionString();
                if (string.Compare(strConnection, this.ConnectionString, StringComparison.OrdinalIgnoreCase) != 0)
                {
                    this.ConnectionString = strConnection;
                    bHasChanged = true;
                }
                if (bHasChanged == true)
                {
                    ConfigureApplication();
                }
            }
            catch (BSE.Configuration.ConfigurationValueNotFoundException configurationValueNotFoundException)
            {
                if (CSplashScreen.SplashScreen != null)
                {
                    CSplashScreen.CloseSplashScreen(this);
                }
                DialogResult dialogResult = GlobalizedMessageBox.Show(this, configurationValueNotFoundException.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                if (dialogResult == DialogResult.OK)
                {
                    OpenOptions();
                }
            }
            catch (Exception exception)
            {
                if (CSplashScreen.SplashScreen != null)
                {
                    CSplashScreen.CloseSplashScreen(this);
                }
                GlobalizedMessageBox.Show(this, exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (CSplashScreen.SplashScreen != null)
                {
                    CSplashScreen.CloseSplashScreen(this);
                }
                Cursor.Current = Cursors.Default;
            }
        }
        private void ConfigureApplication()
        {
            int iSplashStep = 0;
            int iSplashStepsTotal = 8;
            CSplashScreen.ShowSplashScreen();
            CSplashScreen.SetStatusMessage(Resources.IDS_TunesLoadMessageLoadSystemsettings, iSplashStep++, iSplashStepsTotal);
            DatabaseHostController.Initialize(this.m_environment);
            //Starte Player
            CSplashScreen.SetStatusMessage(Resources.IDS_TunesLoadMessageStartPlayer, iSplashStep++, iSplashStepsTotal);
            PlayerManager.LoadPlayer();
            CSplashScreen.SetStatusMessage(Resources.IDS_TunesLoadMessageCheckDatabaseConnection, iSplashStep++, iSplashStepsTotal);
            this.ConnectionString = this.m_environment.GetConnectionString();
            CSplashScreen.SetStatusMessage(Resources.IDS_TunesLoadMessageCheckAudiodirectory, iSplashStep++, iSplashStepsTotal);
            this.AudioHomeDirectory = this.m_environment.GetAudioHomeDirectory();

            CSplashScreen.SetStatusMessage(Resources.IDS_TunesLoadMessageCheckDatabaseHost, iSplashStep++, iSplashStepsTotal);
            if (DatabaseHostController.IsHostAvailable == true)
            {
                this.m_desktopViewModel = new CoverFlow.WPFLib.ViewModel.DesktopViewModel(this.m_environment);
                this.desktop1.DataContext = this.m_desktopViewModel;

                CTunesBusinessObject tunesBusinessObject = new CTunesBusinessObject(this.ConnectionString);

                //lädt Alben und Genres in den Tree
                CSplashScreen.SetStatusMessage(Resources.IDS_TunesLoadMessageLoadAlbums, iSplashStep++, iSplashStepsTotal);
                CInterpretData[] interpretsAndAlbums = tunesBusinessObject.GetInterpretsAndAlbums();
                this.m_desktopViewModel.InterpretData = interpretsAndAlbums;

                //löscht alte Einträge aus der Benutzerhistory
                CSplashScreen.SetStatusMessage(Resources.IDS_TunesLoadMessageDeleteHistory, iSplashStep++, iSplashStepsTotal);
                tunesBusinessObject.DeleteTracksFromHistory(this.m_environment.UserName);

                //Filter
                CSplashScreen.SetStatusMessage(Resources.IDS_TunesLoadMessageLoadFilters, iSplashStep++, iSplashStepsTotal);
                Filters.FilterConfiguration filterConfiguration = BSE.Platten.Tunes.Filters.FilterMain.GetFilterConfiguration(this.m_environment);
                this.m_captionViewModel.FilterName = filterConfiguration.FilterName;
                this.TrackCollectionByFilterSettings = BSE.Platten.Tunes.Filters.FilterMain.GetRandomTracksByFilterSettings(this.m_environment, (FilterSettings)filterConfiguration);
                if (this.TrackCollectionByFilterSettings.Count > 0)
                {
                    PlayerManager.InitializeTracks(this.TrackCollectionByFilterSettings);
                    this.m_desktopViewModel.SetRandomAlbum();
                }
            }
        }

        private void OnExecuteStatistics(object sender, EventArgs e)
        {
            using (Statistics statistik = new Statistics
            {
                ConnectionString = this.ConnectionString
            })
            {
                statistik.ShowDialog();
            }
        }

        private void OnExecuteAdmin(object sender, EventArgs e)
        {
            if (this.m_desktopViewModel != null)
            {
                try
                {
                    using (Admin.Admin admin = new Admin.Admin(this.m_configuration,
                        this.m_desktopViewModel.CurrentAlbum))
                    {
                        admin.ShowInTaskbar = false;
                        admin.ShowDialog(this);
                    }
                }
                catch (Exception exception)
                {
                    GlobalizedMessageBox.Show(this, exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FilterPropertiesClick(object sender, EventArgs e)
        {
            Application.DoEvents();
            try
            {
                using (BSE.Platten.Tunes.Filters.FilterMain filter
                    = new BSE.Platten.Tunes.Filters.FilterMain(this.m_environment))
                {
                    filter.FilterChanged -= new EventHandler<BSE.Platten.Tunes.Filters.FilterChangedEventArgs>(OnFilterChanged);
                    filter.FilterChanged += new EventHandler<BSE.Platten.Tunes.Filters.FilterChangedEventArgs>(OnFilterChanged);
                    filter.ShowInTaskbar = false;
                    filter.ShowDialog();
                }
            }
            catch (Exception exception)
            {
                GlobalizedMessageBox.Show(this, exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnFilterChanged(object sender, Filters.FilterChangedEventArgs e)
        {
            try
            {
                BSE.Platten.Tunes.Filters.FilterConfiguration filterConfiguration
                    = BSE.Platten.Tunes.Filters.FilterMain.GetFilterConfiguration(this.m_environment);

                this.m_captionViewModel.FilterName = filterConfiguration.FilterName;

                this.TrackCollectionByFilterSettings = BSE.Platten.Tunes.Filters.FilterMain.GetRandomTracksByFilterSettings(this.m_environment, (FilterSettings)filterConfiguration);
                if (this.TrackCollectionByFilterSettings.Count > 0)
                {
                    PlayerManager.SetRandomTracks(this.TrackCollectionByFilterSettings);
                }
            }
            catch (Exception exception)
            {
                GlobalizedMessageBox.Show(this, exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private BaseFormSettingsData LoadSettings()
        {
            BaseFormSettingsData tunesSettingsData = new BaseFormSettingsData();
            return (BaseFormSettingsData)tunesSettingsData.LoadSettings(this, this.m_settings, tunesSettingsData);
        }

        private void SaveSettings()
        {
            BaseFormSettingsData tunesSettingsData = new BaseFormSettingsData();
            tunesSettingsData.SaveSettings(this, this.m_settings, tunesSettingsData);
        }
        #endregion
    }
}