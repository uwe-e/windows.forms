using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Diagnostics.CodeAnalysis;
using System.Security.Permissions;

namespace BSE.Platten.Audio.WMFSDK
{
    internal class WMPicture : IDisposable
    {
        #region Events
        #endregion

        #region Constants
        #endregion

        #region FieldsPrivate
        private Image m_imageToEmbed;
        private IntPtr m_ptrMIMEType = IntPtr.Zero;
        private IntPtr m_ptrDescription = IntPtr.Zero;
        private IntPtr m_ptrPictureData = IntPtr.Zero;
        // Track whether Dispose has been called.
        private bool m_bDisposed;
        #endregion

        #region Properties
        
        public string MimeType
        {
            get;
            private set;
        }
        public Image ImageToEmbed
        {
            get
            {
                return this.m_imageToEmbed;
            }
            set
            {
                if (value != null)
                {
                    this.m_imageToEmbed = value;
                    this.MimeType = GetMimeTypeFromImage(this.m_imageToEmbed);
                }
            }
        }
        public WMFSDK.PictureType PictureType
        {
            get;
            set;
        }
        public string Description
        {
            get;
            set;
        }
        #endregion

        #region MethodsPublic

        public WMPicture()
        {
        }
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        public WMPicture(Image imageToEmbed, WMFSDK.PictureType pictureType, string strDescription) : this()
        {
            this.ImageToEmbed = imageToEmbed;
            this.PictureType = pictureType;
            this.Description = strDescription;
        }
        /// <summary>
        /// destructor of the WMPicture class.
		/// </summary>
        ~WMPicture()
		{
			Dispose(false);
		}

        public byte[] GetWMPictureData()
        {
            byte[] bPicture = null;
            try
            {
                ImageConverter imageConverter = new ImageConverter();
                byte[] bImageData = (byte[])imageConverter.ConvertTo(this.ImageToEmbed, typeof(byte[]));
                if (bImageData != null)
                {
                    bPicture = GetWMByteArray(bImageData);
                }
            }
            catch
            {
            }
            return bPicture;
        }
        // Implement IDisposable.
        // Do not make this method virtual.
        // A derived class should not be able to override this method.
        public void Dispose()
        {
            Dispose(true);
            // This object will be cleaned up by the Dispose method.
            // Therefore, you should call GC.SupressFinalize to
            // take this object off the finalization queue
            // and prevent finalization code for this object
            // from executing a second time.
            GC.SuppressFinalize(this);
        }
        
        #endregion

        #region MethodsProtected
        // Dispose(bool disposing) executes in two distinct scenarios.
        // If disposing equals true, the method has been called directly
        // or indirectly by a user's code. Managed and unmanaged resources
        // can be disposed.
        // If disposing equals false, the method has been called by the
        // runtime from inside the finalizer and you should not reference
        // other objects. Only unmanaged resources can be disposed.
        protected virtual void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if (this.m_bDisposed == false)
            {
                // If disposing equals true, dispose all managed
                // and unmanaged resources.
                if (disposing)
                {
                    // Dispose managed resources.
                }
                // Call the appropriate methods to clean up
                // unmanaged resources here.
                // If disposing is false,
                // only the following code is executed.
                if (this.m_ptrMIMEType != IntPtr.Zero)
                {
                    Marshal.FreeCoTaskMem(this.m_ptrMIMEType);
                    this.m_ptrMIMEType = IntPtr.Zero;
                }
                if (this.m_ptrDescription != IntPtr.Zero)
                {
                    Marshal.FreeCoTaskMem(this.m_ptrDescription);
                    this.m_ptrDescription = IntPtr.Zero;
                }
                if (this.m_ptrPictureData != IntPtr.Zero)
                {
                    Marshal.FreeCoTaskMem(this.m_ptrPictureData);
                    this.m_ptrPictureData = IntPtr.Zero;
                }
                // Note disposing has been done.
                this.m_bDisposed = true;
            }
        }
        #endregion

        #region MethodsPrivate
        [SecurityPermission(SecurityAction.LinkDemand,Flags = SecurityPermissionFlag.UnmanagedCode)]
        private byte[] GetWMByteArray(byte[] bImageData)
        {
            byte[] bPictureData = null;
            try
            {
                if (string.IsNullOrEmpty(this.Description) == true)
                {
                    this.Description = string.Empty;
                }
                int lengthData = bImageData.Length;
                // now create unmanaged memory and copy some content
                this.m_ptrMIMEType = Marshal.StringToCoTaskMemUni(MimeType);
                this.m_ptrDescription = Marshal.StringToCoTaskMemUni(Description);
                this.m_ptrPictureData = Marshal.AllocCoTaskMem(lengthData);
                Marshal.Copy(bImageData, 0, this.m_ptrPictureData, lengthData);

                // now we create our wm_picture structure...
                bPictureData = new byte[18];
                using (MemoryStream memStream = new MemoryStream(bPictureData))
                {
                    BinaryWriter binWriter = new BinaryWriter(memStream);
                    // write the mime ptr
                    binWriter.Write(this.m_ptrMIMEType.ToInt32());
                    // write the picture desc
                    binWriter.Write(Convert.ToByte((byte)PictureType));
                    // write the desc ptr
                    binWriter.Write(this.m_ptrDescription.ToInt32());
                    // write the size of data
                    binWriter.Write(Convert.ToInt32(lengthData));
                    // write the data ptr
                    binWriter.Write(this.m_ptrPictureData.ToInt32());

                    binWriter.Close();
                }
            }
            catch(Exception)
            {
                throw;
            }
            return bPictureData;
        }
        private static string GetMimeTypeFromImage(Image image)
        {
            string strMIMEType = "image/jpeg";
            ImageFormat imageFormat = image.RawFormat;
            if (imageFormat.Equals(ImageFormat.Gif) == true)
            {
                strMIMEType = "image/gif";
            }
            else if (imageFormat.Equals(ImageFormat.MemoryBmp) == true)
            {
                strMIMEType = "image/bmp";
            }
            else if (imageFormat.Equals(ImageFormat.Bmp) == true)
            {
                strMIMEType = "image/bmp";
            }
            else if (imageFormat.Equals(ImageFormat.Png) == true)
            {
                strMIMEType = "image/png";
            }
            else if (imageFormat.Equals(ImageFormat.Icon) == true)
            {
                strMIMEType = "image/x-icon";
            }
            else if (imageFormat.Equals(ImageFormat.Tiff) == true)
            {
                strMIMEType = "image/tiff";
            }
            else if (imageFormat.Equals(ImageFormat.Emf) == true)
            {
                strMIMEType = "image/x-emf";
            }
            else if (imageFormat.Equals(ImageFormat.Wmf) == true)
            {
                strMIMEType = "image/x-wmf";
            }
            return strMIMEType;
        }
        #endregion
    }
}
