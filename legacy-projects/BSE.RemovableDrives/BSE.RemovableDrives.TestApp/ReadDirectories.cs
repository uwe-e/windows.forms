using System;
using System.IO;
using System.Windows.Forms;

//using BSE.Platten.BO;
//using BSE.Platten.Common;

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
		#endregion

		#region MethodsPublic
        /// <summary>
        /// default constructor of the CReadDirectories class.
        /// </summary>
        public ReadDirectories(IWin32Window owner, System.IO.DirectoryInfo directoryInfo)
            : base(owner, directoryInfo)
        {
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
					foreach (System.IO.FileInfo fileInfo in directory.GetFiles())
					{
                        //System.Threading.Thread.Sleep(20);
                        if (bNewFolder == true)
                        {
                            OnReadDirectory(new ReadDirectoriesEventArgs(directory));
                            if ((string.Compare(fileInfo.Extension.ToLower(),AudioformatExtensions.Mp3) == 0) ||
                                (string.Compare(fileInfo.Extension.ToLower(),AudioformatExtensions.Wma) == 0))
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
                        if (MessageBox.Show(exception.Message,"Hallo", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
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
