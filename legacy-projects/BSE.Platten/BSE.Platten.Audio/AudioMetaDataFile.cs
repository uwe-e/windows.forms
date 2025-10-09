using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Globalization;
using BSE.Platten.Audio.Properties;

namespace BSE.Platten.Audio
{
    /// <summary>
    /// Summary description for AudioMetadataFile.
    /// </summary>
    /// <remarks></remarks>
    /// <copyright>Copyright © 2008 BSE</copyright>
    public class AudioMetadataFile : IComparable
    {
        #region FieldsPrivate
        private string m_strFullName;
        private FileInfo m_fileInfo;
        private AudioMetadata m_audioMetaData;
        #endregion

        #region Properties
        /// <summary>
        /// Gets the or sets full path of the directory or file.
        /// </summary>
        /// <value>
        /// Type: <see cref="System.String"/>
        /// A string containing the full path.
        /// </value>
        public string FullName
        {
            get { return this.m_strFullName; }
            set { this.m_strFullName = value; }
        }
        /// <summary>
        /// Gets or sets the FileInfo of a file.
        /// </summary>
        /// <value>
        /// Type: <see cref="System.IO.FileInfo"/>
        /// Provides instance methods for the creation, copying, deletion, moving, and opening of files.
        /// </value>
        public FileInfo FileInfo
        {
            get { return this.m_fileInfo; }
            set { this.m_fileInfo = value; }
        }
        /// <summary>
        /// Gets or sets the MetaData of an audiofile.
        /// </summary>
        /// <value>
        /// Type: <see cref="BSE.Platten.Audio.AudioMetaData"/>
        /// A class containing the meta data of an audiofile.
        /// </value>
        public AudioMetadata AudioMetadata
        {
            get { return this.m_audioMetaData; }
            set { this.m_audioMetaData = value; }
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
            AudioMetadataFile audioMetaDataFile = obj as AudioMetadataFile;
            if (audioMetaDataFile == null)
            {
                throw new ArgumentNullException(
                    string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.IDS_ArgumentNullException, "AudioMetadataFile"));
            }
            return string.Compare(this.m_strFullName, audioMetaDataFile.FullName, StringComparison.OrdinalIgnoreCase);
        }
        /// <summary>
        /// Determines whether the specified AudioMetaDataFile is equal to the current AudioMetaDataFile.
        /// </summary>
        /// <param name="obj">The AudioMetaDataFile to compare with the current AudioMetaDataFile. 
        ///</param>
        /// <returns>true if the specified AudioMetaDataFile is equal to the current AudioMetaDataFile; otherwise, false.
        ///</returns>
        public override bool Equals(object obj)
        {
            AudioMetadataFile audioMetaDataFile = obj as AudioMetadataFile;
            if (audioMetaDataFile == null)
            {
                return false;
            }
            if (this.m_strFullName.Equals(audioMetaDataFile.FullName) == false)
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
