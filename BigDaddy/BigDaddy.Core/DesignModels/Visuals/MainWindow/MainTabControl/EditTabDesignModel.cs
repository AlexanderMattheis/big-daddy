using System.Windows.Input;

namespace BigDaddy.Core
{
    public class EditTabDesignModel : EditTabViewModel
    {
        public EditTabDesignModel() : base(true)
        {
            Name = "Edit";

            #region Keys
            AddColumnsKey = "Add Columns";
            DuplicateColumnsKey = "Duplicate Columns";
            RemoveColumnsKey = "Remove Columns";

            CopyColumnsKey = "Copy Columns";
            CutColumnsKey = "Cut Columns";
            PasteColumnsKey = "Paste Columns";
            #endregion
        }
    }
}
