using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using BSE.Platten.Common;
using BSE.Platten.BO;
using BSE.Platten.Audio.Properties;

namespace BSE.Platten.Audio
{
    public partial class CPlayerConfigurationControl : BaseConfigurationControl
    {

        #region FieldsPrivate

        private BSE.Configuration.Configuration m_configuration;

        #endregion

        #region Properties

        #endregion

        #region MethodsPublic

        public CPlayerConfigurationControl()
        {
            InitializeComponent();
        }

        public override void LoadConfigurationValues(BSE.Configuration.Configuration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException("configuration",
                    string.Format(System.Globalization.CultureInfo.InvariantCulture,
                    Properties.Resources.IDS_ArgumentNullException,
                    "configuration"));
            }
            this.m_configuration = configuration;
            UsedPlayerConfigurationData configurationObject =
                GetConfiguration(configuration) as UsedPlayerConfigurationData;

            if (configurationObject != null)
            {
                GetAudioPlayers(configurationObject);
            }
        }

        public override void SaveConfigurationValues(BSE.Configuration.Configuration configuration)
        {
            this.m_configuration = configuration;
            UsedPlayerConfigurationData configurationObject = new UsedPlayerConfigurationData();
            configurationObject.UsedPlayer = (UsedPlayer)Enum.Parse(typeof(UsedPlayer), this.m_cboPlayers.SelectedValue.ToString());

            configuration.SetValue(
                BaseConfigurationControl.OptionsConfiguration,
                typeof(UsedPlayerConfigurationData).Name,
                configurationObject);
        }

        public static IConfigurationData GetConfiguration(BSE.Configuration.Configuration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException("configuration",
                    string.Format(System.Globalization.CultureInfo.InvariantCulture,
                    Properties.Resources.IDS_ArgumentNullException,
                    "configuration"));
            }
            return configuration.GetValue(
               BSE.Platten.Common.BaseConfigurationControl.OptionsConfiguration,
               typeof(UsedPlayerConfigurationData).Name,
               new UsedPlayerConfigurationData()) as UsedPlayerConfigurationData;
        }

        public static IConfigurationData PlayerOptionsConfiguration(BSE.Configuration.Configuration configuration)
        {
            IConfigurationData configurationObject = null;
            
            UsedPlayerConfigurationData usedPlayerConfigurationObject = configuration.GetValue(
                BaseConfigurationControl.OptionsConfiguration,
                typeof(UsedPlayerConfigurationData).Name,
                new UsedPlayerConfigurationData()) as UsedPlayerConfigurationData;

            if (usedPlayerConfigurationObject != null)
            {
                UsedPlayer eUsedPlayer = usedPlayerConfigurationObject.UsedPlayer;
                switch (eUsedPlayer)
                {
                    case UsedPlayer.MediaPlayer:
                        break;
                    case UsedPlayer.Winamp:
                        configurationObject = configuration.GetValue(
                            BaseConfigurationControl.OptionsConfiguration,
                            typeof(WinampConfigurationData).Name,
                            new WinampConfigurationData()) as WinampConfigurationData;
                        break;
                }
            }
            return configurationObject;
        }

        #endregion

        #region MethodsPrivate

        private void GetAudioPlayers(UsedPlayerConfigurationData configurationObject)
        {
            UsedPlayer eUsedPlayer = configurationObject.UsedPlayer;

            Player[] audioPlayers = new Player[3];

            Player noPlayer = new MediaPlayer();
            noPlayer.UsedAudioPlayer = UsedPlayer.None;
            noPlayer.Description = Resources.CNoPlayerConfigurationControlDescription;
            audioPlayers[0] = noPlayer;
            
            Player mediaPlayer = new MediaPlayer();
            mediaPlayer.UsedAudioPlayer = UsedPlayer.MediaPlayer;
            mediaPlayer.Description = mediaPlayer.Name;
            audioPlayers[1] = mediaPlayer;

            Player winamp = new Winamp();
            winamp.UsedAudioPlayer = UsedPlayer.Winamp;
            winamp.Description = winamp.Name;
            audioPlayers[2] = winamp;

            this.m_cboPlayers.DataSource = audioPlayers;
            this.m_cboPlayers.ValueMember = "UsedAudioPlayer";
            this.m_cboPlayers.DisplayMember = "Description";

            this.m_cboPlayers.SelectedValue = eUsedPlayer;
        }

        private void m_cboPlayers_SelectedValueChanged(object sender, EventArgs e)
        {
            this.m_btnConfigPlayer.Enabled = false;
            if (this.m_cboPlayers.SelectedValue != null)
            {
                Player audioPlayer = this.m_cboPlayers.SelectedItem as Player;
                if (audioPlayer != null)
                {
                    BaseConfigurationControl configurationControl = null;
                    this.m_grpPlayerProperties.Controls.Clear();
                    switch (audioPlayer.UsedAudioPlayer)
                    {
                        case UsedPlayer.None:
                            configurationControl = new CNoPlayerConfigurationControl();
                            break;
                        case UsedPlayer.MediaPlayer:
                            configurationControl = new CMediaPlayerConfigurationControl();
                            break;
                        case UsedPlayer.Winamp:
                            this.m_btnConfigPlayer.Enabled = true;
                            configurationControl = new CWinampConfigurationControl();
                            break;
                    }
                    if (configurationControl != null)
                    {
                        configurationControl.Dock = DockStyle.Fill;
                        configurationControl.LoadConfigurationValues(this.m_configuration);
                        
                        this.m_grpPlayerProperties.Text = configurationControl.Text;
                        this.m_grpPlayerProperties.Controls.Add(configurationControl);
                    }
                }
            }
        }

        private void m_btnConfigPlayer_Click(object sender, EventArgs e)
        {
            if (this.m_configuration != null)
            {
                if (this.m_cboPlayers.SelectedValue != null)
                {
                    Player audioPlayer = this.m_cboPlayers.SelectedItem as Player;
                    if (audioPlayer != null)
                    {
                        BaseConfigurationControl configurationControl = null;
                        switch (audioPlayer.UsedAudioPlayer)
                        {
                            case UsedPlayer.MediaPlayer:
                                break;
                            case UsedPlayer.Winamp:
                                this.m_btnConfigPlayer.Enabled = true;
                                configurationControl = new CWinampConfigurationControl();
                                break;
                        }
                        if (configurationControl != null)
                        {
                            CPlayerOptionsDialog dlgPlayerOptions = new CPlayerOptionsDialog(this.m_configuration);
                            dlgPlayerOptions.ConfigChange += new EventHandler(ConfigurationChanged);
                            dlgPlayerOptions.SetConfigurationControl(configurationControl);
                            if (dlgPlayerOptions.ShowDialog() == DialogResult.OK)
                            {
                                BaseConfigurationControl changedConfigurationControl =
                                    dlgPlayerOptions.ChangedConfiguration;
                                if (changedConfigurationControl != null)
                                {
                                    this.m_grpPlayerProperties.Controls.Clear();
                                    this.m_grpPlayerProperties.Controls.Add(changedConfigurationControl);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void ConfigurationChanged(object sender, EventArgs e)
        {
            OnConfigChanging(new EventArgs());
        }

        private void m_cboPlayers_Click(object sender, EventArgs e)
        {
            OnConfigChanging(new EventArgs());
        }
        
        #endregion
        
    }
}
