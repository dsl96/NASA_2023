using GUI.MVVM.ViewModel;
using GUI.services.implementation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GUI.command
{
    internal class RefreshISScomand :ICommand
    {

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        private readonly ISSlocationVM ISSvm;

        public RefreshISScomand(ISSlocationVM VM)
        {
            ISSvm = VM;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter = null)
        {
            ISSvm.IssLocation = await new IssClient().GetIssLocation();
        }
    }
}
