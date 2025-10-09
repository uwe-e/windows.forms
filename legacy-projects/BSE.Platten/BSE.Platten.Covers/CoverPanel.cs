using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace BSE.Platten.Covers
{
    public class CoverPanel : FlowLayoutPanel
    {
        #region EventsPublic
        /// <summary>
        /// Occurs when a coverbox is clicked.
        /// </summary>
        [Description("Occurs when a coverbox is clicked.")]
        public event EventHandler<CoverBoxClickEventArgs> CoverBoxClick;

        #endregion

        #region MethodsPublic
        /// <summary>
        /// Initializes a new instance of the CoverPanel class.
        /// </summary>
        public CoverPanel()
        {
        }
        /// <summary>
        /// Load the covers into the coverboxes.
        /// </summary>
        /// <param name="albums">A array of CAlbum objects</param>
        public void LoadCoverBoxes(BSE.Platten.BO.Album[] albums)
        {
            int iAlbumsCount = albums.Length;
            this.Controls.Clear();
            if (iAlbumsCount > 0)
            {
                foreach (BSE.Platten.BO.Album album in albums)
                {
                    CoverBox coverBox = new CoverBox();
                    coverBox.LoadCover(album);
                    coverBox.CoverBoxClick += OnCoverBoxClick;
                    this.Controls.Add(coverBox);
                }
                HideCovers();
            }
        }

        #endregion

        #region MethodsProtected
        /// <summary>
        /// Releases all resources used by the Control.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            try
            {
                foreach (Control control in this.Controls)
                {
                    if (control != null)
                    {
                        control.Dispose();
                    }
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
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
        /// <summary>
        /// Raises the Resize event.
        /// </summary>
        /// <param name="eventargs">An EventArgs that contains the event data.</param>
        protected override void OnResize(EventArgs eventargs)
        {
            HideCovers();
            base.OnResize(eventargs);
        }

        #endregion

        #region MethodsPrivate

        private void HideCovers()
        {
            foreach (Control control in this.Controls)
            {
                control.Visible = true;
                if (this.ClientRectangle.Contains(control.Bounds) == false)
                {
                    control.Visible = false;
                }
            }
        }

        #endregion

        
    }
}
