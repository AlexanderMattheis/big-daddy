using System;
using System.Globalization;

namespace BigDaddy
{
    internal class SubtractionConverter : ValueConverter<SubtractionConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is double windowWidth))
            {
                throw new ArgumentException($"You did not pass {nameof(Double)}.");
            }

            double.TryParse(parameter.ToString(), out double subtrahend);

            return windowWidth - subtrahend;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
#pragma warning disable RCS1079 // Throwing of new NotImplementedException.
            throw new NotImplementedException();
#pragma warning restore RCS1079 // Throwing of new NotImplementedException.
        }
    }
}
