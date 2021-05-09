using System;
using System.Globalization;

namespace BigDaddy
{
    internal class NumberToExtendedFormattedNumberConverter : ValueConverter<NumberToExtendedFormattedNumberConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is int numberValue))
            {
                throw new ArgumentException($"You did not pass {nameof(Int32)}.");
            }

            return numberValue == -1 ? "-" : numberValue.ToString("N0"); // TODO: Make 'CultureInfo' selectable
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
#pragma warning disable RCS1079 // Throwing of new NotImplementedException.
            throw new NotImplementedException();
#pragma warning restore RCS1079 // Throwing of new NotImplementedException.
        }
    }
}
