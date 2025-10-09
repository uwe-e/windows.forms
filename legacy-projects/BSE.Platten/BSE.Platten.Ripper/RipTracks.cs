using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Diagnostics;

using BSE.CDDrives;
using BSE.Platten.BO;
using BSE.Platten.Common;
using BSE.Configuration;
using System.Collections.ObjectModel;
using System.Globalization;
using BSE.Platten.Ripper.Properties;
using BSE.Platten.Ripper.AudioWriters;


namespace BSE.Platten.Ripper
{
    public partial class RipTracks : BaseForm
    {

        #region EventsPublic

        public event EventHandler<TrackRippingEventArgs> TrackRipped;
        public event System.EventHandler RippingComplete;

        #endregion

        #region Delegates

        private delegate void ReadProcessHandler(ReadProgressEventArgs readProgressEventArgs);
        private delegate void WriteStatusHandler(CTrack track);
        private delegate void TrackExistsHandler(CTrack track);
        private delegate void WindowCloseHandler();

        #endregion

        #region FieldsPrivate

        private BSE.Configuration.Configuration m_configuration;
        private Collection<CTrack> m_trackCollection;
        private uint m_iTotalSize;
        private uint m_iBytesRead;
        private uint m_iBytes2Read;
        private uint m_iTotalBytesRead;
        private CDDrive m_cdDrive;
        private int m_iTrackIndex;
        private TrackRipper m_trackRipper;

        #endregion

        #region Properties

        public CDDrive CDDrive
        {
            get { return this.m_cdDrive; }
            set
            {
                if (value != this.m_cdDrive)
                {
                    this.m_cdDrive = value;
                }
            }
        }
        public Album Album
        {
            get;
            set;
        }
        #endregion

        #region MethodsPublic

        public RipTracks()
        {
            InitializeComponent();
            this.m_lblTotalTrackPercentValue.Text = string.Format(CultureInfo.InvariantCulture, "0 %");
            this.m_lblTrackPercentValue.Text = string.Format(CultureInfo.InvariantCulture, "0 %");
        }

        public RipTracks(BSE.Configuration.Configuration configuration, Collection<CTrack> trackCollection)
            : this()
        {
            this.m_configuration = configuration;
            this.m_trackCollection = trackCollection;
            this.m_iTotalSize = GetTotalTracksSize(trackCollection);
        }

        #endregion

        #region MethodsProtected
        #endregion

        #region MethodsPrivate

        private void RipThisTrack(int iIndexTrackToRip, System.IO.FileMode fileMode)
        {
            this.m_trackRipper = null;
            this.m_trackRipper = new TrackRipper();
            this.m_trackRipper.ReadCDProgess -= new EventHandler<ReadProgressEventArgs>(this.CdReadProgress);
            this.m_trackRipper.ReadCDProgess += new EventHandler<ReadProgressEventArgs>(this.CdReadProgress);
            this.m_trackRipper.TrackRippingCanceled -= new EventHandler<TrackRippingEventArgs>(this.TrackRippingCanceled);
            this.m_trackRipper.TrackRippingCanceled += new EventHandler<TrackRippingEventArgs>(this.TrackRippingCanceled);
            this.m_trackRipper.TrackExists -= new EventHandler<TrackRippingEventArgs>(this.TrackExists);
            this.m_trackRipper.TrackExists += new EventHandler<TrackRippingEventArgs>(this.TrackExists);
            this.m_trackRipper.TrackRipping -= new EventHandler<TrackRippingEventArgs>(this.TrackRipping);
            this.m_trackRipper.TrackRipping += new EventHandler<TrackRippingEventArgs>(this.TrackRipping);
            this.m_trackRipper.TrackRipped -= new EventHandler<TrackRippingEventArgs>(this.RipperTrackRipped);
            this.m_trackRipper.TrackRipped += new EventHandler<TrackRippingEventArgs>(this.RipperTrackRipped);
            this.m_trackRipper.StartRipping(
                this,
                this.m_cdDrive,
                this.Album,
                this.m_trackCollection[iIndexTrackToRip],
                fileMode,
                this.m_iTotalSize,
                this.m_configuration);
        }

        private void CdReadProgress(object sender, ReadProgressEventArgs ea)
        {
            if (this.IsHandleCreated == true)
            {
                this.Invoke(new ReadProcessHandler(ReadProcess), ea);
            }
        }

