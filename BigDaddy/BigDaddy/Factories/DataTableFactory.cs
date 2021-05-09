using BigDaddy.Core;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace BigDaddy
{
    internal static class DataTableFactory
    {
        private const string DuplicateColumnNameAvoidanceSymbol = " ";

        internal static DataTable Create(CsvImportData importData)
        {
            ObservableCollection<string> lines = importData.Lines;
            string[] separators = importData.Separators;

            var dataTable = new DataTable();

            if (lines.Count == 0)
            {
                return dataTable;
            }

            CreateHeader(dataTable, lines[0], separators);

            for (int i = 1; i < lines.Count; i++)
            {
                CreateRow(dataTable, lines[i], separators);
            }

            return dataTable;
        }

        private static void CreateHeader(DataTable table, string line, string[] separators)
        {
            foreach (var columnName in line.Split(separators, StringSplitOptions.None))
            {
                CreateColumn(table, columnName);
            }
        }

        private static void CreateColumn(DataTable table, string columnName)
        {
            try
            {
                DataColumn tableColumn = new DataColumn(columnName);
                table.Columns.Add(tableColumn);
            }
            catch (DuplicateNameException)
            {
                CreateColumn(table, columnName + DuplicateColumnNameAvoidanceSymbol);
            }
        }

        private static void CreateRow(DataTable table, string line, string[] separators)
        {
            var columnData = line.Split(separators, StringSplitOptions.None);

            var row = table.NewRow();

            for (int i = 0; i < columnData.Length; i++)
            {
                if (i < table.Columns.Count)
                {
                    row[table.Columns[i].ColumnName] = columnData[i];
                }
            }

            table.Rows.Add(row);
        }
    }
}
