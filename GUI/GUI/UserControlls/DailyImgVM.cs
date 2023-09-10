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

        private string imageDescription;

        public string ImageDescription
        {
            get { return imageDescription; }
            set
            {
                if (imageDescription != value)
                {
                    imageDescription = value;
                    OnPropertyChanged("ImageDescription");
                }
            }
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

        private DateTime _minDate = new DateTime(2023, 1, 1);
        public DateTime MinDate
        {
            get { return _minDate; }
            set
            {
                _minDate = value;
                OnPropertyChanged(nameof(MinDate));
            }
        }

        private DateTime _maxDate = new DateTime(2023, 12, 31);
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
            dailyImageService = new NasaClient();

            _maxDate = dailyImageService.MaxDate;
            _minDate = dailyImageService.MinDate;
            SelectedDate = _maxDate;
        }

        private async void ExecuteDateChangedCommand(object parameter)
        {
           if (parameter == null)
            {
                return;
            }

            DateTime newDate = (DateTime)parameter;

            dailyImageResponse newImage = await getImageUrl(newDate);

            if(newImage != null)
            {
                ImageUrl = newImage.HdUrl != null ? newImage.HdUrl : newImage.Url;
                ImageDescription = newImage.Explanation;
            }
                
        }


        private async Task<dailyImageResponse> getImageUrl(DateTime date)
        {
           var  response  = await dailyImageService.GetDailyImage(date);
           return response;
 
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
 
