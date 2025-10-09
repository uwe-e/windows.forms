using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

using BSE.Platten.BO;
using System.Globalization;
using BSE.Platten.Common.Properties;

namespace BSE.Platten.Common
{
    /// <summary>
    /// Represents a panel in a StatusStrip control that checks the availability of the database host.
    /// </summary>
    public partial class CToolStripStatusLabelCheckDB : ToolStripStatusLabel
    {
        #region Events
        /// <summary>
        /// Occurs when the HostAvailability has changed.
        /// </summary>
        public event EventHandler<HostAvailableEventArgs> HostAvailabilityChanged;

        #endregion

        #region FieldsPrivate

        private System.Windows.Forms.Timer m_timerCheckDb;
        private bool m_bHostIsAvailable;

        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the environment object for the application
        /// </summary>
        public BSE.Platten.BO.Environment Environment
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the DatabaseHostAvailability object for the application
        /// </summary>
        public DatabaseHostAvailability DatabaseHostAvailability
        {
            get;
            set;
        }
        #endregion

        #region MethodsPublic
        /// <summary>
        /// Initializes a new instance of the CToolStripStatusLabelCheckDB class.
        /// </summary>
        public CToolStripStatusLabelCheckDB()
        {
            InitializeComponent();
            this.Image = Properties.Resources.Network;
            this.Enabled = false;
            this.m_timerCheckDb = new System.Windows.Forms.Timer();
            this.m_timerCheckDb.Interval = 10000;
            this.m_timerCheckDb.Tick += new System.EventHandler(this.TimerCheckDbTick);
        }
        /// <summary>
        /// Initializes a new instance of the CToolStripStatusLabelCheckDB class.
        /// </summary>
        /// <param name="environment">The <see cref="CEnvironment"/> object.</param>
        public CToolStripStatusLabelCheckDB(BSE.Platten.BO.Environment environment)
            : this()
        {
            if (environment == null)
            {
                throw new ArgumentNullException(
                    string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.IDS_ArgumentNullException, "environment"));
            }
            this.Environment = environment;
        }
        /// <summary>
        /// Checks whether the database host is available.
        /// </summary>
        /// <param name="environment">The <see cref="CEnvironment"/> object.</param>
        /// <returns>True, if the database is available else false.</returns>
        public bool IsHostAvailable(BSE.Platten.BO.Environment environment)
        {
            this.Environment = environment;
            if (this.m_timerCheckDb.Enabled == false)
            {
                this.m_timerCheckDb.Enabled = true;
            }
            DatabaseHostAvailability databaseHostAvailability = GetDatabaseHostAvailability(this.Environment);
            if (databaseHostAvailability != null)
            {
                this.DatabaseHostAvailability = databaseHostAvailability;
                this.m_bHostIsAvailable = databaseHostAvailability.IsAvailable;
                SetLabelProperties(databaseHostAvailability);
                return this.m_bHostIsAvailable;
            }
            return false;
        }
        /// <summary>
        /// Gets a <see cref="DatabaseHostAvailability"/> objects with the availability properties for the database.
        /// </summary>
        /// <param name="environment">The <see cref="CEnvironment"/> object.</param>
        /// <returns>The <see cref="DatabaseHostAvailability"/> object with the database properties</returns>
        public static DatabaseHostAvailability GetDatabaseHostAvailability(BSE.Platten.BO.Environment environment)
        {
            DatabaseHostAvailability databaseHostAvailability = null;
            CUserGrant userGrant = null;
            if (environment != null)
            {
                string strConnection = environment.GetConnectionString();
                CHostBusinessObject hostBusinessObject = new CHostBusinessObject(strConnection);
                bool bHostIsAvailable = hostBusinessObject.IsHostAvailable();
                if (bHostIsAvailable)
                {
                    CBSEAdminBusinessObject adminBusinessObject = new CBSEAdminBusinessObject(strConnection);
                    userGrant = adminBusinessObject.GetUserGrant(environment.UserName);
                }

                databaseHostAvailability = new DatabaseHostAvailability
                {
                    IsAvailable = bHostIsAvailable,
                    UserGrant = userGrant
                };
            }
            return databaseHostAvailability;
        }

        #endregion

        #region MethodsPrivate

        private void TimerCheckDbTick(object sender, System.EventArgs e)
        {
            using (CheckDatabaseHostThread checkDataBaseHostThread = new CheckDatabaseHostThread(
                this.Environment))
            {
                checkDataBaseHostThread.HostChecked += new EventHandler<HostAvailableEventArgs>(CheckDataBaseHostChecked);
            }
        }

        private void CheckDataBaseHostChecked(object sender, HostAvailableEventArgs e)
        {
            using (CheckDatabaseHostThread checkDataBaseHostThread = sender as CheckDatabaseHostThread)
            {
                if (checkDataBaseHostThread != null)
                {
                    checkDataBaseHostThread.HostChecked -= new EventHandler<HostAvailableEventArgs>(CheckDataBaseHostChecked);
                }
            }
            DatabaseHostAvailability databaseHostAvailability = e.DatabaseHostAvailability;
            if (databaseHostAvailability != null)
            {
                bool bHostIsAvailable = databaseHostAvailability.IsAvailable;
                if (bHostIsAvailable.Equals(this.m_bHostIsAvailable) == false)
                {
                    this.m_bHostIsAvailable = bHostIsAvailable;
                    SetLabelProperties(databaseHostAvailability);
                    if (this.HostAvailabilityChanged != null)
                    {
                        this.HostAvailabilityChanged(this, e);
                    }
                }
            }
        }

        private void SetLabelProperties(DatabaseHostAvailability databaseHostAvailability)
        {
            if (databaseHostAvailability != null)
            {
                this.Enabled = databaseHostAvailability.IsAvailable;
                this.Environment.UserGrant = databaseHostAvailability.UserGrant;
                string strText = String.Format(CultureInfo.CurrentUICulture,
                        Properties.Resources.IDS_ToolStripStatusLabelCheckDBHostAndPort,
                        this.Environment.GetDatabaseHost(),
                        this.Environment.GetDatabasePort());
                this.Text = strText;
            }
        }

        #endregion
    }
}
