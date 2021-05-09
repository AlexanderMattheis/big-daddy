namespace BigDaddy.Core
{
    public class BaseTabDesignModel : BaseTabViewModel
    {
        public BaseTabDesignModel() : base(true)
        {
            Name = "Base";

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
