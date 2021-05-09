using System.Collections.ObjectModel;

namespace BigDaddy.Core
{
    public class CsvImportData
    {
        public ObservableCollection<string> Lines { get; set; }

        public int StartRowNumber { get; set; }

        public int EndRowNumber { get; set; }

        public string[] Separators { get; set; }
    }
}
