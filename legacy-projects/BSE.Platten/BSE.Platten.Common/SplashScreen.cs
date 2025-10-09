using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace BSE.Platten.Common
{
    public partial class CSplashScreen : Form
    {
        #region Delegates

        private delegate void DelegateCloseSplashScreen();
        private delegate void DelegateSetStatusText(string strStatusText, int iProgressStep, int iProgressStepsTotal);

        #endregion

        #region FieldsPrivate

        private static CSplashScreen m_splashScreen;
        private DelegateCloseSplashScreen m_delegateCloseSplashScreen;
        private DelegateSetStatusText m_delegateSetStatusText;
        private Rectangle m_rectangleProgress;
        private static Thread m_instanceCallerThread;

        #endregion

        #region Properties

        public static CSplashScreen SplashScreen
        {
            get { return m_splashScreen; }
        }

        #endregion

        #region MethodsPublic

        public CSplashScreen()
        {
            InitializeComponent();
            this.m_pnlStatus.Visible = false;
            this.m_lblStatusMessage.Text = String.Empty;
            this.m_delegateCloseSplashScreen = new DelegateCloseSplashScreen(CloseForm);
            this.m_delegateSetStatusText = new DelegateSetStatusText(SetStatusText);
        }

        public static void ShowSplashScreen()
        {
            m_instanceCallerThread = new Thread(new ThreadStart(ShowForm));
            m_instanceCallerThread.IsBackground = true;
            m_instanceCallerThread.Start();
        }

        public static void CloseSplashScreen(Form parentForm)
        {
            if ((m_splashScreen != null) && (m_splashScreen.IsDisposed == false))
            {
                if (parentForm != null)
                {
                    parentForm.Activate();
                }
                m_splashScreen.Invoke(new DelegateCloseSplashScreen(m_splashScreen.m_delegateCloseSplashScreen));
            }
        }

        public static void SetStatusMessage(string strStatusText, int iProgressStep, int iProgressStepsTotal)
        {
            if (m_splashScreen != null)
            {
                while (m_splashScreen.IsHandleCreated == false);
                m_splashScreen.Invoke(new DelegateSetStatusText(m_splashScreen.m_delegateSetStatusText),
                    new object[] { strStatusText, iProgressStep, iProgressStepsTotal });
            }
        }

        #endregion

        #region MethodsPrivate

        private static void ShowForm()
        {
            m_splashScreen = new CSplashScreen();
            if (m_splashScreen.BackgroundImage != null)
            {
                m_splashScreen.ClientSize = m_splashScreen.BackgroundImage.Size;
            }
            m_splashScreen.StartPosition = FormStartPosition.CenterScreen;
            m_splashScreen.ShowInTaskbar = false;
            m_splashScreen.ShowDialog();
        }

        private void CloseForm()
        {
            if (m_splashScreen != null)
            {
                m_splashScreen.Dispose();
                m_splashScreen = null;
            }

            this.Close();
            this.Dispose();
        }

        private void SplashScreenMouseClick(object sender, MouseEventArgs e)
        {
            CloseForm();
        }

        private void SetStatusText(string strStatusText, int iProgressStep, int iProgressStepsTotal)
        {
            if (this.m_pnlStatus.Visible == false)
            {
                this.m_pnlStatus.Visible = true;
            }
            this.m_lblStatusMessage.Text = strStatusText;
            int iProgressX = this.m_pnlStatus.ClientRectangle.X;
            int iProgressY = this.m_pnlStatus.ClientRectangle.Y;
            int iProgressHeight = this.m_pnlStatus.ClientRectangle.Height;
            int iPogressWidth = (int)this.m_pnlStatus.ClientRectangle.Width * iProgressStep / iProgressStepsTotal;

            this.m_rectangleProgress = new Rectangle(
                iProgressX,
                iProgressY,
                iPogressWidth,
                iProgressHeight);

            this.m_pnlStatus.Invalidate(this.m_rectangleProgress);
        }

        private void PanelStatusPaint(object sender, PaintEventArgs e)
        {
            Rectangle rectangleProgress = new Rectangle(this.m_pnlStatus.Location, new Size(this.m_pnlStatus.Width, this.m_pnlStatus.Height));
            System.Drawing.Drawing2D.LinearGradientBrush brBackground
                = new System.Drawing.Drawing2D.LinearGradientBrush(
                rectangleProgress,
                Color.FromArgb(58, 96, 151),
                Color.FromArgb(181, 237, 254),
                System.Drawing.Drawing2D.LinearGradientMode.Horizontal);
            e.Graphics.FillRectangle(brBackground, this.m_rectangleProgress);
        }

        #endregion
    }
}