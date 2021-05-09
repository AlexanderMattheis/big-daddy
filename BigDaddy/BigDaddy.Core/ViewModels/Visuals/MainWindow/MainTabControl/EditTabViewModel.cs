using System.Windows.Input;

namespace BigDaddy.Core
{
    public class EditTabViewModel : ViewModel
    {
        public string Name { get; set; }

        #region Keys
        public string AddColumnsKey { get; set; }
        public string DuplicateColumnsKey { get; set; }
        public string RemoveColumnsKey { get; set; }

        public string CopyColumnsKey { get; set; }
        public string CutColumnsKey { get; set; }
        public string PasteColumnsKey { get; set; }

        #endregion

        #region Commands
        public ICommand AddColumnsCommand { get; set; }
        public ICommand DuplicateColumnsCommand { get; set; }
        public ICommand RemoveColumnsCommand { get; set; }

        public ICommand CopyColumnsCommand { get; set; }
        public ICommand CutColumnsCommand { get; set; }
        public ICommand PasteColumnsCommand { get; set; }

        #endregion

        public EditTabViewModel(bool isDesignTime = false)
        {
            if (isDesignTime)
            {
                return;
            }

            Name = Strings.EditTab;

            #region Keys
            AddColumnsKey = "AddColumns";
            DuplicateColumnsKey = "DuplicateColumns";
            RemoveColumnsKey = "RemoveColumns";

            CopyColumnsKey = "CopyColumns";
            CutColumnsKey = "CutColumns";
            PasteColumnsKey = "PasteColumns";
            #endregion

            #region Commands
            AddColumnsCommand = new DefaultCommand(AddColumns);
            DuplicateColumnsCommand = new DefaultCommand(DuplicateColumns);
            RemoveColumnsCommand = new DefaultCommand(RemoveColumns);

            CopyColumnsCommand = new DefaultCommand(CopyColumns);
            CutColumnsCommand = new DefaultCommand(CutColumns);
            PasteColumnsCommand = new DefaultCommand(PasteColumns);
            #endregion
        }

        #region Commands
        public void AddColumns() { }
        public void DuplicateColumns() { }
        public void RemoveColumns() { }

        public void CopyColumns() { }
        public void CutColumns() { }
        public void PasteColumns() { }
        #endregion
    }
}
