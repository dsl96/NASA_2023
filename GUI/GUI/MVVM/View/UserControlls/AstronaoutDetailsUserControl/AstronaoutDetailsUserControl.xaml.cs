using GUI.MVVM.Model;
using GUI.MVVM.ViewModel;
using GUI.services;
using GUI.services.implementation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

    public partial class AstronaoutDetailsUserControl : UserControl
    {

        public static readonly DependencyProperty AstronautProperty =
        DependencyProperty.Register(
         "Astronaut",
         typeof(AstronautResponse),
         typeof(AstronaoutDetailsUserControl),
         new PropertyMetadata(null, new PropertyChangedCallback(OnAstronautPropertyChanged)));

        public AstronautResponse Astronaut
        {
            get { return (AstronautResponse)GetValue(AstronautProperty); }
            set { SetValue(AstronautProperty, value); }
        }

        private static void OnAstronautPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var userControl = d as AstronaoutDetailsUserControl;
            userControl.OnAstronautChanged(e.NewValue as AstronautResponse);
        }

        private void OnAstronautChanged(AstronautResponse newAstronaut)
        {
            this.Astronaut = newAstronaut;
        }


        public AstronaoutDetailsUserControl()
        {
            InitializeComponent();
            DataContext = this;
        }


    }
}
