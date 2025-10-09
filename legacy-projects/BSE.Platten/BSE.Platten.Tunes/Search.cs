using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using BSE.Platten.BO;
using BSE.Platten.Common;

namespace BSE.Platten.Tunes
{
    public partial class Search : UserControl
    {
        #region Events

        public event EventHandler<AlbumSelectEventArgs> AlbumSelecting;
        public event EventHandler<SearchExecuteEventArgs> SearchExecuted;

        #endregion
        
        #region FieldsPrivate

        private BSE.Platten.BO.Environment m_environment;
        private ToolStripMenuItem m_parentToolStripMenuItem;
        private Control m_parentControl;

        #endregion

        #region Properties

        public BSE.Platten.BO.Environment Environment
        {
            get { return this.m_environment; }
            set { this.m_environment = value; }
        }

        public ToolStripMenuItem ParentToolStripMenuItem
        {
            get { return this.m_parentToolStripMenuItem; }
            set { this.m_parentToolStripMenuItem = value; }
        }

        #endregion

        #region MethodsPublic

        public Search()
        {
            InitializeComponent();
            this.m_grdSearch.AutoGenerateColumns = false;
            this.m_grdSearch.AlternatingRowsDefaultCellStyle.BackColor = BSEColors.AlternatingBackColor;
            this.m_grdSearch.DataSource = new SortableCollection<CTrack>();
        }

        public void SetSearchTerm(string strSearchTerm)
        {
            try
            {
                ExecuteSearch(strSearchTerm);
            }
            catch (Exception exception)
            {
                GlobalizedMessageBox.Show(this, exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        
        protected void OnSearchExecuted(object sender, SearchExecuteEventArgs e)
        {
            this.m_tsInnerSearch.SetSearchTerm(e.SearchTerm);
            if (SearchExecuted != null)
            {
                SearchExecuted(sender, e);
            }
        }
        
        #endregion

        #region MethodsPrivate
        
        private void SearchLoad(object sender, EventArgs e)
        {
            this.m_parentControl = this.Parent;
            if (m_parentControl != null)
            {
                m_parentControl.VisibleChanged += new EventHandler(SearchVisibleChanged);
            }
        }

        private void SearchVisibleChanged(object sender, EventArgs e)
        {
            if (this.m_parentToolStripMenuItem != null)
            {
                this.m_parentToolStripMenuItem.Checked = this.Visible;
            }
        }

        private void GridResize(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn dataGridViewColumn in this.m_grdSearch.Columns)
            {
                if (dataGridViewColumn.Equals(this.m_clmnTitle) == true)
                {
                    if (dataGridViewColumn.Width != 0)
                    {
                        int iTotalColumnWidth = 0;
                        int iVerticalScrollBarWidth = 0;

                        foreach (Control dataGridControl in this.m_grdSearch.Controls)
                        {
                            if (dataGridControl is VScrollBar)
                            {
                                if (dataGridControl.Visible)
                                {
                                    iVerticalScrollBarWidth = SystemInformation.VerticalScrollBarWidth;
                                }
                            }
                        }

                        foreach (DataGridViewColumn col in this.m_grdSearch.Columns)
                        {
                            iTotalColumnWidth += col.Width;
                        }

                        dataGridViewColumn.Width += this.m_grdSearch.Width
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
        
        private void GridMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DataGridView.HitTestInfo hitTestInfo = this.m_grdSearch.HitTest(e.X, e.Y);
                if (hitTestInfo.RowIndex >= 0)
                {
                    CTrack track = (CTrack)this.m_grdSearch.Rows[hitTestInfo.RowIndex].DataBoundItem;
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

                        this.m_grdSearch.DoDragDrop(dataObject, DragDropEffects.Copy);
                    }
                }
            }
        }
        
        private void GridMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (this.m_grdSearch.SelectedRows.Count != 0)
                {
                    this.m_ctxHistory.Show(this.m_grdSearch,  new Point(e.X, e.Y));
                }
            }
        }
        
        private void GridKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.T && e.Modifiers == Keys.Control)
            {
                if (this.m_grdSearch.SelectedRows.Count != 0)
                {
                    SelectAlbumClick(sender, e);
                }
            }
        }
        private void SearchExecuting(object sender, SearchExecuteEventArgs e)
        {
            if (String.IsNullOrEmpty(e.SearchTerm) == false)
            {
                ExecuteSearch(e.SearchTerm);
            }
        }
        
        private void SelectAlbumClick(object sender, EventArgs e)
        {
            DataGridViewRow dataGridViewRow = this.m_grdSearch.SelectedRows[0];
            CTrack track = (CTrack)dataGridViewRow.DataBoundItem;
            if (track != null)
            {
                OnAlbumSelecting(new AlbumSelectEventArgs(track.TitelId));
            }
        }

        private void ExecuteSearch(string strSearchTerm)
        {
            if (this.m_environment != null)
            {
                Cursor.Current = Cursors.WaitCursor;
                this.m_grdSearch.DataSource = new SortableCollection<CTrack>();
                try
                {
                    string strConnection = this.m_environment.GetConnectionString();
                    CTunesBusinessObject tunesBusinessObject = new CTunesBusinessObject(strConnection);
                    SortableCollection<CTrack> trackCollection = tunesBusinessObject.GetFullTextSearchCollection(strSearchTerm);
                    if (trackCollection != null)
                    {
                        this.m_grdSearch.DataSource = trackCollection;
                    }
                }
                catch (Exception exception)
                {
                    GlobalizedMessageBox.Show(this, exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    OnSearchExecuted(this, new SearchExecuteEventArgs(strSearchTerm));
                    Cursor.Current = Cursors.Default;
                }
            }
        }

        #endregion

        

        
      
    }
}
