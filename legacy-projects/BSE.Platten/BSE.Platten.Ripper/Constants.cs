using System;

namespace BSE.Platten.Ripper
{
	/// <summary>
	/// Zusammendfassende Beschreibung f�r CConstants.
	/// </summary>
	public static class Constants
	{
		#region Konstanten
		/// <summary>
		/// Defaultname der zu rippenden Datei
		/// </summary>
		public const string TrackName = "Track";
		/// <summary>
		/// Defaultwert f�r SamplePerSec
		/// </summary>
        public const int WavSamplesPerSecDefaultValue = 44100;
		/// <summary>
		/// Defaultwert f�r BitsPerSample
		/// </summary>
        public const int WavBitsPerSampleDefaultValue = 16;
		/// <summary>
		/// Defaultwert f�r Channels
		/// </summary>
        public const int WavChannelsDefaultValue = 2;
		#endregion
	}
}
