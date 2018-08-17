using System;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PrismNewsFeed.Converters
{
    public class InverseBoolConverter : IValueConverter, IMarkupExtension
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => !((bool)value);
        
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => value;

        public object ProvideValue(IServiceProvider serviceProvider) => this;
    }
}
