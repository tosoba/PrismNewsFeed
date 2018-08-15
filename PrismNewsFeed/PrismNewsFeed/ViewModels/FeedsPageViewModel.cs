using Prism.Navigation;

namespace PrismNewsFeed.ViewModels
{
    public class FeedsPageViewModel : ViewModelBase
    {
        public FeedsPageViewModel(INavigationService navigationService): base(navigationService)
        {
            Title = "PrismNews";
        }
    }
}
