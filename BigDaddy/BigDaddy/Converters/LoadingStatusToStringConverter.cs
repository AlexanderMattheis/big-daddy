using BigDaddy.Core;
using System;
using System.Globalization;
using static BigDaddy.Core.MainStatusBarViewModel;

namespace BigDaddy
{
    internal class LoadingStatusToStringConverter : ValueConverter<LoadingStatusToStringConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (value)
            {
                case LoadingStatus.Ready:
                    return Strings.MainStatusBar_LoadingStatus__Ready;
                case LoadingStatus.Loading:
                    return Strings.MainStatusBar_LoadingStatus__Loading;
                case LoadingStatus.Finished:
                    return Strings.MainStatusBar_LoadingStatus__Finished;
            }

            throw new ArgumentException($"There is no corresponding string value for the provided Enum.");
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
#pragma warning disable RCS1079 // Throwing of new NotImplementedException.
            throw new NotImplementedException();
#pragma warning restore RCS1079 // Throwing of new NotImplementedException.
        }
    }
}
