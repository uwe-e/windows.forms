using System;

namespace BSE.Platten.Common
{
	/// <summary>
    /// Summary description for ThreadEventArgs.
	/// </summary>
	/// <remarks></remarks>
	/// <copyright>Copyright © 2009 BSE</copyright>
	public class ThreadEventArgs : EventArgs
	{
		#region FieldsPrivate
		private object m_userState;
		#endregion

		#region Properties
		/// <summary>
		/// Exposes instance methods for creating, moving, and enumerating through directories and subdirectories.
		/// </summary>
		public object UserState
		{
			get
			{
				return this.m_userState;
			}
		}

		#endregion

		#region MethodsPublic
		/// <summary>
        /// Initializes a new instance of the ThreadEventArgs class.
		/// </summary>
		public ThreadEventArgs(object userState)
		{
			this.m_userState = userState;
		}
		#endregion

	}
}
