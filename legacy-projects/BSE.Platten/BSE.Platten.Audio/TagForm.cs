using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

using BSE.Platten.BO;
using BSE.Platten.Common;
using System.Globalization;
using BSE.Platten.Audio.Properties;

namespace BSE.Platten.Audio
{
    public partial class TagForm : BaseForm
    {
        #region Events

        public event System.EventHandler ReadingComplete;

        #endregion

        #region Delegates

        private delegate void WriteStatusHandler(CTrack track);
        private delegate void TagReadingCompleteHandler();
        private delegate void WindowCloseHandler();

        #endregion

        #region FieldsPrivate

        private BSE.Platten.BO.Album m_album;
        private TagWriter m_tagWriter;

        #endregion
        
        #region MethodsPublic
        
        public TagForm()
        {
            InitializeComponent();
        }

        public TagForm(BSE.Platten.BO.Album album) : this()
        {
            this.m_album = album;
            if (this.m_album != null)
            {
                this.m_prgsTotalTime.Maximum = 1;
                this.m_prgsTotalTime.Maximum = this.m_album.Tracks.Length;
            }
        }

        #endregion

        #region MethodsPrivate

        private void m_btnCancel_Click(object sender, EventArgs e)
        {
            if (this.m_tagWriter != null)
            {
                this.m_tagWriter.CancelRead();
            }
        }

        private void CTagger_Load(object sender, EventArgs e)
        {
            this.m_tagWriter = new TagWriter(this.m_album,this);
            this.m_tagWriter.CancelReading += new System.EventHandler(this.TagWriterCancelReading);
            this.m_tagWriter.ReadingAborted += new System.EventHandler(this.TagWriterReadingAborted);
            this.m_tagWriter.ReadingComplete += new System.EventHandler(this.TagWriterReadingComplete);
            this.m_tagWriter.TagWritten += new EventHandler<WriteTagEventArgs>(this.TagWriterTagWritten);
        }

