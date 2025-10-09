using System;
using System.Collections.Generic;
using System.Text;
using BSE.Platten.BO;

namespace BSE.Platten.Common
{
    /// <summary>
    /// Thread class for checking the database host and verifying the user privileges.
    /// </summary>
    public class CheckDatabaseHostThread : BSE.Platten.Common.BaseThread
    {
        #region Events
        /// <summary>
        /// Occurs when the Database host was checked.
        /// </summary>
        public event EventHandler<HostAvailableEventArgs> HostChecked;
        #endregion

        #region FieldsPrivate
        private BSE.Platten.BO.Environment m_environment;
        #endregion

        #region MethodsPublic
        /// <summary>
        /// Initializes a new instance of the CheckDataBaseHostThread class.
        /// </summary>
        /// <param name="environment">The <see cref="CEnvironment"/> object.</param>
        public CheckDatabaseHostThread(BSE.Platten.BO.Environment environment)
            : base()
        {
            this.m_environment = environment;
            base.Thread = new System.Threading.Thread(
               new System.Threading.ThreadStart(this.CheckDataBaseHostIfAvailable));
            base.Thread.Start();
        }
        #endregion

        #region MethodsPrivate
        private void CheckDataBaseHostIfAvailable()
        {
            DatabaseHostAvailability databaseHostAvailability = DatabaseHostController.GetDatabaseHostAvailability(this.m_environment);
            if (databaseHostAvailability != null)
            {
                if (this.HostChecked != null)
                {
                    HostChecked(this, new HostAvailableEventArgs(
                        databaseHostAvailability));
                }
            }
        }
        #endregion

    }
}
