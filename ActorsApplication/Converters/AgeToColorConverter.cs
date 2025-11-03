using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActorsApplication.Converters
{
    public class AgeToColorConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value == null) return null;

            int birthYear = (int)value;

            int currentYear = DateTime.Now.Year;

            int age = currentYear - birthYear;

            if (age < 50)
            {
                return Colors.Blue;
            }
            else
            {
                return Colors.Green;
            }
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
