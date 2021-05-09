using System.Collections.ObjectModel;

namespace BigDaddy.Core
{
    public class DataGridDesignModel : DataGridViewModel
    {
        public DataGridDesignModel() : base(true)
        {
            ImportData = new CsvImportData
            {
                Lines = new ObservableCollection<string>()
                {
                    "Name;Job;Age;Gender",
                    "Alex;Scientist;28;Male",
                    "Irene;Secretary;55;Female",
                    "Laura;Developer;27;Female",
                    "Max;Developer;32;Male",
                },
                StartRowNumber = 5,
                EndRowNumber = 10,
                Separators = new string[] { ";" }
            };
        }
    }
}
