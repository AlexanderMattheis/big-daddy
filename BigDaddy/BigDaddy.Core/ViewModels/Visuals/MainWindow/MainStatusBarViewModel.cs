using System;
using System.Windows.Input;

namespace BigDaddy.Core
{
    public class MainStatusBarViewModel : ViewModel
    {
        #region Names
        public string LinesName { get; set; }
        #endregion

        #region Values
        public int LinesValue { get; set; }

        public int TotalLinesValue { get; set; }

        public int ProgressBarValue { get; set; }

        public bool IsWorking { get; set; }

        public LoadingStatus ProgressBarStatus { get; set; }
        #endregion

        #region Commands
        public ICommand ReloadCommand { get; set; }
        #endregion

        public MainStatusBarViewModel(bool isDesignTime = false)
        {
            if (isDesignTime)
            {
                return;
            }

            #region Names
            LinesName = Strings.MainStatusBar_Lines;
            #endregion

            #region Values
            LinesValue = 0;
            TotalLinesValue = 0;
            ProgressBarValue = 0;
            IsWorking = false;
            ProgressBarStatus = LoadingStatusToStringConverter.ConvertBack(Strings.MainStatusBar_LoadingStatus__Ready);
            #endregion

            #region Commands
            ReloadCommand = new DefaultCommand(Reload);
            #endregion
        }

        #region Commands
        public void Reload() { }
        #endregion

        public enum LoadingStatus
        {
            Ready,
            Loading,
            Finished
        }

        private static class LoadingStatusToStringConverter
        {
            public static LoadingStatus ConvertBack(string value)
            {
                if (value.Equals(Strings.MainStatusBar_LoadingStatus__Ready))
                {
                    return LoadingStatus.Ready;
                }
                else if (value.Equals(Strings.MainStatusBar_LoadingStatus__Loading))
                {
                    return LoadingStatus.Loading;
                }
                else if (value.Equals(Strings.MainStatusBar_LoadingStatus__Finished))
                {
                    return LoadingStatus.Finished;
                }

                throw new ArgumentException($"There is no corresponding Enum value for the provided string {value}.");
            }
        }
    }
}
