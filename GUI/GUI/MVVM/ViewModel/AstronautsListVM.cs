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

namespace GUI.MVVM.ViewModel
{
    internal class AstronautsListVM : ViewModelBase
    {
        public RelayCommand GetMoreAstronauts{ get; }

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

        private  IAstronautsGenerator  _astronautsGenerator;

        public AstronautsListVM()
        {
            GetMoreAstronauts = new RelayCommand(addAstronaouts, canAddAstronauts);
            _astronautsGenerator = new AstronautsGenerator(20);
            Astronauts = new ObservableCollection<AstronautResponse>();
        }

        private bool canAddAstronauts()
        {
            return true;
        }

        private async void addAstronaouts()
        {
            var newAstronauts = await _astronautsGenerator.GetMoreAstronauts();

            if (newAstronauts != null)
            {
                foreach (var astronaut in newAstronauts)
                    Astronauts.Add(astronaut);
            }
        }




    }
}
