using GUI.MVVM.Model;
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

namespace GUI.MVVM.View.UserControlls 
{
    /// <summary>
    /// Interaction logic for AstronautListUserControl.xaml
    /// </summary>
    public partial class AstronautListUserControl : UserControl
    {
        public event PropertyChangedEventHandler PropertyChanged;


        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private List<AstronautResponse> astronauts;
        public List<AstronautResponse> Astronauts
        {
            get { return astronauts; }
            set
            {
                if (value != astronauts)
                {
                    astronauts = value;
                    OnPropertyChanged("Astronauts");
                }
            }
        }

        private bool isDialogOpen;



        public bool IsDialogOpen
        {
            get { return isDialogOpen; }
            set
            {

                isDialogOpen = value;
                OnPropertyChanged(nameof(IsDialogOpen));

            }
        }


        public string BackgroundImageURL { get; set; } = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRy1QOcQDEi4hOtv4LLo2fUijbLVSOxIW-i8g&usqp=CAU";
        public AstronautListUserControl()
        {
            InitializeComponent();

            Astronauts = new List<AstronautResponse>();

            for (int i = 0; i < 100; i++)
            {
                AstronautResponse astronaut = new AstronautResponse
                {
                    Name = "Astronaut " + (i + 1),
                    ImageURL = "https://spacelaunchnow-prod-east.nyc3.digitaloceanspaces.com/media/astronaut_images/thomas2520pesquet_image_20200102120546.jpeg"
                };

                Astronauts.Add(astronaut);

            }

            DataContext = this;


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            IsDialogOpen = true;
        }
    }
   
}
