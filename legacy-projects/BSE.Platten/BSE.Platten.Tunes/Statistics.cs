using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BSE.Platten.Common;
using BSE.Platten.BO;

namespace BSE.Platten.Tunes
{
    /// <summary>
    /// Used to parenting the <see cref="BSE.Platten.Statistik.CStatistik"/> object.
    /// </summary>
    public partial class Statistics : BaseForm
    {
        #region Properties
        /// <summary>
        /// Gets or sets the connectionstring to the database.
        /// </summary>
        public string ConnectionString
        {
            get { return this.m_statistik.ConnectionString; }
            set { this.m_statistik.ConnectionString = value; }
        }
        #endregion

        #region MethodsPublic
        /// <summary>
        /// Initializes a new instance of the <see cref="Statistics"/> class.
        /// </summary>
        public Statistics()
        {
            InitializeComponent();
        }
        #endregion
    }
}