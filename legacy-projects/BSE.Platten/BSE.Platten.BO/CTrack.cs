using System;

namespace BSE.Platten.BO
{
	/// <summary>
    /// This class contains all properties and methods of a track.
	/// </summary>
    public class CTrack : ICloneable
	{
		#region Properties
		/// <summary>
		/// Gets or sets the id of the album.
		/// </summary>
        public int TitelId
        {
            get;
            set;
        }
		/// <summary>
		/// Gets or sets the id of the track.
		/// </summary>
        public int LiedId
        {
            get;
            set;
        }
		/// <summary>
		/// Gets or sets the index of the track.
		/// </summary>
        public int Index
        {
            get;
            set;
        }
		/// <summary>
		/// Gets or sets the cd index of the track beginning at 1.
		/// </summary>
        public int CDIndex
        {
            get;
            set;
        }
		/// <summary>
		/// Gets or sets the tracknumber of the track.
		/// </summary>
        public int TrackNumber
        {
            get;
            set;
        }
		/// <summary>
		/// Gets or sets the interpret of the track.
		/// </summary>
        public string Interpret
        {
            get;
            set;
        }
		/// <summary>
		/// Gets or sets the album of the track.
		/// </summary>
        public string Album
        {
            get;
            set;
        }
		/// <summary>
		/// Gets or sets the title of the track.
		/// </summary>
        public string Title
        {
            get;
            set;
        }
		/// <summary>
		/// Gets or sets the year of the tracks album.
		/// </summary>
        public int Year
        {
            get;
            set;
        }
		/// <summary>
		/// Gets or sets the mediumid of the tracks album.
		/// </summary>
        public int MediumId
        {
            get;
            set;
        }
		/// <summary>
		/// Gets or sets the medium of the tracks album.
		/// </summary>
        public string Medium
        {
            get;
            set;
        }
		/// <summary>
		/// Gets or sets the genreid of the tracks album.
		/// </summary>
        public int GenreId
        {
            get;
            set;
        }
		/// <summary>
		/// Gets or sets the genre of the tracks album.
		/// </summary>
        public string Genre
        {
            get;
            set;
        }
		/// <summary>
		/// Gets or sets the cover of the tracks album.
		/// </summary>
        public System.Drawing.Image Cover
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the thumbnail of the tracks album.
        /// </summary>
        public System.Drawing.Image ThumbNail
        {
            get;
            set;
        }
		/// <summary>
		/// Gets or sets the duration of the track.
		/// </summary>
        public TimeSpan Duration
        {
            get;
            set;
        }
		/// <summary>
		/// Gets or sets the size of the track.
		/// </summary>
        public uint TrackSize
        {
            get;
            set;
        }
		/// <summary>
		/// Gets or sets the audioformat of the track.
		/// </summary>
        public CAudioFormat.AudioFormat UsedAudioFormat
        {
            get;
            set;
        }
		/// <summary>
		/// Gets or sets the name of the track.
		/// </summary>
        public string FileName
        {
            get;
            set;
        }
		/// <summary>
		/// Gets or sets the full path of the directory or track.
		/// </summary>
        public string FileFullName
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the string representing the extension part of the track file.
        /// </summary>
        public string Extension
        {
            get;
            set;
        }
		#endregion
		#region MethodsPublic

		public CTrack()
		{
		}
		/// <summary>
		/// Creates a new object that is a copy of the current track.
		/// </summary>
		/// <returns>A new object that is a copy of this track.</returns>
		public virtual object Clone()
		{
			CTrack track = new CTrack();
            track.TitelId = this.TitelId;
            track.LiedId = this.LiedId;
            track.Index = this.Index;
            track.CDIndex = this.CDIndex;
            track.TrackNumber = this.TrackNumber;
            if (this.Interpret != null)
            {
                track.Interpret = (string)this.Interpret.Clone(); ;
            }
            if (this.Album != null)
            {
                track.Album = (string)this.Album.Clone();
            }
            if (this.Title != null)
            {
                track.Title = (string)this.Title.Clone();
            }
            track.Year = this.Year;
            track.MediumId = this.MediumId;
            track.Medium = this.Medium;
            track.GenreId = this.GenreId;
            if (this.Genre != null)
            {
                track.Genre = (string)this.Genre.Clone();
            }
            if (this.Cover != null)
            {
                track.Cover = (System.Drawing.Image)this.Cover.Clone();
            }
            if (this.ThumbNail != null)
            {
                track.ThumbNail = (System.Drawing.Image)this.ThumbNail.Clone();
            }
            track.Duration = this.Duration;
			track.TrackSize = this.TrackSize;
            if (this.FileName != null)
            {
                track.FileName = (string)this.FileName.Clone();
            }
            if (this.FileFullName != null)
            {
                track.FileFullName = (string)this.FileFullName.Clone();
            }
            if (this.Extension != null)
            {
                track.Extension = (string)this.Extension.Clone();
            }
			return (object)track;
		}
        public override bool Equals(object obj)
        {
            //return base.Equals(obj);
            CTrack track = obj as CTrack;
            if (track == null)
            {
                return false;
            }
            if (this.LiedId.Equals(track.LiedId) == false)
            {
                return false;
            }
            return true;
        }
        //public virtual bool Equals(CTrack track)
        //{
        //    if (track == null)
        //    {
        //        return false;
        //    }
        //    return this.LiedId.Equals(track.LiedId);
        //}
		#endregion

	}
}
