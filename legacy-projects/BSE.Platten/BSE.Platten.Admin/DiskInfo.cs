using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Management;

using BSE.Platten.BO;
using System.Globalization;
using BSE.Platten.Common;
using BSE.Platten.Admin.Properties;

namespace BSE.Platten.Admin
{
    public partial class DiskInfo : BSE.Platten.Admin.BaseForm
    {
        #region Konstanten

        private const long GIGABYTE = 1073741824;
        private Color m_colorUsedSpace = Color.Blue;
        private Color m_colorFreeSpace = Color.Magenta;

        #endregion
        
        #region FieldsPrivate

        BSE.Platten.BO.Environment m_environment;

        #endregion

        #region MethodsPublic
        public DiskInfo()
        {
            InitializeComponent();
            this.m_picUsedSpace.BackColor = m_colorUsedSpace;
            this.m_picFreeSpace.BackColor = m_colorFreeSpace;
            this.m_btnCancel.Left = (this.Width - this.m_btnCancel.Width) / 2;
        }
        public DiskInfo(BSE.Platten.BO.Environment environment) : this()
        {
            this.m_environment = environment;
        }
        #endregion
        
        #region MethodsPrivate
        private void CDiskInfo_Load(object sender, EventArgs e)
        {
            if (this.m_environment != null)
            {
                try
                {
                    string strAudioHomeDirectory = this.m_environment.GetAudioHomeDirectory();
                    this.m_grpDiskInfo.Text += " " + strAudioHomeDirectory;
                    if (strAudioHomeDirectory.StartsWith(System.IO.Path.DirectorySeparatorChar.ToString() +
                        System.IO.Path.DirectorySeparatorChar.ToString(), StringComparison.OrdinalIgnoreCase) == true)
                    {
                        string strException = String.Format(CultureInfo.CurrentUICulture,Resources.IDS_NetworkShareException);

                        GlobalizedMessageBox.Show(this, strException, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        
                        this.m_lblUsedSpaceBytes.Text = String.Format(CultureInfo.CurrentUICulture,"{0} Bytes", 0);
                        this.m_lblUsedSpaceGBytes.Text = String.Format(CultureInfo.CurrentUICulture, "{0} GB", 0);
                        this.m_lblFreeSpaceBytes.Text = String.Format(CultureInfo.CurrentUICulture, "{0} Bytes", 0);
                        this.m_lblFreeSpaceGBytes.Text = String.Format(CultureInfo.CurrentUICulture, "{0} GB", 0);
                        
                    }
                    else
                    {
                        GetDiskInfo(strAudioHomeDirectory);
                    }
                }
                catch (BSE.Configuration.ConfigurationValueNotFoundException configurationValueNotFoundException)
                {
                    GlobalizedMessageBox.Show(this, configurationValueNotFoundException.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                }
                catch (Exception exception)
                {
                    GlobalizedMessageBox.Show(this, exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
        }

        private void GetDiskInfo(string strDrive)
        {
            if (strDrive.StartsWith(System.IO.Path.DirectorySeparatorChar.ToString() +
                System.IO.Path.DirectorySeparatorChar.ToString(), StringComparison.OrdinalIgnoreCase) == false)
            {
                strDrive = strDrive.Substring(0, strDrive.IndexOf("\\", StringComparison.OrdinalIgnoreCase));
                using (ManagementObject managementObject = new ManagementObject("Win32_LogicalDisk.DeviceID=\"" + strDrive + "\""))
                {

                    long lFreeSpace = (long)Convert.ToUInt64(managementObject.Properties["FreeSpace"].Value,CultureInfo.InvariantCulture);
                    long lSize = (long)Convert.ToUInt64(managementObject.Properties["Size"].Value,CultureInfo.InvariantCulture);
                    long lUsedSpace = lSize - lFreeSpace;

                    double dUsedSpace = (double)lUsedSpace / GIGABYTE;
                    double dFreeSpace = (double)lFreeSpace / GIGABYTE;

                    Charts.ChartItem itemUsedSpace = new BSE.Charts.ChartItem();
                    itemUsedSpace.Color = m_colorUsedSpace;
                    itemUsedSpace.Value = (float)dUsedSpace;
                    this.m_chrtDiskInfo.ChartItems.Add(itemUsedSpace);

                    Charts.ChartItem itemFreeSpace = new BSE.Charts.ChartItem();
                    itemFreeSpace.Color = m_colorFreeSpace;
                    itemFreeSpace.Value = (float)dFreeSpace;
                    this.m_chrtDiskInfo.ChartItems.Add(itemFreeSpace);

                    this.m_lblUsedSpaceBytes.Text = String.Format(CultureInfo.InvariantCulture, "{0} Bytes", lUsedSpace.ToString("N0",CultureInfo.InvariantCulture));
                    this.m_lblUsedSpaceGBytes.Text = String.Format(CultureInfo.InvariantCulture, "{0} GB", dUsedSpace.ToString("N", CultureInfo.InvariantCulture));
                    this.m_lblFreeSpaceBytes.Text = String.Format(CultureInfo.InvariantCulture, "{0} Bytes", lFreeSpace.ToString("N0", CultureInfo.InvariantCulture));
                    this.m_lblFreeSpaceGBytes.Text = String.Format(CultureInfo.InvariantCulture, "{0} GB", dFreeSpace.ToString("N", CultureInfo.InvariantCulture));
                }
            }
        }
        #endregion
    }
}

