using System;
using System.IO;
using System.Globalization;
using BSE.Platten.Audio.Properties;
using System.Diagnostics.CodeAnalysis;

namespace BSE.Platten.Audio
{
	/// <summary>
    /// Zusammendfassende Beschreibung für CheckFile.
	/// </summary>
	public static class CheckFile
	{
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        public static bool FileExists(string strFileName)
		{
			bool bFileExists = false;
            if (System.IO.File.Exists(strFileName) == true)
            {
                bFileExists = true;
            }
			else
			{
				throw new FileNotFoundException(string.Format(
                    CultureInfo.CurrentUICulture,
                    Resources.IDS_FileNotFoundException,strFileName));
			}

			return bFileExists;
		}
	}
}
