using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace GUI.converters
{
    public class UrlToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string url)
            {
                try
                {
                    if (IsValidUrl(url) || File.Exists(url))
                    {
                        return LoadImageFromUrl(url);
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
            else if (value is byte[] bytes)
            {
                try
                {
                    return LoadImageFromBytes(bytes);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error loading image from byte array: " + ex.Message);
                }
            }

            return null;
        }

        private bool IsValidUrl(string url)
        {
            return Uri.TryCreate(url, UriKind.Absolute, out Uri uriResult) &&
                   (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }

        private BitmapImage LoadImageFromUrl(string url)
        {
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(url);
            image.CacheOption = BitmapCacheOption.OnLoad;
            image.EndInit();
            return image;
        }

        private BitmapImage LoadImageFromBytes(byte[] bytes)
        {
            BitmapImage image = new BitmapImage();
            using (MemoryStream stream = new MemoryStream(bytes))
            {
                image.BeginInit();
                image.StreamSource = stream;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.EndInit();
            }
            return image;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
