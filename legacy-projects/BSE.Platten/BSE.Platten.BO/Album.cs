using System;
using System.Collections;
using System.Drawing;

using BSE.Platten.BO.Properties;
using System.Globalization;

namespace BSE.Platten.BO
{
	/// <summary>
	/// This class contains all properties and methods of an album.
	/// </summary>
	public class Album : ICloneable
    {
        #region Constants

        private readonly Size m_thumbNailSize = new Size(80, 80);

        #endregion

		#region Properties
        /// <summary>
        /// Gets or sets the AlbumId for the album.
        /// </summary>
        public int AlbumId
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the TOC for the album.
        /// </summary>
        public string TOC
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the MediaId for the album.
        /// </summary>
        public string MediaId
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the Index for the album.
        /// </summary>
        public int Index
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the InterpretId for the album.
        /// </summary>
        public int InterpretId
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the name of the artist for the album.
        /// </summary>
        public string Interpret
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the title for the album.
        /// </summary>
        public string Title
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the publishing year for the album.
        /// </summary>
        public int Year
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the MediumId for the album.
        /// </summary>
        public int MediumId
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the name of the data medium for the album.
        /// </summary>
        public string Medium
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the GenreId for the album.
        /// </summary>
        public int GenreId
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the name of the genre medium for the album.
        /// </summary>
        public string Genre
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the Cover for the album.
        /// </summary>
        public System.Drawing.Image Cover
        {
            get;
            set;
        }
        public System.Windows.Media.Imaging.BitmapSource CoverSource
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the Thumbnail for the album.
        /// </summary>
        public System.Drawing.Image Thumbnail
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the size of the album's thumbnail.
        /// </summary>
        public System.Drawing.Size ThumbnailSize
        {
            get { return this.m_thumbNailSize; }
        }
        /// <summary>
        /// Gets or sets the file extension of the album's cover.
        /// </summary>
        public string CoverExtension
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the tracks for the album
        /// </summary>
        public CTrack[] Tracks
        {
            get;
            set;
        }
		#endregion

		#region MethodsPublic

