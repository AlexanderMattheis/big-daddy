using System.Windows.Input;

namespace BigDaddy.Core
{
    public class BaseTabViewModel : ViewModel
    {
        public string Name { get; set; }

        #region Keys
        public string NewKey { get; set; }
        public string OpenKey { get; set; }
        public string SaveKey { get; set; }
        public string SaveAsKey { get; set; }

        public string ExitKey { get; set; }
        #endregion

        public BaseTabViewModel(bool isDesignTime = false)
        {
            if (isDesignTime)
            {
                return;
            }

            Name = Strings.BaseTab;

            #region Keys
            NewKey = "New";
            OpenKey = "Open";
            SaveKey = "Save";
            SaveAsKey = "SaveAs";

            ExitKey = "Exit";
            #endregion
        }
    }
}
