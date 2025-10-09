using System;
using System.Collections.Generic;

namespace BSE.Platten.BO
{
	/// <summary>
	/// Zusammenfassung für CImportEventArgs.
	/// </summary>
	public class ImportEventArgs : EventArgs
	{
		#region FieldsPrivate
		
        private List<CTrack> m_trackCollection;
		
		#endregion
		
		#region Properties
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
        public List<CTrack> TrackCollection
        {
            get { return this.m_trackCollection; }
        }
		
		#endregion

		#region MethodsPublic

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
        public ImportEventArgs(List<CTrack> trackCollection)
        {
            this.m_trackCollection = trackCollection;
        }

		#endregion

	}
}
