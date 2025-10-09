using System;

using BSE.Configuration;
using System.Globalization;
using BSE.Platten.BO.Properties;
using System.Collections.ObjectModel;

namespace BSE.Platten.BO
{
	/// <summary>
	/// This class contains all environment settings for the application.
	/// </summary>
	public class Environment
	{
        #region Constants

        public const string BSEApplicationDataPath = "BSE";
        private const string m_strAssemblySettingsPart = "Settings";

        #endregion

        #region FieldsPrivate

        private string m_strUserName;
        private string m_strDataBaseHost;
        private int m_iDataBasePort;
        private BSE.Configuration.Configuration m_configuration;
        private static Collection<string> m_writableAudioFormats;
		#endregion
		
		#region Properties

        /// <summary>
        /// Gets or sets the username for the application.
        /// </summary>
        public string UserName
        {
            get
            {
                if (String.IsNullOrEmpty(this.m_strUserName) == true)
                {
                    this.m_strUserName = System.Environment.UserName;
                }
                return this.m_strUserName;
            }
            set { this.m_strUserName = value; }
        }
        /// <summary>
        /// Gets or sets the password for the application.
        /// </summary>
        public string Password
        {
            set;
            get;
        }
        /// <summary>
        /// Gets or sets the database host.
        /// </summary>
        public string DataBaseHost
        {
            get
            {
                if (String.IsNullOrEmpty(this.m_strDataBaseHost) == true)
                {
                    this.m_strDataBaseHost = GetDatabaseHost();
                }
                return this.GetDatabaseHost();
            }
            set
            {
                this.m_strDataBaseHost = value;
            }
        }
        /// <summary>
        /// Gets or sets the TCP/IP port of the database host.
        /// </summary>
        public int DataBasePort
        {
            set { this.m_iDataBasePort = value; }
            get
            {
                if (this.m_iDataBasePort == 0)
                {
                    this.m_iDataBasePort = GetDatabasePort();
                }
                return this.m_iDataBasePort;
            }
        }
        /// <summary>
        /// Gets or sets the database privileges for the current user.
        /// </summary>
        public CUserGrant UserGrant
        {
            get;
            set;
        }
        /// <summary>
        /// Gets a <see cref="collection<string>"/> with the writable formats for
        /// editing the header attributes of audio files.
        /// </summary>
        public static Collection<string> WritableAudioExtensions
        {
            get
            {
                if (m_writableAudioFormats == null)
                {
                    m_writableAudioFormats = GetWritableAudioExtensions();
                }
                return m_writableAudioFormats;
            }
        }
		#endregion

