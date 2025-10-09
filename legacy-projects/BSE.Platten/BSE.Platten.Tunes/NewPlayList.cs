using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using BSE.Platten.BO;
using BSE.Platten.Common;
using BSE.Platten.Tunes.Properties;
using System.Globalization;

namespace BSE.Platten.Tunes
{
    public partial class NewPlayList : BSE.Platten.Common.BaseDialog
    {
        #region EventsPublic

        public event EventHandler<PlayListEventArgs> PlayListInserted;

        #endregion

        #region FieldsPrivate

        private BSE.Platten.BO.Environment m_environment;

        #endregion

        #region MethodsPublic
        public NewPlayList()
        {
            InitializeComponent();
        }
        public NewPlayList(BSE.Platten.BO.Environment environment) : this()
        {
            this.m_environment = environment;
        }

        #endregion

        #region MethodsProtected

        protected override bool SaveSettings()
        {
            if (string.IsNullOrEmpty(this.m_txtName.Text) == true)
            {
                GlobalizedMessageBox.Show(this,Resources.IDS_NoPlayListNameException, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else
            {
                Playlist playList = new Playlist();
                playList.Guid = System.Guid.NewGuid();
                playList.Name = this.m_txtName.Text;
                playList.User = this.m_environment.UserName;
                CTunesBusinessObject tunesBusinessObject = new CTunesBusinessObject(this.m_environment.GetConnectionString());
                try
                {
                    Playlist newPlayList = tunesBusinessObject.InsertPlaylist(playList);
                    if (PlayListInserted != null)
                    {
                        PlayListInserted(this, new PlayListEventArgs(newPlayList));
                    }
                    return true;
                }
                catch (PlaylistAlreadyExistsException playlistAlreadyExistsException)
                {
                    string strExceptionMessage = string.Format(
                        CultureInfo.CurrentUICulture,
                        Resources.IDS_PlayListAlreadyExistsExceptionMessage,
                        playlistAlreadyExistsException.PlaylistName);
                    GlobalizedMessageBox.Show(this, strExceptionMessage, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                catch (Exception exception)
                {
                    GlobalizedMessageBox.Show(this, exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        #endregion

        #region MethodsPrivate
        private void NewPlayListLoad(object sender, EventArgs e)
        {
            this.ActiveControl = this.m_txtName;
            Button acceptButton = this.AcceptButton as Button;
            if (acceptButton != null)
            {
                acceptButton.Enabled = false;
            }
        }

        private void TxtNameTextChanged(object sender, EventArgs e)
        {
            Button acceptButton = this.AcceptButton as Button;
            if (acceptButton != null)
            {
                if (string.IsNullOrEmpty(this.m_txtName.Text) == false)
                {
                    acceptButton.Enabled = true;

                }
                else
                {
                    acceptButton.Enabled = false;
                }
            }
        }

        #endregion
    }
}