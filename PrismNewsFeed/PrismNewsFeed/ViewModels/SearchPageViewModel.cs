using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using PrismNewsFeed.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using PrismNewsFeed.Models;
using Xamarin.Forms;
using System.Windows.Input;
using System.Threading.Tasks;
using Plugin.Connectivity;

namespace PrismNewsFeed.ViewModels
{
    public class SearchPageViewModel : HeadlinesViewModelBase
    {
        public SearchPageViewModel(INavigationService navigationService, INewsService headlinesService) : base(navigationService, headlinesService)
        {
            Title = "Search";
            IsLoading = false;
            Headlines = new List<Headline>();
        }

        private ICommand _searchCommand;
        public ICommand SearchCommand
        {
            get
            {
                return _searchCommand ?? (_searchCommand = new Command<string>(async (query) =>
                {
                    if (query.Any())
                    {
                        lastQuery = query;
                        if (CrossConnectivity.Current.IsConnected)
                        {
                            await LoadData();
                        }
                        else
                        {
                            ConnectionLost = true;
                        }
                    }
                }));
            }
        }

        private string lastQuery;

        private async Task SearchForHeadlines(string query)
        {
            Headlines = await _newsService.SearchHeadlines(query);
        }

        public override async Task LoadData()
        {
            if (lastQuery != null)
            {
                await base.LoadData();
                await SearchForHeadlines(lastQuery);
            }
        }
    }
}