		public Album()
		{
		}
        /// <summary>
        /// Converts a <see cref="BSE.Platten.BO.CDataRowAlbum"/> object into a <see cref="CAlbum"/> object.
        /// </summary>
        /// <param name="dataRowAlbum">The convertible <see cref="BSE.Platten.BO.CDataRowAlbum"/> object</param>
        /// <param name="strAudioHomeDirectory">The audio directory in which the tracks are located.</param>
        /// <returns>A <see cref="CAlbum"/> object.</returns>
        public static Album GetAlbumDataByDataRow(CDataRowAlbum dataRowAlbum, string strAudioHomeDirectory)
        {
            Album album = null;
            if (dataRowAlbum != null)
            {
                album = new Album();
                album.AlbumId = dataRowAlbum.TitelId;
                album.InterpretId = dataRowAlbum.InterpretId;
                string strInterpret = dataRowAlbum.Interpret as string;
                if (String.IsNullOrEmpty(strInterpret) == false)
                {
                    album.Interpret = strInterpret;
                }
                string strTitel = dataRowAlbum.Titel as string;
                if (String.IsNullOrEmpty(strTitel) == false)
                {
                    album.Title = strTitel;
                }
                if (dataRowAlbum.IsErschDatumNull() == false)
                {
                    album.Year = dataRowAlbum.ErschDatum;
                }
                if (dataRowAlbum.IsMediumIdNull() == false)
                {
                    album.MediumId = dataRowAlbum.MediumId;
                }
                if (dataRowAlbum.IsGenreIdNull() == false)
                {
                    album.GenreId = dataRowAlbum.GenreId;
                }

                if (dataRowAlbum.IsCoverNull() == false)
                {
                    Byte[] byteCover = dataRowAlbum.Cover;
                    album.Cover = System.Drawing.Bitmap.FromStream(new System.IO.MemoryStream((byte[])byteCover));
                }
                if (dataRowAlbum.IsThumbNailNull() == false)
                {
                    Byte[] byteThumbNail = dataRowAlbum.ThumbNail;
                    album.Thumbnail = System.Drawing.Bitmap.FromStream(new System.IO.MemoryStream((byte[])byteThumbNail));
                }

                if (dataRowAlbum.IsPictureFormatNull() == false)
                {
                    album.CoverExtension = dataRowAlbum.PictureFormat;
                }

                CDataRowTracks[] dataRowsTrack = (CDataRowTracks[])dataRowAlbum.GetChildRows(CDataSetAlbum.DATARELATIONNAME);
                ArrayList aTracks = new ArrayList();
                foreach (CDataRowTracks dataRow in dataRowsTrack)
                {
                    CTrack track = new CTrack();
                    track.TitelId = dataRow.TitelId;
                    track.LiedId = dataRow.LiedId;
                    if (dataRow.IsTrackNull() == false)
                    {
                        track.TrackNumber = dataRow.Track;
                    }
                    if (dataRow.IsLiedNull() == false)
                    {
                        track.Title = dataRow.Lied;
                    }
                    if (dataRow.IsDauerNull() == false)
                    {
                        track.Duration = new TimeSpan(
                            dataRow.Dauer.Hour,
                            dataRow.Dauer.Minute,
                            dataRow.Dauer.Second);
                    }
                    if (dataRow.IsLiedpfadNull() == false)
                    {
                        track.FileName = dataRow.Liedpfad;
                        if (String.IsNullOrEmpty(track.FileName) == false)
                        {
                            if (String.IsNullOrEmpty(strAudioHomeDirectory) == false)
                            {
                                track.FileFullName = strAudioHomeDirectory + dataRow.Liedpfad;
                            }
                        }
                    }
                    aTracks.Add(track);
                    album.Tracks = new CTrack[dataRowsTrack.Length];
                    aTracks.CopyTo(album.Tracks);
                }
            }

            return album;
        }
        /// <summary>
        /// Creates a exact copy of this <see cref="CAlbum"/> object
        /// </summary>
        /// <returns>The <see cref="CAlbum"/> this method creates, cast as an object.
        ///</returns>
		public object Clone()
		{
			Album album = new Album();
            album.AlbumId = this.AlbumId;
            if (this.TOC != null)
            {
                album.TOC = (string)this.TOC.Clone();
            }
            if (this.MediaId != null)
            {
                album.MediaId = (string)this.MediaId.Clone();
            }
			album.Index = this.Index;
			album.InterpretId = this.InterpretId;
            if (this.Interpret != null)
            {
                album.Interpret = (string)this.Interpret.Clone();
            }
            if (this.Title != null)
            {
                album.Title = (string)this.Title.Clone();
            }
			album.Year = this.Year;
			album.MediumId = this.MediumId;
            if (this.Medium != null)
            {
                album.Medium = (string)this.Medium.Clone();
            }
			album.GenreId = this.GenreId;
            if (this.Genre != null)
            {
                album.Genre = (string)this.Genre.Clone();
            }
            if (this.Cover != null)
            {
                album.Cover = (Image)this.Cover.Clone();
            }
            if (this.Thumbnail != null)
            {
                album.Thumbnail = (Image)this.Thumbnail.Clone();
            }
            if (this.CoverExtension != null)
            {
                album.CoverExtension = (string)this.CoverExtension.Clone();
            }
            if (this.Tracks != null)
            {
                album.Tracks = new CTrack[this.Tracks.Length];
                this.Tracks.CopyTo(album.Tracks, 0);
            }
			return (object)album;
		}
        /// <summary>
        /// Gets the name of the audio directory in which the tracks are located.
        /// </summary>
        /// <param name="environment">A <see cref="BSE.Platten.BO.CEnvironment"/> object.</param>
        /// <returns>The name of the audio directory.</returns>
        public static string GetAudioHomeDirectory(Environment environment)
        {
            if (environment == null)
            {
                throw new ArgumentNullException(
                    string.Format(
                    CultureInfo.CurrentUICulture,
                    Resources.IDS_ArgumentException,
                    typeof(Environment).Name));
            }
            
            string strAudioHomeDirectory;
            try
            {
                strAudioHomeDirectory = environment.GetAudioHomeDirectory();
                if (String.IsNullOrEmpty(strAudioHomeDirectory) == false)
                {
                    if (!strAudioHomeDirectory.EndsWith(System.IO.Path.DirectorySeparatorChar.ToString()))
                    {
                        strAudioHomeDirectory += System.IO.Path.DirectorySeparatorChar;
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
            return strAudioHomeDirectory;
        }

		#endregion
	}
}
