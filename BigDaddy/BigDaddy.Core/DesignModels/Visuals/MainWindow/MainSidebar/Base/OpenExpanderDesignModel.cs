namespace BigDaddy.Core
{
    public class OpenExpanderDesignModel : OpenExpanderViewModel
    {
        public OpenExpanderDesignModel() : base(true)
        {
            Name = "Open";

            #region Names
            importName = "Import";
            cancelName = "Cancel";

            LowerBoundName = "Lower Bound";
            UpperBoundName = "Upper Bound";
            SeparatorName = "Separator";
            DetermineTotalNumberOfLinesName = "Determine Total Number of Lines";
            ReimportName = "Reimport";
            #endregion

            ValidationErrorTooltip = Strings.ValidationError;

            #region Values
            LowerBoundValue = 1;
            UpperBoundValue = 1000;
            SeparatorValue = ",";
            DetermineTotalNumberOfLinesValue = true;

            IsImporting = false;
            #endregion
        }
    }
}
