using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Xml;

namespace GUI.converters
{
    /// <summary>
    /// Converts a duration string in the format of "P[D]DT[H]H[M]M[S]S" to a human-readable format.
    /// </summary>
    public class DurationConverter : IValueConverter
    {
     
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string durationString)
            {
                try
                {
                    TimeSpan duration = XmlConvert.ToTimeSpan(durationString);
                    return $"{(int)duration.TotalDays} days, {duration.Hours} hours, {duration.Minutes} minutes, {duration.Seconds} seconds";
                }
                catch (FormatException)
                {
                    return "Invalid duration format";
                }
            }

            return "Invalid duration format";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }

}
