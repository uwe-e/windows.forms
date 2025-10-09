using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BSE.Platten.BO;
using BSE.CoverFlow.WPFLib.Controls;
using BSE.CoverFlow.WPFLib.Properties;
using BSE.CoverFlow.WPFLib.Input;

namespace BSE.CoverFlow.WPFLib.ViewModel
{
    public class HistoryViewModel : EnvironmentViewModel
    {
        #region FieldsPrivate
        private List<Album> m_albums;
        private Album m_selectedAlbum;
        private RelayCommand m_selectionChangedCommand;
        #endregion

        #region Properties
        public System.Windows.Input.ICommand SelectionChangedCommand
        {
            get
            {
                if (this.m_selectionChangedCommand == null)
                {
                    this.m_selectionChangedCommand = new RelayCommand(
                        this.SelectionChanged);

                }
                return this.m_selectionChangedCommand;
            }
        }
        public List<Album> Albums
        {
            get
            {
                return this.m_albums;
            }
            set
            {
                this.m_albums = value;
                this.OnPropertyChanged("Albums");
            }
        }
        public Album SelectedAlbum
        {
            get
            {
                return this.m_selectedAlbum;
            }
            set
            {
                this.m_selectedAlbum = value;
                this.OnPropertyChanged("SelectedAlbum");
            }
        }
        #endregion

        #region MethodsPublic
        public HistoryViewModel()
        {
        }
        public HistoryViewModel(BSE.Platten.BO.Environment environment)
            : base(environment)
        {
            Mediator.Register(this);
            this.LoadHistory();
        }

        [BSE.CoverFlow.WPFLib.Mediator.MediatorMessageSink(MediatorMessages.MessageHistoryIsChanging, ParameterType = typeof(HistoryData))]
        public void UpdateHistory(HistoryData historyData)
        {
            if (historyData != null)
            {
                this.InvokeAsynchronously(() =>
                {
                    CTunesBusinessObject tunesBusinessObject = new CTunesBusinessObject(this.Environment.GetConnectionString());
                    try
                    {
                        tunesBusinessObject.UpdateHistory(historyData);
                    }
                    catch (Exception exception)
                    {
                        this.DialogService.ShowMessageBox(this, exception.Message, Resources.IDS_HistoryExceptionCaption, DialogButton.Ok);
                    }
                });
            }
        }
        #endregion

        #region MethodsPrivate
        private void LoadHistory()
        {
            this.Invoke(() =>
            {
                CTunesBusinessObject tunesBusinessObject = new CTunesBusinessObject(this.Environment.GetConnectionString());
                try
                {
                    IList<Album> historyAlbums = tunesBusinessObject.GetHistoryAlbums(this.Environment.UserName);
                    if (historyAlbums != null)
                    {
                        List<Album> albums = new List<Album>(historyAlbums);
                        this.SelectedAlbum = albums.FirstOrDefault();
                        albums.Remove(this.SelectedAlbum);
                        this.Albums = albums;
                    }
                }
                catch (Exception exception)
                {
                    this.DialogService.ShowMessageBox(this, exception.Message, Resources.IDS_HistoryExceptionCaption, DialogButton.Ok);
                }
            });
        }
        private void SelectionChanged(object parameter)
        {
            Album selectedAlbum = parameter as Album;
            if (selectedAlbum != null)
            {
                this.InvokeAsynchronously(() =>
                {
                    selectedAlbum = this.GetAlbumById(selectedAlbum.AlbumId);
                    Mediator.NotifyColleagues<Album>(MediatorMessages.MessageCurrentAlbumChanged, selectedAlbum);
                });
            }
        }
        #endregion
    }
}
