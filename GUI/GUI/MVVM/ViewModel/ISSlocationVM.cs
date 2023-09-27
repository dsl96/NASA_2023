using GUI.models;
using GUI.services;
using GUI.services.implementation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GUI.MVVM.ViewModel
{
    internal class ISSlocationVM:ViewModelBase
    {

        public IssLocationResponse _IssLocation { get; set; }

        public IssLocationResponse IssLocation
        {
            get { return _IssLocation; }
            set
            {
                _IssLocation = value;
                OnPropertyChanged("IssLocation");
            }
        }

        ISSlocationVM()
        {
            
        }
        private async void IssTrackerUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            IssLocation = await new IssClient().GetIssLocation();
        }

    }
}
