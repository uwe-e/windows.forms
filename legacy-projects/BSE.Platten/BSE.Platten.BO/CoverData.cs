using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Data;
using System.Globalization;
using BSE.Platten.BO.Properties;

namespace BSE.Platten.BO
{
	/// <summary>
	/// Zusammendfassende Beschreibung für CCoverData.
	/// </summary>
	public class CCoverData
    {

        #region FieldsPrivate

        private string m_strExtension;
		
		#endregion
		
		#region Properties

        public string Extension
		{
            get
            {
                if (this.m_strExtension.StartsWith(".", StringComparison.OrdinalIgnoreCase) == false)
                {
                    this.m_strExtension = "." + this.m_strExtension;
                }
                return this.m_strExtension;
            }
            set { this.m_strExtension = value; }
		}

		public string Interpret
		{
			get;
			set;
		}

		public string Titel
		{
			get;
			set;
		}

		public string ImageFileName
		{
			get;
			set;
		}

		public Image Image
		{
			get;
			set;
		}

        public Image ThumbNail
        {
            get;
            set;
        }
        
        public static Size ThumbnailSize
        {
            get { return new Size(100, 100); }
        }
		#endregion

		#region MethodsPublic

		public CCoverData()
		{
		}

        public static bool IsAllowedCoverExtension(string strExtension)
        {
            System.Collections.ArrayList allowedCoverExtensions
                = new System.Collections.ArrayList(5);
            allowedCoverExtensions.Add(".bmp");
            allowedCoverExtensions.Add(".jpg");
            allowedCoverExtensions.Add(".jpeg");
            allowedCoverExtensions.Add(".gif");
            allowedCoverExtensions.Add(".png");

            bool bIsAllowedCoverExtension = false;
            if (String.IsNullOrEmpty(strExtension) == false)
            {
                if (allowedCoverExtensions.Contains(strExtension.ToLower(CultureInfo.InvariantCulture)) == true)
                {
                    bIsAllowedCoverExtension = true;
                }
            }
            return bIsAllowedCoverExtension;
        }

        public static Image GetImageFromFile(System.IO.FileSystemInfo fileInfo)
        {
            if (fileInfo == null)
            {
                throw new ArgumentNullException(
                    string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.IDS_ArgumentException,
                    "fileInfo"));
            }
            
            System.Drawing.Image image = null;
            try
            {
                using (System.IO.FileStream filestream = new System.IO.FileStream(
                    fileInfo.FullName,
                    System.IO.FileMode.Open,
                    System.IO.FileAccess.Read))
                {
                    Byte[] bytesPicture = new byte[filestream.Length];
                    filestream.Read(bytesPicture, 0, (int)filestream.Length);
                    image = GetImageFromBytes((byte[])bytesPicture);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return image;
        }

        public static Image GetThumbNailFromImage(Image image, Size imageSize)
        {
            if (image == null)
            {
                throw new ArgumentNullException(
                    string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.IDS_ArgumentException,
                    "image"));
            }
            
            System.Drawing.Image thumbImage = null;
            try
            {
                thumbImage = image.GetThumbnailImage(imageSize.Width, imageSize.Height, null, IntPtr.Zero);

            }
            catch (Exception)
            {
                throw;
            }
            return thumbImage;
        }

        public static Byte[] GetBytesFromImage(Image image, ImageFormat imageFormat)
        {
            if (image == null)
            {
                throw new ArgumentNullException(
                    string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.IDS_ArgumentException,
                    typeof(Image).Name));
            }
            
            Byte[] bytesFromImage = null;
            try
            {
                if (imageFormat == null)
                {
                    imageFormat = GetImageFormat(image);
                }
                using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
                {
                    image.Save(memoryStream, imageFormat);
                    bytesFromImage = new Byte[memoryStream.Length];
                    memoryStream.Position = 0;
                    memoryStream.Read(bytesFromImage, 0, (int)memoryStream.Length);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return bytesFromImage;
        }

        public static System.Drawing.Image GetImageFromBytes(Byte[] bytesToImage)
        {
            System.Drawing.Image image = null;
            try
            {
                image = Bitmap.FromStream(new System.IO.MemoryStream((byte[])bytesToImage));
            }
            catch (Exception)
            {
                throw;
            }
            return image;
        }

        public static System.Windows.Media.Imaging.BitmapSource GetBitmapSourceFromBytes(Byte[] bytesToImage)
        {
            System.Windows.Media.Imaging.BitmapSource bitmapSource = null;
            using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream(bytesToImage))
            {
                System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(memoryStream);
                if (bitmap != null)
                {
                    bitmapSource = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                    bitmap.GetHbitmap(),
                    IntPtr.Zero,
                    System.Windows.Int32Rect.Empty,
                    System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());
                }
            }
            return bitmapSource;
        }
        public static System.Drawing.Image GetImageFromDbReader(
            IDataRecord dataReader,
            string strColumnName)
        {
            if (dataReader == null)
            {
                throw new ArgumentNullException(
                    string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.IDS_ArgumentException,
                    "dataReader"));
            }
            
            System.Drawing.Image image = null;
            try
            {
                object objectBlob = (object)dataReader[strColumnName];
                if (objectBlob != DBNull.Value)
                {
                    byte[] bytes = objectBlob as byte[];
                    if ((bytes != null) && (bytes.Length > 0))
                    {
                        image = GetImageFromBytes(bytes);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return image;
        }

        public static ImageFormat GetImageFormat(Image image)
        {
            if (image == null)
            {
                throw new ArgumentNullException(
                    string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.IDS_ArgumentException,
                    typeof(Image).Name));
            }
            
            ImageFormat imageFormat = image.RawFormat;
            if (imageFormat.Equals(ImageFormat.Bmp) == true)
            {
                imageFormat = ImageFormat.Bmp;
            }
            if (imageFormat.Equals(ImageFormat.Jpeg) == true)
            {
                imageFormat = ImageFormat.Jpeg;
            }
            if (imageFormat.Equals(ImageFormat.Gif) == true)
            {
                imageFormat = ImageFormat.Gif;
            }
            if (imageFormat.Equals(ImageFormat.Png) == true)
            {
                imageFormat = ImageFormat.Png;
            }
            return imageFormat;
        }

        public static Size GetCalculatedImageSize(Image image)
        {
            if (image == null)
            {
                throw new ArgumentNullException(
                    string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.IDS_ArgumentException,
                    typeof(Image).Name));
            }
            
            Size imageSize = ThumbnailSize;
            try
            {
                Single sThumbHeight = (Single)CCoverData.ThumbnailSize.Height;
                Single sThumbWidth = (Single)sThumbHeight / image.Height * image.Width;
                if (sThumbWidth > (Single)CCoverData.ThumbnailSize.Height)
                {
                    sThumbWidth = (Single)CCoverData.ThumbnailSize.Height;
                    sThumbHeight = (Single)sThumbWidth / image.Width * image.Height;
                }

                imageSize = new Size(Convert.ToInt32(sThumbWidth), Convert.ToInt32(sThumbHeight));
            }
            catch (Exception)
            {
                throw;
            }
            return imageSize;
        }

		#endregion

		#region MethodsPrivate

		#endregion

	}
}
