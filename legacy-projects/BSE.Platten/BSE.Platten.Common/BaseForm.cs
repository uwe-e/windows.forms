using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using BSE.Windows.Forms;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using BSE.Windows.Forms.Form;

namespace BSE.Platten.Common
{
    public partial class BaseForm : Form
    //public partial class BaseForm : MetroForm
    {
        #region EventsPublic
        /// <summary>
        /// Occurs when the PanelColors have been changed.
        /// </summary>
        [Description("Occurs when the PanelColors have been changed.")]
        public event EventHandler<EventArgs> PanelColorsChanged;

        #endregion
        
        #region FieldsPrivate

        private BSE.Windows.Forms.ProfessionalColorTable m_professionalColorTable;
        private BSE.Windows.Forms.PanelColors m_panelColors;
        private BSE.Windows.Forms.PanelStyle m_ePanelStyle;
        private uint m_iQueryCancelAutoPlay;

        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the panelcolors table.
        /// </summary>
        [System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public BSE.Windows.Forms.PanelColors PanelColors
        {
            get { return this.m_panelColors; }
            set
            {
                if (value != null)
                {
                    this.m_panelColors = value;
                    OnPanelColorsChanged(this, EventArgs.Empty);
                }
            }
        }
        /// <summary>
        /// Gets or sets the style of the panel.
        /// </summary>
        [System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public BSE.Windows.Forms.PanelStyle PanelStyle
        {
            get { return this.m_ePanelStyle; }
            set { this.m_ePanelStyle = value; }
        }
        /// <summary>
        /// Gets or sets the ProfessionalColorTable
        /// </summary>
        [System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public BSE.Windows.Forms.ProfessionalColorTable ProfessionalColorTable
        {
            get { return this.m_professionalColorTable; }
            set
            {
                if (value != null)
                {
                    this.m_professionalColorTable = value;
                    ChangeColors(this.ContentPanel);
                }
            }
        }
        #endregion

        #region MethodsPublic

        public BaseForm()
        {
            InitializeComponent();
            ToolStripProfessionalRenderer toolStripRenderer = new BSE.Windows.Forms.MetroRenderer();
            ToolStripManager.Renderer = toolStripRenderer;
            BSE.Windows.Forms.ProfessionalColorTable colorTable = toolStripRenderer.ColorTable as BSE.Windows.Forms.ProfessionalColorTable;
            if (colorTable != null)
            {
                this.ProfessionalColorTable = colorTable;
                BSE.Windows.Forms.PanelColors panelColorTable = colorTable.PanelColorTable;
                if (panelColorTable != null)
                {
                    this.PanelColors = panelColorTable;
                }
            }
            this.BackColor = BSEColors.FormBackroundColor;
            //this.BorderColor = BSEColors.FormBorderColor;
            this.ContentPanel.Dock = DockStyle.Fill;
            //this.m_ePanelStyle = PanelStyle.Office2007;
            //this.PanelStyle = Windows.Forms.PanelStyle.Default;
            //this.PanelColors = new BSE.Windows.Forms.PanelColors();
            PanelSettingsManager.SetPanelProperties(this.Controls, this.PanelColors);
            
        }
        /// <summary>
        /// Change the colors for certain objects.
        /// </summary>
        /// <param name="control">the controls that should change the color</param>
        public void ChangeColors(Control control)
        {
            TextBox textBox = control as TextBox;
            if (textBox != null)
            {
                if (textBox.ReadOnly == true)
                {
                    Color backColor = ProfessionalColors.ToolStripContentPanelGradientBegin;
                    if (this.m_professionalColorTable != null)
                    {
                        backColor = this.m_professionalColorTable.ToolStripContentPanelGradientBegin;
                       	if (typeof(BSE.Windows.Forms.ProfessionalColorTable).IsAssignableFrom(this.m_professionalColorTable.GetType()))
                        {
                            textBox.ForeColor = this.m_professionalColorTable.MenuItemText;
                        }
                        else
                        {
                            textBox.ForeColor = SystemColors.ControlText;
                        }
                    }
                    textBox.BackColor = backColor;
                }
            }
            Label label = control as Label;
            if ((label != null)
                && (this.m_professionalColorTable != null)
                && (label.GetType() != typeof(UnchangeableLabel))
                && (typeof(BSE.Windows.Forms.ProfessionalColorTable).IsAssignableFrom(this.m_professionalColorTable.GetType())))
            {
                if (this.m_professionalColorTable != null)
                {
                    label.ForeColor = this.m_professionalColorTable.MenuItemText;
                }
            }
            CheckBox checkBox = control as CheckBox;
            if (checkBox != null)
            {
                if (this.m_professionalColorTable != null)
                {
                    checkBox.ForeColor = this.m_professionalColorTable.MenuItemText;
                }
            }
            GroupBox groupBox = control as GroupBox;
            if (groupBox != null)
            {
                if ((this.m_professionalColorTable != null)
                    && (typeof(BSE.Windows.Forms.ProfessionalColorTable).IsAssignableFrom(this.m_professionalColorTable.GetType())))
                {

                    groupBox.ForeColor = this.m_professionalColorTable.MenuItemText;
                }
                else
                {
                    groupBox.ForeColor = SystemColors.ControlText;
                }
            }
            if ((control != null) && (control.HasChildren == true))
            {
                // Recursively call this method for each child control.
                foreach (Control childControl in control.Controls)
                {
                    ChangeColors(childControl);
                }
            }
        }

        #endregion

        #region MethodsProtected
        /// <summary>
        /// Raises the <see cref="Form.Load"/> event.
        /// </summary>
        /// <param name="e">An <see cref="System.EventArgs"/>that contains the event data.</param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Localize();
        }
        /// <summary>
        /// Method for localization.
        /// </summary>
        protected virtual void Localize()
        {
        }
        /// <summary>
        /// Processes Windows messages.
        /// </summary>
        /// <param name="m">The Windows <see cref="Message"/> to process.</param>
        [SecurityPermissionAttribute(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        protected override void WndProc(ref Message m)
        {
            if (this.m_iQueryCancelAutoPlay == 0)
            {
                this.m_iQueryCancelAutoPlay = NativeMethods.RegisterWindowMessage("QueryCancelAutoPlay");
            }
            if (m.Msg == this.m_iQueryCancelAutoPlay)
            {
                m.Result = (IntPtr)1;
            }
            else
            {
                base.WndProc(ref m);
            }
        }
        /// <summary>
        /// Raises the System.Windows.Forms.Control.SystemColorsChanged event.
        /// </summary>
        /// <param name="e">A EventArgs that contains the event data.</param>
        protected override void OnSystemColorsChanged(EventArgs e)
        {
            ChangeColors(this.ContentPanel);
            base.OnSystemColorsChanged(e);
        }
        /// <summary>
        /// Raises the PanelColorsChanged event.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">A EventArgs that contains the event data.</param>
        protected virtual void OnPanelColorsChanged(object sender, EventArgs e)
        {
            if (this.m_panelColors != null)
            {
                BSE.Windows.Forms.PanelSettingsManager.SetPanelProperties(
                    this.ContentPanel.Controls,
                    this.m_ePanelStyle,
                    this.m_panelColors);
                this.Invalidate();
            }
            if (this.PanelColorsChanged != null)
            {
                this.PanelColorsChanged(sender, e);
            }
        }
        /// <summary>
        /// Raises the KeyUp event.
        /// </summary>
        /// <param name="e">A EventArgs that contains the event data.</param>
        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            if (e.KeyCode == Keys.X)
            {
                if (e.Modifiers == Keys.Control)
                {
                    if (this.ContentPanel.BackgroundImage != null)
                    {
                        this.ContentPanel.BackgroundImage = null;
                    }
                }
            }
        }
        /// <summary>
        /// Raises the DragEnter event.
        /// </summary>
        /// <param name="drgevent">A DragEventArgs that contains the event data</param>
        protected override void OnDragEnter(DragEventArgs drgevent)
        {
            base.OnDragEnter(drgevent);
            if (drgevent.Data is DataObject)
            {
                drgevent.Effect = DragDropEffects.Move;
            }
        }
        /// <summary>
        /// Raises the DragDrop event.
        /// </summary>
        /// <param name="drgevent">A DragEventArgs that contains the event data</param>
        protected override void OnDragDrop(DragEventArgs drgevent)
        {
            base.OnDragDrop(drgevent);
            if (drgevent.Data is DataObject)
            {
                DataObject dataObject = drgevent.Data as DataObject;
                if (dataObject.ContainsFileDropList() == true)
                {
                    try
                    {
                        System.Collections.Specialized.StringCollection files = dataObject.GetFileDropList();
                        System.IO.FileInfo fileInfo = new System.IO.FileInfo(files[0]);
                        if (fileInfo.Exists == true)
                        {
                            if (BSE.Platten.BO.CCoverData.IsAllowedCoverExtension(fileInfo.Extension) == true)
                            {
                                Image image = Bitmap.FromFile(fileInfo.FullName);
                                if (image != null)
                                {
                                    this.ContentPanel.BackgroundImage = image;
                                    this.ContentPanel.BackgroundImageLayout = ImageLayout.Tile;
                                }
                            }
                        }
                    }
                    catch
                    {
                    }
                }
            }
        }
        #endregion

        #region MethodsPrivate

        internal class NativeMethods
        {
            /// <summary>
            /// The RegisterWindowMessage function defines a new window message that is guaranteed to be unique
            /// throughout the system. The message value can be used when sending or posting messages.
            /// </summary>
            /// <param name="lpString">Pointer to a null-terminated string that specifies the message to be registered.</param>
            /// <returns>If the message is successfully registered, the return value is a message identifier
            /// in the range 0xC000 through 0xFFFF.</returns>
            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            internal static extern uint RegisterWindowMessage(string lpString);
        }
        
        #endregion
    }

    public static class GlobalizedMessageBox
    {
        /// <summary>
        /// Displays a message box with the specified text, buttons, icon and builds the caption from
        /// the IWin32Window functions.
        /// </summary>
        /// <param name="owner">An implementation of IWin32Window that will own the modal dialog box.</param>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="buttons">One of the MessageBoxButtons values that specifies which buttons to display
        /// in the message box.</param>
        /// <param name="icon">One of the MessageBoxIcon values that specifies which icon to display
        /// in the message box</param>
        /// <returns></returns>
        public static DialogResult Show(IWin32Window owner, string text,MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            string strMessageBoxCaption = string.Empty;
            Form form = owner as Form;
            if (form != null)
            {
                strMessageBoxCaption = form.Text;
            }
            if (string.IsNullOrEmpty(strMessageBoxCaption) == true)
            {
                Control control = owner as Control;
                if (control != null)
                {
                    if (control.FindForm() != null)
                    {
                        strMessageBoxCaption = control.FindForm().Text;
                    }
                }
            }
            return Show(owner, text, strMessageBoxCaption, buttons, icon);
        }
        /// <summary>
        /// Displays a message box with the specified text, caption, buttons, icon.
        /// </summary>
        /// <param name="owner">An implementation of IWin32Window that will own the modal dialog box.</param>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="buttons">One of the MessageBoxButtons values that specifies which buttons to display
        /// in the message box.</param>
        /// <param name="icon">One of the MessageBoxIcon values that specifies which icon to display
        /// in the message box.</param>
        /// <returns></returns>
        public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons,
            MessageBoxIcon icon)
        {
            MessageBoxOptions options = (MessageBoxOptions)0;
            MessageBoxDefaultButton defaultButton = MessageBoxDefaultButton.Button1;
            return Show(owner, text, caption, buttons, icon, defaultButton, options);
        }
        /// <summary>
        /// Displays a message box in front of the specified object and with the specified text,
        /// caption, buttons, icon, default button, and options.
        /// </summary>
        /// <param name="owner">An implementation of IWin32Window that will own the modal dialog box.</param>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="buttons">One of the MessageBoxButtons values that specifies which buttons to display
        /// in the message box.</param>
        /// <param name="icon">One of the MessageBoxIcon values that specifies which icon to display in the message
        /// box.</param>
        /// <param name="defaultButton">One of the MessageBoxDefaultButton values the specifies the default button
        /// for the message box.</param>
        /// <param name="options">One of the MessageBoxOptions values that specifies which display and association
        /// options will be used for the message box. You may pass in 0 if you wish to use the defaults.</param>
        /// <returns></returns>
        public static DialogResult Show (IWin32Window owner,string text,string caption,MessageBoxButtons buttons,
            MessageBoxIcon icon,MessageBoxDefaultButton defaultButton, MessageBoxOptions options)
        {
            if (IsRightToLeft(owner))
            {
                options |= MessageBoxOptions.RtlReading | MessageBoxOptions.RightAlign;
            }
            return MessageBox.Show(owner, text, caption, buttons, icon, defaultButton, options);
        }

        private static bool IsRightToLeft(IWin32Window owner)
        {
            Control control = owner as Control;
            if (control != null)
            {
                return control.RightToLeft == RightToLeft.Yes;
            }
            // If no parent control is available, ask the CurrentUICulture
            // if we are running under right-to-left.
            return CultureInfo.CurrentUICulture.TextInfo.IsRightToLeft;
        }
    }
}