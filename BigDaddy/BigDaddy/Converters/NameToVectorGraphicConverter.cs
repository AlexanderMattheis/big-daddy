using System;
using System.Globalization;
using System.Windows;

namespace BigDaddy
{
    internal class NameToVectorGraphicConverter : ValueConverter<NameToVectorGraphicConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is string iconName))
            {
                throw new ArgumentException($"You did not pass {nameof(String)}.");
            }

            return Application.Current.TryFindResource($"{iconName}Icon");
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
#pragma warning disable RCS1079 // Throwing of new NotImplementedException.
            throw new NotImplementedException();
#pragma warning restore RCS1079 // Throwing of new NotImplementedException.
        }
    }
}
