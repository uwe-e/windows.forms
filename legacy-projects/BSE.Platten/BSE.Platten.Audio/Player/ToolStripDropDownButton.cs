using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Layout;
using System.Drawing;

using BSE.Platten.BO;
using System.Diagnostics.CodeAnalysis;

namespace BSE.Platten.Audio
{
    [ToolboxBitmap(typeof(System.Windows.Forms.ToolStripDropDownButton), "ToolStripDropDownButton")]
    public partial class ToolStripDropDownButton : System.Windows.Forms.ToolStripDropDownButton
    {
        #region Events

        public event EventHandler<PlaylistSelectionChangeEventArgs> PlaylistSelectionChanged;

        #endregion
        
        #region FieldsPrivate

        private CPlaylistView m_playListView;

        #endregion

        #region Properties

        public TrackCollection TrackCollection
        {
            get { return this.m_playListView.TrackCollection; }
            set { this.m_playListView.TrackCollection = value; }
        }

        #endregion

        #region MethodsPublic

        public ToolStripDropDownButton() : base()
        {
            InitializeComponent();
            this.m_playListView = new CPlaylistView();
            this.m_playListView.PlaylistSelectionChanged += new EventHandler<PlaylistSelectionChangeEventArgs>(PlayListViewPlaylistSelectionChanged);
        }
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        public void SelectTrack(int iPlaylistPosition)
        {
            this.m_playListView.SelectTrack(iPlaylistPosition);
        }

        #endregion

        #region MethodsProtected

        protected override void OnClick(EventArgs e)
        {
            if (this.m_playListView != null)
            {
                Point startPoint = GetOpenPoint();
                this.m_playListView.Show(startPoint);
            }
        }

        #endregion

        #region MethodsPrivate
        
        private void PlayListViewPlaylistSelectionChanged(object sender, PlaylistSelectionChangeEventArgs e)
        {
            if (this.PlaylistSelectionChanged != null)
            {
                this.PlaylistSelectionChanged(sender, e);
            }
        }
        /// <summary>
        /// Gets the button position by the parent ToolStrip
        /// </summary>
        /// <returns></returns>
        private Point GetOpenPoint()
        {
            if (this.Owner == null)
            {
                return new Point(5, 5);
            }
            int x = 0;
            foreach (ToolStripItem item in this.Parent.Items)
            {
                if (item == this)
                {
                    break;
                }
                x += item.Width;
            }
            int iY = -3;
            int iOwnerTop = this.Owner.RectangleToScreen(this.Owner.ClientRectangle).Top;
            int iSreenHeight = Screen.GetWorkingArea(this.m_playListView).Height;
            if (iSreenHeight - iOwnerTop - this.m_playListView.Height > 0)
            {
                return this.Owner.PointToScreen(new Point(x, iY));
            }
            else
            {
                return this.Owner.PointToScreen(new Point(x, iY - this.Parent.Height - this.m_playListView.Height));
            }
        }

        #endregion
    }
}
