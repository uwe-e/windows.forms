using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using BSE.Platten.BO;
using BSE.Platten.Admin.Properties;
using System.Globalization;
using BSE.Platten.Common;

namespace BSE.Platten.Admin
{
    public partial class MySqlConnect : BaseForm
    {
        #region Events

        public event EventHandler ConfigurationChanged;

        #endregion

        #region FieldsPrivate
        private BSE.Platten.BO.Environment m_environment;
        private bool m_bCancel;
        #endregion

        #region MethodsPublic

        public MySqlConnect()
        {
            InitializeComponent();
        }

        public MySqlConnect(BSE.Platten.BO.Environment environment)
            : this()
        {
            if (environment == null)
            {
                throw new ArgumentNullException(
                    string.Format(CultureInfo.InvariantCulture,Resources.IDS_ArgumentNullException,"environment"));
            }
            this.m_environment = environment;
            this.m_txtHost.Text = this.m_environment.GetDatabaseHost();
            this.m_txtPort.Text = this.m_environment.GetDatabasePort().ToString(CultureInfo.InvariantCulture);
        }

        #endregion

        #region MethodsProtected

        protected void OnConfigurationChanged(EventArgs e)
        {
            if (ConfigurationChanged != null)
            {
                ConfigurationChanged(this, e);
            }
        }

        #endregion

        #region MethodsPrivate

        private void m_btnConnect_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.m_txtUser.Text) == true)
            {
                GlobalizedMessageBox.Show(this, Resources.IDS_MySqlConnectNoUserNameException, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.m_bCancel = true;
                return;
            }
            if (String.IsNullOrEmpty(this.m_txtPassword.Text) == true)
            {
                GlobalizedMessageBox.Show(this, Resources.IDS_MySqlConnectNoPasswordException, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.m_bCancel = true;
                return;
            }
            if (String.IsNullOrEmpty(this.m_txtPort.Text) == true)
            {
                GlobalizedMessageBox.Show(this, Resources.IDS_MySqlConnectNoTcpIpPortException, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.m_bCancel = true;
                return;
            }
            this.m_environment.UserName = this.m_txtUser.Text;
            this.m_environment.Password = this.m_txtPassword.Text;
            this.m_environment.DataBaseHost = this.m_txtHost.Text;
            this.m_environment.DataBasePort = (int)this.m_txtPort.Value;
            OnConfigurationChanged(new EventArgs());

        }

        private void m_btnCancel_Click(object sender, EventArgs e)
        {
            this.m_bCancel = false;
        }
        
        private void CMySqlConnect_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = this.m_bCancel;
        }

        #endregion
       
    }
}