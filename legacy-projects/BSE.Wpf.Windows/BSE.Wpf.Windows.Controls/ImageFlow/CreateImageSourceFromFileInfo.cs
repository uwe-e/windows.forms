using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;

namespace BSE.Wpf.Windows.Controls.ImageFlow
{
    public class CreateImageSourceFromFileInfo : CreateImageSource
    {
        #region Properties
        /// <summary>
        /// Gets or sets the <see cref="FileInfo"/> of the image file.
        /// </summary>
        public FileInfo FileInfo
        {
            get;
            set;
        }
        #endregion

        #region MethodsPublic
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateImageSourceFromFileInfo"/> class.
        /// </summary>
        /// <param name="item"></param>
        public CreateImageSourceFromFileInfo(ImageFlowItem item)
            : base(item)
        {
        }
        #endregion

        #region MethodsProtected
        /// <summary>
        /// Creates the <see cref="Image"/> from its source.
        /// </summary>
        /// <returns>The created <see cref="Image"/>.</returns>
        protected override Image CreateImage()
        {
            return Image.FromFile(this.FileInfo.FullName);
        }
        #endregion
    }
}
