using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Globalization;
using BSE.Wpf.Windows.Controls.Properties;

namespace BSE.Wpf.Windows.Controls.ImageFlow
{
    /// <summary>
    /// Provides data for mouse button related events.
    /// </summary>
    public class ImageFlowItemMouseEventArgs : MouseButtonEventArgs
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
        /// Initializes a new instance of the <see cref="ImageFlowItemMouseEventArgs"/> class.
        /// </summary>
        /// <param name="mouse">The logical Mouse device associated with this event.</param>
        /// <param name="timestamp">The time when the input occurred.</param>
        /// <param name="button">The mouse button whose state is being described.</param>
        /// <param name="item">An <see cref="IImageFlowItem"/> that will be reported when the event is handled.</param>
        public ImageFlowItemMouseEventArgs(MouseDevice mouse, int timestamp, MouseButton button, IImageFlowItem item)
            : base(mouse, timestamp, button)
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
        }
        
        #endregion

        #region MethodsProtected
        /// <summary>
        /// Invokes event handlers in a type-specific way, which can increase event system efficiency.
        /// </summary>
        /// <param name="genericHandler">The generic handler to call in a type-specific way.</param>
        /// <param name="genericTarget">The target to call the handler on.</param>
        /// <remarks>
        /// This implementation casts the generic handler as a <see cref="ImageFlowItemMouseEventHandler"/> and then invokes it.
        /// </remarks>
        protected override void InvokeEventHandler(Delegate genericHandler, object genericTarget)
        {
            ImageFlowItemMouseEventHandler handler = (ImageFlowItemMouseEventHandler)genericHandler;
            handler(genericTarget, this);
        }
        #endregion
    }
}
