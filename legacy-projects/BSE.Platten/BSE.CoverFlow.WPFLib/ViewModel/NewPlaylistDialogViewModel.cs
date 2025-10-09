using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BSE.CoverFlow.WPFLib.Input;
using System.Windows.Input;
using BSE.Platten.BO;
using System.Globalization;
using BSE.CoverFlow.WPFLib.Properties;

namespace BSE.CoverFlow.WPFLib.ViewModel
{
    public class NewPlaylistDialogViewModel : BaseDialogViewModel
    {
        #region Events
        public event EventHandler<PlaylistChangedEventArgs> PlayListAdded;
        #endregion

        #region FieldsPrivate
        private string m_strErrorMessage;
        private string m_strPlaylistName;
        #endregion

        #region Properties
        public string PlaylistName
        {
            get
            {
                return this.m_strPlaylistName;
            }
            set
            {
                this.m_strPlaylistName = value;
                this.OnPropertyChanged("PlaylistName");
            }
        }
        public string ErrorMessage
        {
            get
            {
                return this.m_strErrorMessage;
            }
            set
            {
                this.m_strErrorMessage = value;
                this.OnPropertyChanged("ErrorMessage");
            }
        }
        #endregion

        #region MethodsPublic
        public NewPlaylistDialogViewModel() : base()
        {
            
        }
        public NewPlaylistDialogViewModel(BSE.Platten.BO.Environment environment)
            : base(environment)
        {
        }
        public override bool SaveData()
        {
            bool bSaveData = false;
            if (string.IsNullOrEmpty(this.PlaylistName) == true)
            {
                this.ErrorMessage = Resources.IDS_NewPlaylistDialog_NoPlayListNameException;
                return false;
            }
            Playlist playList = new Playlist();
            playList.Guid = System.Guid.NewGuid();
            playList.Name = this.PlaylistName;
            playList.User = this.Environment.UserName;
            CTunesBusinessObject tunesBusinessObject = new CTunesBusinessObject(this.Environment.GetConnectionString());
            try
            {
                Playlist newPlayList = tunesBusinessObject.InsertPlaylist(playList);
                if (this.PlayListAdded != null)
                {
                    this.PlayListAdded(this, new PlaylistChangedEventArgs(newPlayList));
                }
                bSaveData = true;
            }
            catch (PlaylistAlreadyExistsException playlistAlreadyExistsException)
            {
                this.ErrorMessage = string.Format(
                    CultureInfo.CurrentUICulture,
                    Resources.IDS_NewPlaylistDialog_PlayListAlreadyExistsExceptionMessage,
                    playlistAlreadyExistsException.PlaylistName);
            }
            catch (Exception exception)
            {
                this.ErrorMessage = exception.Message;
            }
            return bSaveData;
        }
        #endregion
    }
}
