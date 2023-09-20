using DATA_CLASSES;
using GUI.services;
using GUI.services.implementation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GUI.UserControlls
{
    /// <summary>
    /// Interaction logic for IssTrackerUserControl.xaml
    /// </summary>
    public partial class IssTrackerUserControl : UserControl , INotifyPropertyChanged
    {

        public IssLocationResponse  _IssLocation { get; set; }
 
        public IssLocationResponse IssLocation
        {
            get { return  _IssLocation; }
            set
            {
              _IssLocation = value;
                OnPropertyChanged("IssLocation");
            }
        }
        public  IssTrackerUserControl()
        {
            InitializeComponent();

            DataContext = this;

           
 
        }

        private async void IssTrackerUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var client = new IssClient();

            IssLocation = await client.GetIssLocation();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
