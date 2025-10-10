using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace BSE.RemovableDrives
{
	public class RemovableDrive : IComparable
	{
		#region Properties
		/// <summary>
        ///  Gets or sets the name of the volume.
		/// </summary>
        /// <value>
        /// Type: <see cref="System.IO.DriveInfo"/>
        /// The name of the volume.
        /// </value>
        public string VolumeName
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the volume label of a removable drive.
        /// </summary>
        /// <value>
        /// Type: <see cref="System.String"/>
        /// The volume label.
        /// </value>
        public string VolumeLabel
        {
            get;
            set;
        }
		/// <summary>
        /// Gets or sets the information on a drive.
		/// </summary>
        /// <value>
        /// Type: <see cref="System.IO.DriveInfo"/>
        /// The information on a drive.
        /// </value>
        public DriveInfo DriveInfo
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the displayed name of the removable drive.
        /// </summary>
        /// <value>
        /// Type: <see cref="System.String"/>
        /// The displayed name of the removable drive.
        /// </value>
        public string Name
        {
            get { return this.DriveInfo.Name.Substring(0, 2); }
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
			RemovableDrive removableDrive = obj as RemovableDrive;
			if (removableDrive == null)
			{
				throw new ArgumentException();
			}
			return string.Compare(this.VolumeName, removableDrive.VolumeName, StringComparison.OrdinalIgnoreCase);
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
			RemovableDrive removableDrive = obj as RemovableDrive;
			if (removableDrive == null)
			{
				return false;
			}
			if (this.VolumeName.Equals(removableDrive.VolumeName) == false)
			{
				return false;
			}
			return true;
		}
		/// <summary>
        /// Returns a hash code for the specified object.
		/// </summary>
		/// <returns>A hash code for the specified object.
        ///</returns>
        public override int GetHashCode()
		{
			return this.VolumeName.GetHashCode();
		}
		#endregion
	}
}
