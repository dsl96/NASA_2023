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

        public string _url { get; set; }
 
        public string url
        {
            get { return _url; }
            set
            {
                _url = value;
                OnPropertyChanged("url");
            }
        }
        public IssTrackerUserControl()
        {
            InitializeComponent();

            IWorldMapClient c = new WorldMapClient();



            url =  @"https://maps.geoapify.com/v1/staticmap?style=klokantech-basic&width=665&height=660&center=lonlat:16.804209,0&zoom=0.3772&center=lonlat:14.658025,0&apiKey=d548c5ed24604be6a9dd0d989631f783";
            url = c.GetMapUrl(new models.Coordinate( - 51.4928, -176.9762));
            DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
