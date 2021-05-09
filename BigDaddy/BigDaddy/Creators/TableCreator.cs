using System;
using System.Collections.Generic;
using System.Data;

namespace BigDaddy
{
    public static class TableCreator
    {
        private const string DuplicateColumnNameAvoidanceSymbol = " ";

        public static DataTable Create(List<string> lines, string[] separators)
        {
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
