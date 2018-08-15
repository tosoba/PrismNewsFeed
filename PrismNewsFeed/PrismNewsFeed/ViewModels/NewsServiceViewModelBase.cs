using Prism.Navigation;
using PrismNewsFeed.Services;

namespace PrismNewsFeed.ViewModels
{
    public class NewsServiceViewModelBase : LoadingViewModelBase
    {
        protected INewsService _newsService;

        public NewsServiceViewModelBase(INavigationService navigationService, INewsService newsService) : base(navigationService)
        {
            _newsService = newsService;
            IsLoading = true;
        }
    }
}
