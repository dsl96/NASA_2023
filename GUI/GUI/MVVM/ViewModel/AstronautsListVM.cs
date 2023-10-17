using GUI.command;
using GUI.MVVM.Model;
using GUI.services;
using GUI.services.implementation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GUI.MVVM.ViewModel
{
    internal class AstronautsListVM : ViewModelBase
    {
        public ICommand GetMoreAstronautsCommand { get; set; }
        public ICommand ShowAstronautDetailsCommand { get; set; }
        public ICommand OpenLinkCommand { get; private set; }


        private IAstronautsGenerator _astronautsGenerator;

        private ObservableCollection<AstronautResponse> astronauts;
        public ObservableCollection<AstronautResponse> Astronauts
        {
            get { return astronauts; }
            set
            {
                if (value != astronauts)
                {
                    astronauts = value;
                    OnPropertyChanged(nameof(Astronauts));
                }
            }
        }
        private bool _showDetails;
        public bool IsShowDetails
        {
            get { return _showDetails; }
            set
            {
                _showDetails = value;
                OnPropertyChanged(nameof(IsShowDetails));
            }
        }

        private AstronautResponse _selectedAstronaut;
        public AstronautResponse SelectedAstronaut
        {
            get { return _selectedAstronaut; }
            set
            {
                _selectedAstronaut = value;
                OnPropertyChanged(nameof(SelectedAstronaut));
            }
        }

        public AstronautsListVM()
        {
            ShowAstronautDetailsCommand = new RelayCommand(showAstronautDetails);
            GetMoreAstronautsCommand = new RelayCommand(addAstronaouts);
            OpenLinkCommand = new RelayCommand(OpenLink);

            _astronautsGenerator = new AstronautsGenerator(20);
            Astronauts = new ObservableCollection<AstronautResponse>();
        }

        private async void addAstronaouts(object parameter)
        {
            var newAstronauts = await _astronautsGenerator.GetMoreAstronauts();

            if (newAstronauts != null)
            {
                foreach (var astronaut in newAstronauts)
                    Astronauts.Add(astronaut);
            }
        }

        private   void showAstronautDetails(object parameter)
        {
            SelectedAstronaut = (AstronautResponse)parameter;
            IsShowDetails = true;
        }
    

        private void OpenLink(object parameter)
        {

            try
            {
                var uri = (string)parameter;
                System.Diagnostics.Process.Start(uri);
            }
            catch (Exception)
            {

                 
            }
         
        }
    }
}
