namespace BigDaddy.Core
{
    public class MainDataGridDesignModel : MainDataGridViewModel
    {
        public MainDataGridDesignModel() : base(true)
        {
            LoadMoreName = "Load More Rows...";

            ColumnMenuData = new ColumnContextMenuData
            {
                AddColumnsName = "Add Column(s)",
                DuplicateColumnsName = "Duplicate Column(s)",
                RemoveColumnsName = "Remove Column(s)",

                CopyColumnsName = "Copy Column(s)",
                CutColumnsName = "Cut Column(s)",
                PasteColumnsName = "Paste Column(s)"
            };

            RowMenuData = new RowContextMenuData
            {
                AddRowsName = "Add Row(s)",
                DuplicateRowsName = "Duplicate Row(s)",
                RemoveRowsName = "Remove Row(s)",

                CopyRowsName = "Copy Row(s)",
                CutRowsName = "Cut Row(s)",
                PasteAfterRowsName = "Paste After Row(s)",
                PasteBeforeRowsName = "Paste Before Row(s)",
            };

            CellMenuData = new CellContextMenuData
            {
                CopyName = "Copy",
                CutName = "Cut",
                PasteName = "Paste"
            };
        }
    }
}
