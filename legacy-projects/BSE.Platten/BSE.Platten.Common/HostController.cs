using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Threading;
using BSE.Platten.BO;
using System.Windows;

namespace BSE.Platten.Common
{
    public class HostController
    {
        #region Events
        /// <summary>
        /// Occurs when the HostAvailability has changed.
        /// </summary>
        public EventHandler<HostAvailableEventArgs> HostAvailabilityChanged;
        #endregion

        #region Constants
        #endregion

        #region FieldsPrivate
        private readonly DispatcherTimer m_checkHostTimer;
        private BSE.Platten.BO.Environment m_environment;
        #endregion

        #region Properties
        public bool IsHostAvailable
        {
            get;
            private set;
        }
        #endregion

        #region MethodsPublic
        public HostController(BSE.Platten.BO.Environment environment)
        {
            this.m_environment = environment;
            DatabaseHostAvailability databaseHostAvailability = DatabaseHostController.GetDatabaseHostAvailability(environment);
            if (databaseHostAvailability != null)
            {
                this.IsHostAvailable = databaseHostAvailability.IsAvailable;
            }
            this.m_checkHostTimer = new DispatcherTimer();
            this.m_checkHostTimer.Interval = new TimeSpan(0,0,10);
            this.m_checkHostTimer.Tick += new EventHandler(CheckHostTimerTick);
            this.m_checkHostTimer.Start();
        }
        
        #endregion

        #region MethodsProtected
        #endregion

        #region MethodsPrivate
        private void CheckHostTimerTick(object sender, EventArgs e)
        {
            using (CheckDatabaseHostThread checkDataBaseHostThread = new CheckDatabaseHostThread(
                this.m_environment))
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
                bool isHostAvailable = databaseHostAvailability.IsAvailable;
                if (isHostAvailable.Equals(this.IsHostAvailable) == false)
                {
                    this.IsHostAvailable = isHostAvailable;
                    if (this.HostAvailabilityChanged != null)
                    {
                        this.HostAvailabilityChanged(this, e);
                    }
                }
            }
        }
        #endregion
    }
}
