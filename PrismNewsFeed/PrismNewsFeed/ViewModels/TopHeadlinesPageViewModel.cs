using Plugin.Connectivity;
using Prism.Navigation;
using PrismNewsFeed.Constants;
using PrismNewsFeed.Models;
using PrismNewsFeed.Services;
using System;
using System.Net.Http;
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
            }
        }

        public override async Task LoadData()
        {
            if (_receivedOnNavigatingParameters != null)
            {
                await base.LoadData();
                if (_receivedOnNavigatingParameters.ContainsKey(NavigationKeys.headlinesSource))
                {
                    var source = _receivedOnNavigatingParameters[NavigationKeys.headlinesSource] as Source;
                    Title = source.Name;
                    Headlines = await _newsService.LoadTopHeadlines(source.Id);
                }
                else if (_receivedOnNavigatingParameters.ContainsKey(NavigationKeys.query))
                {
                    var query = (string)_receivedOnNavigatingParameters[NavigationKeys.query];
                    Title = query;
                    Headlines = await _newsService.SearchHeadlines(query);
                }
                else
                {
                    Headlines = await _newsService.LoadTopHeadlines();
                }
            }
        }
    }
}
