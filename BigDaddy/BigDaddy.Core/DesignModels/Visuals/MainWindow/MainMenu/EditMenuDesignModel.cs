
namespace BigDaddy.Core
{
    public class EditMenuDesignModel : EditMenuViewModel
    {
        public EditMenuDesignModel() : base(true)
        {
            Name = "_Edit";

            #region Names
            AddColumnsName = "Add Columns";
            DuplicateColumnsName = "Duplicate Columns";
            RemoveColumnsName = "Remove Columns";

            CopyColumnsName = "Copy Columns";
            CutColumnsName = "Cut Columns";
            PasteColumnsName = "Paste Columns";
            #endregion
        }
    }
}
