using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using BSE.Platten.BO;
using BSE.Platten.Common;
using BSE.Platten.Audio;

namespace BSE.Platten.Tunes
{
    public partial class History : UserControl
    {
        #region Delegates

        private delegate void delegateUpdateHistory(SortableCollection<CHistoryTrack> trackCollection);

        #endregion

        #region Events

        public event EventHandler<AlbumSelectEventArgs> AlbumSelecting;

        #endregion

        #region FieldsPrivate

        private BSE.Platten.BO.Environment m_environment;

        #endregion

        #region Properties

        public BSE.Platten.BO.Environment Environment
        {
            get { return this.m_environment; }
            set { this.m_environment = value; }
        }

        #endregion

        #region MethodsPublic

        public History()
        {
            InitializeComponent();
            this.m_grdHistory.AutoGenerateColumns = false;
            this.m_grdHistory.AlternatingRowsDefaultCellStyle.BackColor = BSE.Platten.Common.BSEColors.AlternatingBackColor;
            this.m_grdHistory.DataSource = new SortableCollection<CTrack>();
        }

        public void UpdateHistory(SortableCollection<CHistoryTrack> trackCollection)
        {
            if (trackCollection != null)
            {
                try
                {
                    this.Invoke(new delegateUpdateHistory(this.UpdateDataGridView),
                        new object[] { trackCollection });
                }
                catch (Exception exception)
                {
                    GlobalizedMessageBox.Show(this,exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void UpdateHistory(CTrack currentTrack, BSE.Platten.Audio.PlayMode eMode)
        {
            if ((this.m_environment != null) && (currentTrack != null))
            {
                HistoryUpdateData updateData = new HistoryUpdateData();
                updateData.Environment = this.m_environment;
                updateData.HistoryData = new HistoryData();
                updateData.HistoryData.UserName = this.m_environment.UserName;
                updateData.HistoryData.TitelId = currentTrack.TitelId;
                updateData.HistoryData.LiedId = currentTrack.LiedId;
                updateData.HistoryData.AppId = (int)eMode;
                if (eMode == PlayMode.Playlist)
                {
                    updateData.HistoryData.AppId = (int)PlayMode.Song;
                }
                updateData.HistoryData.PlayedAt = DateTime.Now;

                m_backgroundWorkerUpdate.RunWorkerAsync(updateData);
            }
        }
        #endregion

        #region MethodsProtected

        protected void OnAlbumSelecting(AlbumSelectEventArgs e)
        {
            if (AlbumSelecting != null)
            {
                AlbumSelecting(this, e);
            }
        }

        #endregion

        #region MethodsPrivate

        private void UpdateDataGridView(SortableCollection<CHistoryTrack> trackCollection)
        {
            if (trackCollection != null)
            {
                this.m_grdHistory.DataSource = trackCollection;
            }
        }
        
        private void GridMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DataGridView.HitTestInfo hitTestInfo = this.m_grdHistory.HitTest(e.X, e.Y);
                if (hitTestInfo.RowIndex >= 0)
                {
                    CTrack track = this.m_grdHistory.Rows[hitTestInfo.RowIndex].DataBoundItem as CTrack;
                    if (track != null)
                    {
                        PlayListDragDropData playListDragDropData = new PlayListDragDropData();
                        if (track.LiedId == 0)
                        {
                            playListDragDropData.Id = track.TitelId;
                            playListDragDropData.PlayListDragDropMode = PlayList.PlayListDragDropMode.Albums;
                        }
                        if (track.LiedId > 0)
                        {
                            playListDragDropData.Id = track.LiedId;
                            playListDragDropData.PlayListDragDropMode = PlayList.PlayListDragDropMode.PlayList;
                        }
                        BSE.Windows.Forms.CDraggedListViewObjects draggedListViewObjects
                            = new BSE.Windows.Forms.CDraggedListViewObjects(new BSE.Windows.Forms.ListView(DragDropEffects.Move));
                        draggedListViewObjects.DragObjects.Add(playListDragDropData);
                        BSE.Windows.Forms.CDataObject dataObject = new BSE.Windows.Forms.CDataObject(draggedListViewObjects);

                        this.m_grdHistory.DoDragDrop(dataObject, DragDropEffects.Copy);
                    }
                }
            }
        }
        
        private void GridMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (this.m_grdHistory.SelectedRows.Count != 0)
                {
                    this.m_ctxHistory.Show(this.m_grdHistory, new Point(e.X, e.Y));
                }
            }
        }
        