        private void TrackExists(object sender, TrackRippingEventArgs e)
        {
            if (this.IsHandleCreated == true)
            {
                TrackExistsHandler trackExistsHandler = delegate(CTrack track)
                {
                    string strException = String.Format(CultureInfo.CurrentUICulture, Resources.IDS_FileToRipExistsException, e.Track.FileFullName);
                    DialogResult dialogResult = GlobalizedMessageBox.Show(
                        this,
                        strException,
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (dialogResult == DialogResult.Yes)
                    {
                        RipThisTrack(this.m_iTrackIndex, System.IO.FileMode.Create);
                    }
                    else
                    {
                        this.Close();
                    }
                };
                this.Invoke(trackExistsHandler, e.Track);
            }
        }

        private void TrackRippingCanceled(object sender, TrackRippingEventArgs e)
        {
            GlobalizedMessageBox.Show(this, Resources.IDS_RippingAbortException, MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (e.Track != null)
            {
                System.IO.FileInfo fileInfo = new System.IO.FileInfo(e.Track.FileFullName);
                if (fileInfo.Exists)
                {
                    fileInfo.Delete();
                }
            }
            if (this.IsHandleCreated == true)
            {
                this.Invoke(new WindowCloseHandler(WindowCloseEvent));
            }
        }

        private void TrackRipping(object sender, TrackRippingEventArgs e)
        {
            if (this.IsHandleCreated == true)
            {
                WriteStatusHandler writeStatusHandler = delegate(CTrack track)
                {
                    if (this.m_iTrackIndex == 0)
                    {
                        //Index 0, die erste Zeile wird geschrieben
                        this.m_txtStatus.AppendText(string.Format(
                            CultureInfo.CurrentUICulture,
                            Resources.IDS_RippingTrackInformation,
                            track.Title,
                            track.FileFullName));
                    }
                    else
                    {
                        //Index > 0, die Zeilen werden angehängt
                        this.m_txtStatus.AppendText(
                            System.Environment.NewLine + string.Format(
                            CultureInfo.CurrentUICulture,
                            Resources.IDS_RippingTrackInformation,
                            track.Title,
                            track.FileFullName));
                    }
                };
                this.Invoke(writeStatusHandler, e.Track);
            }
        }

        private void RipperTrackRipped(object sender, TrackRippingEventArgs e)
        {
            //das Ende des Rip- Vorgangs wird an das aufrufenden Formular zurück gegeben
            if (this.TrackRipped != null)
            {
                this.TrackRipped(sender, new TrackRippingEventArgs(e.Track));
            }
            if (MoveNext() == true)
            {
                RipThisTrack(this.m_iTrackIndex, System.IO.FileMode.CreateNew);
            }
            else
            {
                if (this.IsHandleCreated == true)
                {
                    this.Invoke(new WindowCloseHandler(WindowCloseEvent));
                }
            }
        }

        private void WindowCloseEvent()
        {
            this.Close();
        }

        private static uint GetTotalTracksSize(Collection<CTrack> trackCollection)
        {
            uint iTotalTracksSize = 0;
            foreach (CTrack track in trackCollection)
            {
                iTotalTracksSize += track.TrackSize;
            }
            return iTotalTracksSize;
        }

        private void m_btnCancel_Click(object sender, EventArgs e)
        {
            if (this.m_trackRipper != null)
            {
                this.m_trackRipper.CancelRipping();
            }
        }

        private void CRipTracks_Load(object sender, EventArgs e)
        {
            this.RipThisTrack(this.m_iTrackIndex, System.IO.FileMode.CreateNew);
        }

        private void CRipTracks_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.m_trackRipper != null)
            {
                System.Threading.Thread threadTrackRipper =
                    this.m_trackRipper.Thread();
                if (threadTrackRipper != null && threadTrackRipper.IsAlive)
                {
                    this.m_trackRipper.CancelRipping();
                }
            }
            if (this.RippingComplete != null)
            {
                this.RippingComplete(this, e);
            }
        }

        private void ReadProcess(ReadProgressEventArgs readProgressEventArgs)
        {
            if (readProgressEventArgs.BytesRead == 0)
            {
                this.m_iBytes2Read = 0;
                this.m_iBytes2Read = readProgressEventArgs.Bytes2Read;
            }
            if (this.m_iBytes2Read == readProgressEventArgs.BytesRead)
            {
                this.m_iTotalBytesRead += readProgressEventArgs.BytesRead;
            }

            this.m_iBytesRead = this.m_iTotalBytesRead + readProgressEventArgs.BytesRead;

            ulong lPercentTotal = ((ulong)this.m_iBytesRead * 100) / this.m_iTotalSize;
            if (lPercentTotal <= 100)
            {
                this.m_pgTotalTime.Value = (int)lPercentTotal;
                this.m_lblTotalTrackPercentValue.Text = (double)lPercentTotal + " %";
            }

            ulong lPercent = ((ulong)readProgressEventArgs.BytesRead * 100) / readProgressEventArgs.Bytes2Read;
            this.m_pgTime.Value = (int)lPercent;
            this.m_lblTrackPercentValue.Text = (double)lPercent + " %";
        }

