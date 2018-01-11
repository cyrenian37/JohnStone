using System;
using System.Globalization;
using System.Windows.Data;

namespace SunSeven.Models
{
    public class TelerikDateFormatWorkaround
    {
        public CultureInfo CultureFormat
        {
            get
            {
               // var tempCultureInfo = (CultureInfo)CultureInfo.CurrentCulture.Clone();

                var tempCultureInfo = new CultureInfo("en-IE");
                tempCultureInfo.DateTimeFormat.FullDateTimePattern = "dd-MMM-yyyy HH:mm:ss";
                tempCultureInfo.DateTimeFormat.LongDatePattern  = "dd-MMM-yyyy HH:mm:ss";
                tempCultureInfo.DateTimeFormat.ShortDatePattern = "dd-MMM-yyyy";
                return tempCultureInfo;
            }
        }
    }


    
    public class HeaderConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            SunSeven.DataSource.Person lperson = value as SunSeven.DataSource.Person;

            if (lperson == null) return null;

            return lperson.FirstName + "  " + lperson.LastName;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }

    public class FullNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            SunSeven.DataSource.Person lperson = value as SunSeven.DataSource.Person;

            if (lperson == null) return null;

            return lperson.FirstName + "  " + lperson.LastName;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }

    public class CustomerConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            SunSeven.DataSource.Customer lperson = value as SunSeven.DataSource.Customer;

            if (lperson == null) return null;

            return lperson.Name  + "  (" + lperson.CompanyName  + ")";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
