using BigDaddy.Core;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace BigDaddy
{
    internal class DataTableClipboardController
    {
        private IList<DataRowView> copiedItems;

        internal DataTableClipboardController()
        {
            copiedItems = new List<DataRowView>();
        }

        internal void CopyRows(IList items)
        {
            copiedItems = new List<DataRowView>();

            foreach (DataRowView rowView in items)
            {
                copiedItems.Add(rowView.GetCopyOfRowView());
            }
        }

        internal void PasteRows(int index, DataGridViewModel viewModel)
        {
            var importData = viewModel.ImportData;
            var separator = importData.Separators[0];

            for (int i = 0; i < copiedItems.Count; i++)
            {
                var newLine = string.Join(separator, copiedItems[i].Row.ItemArray);
                importData.Lines.Insert(index + i + 1, newLine); // '+ 1' since there is the header row
            }

            // to trigger update of ItemSource
            viewModel.ImportData = new CsvImportData()
            {
                Lines = importData.Lines,
                Separators = importData.Separators,
                StartRowNumber = importData.StartRowNumber,
                EndRowNumber = importData.EndRowNumber
            };
        }

        internal void CutRows(IList selectedItems)
        {
        }
    }
}
