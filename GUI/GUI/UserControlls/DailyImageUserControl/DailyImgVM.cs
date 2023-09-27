using GUI.command;
using GUI.DAL;
using GUI.DAL.DataClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GUI.UserControlls
{
    internal class DailyImgVM : INotifyPropertyChanged
    {
        private DateTime selectedDate;

        public DateTime SelectedDate
        {
            get { return selectedDate; }
            set
            {
                if (selectedDate != value)
                {
                    selectedDate = value;
                    ExecuteDateChangedCommand(value);
                    OnPropertyChanged("SelectedDate");

                }
            }
        }

        private dailyImageResponse imageData;

        public dailyImageResponse ImageData
        {
            get { return imageData; }
            set
            {
                if (imageData != value)
                {
                    imageData = value;
                    OnPropertyChanged("ImageData");
                }
            }
        }

        //the min date to choose image
        private DateTime _minDate;
        public DateTime MinDate
        {
            get { return _minDate; }
            set
            {
                _minDate = value;
                OnPropertyChanged(nameof(MinDate));
            }
        }

        //the max date to choose image
        private DateTime _maxDate;
        public DateTime MaxDate
        {
            get { return _maxDate; }
            set
            {
                _maxDate = value;
                OnPropertyChanged(nameof(MaxDate));
            }
        }

        private readonly NasaClient dailyImageService;

        public DailyImgVM()
        {
           this. dailyImageService = new NasaClient();

            this.MaxDate = dailyImageService.MaxDate;
            this.MinDate = dailyImageService.MinDate;
            this.SelectedDate = _maxDate;
        }

        private async void ExecuteDateChangedCommand(object parameter)
        {
            if (parameter == null)
            {
                return;
            }

            DateTime newDate = (DateTime)parameter;

            await UpdateImageData(newDate);
        }

        private async Task UpdateImageData(DateTime date)
        {
            var response = await dailyImageService.GetDailyImage(date);

            //TODO check video

            if (response != null)
            {
                //set the default url to hd if exist
              //  response.Url = (response.HdUrl != null) ? response.HdUrl : response.Url;
                ImageData = response;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}

