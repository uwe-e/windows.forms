using System;
using System.IO;
using System.Windows.Forms;
using BSE.Platten.BO;
using BSE.Platten.Common;
using System.Globalization;
using BSE.Platten.Audio.Properties;
using System.Diagnostics.CodeAnalysis;

namespace BSE.Platten.Audio
{
	/// <summary>
	/// Summary description for CReadFiles.
	/// </summary>
	/// <remarks></remarks>
	public class ReadFiles : ReadDirectoriesAndFiles
	{
		#region FieldsPrivate
        private string m_strSearchPattern;
        #endregion

		#region MethodsPublic
		/// <summary>
        /// default constructor of the CReadFiles class.
		/// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        public ReadFiles(IWin32Window owner, string strSearchPattern, System.IO.DirectoryInfo directoryInfo)
            : base(owner)
        {
            this.m_strSearchPattern = strSearchPattern;
            base.DirectoryInfo = directoryInfo;
            base.Thread =
                new System.Threading.Thread(
                new System.Threading.ThreadStart(this.GetFiles));
            base.Thread.Start();
        }
		#endregion

		#region MethodsPrivate
		
		private void GetFiles()
		{
			DirectoryInfo directory = new DirectoryInfo(base.DirectoryInfo.FullName);
			if (directory.Exists == true)
			{
				try
				{
                    FileInfo[] fileInfos = null;
                    if (string.IsNullOrEmpty(this.m_strSearchPattern) == true)
                    {
                        fileInfos = directory.GetFiles();
                    }
                    else
                    {
                        fileInfos = directory.GetFiles(this.m_strSearchPattern);
                    }

                    if ((fileInfos != null) && (fileInfos.Length > 0))
                    {
                        foreach (System.IO.FileInfo fileInfo in fileInfos)
                        {
                            System.Threading.Thread.Sleep(20);
                            OnReadFile(new ReadFilesEventArgs(fileInfo, null));

                            if (BSE.Platten.BO.Environment.IsWritableAudioExtension(fileInfo.Extension) == true)
                            {
                                AudioData audioData = new WMFMediaData();
                                try
                                {
                                    AudioMetadata audioMetaData = audioData.GetMediaMetadata(fileInfo.FullName);
                                    if (audioMetaData != null)
                                    {

                                        audioMetaData.FullName = fileInfo.FullName;
                                        audioMetaData.Name = fileInfo.Name;
                                        audioMetaData.Extension = fileInfo.Extension;
                                        OnFoundFile(new ReadFilesEventArgs(fileInfo, audioMetaData));

                                    }
                                }
                                catch (Exception)
                                {
                                    string strMessage = String.Format(
                                        CultureInfo.CurrentCulture,
                                        Resources.IDS_ReadAudioFileException,
                                        fileInfo.FullName);

                                    DialogResult dialogResult = GlobalizedMessageBox.Show(
                                        base.Owner,
                                        strMessage,
                                        MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Error);
                                    if (dialogResult == DialogResult.No)
                                    {
                                        return;
                                    }
                                }
                            }
                        }
					}
				}
				catch(Exception exception)
				{
					if (base.Thread.ThreadState != System.Threading.ThreadState.AbortRequested)
					{
                        if (GlobalizedMessageBox.Show(base.Owner, exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                        {
                            base.Thread.Abort();
                        }
					}
				}
			}
		}

    	#endregion
	}
}
