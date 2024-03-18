using System;
using System.Globalization;
using System.Windows.Data;

namespace practice.Classes
{
    public class FullNameConverter: IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length < 3)
                return string.Empty;

            string surname = values[0]?.ToString();
            string name = values[1]?.ToString();
            string patronymic = values[2]?.ToString();

            return $"{surname} {name} {patronymic}";
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
