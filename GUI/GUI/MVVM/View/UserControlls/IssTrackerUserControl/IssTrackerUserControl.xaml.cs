using GUI.MVVM.ViewModel;
using GUI.services;
using GUI.services.implementation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
using System.Xml.Linq;
using System.Xml.Serialization;

namespace GUI.MVVM.View.UserControlls
{

    /// <summary>
    /// Interaction logic for IssTrackerUserControl.xaml
    /// </summary>
    public partial class IssTrackerUserControl : UserControl
    {
       // private string path = @"..\NASA_2023\GUI\resources\Text.xml";

        public IssTrackerUserControl()
        {
            InitializeComponent();

            //XmlSerializer serializer = new XmlSerializer(typeof(string));
            //FileStream file = new FileStream(path,FileMode.Open, FileAccess.Read,FileShare.None);
            //Text = (string)serializer. Deserialize(file);
            //file.Close();
            DataContext = new ISSlocationVM();
        }

        private void PlayMedia(object sender, RoutedEventArgs e)
        {
            var mediaElement = (MediaElement)sender;
            mediaElement.Position = TimeSpan.FromSeconds(2);
            mediaElement.Play();
        }
    }
}
