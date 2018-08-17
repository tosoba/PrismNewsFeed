using System;
using System.Globalization;
using Xamarin.Forms;

namespace PrismNewsFeed.Converters
{
    public class EmptyOrNullStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => 
            string.IsNullOrEmpty(value as string) ? parameter : value;

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
            throw new NotImplementedException();
    }
}
