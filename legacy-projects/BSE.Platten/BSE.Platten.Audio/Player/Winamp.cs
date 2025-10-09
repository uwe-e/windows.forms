using System;
using System.Runtime.InteropServices;
using System.Timers;
using BSE.Platten.Audio.Properties;
using System.Globalization;
using System.Diagnostics.CodeAnalysis;

namespace BSE.Platten.Audio
{
	/// <summary>
	/// Zusammenfassung für CWinamp.
	/// </summary>
	public class Winamp : Player
	{
        #region Events

        internal event EventHandler<PlayStateChangeEventArgs> PlayStateChange;

        #endregion

        #region Konstanten

        private const string m_lpClassName		= "Winamp v1.x";
		private const string m_strTtlEnd		= " - Winamp";
		
		//Windows Const
		private const uint WM_COMMAND = 0x111;
		private const uint WM_COPYDATA = 0x4A;
		private const uint WM_USER = 0x400;
		
		//WM_USER Messages
		private const int IPC_PLAYFILE = 100;
		private const int IPC_DELETE = 101;
		private const int IPC_ISPLAYING = 104;
		private const int IPC_GETOUTPUTTIME	= 105;
        private const int IPC_JUMPTOTIME = 106;
        private const int IPC_SETPLAYLISTPOS = 121;
        private const int IPC_GETLISTLENGTH = 124;
        private const int IPC_GETLISTPOS = 125;

		//WM_Command
		private const int IPC_CLOSE = 40001;
		private const int IPC_PLAY = 40045;
		private const int IPC_PLAUSE = 40046;
		private const int IPC_STOP = 40047;

		#endregion

		#region FieldsPrivate
		
		private COPYDATASTRUCT m_copyDataStruct;
		private string m_strPlayerFileName;
		private System.Timers.Timer m_tmrMonitoring;
        private PlayState m_ePlayState;
        private int m_iPlaylistPosition;
		
		#endregion
		
		#region Properties
        /// <summary>
        /// The count property retrieves the number of media items in the playlist.
        /// </summary>
        public override int Count
        {
            get
            {
                IntPtr hWnd = NativeMethods.FindWindow(m_lpClassName, null);
                return NativeMethods.SendMessage(hWnd, WM_USER, 0, IPC_GETLISTLENGTH);
            }
        }
        /// <summary>
        /// Gets the name of the used audioplayer
        /// </summary>
        public override string Name
        {
            get { return "Nullsoft Winamp"; }
        }
        internal string PlayerFileName
		{
			get {return this.m_strPlayerFileName;}
			set {this.m_strPlayerFileName = value;}
		}
        /// <summary>
        /// The PlaylistPosition property retrieves the current position of the media item in the playlist.
        /// </summary>
        internal int PlaylistPosition
        {
            get { return this.m_iPlaylistPosition; }
            set { this.m_iPlaylistPosition = value; }
        }
		#endregion

		#region MethodsPublic

		public Winamp()
		{
            this.PlayStateChange += new EventHandler<PlayStateChangeEventArgs>(this.PlayStateChanged);
            this.m_tmrMonitoring = new System.Timers.Timer();
			this.m_tmrMonitoring.Interval = 1000;
			this.m_tmrMonitoring.AutoReset = true;
			this.m_tmrMonitoring.Elapsed += new System.Timers.ElapsedEventHandler(this.m_tmrMonitoring_Elapsed);
			this.m_tmrMonitoring.Enabled = false;
		}

        public Winamp(WinampConfigurationData winampConfigurationObject) : this()
        {
            if (winampConfigurationObject == null)
            {
                throw new ArgumentNullException(
                    string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.IDS_ArgumentNullException,
                    "winampConfigurationObject"));
            }
            this.m_strPlayerFileName = winampConfigurationObject.FileName;
        }

        public Winamp(string playerFileName) : this()
        {
            this.m_strPlayerFileName = playerFileName;
        }

		public override void Play()
		{
            if (IsPlaying(IPC_PLAY) == true)
			{
				this.m_tmrMonitoring.Enabled = true;
			}
		}

