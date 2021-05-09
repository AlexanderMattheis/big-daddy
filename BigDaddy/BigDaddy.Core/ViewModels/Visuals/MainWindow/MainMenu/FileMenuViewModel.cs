using System.Windows.Input;

namespace BigDaddy.Core
{
    public class FileMenuViewModel : ViewModel
    {
        public string Name { get; set; }

        #region Names
        public string NewName { get; set; }
        public string OpenName { get; set; }
        public string SaveName { get; set; }
        public string SaveAsName { get; set; }

        public string ExitName { get; set; }
        #endregion

        #region Commands
        public ICommand NewCommand { get; set; }
        public ICommand OpenCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand SaveAsCommand { get; set; }

        public ICommand ExitCommand { get; set; }
        #endregion

        public FileMenuViewModel(bool isDesignTime = false)
        {
            if (isDesignTime)
            {
                return;
            }

            Name = Strings.FileMenu;

            #region Names
            NewName = Strings.FileMenu_New;
            OpenName = Strings.FileMenu_Open;
            SaveName = Strings.FileMenu_Save;
            SaveAsName = Strings.FileMenu_SaveAs;

            ExitName = Strings.FileMenu_Exit;
            #endregion

            #region Commands
            NewCommand = new DefaultCommand(New);
            OpenCommand = new DefaultCommand(Open);
            SaveCommand = new DefaultCommand(Save);
            SaveAsCommand = new DefaultCommand(SaveAs);

            ExitCommand = new DefaultCommand(Exit);
            #endregion
        }

        #region Commands
        public void New() { }
        public void Open() { }
        public void Save() { }
        public void SaveAs() { }

        public void Exit() { }
        #endregion
    }
}
