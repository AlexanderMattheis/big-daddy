namespace BigDaddy.Core
{
    public class FileMenuDesignModel : FileMenuViewModel
    {
        public FileMenuDesignModel() : base(true)
        {
            Name = "_File";

            #region Names
            NewName = "_New";
            OpenName = "_Open";
            SaveName = "_Save";
            SaveAsName = "Save_As";

            ExitName = "_Exit";
            #endregion
        }
    }
}