		public override void Play(string strFile, BSE.Platten.Audio.PlayMode mode)
		{
			try
			{
				if (IsRunning() == false)
				{
					this.StartPlayer();
					while (IsStarting() == false);
					OnPlayerStarted(this, new PlayerEventArgs(true));
				}
				this.Mode = mode;
				this.ClearPlaylist();
                try
                {
                    if (CheckFile.FileExists(strFile) == true)
                    {
                        this.EnqueueFile(strFile);
                        if (IsPlaying(IPC_PLAY) == true)
                        {
                            this.m_tmrMonitoring.Enabled = true;
                        }
                    }
                }
                catch (System.IO.FileNotFoundException)
                {
                    throw;
                }
			}
			catch (Exception)
			{
				throw;
			}
		}

		public override void Play(string[] strFiles, BSE.Platten.Audio.PlayMode mode)
		{
			try
			{
                if (strFiles == null)
                {
                    throw new ArgumentNullException(
                        string.Format(
                        CultureInfo.InvariantCulture,
                        Resources.IDS_ArgumentNullException,"strFiles"));
                }
                if (IsRunning() == false)
				{
					this.StartPlayer();
					while (IsStarting() == false);
					OnPlayerStarted(this, new PlayerEventArgs(true));
				}
				this.Mode = mode;
				int iFileCount = strFiles.Length;
				string[] files = strFiles;
			
				this.ClearPlaylist();

				for (int i = 0; i < iFileCount; i++)
				{
					string fileName = files[i];
                    try
                    {
                        if (CheckFile.FileExists(fileName) == true)
                        {
                            EnqueueFile(fileName);
                        }
                    }
                    catch (System.IO.FileNotFoundException)
                    {
                        throw;
                    }
				}
                if (IsPlaying(IPC_PLAY) == true)
				{
                    this.PlaylistPosition = 0;
                    this.m_tmrMonitoring.Enabled = true;
				}
			}
			catch (Exception)
			{
				throw;
			}
		}

