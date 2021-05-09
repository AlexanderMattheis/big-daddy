namespace BigDaddy.Core
{
    public class MainDataGridViewModel : ViewModel
    {
        #region Names
        public string LoadMoreName { get; set; } 
        #endregion

        public ColumnContextMenuData ColumnMenuData { get; set; }
        public RowContextMenuData RowMenuData { get; set; }
        public CellContextMenuData CellMenuData { get; set; }

        public MainDataGridViewModel(bool isDesignTime = false)
        {
            if (isDesignTime)
            {
                return;
            }

            LoadMoreName = Strings.MainDataGrid_LoadMore;

            ColumnMenuData = new ColumnContextMenuData();
            CellMenuData = new CellContextMenuData();
            RowMenuData = new RowContextMenuData();
        }

        public class ColumnContextMenuData
        {
            #region Names
            public string AddColumnsName { get; set; }
            public string DuplicateColumnsName { get; set; }
            public string RemoveColumnsName { get; set; }

            public string CopyColumnsName { get; set; }
            public string CutColumnsName { get; set; }
            public string PasteColumnsName { get; set; }
            #endregion

            public ColumnContextMenuData()
            {
                #region Names
                AddColumnsName = Strings.MainDataGrid_ColumnContextMenu_AddColumns;
                DuplicateColumnsName = Strings.MainDataGrid_ColumnContextMenu_DuplicateColumns;
                RemoveColumnsName = Strings.MainDataGrid_ColumnContextMenu_RemoveColumns;

                CopyColumnsName = Strings.MainDataGrid_ColumnContextMenu_CopyColumns;
                CutColumnsName = Strings.MainDataGrid_ColumnContextMenu_CutColumns;
                PasteColumnsName = Strings.MainDataGrid_ColumnContextMenu_PasteColumns;
                #endregion
            }
        }

        public class RowContextMenuData
        {
            #region Names
            public string AddRowsName { get; set; }
            public string DuplicateRowsName { get; set; }
            public string RemoveRowsName { get; set; }

            public string CopyRowsName { get; set; }
            public string CutRowsName { get; set; }
            public string PasteAfterRowsName { get; set; }
            public string PasteBeforeRowsName { get; set; }
            #endregion

            public RowContextMenuData()
            {
                #region Names
                AddRowsName = Strings.MainDataGrid_RowContextMenu_AddRows;
                DuplicateRowsName = Strings.MainDataGrid_RowContextMenu_DuplicateRows;
                RemoveRowsName = Strings.MainDataGrid_RowContextMenu_RemoveRows;

                CopyRowsName = Strings.MainDataGrid_RowContextMenu_CopyRows;
                CutRowsName = Strings.MainDataGrid_RowContextMenu_CutRows;
                PasteBeforeRowsName = Strings.MainDataGrid_RowContextMenu_PasteBeforeRows;
                PasteAfterRowsName = Strings.MainDataGrid_RowContextMenu_PasteAfterRows;
                #endregion
            }
        }

        public class CellContextMenuData
        {
            #region Names
            public string CopyName { get; set; }
            public string CutName { get; set; }
            public string PasteName { get; set; }
            #endregion

            public CellContextMenuData()
            {
                CopyName = Strings.MainDataGrid_CellContextMenu_Copy;
                CutName = Strings.MainDataGrid_CellContextMenu_Cut;
                PasteName = Strings.MainDataGrid_CellContextMenu_Paste;
            }
        }
    }
}
