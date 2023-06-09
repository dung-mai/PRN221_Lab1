using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace SalesWFPApp
{
    public class MultipleValueToVisibilityConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {

            bool result = true;
            foreach (object value in values)
            {
                if (value is bool)
                {
                    result &= !(bool)value;
                }
                else if(value is string)
                {
                    result &= String.IsNullOrEmpty((string)value);
                }
            }
            return result ? Visibility.Visible : Visibility.Collapsed;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
