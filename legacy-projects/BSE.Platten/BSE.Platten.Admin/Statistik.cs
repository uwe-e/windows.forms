using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BSE.Platten.Admin
{
    /// <summary>
    /// Used to parenting the <see cref="BSE.Platten.Statistic.Statistic"/> object.
    /// </summary>
    public partial class Statistic : BSE.Platten.Admin.BaseForm
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
        public Statistic()
        {
            InitializeComponent();
        }
        #endregion
    }
}

