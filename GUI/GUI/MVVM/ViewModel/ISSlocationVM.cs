using GUI.command;
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

        public RefreshISScomand refreshISScomand { get; set; }

        private IssClient _IssClient { get; set; }

        public IssLocationResponse IssLocation
        {
            get { return _IssLocation; }
            set
            {
                _IssLocation = value;
                OnPropertyChanged("IssLocation");
            }
        }

        public ISSlocationVM()
        {
            var issLocation = new IssClient().GetIssLocation();

            refreshISScomand = new RefreshISScomand(this);

        }
    }
}
