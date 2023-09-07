using DATA_CLASSES;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using API.Controllers;

namespace GUI.ViewModel
{
    class DailyPictureVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;



        internal NasaDailyImageResponse? imageResponse;

        internal MediaElement? dailyPicture;

        DailyPictureVM()
        {
            imageResponse = ;

            dailyPicture = new MediaElement();
            dailyPicture.Source = new Uri();

        }

    }
}
