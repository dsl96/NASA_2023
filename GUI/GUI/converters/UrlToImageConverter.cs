using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace GUI.converters
{
    public class UrlToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

          //  value = "C:\\Users\\dov31\\Desktop\\images.png";
            if (value is string url)
            {
                try
                {
                    BitmapImage image = new BitmapImage();
                    image.BeginInit();

                    if ( checkValidInternetUri(url)  ||  File.Exists(url))
                    {
                        image.UriSource = new Uri(url);
                        image.CacheOption = BitmapCacheOption.OnLoad;
                        image.EndInit();
                        return image;
                    }
                    else
                    {
                        Console.WriteLine("Invalid URL or local file path");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error loading image: " + ex.Message);
                }
            }

            return null;
        }

        private bool checkValidInternetUri(string url)
        {
            return Uri.TryCreate(url, UriKind.Absolute, out Uri uriResult) &&
                (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

        }
 

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
