using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using BSE.CoverFlow.WPFLib.Input;
using BSE.Platten.BO;
using BSE.CoverFlow.WPFLib.Properties;
using System.Globalization;

namespace BSE.CoverFlow.WPFLib.ViewModel
{
    public class DeletePlaylistDialogViewModel : BaseDialogViewModel
    {
        #region Events
        public event EventHandler<PlaylistChangedEventArgs> PlayListDeleted;
        #endregion

        #region Constants
        #endregion

        #region FieldsPrivate
        private string m_strDeletePlaylistMessage;
        private Playlist m_currentPlaylist;
        #endregion

        #region Properties
        public string DeletePlaylistConfirmation
        {
            get
            {
                return this.m_strDeletePlaylistMessage;
            }
            set
            {
                this.m_strDeletePlaylistMessage = value;
                this.OnPropertyChanged("DeletePlaylistConfirmation");
            }
            //get
            //{
            //    return string.Format(CultureInfo.InvariantCulture,
            //        Resources.IDS_PlayListDeleteWarningConfirmation, this.CurrentPlaylist != null ? this.CurrentPlaylist.Name : string.Empty);
            //}
        }
        
        public Playlist CurrentPlaylist
        {
            get
            {
                return this.m_currentPlaylist;
            }
            set
            {
                this.m_currentPlaylist = value;
                this.DeletePlaylistConfirmation = string.Format(CultureInfo.InvariantCulture,
                    Resources.IDS_PlayListDeleteWarningConfirmation, this.CurrentPlaylist != null ? this.CurrentPlaylist.Name : string.Empty);
                this.OnPropertyChanged("CurrentPlaylist");
            }
        }
        #endregion

        #region MethodsPublic
        public DeletePlaylistDialogViewModel(BSE.Platten.BO.Environment environment)
            : base(environment)
        {

        }
        public override bool SaveData()
        {
            bool bHasSaved = false;
            if (this.Environment != null)
            {
                CTunesBusinessObject tunesBusinessObject = new CTunesBusinessObject(this.Environment.GetConnectionString());
                try
                {
                    tunesBusinessObject.DeletePlayList(this.CurrentPlaylist.Id);
                    this.CurrentPlaylist = null;
                    if (this.PlayListDeleted != null)
                    {
                        this.PlayListDeleted(this, new PlaylistChangedEventArgs(this.CurrentPlaylist));
                    }
                    bHasSaved = true;

                }
                catch (Exception exception)
                {
                    this.DeletePlaylistConfirmation = string.Format(
                        CultureInfo.InvariantCulture,
                        Resources.IDS_PlayListDeleteException, exception.Message);
                }
            }
            return bHasSaved;
        }
        #endregion
    }
}
