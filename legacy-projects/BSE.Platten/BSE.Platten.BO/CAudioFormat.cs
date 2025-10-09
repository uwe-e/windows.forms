using System;

namespace BSE.Platten.BO
{
	/// <summary>
	/// Zusammenfassung für CAudioFormat.
	/// </summary>
	public class CAudioFormat : ICloneable
	{
		#region Enumerationen
		
		public enum AudioFormat
		{
			/// <summary>
			/// Audioformat Wav
			/// </summary>
            Wav,
            /// <summary>
            /// Audioformat Mp3
            /// </summary>
			Mp3,
            /// <summary>
            /// Audioformat Wma
            /// </summary>
			Wma
		}
		
		#endregion

		#region FieldsPrivate
		
		private CAudioFormat.AudioFormat m_eUsedAudioFormat;
        private string m_strExtension;
        private string m_strFormatDescription;
		
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the used audioformat
		/// </summary>
		public CAudioFormat.AudioFormat UsedAudioFormat
		{
			get {return m_eUsedAudioFormat;}
			set {m_eUsedAudioFormat = value;}
		}
        /// <summary>
        /// Gets or sets the description of the audioformat.
        /// </summary>
		public string Description
		{
			get {return m_strFormatDescription;}
			set {m_strFormatDescription = value;}
		}
		/// <summary>
        /// Gets or sets the string representing the extension part of the file.
		/// </summary>
        public string Extension
        {
            get { return m_strExtension; }
            set { m_strExtension = value; }
        }
		#endregion

		#region MethodsPublic

		public CAudioFormat()
		{
		}

		public object Clone()
		{
			CAudioFormat audioFormat = new CAudioFormat();
			audioFormat.UsedAudioFormat = this.m_eUsedAudioFormat;
			audioFormat.Description = this.m_strFormatDescription;
			
			return (object)audioFormat;
		}

		#endregion

	}
}