		#region MethodsPublic
        /// <summary>
        /// Construktor von CEnvironment
        /// </summary>
		public Environment()
		{
		}
        /// <summary>
        /// Konstruktor von CEnvironment
        /// </summary>
        /// <param name="configuration">A <see cref="BSE.Configuration.Configuration"/> object with the application settings.</param>
        public Environment(BSE.Configuration.Configuration configuration)
            : this()
        {
            this.m_configuration = configuration;
        }
        /// <summary>
        /// Gets the configuration of the application.
        /// </summary>
        /// <returns>Konfiguration als BSE.Configuration.CConfiguration</returns>
        public BSE.Configuration.Configuration GetConfiguration()
        {
            BSE.Configuration.Configuration configuration = null;
            if (this.m_configuration == null)
            {
                throw new ArgumentNullException(
                    string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.IDS_ArgumentException,
                    "configuration"));
            }
            else
            {
                configuration = this.m_configuration;
            }
            return configuration;
        }
        /// <summary>
        /// Gets the tcp/ip port of the database host.
        /// </summary>
        /// <returns>The tcp/ip port of the database host.</returns>
        public int GetDatabasePort()
        {
            if (this.m_configuration == null)
            {
                throw new ArgumentNullException(
                    string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.IDS_ArgumentException,
                    "configuration"));
            }
            return GetDatabasePort(this.m_configuration);
        }
        /// <summary>
        /// Gets the tcp/ip port of the database host.
        /// </summary>
        /// <param name="configuration"><see cref="BSE.Configuration.Configuration"/> object with the application settings.</param>
        /// <returns>The tcp/ip port of the database host.</returns>
        public static int GetDatabasePort(BSE.Configuration.Configuration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(
                    string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.IDS_ArgumentException,
                    "configuration"));
            }
            
            int iDataBasePort = 3306;
            try
            {
                BSE.Configuration.VisualObject visualObject = new BSE.Configuration.VisualObject();
                visualObject.Element = "databaseport";
                visualObject.Description = Resources.IDS_ConfigurationNoTcpIpPortLabel;
                visualObject.VisualObjectType = BSE.Configuration.VisualObjectType.OpenNumericUpDown;
                visualObject.ErrorMessage = string.Format(CultureInfo.CurrentUICulture, Resources.IDS_ConfigurationNoTcpIpPortException, iDataBasePort);

                string strDataBasePort = configuration.GetValue(BSE.Configuration.Configuration.VisualObjectsElementName, visualObject).ToString();
                if (String.IsNullOrEmpty(strDataBasePort) == false)
                {
                    iDataBasePort = Convert.ToInt32(strDataBasePort,CultureInfo.InvariantCulture);
                }
                return iDataBasePort;
            }
            catch (BSE.Configuration.ConfigurationValueNotFoundException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Gets the name of the database host.
        /// </summary>
        /// <returns>The name of the database host.</returns>
        public string GetDatabaseHost()
        {
            if (this.m_configuration == null)
            {
                throw new ArgumentNullException(
                    string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.IDS_ArgumentException,
                    "configuration"));
            }
            return GetDatabaseHost(this.m_configuration);
        }
        /// <summary>
        /// Gets the name of the database host.
        /// </summary>
        /// <param name="configuration"><see cref="BSE.Configuration.Configuration"/> object with the application settings.</param>
        /// <returns>The name of the database host.</returns>
        public static string GetDatabaseHost(BSE.Configuration.Configuration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(
                    string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.IDS_ArgumentException,
                    "configuration"));
            }
            
            string strDataBaseHost = null;
            try
            {
                BSE.Configuration.VisualObject visualObject = new BSE.Configuration.VisualObject();
                visualObject.Element = "databasehost";
                visualObject.Description = Resources.IDS_ConfigurationNoDataBaseLabel;
                visualObject.VisualObjectType = BSE.Configuration.VisualObjectType.OpenTextBox;
                visualObject.ErrorMessage = Resources.IDS_ConfigurationNoDataBaseException;

                strDataBaseHost = configuration.GetValue(BSE.Configuration.Configuration.VisualObjectsElementName, visualObject).ToString();

                return strDataBaseHost;
            }
            catch (BSE.Configuration.ConfigurationValueNotFoundException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Gets the connectionstring for the database.
        /// </summary>
        /// <returns>Connectionstring</returns>
        public string GetConnectionString()
        {
            if (this.m_configuration == null)
            {
                throw new ArgumentNullException(
                    string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.IDS_ArgumentException,
                    "configuration"));
            }
            return GetConnectionString(this.m_configuration);
        }
        /// <summary>
        /// Gets the connectionstring for the database.
        /// </summary>
        /// <param name="configuration"><see cref="BSE.Configuration.Configuration"/> object with the application settings.</param>
        /// <returns>The connectionstring for the database</returns>
        public string GetConnectionString(BSE.Configuration.Configuration configuration)
        {
            string strConnectionString = null;
            string strPassword = string.Empty;
            if (String.IsNullOrEmpty(this.Password) == false)
            {
                strPassword = this.Password;
            }

            strConnectionString = string.Format(CultureInfo.InvariantCulture, "server={0};user id={1}; password={2}; Port={3}; database=platten; pooling=false",
                this.DataBaseHost,
                this.UserName,
                strPassword,
                this.DataBasePort);

            return strConnectionString;
        }
        /// <summary>
        /// Gets the name of the root directory for the audio files.
        /// </summary>
        /// <returns>The name of the root directory.</returns>
        public string GetAudioHomeDirectory()
        {
            if (this.m_configuration == null)
            {
                throw new ArgumentNullException(
                    string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.IDS_ArgumentException,
                    "configuration"));
            }
            return GetAudioHomeDirectory(this.m_configuration);
        }
        /// <summary>
        /// Gets the name of the root directory for the audio files.
        /// </summary>
        /// <param name="configuration"><see cref="BSE.Configuration.Configuration"/> object with the application settings.</param>
        /// <returns>The name of the root directory.</returns>
        public static string GetAudioHomeDirectory(BSE.Configuration.Configuration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(
                    string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.IDS_ArgumentException,
                    "configuration"));
            }
            
            string strAudioHomeDirectory = null;
            try
            {
                BSE.Configuration.VisualObject visualObject = new BSE.Configuration.VisualObject();
                visualObject.Element = "dirmp3";
                visualObject.Description = Resources.IDS_ConfigurationNoAudioDirectoryLabel;
                visualObject.VisualObjectType = BSE.Configuration.VisualObjectType.OpenFolderBrowseDialog;
                visualObject.ErrorMessage = Resources.IDS_ConfigurationNoAudioDirectoryException;

                strAudioHomeDirectory = configuration.GetValue(BSE.Configuration.Configuration.VisualObjectsElementName, visualObject).ToString();

                if (strAudioHomeDirectory.EndsWith(System.IO.Path.DirectorySeparatorChar.ToString()) == false)
                {
                    strAudioHomeDirectory += System.IO.Path.DirectorySeparatorChar;
                }
                return strAudioHomeDirectory;
            }
            catch (BSE.Configuration.ConfigurationValueNotFoundException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Removes all characters that are not allowed from the folder name.
        /// </summary>
        /// <param name="strFolderName">>The name of the folder.</param>
        /// <returns>The name of the folder without all not allowed characters.</returns>
        public static string RemoveInvalidFolderChars(string strFolderName)
        {
            char[] invalidFileChars = System.IO.Path.GetInvalidFileNameChars();

            int iIndex = strFolderName.IndexOfAny(invalidFileChars);
            if (iIndex != -1)
            {
                foreach (char invalidChar in invalidFileChars)
                {
                    strFolderName = strFolderName.Replace(invalidChar.ToString(), "");
                }
            }

            // Entferne alle . am Ende des Strings weil Windows diese sonst automatisch entfernt.
            strFolderName = strFolderName.TrimEnd('.');
            // Entferne alle . am Anfang des Strings weil Windows sonst meckert.
            strFolderName = strFolderName.TrimStart('.');
            
            return strFolderName;
        }
        /// <summary>
        /// Removes all characters that are not allowed from the path name.
        /// </summary>
        /// <param name="strPath">The name of the path</param>
        /// <returns>The name of the path without all not allowed characters.</returns>
        public static string RemoveInvalidPathChars(string strPath)
        {
            if (strPath == null)
            {
                throw new ArgumentNullException(
                    string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.IDS_ArgumentException,
                    "strPath"));
            }

            char[] invalidPathChars = System.IO.Path.GetInvalidPathChars();

            int iIndex = strPath.IndexOfAny(invalidPathChars);
            if (iIndex != -1)
            {
                foreach (char invalidChar in invalidPathChars)
                {
                    strPath = strPath.Replace(invalidChar.ToString(), "");
                }
            }
            return strPath;
        }
        /// <summary>
        /// Removes all characters that are not allowed from the file name.
        /// </summary>
        /// <param name="strPathOrFileName">The name of the file</param>
        /// <returns>The name of the file without all not allowed characters.</returns>
        public static string ParseOutInvalidFileNameChars(string strPathOrFileName)
        {
            if (strPathOrFileName == null)
            {
                throw new ArgumentNullException(
                    string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.IDS_ArgumentException,
                    "strPathOrFileName"));
            }
            
            // die abschliessenden . werden, falls vorhanden entfernt
            int iIndexLastChar = strPathOrFileName.IndexOf(
                '.',
                strPathOrFileName.Length - 1);
            if (iIndexLastChar != -1)
            {
                strPathOrFileName = strPathOrFileName.Remove(
                    iIndexLastChar,
                    1);

                strPathOrFileName = ParseOutInvalidFileNameChars(
                    strPathOrFileName);
            }
            // alle nicht erlaubten Zeichen werden entfernt
            int iIndex = strPathOrFileName.IndexOfAny(
                System.IO.Path.GetInvalidFileNameChars());
            if (iIndex != -1)
            {
                strPathOrFileName = strPathOrFileName.Remove(
                    iIndex,
                    1);

                strPathOrFileName = ParseOutInvalidFileNameChars(
                    strPathOrFileName);
            }

            return strPathOrFileName;
        }
        /// <summary>
        /// Appends the DirectorySeparatorChar the a path if there is no one.
        /// </summary>
        /// <param name="strPathOrFileName"></param>
        /// <returns></returns>
        public static string AppendDirectorySeparatorChar(string strPath)
        {
            if (strPath == null)
            {
                throw new ArgumentNullException(
                    string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.IDS_ArgumentException,
                    "strPathOrFileName"));
            }

            if (strPath.EndsWith(System.IO.Path.DirectorySeparatorChar.ToString(), StringComparison.OrdinalIgnoreCase) == false)
            {
                strPath += System.IO.Path.DirectorySeparatorChar;
            }
            return strPath;
        }
        /// <summary>
        /// Gets the default file name of an audio track in the form <b>S1011</b>.
        /// </summary>
        /// <param name="iAlbumId">The id of an album.</param>
        /// <returns>The default file name of an audio track.</returns>
        public static string GetDefaultAudioTrackName(int iAlbumId)
        {
            return string.Format(
                CultureInfo.InvariantCulture,
                "S{0}",
                iAlbumId.ToString("0000", CultureInfo.InvariantCulture));
        }
        /// <summary>
        /// Gets an information whether the file extension is a audio extension
        /// </summary>
        /// <param name="strFileExtension">The string representing the extension part of the file</param>
        /// <returns><b>true</b> if the file extension is a allowed audio extension; otherwise <b>false</b>.</returns>
        public static bool IsWritableAudioExtension(string strFileExtension)
        {
            if (string.IsNullOrEmpty(strFileExtension) == false)
            {
                 if (WritableAudioExtensions.Contains(strFileExtension.ToUpper(CultureInfo.InvariantCulture)) == true)
                 {
                     return true;
                 }
            }
            return false;
        }
        #endregion

        #region MethodsPrivate
        /// <summary>
        /// Gets a collection of writable audio formats
        /// </summary>
        /// <returns>A <see cref="Collection<string>"/> with the writable audio formats</returns>
        private static Collection<string> GetWritableAudioExtensions()
        {
            Collection<string> writableAudioExtensions = new Collection<string>();
            writableAudioExtensions.Add(BO.AudioformatExtensions.Mp3.ToUpper(CultureInfo.InvariantCulture));
            writableAudioExtensions.Add(BO.AudioformatExtensions.Wma.ToUpper(CultureInfo.InvariantCulture));
            return writableAudioExtensions;
        }
        #endregion
    }
}
