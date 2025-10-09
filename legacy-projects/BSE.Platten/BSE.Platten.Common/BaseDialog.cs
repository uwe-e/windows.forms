using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BSE.Platten.Common
{
    public partial class BaseDialog : Form
    {
        #region EventsPublic

        public event System.EventHandler ConfigurationChanged;

        #endregion

        #region FieldsPrivate

        private bool m_bUseAsStandardDialog;

        #endregion

        #region Properties
        [Description("Use this dialog as standard dialog")]
        [DefaultValue(true)]
        [Category("Behavior")]
        public bool UseAsStandardDialog
        {
            get { return this.m_bUseAsStandardDialog; }
            set { this.m_bUseAsStandardDialog = value; }
        }

        #endregion

        #region MethodsPublic

        public BaseDialog()
        {
            InitializeComponent();
            this.m_bUseAsStandardDialog = true;
        }

        #endregion

        #region MethodsProtected

        // Derived Forms MUST override this method
        protected virtual bool SaveSettings()
        {
            // Code logic in derived Form
            return true;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (this.m_bUseAsStandardDialog == true)
            {
                this.AcceptButton = this.m_btnOk;
                this.CancelButton = this.m_btnCancel;
            }
            else
            {
                this.AcceptButton = null;
                this.CancelButton = null;
            }
        }
        // The Form class provides a Closing event that occurs
        // whenever the form is about to close. The protected
        // OnClosing method is invoked whenever the Close method
        // is called, and it in turn raises the Closing event by
        // invoking any registered event handlers.
        //
        // If Cancel is set to TRUE, then the close
        // operation is cancelled and the application will
        // continute to run.
        //
        // If Cancel is set to FALSE, then the close
        // operation is not cancelled and the application will
        // exit.
        protected override void OnClosing(CancelEventArgs e)
        {
            // If user clicked the OK button, make sure to
            // save the content. This must be done in the
            // SaveSettings() method in the derived Form.
            if (!e.Cancel && (this.DialogResult == DialogResult.OK))
            {
                // If SaveSettings() is OK (TRUE), then e.Cancel
                // will be FALSE, therefore the application will be exit.
                e.Cancel = !SaveSettings();
            }

            // Make sure any Closing event handler for the
            // form are called before the application exits.
            base.OnClosing(e);
        }
        protected void OnConfigurationChanged(EventArgs e)
        {
            if (this.ConfigurationChanged != null)
            {
                this.ConfigurationChanged(this, e);
            }
        }
        #endregion

        #region MethodsPrivate

        private void PanelContentResize(object sender, EventArgs e)
        {
        }

        #endregion

    }
}