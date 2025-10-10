using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Media;
using System.Diagnostics.CodeAnalysis;

namespace BSE.Wpf.Windows.Controls.ImageFlow
{
    /// <summary>
    /// This interface identifies an implementing class of 3-D items located in a <see cref="ModelVisual3D"/> class.
    /// </summary>
    public interface IImageFlowItem
    {
        #region Properties
        /// <summary>
        /// Gets or sets the current position of the coveritem within the Visual3DCollection.
        /// </summary>
        int Position { get; set; }
        /// <summary>
        /// Gets or sets the <see cref="ModelVisual3D"/>.
        /// </summary>
        System.Windows.Media.Media3D.ModelVisual3D ModelVisual3D { get; set; }
        /// <summary>
        /// Gets or sets the <see cref="Storyboard"/>.
        /// </summary>
        System.Windows.Media.Animation.Storyboard Storyboard { get; set; }
        /// <summary>
        /// Gets or sets the Viewport3DIndex for the animation.
        /// </summary>
        int Viewport3DIndex { get; set; }
        /// <summary>
        /// Gets or sets the <see cref="DirectoryInfo"/> for the used cache directory.
        /// </summary>
        DirectoryInfo CacheDirectoryInfo { get; set; }
        /// <summary>
        /// Gets or sets the <see cref="ImageSource"/> of the default image.
        /// </summary>
        ImageSource DefaultImageSource { get; set; }
        /// <summary>
        /// Gets or sets the name of the cachefile.
        /// </summary>
        string FileName { get; set; }
        /// <summary>
        /// Gets or sets a brush that describes the background of a <see cref="IImageFlowItem"/> object.
        /// </summary>
        Brush Background { get; set; }
        #endregion

        #region MethodsPublic
        /// <summary>
        /// Gets the animation offsets for the <see cref="IImageFlowItem"/> dependent to the position in its parent list
        /// </summary>
        /// <param name="position">The position of the <see cref="IImageFlowItem"/> in the Visual3DCollection.</param>
        /// <param name="rotationY">The value for the rotation animation.</param>
        /// <param name="offsetX">The value for the x- axis animation.</param>
        /// <param name="offsetY">The value for the x- axis animation.</param>
        /// <param name="offsetZ">The value for the z- axis animation.</param>
        [SuppressMessage("Microsoft.Design","CA1021:AvoidOutParameters")]
        void GetOffsetsFromPosition(int position, out double rotationY, out double offsetX, out double offsetY, out double offsetZ);
        /// <summary>
        /// Matches a <see cref="IImageFlowItem"/> with the clicked <see cref="IImageFlowItem"/>.
        /// </summary>
        /// <param name="modelVisual3D"><see cref="Visual"/>that contains 3-D models.</param>
        /// <returns>True if when match else false</returns>
        bool Matches(System.Windows.Media.Media3D.ModelVisual3D modelVisual3D);
        /// <summary>
        /// Prepares the current <see cref="IImageFlowItem"/> for displaying within the <see cref="System.Windows.Media.Media3D.ModelVisual3D"/> of the <see cref="System.Windows.Controls.Viewport3D"/>
        /// </summary>
        void PrepareItem();
        /// <summary>
        /// Determines whether the specified <see cref="IImageFlowItem"/> object is equal to the current <see cref="IImageFlowItem"/> object.
        /// </summary>
        /// <param name="imageFlowItem">The <see cref="IImageFlowItem"/> object to compare with the current <see cref="IImageFlowItem"/> object. </param>
        /// <returns>true if the specified <see cref="IImageFlowItem"/> object is equal to the current <see cref="IImageFlowItem"/> object; otherwise, false.</returns>
        bool Equals(IImageFlowItem imageFlowItem);
        /// <summary>
        /// Returns a hash code for the current <see cref="IImageFlowItem"/>
        /// </summary>
        /// <returns>A hash code for the current <see cref="IImageFlowItem"/></returns>
        int GetHashCode();
        /// <summary>
        /// Creates an identical copy of the <see cref="IImageFlowItem"/>.
        /// </summary>
        /// <returns>An object that represents an <see cref="IImageFlowItem"/> that has the same properties the cloned item.</returns>
        object Clone();
        /// <summary>
        /// Creates the <see cref="System.Drawing.Image"/> from its source.
        /// </summary>
        /// <returns>The created <see cref="System.Drawing.Image"/>.</returns>
        System.Drawing.Image CreateImage();
        #endregion
    }
}