        private void CTagger_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.m_tagWriter != null)
            {
                System.Threading.Thread threadWriteTags = this.m_tagWriter.Thread();
                if (threadWriteTags != null && threadWriteTags.IsAlive)
                {
                    this.m_tagWriter.CancelRead();
                }
            }
        }

        private void TagWriterCancelReading(object sender, System.EventArgs e)
        {
            if (this.IsHandleCreated == true)
            {
                this.Invoke(new WindowCloseHandler(WindowCloseEvent));
            }
        }

        private void TagWriterReadingAborted(object sender, System.EventArgs e)
        {
            if (this.IsHandleCreated == true)
            {
                this.Invoke(new WindowCloseHandler(WindowCloseEvent));
            }
        }

        private void TagWriterReadingComplete(object sender, System.EventArgs e)
        {
            if (this.IsHandleCreated == true)
            {
                this.Invoke(new TagReadingCompleteHandler(TagReadingComplete));
            }
        }

        private void TagWriterTagWritten(object sender, WriteTagEventArgs e)
        {
            if (this.IsHandleCreated == true)
            {
                this.Invoke(new WriteStatusHandler(WriteStatusText), e.Track);
            }
        }

        private void WindowCloseEvent()
        {
            this.Close();
        }

        private void WriteStatusText(CTrack track)
        {
            if (track != null)
            {
                string strTagWritten = string.Format(CultureInfo.CurrentUICulture, Resources.IDS_TaggerTagWritten, track.FileFullName);
                if (track.Index == 1)
                {
                    this.m_txtStatus.AppendText(strTagWritten);
                }
                else
                {
                    this.m_txtStatus.AppendText(System.Environment.NewLine + strTagWritten);
                }
                this.m_prgsTotalTime.Value = track.Index;
            }
        }

        private void TagReadingComplete()
        {
            if (this.ReadingComplete != null)
            {
                this.ReadingComplete(this, new System.EventArgs());
            }
            this.Close();
        }

        #endregion

        #region internal class CTag

        internal class TagWriter : IDisposable
        {
            #region EventsPublic

            public event System.EventHandler CancelReading;
            public event System.EventHandler ReadingAborted;
            public event System.EventHandler ReadingComplete;
            public event EventHandler<WriteTagEventArgs> TagWritten;

            #endregion

            #region FieldsPrivate

            private System.Threading.Thread m_threadWriteTags;
            private BSE.Platten.BO.Album m_album;
            private System.Timers.Timer m_timer;
            private bool m_bCancelReading;
            private IWin32Window m_owner;
            // Track whether Dispose has been called.
            private bool m_bDisposed;

            #endregion

            #region MethodsPublic

            public TagWriter(BSE.Platten.BO.Album album,IWin32Window owner)
            {
                this.m_album = album;
                this.m_owner = owner;
                this.m_timer = new System.Timers.Timer();
                this.m_timer.Enabled = true;
                this.m_timer.Elapsed += new System.Timers.ElapsedEventHandler(this.Timer_Elapsed);
                this.m_timer.Start();

                this.m_threadWriteTags =
                    new System.Threading.Thread(
                    new System.Threading.ThreadStart(this.WriteTags));
                this.m_threadWriteTags.Start();
            }
            /// <summary>
            /// Enables to perform final clean up before the object is released from memory.
            /// </summary>
            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
            ~TagWriter()
        {
            Dispose(false);
        }
            public System.Threading.Thread Thread()
            {
                return this.m_threadWriteTags;
            }

            public void CancelRead()
            {
                if (this.m_threadWriteTags.ThreadState == System.Threading.ThreadState.Running)
                {
                    if (this.m_timer != null)
                    {
                        this.m_timer.Stop();
                    }
                    this.m_threadWriteTags.Abort();
                }
                if (this.m_bCancelReading == false)
                {
                    this.m_bCancelReading = true;
                    OnCancelReading(this, new System.EventArgs());
                }
            }

            #endregion

            #region MethodsProtected
            // Dispose(bool disposing) executes in two distinct scenarios.
            // If disposing equals true, the method has been called directly
            // or indirectly by a user's code. Managed and unmanaged resources
            // can be disposed.
            // If disposing equals false, the method has been called by the
            // runtime from inside the finalizer and you should not reference
            // other objects. Only unmanaged resources can be disposed.
            protected void Dispose(bool disposing)
            {
                    // Check to see if Dispose has already been called.
                    if (this.m_bDisposed == false)
                    {
                        // If disposing equals true, dispose all managed
                        // and unmanaged resources.
                        if (disposing)
                        {
                            this.m_timer.Dispose();
                        }
                        // Call the appropriate methods to clean up
                        // unmanaged resources here.
                        // If disposing is false,
                        // only the following code is executed.
                    }
                    // Note disposing has been done.
                    this.m_bDisposed = true;
            }
            protected void OnReadingAborted(object sender, System.EventArgs e)
            {
                this.m_timer.Stop();
                if (ReadingAborted != null)
                {
                    ReadingAborted(this, e);
                }
            }

            protected void OnCancelReading(object sender, System.EventArgs e)
            {
                if (CancelReading != null)
                {
                    CancelReading(this, e);
                }
            }

            #endregion

            #region MethodsPrivate

            private void WriteTags()
            {
                try
                {
                    int iWriteTagsCounter = 0;
                    foreach (BSE.Platten.BO.CTrack track in this.m_album.Tracks)
                    {
                        if (track.FileFullName != null)
                        {
                            System.IO.FileInfo fileInfo = new System.IO.FileInfo(track.FileFullName);
                            if (BSE.Platten.BO.Environment.IsWritableAudioExtension(fileInfo.Extension) == true)
                            {
                                AudioData audioData = new WMFMediaData();
                                audioData.SetAttributeAuthor(track.FileFullName, this.m_album.Interpret);
                                audioData.SetAttributeAlbumTitle(track.FileFullName, this.m_album.Title);
                                audioData.SetAttributeGenre(track.FileFullName, this.m_album.Genre);
                                audioData.SetAttributeYear(track.FileFullName, this.m_album.Year.ToString());
                                if (this.m_album.Cover != null)
                                {
                                    audioData.SetAttributePicture(track.FileFullName, this.m_album.Cover);
                                }
                                audioData.SetAttributeTrackNumber(track.FileFullName, track.TrackNumber.ToString());
                                if (string.IsNullOrEmpty(track.Title) == false)
                                {
                                    audioData.SetAttributeTitle(track.FileFullName, track.Title);
                                }
                                track.Index = iWriteTagsCounter + 1;
                                if (TagWritten != null)
                                {
                                    TagWritten(this, new BSE.Platten.Audio.WriteTagEventArgs(track));
                                }
                            }
                        }
                        iWriteTagsCounter++;
                    }
                }
                catch (System.Runtime.InteropServices.COMException comException)
                {
                    if (this.m_threadWriteTags.ThreadState != System.Threading.ThreadState.AbortRequested)
                    {
                        string strMessage = String.Format(
                            CultureInfo.InvariantCulture,"{0} {1}",
                            comException.Message,
                            Resources.IDS_TaggerComExceptionExtension);
                        
                        GlobalizedMessageBox.Show(this.m_owner,strMessage, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        OnReadingAborted(this, new System.EventArgs());
                    }
                }
                catch (Exception exception)
                {
                    if (this.m_threadWriteTags.ThreadState != System.Threading.ThreadState.AbortRequested)
                    {
                        GlobalizedMessageBox.Show(this.m_owner, exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        OnReadingAborted(this, new System.EventArgs());
                    }
                }
            }

            private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
            {
                if (this.m_threadWriteTags != null)
                {
                    if (this.m_threadWriteTags.ThreadState == System.Threading.ThreadState.Stopped)
                    {
                        this.m_timer.Stop();
                        if (this.ReadingComplete != null)
                        {
                            this.ReadingComplete(this.m_owner, new System.EventArgs());
                        }
                    }
                }
            }

            #endregion
        }

        #endregion
    }
}