using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.ComponentModel;
using System.Drawing;

namespace BSE.Platten.Covers
{
    public class CoverBox : PictureBox
    {
        #region EventsPublic
        /// <summary>
        /// Occurs when the CoverBox is clicked.
        /// </summary>
        [Description("Occurs when the CoverBox is clicked.")]
        public event EventHandler<CoverBoxClickEventArgs> CoverBoxClick;

        #endregion

        #region FieldsPrivate

        private System.Windows.Forms.ToolTip m_ttpCover;
        private BSE.Platten.BO.Album m_album;

        #endregion

        #region MethodsPublic

        public CoverBox()
        {
            this.Size = new System.Drawing.Size(80, 80);
            this.Margin = new Padding(0);
            this.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.m_ttpCover = new System.Windows.Forms.ToolTip();
        }
        /// <summary>
        /// loads the cover image into the CoverBox.
        /// </summary>
        /// <param name="album">A CAlbum object with the cover information</param>
        public void LoadCover(BSE.Platten.BO.Album album)
        {
            this.m_album = album;
            if (this.m_album.Thumbnail != null)
            {
                this.Image = this.m_album.Thumbnail.Clone() as Image;
            }
        }

        #endregion

        #region MethodsProtected
        /// <summary>
        /// Raises the MouseHover event.
        /// </summary>
        /// <param name="e">An EventArgs that contains the event data.</param>
        protected override void  OnMouseHover(EventArgs e)
        {
 	        base.OnMouseHover(e);
            if (this.m_album != null)
            {
                string strYear = String.Empty;
                if (this.m_album.Year > 0)
                {
                    strYear = this.m_album.Year.ToString(CultureInfo.InvariantCulture);
                }
                
                this.m_ttpCover.SetToolTip(this,
                    this.m_album.Interpret + Environment.NewLine +
                    this.m_album.Title + Environment.NewLine +
                    strYear + Environment.NewLine +
                    this.m_album.Medium + Environment.NewLine +
                    this.m_album.Genre);
            }
        }
        /// <summary>
        /// Raises the Click event.
        /// </summary>
        /// <param name="e">An EventArgs that contains the event data.</param>
        protected override void OnClick(System.EventArgs e)
        {
            if (this.m_album != null)
            {
                OnCoverBoxClick(this, new CoverBoxClickEventArgs(this.m_album.AlbumId));
            }
            base.OnClick(e);
        }
        /// <summary>
        /// Raises the CoverBoxClick event.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An EventArgs that contains the event data.</param>
        protected virtual void OnCoverBoxClick(object sender, CoverBoxClickEventArgs e)
        {
            if (this.CoverBoxClick != null)
            {
                this.CoverBoxClick(this, e);
            }
        }

        #endregion
    }
}
