using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;

namespace BSE.Wpf.Windows.Controls.ImageFlow
{
    /// <summary>
    /// Contains the functions and the properties for creating one <see cref="ImageFlowItem"/> object
    /// from a <see cref="FileInfo"/> object.
    /// </summary>
    public class ImageFlowItemFromFileInfo :  ImageFlowItem
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
        /// Creates the <see cref="Image"/> from a <see cref="FileInfo"/> object as the source.
        /// </summary>
        /// <returns>The created <see cref="Image"/>.</returns>
        public override Image CreateImage()
        {
            return Image.FromFile(this.FileInfo.FullName);
        }
        /// <summary>
        /// Prepares the current <see cref="ImageFlowItemFromFileInfo"/> for displaying within the <see cref="System.Windows.Media.Media3D.ModelVisual3D"/> of the <see cref="System.Windows.Controls.Viewport3D"/>
        /// </summary>
        public override void PrepareItem()
        {
            if (this.FileInfo != null)
            {
                base.FileName = Path.GetFileNameWithoutExtension(this.FileInfo.Name) + Constants.PngFileFormatSuffix;
            }
            base.PrepareItem();
        }
        /// <summary>
        /// Determines whether the specified <see cref="ImageFlowItemFromFileInfo"/> object is equal to the current <see cref="ImageFlowItemFromFileInfo"/> object.
        /// </summary>
        /// <param name="imageFlowItem">The <see cref="ImageFlowItemFromFileInfo"/> object to compare with the current <see cref="ImageFlowItemFromFileInfo"/> object. </param>
        /// <returns>true if the specified <see cref="ImageFlowItemFromFileInfo"/> object is equal to the current <see cref="ImageFlowItemFromFileInfo"/> object; otherwise, false.</returns>
        public override bool Equals(IImageFlowItem imageFlowItem)
        {
            ImageFlowItemFromFileInfo item = imageFlowItem as ImageFlowItemFromFileInfo;
            if (item == null)
            {
                return false;
            }
            if (this.FileInfo != item.FileInfo)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Returns a hash code for the current <see cref="ImageFlowItemFromFileInfo"/>
        /// </summary>
        /// <returns>A hash code for the current <see cref="ImageFlowItemFromFileInfo"/></returns>
        public override int GetHashCode()
        {
            return this.FileInfo == null ? 0 : this.FileInfo.GetHashCode();
        }
        /// <summary>
        /// Creates an identical copy of the <see cref="ImageFlowItemFromFileInfo"/>.
        /// </summary>
        /// <returns>An object that represents an <see cref="ImageFlowItemFromFileInfo"/> that has the same properties the cloned item.</returns>
        public override object Clone()
        {
            ImageFlowItemFromFileInfo item = new ImageFlowItemFromFileInfo();
            item.FileInfo = this.FileInfo;
            return item;
        }
        #endregion
    }
}
