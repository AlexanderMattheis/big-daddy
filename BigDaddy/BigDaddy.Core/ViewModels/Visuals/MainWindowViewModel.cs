namespace BigDaddy.Core
{
    public class MainWindowViewModel : ViewModel
    {
        public bool IsLoading { get; set; }

        public MainWindowViewModel(bool isDesignTime = false)
        {
            if (isDesignTime)
            {
                return;
            }

            IsLoading = false;
        }
    }
}
