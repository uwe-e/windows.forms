using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Media;
using System.IO;
using System.Drawing;
using System.Windows.Media.Imaging;
using System.Globalization;
using BSE.Wpf.Windows.Controls.Properties;

namespace BSE.Wpf.Windows.Controls.ImageFlow
{
    /// <summary>
    /// Contains all methods and properties which are necessary for scaling an image and storing it into the cache directory.
    /// This class includes the <see cref="BackgroundWorker"/> thread which manipulates all the operations in a seperate thread.
    /// </summary>
    public class CreateImageSource : IDisposable
    {
        #region Events
        /// <summary>
        /// Occurs when the Imagesource has been created.
        /// </summary>
        public event EventHandler<EventArgs> ImageSourceCreated;
        #endregion

        #region FieldsPrivate
        private BackgroundWorker m_backgroundWorker;
        private readonly DirectoryInfo m_cacheDirectoryInfo;
        private readonly IImageFlowItem m_item;
        private readonly string m_strFileName;
        #endregion

        #region Properties
        /// <summary>
        /// Gets the <see cref="ImageSource"/> of the created image.
        /// </summary>
        public ImageSource PictureImageSource
        {
            get;
            private set;
        }
        #endregion

        #region MethodsPublic
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateImageSource"/> class.
        /// </summary>
        /// <param name="item">The <see cref="ImageFlowItem"/> which is the parent object.</param>
        public CreateImageSource(ImageFlowItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(
                    string.Format(
                    CultureInfo.CurrentUICulture,
                    Resources.IDS_ArgumentException,
                    "item"));
            }
            this.m_item = item;
            this.m_strFileName = item.FileName;
            this.m_cacheDirectoryInfo = item.CacheDirectoryInfo;
            this.m_backgroundWorker = new BackgroundWorker();
            this.m_backgroundWorker.WorkerSupportsCancellation = true;
            this.m_backgroundWorker.DoWork += new DoWorkEventHandler(BackgroundWorkerDoWork);
            this.m_backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BackgroundWorkerRunWorkerCompleted);
        }
        /// <summary>
        /// Starts the <see cref="CreateImageSource"/> thread.
        /// </summary>
        public void Run()
        {
            this.m_backgroundWorker.RunWorkerAsync();
        }
        /// <summary>
        /// Releases all resources used by the <see cref="Component"/>.
        /// </summary>
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
        /// <summary>
        /// Destructor for the <see cref="CreateImageSource"/> object.
        /// Use C# destructor syntax for finalization code.
        /// </summary>
        ~CreateImageSource()
        {
            // Simply call Dispose(false).
            Dispose(false);
        }
        #endregion

        #region MethodsProtected
        /// <summary>
        /// Releases the unmanaged resources used by <see cref="CreateImageSource"/> and optionally
        /// releases the managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources;
        /// false to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if (disposing == true)
            {
                if (this.m_backgroundWorker != null)
                {
                    if (this.m_backgroundWorker.IsBusy == true)
                    {
                        this.m_backgroundWorker.CancelAsync();
                    }
                    this.m_backgroundWorker.Dispose();
                }
            }
        }
        #endregion

        #region MethodsPrivate
        private void BackgroundWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            if ((string.IsNullOrEmpty(this.m_strFileName) == false) && (this.m_cacheDirectoryInfo != null))
            {
                BackgroundWorker backgroundWorker = sender as BackgroundWorker;
                try
                {
                    e.Result = this.GetImageSource(this.m_cacheDirectoryInfo, this.m_strFileName);
                }
                catch (Exception)
                {
                    throw;
                }
                if (backgroundWorker != null)
                {
                    if (backgroundWorker.CancellationPending == true)
                    {
                        e.Cancel = true;
                    }
                }
            }
        }
        private void BackgroundWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            using (BackgroundWorker backgroundWorker = sender as BackgroundWorker)
            {
                if (backgroundWorker != null)
                {
                    backgroundWorker.DoWork -= new DoWorkEventHandler(BackgroundWorkerDoWork);
                    backgroundWorker.RunWorkerCompleted -= new RunWorkerCompletedEventHandler(BackgroundWorkerRunWorkerCompleted);
                }
                if ((e.Error == null) && (e.Cancelled == false))
                {
                    this.PictureImageSource = e.Result as ImageSource; ;
                    if (this.ImageSourceCreated != null)
                    {
                        this.ImageSourceCreated(this, EventArgs.Empty);
                    }
                }
            }
        }
        private ImageSource GetImageSource(DirectoryInfo cacheDirectoryInfo, string fileName)
        {
            cacheDirectoryInfo.Refresh();
            if (cacheDirectoryInfo.Exists == false)
            {
                cacheDirectoryInfo.Create();
            }
            string strFullName = Path.Combine(cacheDirectoryInfo.FullName, fileName);
            FileInfo fileInfo = new FileInfo(strFullName);
            if (fileInfo.Exists == false)
            {
                try
                {
                    bool bIsPortrait = false;
                    using (Image image = this.m_item.CreateImage())
                    {
                        if (image != null)
                        {
                            if (image.Height > image.Width)
                            {
                                bIsPortrait = true;
                            }

                            using (MemoryStream memoryStream = new MemoryStream())
                            {
                                image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
                                BitmapImage thumbNail = new BitmapImage();
                                thumbNail.BeginInit();
                                thumbNail.CacheOption = BitmapCacheOption.OnLoad;
                                if (bIsPortrait == true)
                                {
                                    thumbNail.DecodePixelHeight = Constants.ImageStretchExtension;
                                }
                                else
                                {
                                    thumbNail.DecodePixelWidth = Constants.ImageStretchExtension;
                                }
                                thumbNail.StreamSource = memoryStream;
                                thumbNail.EndInit();
                                thumbNail.Freeze();

                                using (FileStream fileStream = new FileStream(strFullName, FileMode.Create))
                                {
                                    PngBitmapEncoder encoder = new PngBitmapEncoder();
                                    encoder.Interlace = PngInterlaceOption.Off;
                                    encoder.Frames.Add(BitmapFrame.Create(thumbNail));
                                    encoder.Save(fileStream);
                                    encoder = null;
                                    thumbNail = null;
                                }
                            }
                            fileInfo.Refresh();
                        }
                    }
                }
                catch
                {
                }
            }
            return GetImageSource(fileInfo);
        }

        private static ImageSource GetImageSource(FileInfo fileInfo)
        {
            BitmapImage bitmapImage = null;
            if ((fileInfo != null) && (fileInfo.Exists == true))
            {
                try
                {
                    bitmapImage = new BitmapImage();
                    Uri uri = new Uri(fileInfo.FullName, UriKind.RelativeOrAbsolute);
                    bitmapImage.BeginInit();
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.CreateOptions = BitmapCreateOptions.DelayCreation;
                    bitmapImage.UriSource = uri;
                    bitmapImage.EndInit();
                    bitmapImage.Freeze();
                }
                catch { }
            }
            return bitmapImage;
        }
        #endregion
    }
}
