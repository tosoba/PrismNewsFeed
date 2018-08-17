using Prism.Navigation;

namespace PrismNewsFeed.ViewModels
{
    public class LoadingViewModelBase : ViewModelBase
    {
        private bool _isLoading;
        public bool IsLoading
        {
            get => _isLoading;
            set => SetProperty(ref _isLoading, value); 
        }

        public LoadingViewModelBase(INavigationService navigationService) : base(navigationService)
        {
        }
    }
}
