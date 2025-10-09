using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using BSE.Platten.BO;
using System.Diagnostics.CodeAnalysis;

namespace BSE.Platten.Audio
{
    public partial class CPlaylistView : UserControl
    {
        #region Events

        public event EventHandler<PlaylistSelectionChangeEventArgs> PlaylistSelectionChanged;

        #endregion
        
        #region FieldsPrivate

        private ContextForm m_contextForm;
        private TrackCollection m_trackCollection;

        #endregion

        #region Properties

        public TrackCollection TrackCollection
        {
            get { return this.m_trackCollection; }
            set
            {
                this.m_trackCollection = value;
                LoadTracksIntoListView();
            }
        }

        #endregion

        #region MethodsPublic
        
        public CPlaylistView()
        {
            InitializeComponent();
            this.m_pnlBase.Padding = new Padding(3);
            this.m_trackCollection = new TrackCollection();
        }

        public void Show(Point location)
        {
            this.m_contextForm = new ContextForm();
            this.m_contextForm.ShowInTaskbar = false;
            this.m_contextForm.SetControl(this);
            this.m_contextForm.ClientSize = this.ClientSize;
            Rectangle rectangleBounds = this.Bounds;
            rectangleBounds.X = location.X;
            rectangleBounds.Y = location.Y;
            if (Screen.GetWorkingArea(this).Contains(rectangleBounds) == false)
            {
                location.X = Screen.GetWorkingArea(this).Width - this.Bounds.Width;

            }
            this.m_contextForm.Show(this, location);
            this.m_lstvPlaylist.Focus();
        }
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        public void SelectTrack(int iPlaylistPosition)
        {
            foreach (ListViewItem listViewItem in this.m_lstvPlaylist.SelectedItems)
            {
                listViewItem.Selected = false;
            }
            if (iPlaylistPosition < this.m_lstvPlaylist.Items.Count)
            {
                ListViewItem listViewItem = this.m_lstvPlaylist.Items[iPlaylistPosition];
                if (listViewItem != null)
                {
                    listViewItem.EnsureVisible();
                    listViewItem.Selected = true;
                }
            }
        }

        #endregion

        #region MethodsPrivate

        private void OnPlaylistSelectionChanged(object sender, PlaylistSelectionChangeEventArgs e)
        {
            if (this.PlaylistSelectionChanged != null)
            {
                this.PlaylistSelectionChanged(sender, e);
            }
        }

        private void PlayListViewLoad(object sender, EventArgs e)
        {
            PlaylistResize(sender, e);
        }
        
        private void PlaylistResize(object sender, EventArgs e)
        {
            this.m_clmnTrack.Width =
                this.m_lstvPlaylist.Width
                - SystemInformation.VerticalScrollBarWidth
                - this.m_clmnDuration.Width
                - 4 * SystemInformation.BorderSize.Width;
        }
        
        private void PlaylistMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ListViewItem listViewItem = this.m_lstvPlaylist.GetItemAt(e.X, e.Y);
                if (listViewItem != null)
                {
                    OnPlaylistSelectionChanged(sender, new PlaylistSelectionChangeEventArgs(listViewItem.Index));
                }
            }
        }
        
        private void PlaylistKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ListViewItem listViewItem = this.m_lstvPlaylist.SelectedItems[0];
                if (listViewItem != null)
                {
                    OnPlaylistSelectionChanged(sender, new PlaylistSelectionChangeEventArgs(listViewItem.Index));
                }
            }
        }
        
        private void LoadTracksIntoListView()
        {
            this.m_lstvPlaylist.Items.Clear();
            if (this.m_trackCollection != null)
            {
                System.Collections.IEnumerator enumerator = this.m_trackCollection.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    CTrack track = enumerator.Current as CTrack;
                    if (track != null)
                    {
                        ListViewItem listViewItem = new ListViewItem();
                        listViewItem.Text = track.Title;
                        listViewItem.SubItems.Add(track.Duration.ToString());
                        listViewItem.Tag = track;

                        this.m_lstvPlaylist.Items.Add(listViewItem);
                    }
                }
            }
        }
        #endregion
    }
}