        public bool MoveNext()
        {
            if (this.m_trackCollection == null || this.m_trackCollection.Count == 0)
            {
                return false;
            }

            if (this.m_iTrackIndex < this.m_trackCollection.Count - 1)
            {
                this.m_iTrackIndex++;
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region internal class CTrackRipper

        internal class TrackRipper
        {
            #region EventsPublic

            public event EventHandler<ReadProgressEventArgs> ReadCDProgess;
            public event EventHandler<TrackRippingEventArgs> TrackRipping;
            public event EventHandler<TrackRippingEventArgs> TrackRipped;
            public event EventHandler<TrackRippingEventArgs> TrackRippingCanceled;
            public event EventHandler<TrackRippingEventArgs> TrackExists;

            #endregion

            #region FieldsPrivate

            private BSE.CDDrives.CDDrive m_cdDrive;
            private Album m_album;
            private BSE.Platten.BO.CTrack m_track;
            private Thread m_ripThread;
            private BSE.Configuration.Configuration m_configuration;
            private System.IO.FileMode m_fileMode = FileMode.CreateNew;
            private AudioWriter m_audioWriter;
            private System.Timers.Timer m_timer;
            private bool m_bCancelRipping;
            private uint m_iTotalTracksSize;
            private IWin32Window m_owner;

            #endregion

            #region MethodsPublic

            public void StartRipping(
                IWin32Window owner,
                CDDrive cdDrive,
                Album album,
                CTrack track,
                FileMode fileMode,
                uint iTotalTracksSize,
                BSE.Configuration.Configuration configuration)
            {
                this.m_owner = owner;
                this.m_cdDrive = cdDrive;
                this.m_album = album;
                this.m_track = track;
                this.m_fileMode = fileMode;
                this.m_iTotalTracksSize = iTotalTracksSize;
                this.m_configuration = configuration;

                this.m_ripThread = new Thread(new ThreadStart(RipThisTrack));
                this.m_ripThread.Start();

                this.m_timer = new System.Timers.Timer();
                this.m_timer.Elapsed += new System.Timers.ElapsedEventHandler(this.Timer_Elapsed);
                this.m_timer.Enabled = true;
                this.m_timer.Start();
            }

            public Thread Thread()
            {
                return this.m_ripThread;
            }

            public void CancelRipping()
            {
                if (this.m_bCancelRipping == false)
                {
                    this.m_bCancelRipping = true;
                    if (this.TrackRippingCanceled != null)
                    {
                        this.TrackRippingCanceled(this, new TrackRippingEventArgs(this.m_track));
                    }
                }
            }
            #endregion

            #region MethodsPrivate
            private void RipThisTrack()
            {
                try
                {
                    this.m_cdDrive.LockCD();
                    using (FileStream fileStream = new FileStream(this.m_track.FileFullName, this.m_fileMode, System.IO.FileAccess.Write))
                    {
                        AudioWriter audioWriter = null;
                        BSE.Platten.BO.CAudioFormat.AudioFormat eAudioFormat = this.m_track.UsedAudioFormat;
                        switch (eAudioFormat)
                        {
                            case BSE.Platten.BO.CAudioFormat.AudioFormat.Wav:
                                WaveConfigurationControl waveWriter = new WaveConfigurationControl(this.m_configuration);
                                audioWriter = new WaveWriter(fileStream, waveWriter.AudioWriterConfiguration);
                                break;
                            case BSE.Platten.BO.CAudioFormat.AudioFormat.Mp3:
                                MP3ConfigurationControl mp3Writer = new MP3ConfigurationControl(this.m_configuration);
                                audioWriter = new MP3Writer(fileStream, (MP3WriterConfiguration)mp3Writer.AudioWriterConfiguration);
                                break;
                        }

                        if (audioWriter != null)
                        {
                            using (this.m_audioWriter = audioWriter)
                            {
                                //event wenn das Rippen beginnt
                                if (this.TrackRipping != null)
                                {
                                    this.TrackRipping(this, new TrackRippingEventArgs(this.m_track));
                                }

                                this.m_cdDrive.ReadTrack(
                                    this.m_track.CDIndex,
                                    new EventHandler<DataReadEventArgs>(this.WriteWaveData),
                                    new EventHandler<ReadProgressEventArgs>(this.CdReadProgress));
                            }
                        }
                    }
                    if (this.m_bCancelRipping == false)
                    {
                        System.IO.FileInfo fileInfo = new System.IO.FileInfo(this.m_track.FileFullName);
                        if (BSE.Platten.BO.Environment.IsWritableAudioExtension(fileInfo.Extension) == true)
                        {
                            BSE.Platten.Audio.AudioData audioData = new BSE.Platten.Audio.WMFMediaData();
                            if (string.IsNullOrEmpty(this.m_track.Title) == false)
                            {
                                audioData.SetAttributeTitle(this.m_track.FileFullName, this.m_track.Title);
                            }
                            audioData.SetAttributeTrackNumber(this.m_track.FileFullName, this.m_track.TrackNumber.ToString());
                            if (this.m_album != null)
                            {
                                string strInterpret = this.m_album.Interpret;
                                if (string.IsNullOrEmpty(strInterpret) == false)
                                {
                                    audioData.SetAttributeAuthor(this.m_track.FileFullName, strInterpret);
                                }
                                string strAlbumTitle = this.m_album.Title;
                                if (string.IsNullOrEmpty(strAlbumTitle) == false)
                                {
                                    audioData.SetAttributeAlbumTitle(this.m_track.FileFullName, strAlbumTitle);
                                }
                                string strGenre = this.m_album.Genre;
                                if (string.IsNullOrEmpty(strGenre) == false)
                                {
                                    audioData.SetAttributeGenre(this.m_track.FileFullName, strGenre);
                                }
                                int iYear = this.m_album.Year;
                                if (iYear > 0)
                                {
                                    audioData.SetAttributeYear(this.m_track.FileFullName, iYear.ToString(CultureInfo.InvariantCulture));
                                }
                                Image coverImage = this.m_album.Cover;
                                if (coverImage != null)
                                {
                                    audioData.SetAttributePicture(this.m_track.FileFullName, coverImage);
                                }
                            }
                        }
                    }
                }
                catch (System.IO.IOException ioException)
                {
                    this.m_bCancelRipping = true;
                    if (this.m_fileMode == System.IO.FileMode.CreateNew)
                    {
                        if (this.m_ripThread != null && this.m_ripThread.IsAlive)
                        {
                            if (this.TrackExists != null)
                            {
                                this.TrackExists(this, new TrackRippingEventArgs(this.m_track));
                            }
                        }
                    }
                    else
                    {
                        this.m_bCancelRipping = true;
                        GlobalizedMessageBox.Show(
                            this.m_owner,
                            ioException.Message,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
                catch (Exception exception)
                {
                    this.m_bCancelRipping = true;
                    GlobalizedMessageBox.Show(
                        this.m_owner,
                        exception.Message,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                finally
                {
                    this.m_cdDrive.UnlockCD();
                }
            }

            private void CdReadProgress(object sender, BSE.CDDrives.ReadProgressEventArgs ea)
            {
                ea.CancelRead |= this.m_bCancelRipping;
                if (this.ReadCDProgess != null)
                {
                    this.ReadCDProgess(this, new BSE.CDDrives.ReadProgressEventArgs(
                        ea.Bytes2Read,
                        ea.BytesRead,
                        ea.Seconds2Read,
                        0));
                }
            }

            private void WriteWaveData(object sender, BSE.CDDrives.DataReadEventArgs ea)
            {
                if (this.m_audioWriter != null)
                {
#if DEBUG
                    Trace.WriteLine("this.m_audioWriter.Write");
#endif
                    this.m_audioWriter.Write(ea.Data, 0, (int)ea.DataSize);
                }
            }

            private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
            {
                if (this.m_ripThread != null)
                {
                    if (this.m_ripThread.ThreadState == System.Threading.ThreadState.Stopped)
                    {
                        this.m_timer.Stop();
                        if (this.m_bCancelRipping == false)
                        {
                            if (this.TrackRipped != null)
                            {
                                this.TrackRipped(this, new TrackRippingEventArgs(this.m_track));
                            }
                        }
                    }
                }
            }

            #endregion

        }

        #endregion

    }
}