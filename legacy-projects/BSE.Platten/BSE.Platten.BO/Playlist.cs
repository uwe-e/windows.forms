using System;
using System.Linq; 

namespace BSE.Platten.BO
{
	/// <summary>
	/// Zusammenfassung für CPlaylist.
	/// </summary>
	public class Playlist : ICloneable
	{
		#region Properties

        public int Id
        {
            get;
            set;
        }

		public string Name
		{
            get;
            set;
		}

		public System.Guid Guid
		{
            get;
            set;
		}

		public string User
		{
            get;
            set;
		}

		public System.DateTime TimeStamp
		{
            get;
            set;
		}
		
		public CTrack[] Tracks
		{
            get;
            set;
		}

		public PlaylistEntry[] PlayListEntries
		{
            get;
            set;
		}

		#endregion

		#region MethodsPublic

		public Playlist()
		{
			//
			// TODO: Fügen Sie hier die Konstruktorlogik hinzu
			//
		}

		public object Clone()
		{
			Playlist playList = new Playlist();
			playList.Id = this.Id;
			playList.Name = this.Name;
			playList.Guid = this.Guid;
			playList.TimeStamp = this.TimeStamp;
			playList.User = this.User;
			playList.Tracks = this.Tracks;
			playList.PlayListEntries = this.PlayListEntries;

			return playList;
		}

        public static Playlist GetPlaylist(int playlistId, Environment environment)
        {
            if (environment == null)
            {
                throw new ArgumentNullException("environment");
            }
            Playlist playlist = null;
            CTunesBusinessObject tunesBusinessObject = new CTunesBusinessObject(environment.GetConnectionString());
            try
            {
                playlist = tunesBusinessObject.GetPlayListByPlayListId(playlistId);
                if (playlist != null)
                {
                    CTrack[] tracks = playlist.Tracks;
                    if (tracks != null)
                    {
                        string strAudioHomeDirectory = Album.GetAudioHomeDirectory(environment);
                        tracks.ToList().ForEach(delegate(CTrack track)
                        {
                            track.FileFullName = strAudioHomeDirectory + track.FileName;
                        });
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return playlist;
        }

        public static TrackCollection GetTrackCollection(Playlist playlist, Environment environment)
        {
            if (playlist == null)
            {
                throw new ArgumentNullException("playlist");
            }

            TrackCollection trackCollection = null;
            playlist = GetPlaylist(playlist.Id, environment);
            if (playlist != null)
            {
                if (playlist.Tracks != null)
                {
                    trackCollection = new TrackCollection(playlist.Tracks.ToList());
                }
            }
            return trackCollection;
        }
		#endregion

	}
}
