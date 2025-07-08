﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace pr41.ViewModel
{
    public class RelayCommand:ICommand
    {
        private Action<object> _execute;
        private Func<object, bool> canExecute;
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parametr)
        {
            return canExecute == null || canExecute(parametr);
        }

        public void Execute(object parametr) =>
            _execute(parametr);
    }
}
