﻿using GUI.MVVM.Model;
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
    /// <summary>
    /// Interaction logic for AstronautListUserControl.xaml
    /// </summary>
    public partial class AstronautListUserControl : UserControl  
    {
        private bool isDialogOpen;
        
        public AstronautListUserControl()
        {
            InitializeComponent();
            DataContext = new AstronautsListVM();
        }  
    }
   
}
