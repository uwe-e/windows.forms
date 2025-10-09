using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.ComponentModel;
using System.IO;
using System.Globalization;
using BSE.Platten.Common.Properties;

namespace BSE.Platten.Common
{
    public class BaseFormSettingsData : BaseSettingsData
    {
        #region FieldsPrivate

        private Size m_clientSize;
        private FormWindowState m_windowState;
        private FormStartPosition m_startPosition;
        private Point m_desktopLocation;
        private Image m_backgroundImage;

        #endregion

        #region Properties

        public Size ClientSize
        {
            get { return this.m_clientSize; }
            set { this.m_clientSize = value; }
        }

        public FormWindowState WindowState
        {
            get { return this.m_windowState; }
            set { this.m_windowState = value; }
        }

        public FormStartPosition StartPosition
        {
            get { return this.m_startPosition; }
            set { this.m_startPosition = value; }
        }

        public Point DesktopLocation
        {
            get { return this.m_desktopLocation; }
            set { this.m_desktopLocation = value; }
        }
        [XmlIgnoreAttribute()]
        public Image BackgroundImage
        {
            get { return this.m_backgroundImage; }
            set { this.m_backgroundImage = value; }
        }
        // Serializes the 'Picture' Bitmap to XML.
        [XmlElementAttribute("BackgroundImage")]
        public byte[] BackgroundImageByteArray
        {
            get
            {
                if (this.BackgroundImage != null)
                {
                    TypeConverter BitmapConverter = TypeDescriptor.GetConverter(this.BackgroundImage.GetType());
                    return (byte[])BitmapConverter.ConvertTo(this.BackgroundImage, typeof(byte[]));
                }
                else
                {
                    return null;
                }
            }

            set
            {
                if (value != null)
                {
                    this.BackgroundImage = new Bitmap(new MemoryStream(value));
                }
                else
                {
                    this.BackgroundImage = null;
                }
            }
        }
        #endregion

        #region MethodsPublic

        public override BaseSettingsData LoadSettings(object objSettingsFor, BSE.Configuration.Configuration objConfiguration, BaseSettingsData baseSettingsData)
        {
            if (objSettingsFor == null)
            {
                throw new ArgumentNullException(
                    string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.IDS_ArgumentNullException, "objSettingsFor"));
            }
            if (objConfiguration == null)
            {
                throw new ArgumentNullException(
                    string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.IDS_ArgumentNullException, "objConfiguration"));
            }
            
            BaseFormSettingsData baseFormSettingsData = baseSettingsData as BaseFormSettingsData;
            if (baseFormSettingsData != null)
            {
                Form form = objSettingsFor as Form;
                if (form != null)
                {
                    baseFormSettingsData.ClientSize = form.Size;
                    baseFormSettingsData.StartPosition = form.StartPosition;
                    baseFormSettingsData = objConfiguration.GetValue(objSettingsFor.GetType().FullName, baseFormSettingsData.GetType().FullName, baseFormSettingsData) as BaseFormSettingsData;
                    if (baseFormSettingsData != null)
                    {
                        Size formClientSize = baseFormSettingsData.ClientSize;
                        if ((formClientSize.Height != 0) && (formClientSize.Width != 0))
                        {
                            form.Size = formClientSize;
                        }

                        form.StartPosition = baseFormSettingsData.StartPosition;
                        if (form.StartPosition == FormStartPosition.Manual)
                        {
                            form.DesktopLocation = baseFormSettingsData.DesktopLocation;
                        }
                    }
                }
            }
            return baseFormSettingsData;
        }

        public override BaseSettingsData SaveSettings(object objSettingsFor, BSE.Configuration.Configuration objConfiguration, BaseSettingsData baseSettingsData)
        {
            if (objSettingsFor == null)
            {
                throw new ArgumentNullException(
                    string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.IDS_ArgumentNullException, "objSettingsFor"));
            }
            if (objConfiguration == null)
            {
                throw new ArgumentNullException(
                    string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.IDS_ArgumentNullException, "objConfiguration"));
            }

            BaseFormSettingsData baseFormSettingsData = baseSettingsData as BaseFormSettingsData;
            if (baseFormSettingsData != null)
            {
                Form form = objSettingsFor as Form;
                if (form != null)
                {
                    if (form.StartPosition != FormStartPosition.Manual)
                    {
                        baseFormSettingsData.StartPosition = FormStartPosition.Manual;
                    }
                    
                    baseFormSettingsData.WindowState = form.WindowState;
                    if (form.WindowState == System.Windows.Forms.FormWindowState.Normal)
                    {
                        baseFormSettingsData.ClientSize = form.Size;
                        baseFormSettingsData.DesktopLocation = form.DesktopLocation;
                    }
                    else
                    {
                        baseFormSettingsData.ClientSize = form.RestoreBounds.Size;
                        baseFormSettingsData.DesktopLocation = form.RestoreBounds.Location;
                        //TODO: Workaround when the windows taskbar is positioned at the left side
                        if (Screen.PrimaryScreen.WorkingArea.Left > 0)
                        {
                            baseFormSettingsData.DesktopLocation = new Point(
                                form.RestoreBounds.Location.X - Screen.PrimaryScreen.WorkingArea.Left,
                                form.RestoreBounds.Location.Y);
                        }
                    }
                    objConfiguration.SetValue(objSettingsFor.GetType().FullName, baseFormSettingsData.GetType().FullName, baseFormSettingsData);
                }
            }
            return baseFormSettingsData;
        }

        #endregion
    }
}
