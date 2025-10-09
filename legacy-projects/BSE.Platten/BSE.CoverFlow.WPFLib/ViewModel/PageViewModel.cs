using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BSE.CoverFlow.WPFLib.ViewModel
{
    public class PageViewModel : EnvironmentViewModel
    {
        #region FieldsPrivate
        private string m_strHeader;
        private bool m_bIsPersistent;
        private bool m_bIsVisible;
        #endregion

        #region Properties
        public string Header
        {
            get { return this.m_strHeader; }
            set
            {
                this.m_strHeader = value;
                this.OnPropertyChanged("Header");
            }
        }
        public bool IsPersistent
        {
            get
            {
                return this.m_bIsPersistent;
            }
            set
            {
                this.m_bIsPersistent = value;
                this.OnPropertyChanged("IsPersistent");
            }
        }
        public bool IsVisible
        {
            get
            {
                return this.m_bIsVisible;
            }
            set
            {
                this.m_bIsVisible = value;
                base.OnPropertyChanged("IsVisible");
            }
        }
        #endregion

        #region MethodsPublic
        public PageViewModel()
        {
        }

        public PageViewModel(BSE.Platten.BO.Environment environment)
            : base(environment)
        {
        }
        #endregion
    }
}
