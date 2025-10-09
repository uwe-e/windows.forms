using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using BSE.CoverFlow.WPFLib.Input;

namespace BSE.CoverFlow.WPFLib.ViewModel
{
    public class BaseDialogViewModel : EnvironmentViewModel, IDialogModel
    {
        #region FieldsPrivate
        private bool m_bIsOpen;
        private bool? m_dialogResult;
        private ICommand m_dialogOKCommand;
        private RelayCommand m_dialogCancelCommand;
        #endregion

        #region Properties
        public bool IsOpen
        {
            get { return this.m_bIsOpen; }
            set
            {
                this.m_bIsOpen = value;
                this.OnPropertyChanged("IsOpen");
            }
        }
        public bool? DialogResult
        {
            get
            {
                return this.m_dialogResult;
            }
            set
            {
                this.m_dialogResult = value;
                this.OnPropertyChanged("DialogResult");
            }
        }
        public ICommand DialogOkCommand
        {
            get
            {
                if (this.m_dialogOKCommand == null)
                {
                    this.m_dialogOKCommand = new RelayCommand(
                        this.DialogOK);
                }
                return this.m_dialogOKCommand;
            }
        }
        public ICommand DialogCancelCommand
        {
            get
            {
                if (this.m_dialogCancelCommand == null)
                {
                    this.m_dialogCancelCommand = new RelayCommand(DialogCancel);

                }
                return this.m_dialogCancelCommand;
            }
        }
        #endregion

        #region MethodsPublic
        public BaseDialogViewModel()
        {
            
        }
        public BaseDialogViewModel(BSE.Platten.BO.Environment environment)
            : base(environment)
        {
        }
        public void Close()
        {
            this.IsOpen = false;
        }
        public virtual bool SaveData()
        {
            return true;
        }
        #endregion

        #region MethodsProtected
        protected virtual void DialogOK(object parameter)
        {
            if (this.SaveData() == true)
            {
                this.DialogResult = true;
                this.Close();
            }
        }
        protected virtual void DialogCancel(object parameter)
        {
            this.DialogResult = false;
            this.Close();
        }
        #endregion
    }
}
