using System.Windows.Input;

namespace BigDaddy.Core
{
    public class EditMenuViewModel : ViewModel
    {
        public string Name { get; set; }

        #region Names
        public string AddColumnsName { get; set; }
        public string DuplicateColumnsName { get; set; }
        public string RemoveColumnsName { get; set; }

        public string CopyColumnsName { get; set; }
        public string CutColumnsName { get; set; }
        public string PasteColumnsName { get; set; }

        #endregion

        #region Commands
        public ICommand AddColumnsCommand { get; set; }
        public ICommand DuplicateColumnsCommand { get; set; }
        public ICommand RemoveColumnsCommand { get; set; }

        public ICommand CopyColumnsCommand { get; set; }
        public ICommand CutColumnsCommand { get; set; }
        public ICommand PasteColumnsCommand { get; set; }

        #endregion

        public EditMenuViewModel(bool isDesignTime = false)
        {
            if (isDesignTime)
            {
                return;
            }

            Name = Strings.EditMenu;

            #region Names
            AddColumnsName = Strings.EditMenu_AddColumns;
            DuplicateColumnsName = Strings.EditMenu_DuplicateColumns;
            RemoveColumnsName = Strings.EditMenu_RemoveColumns;

            CopyColumnsName = Strings.EditMenu_CopyColumns;
            CutColumnsName = Strings.EditMenu_CutColumns;
            PasteColumnsName = Strings.EditMenu_PasteColumns;
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
