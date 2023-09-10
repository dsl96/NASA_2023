using GUI.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
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
using static System.Net.Mime.MediaTypeNames;

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        NasaClient client;
        public  MainWindow()
        {
            InitializeComponent();

            DataContext = this;


             client = new NasaClient();

          
 
        }

        private string imageUrl;

        public string ImageUrl
        {
            get { return imageUrl; }
            set
            {
                if (imageUrl != value)
                {
                    imageUrl = value;
                    OnPropertyChanged("ImageUrl");
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private async void loadImage( )
        {
            var dailyImg = await client.GetDailyImage();

          
            if (dailyImg != null)
            {

                if(dailyImg.HdUrl!= null)
                   ImageUrl =  dailyImg.HdUrl ;
                else
                {
                    ImageUrl = dailyImg.Url;
                }
            }

             
        }

       

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            loadImage();
        }
    }
}

