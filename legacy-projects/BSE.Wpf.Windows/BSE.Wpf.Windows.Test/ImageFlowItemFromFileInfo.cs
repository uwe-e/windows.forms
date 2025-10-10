using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace BSE.Wpf.Windows.Test
{
    public class ImageFlowItemFromFileInfo1 :  BSE.Wpf.Windows.Controls.ImageFlow.ImageFlowItem
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
        /// Prepares the current <see cref="ImageFlowItemFromFileInfo"/> for displaying within the <see cref="System.Windows.Media.Media3D.ModelVisual3D"/> of the <see cref="System.Windows.Controls.Viewport3D"/>
        /// </summary>
        public override void PrepareItem()
        {
            if (this.FileInfo != null)
            {
                base.FileName = Path.GetFileNameWithoutExtension(this.FileInfo.Name) + BSE.Wpf.Windows.Controls.ImageFlow.Constants.PngFileFormatSuffix;
            }
            base.PrepareItem();
        }
        /// <summary>
        /// Determines whether the specified <see cref="ImageFlowItemFromFileInfo"/> object is equal to the current <see cref="ImageFlowItemFromFileInfo"/> object.
        /// </summary>
        /// <param name="imageFlowItem">The <see cref="ImageFlowItemFromFileInfo"/> object to compare with the current <see cref="ImageFlowItemFromFileInfo"/> object. </param>
        /// <returns>true if the specified <see cref="ImageFlowItemFromFileInfo"/> object is equal to the current <see cref="ImageFlowItemFromFileInfo"/> object; otherwise, false.</returns>
        public override bool Equals(BSE.Wpf.Windows.Controls.ImageFlow.IImageFlowItem imageFlowItem)
        {
            ImageFlowItemFromFileInfo1 item = imageFlowItem as ImageFlowItemFromFileInfo1;
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
            ImageFlowItemFromFileInfo1 item = new ImageFlowItemFromFileInfo1();
            item.FileInfo = this.FileInfo;
            return item;
        }
        #endregion
    }
}
