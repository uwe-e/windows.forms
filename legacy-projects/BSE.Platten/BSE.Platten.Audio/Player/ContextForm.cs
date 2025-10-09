using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BSE.Platten.Common;
using System.Diagnostics.CodeAnalysis;

namespace BSE.Platten.Audio
{
    public partial class ContextForm : BaseForm
    {
        #region FieldsPrivate
        [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        private Control m_parentControl;

        #endregion

        #region MethodsPublic

        public ContextForm()
        {
            InitializeComponent();
        }

        public void Show(Control parentControl, Point locationPoint)
        {
            this.m_parentControl = parentControl;
            Point location = parentControl.PointToScreen(locationPoint);
            this.Location = location;
            this.Show();
        }

        public void SetControl(Control control)
        {
            this.ContentPanel.Controls.Clear();
            this.ContentPanel.Controls.Add(control);
        }

        public new void Hide()
        {
            base.Hide();
        }

        #endregion

        #region MethodsPrivate

        private void CContextFormLeave(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void CContextFormDeactivate(object sender, EventArgs e)
        {
            this.Hide();
        }

        #endregion
    }
}