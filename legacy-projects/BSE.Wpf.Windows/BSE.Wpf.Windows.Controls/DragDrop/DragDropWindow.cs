using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows;
using System.Windows.Controls;

namespace BSE.Wpf.Windows.Controls.DragDrop
{
    public class DragDropWindow : IDisposable
    {
        #region FieldsPrivate
        private Window m_dragDropWindow;
        private readonly Control m_parentControl;
        private QueryContinueDragEventHandler m_queryContinueDragEventHandler;
        #endregion

        #region MethodsPublic
        public DragDropWindow(Control parentControl, Visual dragElement)
        {
            this.m_parentControl = parentControl;
            this.m_queryContinueDragEventHandler = new QueryContinueDragEventHandler(this.ParentControlQueryContinueDrag);
            this.m_parentControl.QueryContinueDrag += m_queryContinueDragEventHandler;
            this.m_dragDropWindow = new Window();
            this.m_dragDropWindow.WindowStyle = WindowStyle.None;
            this.m_dragDropWindow.AllowsTransparency = true;
            this.m_dragDropWindow.AllowDrop = false;
            this.m_dragDropWindow.Background = null;
            this.m_dragDropWindow.IsHitTestVisible = false;
            this.m_dragDropWindow.SizeToContent = SizeToContent.WidthAndHeight;
            this.m_dragDropWindow.Topmost = true;
            this.m_dragDropWindow.ShowInTaskbar = false;
            this.m_dragDropWindow.SourceInitialized += new EventHandler(
            delegate(object sender, EventArgs args)
            {
                //TODO assert that we can do this.. 
                PresentationSource windowSource = PresentationSource.FromVisual(this.m_dragDropWindow);
                IntPtr handle = ((System.Windows.Interop.HwndSource)windowSource).Handle;

                Int32 styles = NativeMethods.GetWindowLong(handle, NativeMethods.GWL_EXSTYLE);
                NativeMethods.SetWindowLong(handle, NativeMethods.GWL_EXSTYLE, styles | NativeMethods.WS_EX_LAYERED | NativeMethods.WS_EX_TRANSPARENT);
            });

            System.Windows.Shapes.Rectangle rectangle = new System.Windows.Shapes.Rectangle();
            rectangle.Width = ((FrameworkElement)dragElement).ActualWidth;
            rectangle.Height = ((FrameworkElement)dragElement).ActualHeight;
            VisualBrush visualBrush = new VisualBrush(dragElement);
            visualBrush.Opacity = .6;
            rectangle.Fill = visualBrush;
            this.m_dragDropWindow.Content = rectangle;

            // put the window in the right place to start
            UpdateWindowLocation();
        }

        public void Show()
        {
            this.m_dragDropWindow.Show();
        }
        
        ~DragDropWindow()
        {
            // Simply call Dispose(false).
            Dispose(false);
        }
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
        #endregion

        #region MethodsProtected
        protected virtual void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if (disposing == true)
            {
                if (this.m_dragDropWindow != null)
                {
                    this.m_dragDropWindow.Close();
                    this.m_dragDropWindow = null;
                }
                if (this.m_parentControl != null)
                {
                    this.m_parentControl.QueryContinueDrag -= this.m_queryContinueDragEventHandler;
                }
            }
        }
        #endregion

        #region MethodsPrivate
        private void UpdateWindowLocation()
        {
            if (this.m_dragDropWindow != null)
            {
                NativeMethods.POINT p;
                if (NativeMethods.GetCursorPos(out p) == false)
                {
                    return;
                }
                this.m_dragDropWindow.Left = (double)p.X;
                this.m_dragDropWindow.Top = (double)p.Y;
            }
        }
        private void ParentControlQueryContinueDrag(object sender, QueryContinueDragEventArgs e)
        {
            this.UpdateWindowLocation();
        }
        #endregion

    }
}
