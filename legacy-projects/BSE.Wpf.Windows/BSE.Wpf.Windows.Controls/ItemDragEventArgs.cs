using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Globalization;

namespace BSE.Wpf.Windows.Controls
{
    /// <summary>
    /// Provides data for the ItemDrag event of the TreeView control.
    /// </summary>
    public class ItemDragEventArgs : MouseEventArgs
    {
        #region FieldsPrivate
        private readonly object m_item;
        #endregion

        #region Properties
        /// <summary>
        /// Gets the item that is being dragged.
        /// </summary>
        public object Item
        {
            get
            {
                return this.m_item;
            }
        }
        #endregion

        #region MethodsPublic
        /// <summary>
        /// Initializes a new instance of the <see cref="ItemDragEventArgs"/> class with a specified mouse button and the item that is being dragged.
        /// </summary>
        /// <param name="mouse">The logical Mouse device associated with this event.</param>
        /// <param name="timestamp">The time when the input occurred.</param>
        /// <param name="item">The item being dragged.</param>
        public ItemDragEventArgs(MouseDevice mouse, int timestamp, object item)
            : base(mouse, timestamp)
        {
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
            ItemDragEventHandler handler = (ItemDragEventHandler)genericHandler;
            handler(genericTarget, this);
        }
        #endregion
    }
}
