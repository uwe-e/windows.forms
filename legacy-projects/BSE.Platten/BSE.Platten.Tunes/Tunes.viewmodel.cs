using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BSE.CoverFlow.WPFLib.ViewModel;
using System.Windows.Forms.Integration;
using BSE.CoverFlow.WPFLib.Caption;

namespace BSE.Platten.Tunes
{
    public partial class Tunes
    {
        #region FieldsPrivate
        private CaptionMenuViewModel m_captionViewModel;
        private ElementHost m_elementHostWindowHeader;
        private TunesCaption m_tunesCaption;
        private DesktopViewModel m_desktopViewModel;
        #endregion

        #region MethodsPrivate
        private void InitializeViewModels()
        {
            this.m_captionViewModel = new CaptionMenuViewModel();
            this.m_captionViewModel.ExecuteAdministration += new EventHandler<EventArgs>(OnExecuteAdmin);
            this.m_captionViewModel.ExecuteFilters += new EventHandler<EventArgs>(FilterPropertiesClick);
            this.m_captionViewModel.ExecuteSettings += new EventHandler<EventArgs>(OptionenClick);
            this.m_captionViewModel.ExecuteStatistics += new EventHandler<EventArgs>(OnExecuteStatistics);
            this.m_tunesCaption = new TunesCaption();
            this.m_tunesCaption.DataContext = this.m_captionViewModel;
            this.m_elementHostWindowHeader = new ElementHost();
            this.m_elementHostWindowHeader.Child = this.m_tunesCaption;
            this.m_elementHostWindowHeader.Dock = System.Windows.Forms.DockStyle.Right;
            //this.Caption.Controls.Add(this.m_elementHostWindowHeader);
        }
        #endregion
    }
}
