using System;

namespace BSE.Platten.Ripper
{
	/// <summary>
	/// Zusammendfassende Beschreibung für CConstants.
	/// </summary>
	public static class Constants
	{
		#region Konstanten
		/// <summary>
		/// Defaultname der zu rippenden Datei
		/// </summary>
		public const string TrackName = "Track";
		/// <summary>
		/// Defaultwert für SamplePerSec
		/// </summary>
        public const int WavSamplesPerSecDefaultValue = 44100;
		/// <summary>
		/// Defaultwert für BitsPerSample
		/// </summary>
        public const int WavBitsPerSampleDefaultValue = 16;
		/// <summary>
		/// Defaultwert für Channels
		/// </summary>
        public const int WavChannelsDefaultValue = 2;
		#endregion
	}
}
