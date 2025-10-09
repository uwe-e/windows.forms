using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Threading;
using BSE.Platten.BO;

namespace BSE.Platten.Common
{
    public class DatabaseHostController
    {
        #region Events
        /// <summary>
        /// Occurs when the availability of the database host changes.
        /// </summary>
        public static event EventHandler<HostAvailableEventArgs> HostAvailabilityChanged;
        public static event EventHandler<EventArgs> HostAvailabilityInitialized;
        #endregion

        #region FieldsPrivate
        private static HostController m_hostController;
        private static object syncRoot = new Object();
        #endregion

        #region Properties
        /// <summary>
        /// Gets the <see cref="BSE.Platten.BO.Environment"/> object.
        /// </summary>
        public static BSE.Platten.BO.Environment Environment
        {
            get;
            private set;
        }
        /// <summary>
        /// Gets an information whether the database host is available.
        /// </summary>
        public static bool IsHostAvailable
        {
            get
            {
                return m_hostController.IsHostAvailable;
            }
        }
        #endregion

        #region MethodsPublic
        /// <summary>
        /// Initializes the <see cref="DatabaseHostController"/>.
        /// </summary>
        /// <param name="environment"></param>
        public static void Initialize(BSE.Platten.BO.Environment environment)
        {
            if (m_hostController != null)
            {
                m_hostController.HostAvailabilityChanged -= new EventHandler<HostAvailableEventArgs>(OnHostAvailabilityChanged);
            }
            lock (syncRoot)
            {
                Environment = environment;
                m_hostController = new HostController(environment);
                m_hostController.HostAvailabilityChanged += new EventHandler<HostAvailableEventArgs>(OnHostAvailabilityChanged);
                if (HostAvailabilityInitialized != null)
                {
                    HostAvailabilityInitialized(null, EventArgs.Empty);
                }
            }
        }
        /// <summary>
        /// Raises the <see cref="HostAvailabilityChanged"/> event.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see cref="HostAvailableEventArgs"/ that contains the event data. </param>
        public static void OnHostAvailabilityChanged(object sender, HostAvailableEventArgs e)
        {
            if (HostAvailabilityChanged != null)
            {
                HostAvailabilityChanged(sender, e);
            }
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
    }
}
