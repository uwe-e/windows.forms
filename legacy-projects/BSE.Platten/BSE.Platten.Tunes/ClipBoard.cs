using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using BSE.Platten.Audio;
using BSE.Platten.BO;
using BSE.Platten.Common;

namespace BSE.Platten.Tunes
{
    public partial class ClipBoard : UserControl, IWPFHost
    {

        #region FieldsPrivate
        private Control m_parentControl;
        private ToolStripMenuItem m_parentToolStripMenuItem;

        #endregion

        #region Properties

        public ToolStripMenuItem ParentToolStripMenuItem
        {
            get { return this.m_parentToolStripMenuItem; }
            set { this.m_parentToolStripMenuItem = value; }
        }
        public object DataContext
        {
            get
            {
                return this.clipboard1.DataContext;
            }
            set
            {
                this.clipboard1.DataContext = value;
            }
        }
        #endregion

        #region MethodsPublic

        public ClipBoard()
        {
            InitializeComponent();
        }

        #endregion

        #region MethodsPrivate

        private void CClipBoard_Load(object sender, EventArgs e)
        {
            this.m_parentControl = this.Parent;
            if (this.m_parentControl != null)
            {
                this.m_parentControl.VisibleChanged += new EventHandler(ClipBoardVisibleChanged);
            }
        }
        
        private void ClipBoardVisibleChanged(object sender, EventArgs e)
        {
            if (this.m_parentToolStripMenuItem != null)
            {
                this.m_parentToolStripMenuItem.Checked = this.Visible;
            }
        }
        #endregion
    }
}
