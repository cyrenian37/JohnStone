using System;
using System.Windows.Data;

namespace SunSeven.Models
{
    public class ProductDetailConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return ((DateTime)value).ToString("dd-MMM-yy HH:mm:ss");
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
