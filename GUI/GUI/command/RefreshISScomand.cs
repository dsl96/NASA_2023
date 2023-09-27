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
    internal class RefreshISScomand : ICommand
    {

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        ISSlocationVM ISSvm;

        public RefreshISScomand(ISSlocationVM VM)
        {
            ISSvm = VM;
        }

        bool CanExecute(object parameter)
        {
            return true;
        }

        void Execute(object parameter)
        {
            IssTrackerUserControl_Loaded();
        }

        internal async void IssTrackerUserControl_Loaded()
        {
            ISSvm.IssLocation = await new IssClient().GetIssLocation();
        }

    }
}
