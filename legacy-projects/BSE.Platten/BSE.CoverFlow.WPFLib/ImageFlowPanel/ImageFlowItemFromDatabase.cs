using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using BSE.CoverFlow.WPFLib.Properties;
using System.IO;
using System.Windows.Markup;
using System.Windows.Media.Animation;
using System.Diagnostics.CodeAnalysis;
using BSE.Wpf.Windows.Controls.ImageFlow;
using System.Drawing;

namespace BSE.CoverFlow.WPFLib.ImageFlowPanel
{
    public class ImageFlowItemFromDatabase : ImageFlowItem
    {
        #region Properties
        /// <summary>
        /// Gets or sets the AlbumId for the record which contains the cover.
        /// </summary>
        public int AlbumId
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the connection string for the database operation.
        /// </summary>
        public string ConnectionString
        {
            get;
            set;
        }
        #endregion

        #region MethodsPublic
        /// <summary>
        /// Prepares the current <see cref="ImageFlowItemFromDatabase"/> for displaying within the <see cref="System.Windows.Media.Media3D.ModelVisual3D"/> of the <see cref="System.Windows.Controls.Viewport3D"/>
        /// </summary>
        public override void PrepareItem()
        {
            if (this.AlbumId != 0)
            {
                base.FileName = this.AlbumId + Constants.PngFileFormatSuffix;
            }
            base.PrepareItem();
        }
        public override Image CreateImage()
        {
            Image image = null;
            BSE.Platten.BO.CCoversBusinessObject coversBusinessObject
                = new BSE.Platten.BO.CCoversBusinessObject(this.ConnectionString);
            if (coversBusinessObject != null)
            {
                image = coversBusinessObject.GetCoverImageByAlbumId(this.AlbumId);
            }
            return image;
        }
        /// <summary>
        /// Determines whether the specified <see cref="ImageFlowItemFromDatabase"/> object is equal to the current <see cref="ImageFlowItemFromDatabase"/> object.
        /// </summary>
        /// <param name="imageFlowItem">The <see cref="ImageFlowItemFromDatabase"/> object to compare with the current <see cref="ImageFlowItemFromDatabase"/> object. </param>
        /// <returns>true if the specified <see cref="ImageFlowItemFromDatabase"/> object is equal to the current <see cref="ImageFlowItemFromDatabase"/> object; otherwise, false.</returns>
        public override bool Equals(IImageFlowItem imageFlowItem)
        {
            ImageFlowItemFromDatabase item = imageFlowItem as ImageFlowItemFromDatabase;
            if (item == null)
            {
                return false;
            }
            if (this.AlbumId != item.AlbumId)
            {
                return false;
            }
            return true;
        }
        // <summary>
        /// Returns a hash code for the current <see cref="ImageFlowItemFromDatabase"/>
        /// </summary>
        /// <returns>A hash code for the current <see cref="ImageFlowItemFromDatabase"/></returns>
        public override int GetHashCode()
        {
            return this.AlbumId.GetHashCode();
        }
        /// <summary>
        /// Creates an identical copy of the <see cref="ImageFlowItemFromDatabase"/>.
        /// </summary>
        /// <returns>An object that represents an <see cref="ImageFlowItemFromDatabase"/> that has the same properties the cloned item.</returns>
        public override object Clone()
        {
            ImageFlowItemFromDatabase item = new ImageFlowItemFromDatabase();
            item.AlbumId = this.AlbumId;
            item.ConnectionString = this.ConnectionString;
            return item;
        }
        #endregion
    }
}
