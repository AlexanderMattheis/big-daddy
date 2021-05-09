using System.Collections.ObjectModel;

namespace BigDaddy.Core
{
    public class DataGridViewModel : ViewModel
    {
        public CsvImportData ImportData { get; set; }

        public DataGridViewModel(bool isDesignTime = false)
        {
            if (isDesignTime)
            {
                return;
            }

            ImportData = new CsvImportData
            {
                Lines = new ObservableCollection<string>(),
                StartRowNumber = 0,
                EndRowNumber = 0,
                Separators = new string[] { string.Empty }
            };
        }
    }
}
