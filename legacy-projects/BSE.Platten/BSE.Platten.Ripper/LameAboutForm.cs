using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using BSE.Platten.Common;
using System.Globalization;
using BSE.Platten.Ripper.Lame;

namespace BSE.Platten.Ripper
{
    /// <summary>
    /// The form that display the current lame version informations
    /// </summary>
    public partial class LameAboutForm : Form
    {
        #region MethodsPublic
        /// <summary>
        /// Initializes a new instance of the <see cref="LameAboutForm"/> class.
        /// </summary>
        public LameAboutForm()
        {
            InitializeComponent();
            /*
             * not in use since we changed the lame encoder; 
             */
            //BeVersion beVersion = new BeVersion();
            //try
            //{
            //    LameEncDll.NativeMethods.beVersion(beVersion);
            //    this.m_lblDllVersion.Text = string.Format(CultureInfo.InvariantCulture, "{0} {1}.{ 2}",
            //        this.m_lblDllVersion.Text,
            //        beVersion.byDLLMajorVersion,
            //        beVersion.byDLLMinorVersion);
            //    this.m_lblEncodingEngineVersion.Text = string.Format(CultureInfo.InvariantCulture, "{0} {1}.{2}",
            //        this.m_lblEncodingEngineVersion.Text,
            //        beVersion.byMajorVersion,
            //        beVersion.byMinorVersion);
            //    DateTime date = new DateTime(beVersion.wYear, beVersion.byMonth, beVersion.byDay);
            //    this.m_lblReleaseDate.Text = string.Format(CultureInfo.InvariantCulture,"{0} {1}",
            //        this.m_lblReleaseDate.Text,
            //        date.ToShortDateString());
            //    this.m_lnkLameHomepage.Text = beVersion.zHomepage;
            //    this.m_lnkLameHomepage.Links[0].LinkData = this.m_lnkLameHomepage.Text;
            //}
            //catch (Exception exception)
            //{
            //    GlobalizedMessageBox.Show(this,exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }
        #endregion

        #region MethodsPrivate

        private void m_lnkLameHomepage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string strTarget = e.Link.LinkData as string;
            e.Link.Visited = true;
            if (string.IsNullOrEmpty(strTarget) == false)
            {
                try
                {
                    System.Diagnostics.Process.Start(strTarget);
                }
                catch (Exception exception)
                {
                    GlobalizedMessageBox.Show(this,exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion
    }
}