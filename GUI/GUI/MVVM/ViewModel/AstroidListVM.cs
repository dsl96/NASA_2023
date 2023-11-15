using GUI.command;
using GUI.MVVM.Model;
using GUI.services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GUI.MVVM.ViewModel
{

    public class AstroidListVM : ViewModelBase
    {

        /*********************************   Commnad   *******************************/
        public ICommand ShowCloseApproachDataCommand { get; set; }
        public ICommand OpenLinkCommand { get; set; }

        public ICommand FilterCommand { get; set; }


        /**********************************   Data   ***************************/

        public ObservableCollection<KeyValuePair<string, NearEarthObject>> DataAstroidList { get; set; }

        private AstroidResponse _response;
        public AstroidResponse response
        {
            get { return _response; }
            set
            {
                if (_response != value)
                {
                    _response = value;
                    OnPropertyChanged(nameof(_response));
                }
            }
        }


        private bool _showDetails;
        public bool ShowDetails
        {
            get { return _showDetails; }
            set
            {
                _showDetails = value;
                OnPropertyChanged(nameof(ShowDetails));
            }
        }

        private List<CloseApproachData> _selected;
        public List<CloseApproachData> Selected
        {
            get { return _selected; }
            set
            {
                if (_selected != value)
                {
                    _selected = value;
                    OnPropertyChanged(nameof(_selected));
                }
            }
        }


        private Uri _sourceUrl;
        public Uri SourceUrl
        {
            get { return _sourceUrl; }
            set
            {
                if (value != _sourceUrl)
                {
                    _sourceUrl = value;
                    OnPropertyChanged(nameof(SourceUrl));
                }
            }
        }

        private AsteroidsFilter _asteroidsFilter { get; set; }
        public AsteroidsFilter AsteroidsFilter
        {
            get { return _asteroidsFilter; }
            set
            {
                if (_asteroidsFilter != value)
                {
                    _asteroidsFilter = value;
                    OnPropertyChanged(nameof(AsteroidsFilter));
                }
            }
        }


        /**************************** Service *****************************/

        private readonly NasaClient _nasaService;


        /*************************** Constructor ***********************/
        public AstroidListVM()
        {

            this._nasaService = new NasaClient();
            this._asteroidsFilter = new AsteroidsFilter();
            Task.Run(() => DateChange()).Wait();

            this.DataAstroidList = new ObservableCollection<KeyValuePair<string, NearEarthObject>>();
            FilterCommand = new RelayCommand(DateChange);
            ShowCloseApproachDataCommand = new RelayCommand(ShowCloseApproachData);
            OpenLinkCommand = new RelayCommand(OpenLink);
            ShowDetails = false;
            SourceUrl = new Uri("https://www.youtube.com/watch?v=rBr18UhT2fs");
        }


        /****************************** Methods ************************/

        private bool CanExecute(object parameter)
        {
            return true;
        }

        private void ShowCloseApproachData(object parameter)
        {
            Selected = (List<CloseApproachData>)parameter;
            ShowDetails = true;
        }

        public async void DateChange(object prameter = null)
        {
            response = await _nasaService.GetAstroidList(AsteroidsFilter.StartDate, AsteroidsFilter.EndDate);
            if (_response != null)
                UpdateListByDispatcher();
        }

        private void UpdateListByDispatcher()
        {
            Application.Current.Dispatcher.Invoke(() => { DataAstroidList.Clear(); });

            _response.NearEarthObjects.SelectMany(x => x.Value.Select(y => new KeyValuePair<string, NearEarthObject>(
                x.Key,
                y
            ))).ToList().ForEach(x =>
            {
                Application.Current.Dispatcher.Invoke(() => { DataAstroidList.Add(x); });
            });
        }

        private void OpenLink(object parameter)
        {
            try
            {
                var uri = parameter as string;
                System.Diagnostics.Process.Start(uri);
            }
            catch (Exception ex) { }
        }

    }
}