        private void GridKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.T && e.Modifiers == Keys.Control)
            {
                if (this.m_grdHistory.SelectedRows.Count != 0)
                {
                    SelectAlbumClick(sender, e);
                }
            }
        }
        
        private void GridResize(object sender, EventArgs e)
        {
            
            foreach (DataGridViewColumn dataGridViewColumn in this.m_grdHistory.Columns)
            {
                if (dataGridViewColumn.Equals(this.m_clmnTitle) == true)
                {
                    if (dataGridViewColumn.Width != 0)
                    {
                        int iTotalColumnWidth = 0;
                        int iVerticalScrollBarWidth = 0;

                        foreach (Control dataGridControl in this.m_grdHistory.Controls)
                        {
                            if (dataGridControl is VScrollBar)
                            {
                                if (dataGridControl.Visible)
                                {
                                    iVerticalScrollBarWidth = SystemInformation.VerticalScrollBarWidth;
                                }
                            }
                        }

                        foreach (DataGridViewColumn col in this.m_grdHistory.Columns)
                        {
                            iTotalColumnWidth += col.Width;
                        }

                        dataGridViewColumn.Width += this.m_grdHistory.Width
                            - iTotalColumnWidth
                            - iVerticalScrollBarWidth
                            - dataGridViewColumn.DividerWidth;

                        if (dataGridViewColumn.Width < 1)
                        {
                            dataGridViewColumn.Width = 1;
                        }
                    }
                }
            }
        }
        
        private void SelectAlbumClick(object sender, EventArgs e)
        {
            DataGridViewRow dataGridViewRow = this.m_grdHistory.SelectedRows[0];
            CTrack track = dataGridViewRow.DataBoundItem as CTrack;
            if (track != null)
            {
                OnAlbumSelecting(new AlbumSelectEventArgs(track.TitelId));
            }
        }
        private void BackgroundWorkerUpdateDoWork(object sender, DoWorkEventArgs e)
        {
            HistoryUpdateData updateData = e.Argument as HistoryUpdateData;
            if ((updateData != null) && (updateData.Environment != null))
            {
                CTunesBusinessObject tunesBusinessObject = new CTunesBusinessObject(
                    updateData.Environment.GetConnectionString());
                try
                {
                    e.Result = tunesBusinessObject.GetHistoryTrackCollection(
                        updateData.HistoryData);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        private void BackgroundWorkerUpdateRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                GlobalizedMessageBox.Show(this, e.Error.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SortableCollection<CHistoryTrack> tracksCollection = e.Result as SortableCollection<CHistoryTrack>;
                //this.m_grdHistory.Invoke(
                //    new delegateUpdateHistory(this.UpdateDataGridView),
                //    new object[] { tracksCollection });
            }
        }

        internal class HistoryUpdateData
        {
            #region FieldsPrivate
            private BSE.Platten.BO.Environment m_environment;
            private BSE.Platten.BO.HistoryData m_historyData;
            #endregion

            #region Properties
            public BSE.Platten.BO.Environment Environment
            {
                get { return this.m_environment; }
                set { this.m_environment = value; }
            }
            public BSE.Platten.BO.HistoryData HistoryData
            {
                get { return this.m_historyData; }
                set { this.m_historyData = value; }
            }
            #endregion
        }

        #endregion
    }
}
