using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace BSE.Platten.BO.Cache
{
    public class ImageFlowCache
    {
        #region FieldsPrivate
        private static DirectoryInfo m_cacheDirectory;
        #endregion

        #region Properties
        public static DirectoryInfo CacheDirectory
        {
            get
            {
                if (m_cacheDirectory == null)
                {
                    string strApplicationDataPath = System.IO.Path.Combine(
                        System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData),
                        BSE.Platten.BO.Environment.BSEApplicationDataPath);

                    m_cacheDirectory = new DirectoryInfo(
                        System.IO.Path.Combine(strApplicationDataPath,
                        System.Reflection.Assembly.GetEntryAssembly().GetName().Name)
                        );
                    if (m_cacheDirectory.Exists == false)
                    {
                        m_cacheDirectory.Create();
                    }
                }
                return m_cacheDirectory;
            }
        }
        #endregion

        #region MethodsPublic
        public static void DeleteCacheDirectory()
        {
            if (CacheDirectory != null && CacheDirectory.Exists == true)
            {
                CacheDirectory.Delete(true);
                m_cacheDirectory = null;
            }
        }
        #endregion
    }
}
