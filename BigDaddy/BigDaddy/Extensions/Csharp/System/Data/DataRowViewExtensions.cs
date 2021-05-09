using System.Data;

namespace BigDaddy
{
    internal static class DataRowViewExtensions
    {
        internal static DataRowView GetCopyOfRowView(this DataRowView rowView)
        {
            // HACK: Enhance if copying is too slow https://stackoverflow.com/questions/31720480/is-there-a-better-way-to-get-a-copy-of-datarowview/31720663
            DataTable table = rowView.DataView.ToTable();
            DataRow rowCopy = table.NewRow();
            rowCopy.ItemArray = rowView.Row.ItemArray;
            table.Rows.InsertAt(rowCopy, table.Rows.Count);
            return table.DefaultView[table.Rows.Count - 1];
        }
    }
}
