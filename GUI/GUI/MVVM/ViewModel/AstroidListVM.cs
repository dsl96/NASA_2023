using GUI.command;
using GUI.MVVM.Model;
using GUI.services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace GUI.MVVM.ViewModel
{
    public class AstroidListVM : ViewModelBase
    {
        public DateTime MaxDate { set; get; }


        private DateTime _startDate;
        public DateTime StartDate
        {
            get { return _startDate; }
            set
            {
                if (_startDate != value)
                {
                    _startDate = value;

                    OnPropertyChanged(nameof(StartDate));
                }
            }
        }


        private DateTime _endDate;
        public DateTime EndDate
        {
            get { return _endDate; }
            set
            {
                if (_endDate != value)
                {
                    _endDate = value;
                    OnPropertyChanged(nameof(EndDate));
                }
            }
        }


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

        public ObservableCollection<dynamic> DataAstroidList { get; set; }
        public RefreshAstroidListCommand refreshCommand { set; get; }

        private readonly NasaClient _nasaService;

        public AstroidListVM()
        {
            this._startDate = DateTime.Now.AddDays(-6);
            this._endDate = DateTime.Now;
            this.MaxDate = DateTime.Now;
            this._nasaService = new NasaClient();
            Task.Run(() => DateChange()).Wait();
            this.DataAstroidList = new ObservableCollection<dynamic>();
            refreshCommand = new RefreshAstroidListCommand(this);
        }


        internal async void DateChange()
        {
            response = await _nasaService.GetAstroidList(_startDate, _endDate);
            if (_response != null)
                UpdateListByDispatcher();
        }

        private void UpdateListByDispatcher()
        {
            Application.Current.Dispatcher.Invoke(() => { DataAstroidList.Clear(); });

            _response.NearEarthObjects.SelectMany(x => x.Value.Select(y => new
            {
                Key = x.Key,
                Value = y
            })).ToList().ForEach(x =>
            {
                Application.Current.Dispatcher.Invoke(() => { DataAstroidList.Add(x); });
            });
        }

    }
}


