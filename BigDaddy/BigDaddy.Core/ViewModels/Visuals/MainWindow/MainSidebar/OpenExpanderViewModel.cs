namespace BigDaddy.Core
{
    public class OpenExpanderViewModel : ViewModel
    {
        protected string importName;

        protected string cancelName;

        public string Name { get; set; }

        #region Names
        public string LowerBoundName { get; set; }

        public string UpperBoundName { get; set; }

        public string SeparatorName { get; set; }

        public string DetermineTotalNumberOfLinesName { get; set; }

        public string ImportName {
            get
            {
                return IsImporting ? cancelName : importName;
            }
        }

        public string ReimportName { get; set; }
        #endregion

        #region Tooltip
        public string ValidationErrorTooltip { get; set; }
        #endregion

        #region Values
        public int LowerBoundValue { get; set; }

        public int UpperBoundValue { get; set; }

        public string SeparatorValue { get; set; }

        public string LastLoadedFileName { get; set; }

        public bool DetermineTotalNumberOfLinesValue { get; set; }

        public bool IsImporting { get; set; }
        #endregion

        public OpenExpanderViewModel(bool isDesignTime = false)
        {
            if (isDesignTime)
            {
                return;
            }

            Name = Strings.OpenExpander;

            #region Names
            importName = Strings.OpenExpander_Import;
            cancelName = Strings.OpenExpander_Cancel;

            LowerBoundName = Strings.OpenExpander_LowerBound;
            UpperBoundName = Strings.OpenExpander_UpperBound;
            SeparatorName = Strings.OpenExpander_Separator;
            DetermineTotalNumberOfLinesName = Strings.OpenExpander_DetermineTotalNumberOfLines;
            ReimportName = Strings.OpenExpander_Reimport;
            #endregion

            #region Tooltip
            ValidationErrorTooltip = Strings.ValidationError;
            #endregion

            #region Values
            LowerBoundValue = Config.Get<int>("BaseExpander.LowerBound");
            UpperBoundValue = Config.Get<int>("BaseExpander.UpperBound");
            SeparatorValue = Config.Get<string>("BaseExpander.Separator");
            DetermineTotalNumberOfLinesValue = Config.Get<bool>("BaseExpander.DetermineTotalNumberOfLines");

            IsImporting = false;
            #endregion
        }
    }
}
