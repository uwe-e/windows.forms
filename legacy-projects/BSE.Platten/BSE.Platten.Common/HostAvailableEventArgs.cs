using System;

namespace BSE.Platten.Common
{
	/// <summary>
	/// Zusammendfassende Beschreibung für CHostAvailableEventArgs.
	/// </summary>
	public class HostAvailableEventArgs : EventArgs
	{
		#region FieldsPrivate
        private BSE.Platten.BO.DatabaseHostAvailability m_databaseHostAvailability;
		#endregion

		#region Properties
        public BSE.Platten.BO.DatabaseHostAvailability DatabaseHostAvailability
        {
            get { return this.m_databaseHostAvailability; }
        }
		#endregion

		#region MethodsPublic
        public HostAvailableEventArgs(BSE.Platten.BO.DatabaseHostAvailability databaseHostAvailability)
        {
            this.m_databaseHostAvailability = databaseHostAvailability;
        }
		#endregion
	}
}
