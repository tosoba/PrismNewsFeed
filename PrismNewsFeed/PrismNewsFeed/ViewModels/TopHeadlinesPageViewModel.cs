using Prism.Navigation;
using PrismNewsFeed.Constants;
using PrismNewsFeed.Models;
using PrismNewsFeed.Services;

namespace PrismNewsFeed.ViewModels
{
    public class TopHeadlinesPageViewModel : HeadlinesViewModelBase
	{
        public TopHeadlinesPageViewModel(INavigationService navigationService, INewsService headlinesService) : base(navigationService, headlinesService)
        {
            Title = "Top headlines";
        }

        public override async void OnNavigatingTo(NavigationParameters parameters)
        {
            base.OnNavigatingTo(parameters);

            if (!parameters.ContainsKey(NavigationKeys.headlinesSource))
            {
                Headlines = await _newsService.LoadTopHeadlines();
            }
            else
            {
                var source = (Source)parameters[NavigationKeys.headlinesSource];
                Title = source.Name;
                Headlines = await _newsService.LoadTopHeadlines(source.Id);
            }
        }
    }
}
