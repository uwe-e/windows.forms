using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace BSE.Wpf.Windows.Controls.DragDrop
{
    public delegate void ItemDropEventHandler(object sender, ItemDropEventArgs e);
    
    public class ItemDropEventArgs : RoutedEventArgs
    {
        #region FieldsPrivate
        private readonly IDataObject m_data;
        private readonly int m_insertionIndex;
        private DragDropEffects m_allowedEffects;
        #endregion

        #region Properties
        public IDataObject Data
        {
            get
            {
                return this.m_data;
            }
        }
        public int InsertionIndex
        {
            get
            {
                return this.m_insertionIndex;
            }
        }
        public DragDropEffects Effects
        {
            get
            {
                return this.m_allowedEffects;
            }
        }
        #endregion

        #region MethodsPublic
        public ItemDropEventArgs(IDataObject data, DragDropEffects allowedEffects, int insertionIndex)
        {
            this.m_data = data;
            this.m_allowedEffects = allowedEffects;
            this.m_insertionIndex = insertionIndex;
        }

        #endregion

        #region MethodsProtected
        protected override void InvokeEventHandler(Delegate genericHandler, object genericTarget)
        {
            ItemDropEventHandler handler = (ItemDropEventHandler)genericHandler;
            handler(genericTarget, this);
        }
        #endregion
    }
}
