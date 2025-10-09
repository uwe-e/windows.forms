using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using BSE.Platten.BO.Properties;
using System.Collections.ObjectModel;

namespace BSE.Platten.BO
{
    public class CTunesBusinessObject
    {
        #region FieldsPrivate

        private string m_strConnection;

        #endregion

        #region MethodsPublic

        public CTunesBusinessObject(string strConnection)
        {
            this.m_strConnection = strConnection;
        }

        #region Albums

        public Album GetAlbumById(int iTitelId)
        {
            return CTunesModel.GetAlbumById(this.m_strConnection, iTitelId);
        }

        public CTrack GetTrackWithThumbNailById(CTrack track)
        {
            return CTunesModel.GetTrackWithThumbNailById(this.m_strConnection, track);
        }

        #endregion

        #region Covers

        public Album[] GetNewestAlbumsWithCovers(int iLimit)
        {
            CCoversBusinessObject coversBusinessObject
                = new CCoversBusinessObject(this.m_strConnection);
            return coversBusinessObject.GetNewestAlbumsWithCoverSources(iLimit);
        }

        #endregion

        #region Trees

        public CInterpretData[] GetInterpretsAndAlbums()
        {
            return CTunesModel.GetInterpretsAndAlbums(this.m_strConnection);
        }

        public CGenreData[] GetGenresWithAlbums()
        {
            return CTunesModel.GetGenresWithAlbums(this.m_strConnection);
        }

        public CYearData[] GetYearsWithAlbums()
        {
            return CTunesModel.GetYearsWithAlbums(this.m_strConnection);
        }

        #endregion

        #region Favorites

        public CFavorite[] GetFavoritesByFavoritId(int iLimit, int iFavoriteId, string strBenutzer)
        {
            return CTunesModel.GetFavoritesByFavoritId(iLimit, iFavoriteId, strBenutzer, this.m_strConnection);
        }

        #endregion

        #region FullTextSearch

        public SortableCollection<CTrack> GetFullTextSearchCollection(string strSearchstring)
        {
            return CTunesModel.GetFullTextSearchCollection(strSearchstring, this.m_strConnection);
        }

        #endregion

        #region Playlist

        public CTrack[] GetAlbumTracksForPlayListByTitelId(int iTitelId)
        {
            return CTunesModel.GetAlbumTracksForPlayListByTitelId(this.m_strConnection, iTitelId);
        }

        public BSE.Platten.BO.CTrack GetTrackForPlayListByLiedId(int iLiedId)
        {
            return CTunesModel.GetTrackForPlayListByLiedId(this.m_strConnection, iLiedId);
        }

        public IList<Playlist> GetPlaylistsByUserName(string userName)
        {
            return CTunesModel.GetPlaylistsByUserName(this.m_strConnection, userName);
        }

        public Playlist GetPlayListByPlayListId(int iPlayListId)
        {
            return CTunesModel.GetPlayListByPlayListId(this.m_strConnection, iPlayListId);
        }

        public Playlist InsertPlaylist(Playlist playList)
        {
            if (playList == null)
            {
                throw new ArgumentNullException(
                    string.Format(
                    CultureInfo.CurrentUICulture,
                    Resources.IDS_ArgumentException,
                    "playList"));
            }
            
            Playlist newPlayList = null;
            try
            {
                newPlayList = CTunesModel.InsertPlaylist(this.m_strConnection, playList);
            }
            catch (Exception exception)
            {
                MySql.Data.MySqlClient.MySqlException mySqlException = exception as MySql.Data.MySqlClient.MySqlException;
                if (mySqlException != null)
                {
                    if (mySqlException.Number == 1062)
                    {
                        throw new PlaylistAlreadyExistsException(Resources.IDS_PlaylistAlreadyExistsExceptionMessage, playList.Name);
                    }
                    else
                    {
                        throw;
                    }
                }
                else
                {
                    throw;
                }
            }
            return newPlayList;
        }

        public void SavePlayList(Playlist playList)
        {
            CTunesModel.SavePlayList(this.m_strConnection, playList);
        }

        public void DeletePlayList(int iPlayListId)
        {
            CTunesModel.DeletePlayList(this.m_strConnection, iPlayListId);
        }

        #endregion

        #region Filters

        public CFilter[] GetFilterByFilterMode(FilterSettings.FilterMode filterMode)
        {
            return CTunesModel.GetFilterByFilterMode(this.m_strConnection, filterMode);
        }

        public TrackCollection GetTracksByFilterSettings(FilterSettings filterSettings)
        {
            return CTunesModel.GetTracksByFilterSettings(this.m_strConnection, filterSettings);
        }

        public FilterSettings GetFilterSettings(FilterSettings.FilterMode filterMode, string strBenutzer)
        {
            return CTunesModel.GetFilterSettings(this.m_strConnection, filterMode, strBenutzer);
        }

        public void SaveFilterSettings(FilterSettings filterSettings)
        {
            if (filterSettings == null)
            {
                throw new ArgumentNullException(
                    string.Format(
                    CultureInfo.CurrentUICulture,
                    Resources.IDS_ArgumentException,
                    "filterSettings"));
            }
            
            if (String.IsNullOrEmpty(filterSettings.Value) == true)
            {
                filterSettings.Value = null;
            }
            CTunesModel.SaveFilterSettings(this.m_strConnection, filterSettings);
        }

        #endregion

        #region History

        public void DeleteTracksFromHistory(string strUser)
        {
            CTunesModel.DeleteTracksFromHistory(this.m_strConnection, strUser);
        }

        public SortableCollection<CHistoryTrack> GetHistoryTrackCollection(string strUser)
        {
            return CTunesModel.GetHistoryTrackCollection(this.m_strConnection, strUser);
        }

        public SortableCollection<CHistoryTrack> GetHistoryTrackCollection(HistoryData historyData)
        {
            return CTunesModel.GetHistoryTrackCollection(this.m_strConnection, historyData);
        }

        public IList<Album> GetHistoryAlbums(string strUserName)
        {
            return CTunesModel.GetHistoryAlbums(this.m_strConnection, strUserName);
        }
        public IList<Album> GetHistoryAlbums(HistoryData historyData)
        {
            return CTunesModel.GetHistoryAlbums(this.m_strConnection, historyData);
        }
        public void UpdateHistory(HistoryData historyData)
        {
            CTunesModel.UpdateHistory(this.m_strConnection, historyData);
        }
        #endregion

        #endregion
    }
}
