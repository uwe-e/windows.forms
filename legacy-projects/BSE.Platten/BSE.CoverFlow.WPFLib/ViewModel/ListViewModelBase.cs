using System;
using System.Collections.Generic;
using System.Linq;
using BSE.Platten.BO.Data.Extensions;
using System.Text;
using GongSolutions.Wpf.DragDrop;
using System.Windows;
using BSE.Platten.BO;
using System.Collections.ObjectModel;

namespace BSE.CoverFlow.WPFLib.ViewModel
{
    public class ListViewModelBase : EnvironmentViewModel, IDropTarget
    {
        #region Events
        public EventHandler<BSE.Platten.BO.AlbumEventArgs> AlbumSelectionChanged;
        #endregion

        #region Constants
        #endregion

        #region FieldsPrivate
        private BSE.CoverFlow.WPFLib.Input.RelayCommand m_removeSelectedItemCommand;
        private BSE.CoverFlow.WPFLib.Input.RelayCommand m_playSelectedTracksCommand;
        private BSE.CoverFlow.WPFLib.Input.RelayCommand m_selectedAlbumCommand;
        private ObservableCollection<CTrack> m_tracks;
        #endregion

        #region Properties
        public System.Windows.Input.ICommand RemoveSelectedItemCommand
        {
            get
            {
                if (this.m_removeSelectedItemCommand == null)
                {
                    this.m_removeSelectedItemCommand = new BSE.CoverFlow.WPFLib.Input.RelayCommand(
                        this.RemoveSelectedItem);
                }
                return this.m_removeSelectedItemCommand;
            }
        }
        public System.Windows.Input.ICommand PlaySelectedTracksCommand
        {
            get
            {
                if (this.m_playSelectedTracksCommand == null)
                {
                    this.m_playSelectedTracksCommand = new BSE.CoverFlow.WPFLib.Input.RelayCommand(
                        this.PlaySelectedTracks);
                }
                return this.m_playSelectedTracksCommand;
            }
        }
        public System.Windows.Input.ICommand SelectedAlbumCommand
        {
            get
            {
                if (this.m_selectedAlbumCommand == null)
                {
                    this.m_selectedAlbumCommand = new BSE.CoverFlow.WPFLib.Input.RelayCommand(
                        this.SelectAlbum);
                }
                return this.m_selectedAlbumCommand;
            }
        }
        public virtual ObservableCollection<CTrack> Tracks
        {
            get
            {
                return this.m_tracks;
            }
            set
            {
                this.m_tracks = value;
                this.OnPropertyChanged("Tracks");
            }
        }
        #endregion

        #region MethodsPublic
        public ListViewModelBase(BSE.Platten.BO.Environment environment) : base(environment)
        {
            this.Tracks = new ObservableCollection<CTrack>();
        }
        void IDropTarget.DragOver(DropInfo dropInfo)
        {
            if (dropInfo.Data is CTrack
                || dropInfo.Data is List<CTrack>
                || dropInfo.Data is AlbumViewModel)
            {
                dropInfo.Effects = DragDropEffects.Move;
                dropInfo.DropTargetAdorner = DropTargetAdorners.Insert;
            }
        }

        void IDropTarget.Drop(DropInfo dropInfo)
        {
            int insertIndex = dropInfo.InsertIndex;
            System.Collections.IList destinationList = GetList(dropInfo.TargetCollection);
            System.Collections.IEnumerable data = ExtractData(dropInfo.Data);
            AlbumViewModel albumViewModel = dropInfo.Data as AlbumViewModel;
            if (this.Environment != null && albumViewModel != null)
            {
                CTunesBusinessObject tunesBusinessObject = new CTunesBusinessObject(this.Environment.GetConnectionString());
                try
                {
                    CTrack[] tracks = tunesBusinessObject.GetAlbumTracksForPlayListByTitelId(albumViewModel.Id);
                    if (tracks != null)
                    {
                        string strAudioHomeDirectory = Album.GetAudioHomeDirectory(this.Environment);
                        tracks.OrderByDescending(item => item.TrackNumber)
                            .ToList()
                            .ForEach(delegate(CTrack trackItem)
                            {
                                trackItem.FileFullName = strAudioHomeDirectory + trackItem.FileName;
                            });
                        data = ExtractData(tracks);
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }

            if (dropInfo.DragInfo.VisualSource == dropInfo.VisualTarget)
            {
                System.Collections.IList sourceList = GetList(dropInfo.DragInfo.SourceCollection);

                foreach (object o in data)
                {
                    int index = sourceList.IndexOf(o);
                    if (index != -1)
                    {
                        sourceList.RemoveAt(index);

                        if (sourceList == destinationList && index < insertIndex)
                        {
                            --insertIndex;
                        }
                    }
                }

                foreach (object o in data)
                {
                    destinationList.Insert(insertIndex++, o);
                }
            }
            else
            {
                foreach (object o in data)
                {
                    object obj = o;
                    ICloneable b = obj as ICloneable;
                    if (b != null)
                    {
                        obj = b.Clone();
                    }
                    destinationList.Insert(insertIndex++, obj);
                }
            }
        }
        #endregion

        #region MethodsProtected
        protected static System.Collections.IList GetList(System.Collections.IEnumerable enumerable)
        {
            if (enumerable is System.ComponentModel.ICollectionView)
            {
                return ((System.ComponentModel.ICollectionView)enumerable).SourceCollection as System.Collections.IList;
            }
            else
            {
                return enumerable as System.Collections.IList;
            }
        }
        protected static System.Collections.IEnumerable ExtractData(object data)
        {
            if (data is System.Collections.IEnumerable && !(data is string))
            {
                return (System.Collections.IEnumerable)data;
            }
            else
            {
                return Enumerable.Repeat(data, 1);
            }
        }
        #endregion

        #region MethodsPrivate
        private void RemoveSelectedItem(object parameter)
        {
            if (parameter != null && this.Tracks != null)
            {
                System.Collections.IEnumerable data = ExtractData(parameter);
                List<int> indexes = new List<int>();

                System.Collections.IList sourceList = GetList(this.Tracks);
                foreach (object o in data)
                {
                    int index = sourceList.IndexOf(o);
                    if (index != -1)
                    {
                        indexes.Add(index);
                    }
                }
                indexes.Sort();
                indexes.Reverse();
                indexes.ForEach(delegate(int i)
                {
                    sourceList.RemoveAt(i);
                });
            }
        }
        private void PlaySelectedTracks(object parameter)
        {
            System.Collections.IList sourceList = parameter as System.Collections.IList;
            if (sourceList != null)
            {
                this.InvokeAsynchronously(() =>
                    {
                        TrackCollection trackCollection = sourceList.ToTrackCollection();
                        if (trackCollection != null)
                        {
                            BSE.Platten.Audio.PlayerManager.PlayTracks(trackCollection, BSE.Platten.Audio.PlayMode.Playlist);
                        }
                    });
            }
        }
        private void SelectAlbum(object parameter)
        {
            CTrack track = parameter as CTrack;
            if (track != null)
            {
                this.InvokeAsynchronously(() =>
                    {
                        Album album = this.GetAlbumById(track.TitelId);
                        if (album != null)
                        {
                            this.Mediator.NotifyColleagues<Album>(MediatorMessages.MessageCurrentAlbumChanged, album);
                        }
                    });
            }
        }
        #endregion

    }
}
