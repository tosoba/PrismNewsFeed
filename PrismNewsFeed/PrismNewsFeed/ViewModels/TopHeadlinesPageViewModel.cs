using Plugin.Connectivity;
using Prism.Navigation;
using PrismNewsFeed.Constants;
using PrismNewsFeed.Models;
using PrismNewsFeed.Services;
using System.Threading.Tasks;

namespace PrismNewsFeed.ViewModels
{
    public class TopHeadlinesPageViewModel : HeadlinesViewModelBase
	{
        public TopHeadlinesPageViewModel(INavigationService navigationService, INewsService headlinesService) : base(navigationService, headlinesService)
        {
            Title = "Top headlines";
        }

        private NavigationParameters _receivedOnNavigatingParameters;

        public override async void OnNavigatingTo(NavigationParameters parameters)
        {
            base.OnNavigatingTo(parameters);
            _receivedOnNavigatingParameters = parameters;

            if (CrossConnectivity.Current.IsConnected)
            {
                await LoadData();
            }
            else
            {
                ConnectionLost = true;
                ShowNoConnectionDialog();
            }
        }

        public override async Task LoadData()
        {
            if (_receivedOnNavigatingParameters != null)
            {
                if (!_receivedOnNavigatingParameters.ContainsKey(NavigationKeys.headlinesSource))
                {
                    Headlines = await _newsService.LoadTopHeadlines();
                }
                else
                {
                    var source = _receivedOnNavigatingParameters[NavigationKeys.headlinesSource] as Source;
                    Title = source.Name;
                    Headlines = await _newsService.LoadTopHeadlines(source.Id);
                }
            }
        }
    }
}
