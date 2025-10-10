using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace BSE.Wpf.Windows.Controls.ImageFlow
{
    /// <summary>
    /// Provides data for the <see cref="ImageFlowPanel"/> events.
    /// </summary>
    public class ImageFlowItemEventArgs : RoutedEventArgs
    {
        #region FieldsPrivate
        private readonly IImageFlowItem m_item;
        #endregion

        #region Properties
        /// <summary>
        /// Gets the <see cref="IImageFlowItem"/>.
        /// </summary>
        public IImageFlowItem Item
        {
            get
            {
                return this.m_item;
            }
        }
        #endregion

        #region MethodsPublic
        /// <summary>
        /// Initializes a new instance of the <see cref="ImageFlowItemEventArgs"/> class.
        /// </summary>
        /// <param name="routedEvent">The routed event identifier for this instance of the <see cref="RoutedEventArgs"/> class.</param>
        /// <param name="item">An <see cref="IImageFlowItem"/> that will be reported when the event is handled.</param>
        public ImageFlowItemEventArgs(RoutedEvent routedEvent, IImageFlowItem item)
            : base(routedEvent)
        {
            this.m_item = item;
        }
        #endregion
    }
}
