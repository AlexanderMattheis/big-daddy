using BigDaddy.Core;
using System;
using System.Data;
using System.Globalization;
using System.Windows.Controls;
using static BigDaddy.MainDataGrid;

namespace BigDaddy
{
    /// <summary>
    /// A simpler solution would be using DataGrid.LoadingRow-event with Code-Behind:
    /// https://stackoverflow.com/a/34641695 (DIRECT LINK)
    /// https://stackoverflow.com/questions/4661998/simple-way-to-display-row-numbers-on-wpf-datagrid (look for: "I had a similar problem")
    /// But presumably this solution here is faster when deleting/adding items, since you have not to update whole datagrid and can write your data when saving to file.
    /// </summary>
    internal class DataGridRowToIndexConverter : MultiValueConverter<DataGridRowToIndexConverter>
    {
        private const int NumberOfInputArguments = 2;

        public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length < NumberOfInputArguments)
            {
                throw new ArgumentException($"You need at least {NumberOfInputArguments} arguments.");
            }

            if (!(values[0] is DataGrid dataGrid))
            {
                throw new ArgumentException($"You did not pass {nameof(DataGrid)}.");
            }

            if (!(values[1] is DataRowView) && !dataGrid.Items[dataGrid.Items.Count - 1].Equals(values[1])) // second check is for CollectionView.NewItemPlaceholder
            {
                throw new ArgumentException($"You did not pass {nameof(DataGridRow)}.");
            }

            if (!(dataGrid.DataContext is CombinedDataGridModel dataGridViewModel))
            {
                throw new ArgumentException($"Your {nameof(DataGrid)}.{nameof(DataGrid.DataContext)} is not typeof({nameof(CombinedDataGridModel)}).");
            }

            return (dataGrid.Items.IndexOf(values[1]) + dataGridViewModel.GridModel.ImportData.StartRowNumber).ToString();
        }

        public override object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
#pragma warning disable RCS1079 // Throwing of new NotImplementedException.
            throw new NotImplementedException();
#pragma warning restore RCS1079 // Throwing of new NotImplementedException.
        }
    }
}
