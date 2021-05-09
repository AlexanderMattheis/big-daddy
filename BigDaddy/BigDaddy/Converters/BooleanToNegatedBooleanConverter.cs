using System;
using System.Globalization;

namespace BigDaddy
{
    internal class BooleanToNegatedBooleanConverter : ValueConverter<BooleanToNegatedBooleanConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is bool booleanValue))
            {
                throw new ArgumentException($"You did not pass {nameof(Boolean)}.");
            }

            return !booleanValue;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
#pragma warning disable RCS1079 // Throwing of new NotImplementedException.
            throw new NotImplementedException();
#pragma warning restore RCS1079 // Throwing of new NotImplementedException.
        }
    }
}
