using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Globalization;
using BSE.Platten.Audio.Properties;

namespace BSE.Platten.Audio
{
	public class AudioDirectory : IComparable
	{
		#region FieldsPrivate
		private DirectoryInfo m_directoryInfo;
		private string m_strFullName;
		#endregion

		#region Properties
		public string FullName
		{
			get { return this.m_strFullName; }
			set { this.m_strFullName = value; }
		}
		public DirectoryInfo DriveInfo
		{
			get { return m_directoryInfo; }
			set { m_directoryInfo = value; }
		}
		#endregion

		#region MethodsPublic
		/// <summary>
		/// Compares the current instance with another object of the same type.
		/// </summary>
		/// <param name="obj">An object to compare with this instance.</param>
		/// <returns>A 32-bit signed integer that indicates the relative order of the comparands.</returns>
		public virtual int CompareTo(object obj)
		{
			AudioDirectory audioDirectory = obj as AudioDirectory;
			if (audioDirectory == null)
			{
                throw new ArgumentNullException(
                    string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.IDS_ArgumentNullException, "AudioDirectory"));
			}
			return string.Compare(this.m_strFullName, audioDirectory.FullName, StringComparison.OrdinalIgnoreCase);
		}
		/// <summary>
		/// Determines whether the specified RemovableDrive is equal to the current RemovableDrive.
		/// </summary>
		/// <param name="obj">The RemovableDrive to compare with the current RemovableDrive. 
		///</param>
		/// <returns>true if the specified RemovableDrive is equal to the current RemovableDrive; otherwise, false.
		///</returns>
		public override bool Equals(object obj)
		{
			AudioDirectory audioDirectory = obj as AudioDirectory;
			if (audioDirectory == null)
			{
				return false;
			}
			if (this.m_strFullName.Equals(audioDirectory.FullName) == false)
			{
				return false;
			}
			return true;
		}
		public override int GetHashCode()
		{
			return this.m_strFullName.GetHashCode();
		}

		#endregion
	}
}