		public override void Load()
		{
			if (IsRunning() == false)
			{
				this.StartPlayer();
				while (IsStarting() == false);
				OnPlayerStarted(this, new PlayerEventArgs(true));
			}
		}
        [SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults")]
		public override void Close()
		{
			this.Stop();
            IntPtr hWnd = NativeMethods.FindWindow(m_lpClassName, null);
            if (hWnd.Equals(IntPtr.Zero) == false)
			{
                this.PlayStateChange -= new EventHandler<PlayStateChangeEventArgs>(this.PlayStateChanged);
                NativeMethods.SendMessage(hWnd, WM_COMMAND, IPC_CLOSE, 0);
			}
		}

		public override void Pause()
		{
			if (IsRunning())
			{
                IntPtr hWnd = NativeMethods.FindWindow(m_lpClassName, null);
                if (hWnd.Equals(IntPtr.Zero) == false)
                {
                    NativeMethods.PostMessage(hWnd, WM_COMMAND, IPC_PLAUSE, 0);
                }
			}
		}

		public override void Stop()
		{ 
			if (IsRunning() == false)
			{
				return;
			}
			if (this.m_tmrMonitoring.Enabled)
			{
				this.m_tmrMonitoring.Enabled = false;
                this.m_ePlayState = PlayState.Stopped;
				OnPlayerStopped(this, new PlayerEventArgs(BSE.Platten.Audio.PlayMode.None));
			}
            IntPtr hWnd = NativeMethods.FindWindow(m_lpClassName, null);
            if (hWnd.Equals(IntPtr.Zero) == false)
            {
                NativeMethods.PostMessage(hWnd, WM_COMMAND, IPC_STOP, 0);
            }

		}
        /// <summary>
        /// Gets the new position in the playlist.
        /// </summary>
        /// <returns>current playlist position</returns>
        public override int GetPlaylistPosition()
        {
            int iPlayListPosition = 0;
            IntPtr hWnd = NativeMethods.FindWindow(m_lpClassName, null);
            if (hWnd.Equals(IntPtr.Zero) == false)
            {
                iPlayListPosition = NativeMethods.SendMessage(hWnd, WM_USER, 0, IPC_GETLISTPOS);
            }
            return iPlayListPosition;
        }
        /// <summary>
        /// Sets the new position in the playlist.
        /// </summary>
        /// <param name="iPosition">new playlist position</param>
        public override void SetPlaylistPosition(int iPosition)
        {
            IntPtr hWnd = NativeMethods.FindWindow(m_lpClassName, null);
            if (hWnd.Equals(IntPtr.Zero) == false)
            {
                NativeMethods.SendMessage(hWnd, WM_USER, iPosition, IPC_SETPLAYLISTPOS);
                if (IsPlaying(IPC_PLAY) == true)
                {
                    OnPlayerPlays(this, new PlayerEventArgs());
                }
            }
        }

		public override void ClearPlaylist()
		{
            IntPtr hWnd = NativeMethods.FindWindow(m_lpClassName, null);
            if (hWnd.Equals(IntPtr.Zero) == false)
            {
                NativeMethods.SendMessage(hWnd, WM_USER, 0, IPC_DELETE);
            }
		}
        /// <summary>
        /// Sets the current position in the media item in seconds from the beginning.
        /// </summary>
        /// <param name="iCurrentPostion">current position in seconds</param>
        public override void SetTrackPosition(int iCurrentPostion)
        {
            if (iCurrentPostion > 0)
            {
                IntPtr hWnd = NativeMethods.FindWindow(m_lpClassName, null);
                if (hWnd.Equals(IntPtr.Zero) == false)
                {
                    NativeMethods.SendMessage(hWnd, WM_USER, iCurrentPostion * 1000, IPC_JUMPTOTIME);
                }
            }
        }
        /// <summary>
        /// Gets the current position in the media item in seconds from the beginning.
        /// </summary>
        /// <returns>current position in seconds</returns>
		public override int GetTrackPosition()
		{
            int iTrackPosition = 0;
            IntPtr hWnd = NativeMethods.FindWindow(m_lpClassName, null);
            if (hWnd.Equals(IntPtr.Zero) == false)
            {
                iTrackPosition = NativeMethods.SendMessage(hWnd, WM_USER, 0, IPC_GETOUTPUTTIME) / 1000;
            }
            return iTrackPosition;
		}
        /// <summary>
        /// Gets the duration in seconds of the current media item
        /// </summary>
        /// <returns>the duration in seconds</returns>
		public override int GetTrackLength()
		{
            int iTrackLenght = 0;
            IntPtr hWnd = NativeMethods.FindWindow(m_lpClassName, null);
            if (hWnd.Equals(IntPtr.Zero) == false)
            {
                iTrackLenght = NativeMethods.SendMessage(hWnd, WM_USER, 1, IPC_GETOUTPUTTIME);
            }
            return iTrackLenght;
		}

		public override string GetSongTitle()
		{
            IntPtr hWnd = NativeMethods.FindWindow(m_lpClassName, null);
            if (hWnd.Equals(IntPtr.Zero) == false)
			{
				string lpText = new string((char) 0, 100);
                int intLength = NativeMethods.GetWindowText(hWnd, lpText, lpText.Length);
		
				if ((intLength <= 0) || (intLength > lpText.Length))
				{
                    return UnknownTitle;
				}
				string strTitle = lpText.Substring(0, intLength);
				int intName = strTitle.IndexOf(m_strTtlEnd);
				int intLeft = strTitle.IndexOf("[");
				int intRight = strTitle.IndexOf("]");

				if ((intName >= 0) && (intLeft >= 0) && (intName < intLeft) &&
					(intRight >= 0) && (intLeft + 1 < intRight))
					return strTitle.Substring(intLeft + 1, intRight - intLeft - 1);

				if ((strTitle.EndsWith(m_strTtlEnd)) && (strTitle.Length > m_strTtlEnd.Length))
					strTitle = strTitle.Substring(0, strTitle.Length - m_strTtlEnd.Length);

				int intDot = strTitle.IndexOf(".");
				if ((intDot > 0) && IsNumeric(strTitle.Substring(0, intDot)))
					strTitle = strTitle.Remove(0, intDot + 1);

				return strTitle.Trim();
			}
			else
			{
				return string.Empty;
			}
		}
		
		#endregion

		#region MethodsProtected
		#endregion

		#region MethodsPrivate

        private void PlayStateChanged(object sender, PlayStateChangeEventArgs e)
        {
            switch (e.PlayState)
            {
                case PlayState.Ended:
                    OnSongEnded(sender, new PlayerEventArgs(this.Mode));
                    break;
                case PlayState.Stopped:
                    OnPlayerStopped(sender, new PlayerEventArgs(this.Mode));
                    break;
                case PlayState.Playing:
                    OnPlayerPlays(sender, new PlayerEventArgs(this.Mode));
                    break;
                case PlayState.Paused:
                    OnPlayerPaused(sender, new PlayerEventArgs());
                    break;
                case PlayState.Closed:
                    OnPlayerClosed(sender, new PlayerEventArgs(this.Mode));
                    break;
            }
        }
        /// <summary>
        /// sent as a WM_COPYDATA, with IPC_PLAYFILE as the dwData, and the string to play
        /// as the lpData. Just enqueues, does not clear the playlist or change the playback
        /// state.
        /// </summary>
        /// <param name="file">file for enqueuing</param>
        private void EnqueueFile(string file)
		{
            IntPtr hWnd = NativeMethods.FindWindow(m_lpClassName, null);
            if (hWnd.Equals(IntPtr.Zero) == false)
            {
                m_copyDataStruct.dwData = (IntPtr)IPC_PLAYFILE;
                m_copyDataStruct.lpData = file;
                m_copyDataStruct.cbData = file.Length + 1;
                NativeMethods.SendMessage(hWnd, WM_COPYDATA, IntPtr.Zero, ref m_copyDataStruct);
            }
		}

        private static bool IsNumeric(string Value)
		{
			try 
			{
				double.Parse(Value);
				return true;
			}
			catch
			{
				return false;
			}
		}

		private void StartPlayer()
		{
            IntPtr hWnd = NativeMethods.FindWindow(m_lpClassName, null);
            if (hWnd.Equals(IntPtr.Zero) == true)
			{
                if (String.IsNullOrEmpty(this.m_strPlayerFileName) == true)
                {
                    throw new System.IO.FileNotFoundException(
                        Resources.IDS_WinampNotFoundException,this.m_strPlayerFileName);
                }
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.EnableRaisingEvents = false;
                process.StartInfo.FileName = this.m_strPlayerFileName;
                process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Minimized;
                process.StartInfo.UseShellExecute = true;
                process.Start();
			}
		}

		private static bool IsStarting()
		{
			bool bIsStarting = false;
            IntPtr hWnd = NativeMethods.FindWindow(m_lpClassName, null);
            if (hWnd.Equals(IntPtr.Zero) == false)
			{
                bIsStarting = true;
			}
			return bIsStarting;
		}

		private static bool IsRunning()
		{
			bool bIsRunning = false;
            IntPtr hWnd = NativeMethods.FindWindow(m_lpClassName, null);
            if (hWnd.Equals(IntPtr.Zero) == false)
			{
				bIsRunning = true;
			}
			return bIsRunning;
		}

		private static bool IsPlaying(int action)
		{
            bool bIsPlaying = false;
            IntPtr hWnd = NativeMethods.FindWindow(m_lpClassName, null);
            if (hWnd.Equals(IntPtr.Zero) == false)
            {
                if (NativeMethods.PostMessage(hWnd, WM_COMMAND, action, 0) > 0)
                {
                    bIsPlaying = true;
                }
            }
            return bIsPlaying;
		}
        /// <summary>
        /// If it returns 1, it is playing. if it returns 3, it is paused,
        /// if it returns 0, it is not playing.
        /// </summary>
        /// <returns>int 1 playing, int 3 pause, 0 not playing</returns>
        private static int GetStatus()
		{
            int iStatus = 0;
            IntPtr hWnd = NativeMethods.FindWindow(m_lpClassName, null);
            if (hWnd.Equals(IntPtr.Zero) == false)
            {
                iStatus = NativeMethods.SendMessage(hWnd, WM_USER, 0, IPC_ISPLAYING);
            }
            return iStatus;
		}
		private void m_tmrMonitoring_Elapsed(object source, System.Timers.ElapsedEventArgs e)
		{
            IntPtr hWnd = NativeMethods.FindWindow(m_lpClassName, null);
            if (hWnd.Equals(IntPtr.Zero) == true)
			{
                this.m_tmrMonitoring.Enabled = false;
				return;
			}
            
            int iCurrentPlaylistPosition = this.GetPlaylistPosition();
            if (iCurrentPlaylistPosition.Equals(this.PlaylistPosition) == false)
            {
                if (this.Mode == PlayMode.CD)
                {
                    //Wird ein Album abgespielt, dann wird hier der Wechsel der Tracks
                    //festgestellt. Ein Statuswechsel wird nicht erreicht
                    this.PlaylistPosition = iCurrentPlaylistPosition;
                    if (IsPlaying(IPC_PLAY) == true)
                    {
                        this.m_ePlayState = PlayState.Undefined;
                        return;
                    }
                }
            }
            PlayState ePlayState = (PlayState)GetStatus();
            if (ePlayState == this.m_ePlayState)
			{
				return;
			}
            //Der Timer wird angehalten
            this.m_tmrMonitoring.Enabled = false;
            this.m_ePlayState = ePlayState;
            switch (ePlayState)
			{
				case PlayState.Stopped:
                    if (hWnd.Equals(IntPtr.Zero))
					{
                        PlayStateChanged(this,new PlayStateChangeEventArgs(PlayState.Closed));
						return;
					}
                    if (this.Mode != PlayMode.CD)
                    {
                        PlayStateChanged(this, new PlayStateChangeEventArgs(PlayState.Ended));
                    }
                    else
                    {
                        //Wenn ein Album gespielt wird, soll hier gestoppt werden
                        //nur nach Beendigung des letzten Tracks wird dieser Code erreicht
                        PlayStateChanged(this, new PlayStateChangeEventArgs(PlayState.Stopped));
                    }
					break;
                case PlayState.Playing:
                    PlayStateChanged(this,new PlayStateChangeEventArgs(PlayState.Playing));
					break;
                case PlayState.Paused:
                    PlayStateChanged(this,new PlayStateChangeEventArgs(PlayState.Paused));
					break;
			}
            //Der Timer wird wieder eingeschaltet
            this.m_tmrMonitoring.Enabled = true;
		}

		#region Struct COPYDATASTRUCT

		[StructLayout(LayoutKind.Sequential)]
		internal struct COPYDATASTRUCT
		{
			public IntPtr dwData;
			public int cbData;
			[MarshalAs(UnmanagedType.LPStr)] public string lpData;
		}
		
		#endregion

        #region class NativeMethods

        internal static class NativeMethods
        {
            [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
            public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

            [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
            public static extern int SendMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);

            [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
            public static extern int SendMessage(IntPtr hwnd, uint wMsg, IntPtr wParam, ref COPYDATASTRUCT copyDataStruct);

            [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
            public static extern int GetWindowText(IntPtr hWnd, string lpString, int nMaxCount);

            [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
            public static extern int PostMessage(IntPtr hWnd, uint wMsg, int wParam, int lParam);
        }
        
        #endregion
        
        #endregion
    }

    public class PlayStateChangeEventArgs : EventArgs
    {
        #region FieldsPrivate

        private PlayState m_playState;

        #endregion

        #region Properties

        public PlayState PlayState
        {
            get { return this.m_playState; }
        }

        #endregion

        #region MethodsPublic

        public PlayStateChangeEventArgs(PlayState playState)
		{
            this.m_playState = playState;
		}

        #endregion
    }
}
