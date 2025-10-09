using System;
using System.IO;
using System.Windows.Forms;

using BSE.Platten.BO;
using BSE.Platten.Common;
using System.Globalization;

namespace BSE.Platten.Audio
{
	/// <summary>
	/// Summary description for CReadDirectories.
	/// </summary>
	/// <remarks></remarks>
	/// <copyright>Copyright © 2005 MCH Messe Schweiz (Basel) AG</copyright>
	public class ReadDirectories : ReadDirectoriesAndFiles
	{

		#region FieldsPrivate
        private string m_strSearchPattern;
		#endregion

		#region MethodsPublic
        /// <summary>
        /// default constructor of the CReadDirectories class.
        /// </summary>
        public ReadDirectories(IWin32Window owner, string strSearchPattern, System.IO.DirectoryInfo directoryInfo)
            : base(owner)
        {
            this.m_strSearchPattern = strSearchPattern;
            base.DirectoryInfo = directoryInfo;
            base.Thread =
                new System.Threading.Thread(
                new System.Threading.ThreadStart(this.GetDirectories));
            base.Thread.Start();
        }

		#endregion

		#region MethodsPrivate
		
		private void GetDirectories()
		{
            DirectoryInfo directory = new DirectoryInfo(base.DirectoryInfo.FullName);
			if (directory.Exists == true)
			{
				bool bNewFolder = true;
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
                    foreach (System.IO.FileInfo fileInfo in fileInfos)
                    {
                        System.Threading.Thread.Sleep(20);
                        if (bNewFolder == true)
                        {
                            OnReadDirectory(new ReadDirectoriesEventArgs(directory));
                            if (BSE.Platten.BO.Environment.IsWritableAudioExtension(fileInfo.Extension) == true)
                            {
                                OnFoundDirectory(new ReadDirectoriesEventArgs(directory));
                                bNewFolder = false;
                                break;
                            }
                        }
                    }

					foreach (System.IO.DirectoryInfo subdirectory in directory.GetDirectories())
					{
                        base.DirectoryInfo = subdirectory;
						GetDirectories();
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
