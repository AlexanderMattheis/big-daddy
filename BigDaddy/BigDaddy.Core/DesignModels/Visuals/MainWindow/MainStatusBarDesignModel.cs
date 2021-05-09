namespace BigDaddy.Core
{
    public class MainStatusBarDesignModel : MainStatusBarViewModel
    {
        public MainStatusBarDesignModel() : base(true)
        {
            LinesName = "Lines:";

            LinesValue = 200000;
            TotalLinesValue = 1000000;
            ProgressBarValue = 100;
            IsWorking = true;
            ProgressBarStatus = LoadingStatus.Loading;
        }
    }
}
