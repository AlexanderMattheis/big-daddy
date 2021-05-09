using BigDaddy.Core;
using System;
using System.Globalization;

namespace BigDaddy
{
    internal class CsvDataToDataTableConverter : ValueConverter<CsvDataToDataTableConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is CsvImportData importData))
            {
                throw new ArgumentException($"You did not pass {nameof(CsvImportData)}.");
            }

            return DataTableFactory.Create(importData);
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            #pragma warning disable RCS1079 // Throwing of new NotImplementedException.
            throw new NotImplementedException();
            #pragma warning restore RCS1079 // Throwing of new NotImplementedException.
        }
    }
}
