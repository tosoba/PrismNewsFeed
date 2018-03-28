using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using PrismNewsFeed.Models;
using PrismNewsFeed.Services;

namespace PrismNewsFeed.ViewModels
{
	public class TopHeadlinesPageViewModel : HeadlinesViewModelBase
	{
        public TopHeadlinesPageViewModel(INavigationService navigationService, IHeadlinesService headlinesService) : base(navigationService, headlinesService)
        {
            Title = "Top headlines";
            IsLoading = true;
        }

        public override async void OnNavigatingTo(NavigationParameters parameters)
        {
            base.OnNavigatingTo(parameters);
            Headlines = await _headlinesService.LoadTopHeadlines();
        }
    }
}
