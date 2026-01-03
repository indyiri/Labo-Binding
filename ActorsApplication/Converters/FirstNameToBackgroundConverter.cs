using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace ActorsApplication.Converters
{
    public class FirstNameToBackgroundConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value == null) return Colors.Transparent;

            string firstName = value.ToString() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(firstName))
                return Colors.Transparent;

            char first = char.ToUpperInvariant(firstName[0]);

            // A-I -> gray, J-Z -> light blue
            if (first >= 'A' && first <= 'I')
                return Colors.LightGray;

            return Colors.LightBlue;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
