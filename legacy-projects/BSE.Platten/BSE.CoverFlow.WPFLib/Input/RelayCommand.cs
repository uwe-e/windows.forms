using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace BSE.CoverFlow.WPFLib.Input
{
    public class RelayCommand : ICommand
    {
        #region Events
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        #endregion

        #region FieldsPrivate
        private readonly Action<object> m_execute;
        private readonly Predicate<object> m_canExecute;
        #endregion

        #region MethodsPublic
        public RelayCommand(Action<object> execute)
            : this(execute, null)
        {
        }
        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");

            this.m_execute = execute;
            this.m_canExecute = canExecute;
        }
        public bool CanExecute(object parameter)
        {
            return this.m_canExecute == null ? true : this.m_canExecute(parameter);
        }
        public void Execute(object parameter)
        {
            this.m_execute(parameter);
        }
        #endregion
    }
}
