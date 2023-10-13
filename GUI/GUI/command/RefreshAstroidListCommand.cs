using GUI.MVVM.Model;
using GUI.MVVM.ViewModel;
using GUI.services.implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GUI.command
{
    public class RefreshAstroidListCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        private readonly AstroidListVM _vm;

        public RefreshAstroidListCommand(AstroidListVM VM)
        {
            this._vm = VM;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter = null)
        {
            _vm.DateChange();
        }
    }
}
