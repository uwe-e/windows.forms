using System;
using System.Diagnostics.CodeAnalysis;

namespace BSE.Platten.Audio
{
	/// <summary>
	/// Zusammenfassung für IPlayer.
	/// </summary>
	public interface IPlayer
	{
		event EventHandler<PlayerEventArgs> PlayerStarted;
        event EventHandler<PlayerEventArgs> PlayerClosed;
        event EventHandler<PlayerEventArgs> PlayerPlays;
        event EventHandler<PlayerEventArgs> PlayerPaused;
        event EventHandler<PlayerEventArgs> PlayerStopped;
        event EventHandler<PlayerEventArgs> SongEnded;
		PlayMode Mode{get;set;}
        PlayState PlayState { get; set; }
        int Count { get;}
        string Name { get;}
        void Play();
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void Play(string strFile, BSE.Platten.Audio.PlayMode playMode);
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void Play(string[] strFiles, BSE.Platten.Audio.PlayMode playMode);
        void Load();
		void Close();
		void Pause();
        [SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords")]
        void Stop();
        int GetPlaylistPosition();
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void SetPlaylistPosition(int iPosition);
		int GetTrackPosition();
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void SetTrackPosition(int iCurrentPostion);
		int GetTrackLength();
		string GetSongTitle();
		void ClearPlaylist();
	}
}
